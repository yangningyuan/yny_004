using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DBUtility;
using System.Collections;

namespace yny_004.DAL
{
    public class MemberCollection
    {
        #region 会员集合信息查询

        /// <summary>
        /// 得到会员及附属信息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        private static DataTable GetTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Member.*"
                + ",MemberConfig.* ");
            strSql.Append(" FROM Member inner join MemberConfig ");
            strSql.Append(" on Member.MID=MemberConfig.MID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 得到会员及附属信息实体列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public static List<Model.Member> GetMemberAndConfigEntityList(string strWhere)
        {
            List<Model.Member> MemberList = new List<Model.Member>();

            DataTable table = GetTable(strWhere);
            table.TableName = "MemberAndConfig";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                MemberList.Add(DAL.Member.TranEntity(table.Rows[i]));
            }

            return MemberList;
        }

        /// <summary>
        /// 得到会员信息数据
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>返回DataTable</returns>
        private static DataTable GetMemberList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" from Member ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 得到会员信息数据
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>返回DataTable</returns>
        private static DataTable GetTopMemberList(int top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + top + " * ");
            strSql.Append(" from Member ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 得到会员信息实体列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public static List<Model.Member> GetMemberEntityList(string strWhere)
        {
            List<Model.Member> MemberList = new List<Model.Member>();

            DataTable table = GetMemberList(strWhere);
            table.TableName = "Member";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                MemberList.Add(DAL.Member.TranEntity(table.Rows[i]));
            }

            return MemberList;
        }

        /// <summary>
        /// 得到会员信息实体列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public static List<Model.Member> GetTopMemberEntityList(int top, string strWhere)
        {
            List<Model.Member> MemberList = new List<Model.Member>();

            DataTable table = GetTopMemberList(top, strWhere);
            table.TableName = "Member";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                MemberList.Add(DAL.Member.TranEntity(table.Rows[i]));
            }

            return MemberList;
        }


        /// <summary>
        /// 得到分页会员信息实体列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="count">out类型总计</param>
        /// <returns>返回会员List集合</returns>
        public static List<Model.Member> GetMemberEntityList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.Member> MemberList = new List<Model.Member>();

            DataTable table = GetTable(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                MemberList.Add(DAL.Member.TranEntity(table.Rows[i]));
            }

            return MemberList;
        }
        /// <summary>
        /// 得到分页会员信息数据
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="count">out类型总计</param>
        /// <returns>返回DataTable</returns>
        private static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return CommonBase.GetTable("Member", "MID", "MCreateDate desc,MID asc", strWhere, pageIndex, pageSize, out count);
        }
        #endregion
    }
}
