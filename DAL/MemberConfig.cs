using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using DBUtility;

namespace yny_004.DAL
{
    public class MemberConfig
    {
        /// <summary>
        /// 更新会员参数值
        /// </summary>
        /// <param name="mid">会员账号</param>
        /// <param name="ConfigValue">参数值</param>
        /// <param name="ConfigName">参数名称</param>
        /// <param name="MyHs"></param>
        /// <returns></returns>
        public static Hashtable UpdateConfigTran(string mid, string fieldName, string fieldValue, Model.Member shmodel, bool isEqual, SqlDbType dataType, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            string guid = Guid.NewGuid().ToString();
            strSql.Append("update MemberConfig set ");
            if (isEqual)
            {
                if (dataType == SqlDbType.Int || dataType == SqlDbType.Decimal)
                    strSql.Append(string.Format("{0} = {1} ", fieldName, fieldValue));
                else
                    strSql.Append(string.Format("{0} = '{1}' ", fieldName, fieldValue));
            }
            else
            {
                if (dataType == SqlDbType.Int || dataType == SqlDbType.Decimal)
                    strSql.Append(string.Format("{0} = {0} + {1} ", fieldName, fieldValue));
                else
                    strSql.Append(string.Format("{0} = '{0}' + '{1}' ", fieldName, fieldValue));
            }
            strSql.Append(string.Format(" where MID='{0}' and '{1}'='{1}'", mid, guid));

            if (isEqual)
                MyHs.Add(strSql, "1");
            else
                MyHs.Add(strSql, null);
            return MyHs;
        }
        /// <summary>
        /// 得到配置信息
        /// </summary>
        /// <param name="MID"></param>
        /// <param name="mhb"></param>
        /// <returns></returns>
        public static Model.MemberConfig GetModel(string MID, Model.Member member)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from MemberConfig");
            strSql.Append(" where MID=@MID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MID", SqlDbType.VarChar,20)};
            parameters[0].Value = MID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0], member);
            return null;
        }

        public static Hashtable Insert(Model.MemberConfig model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MemberConfig(");
            strSql.Append("MID,TakeOffMoney,ReBuyMoney,TotalTXMoney,JJTypeList,MHB,MJB,MCW,MGP,DTFHState,JTFHState,SHMoney,TotalDFHMoney,TotalZFHMoney,TotalYFHMoney,HLGQCount,GQCount,TXStatus,YJCount,ZZStatus,YJMoney,TJCount,TJMoney,UpSumMoney,TotalMoney,RealMoney,EPXingCount,EPTimeOutCount,TJFloat");
            strSql.Append(") values (");
            strSql.Append("@MID,@TakeOffMoney,@ReBuyMoney,@TotalTXMoney,@JJTypeList,@MHB,@MJB,@MCW,@MGP,@DTFHState,@JTFHState,@SHMoney,@TotalDFHMoney,@TotalZFHMoney,@TotalYFHMoney,@HLGQCount,@GQCount,@TXStatus,@YJCount,@ZZStatus,@YJMoney,@TJCount,@TJMoney,@UpSumMoney,@TotalMoney,@RealMoney,@EPXingCount,@EPTimeOutCount,@TJFloat");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
			            new SqlParameter("@MID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@TakeOffMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ReBuyMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalTXMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@JJTypeList", SqlDbType.VarChar,300) ,            
                        new SqlParameter("@MHB", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@MJB", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@MCW", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@MGP", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@DTFHState", SqlDbType.Bit,1) ,            
                        new SqlParameter("@JTFHState", SqlDbType.Bit,1) ,            
                        new SqlParameter("@SHMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalDFHMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalZFHMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalYFHMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@HLGQCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@GQCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@TXStatus", SqlDbType.Bit,1) ,            
                        new SqlParameter("@YJCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@ZZStatus", SqlDbType.Bit,1) ,            
                        new SqlParameter("@YJMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TJCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@TJMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@UpSumMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalMoney", SqlDbType.Decimal,9),
                        new SqlParameter("@RealMoney", SqlDbType.Decimal,9),
                        new SqlParameter("@EPTimeOutCount", SqlDbType.Int,4),
                        new SqlParameter("@EPXingCount", SqlDbType.Int,4),
                        new SqlParameter("@TJFloat", SqlDbType.Decimal,9)
            };

            parameters[0].Value = model.MID;
            parameters[1].Value = model.TakeOffMoney;
            parameters[2].Value = model.ReBuyMoney;
            parameters[3].Value = model.TotalTXMoney;
            parameters[4].Value = model.JJTypeList;
            parameters[5].Value = model.MHB;
            parameters[6].Value = model.MJB;
            parameters[7].Value = model.MCW;
            parameters[8].Value = model.MGP;
            parameters[9].Value = model.DTFHState;
            parameters[10].Value = model.JTFHState;
            parameters[11].Value = model.SHMoney;
            parameters[12].Value = model.TotalDFHMoney;
            parameters[13].Value = model.TotalZFHMoney;
            parameters[14].Value = model.TotalYFHMoney;
            parameters[15].Value = model.HLGQCount;
            parameters[16].Value = model.GQCount;
            parameters[17].Value = model.TXStatus;
            parameters[18].Value = model.YJCount;
            parameters[19].Value = model.ZZStatus;
            parameters[20].Value = model.YJMoney;
            parameters[21].Value = model.TJCount;
            parameters[22].Value = model.TJMoney;
            parameters[23].Value = model.UpSumMoney;
            parameters[24].Value = model.TotalMoney;
            parameters[25].Value = model.RealMoney;
            parameters[26].Value = model.EPTimeOutCount;
            parameters[27].Value = model.EPXingCount;
            parameters[28].Value = model.TJFloat;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }
        public static Hashtable Update(Model.MemberConfig model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MemberConfig set ");

            strSql.Append(" MID = @MID , ");
            strSql.Append(" TakeOffMoney = @TakeOffMoney , ");
            strSql.Append(" ReBuyMoney = @ReBuyMoney , ");
            strSql.Append(" TotalTXMoney = @TotalTXMoney , ");
            strSql.Append(" JJTypeList = @JJTypeList , ");
            strSql.Append(" MHB = @MHB , ");
            strSql.Append(" MJB = @MJB , ");
            strSql.Append(" MCW = @MCW , ");
            strSql.Append(" MGP = @MGP , ");
            strSql.Append(" DTFHState = @DTFHState , ");
            strSql.Append(" JTFHState = @JTFHState , ");
            strSql.Append(" SHMoney = @SHMoney , ");
            strSql.Append(" TotalDFHMoney = @TotalDFHMoney , ");
            strSql.Append(" TotalZFHMoney = @TotalZFHMoney , ");
            strSql.Append(" TotalYFHMoney = @TotalYFHMoney , ");
            strSql.Append(" HLGQCount = @HLGQCount , ");
            strSql.Append(" GQCount = @GQCount , ");
            strSql.Append(" TXStatus = @TXStatus , ");
            strSql.Append(" YJCount = @YJCount , ");
            strSql.Append(" ZZStatus = @ZZStatus , ");
            strSql.Append(" YJMoney = @YJMoney , ");
            strSql.Append(" TJCount = @TJCount , ");
            strSql.Append(" TJMoney = @TJMoney , ");
            strSql.Append(" UpSumMoney = @UpSumMoney , ");
            strSql.Append(" TotalMoney = @TotalMoney , ");
            strSql.Append(" TJFloat = @TJFloat , ");
            strSql.Append(" EPXingCount = @EPXingCount , ");
            strSql.Append(" EPTimeOutCount = @EPTimeOutCount , ");
            strSql.Append(" RealMoney = @RealMoney  ");
            strSql.Append(" where MID=@MID  ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@MID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@TakeOffMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ReBuyMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalTXMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@JJTypeList", SqlDbType.VarChar,300) ,            
                        new SqlParameter("@MHB", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@MJB", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@MCW", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@MGP", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@DTFHState", SqlDbType.Bit,1) ,            
                        new SqlParameter("@JTFHState", SqlDbType.Bit,1) ,            
                        new SqlParameter("@SHMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalDFHMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalZFHMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalYFHMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@HLGQCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@GQCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@TXStatus", SqlDbType.Bit,1) ,            
                        new SqlParameter("@YJCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@ZZStatus", SqlDbType.Bit,1) ,            
                        new SqlParameter("@YJMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TJCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@TJMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@UpSumMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalMoney", SqlDbType.Decimal,9),
                        new SqlParameter("@RealMoney", SqlDbType.Decimal,9),
                        new SqlParameter("@EPTimeOutCount", SqlDbType.Int,4),
                        new SqlParameter("@EPXingCount", SqlDbType.Int,4),
                        new SqlParameter("@TJFloat", SqlDbType.Decimal,9)
              
            };
            parameters[0].Value = model.MID;
            parameters[1].Value = model.TakeOffMoney;
            parameters[2].Value = model.ReBuyMoney;
            parameters[3].Value = model.TotalTXMoney;
            parameters[4].Value = model.JJTypeList;
            parameters[5].Value = model.MHB;
            parameters[6].Value = model.MJB;
            parameters[7].Value = model.MCW;
            parameters[8].Value = model.MGP;
            parameters[9].Value = model.DTFHState;
            parameters[10].Value = model.JTFHState;
            parameters[11].Value = model.SHMoney;
            parameters[12].Value = model.TotalDFHMoney;
            parameters[13].Value = model.TotalZFHMoney;
            parameters[14].Value = model.TotalYFHMoney;
            parameters[15].Value = model.HLGQCount;
            parameters[16].Value = model.GQCount;
            parameters[17].Value = model.TXStatus;
            parameters[18].Value = model.YJCount;
            parameters[19].Value = model.ZZStatus;
            parameters[20].Value = model.YJMoney;
            parameters[21].Value = model.TJCount;
            parameters[22].Value = model.TJMoney;
            parameters[23].Value = model.UpSumMoney;
            parameters[24].Value = model.TotalMoney;
            parameters[25].Value = model.RealMoney;
            parameters[26].Value = model.EPTimeOutCount;
            parameters[27].Value = model.EPXingCount;
            parameters[28].Value = model.TJFloat;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 实体转换
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="mhb"></param>
        /// <returns></returns>
        public static Model.MemberConfig TranEntity(DataRow dr, Model.Member member)
        {
            Model.MemberConfig model = new Model.MemberConfig();

            model.MID = dr["MID"].ToString();
            if (member != null)
                model.Member = member;
            else
                model.Member = DAL.Member.GetModel(model.MID);
            if (!string.IsNullOrEmpty(dr["TakeOffMoney"].ToString()))
            {
                model.TakeOffMoney = decimal.Parse(dr["TakeOffMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["ReBuyMoney"].ToString()))
            {
                model.ReBuyMoney = decimal.Parse(dr["ReBuyMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TotalTXMoney"].ToString()))
            {
                model.TotalTXMoney = decimal.Parse(dr["TotalTXMoney"].ToString());
            }
            model.JJTypeList = dr["JJTypeList"].ToString();
            if (!string.IsNullOrEmpty(dr["MHB"].ToString()))
            {
                model.MHB = decimal.Parse(dr["MHB"].ToString());
                //model.MHBFreeze = DAL.Configuration.TModel.YLMoney + DAL.ChangeMoney.GetAllTx(model.MID);
                model.MHBFreeze = DAL.Configuration.TModel.B_YLMoney;
                model.MJJ = model.MHB - model.MHBFreeze;
                if (model.MJJ < 0)
                    model.MJJ = 0;
            }
            if (!string.IsNullOrEmpty(dr["MJB"].ToString()))
            {
                model.MJB = decimal.Parse(dr["MJB"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["MCW"].ToString()))
            {
                //model.MCW = decimal.Parse(DAl.MGP_BuyRecord.CountTotalMCW(model.MID));
                model.MCW = decimal.Parse(dr["MCW"].ToString());
            }
            //if (!string.IsNullOrEmpty(dr["MGP"].ToString()))
            {
                model.MGP = DAL.StockRight.GetSellCount(string.Format(" and MID = '{0}' and IsValid = 1 ", model.MID));
                //model.MGP = decimal.Parse(dr["MGP"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["DTFHState"].ToString()))
            {
                model.DTFHState = bool.Parse(dr["DTFHState"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["JTFHState"].ToString()))
            {
                model.JTFHState = bool.Parse(dr["JTFHState"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["SHMoney"].ToString()))
            {
                model.SHMoney = decimal.Parse(dr["SHMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["YJCount"].ToString()))
            {
                model.YJCount = int.Parse(dr["YJCount"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["YJMoney"].ToString()))
            {
                model.YJMoney = decimal.Parse(dr["YJMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TJCount"].ToString()))
            {
                model.TJCount = int.Parse(dr["TJCount"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TJMoney"].ToString()))
            {
                model.TJMoney = decimal.Parse(dr["TJMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["UpSumMoney"].ToString()))
            {
                model.UpSumMoney = decimal.Parse(dr["UpSumMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TotalMoney"].ToString()))
            {
                model.TotalMoney = decimal.Parse(dr["TotalMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["RealMoney"].ToString()))
            {
                model.RealMoney = decimal.Parse(dr["RealMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TotalDFHMoney"].ToString()))
            {
                model.TotalDFHMoney = decimal.Parse(dr["TotalDFHMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TotalZFHMoney"].ToString()))
            {
                model.TotalZFHMoney = decimal.Parse(dr["TotalZFHMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TotalYFHMoney"].ToString()))
            {
                model.TotalYFHMoney = decimal.Parse(dr["TotalYFHMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["GQCount"].ToString()))
            {
                model.GQCount = int.Parse(dr["GQCount"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["HLGQCount"].ToString()))
            {
                model.HLGQCount = int.Parse(dr["HLGQCount"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TXStatus"].ToString()))
            {
                model.TXStatus = bool.Parse(dr["TXStatus"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["ZZStatus"].ToString()))
            {
                model.ZZStatus = bool.Parse(dr["ZZStatus"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["EPXingCount"].ToString()))
            {
                model.EPXingCount = int.Parse(dr["EPXingCount"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["EPTimeOutCount"].ToString()))
            {
                model.EPTimeOutCount = int.Parse(dr["EPTimeOutCount"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TJFloat"].ToString()))
            {
                model.TJFloat = decimal.Parse(dr["TJFloat"].ToString());
            }
            return model;
        }
    }
}
