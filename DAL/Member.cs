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
    public class Member
    {

        private static Model.Member _ManageMember;
        public static Model.Member ManageMember
        {
            get
            {
                if (_ManageMember == null)
                    _ManageMember = DAL.Member.GetManageModel();
                return _ManageMember;
            }
            set
            {
                _ManageMember = value;
            }
        }
        public static string GetMBD2(string mtjmid, int bdcount)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@mtj",SqlDbType.VarChar,20),
                new SqlParameter("@mbdcount",SqlDbType.Int,4)
            };
            para[0].Value = mtjmid;
            para[1].Value = bdcount;
            //return DbHelperSQL.ProcGetSingleProc("GetAutoMbdByMTJ_TBLR_UNFixed", para).ToString();//从上到下从左到右
            return DbHelperSQL.ProcGetSingleProc("GetAutoMbdByMTJ_TBLR", para).ToString();//从上到下从左到右
            //return DbHelperSQL.ProcGetSingleProc("GetAutoMbdByMtj", para).ToString();//从上到下从左到右
            //return DbHelperSQL.ProcGetSingleProc("GetAutoMbdByMtj2", para).ToString();//从上到下从左到右
            //return DbHelperSQL.ProcGetSingleProc("GetAutoMbdByMtjToMin", para).ToString();//小区业绩排
            //return DbHelperSQL.ProcGetSingleProc("GetAutoMbdByMtjToLR", para).ToString();//最左或最右
        }

        #region 临时字典

        //临时存储会员业绩相关数据
        public static Dictionary<string, Model.Member> tempMemberList = new Dictionary<string, Model.Member>();
        public static Dictionary<string, DateTime> _onLineMember = new Dictionary<string, DateTime>();
        public static Dictionary<string, decimal> _CPList = new Dictionary<string, decimal>();

        public static decimal CPListAdd(string mid, decimal money)
        {
            mid = mid.ToLower();
            if (_CPList.ContainsKey(mid))
            {
                _CPList[mid] += money;
            }
            else
            {
                _CPList.Add(mid, money);
            }
            return _CPList[mid];
        }

        /// <summary>
        /// 该MID是否存在字典中
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static bool HasMemberConfigInDic(string mid)
        {
            mid = mid.ToLower();
            if (tempMemberList.ContainsKey(mid))
                return true;
            return false;
        }

        public static void AddOnLine(string mid)
        {
            mid = mid.ToLower();
            if (_onLineMember.ContainsKey(mid))
                _onLineMember[mid] = DateTime.Now;
            else
                _onLineMember.Add(mid, DateTime.Now);
        }

        public static bool IfOnLine(string mid)
        {
            mid = mid.ToLower();
            if (_onLineMember.ContainsKey(mid) && (DateTime.Now - _onLineMember[mid]).TotalSeconds <= 60)
                return true;
            return false;
        }

        /// <summary>
        /// 临时字典增加,增加成功，TRUE，否则FALSE
        /// </summary>
        /// <param name="mid"></param>
        /// <param name="model"></param>
        /// <returns>增加成功，TRUE，否则FALSE</returns>
        public static bool tempMemberAdd(Model.Member model)
        {
            if (!DAL.Member.HasMemberConfigInDic(model.MID))
            {
                DAL.Member.tempMemberList.Add(model.MID.ToLower(), model);
                return true;
            }
            return false;
        }

        #endregion

        #region 会员信息增删改
        /// <summary>
        /// 更新会员参数值
        /// </summary>
        /// <param name="mid">会员账号</param>
        /// <param name="ConfigValue">参数值</param>
        /// <param name="ConfigName">参数名称</param>
        /// <param name="MyHs"></param>
        /// <returns></returns>
        public static Hashtable UpdateMemberTran(string mid, string fieldName, string fieldValue, Model.Member shmodel, bool isEqual, SqlDbType dataType, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            string guid = Guid.NewGuid().ToString();
            strSql.Append("update Member set ");
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
        /// 插入会员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Insert(Model.Member model)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Member(");
            strSql.Append("Bank,Branch,BankNumber,BankCardName,Password,SecPsd,MTJ,MSH,MBD,MBDIndex,MID,MCreateDate,MDate,MState,IsClose,IsClock,RoleCode,AgencyCode,MName,Salt,ThrPsd,SHMoney,NumID,Province,QQ,City,Zone,Tel,Email,Address,FMID,Country,NAgencyCode,RegistAgency,FHState,validtime,Alipay,WeChat,QRCode");
            strSql.Append(") values (");
            strSql.Append("@Bank,@Branch,@BankNumber,@BankCardName,@Password,@SecPsd,@MTJ,@MSH,@MBD,@MBDIndex,@MID,@MCreateDate,@MDate,@MState,@IsClose,@IsClock,@RoleCode,@AgencyCode,@MName,@Salt,@ThrPsd,@SHMoney,@NumID,@Province,@QQ,@City,@Zone,@Tel,@Email,@Address,@FMID,@Country,@NAgencyCode,@RegistAgency,@FHState,@validtime,@Alipay,@WeChat,@QRCode");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid).Append(UpdateThrPsd(model.MID));
            SqlParameter[] parameters = {
                        new SqlParameter("@Bank", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Branch", SqlDbType.VarChar,50) ,
                        new SqlParameter("@BankNumber", SqlDbType.VarChar,30) ,
                        new SqlParameter("@BankCardName", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@Password", SqlDbType.VarChar,32) ,
                        new SqlParameter("@SecPsd", SqlDbType.VarChar,32) ,
                        new SqlParameter("@MTJ", SqlDbType.VarChar,20) ,
                        new SqlParameter("@MSH", SqlDbType.VarChar,20) ,
                        new SqlParameter("@MBD", SqlDbType.VarChar,20) ,
                        new SqlParameter("@MBDIndex", SqlDbType.Int,4) ,
                        new SqlParameter("@MID", SqlDbType.VarChar,20) ,
                        new SqlParameter("@MCreateDate", SqlDbType.DateTime) ,
                        new SqlParameter("@MDate", SqlDbType.DateTime) ,
                        new SqlParameter("@MState", SqlDbType.Bit,1) ,
                        new SqlParameter("@IsClose", SqlDbType.Bit,1) ,
                        new SqlParameter("@IsClock", SqlDbType.Bit,1) ,
                        new SqlParameter("@RoleCode", SqlDbType.VarChar,10) ,
                        new SqlParameter("@AgencyCode", SqlDbType.VarChar,10) ,
                        new SqlParameter("@MName", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@Salt", SqlDbType.VarChar,10) ,
                        new SqlParameter("@ThrPsd", SqlDbType.VarChar,50) ,
                        new SqlParameter("@SHMoney", SqlDbType.Decimal,9) ,
                        new SqlParameter("@NumID", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Province", SqlDbType.VarChar,20) ,
                        new SqlParameter("@QQ", SqlDbType.VarChar,20) ,
                        new SqlParameter("@City", SqlDbType.VarChar,20) ,
                        new SqlParameter("@Zone", SqlDbType.VarChar,20) ,
                        new SqlParameter("@Tel", SqlDbType.VarChar,20) ,
                        new SqlParameter("@Email", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Address", SqlDbType.Text),
                        new SqlParameter("@FMID", SqlDbType.VarChar,20),
                        new SqlParameter("@Country", SqlDbType.VarChar,20),
                        new SqlParameter("@NAgencyCode", SqlDbType.VarChar,10),
                        new SqlParameter("@RegistAgency", SqlDbType.VarChar,10),
                        new SqlParameter("@FHState", SqlDbType.Bit,1),
                        new SqlParameter("@validtime", SqlDbType.DateTime),
                        new SqlParameter("@Alipay", SqlDbType.VarChar,20),
                        new SqlParameter("@WeChat", SqlDbType.VarChar,20),
                        new SqlParameter("@QRCode", SqlDbType.VarChar,200)
            };

            parameters[0].Value = model.Bank;
            parameters[1].Value = model.Branch;
            parameters[2].Value = model.BankNumber;
            parameters[3].Value = model.BankCardName;
            parameters[4].Value = model.Password;
            parameters[5].Value = model.SecPsd;
            parameters[6].Value = model.MTJ.ToLower();
            parameters[7].Value = model.MSH.ToLower();
            parameters[8].Value = model.MBD.ToLower();
            parameters[9].Value = model.MBDIndex;
            parameters[10].Value = model.MID.ToLower();
            parameters[11].Value = model.MCreateDate;
            parameters[12].Value = model.MDate;
            parameters[13].Value = model.MState;
            parameters[14].Value = model.IsClose;
            parameters[15].Value = model.IsClock;
            parameters[16].Value = model.RoleCode;
            parameters[17].Value = model.AgencyCode;
            parameters[18].Value = model.MName;
            parameters[19].Value = model.Salt;
            parameters[20].Value = model.ThrPsd;
            parameters[21].Value = model.SHMoney;
            parameters[22].Value = model.NumID;
            parameters[23].Value = model.Province;
            parameters[24].Value = model.QQ;
            parameters[25].Value = model.City;
            parameters[26].Value = model.Zone;
            parameters[27].Value = model.Tel;
            parameters[28].Value = model.Email;
            parameters[29].Value = model.Address;
            parameters[30].Value = model.FMID;
            parameters[31].Value = model.Country;
            parameters[32].Value = model.NAgencyCode;
            parameters[33].Value = model.RegistAgency;
            parameters[34].Value = model.FHState;
            parameters[35].Value = model.ValidTime;
            parameters[36].Value = model.Alipay;
            parameters[37].Value = model.WeChat;
            parameters[38].Value = model.QRCode;


            Hashtable MyHs = new Hashtable();
            MyHs.Add(strSql, parameters);
            if (model.MConfig != null)
                MemberConfig.Insert(model.MConfig, MyHs);
            return DAL.CommonBase.RunHashtable(MyHs);
        }

        public static bool Update(Model.Member model)
        {
            lock (DAL.Member.tempMemberList)
            {
                DAL.Member.tempMemberList.Clear();
                Hashtable MyHs = new Hashtable();
                Update(model, MyHs);
                return DAL.CommonBase.RunHashtable(MyHs);
            }
        }

        /// <summary>
        /// 修改会员资料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Hashtable Update(Model.Member model, Hashtable MyHs)
        {
            if (model == null)
                return MyHs;
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Member set ");

            strSql.Append(" Bank = @Bank , ");
            strSql.Append(" Branch = @Branch , ");
            strSql.Append(" BankNumber = @BankNumber , ");
            strSql.Append(" BankCardName = @BankCardName , ");
            strSql.Append(" Password = @Password , ");
            strSql.Append(" SecPsd = @SecPsd , ");
            strSql.Append(" MTJ = @MTJ , ");
            strSql.Append(" MSH = @MSH , ");
            strSql.Append(" MBD = @MBD , ");
            strSql.Append(" MBDIndex = @MBDIndex , ");
            strSql.Append(" MID = @MID , ");
            strSql.Append(" MCreateDate = @MCreateDate , ");
            strSql.Append(" MDate = @MDate , ");
            strSql.Append(" MState = @MState , ");
            strSql.Append(" IsClose = @IsClose , ");
            strSql.Append(" IsClock = @IsClock , ");
            strSql.Append(" RoleCode = @RoleCode , ");
            strSql.Append(" AgencyCode = @AgencyCode , ");
            strSql.Append(" MName = @MName , ");
            strSql.Append(" Salt = @Salt , ");
            strSql.Append(" ThrPsd = @ThrPsd , ");
            strSql.Append(" SHMoney = @SHMoney , ");
            strSql.Append(" NumID = @NumID , ");
            strSql.Append(" Province = @Province , ");
            strSql.Append(" QQ = @QQ , ");
            strSql.Append(" City = @City , ");
            strSql.Append(" Zone = @Zone , ");
            strSql.Append(" Tel = @Tel , ");
            strSql.Append(" Email = @Email , ");
            strSql.Append(" FMID = @FMID , ");
            strSql.Append(" QRCode = @QRCode , ");
            strSql.Append(" Address = @Address,  ");
            strSql.Append(" NAgencyCode = @NAgencyCode,  ");
            strSql.Append(" RegistAgency = @RegistAgency,  ");
            strSql.Append(" FHState=@FHState, ");
            strSql.Append(" validtime=@validtime, ");
            strSql.Append(" Alipay=@Alipay, ");
            strSql.Append(" WeChat=@WeChat, ");
            strSql.Append(" Country = @Country  ");
            strSql.Append(" where MID=@MID  ");
            strSql.AppendFormat(" ;select '{0}'", guid).Append(UpdateThrPsd(model.MID)); ;

            SqlParameter[] parameters = {
                        new SqlParameter("@ID", SqlDbType.Int,4) ,
                        new SqlParameter("@Bank", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Branch", SqlDbType.VarChar,50) ,
                        new SqlParameter("@BankNumber", SqlDbType.VarChar,30) ,
                        new SqlParameter("@BankCardName", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@Password", SqlDbType.VarChar,32) ,
                        new SqlParameter("@SecPsd", SqlDbType.VarChar,32) ,
                        new SqlParameter("@MTJ", SqlDbType.VarChar,20) ,
                        new SqlParameter("@MSH", SqlDbType.VarChar,20) ,
                        new SqlParameter("@MBD", SqlDbType.VarChar,20) ,
                        new SqlParameter("@MBDIndex", SqlDbType.Int,4) ,
                        new SqlParameter("@MID", SqlDbType.VarChar,20) ,
                        new SqlParameter("@MCreateDate", SqlDbType.DateTime) ,
                        new SqlParameter("@MDate", SqlDbType.DateTime) ,
                        new SqlParameter("@MState", SqlDbType.Bit,1) ,
                        new SqlParameter("@IsClose", SqlDbType.Bit,1) ,
                        new SqlParameter("@IsClock", SqlDbType.Bit,1) ,
                        new SqlParameter("@RoleCode", SqlDbType.VarChar,10) ,
                        new SqlParameter("@AgencyCode", SqlDbType.VarChar,10) ,
                        new SqlParameter("@MName", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@Salt", SqlDbType.VarChar,10) ,
                        new SqlParameter("@ThrPsd", SqlDbType.VarChar,50) ,
                        new SqlParameter("@SHMoney", SqlDbType.Decimal,9) ,
                        new SqlParameter("@NumID", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Province", SqlDbType.VarChar,20) ,
                        new SqlParameter("@QQ", SqlDbType.VarChar,20) ,
                        new SqlParameter("@City", SqlDbType.VarChar,20) ,
                        new SqlParameter("@Zone", SqlDbType.VarChar,20) ,
                        new SqlParameter("@Tel", SqlDbType.VarChar,20) ,
                        new SqlParameter("@Email", SqlDbType.VarChar,50) ,
                        new SqlParameter("@FMID", SqlDbType.VarChar,20) ,
                        new SqlParameter("@Address", SqlDbType.Text),
                        new SqlParameter("@Country", SqlDbType.VarChar,20),
                        new SqlParameter("@NAgencyCode", SqlDbType.VarChar,10),
                        new SqlParameter("@RegistAgency", SqlDbType.VarChar,10),
                        new SqlParameter("@FHState", SqlDbType.Bit,1),
                        new SqlParameter("@validtime", SqlDbType.DateTime),
                        new SqlParameter("@Alipay", SqlDbType.VarChar,20),
                        new SqlParameter("@WeChat", SqlDbType.VarChar,20),
                        new SqlParameter("@QRCode", SqlDbType.VarChar,200)
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.Bank;
            parameters[2].Value = model.Branch;
            parameters[3].Value = model.BankNumber;
            parameters[4].Value = model.BankCardName;
            parameters[5].Value = model.Password;
            parameters[6].Value = model.SecPsd;
            parameters[7].Value = model.MTJ.ToLower();
            parameters[8].Value = model.MSH.ToLower();
            parameters[9].Value = model.MBD.ToLower();
            parameters[10].Value = model.MBDIndex;
            parameters[11].Value = model.MID.ToLower();
            parameters[12].Value = model.MCreateDate;
            parameters[13].Value = model.MDate;
            parameters[14].Value = model.MState;
            parameters[15].Value = model.IsClose;
            parameters[16].Value = model.IsClock;
            parameters[17].Value = model.RoleCode;
            parameters[18].Value = model.AgencyCode;
            parameters[19].Value = model.MName;
            parameters[20].Value = model.Salt;
            parameters[21].Value = model.ThrPsd;
            parameters[22].Value = model.SHMoney;
            parameters[23].Value = model.NumID;
            parameters[24].Value = model.Province;
            parameters[25].Value = model.QQ;
            parameters[26].Value = model.City;
            parameters[27].Value = model.Zone;
            parameters[28].Value = model.Tel;
            parameters[29].Value = model.Email;
            parameters[30].Value = model.FMID;
            parameters[31].Value = model.Address;
            parameters[32].Value = model.Country;
            parameters[33].Value = model.NAgencyCode;
            parameters[34].Value = model.RegistAgency;
            parameters[35].Value = model.FHState;
            parameters[36].Value = model.ValidTime;
            parameters[37].Value = model.Alipay;
            parameters[38].Value = model.WeChat;
            parameters[39].Value = model.QRCode;

            MyHs.Add(strSql.ToString(), parameters);
            if (DAL.MemberConfig.GetModel(model.MID, model) != null)
                MemberConfig.Update(model.MConfig, MyHs);
            else if (model.IsNewMemberSH)
                MemberConfig.Insert(model.MConfig, MyHs);
            return MyHs;
        }
        /// <summary>
        /// 修改会员资料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Hashtable UpdateBankInfo(Model.Member model, Hashtable MyHs)
        {
            if (model == null)
                return MyHs;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Member set ");
            strSql.Append("Bank=@Bank,");
            strSql.Append("Branch=@Branch,");
            strSql.Append("BankNumber=@BankNumber,");
            strSql.Append("BankCardName=@BankCardName");
            strSql.Append(" where MID=@MID " + UpdateThrPsd(model.MID));
            SqlParameter[] parameters = {
                    new SqlParameter("@Bank", SqlDbType.VarChar,50),
                    new SqlParameter("@Branch", SqlDbType.VarChar,50),
                    new SqlParameter("@BankNumber", SqlDbType.VarChar,30),
                    new SqlParameter("@BankCardName", SqlDbType.VarChar,20),
                    new SqlParameter("@MID", SqlDbType.VarChar,20)};
            parameters[0].Value = model.Bank;
            parameters[1].Value = model.Branch;
            parameters[2].Value = model.BankNumber;
            parameters[3].Value = model.BankCardName;
            parameters[4].Value = model.MID;

            MyHs.Add(strSql.ToString(), parameters);
            DAL.Member.ManageMember = null;
            return MyHs;
        }

        public static Hashtable UpdateRole(Model.Member model, Hashtable MyHs)
        {
            MyHs.Add(string.Format("update member set RoleCode='{0}',AgencyCode='{1}',MDate='{2}',SHMoney={3},MBD='{4}',MBDIndex={5},MState='{7}',MSH ='{8}',FHState='{9}',ValidTime='{10}',NAgencyCode='{11}' where MID='{6}'" + UpdateThrPsd(model.MID), model.RoleCode, model.AgencyCode, model.MDate.ToString("yyyy-MM-dd HH:mm:ss.fff"), model.SHMoney, model.MBD, model.MBDIndex, model.MID, model.MState, model.MSH, model.FHState, model.ValidTime, model.NAgencyCode), null);
            return MyHs;
        }

        /// <summary>
        /// 删除会员
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static string DeleteMember(string midList)
        {
            string[] mids = midList.Split(',');
            Hashtable MyHs = new Hashtable();
            int count = mids.Length;
            int successcount = 0;
            foreach (string mid in mids)
            {
                lock (DAL.Member.tempMemberList)
                {
                    //DAl.Member.tempMemberList.Clear();
                    //Model.Member model = DAl.Member.GetModel(mid);
                    //List<Model.ChangeMoney> ChangeMoneyList = ChangeMoneyCollection.GetChangeMoneyEntityList(string.Format("SHMID='{0}'", mid));
                    //List<Model.MConfigChange> MConfigChangeList = MConfigChange.GetMConfigChangeEntityList(string.Format("SHMID='{0}'", mid));
                    //DAl.Member.tempMemberList.Clear();//清空临时字典
                    //string guid = Guid.NewGuid().ToString();
                    //foreach (Model.ChangeMoney item in ChangeMoneyList)
                    //{
                    //    if (item.CState)
                    //    {
                    //        DAl.ChangeMoney.TranChangeTran(item.ToMID, item.FromMID, item.Money - item.TakeOffMoney, item.MoneyType, MyHs);
                    //    }
                    //}
                    //foreach (Model.MConfigChange item in MConfigChangeList)
                    //{
                    //    guid = Guid.NewGuid().ToString();
                    //    if (item.IsValue)
                    //    {
                    //        MyHs.Add(string.Format("update MemberConfig set {0} = '{1}' where MID = '{2}' " + " and '" + guid + "'='" + guid + "'", item.ConfigName, item.ConfigValue, item.MID), null);
                    //    }
                    //    else
                    //    {
                    //        MyHs.Add(string.Format("update MemberConfig set {0} ={0}- {1} where MID = '{2}' " + " and '" + guid + "'='" + guid + "'", item.ConfigName, item.ConfigValue, item.MID), null);
                    //    }
                    //}
                    MyHs.Add(string.Format("delete from ChangeMoney where SHMID='{0}'", mid), null);
                    MyHs.Add(string.Format("delete from Member where MID='{0}'", mid), null);
                    MyHs.Add(string.Format("delete from MemberConfig where MID='{0}'", mid), null);
                    MyHs.Add(string.Format("delete from MConfigChange where SHMID='{0}'", mid), null);

                    if (CommonBase.RunHashtable(MyHs))
                    {
                        DAL.Member.tempMemberList.Clear();//清空临时字典
                        successcount++;
                    }
                }
            }
            DAL.Member.tempMemberList.Clear();//清空临时字典
            return string.Format("成功:{0},失败{1}", successcount, count - successcount);
        }

        /// <summary>
        /// 删除会员
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static string DeleteMemberW(string midList, Model.Member shmodel)
        {
            string[] mids = midList.Split(',');
            Hashtable MyHs = new Hashtable();
            int count = mids.Length;
            foreach (string mid in mids)
            {
                Model.Member model = DAL.Member.GetModel(mid);
                if (model.AgencyCode == "001")
                {
                    MyHs.Add("delete from member where mid='" + model.MID + "'; delete from memberconfig where mid ='" + model.MID + "';", null);
                }
                else
                {
                    return "已审核的会员不能删除";
                }
            }
            if (CommonBase.RunHashtable(MyHs))
            {
                return "操作成功";
            }
            return "操作失败";
        }
        #endregion

        #region 会员信息查询

        /// <summary>
        /// 得到会员对象
        /// </summary>
        /// <param name="MID"></param>
        /// <returns></returns>
        public static Model.Member GetModel(string MID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 *," + Model.Member.MD5 + " as 'TempThrPsd' from Member");
            strSql.Append(" where MID=@MID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@MID", SqlDbType.VarChar,20)};
            parameters[0].Value = MID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            return null;
        }

        public static List<Model.Member> GetModelList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Member");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.AppendFormat(" where {0}", strWhere);
            }

            List<Model.Member> list = new List<Model.Member>();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Model.Member member = TranEntity(row);
                if (!DAL.Member.tempMemberAdd(member))//没有增加成功，存在
                {
                    list.Add(DAL.Member.tempMemberList[member.MID]);
                }
                else
                {
                    list.Add(member);
                }
            }
            return list;
        }

        /// <summary>
        /// 得到管理员对象
        /// </summary>
        /// <returns></returns>
        public static Model.Member GetManageModel()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Member");
            strSql.Append(" where RoleCode in (select RType from Roles where Super='1') order by ID");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            return null;
        }

        /// <summary>
        /// 得到直接接点人数
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static int GetBDCount(string mid, bool mstate)
        {
            return Convert.ToInt32(DbHelperSQL.GetSingle(string.Format("select count(1) from Member where MBD='{0}' and MID<>'{0}' {1} ", mid, (mstate ? " and MState = 1 and agencycode = '003' " : ""))));
        }

        #endregion

        #region 私有方法
        /// <summary>
        /// 转换数据实体
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static Model.Member TranEntity(DataRow row)
        {
            Model.Member model = new Model.Member();
            if (row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }
            if (row[1].ToString() != "")
            {
                model.MID = row[1].ToString().ToLower();
            }
            if (row["FMID"].ToString() != "")
            {
                model.FMID = row["FMID"].ToString().ToLower();
            }
            if (row["MName"] != null)
            {
                model.MName = row["MName"].ToString();
            }
            if (row["Province"] != null)
            {
                model.Province = row["Province"].ToString();
            }
            if (row["City"] != null)
            {
                model.City = row["City"].ToString();
            }
            if (row["Zone"] != null)
            {
                model.Zone = row["Zone"].ToString();
            }
            if (row["Tel"] != null)
            {
                model.Tel = row["Tel"].ToString();
            }
            if (row["Email"] != null)
            {
                model.Email = row["Email"].ToString();
            }
            if (row["Address"] != null)
            {
                model.Address = row["Address"].ToString();
            }
            if (row["Bank"] != null)
            {
                model.Bank = row["Bank"].ToString();
            }
            if (row["Branch"] != null)
            {
                model.Branch = row["Branch"].ToString();
            }
            if (row["BankNumber"] != null)
            {
                model.BankNumber = row["BankNumber"].ToString();
            }
            if (row["BankCardName"] != null)
            {
                model.BankCardName = row["BankCardName"].ToString();
            }
            if (row["Password"] != null)
            {
                model.Password = row["Password"].ToString();
            }
            if (row["SecPsd"] != null)
            {
                model.SecPsd = row["SecPsd"].ToString();
            }
            if (row["QQ"] != null)
            {
                model.QQ = row["QQ"].ToString();
            }
            if (row["Alipay"] != null)
            {
                model.Alipay = row["Alipay"].ToString();
            }
            if (row["WeChat"] != null)
            {
                model.WeChat = row["WeChat"].ToString();
            }
            if (row["ThrPsd"] != null)
            {
                model.ThrPsd = row["ThrPsd"].ToString();
            }
            if (row.Table.Columns.Contains("TempThrPsd"))
            {
                model.TempThrPsd = row["TempThrPsd"].ToString();
            }
            if (row["MTJ"] != null)
            {
                model.MTJ = row["MTJ"].ToString().ToLower();
            }
            if (row["MSH"] != null)
            {
                model.MSH = row["MSH"].ToString().ToLower();
            }
            if (row["MBD"] != null)
            {
                model.MBD = row["MBD"].ToString().ToLower();
            }
            if (row["MBDIndex"].ToString() != "")
            {
                model.MBDIndex = int.Parse(row["MBDIndex"].ToString());
            }
            if (row["MCreateDate"].ToString() != "")
            {
                model.MCreateDate = DateTime.Parse(row["MCreateDate"].ToString());
            }
            if (row["MDate"].ToString() != "")
            {
                model.MDate = DateTime.Parse(row["MDate"].ToString());
            }
            if (row["MState"].ToString() != "")
            {
                model.MState = bool.Parse(row["MState"].ToString());
            }
            if (row["IsClose"].ToString() != "")
            {
                model.IsClose = bool.Parse(row["IsClose"].ToString());
            }
            if (row["IsClock"].ToString() != "")
            {
                model.IsClock = bool.Parse(row["IsClock"].ToString());
            }
            if (row["RoleCode"].ToString() != "")
            {
                model.RoleCode = row["RoleCode"].ToString();
                model.Role = DAL.Roles.RolsList[model.RoleCode];
            }
            if (row["AgencyCode"].ToString() != "")
            {
                model.AgencyCode = row["AgencyCode"].ToString();
                if (!string.IsNullOrEmpty(model.AgencyCode) && DAL.Configuration.TModel.SHMoneyList.ContainsKey(model.AgencyCode))
                    model.MAgencyType = DAL.Configuration.TModel.SHMoneyList[model.AgencyCode];
            }
            if (row["Salt"].ToString() != "")
            {
                model.Salt = row["Salt"].ToString();
            }
            if (row["SHMoney"].ToString() != "")
            {
                model.SHMoney = decimal.Parse(row["SHMoney"].ToString());
            }
            if (row["NAgencyCode"] != null && row["NAgencyCode"].ToString() != "")
            {
                model.NAgencyCode = row["NAgencyCode"].ToString();
            }
            if (row["RegistAgency"] != null)
            {
                model.RegistAgency = row["RegistAgency"].ToString();
            }
            if (row["QRCode"] != null)
            {
                model.QRCode = row["QRCode"].ToString();
            }
            if (row["FHState"] != null && row["FHState"].ToString() != "")
            {
                if ((row["FHState"].ToString() == "1") || (row["FHState"].ToString().ToLower() == "true"))
                {
                    model.FHState = true;
                }
                else
                {
                    model.FHState = false;
                }
            }
            if (row["validtime"] != null && row["validtime"].ToString() != "")
            {
                model.ValidTime = DateTime.Parse(row["validtime"].ToString());
            }
            model.NumID = row["NumID"].ToString();
            model.Country = row["Country"].ToString();
            if (row.Table.TableName == "MemberAndConfig")
                model.MConfig = DAL.MemberConfig.TranEntity(row, model);
            else
                model.MConfig = DAL.MemberConfig.GetModel(model.MID, model);

            return model;
        }

        #endregion

        #region 其他方法
        /// <summary>
        /// 初始化系统
        /// </summary>
        /// <param name="AgencyCode"></param>
        /// <returns></returns>
        public static bool ReSetSys(Model.Member model)
        {
            if (model.Role.Super)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from [ChangeMoney];");
                strSql.Append("delete from [Member] where RoleCode not in ('Activation','Manage');");
                strSql.Append("update Member set MCreateDate=GETDATE(),MDate=GETDATE(),AgencyCode='" + DAL.SHMoney.GetSHMoneyList().OrderByDescending(m => Convert.ToInt32(m.MAgencyType)).FirstOrDefault().MAgencyType + "';" + UpdateThrPsd(""));
                strSql.Append("delete from [MemberConfig];");
                strSql.Append("insert into memberconfig(mid)values('" + DAL.Member.ManageMember.MID + "');");
                strSql.Append("update MemberConfig set SHMoney = 0, YJCount = 1, YJMoney = 0,TJCount = 0, TJMoney = 0, UpSumMoney = 0, TotalMoney = 0, RealMoney = 0, TakeOffMoney = 0, ReBuyMoney = 0, TotalTXMoney = 0,MHB = 0, MJB = 0, MCW = 0, MGP = 0, TotalDFHMoney = 0, TotalZFHMoney = 0, TotalYFHMoney = 0 ,DTFHState = 1,JTFHState = 1");
                strSql.Append("update Configuration set JTFHLastMID = '" + DAL.Member.ManageMember.MID + "';");
                strSql.Append("delete from [BMember];");
                strSql.Append("insert into BMember values('admin','admin_0','admin_0',GETDATE(),GETDATE(),1,0,0,0,0,0);");
                strSql.Append("delete from [LuckyMoney];");
                strSql.Append("delete from [Message];");
                strSql.Append("delete from [Notice];");
                strSql.Append("delete from [Task];");
                strSql.Append("delete from [MConfigChange];");
                strSql.Append("delete from [BankModel] where MID<>'admin';");
                strSql.Append("delete from [HKModel];");
                strSql.Append("delete from [Accounts];");
                strSql.Append("delete from [SMS];");
                strSql.Append("delete from [GoodsOrder];");
                strSql.Append("delete from [BCenter];");
                strSql.Append("delete from [Sys_SQ_Answer] where MID<>" + DAL.Member._ManageMember.ID);
                strSql.Append("delete from [GoodCategory];");
                strSql.Append("delete from [Goods];");
                strSql.Append("delete from [GoodsPic];");
                strSql.Append("delete from [Order];");
                strSql.Append("delete from [OrderDetail];");
                strSql.Append("delete from [ReceiveInfo];");
                strSql.Append("delete from [ShopCar];");
                strSql.Append("delete from [EPList];");
                strSql.Append("delete from [Member_OperationRecord];");
                strSql.Append("delete from [StockRight];");
                strSql.Append("delete from [QuitRecord];");
                strSql.Append("delete from [LotteryDraw];");
                strSql.Append("delete from [BonusList];");
                strSql.Append("delete from [BonusGift];");
                strSql.Append("delete from [EPJX];");
                strSql.Append("delete from [Agents];");

                DAL.Configuration.TModel = null;
                return DbHelperSQL.ExecuteSql(strSql.ToString()) > 0;
            }
            return false;
        }

        #endregion

        # region 项目方法

        public static bool CanMBD(Model.Member member)
        {
            return !(Convert.ToInt32(DbHelperSQL.GetSingle(string.Format("select count(1) from Member where MBD='{0}' and MBDIndex = {1} and MID <> '{0}' ", member.MBD, member.MBDIndex))) > 0);
        }

        public static bool TestMID(string mid)
        {
            return Convert.ToInt32(DbHelperSQL.GetSingle("select count(1) from Member where MID='" + mid + "'")) > 0;
        }

        public static int GetNumIDCount(string NumID, string FiledName)
        {
            return Convert.ToInt32(DbHelperSQL.GetSingle("select count(1) from Member where " + FiledName + "='" + NumID + "'"));
        }

        public static string UpdateThrPsd(string mid)
        {
            string strWhere = Model.Member.UpThrPsd;
            if (!string.IsNullOrEmpty(mid))
                strWhere += " where mid ='" + mid + "'";
            return strWhere;
        }

        public static string GetMBD(string mtjmid, int bdcount)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@mtj",SqlDbType.VarChar,20),
                new SqlParameter("@mbdcount",SqlDbType.Int,4)
            };
            para[0].Value = mtjmid;
            para[1].Value = bdcount;
            return DbHelperSQL.ProcGetSingleProc("GetAutoMbdByMtj", para).ToString();//从上到下从左到右
            //return DbHelperSQL.ProcGetSingleProc("GetAutoMbdByMtjToMin", para).ToString();//小区业绩排
            //return DbHelperSQL.ProcGetSingleProc("GetAutoMbdByMtjToLR", para).ToString();//最左或最右
        }

        public static bool MemberHBClear()
        {
            lock (DAL.Member.tempMemberList)
            {
                DAL.Member.tempMemberList.Clear();
                return DbHelperSQL.ExecuteSql("Update MemberConfig set MJB=0,MHB=0,MGP=0,MCW=0" + UpdateThrPsd("") + "; delete from Accounts; delete from ChangeMoney;") > 0;
            }
        }


        public static bool MemberHBToJB()
        {
            lock (DAL.Member.tempMemberList)
            {
                DAL.Member.tempMemberList.Clear();
                return DbHelperSQL.ExecuteSql("Update Member set MJB=MHB,MHB=0" + UpdateThrPsd("")) > 0;
            }
        }

        public static decimal GetTypeSumJJ(string mid, string type, DateTime day)
        {
            return Convert.ToDecimal(DbHelperSQL.GetSingle(string.Format("select sum(Money) from changemoney where tomid='{0}' and CState='1' and changedate between '{1} 00:00:00' and '{1} 23:59:59' and changetype in ('{2}') ", mid, day.ToString("yyyy-MM-dd"), type)));
        }

        public static bool MemberClose(Model.Member model)
        {
            return DbHelperSQL.ExecuteSql(string.Format("Update Member set IsClose='{0}' where MID='{1}'", model.IsClose, model.MID)) > 0;
        }

        public static int GetLevelForView(Model.Member model, string viewMid, bool viewType)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@mid",SqlDbType.VarChar,20),
                new SqlParameter("@viewmid",SqlDbType.VarChar,10),
                new SqlParameter("@viewtype",SqlDbType.Bit,1)
            };
            para[0].Value = model.MID;
            para[1].Value = viewMid;
            para[2].Value = viewType;
            return Convert.ToInt32(DbHelperSQL.ProcGetSingleProc("GetLevelForView", para));
        }
        /// <summary>
        /// 判断两个会员是否有推荐或被推荐关系
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //public static bool IsCanChangeByMember(Model.Member model1,Model.Member model2)
        //{
        //    return DbHelperSQL.ExecuteSql(string.Format("Update Member set IsClose='{0}' where MID='{1}'", model.IsClose, model.MID)) > 0;
        //}

        public static List<Model.Member> GetJTFHMembers(string shmid, string lastmid, int count)
        {//TranEntity
            List<Model.Member> members = new List<Model.Member>();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select * from Member where MDate > (select MDate from Member where MID = '{1}') and MID <> '{2}' and RoleCode not in ('Activation','Manage') and AgencyCode <> '001' order by MDate asc ", count, lastmid, shmid);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    members.Add(TranEntity(row));
                }
            }
            strSql = new StringBuilder();
            strSql.AppendFormat("select * from Member where MDate <= (select MDate from Member where MID = '{1}') and MID <> '{2}' and RoleCode not in ('Activation','Manage') and AgencyCode <> '001' order by MDate asc ", count - members.Count, lastmid, shmid);
            ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    members.Add(TranEntity(row));
                }
            }
            return members;
        }
        /// <summary>
        /// 获取有参与日分红资格的人
        /// </summary>
        /// <returns></returns>
        public static List<Model.Member> GetDFHMember()
        {
            return GetModelList(" FHState = 1 and MState = 1 and IsClock = 0 and IsClose = 0 and RoleCode not in ('Activation','Manage') ");
        }

        /// <summary>
        /// 获取会员人数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static int GetMemberCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(*) from member  ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = CommonBase.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }

        public static void GetCengCount(string mid, int count, int sumCount)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@mid",SqlDbType.VarChar,20),
                new SqlParameter("@level",SqlDbType.Int,4),
                new SqlParameter("@sumcount",SqlDbType.Int,4)
            };
            para[0].Value = mid;
            para[1].Value = count;
            para[2].Value = sumCount;

            DbHelperSQL.ProcGetSingleProc("GetMemberFHState", para);
        }

        public static Model.Member GetParentVIP(string mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@" 
                                    with cte as
                                    (
                                        select MID,MTJ,RoleCode,MDate from Member
                                        where MID = '{0}'
                                        union all
                                        select d.MID,d.MTJ,d.RoleCode,d.MDate from cte c inner join Member d
                                        on c.MTJ = d.MID where d.MID <> d.MTJ
                                    )
                                     select top 1 * from cte where RoleCode = 'VIP' order by MDate desc
                                      ", mid);
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                return GetModel(dt.Rows[0]["MID"].ToString());
            }
            else
            {
                return null;
            }
        }

        # endregion 项目方法

        # region zx_227

        # region 层奖

        /// <summary>
        /// 根据层数得到左右区第一个会员业绩
        /// </summary>
        public static decimal GetCYJMoney(string mbdmid, int level)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@mbd",SqlDbType.VarChar,20),
                new SqlParameter("@level",SqlDbType.Int,4)
            };
            para[0].Value = mbdmid;
            para[1].Value = level;
            return Convert.ToDecimal(DbHelperSQL.ProcGetSingleProc("getCyjmoney", para));
        }

        # endregion 层奖

        # endregion zx_227
    }
}
