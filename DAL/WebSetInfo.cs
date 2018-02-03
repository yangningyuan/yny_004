using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DBUtility;

namespace yny_004.DAL
{
    public class WebSetInfo
    {
        private static Model.WebSetInfo _model;
        public static Model.WebSetInfo Model
        {
            get
            {
                //if (_model == null)
                _model = GetModel();
                return _model;
            }
            set
            {
                _model = value;
            }
        }
        public static bool Update(Model.WebSetInfo model)
        {
            StringBuilder sb = new StringBuilder("update WebSetInfo set ");
            sb.Append("WebState=@WebState,");
            sb.Append("WebTitle=@WebTitle,");
            sb.Append("WKeyword=@WKeyword,");
            sb.Append("WDescription=@WDescription,");
            sb.Append("OpenTimeStr=@OpenTimeStr,");
            sb.Append("CloseInfo=@CloseInfo,");
            sb.Append("TXInfo=@TXInfo,");
            sb.Append("WCopyright=@WCopyright,");
            sb.Append("HKInfo=@HKInfo,");
            sb.Append("PageSize=@PageSize");

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@WebState",SqlDbType.Bit,1),
                new SqlParameter("@WebTitle",SqlDbType.NVarChar,255),
                new SqlParameter("@WKeyword",SqlDbType.NVarChar,255),
                new SqlParameter("@WDescription",SqlDbType.NVarChar,255),
                new SqlParameter("@OpenTimeStr",SqlDbType.VarChar,100),
                new SqlParameter("@CloseInfo",SqlDbType.NVarChar,255),
                new SqlParameter("@TXInfo",SqlDbType.NVarChar,255),
                new SqlParameter("@HKInfo",SqlDbType.NVarChar,255),
                new SqlParameter("@WCopyright",SqlDbType.NVarChar,255),
                new SqlParameter("@PageSize",SqlDbType.Int,4)
            };
            para[0].Value = model.WebState;
            para[1].Value = model.WebTitle;
            para[2].Value = model.WKeyword;
            para[3].Value = model.WDescription;
            para[4].Value = model.OpenTimeStr;
            para[5].Value = model.CloseInfo;
            para[6].Value = model.TXInfo;
            para[7].Value = model.HKInfo;
            para[8].Value = model.WCopyright;
            para[9].Value = model.PageSize;
            Model = null;
            return DbHelperSQL.ExecuteSql(sb.ToString(), para) > 0;
        }

        private static Model.WebSetInfo GetModel()
        {
            string SqlStr = "select top 1 * from WebSetInfo";
            DataTable table = DbHelperSQL.Query(SqlStr).Tables[0];
            if (table.Rows.Count > 0)
            {
                return TranEntity(table.Rows[0]);
            }
            return null;
        }

        private static Model.WebSetInfo TranEntity(DataRow dr)
        {
            Model.WebSetInfo model = new Model.WebSetInfo();
            if (!string.IsNullOrEmpty(dr["WebState"].ToString()))
            {
                model.WebState = bool.Parse(dr["WebState"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["WebTitle"].ToString()))
            {
                model.WebTitle = dr["WebTitle"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["WKeyword"].ToString()))
            {
                model.WKeyword = dr["WKeyword"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["WDescription"].ToString()))
            {
                model.WDescription = dr["WDescription"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["OpenTimeStr"].ToString()))
            {
                model.OpenTimeStr = dr["OpenTimeStr"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["CloseInfo"].ToString()))
            {
                model.CloseInfo = dr["CloseInfo"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["TXInfo"].ToString()))
            {
                model.TXInfo = dr["TXInfo"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["HKInfo"].ToString()))
            {
                model.HKInfo = dr["HKInfo"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["WCopyright"].ToString()))
            {
                model.WCopyright = dr["WCopyright"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["PageSize"].ToString()))
            {
                model.PageSize = int.Parse(dr["PageSize"].ToString());
            }
            return model;
        }
    }
}
