using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBUtility;

namespace yny_004.DAL
{
    public class Reward
    {
        private static Dictionary<string, Model.Reward> _list;
        public static Dictionary<string, Model.Reward> List
        {
            get
            {
                if (_list == null || _list.Count == 0)
                {
                    _list = new Dictionary<string, Model.Reward>();
                    foreach (Model.Reward item in GetList("RewardState='1'"))
                    {
                        _list.Add(item.RewardType, item);
                    }
                }
                return _list;
            }
            set
            {
                _list = value;
            }
        }

        public static string RewardStr
        {
            get
            {
                string str = "";
                foreach (Model.Reward item in List.Values)
                {
                    if (item.RewardState && item.NeedProcess)
                        str += item.RewardType + "(" + item.RewardName + "),";
                }
                return str;
            }
        }

        public static string AllRewardStr
        {
            get
            {
                string jjtype = "'";
                foreach (Model.Reward item in DAL.Reward.List.Values)
                {
                    if (item.NeedProcess)
                        jjtype += item.RewardType + "','";
                }
                jjtype = jjtype.Substring(0, jjtype.LastIndexOf(",'"));
                return jjtype;
            }
        }

        public static System.Data.DataTable GetTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RewardType,RewardName,RewardState,NeedProcess,RewardIndex ");
            strSql.Append(" FROM Reward ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by RewardIndex");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        public static List<Model.Reward> GetList(string strWhere)
        {
            List<Model.Reward> list = new List<Model.Reward>();

            DataTable table = GetTable(strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(DataRowToModel(table.Rows[i]));
            }

            return list;
        }

        private static Model.Reward DataRowToModel(DataRow row)
        {
            yny_004.Model.Reward model = new yny_004.Model.Reward();
            if (row != null)
            {
                if (row["RewardType"] != null && row["RewardType"].ToString() != "")
                {
                    model.RewardType = row["RewardType"].ToString();
                }
                if (row["RewardName"] != null)
                {
                    model.RewardName = row["RewardName"].ToString();
                }
                if (row["RewardState"] != null && row["RewardState"].ToString() != "")
                {
                    model.RewardState = bool.Parse(row["RewardState"].ToString());
                }
                if (row["NeedProcess"] != null && row["NeedProcess"].ToString() != "")
                {
                    model.NeedProcess = bool.Parse(row["NeedProcess"].ToString());
                }
                if (row["RewardIndex"] != null && row["RewardIndex"].ToString() != "")
                {
                    model.RewardIndex = int.Parse(row["RewardIndex"].ToString());
                }
            }
            return model;
        }
    }
}
