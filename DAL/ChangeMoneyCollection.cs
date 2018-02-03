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
    public class ChangeMoneyCollection
    {
        /// <summary>
        /// 得到提现实体列表
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static List<Model.ChangeMoney> GetChangeMoneyEntityList(string frommid, string tomid, string shmid, string state, List<string> cTypeList, List<string> mTypeList, int pageIndex, int pageSize, string strWhere, out int count)
        {
            List<Model.ChangeMoney> ChangeMoneyList = new List<Model.ChangeMoney>();
            strWhere += @" and ChangeType in ('" + String.Join("','", cTypeList.ToArray()) +
                "') and MoneyType in ('" + String.Join("','", mTypeList.ToArray()) + "') ";
            if (!string.IsNullOrEmpty(frommid))
                strWhere += " and (FromMID='" + frommid + "' or  FromMName like '%" + frommid + "%')";
            if (!string.IsNullOrEmpty(tomid))
                strWhere += " and (ToMID='" + tomid + "' or  ToMName like '%" + tomid + "%' )";
            if (!string.IsNullOrEmpty(state))
                strWhere += " and CState='" + (bool.Parse(state) ? "1" : "0") + "'";
            if (!string.IsNullOrEmpty(shmid))
                strWhere += " and SHMID='" + shmid + "' ";
            DataTable table = GetChangeMoneyTable(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                ChangeMoneyList.Add(DAL.ChangeMoney.TranEntity(table.Rows[i]));
            }
            return ChangeMoneyList;
        }

        public static DataTable GetChangeMoneyTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.CommonBase.GetTable("View_ChangeMoney", "CID", "ChangeDate desc,CID desc ", strWhere, pageIndex, pageSize, out count);
        }

        /// <summary>
        /// 得到奖金信息实体数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        private static DataTable GetChangeMoneyList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM ChangeMoney ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        private static DataTable GetChangeMoneyList(int top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + top + " * ");
            strSql.Append(" FROM ChangeMoney ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 得到奖金信息实体数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        private static DataTable GetTopChangeMoneyList(int top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + top + " * ");
            strSql.Append(" FROM ChangeMoney ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 得到奖金信息实体列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static List<Model.ChangeMoney> GetChangeMoneyEntityList(string strWhere)
        {
            List<Model.ChangeMoney> MemberList = new List<Model.ChangeMoney>();

            DataTable table = GetChangeMoneyList(strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                MemberList.Add(DAL.ChangeMoney.TranEntity(table.Rows[i]));
            }

            return MemberList;
        }

        /// <summary>
        /// 得到提现实体列表
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static List<Model.ChangeMoney> GetChangeMoneyEntityList(string frommid, string tomid, string shmid, string state, List<string> cTypeList, List<string> mTypeList, string strWhere)
        {
            List<Model.ChangeMoney> ChangeMoneyList = new List<Model.ChangeMoney>();
            strWhere += @" and ChangeType in ('" + String.Join("','", cTypeList.ToArray()) +
                "') and MoneyType in ('" + String.Join("','", mTypeList.ToArray()) + "') ";
            if (!string.IsNullOrEmpty(frommid))
                strWhere += " and FromMID='" + frommid + "'";
            if (!string.IsNullOrEmpty(tomid))
                strWhere += " and ToMID='" + tomid + "'";
            if (!string.IsNullOrEmpty(state))
                strWhere += " and CState='" + (bool.Parse(state) ? "1" : "0") + "'";
            if (!string.IsNullOrEmpty(shmid))
                strWhere += " and SHMID='" + shmid + "' ";
            DataTable table = GetChangeMoneyList(strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                ChangeMoneyList.Add(DAL.ChangeMoney.TranEntity(table.Rows[i]));
            }
            return ChangeMoneyList;
        }

        public static List<Model.ChangeMoney> GetChangeMoneyEntityList(int top, string strWhere)
        {
            List<Model.ChangeMoney> MemberList = new List<Model.ChangeMoney>();

            DataTable table = GetChangeMoneyList(top, strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                MemberList.Add(DAL.ChangeMoney.TranEntity(table.Rows[i]));
            }

            return MemberList;
        }
        /// <summary>
        /// 得到奖金信息实体列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static List<Model.ChangeMoney> GetTopChangeMoneyEntityList(int top, string strWhere)
        {
            List<Model.ChangeMoney> MemberList = new List<Model.ChangeMoney>();

            DataTable table = GetTopChangeMoneyList(top, strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                MemberList.Add(DAL.ChangeMoney.TranEntity(table.Rows[i]));
            }

            return MemberList;
        }
    }
}
