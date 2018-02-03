using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DBUtility;

namespace yny_004.DAL
{
    public class Notice
    {
        public static bool Add(Model.Notice model)
        {
            string sb = " Update Notice set IsFixed=0; ";
            if (!model.IsFixed)
            {
                sb = "";
            }
            sb = "insert into Notice(NTitle,NContent,IsFixed) values (@NTitle,@NContent,@IsFixed)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@NTitle", SqlDbType.NVarChar,200),
                new SqlParameter("@NContent",SqlDbType.Text),
                new SqlParameter("@IsFixed",SqlDbType.Bit,1)
            };

            para[0].Value = model.NTitle;
            para[1].Value = model.NContent;
            para[2].Value = model.IsFixed;
            if (DbHelperSQL.ExecuteSql(sb, para) > 0)
                return true;
            return false;
        }

        public static bool Update(Model.Notice model)
        {
            string sb = " Update Notice set IsFixed=0; ";
            if (!model.IsFixed)
            {
                sb = "";
            }
            sb += "Update Notice set NTitle=@NTitle,NContent=@NContent,NState=@NState,IsFixed=@IsFixed where ID=@ID";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@NTitle", SqlDbType.NVarChar,200),
                new SqlParameter("@NContent",SqlDbType.Text),
                new SqlParameter("@NState",SqlDbType.Bit),
                new SqlParameter("@ID",SqlDbType.Int,4),
                new SqlParameter("@IsFixed",SqlDbType.Bit,4)
            };

            para[0].Value = model.NTitle;
            para[1].Value = model.NContent;
            para[2].Value = model.NState;
            para[3].Value = model.ID;
            para[4].Value = model.IsFixed;

            if (DbHelperSQL.ExecuteSql(sb, para) > 0)
                return true;
            return false;
        }

        public static bool UpDateNStateNIDList(string cidList, bool nstate)
        {
            string sb = "Update Notice set NState=@NState where ID in (" + cidList + ")";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@NState",SqlDbType.Bit)
            };

            para[0].Value = nstate;

            if (DbHelperSQL.ExecuteSql(sb, para) > 0)
                return true;
            return false;
        }

        public static Model.Notice Select(int Id, bool isRead)
        {
            string sb = "select * from Notice where ID=@ID;";
            if (isRead)
                sb += "update Notice set NClicks=NClicks+1 where ID=@ID";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@ID",SqlDbType.Int,4)
            };

            para[0].Value = Id;

            DataSet ds = DbHelperSQL.Query(sb, para);

            if (ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            return null;
        }

        public static DataTable GetNoticeTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Notice ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        public static List<Model.Notice> GetNoticeList(string strWhere)
        {
            List<Model.Notice> list = new List<Model.Notice>();
            DataTable dt = GetNoticeTable(strWhere);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(TranEntity(row));
            }
            return list;
        }

        private static Model.Notice TranEntity(DataRow dr)
        {
            Model.Notice model = new Model.Notice();

            if (dr["ID"] != null)
            {
                model.ID = int.Parse(dr["ID"].ToString());
            }
            if (dr["NTitle"] != null)
            {
                model.NTitle = dr["NTitle"].ToString();
            }
            if (dr["NContent"] != null)
            {
                model.NContent = dr["NContent"].ToString();
            }
            if (dr["NClicks"].ToString() != "")
            {
                model.NClicks = int.Parse(dr["NClicks"].ToString());
            }
            if (dr["NState"].ToString() != "")
            {
                model.NState = bool.Parse(dr["NState"].ToString());
            }
            if (dr["NCreateTime"].ToString() != "")
            {
                model.NCreateTime = DateTime.Parse(dr["NCreateTime"].ToString());
            }
            if (dr["IsFixed"].ToString() != "")
            {
                model.IsFixed = bool.Parse(dr["IsFixed"].ToString());
            }
            return model;
        }

        public static Model.Notice GetNewNotice(int days)
        {
            string sb = "select top 1 * from Notice where NState='1' and IsFixed = 1 and NCreateTime > CONVERT(varchar(10),DATEADD(DD," + -days + ",GETDATE()),120) order by ID desc";

            DataSet ds = DbHelperSQL.Query(sb);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Model.Notice model = TranEntity(ds.Tables[0].Rows[0]);
                model.NContent = CheckStr(model.NContent);
                return model;
            }
            else
                return null;
        }

        public static List<Model.Notice> GetNoticeEntityList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.Notice> NoticeList = new List<Model.Notice>();
            DataTable table = GetNoticeList(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                NoticeList.Add(TranEntity(table.Rows[i]));
            }
            return NoticeList;
        }

        private static DataTable GetNoticeList(string strWhere, int pageIndex, int pageSize, out int count, params string[] order)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@TableName", SqlDbType.VarChar, 50),
                    new SqlParameter("@FieldList", SqlDbType.VarChar, 50),
                    new SqlParameter("@PrimaryKey", SqlDbType.VarChar, 50),
                    new SqlParameter("@Where", SqlDbType.VarChar, 500),
                    new SqlParameter("@Order", SqlDbType.VarChar, 50),
                    new SqlParameter("@SortType", SqlDbType.Int,4),
                    new SqlParameter("@RecorderCount", SqlDbType.Int,4),
                    new SqlParameter("@PageSize", SqlDbType.Int,4),
                    new SqlParameter("@PageIndex", SqlDbType.Int,4),
                    new SqlParameter("@TotalCount", SqlDbType.Int,4),
                    new SqlParameter("@TotalPageCount", SqlDbType.Int,4)};
            parameters[0].Value = "Notice";
            parameters[1].Value = "*";
            parameters[2].Value = "ID";
            parameters[3].Value = strWhere;
            if (order.Length == 0)
                parameters[4].Value = "ID desc";
            else
                parameters[4].Value = order[0];
            parameters[5].Value = 3;
            parameters[6].Value = 0;
            parameters[7].Value = pageSize;
            parameters[8].Value = pageIndex;
            parameters[9].Direction = ParameterDirection.InputOutput;
            parameters[10].Direction = ParameterDirection.InputOutput;

            DataTable table = DbHelperSQL.RunProcedure("P_AspNetPage", parameters, "noticeTable").Tables[0];
            count = Convert.ToInt32(parameters[9].Value);
            return table;
        }

        public static bool HideNotice(string IDList)
        {
            string sb = "update Notice set NState='0' where ID in (" + IDList + ")";
            return DbHelperSQL.ExecuteSql(sb) > 0;
        }

        public static bool ShowNotice(string IDList)
        {
            string sb = "update Notice set NState='1' where ID in (" + IDList + ")";
            return DbHelperSQL.ExecuteSql(sb) > 0;
        }

        public static bool DeleteNotice(string IDList)
        {
            string sb = "delete from Notice where ID in (" + IDList + ")";
            return DbHelperSQL.ExecuteSql(sb) > 0;
        }

        public static Model.Notice GetTopNotice()
        {
            string sb = "select top 1 * from Notice where NState='1' order by IsFixed desc,NCreateTime desc";

            DataSet ds = DbHelperSQL.Query(sb);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Model.Notice model = TranEntity(ds.Tables[0].Rows[0]);
                model.NContent = CheckStr(model.NContent) + "[" + model.NCreateTime.ToShortDateString() + "]";
                return model;
            }
            else
                return null;
        }

        public static List<Model.Notice> GetNoticeLists(int top, bool isTop = false)
        {
            string isTopStr = "";
            if (isTop)
            {
                isTopStr = " and IsFixed = 1 ";
            }
            List<Model.Notice> NoticeList = new List<Model.Notice>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + top + " * ");
            strSql.Append(" FROM Notice where NState='1' " + isTopStr + " order by NCreateTime desc ");
            DataTable table = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                NoticeList.Add(TranEntity(table.Rows[i]));
            }
            return NoticeList;
        }

        private static string CheckStr(string html)
        {
            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" no[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex6 = new System.Text.RegularExpressions.Regex(@"\<img[^\>]+\>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex7 = new System.Text.RegularExpressions.Regex(@"</p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex8 = new System.Text.RegularExpressions.Regex(@"<p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex9 = new System.Text.RegularExpressions.Regex(@"<[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex1.Replace(html, ""); //过滤<script></script>标记 
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性 
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件 
            html = regex4.Replace(html, ""); //过滤iframe 
            html = regex5.Replace(html, ""); //过滤frameset 
            html = regex6.Replace(html, ""); //过滤frameset 
            html = regex7.Replace(html, ""); //过滤frameset 
            html = regex8.Replace(html, ""); //过滤frameset 
            html = regex9.Replace(html, "");
            html = html.Replace(" ", "");
            html = html.Replace("</strong>", "");
            html = html.Replace("<strong>", "");
            html = html.Replace(@"\<img[^\>]+\>", "");
            html = html.Replace(@"<p>", "");
            html = html.Replace(@"</p>", "");
            html = html.Replace("&nbsp;", " ");
            return html;
        }
    }
}
