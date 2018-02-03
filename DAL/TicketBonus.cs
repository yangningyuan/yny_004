using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBUtility;
using System.Data.SqlClient;
using System.Collections;

namespace yny_004.DAL
{
    //TicketBonus
    public class TicketBonus
    {
        private static Model.TicketBonus _Model;

        public static Model.TicketBonus Model
        {
            get
            {
                if (_Model == null)
                    _Model = GetModel();
                return _Model;
            }
            set
            {
                _Model = value;
            }

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Model.TicketBonus model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TicketBonus set ");

            strSql.Append(" Percents = @Percents , ");
            strSql.Append(" StartTime = @StartTime , ");
            strSql.Append(" EndTime = @EndTime , ");
            strSql.Append(" BonusPlan = @BonusPlan , ");
            strSql.Append(" Money = @Money , ");
            strSql.Append(" PlayBonus = @PlayBonus , ");
            strSql.Append(" AboutBonus = @AboutBonus , ");
            strSql.Append(" TicketState = @TicketState  ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@Percents", SqlDbType.Int,4) ,            
                        new SqlParameter("@StartTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@EndTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@BonusPlan", SqlDbType.VarChar,10) ,         
                        new SqlParameter("@Money", SqlDbType.Decimal) ,             
                        new SqlParameter("@PlayBonus", SqlDbType.Int,4) ,       
                        new SqlParameter("@AboutBonus", SqlDbType.VarChar,250) ,    
                        new SqlParameter("@TicketState", SqlDbType.Bit,1)             
              
            };

            parameters[0].Value = model.Percents;
            parameters[1].Value = model.StartTime;
            parameters[2].Value = model.EndTime;
            parameters[3].Value = model.BonusPlan;
            parameters[4].Value = model.Money;
            parameters[5].Value = model.PlayBonus;
            parameters[6].Value = model.AboutBonus;
            parameters[7].Value = model.TicketState;

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        public static bool Update(Model.TicketBonus model)
        {
            DAL.TicketBonus.Model = null;
            return DAL.CommonBase.RunHashtable(Update(model, new System.Collections.Hashtable()));
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.TicketBonus GetModel()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 *  ");
            strSql.Append("  from TicketBonus ");


            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        private static Model.TicketBonus DataRowToModel(DataRow row)
        {
            if (row != null)
            {
                Model.TicketBonus model = new Model.TicketBonus();
                if (row["Percents"].ToString() != "")
                {
                    model.Percents = int.Parse(row["Percents"].ToString());
                }
                if (row["PlayBonus"].ToString() != "")
                {
                    model.PlayBonus = int.Parse(row["PlayBonus"].ToString());
                }
                if (row["StartTime"].ToString() != "")
                {
                    model.StartTime = DateTime.Parse(row["StartTime"].ToString());
                }
                if (row["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(row["EndTime"].ToString());
                }
                if (row["Money"].ToString() != "")
                {
                    model.Money = decimal.Parse(row["Money"].ToString());
                }
                model.AboutBonus = row["AboutBonus"].ToString();
                model.BonusPlan = row["BonusPlan"].ToString();
                model.GiftList = DAL.BonusGift.GetList("BonusPlan='" + model.BonusPlan + "'");
                if (row["TicketState"].ToString() != "")
                {
                    model.TicketState = bool.Parse(row["TicketState"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

    }
}
