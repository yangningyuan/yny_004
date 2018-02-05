using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Reflection;

namespace yny_004.BLL
{
    public class ChangeMoney
    {
        # region 数据统计

        /// <summary>
        /// 今日新增会员
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static int GetNewNumber(Model.Member member)
        {
            int count = 0;
            if (member.Role.Super)
            {
                count = DAL.Member.GetModelList(" DATEDIFF(dd,MCreateDate,getdate()) = 0 and MState = 1 and RoleCode not in ('Activation','Manage') ").Count;
            }
            else
            {
                count = DAL.Member.GetModelList(" DATEDIFF(dd,MCreateDate,getdate()) = 0 and MState = 1 and MTJ = '" + member.MID + "' and RoleCode not in ('Activation','Manage') ").Count;
            }
            return count;
        }
        /// <summary>
        /// 批量生产子账号
        /// </summary>
        /// <returns></returns>
        public static bool ListMyAdd()
        {
            List<Model.Member> listmember = BLL.Member.ManageMember.GetMemberEntityList("  [FMID] IS NULL AND MID<>'admin'  AND MID IN(SELECT mid FROM dbo.MemberConfig WHERE MJB>=" + BLL.Configuration.Model.SHMoneyList["002"].Money + " );");
            foreach (var item in listmember)
            {
                string strmid = BLL.Member.GetTestMID();
                Model.Member model = new Model.Member
                {
                    MID = strmid,
                    MSH = BLL.Member.ManageMember.TModel.MID,
                    MTJ = item.MID,
                    MCreateDate = DateTime.Now,
                    MDate = DateTime.MaxValue,
                    AgencyCode = "001",
                    Address = "子账号注册",
                    Bank = item.Bank,
                    Branch = item.Branch,
                    BankNumber = item.BankNumber,
                    BankCardName = item.BankCardName,
                    IsClock = false,
                    IsClose = false,
                    MState = false,
                    FHState = false,
                    FMID = item.MID.Trim(),
                    MName = item.MName,
                    NumID = item.NumID,
                    Password = item.Password,
                    QQ = item.QQ,
                    RoleCode = "Notactive",
                    Salt = item.Salt,
                    SecPsd = item.SecPsd,
                    SHMoney = 0,
                    Tel = item.Tel,
                    MBDIndex = 0,
                    MBD = BLL.Member.ManageMember.TModel.MID,
                    ValidTime = DateTime.Now,
                    Zone = item.Zone,
                    MConfig = new Model.MemberConfig
                    {
                        MID = strmid,
                        JJTypeList = BLL.Reward.RewardStr,
                        DTFHState = true,
                        JTFHState = true,
                        TXStatus = true,
                        ZZStatus = true,
                        GQCount = 0,
                        HLGQCount = 0,
                        EPXingCount = 5
                    }
                };

                string error = "";
                Model.Member strmodel = yny_004.BLL.Member.InsertAndReturnEntity(model, 0, true, ref error);

                if (model == null)
                {
                    continue;
                }
                try
                {
                    Model.SHMoney shmoney = BLL.Configuration.Model.SHMoneyList["002"];
                    BLL.Member.ManageMember.UpMAgencyType(shmoney, model.MID, "MJB", item, shmoney.Money);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return true;
        }

        /// <summary>
        /// 取到今天的提现次数
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static int GetDayTXCount(string mid)
        {
            return DAL.ChangeMoney.GetDayTXCount(mid);
        }

        /// <summary>
        /// 得到个人的总计分红
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static decimal GetTotalFHMoney(string mid)
        {
            return DAL.ChangeMoney.GetTotalFHMoney(mid);
        }

        /// <summary>
        /// 获得当前获取的奖金总额
        /// </summary>
        /// <param name="mid">会员帐号</param>
        /// <param name="type">奖金类型，默认为所有</param>
        /// <param name="day">哪一天(0:当天,1:昨天,2:前天...)</param>
        /// <returns></returns>
        public static decimal GetDayFHMoney(string mid, string type, int? day = null, string strWhere = "", DateTime? startTime = null, DateTime? endTime = null)
        {
            return DAL.ChangeMoney.GetDayFHMoney(mid, type, day, strWhere, startTime, endTime).ToFixedDecimal();
        }

        public static decimal GetTXMoney(string strWhere)
        {
            return DAL.ChangeMoney.GetTXMoney(strWhere);
        }

        /// <summary>
        /// 获得当前获取的奖金总额
        /// </summary>
        public static int GetFHCount(string mid, string type)
        {
            return DAL.ChangeMoney.GetFHCount(mid, type);
        }

        # endregion 数据统计

        #region 与数据库存储相关

        /// <summary>
        /// 添加货币转移记录哈希表
        /// </summary>
        /// <returns></returns>
        public static Hashtable InsertTran(Model.ChangeMoney model, Hashtable MyHs)
        {
            return DAL.ChangeMoney.InsertTran(model, MyHs);
        }

        /// <summary>
        /// 得到转移对象
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>
        public static Model.ChangeMoney GetModel(int CID)
        {
            return DAL.ChangeMoney.GetModel(CID);
        }

        public static Model.ChangeMoney GetTopModel(string changetype, bool cstate, string MID)
        {
            return DAL.ChangeMoney.GetTopModel(changetype, cstate, MID);
        }

        /// <summary>
        /// 改变提现申请状态为已审核哈希表
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>
        public static Hashtable UpdataTran(Model.ChangeMoney model, Hashtable MyHs)
        {
            return DAL.ChangeMoney.UpdataTran(model, MyHs);
        }

        #endregion

        #region 会员业务操作

        /// <summary>
        /// 申请提现
        /// </summary>
        /// <param name="money"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string TXChange(int money, Model.Member model, string moneyType)
        {
            if (!BLL.Configuration.Model.B_TXSwitch)
            {
                return "当前不能提现";
            }
            if (!EnoughChange(model.MID, money, moneyType))
            {
                return "您的可用" + BLL.Reward.List[moneyType].RewardName + "不足";
            }

            if (money < DAL.Configuration.TModel.B_TXMinMoney)
            {
                return "最少提现金额" + DAL.Configuration.TModel.B_TXMinMoney;
            }
            if (money > DAL.Configuration.TModel.B_TXMaxMoney)
            {
                return "最大提现金额" + DAL.Configuration.TModel.B_TXMaxMoney;
            }
            else if ((money - DAL.Configuration.TModel.B_TXMinMoney) % DAL.Configuration.TModel.B_TXBaseMoney != 0)
            {
                return "提现金额应是" + DAL.Configuration.TModel.B_TXBaseMoney + "的倍数";
            }

            //if (BLL.ChangeMoney.GetDayTXCount(model.MID) >=model.MAgencyType.SubCount)
            //{
            //    return "每周只能提现"+ model.MAgencyType.SubCount + "次";
            //}

            //if (DateTime.Now.DayOfWeek != DayOfWeek.Monday)
            //{
            //    return "每周周一才能提现";
            //}
            //if (money > model.MAgencyType.MCWFloat)
            //{
            //    return "您每天最多提现" + model.MAgencyType.MCWFloat.ToString("F2");
            //}

            if (DAL.CommonBase.RunHashtable(TXChangeTran(money, model, moneyType, true)))
            {
                return "提交成功，请等待系统管理员审核！";
            }
            return "操作失败";
        }

        /// <summary>
        /// 申请提现哈希表
        /// </summary>
        /// <param name="money"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Hashtable TXChangeTran(int money, Model.Member model, string moneyType, bool ifSendMsg)
        {
            decimal txfloat = model.MAgencyType.TXFloat;
            Model.ChangeMoney changemoney = new Model.ChangeMoney();
            changemoney.ChangeDate = DateTime.Now;
            changemoney.ChangeType = "TX";
            changemoney.FromMID = model.MID;
            changemoney.Money = money;
            changemoney.MoneyType = moneyType;
            changemoney.TakeOffMoney = money * txfloat;
            changemoney.CState = false;
            changemoney.ToMID = BLL.Member.ManageMember.TModel.MID;
            string bankName = model.Bank;
            // bankName = new CommonBLL.Sys_BankInfoBLL().GetModel(model.Bank).Name;
            //changemoney.CRemarks = model.Bank + "~" + model.Branch + "~" + model.BankCardName + "~" + model.BankNumber;
            try
            {
                bankName = new CommonBLL.Sys_BankInfoBLL().GetModel(model.Bank).Name;
            }
            catch
            {

            }
            changemoney.CRemarks = model.Province + "~" + model.City + "~" + bankName + "~" + model.Branch + "~" + model.BankCardName + "~" + model.BankNumber;
            //changemoney.CRemarks = model.Address;
            Hashtable MyHs = new Hashtable();
            TakeOffMoneyTran(changemoney, model, BLL.Member.ManageMember.TModel, null, MyHs);
            //DAl.Member.UpdateBankInfo(model, MyHs);
            //扣钱
            BLL.Member.UpdateConfigTran(changemoney.FromMID, changemoney.MoneyType, (-changemoney.Money).ToString(), null, false, SqlDbType.Decimal, MyHs);
            if (ifSendMsg)
            {
                BLL.Task.SendManage(model, "001", "您好，会员:" + model.MID + "于当前时间" +
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "申请提现:" + money + ",实发金额:" + (changemoney.Money /*- changemoney.TakeOffMoney*/) +
                    "，请及时汇款，人民币为" + money + "，实发金额" + ((changemoney.Money/* - changemoney.TakeOffMoney*/)));
            }
            return InsertTran(changemoney, MyHs);
        }

        public static string EPChange(int money, Model.Member model)
        {
            if (!EnoughChange(model.MID, money, "MJJ"))
                return "您的可用" + BLL.Reward.List["MHB"].RewardName + "不足";
            if (money < DAL.Configuration.TModel.B_TXMinMoney)
                return "最少挂卖金额" + DAL.Configuration.TModel.B_TXMinMoney;
            else if ((money - DAL.Configuration.TModel.B_TXMinMoney) % DAL.Configuration.TModel.B_TXBaseMoney != 0)
                return "挂卖金额应是" + DAL.Configuration.TModel.B_TXBaseMoney + "的倍数";

            if (DAL.CommonBase.RunHashtable(EPChangeTran(money, model, true)))
            {
                return "提交成功！";
            }
            return "操作失败";
        }
        public static Hashtable EPChangeTran(int money, Model.Member model, bool ifSendMsg)
        {
            Model.ChangeMoney changemoney = new Model.ChangeMoney();
            changemoney.ChangeDate = DateTime.Now;
            changemoney.ChangeType = "EP";
            changemoney.FromMID = model.MID;
            changemoney.Money = money;
            changemoney.MoneyType = "MHB";
            changemoney.CState = false;
            changemoney.ToMID = "";

            Hashtable MyHs = new Hashtable();
            TakeOffMoneyTran(changemoney, model, BLL.Member.ManageMember.TModel, null, MyHs);
            DAL.Member.UpdateBankInfo(model, MyHs);

            if (ifSendMsg)
            {
                BLL.Task.SendManage(model, "001", "会员:" + model.MID + "于当前时间" +
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "申请挂卖:" + money);
            }
            return InsertTran(changemoney, MyHs);
        }

        /// <summary>
        /// 审核提现
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public static string ShTx(string cidList)
        {
            List<string> idList = cidList.Split(',').ToList();
            int success = 0, fail = 0;
            //更新提现申请，货币转移，财务转移
            foreach (string cid in idList)
            {
                Hashtable MyHs = new Hashtable();
                Model.ChangeMoney changemoney = ChangeMoney.GetModel(int.Parse(cid));
                if (changemoney.CState)
                    continue;
                Model.Member FromMember = DAL.Member.GetModel(changemoney.FromMID);
                if (FromMember != null)
                {
                    changemoney.CState = true;
                    UpdataTran(changemoney, MyHs);
                    //DAL.ChangeMoney.TranChangeTran(changemoney.FromMID, changemoney.ToMID, changemoney.Money, changemoney., MyHs);
                    FromMember.MConfig.TotalTXMoney += changemoney.Money;
                    DAL.MemberConfig.UpdateConfigTran(FromMember.MID, "TotalTXMoney", changemoney.Money.ToString(), FromMember, false, SqlDbType.Decimal, MyHs);
                    if (BLL.CommonBase.RunHashtable(MyHs))
                    {
                        //BLL.Task.ManageSend(FromMember, "您好，尊敬的会员:" + FromMember.MID + "，平台已与于当前时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") +
                        //    "审核您的提现申请" + "，实发金额$" + (changemoney.Money - changemoney.TakeOffMoney) + ",折合人民币￥" + (changemoney.Money - changemoney.TakeOffMoney) * BLL.Configuration.Model.OutFloat + ";，请注意查收");
                        success++;
                    }
                    else
                    {
                        fail++;
                    }
                }
            }
            return "成功：" + success + ";失败：" + fail + ";";
        }

        public static string SHAllTX()
        {
            List<Model.ChangeMoney> idList = ChangeMoney.GetList(" ChangeType = 'TX' and CState = 0 ");
            int success = 0, fail = 0;
            //更新提现申请，货币转移，财务转移
            foreach (Model.ChangeMoney changemoney in idList)
            {
                Hashtable MyHs = new Hashtable();
                if (changemoney.CState)
                    continue;
                Model.Member FromMember = DAL.Member.GetModel(changemoney.FromMID);
                if (FromMember != null)
                {
                    changemoney.CState = true;
                    UpdataTran(changemoney, MyHs);
                    FromMember.MConfig.TotalTXMoney += changemoney.Money;
                    DAL.MemberConfig.UpdateConfigTran(FromMember.MID, "TotalTXMoney", changemoney.Money.ToString(), FromMember, false, SqlDbType.Decimal, MyHs);
                    if (BLL.CommonBase.RunHashtable(MyHs))
                    {
                        success++;
                    }
                    else
                    {
                        fail++;
                    }
                }
            }
            return "成功：" + success + ";失败：" + fail + ";";
        }

        /// <summary>
        /// 删除提现
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public static string Cancel_TX(string cidList, Model.Member member)
        {
            List<string> idList = cidList.Split(',').ToList();
            int success = 0, fail = 0;
            //更新提现申请，货币转移，财务转移
            foreach (string cid in idList)
            {
                Hashtable MyHs = new Hashtable();
                Model.ChangeMoney changemoney = ChangeMoney.GetModel(int.Parse(cid));
                if (changemoney.CState)
                    continue;
                Model.Member FromMember = DAL.Member.GetModel(changemoney.FromMID);
                if (FromMember != null)
                {
                    //删除
                    MyHs.Add(string.Format(" delete from changemoney where CID = {0} ", changemoney.CID), null);
                    //返还币种
                    BLL.Member.UpdateConfigTran(changemoney.FromMID, changemoney.MoneyType, (changemoney.Money).ToString(), null, false, SqlDbType.Decimal, MyHs);

                    //changemoney.CState = true;
                    //UpdataTran(changemoney, MyHs);
                    //DAL.ChangeMoney.TranChangeTran(changemoney.FromMID, changemoney.ToMID, changemoney.Money, "MHB", MyHs);
                    //FromMember.MConfig.TotalTXMoney += changemoney.Money;
                    //DAL.MemberConfig.UpdateConfigTran(FromMember.MID, "TotalTXMoney", changemoney.Money.ToString(), FromMember, false, SqlDbType.Decimal, MyHs);
                    if (BLL.CommonBase.RunHashtable(MyHs))
                    {
                        //BLL.Task.ManageSend(FromMember, "您好，尊敬的会员:" + FromMember.MID + "，平台已与于当前时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") +
                        //    "审核您的提现申请" + "，实发金额$" + (changemoney.Money - changemoney.TakeOffMoney) + ",折合人民币￥" + (changemoney.Money - changemoney.TakeOffMoney) * BLL.Configuration.Model.OutFloat + ";，请注意查收");
                        success++;
                    }
                    else
                    {
                        fail++;
                    }
                }
            }
            return "删除成功：" + success + ";删除失败：" + fail + ";";
        }

        /// <summary>
        /// 服务中心
        /// </summary>
        /// <param name="model">支付中心/审核中心</param>
        /// <param name="shmid">待激活对象</param>
        /// <param name="shtype">审核方式[0正常，1回填]</param>
        /// <returns></returns>
        public static string SHMember(Model.Member model, string shmid)
        {
            //获取待激活对象
            Hashtable MyHs = new Hashtable();

            string retStr = "";
            Model.Member shmodel = DAL.Member.GetModel(shmid);
            retStr += BLL.Member.Validation(shmodel);
            if (retStr != "")
                return retStr;

            lock (DAL.Member.tempMemberList)
            {
                DAL.Member.tempMemberList.Clear();//清空临时字典。

                if (!DAL.Member.tempMemberAdd(shmodel))
                    shmodel = DAL.Member.tempMemberList[shmodel.MID];

                Model.Accounts account = new Model.Accounts()
                {
                    AccountsDate = DateTime.MaxValue,
                    ACode = shmid,
                    CreateDate = DateTime.Now,
                    IfAccount = false,
                    IsAuto = true,
                    PCode = "001",
                    TotalFHMoney = 0,
                    FHCount = 0,
                    ARemark = shmid
                };
                //待激活的用户进入系统时候的金额
                shmodel.RoleCode = BLL.Configuration.Model.B_DefaultRole;
                shmodel.MDate = DateTime.Now;
                shmodel.ValidTime = DateTime.Now;
                shmodel.FHState = true;
                shmodel.MConfig = new Model.MemberConfig()
                {
                    MID = shmodel.MID,
                    YJCount = 1,
                    YJMoney = shmodel.SHMoney,
                    UpSumMoney = shmodel.SHMoney,
                    JJTypeList = DAL.Reward.RewardStr,
                    JTFHState = true,
                    DTFHState = true
                };
                DAL.Member.tempMemberAdd(shmodel);
                if (model.Role.Super)
                {
                    HBChangeTran(shmodel.SHMoney, model.MID, "Activation", "SH", shmodel, "MHB", model.MID + "审核该会员", MyHs);//货币减少
                }
                else
                {
                    if (!EnoughChange(model.MID, shmodel.SHMoney, "MJB"))
                        return "您的报单币不足，不能激活会员";
                    HBChangeTran(shmodel.SHMoney, model.MID, BLL.Member.ManageMember.TModel.MID, "SH", shmodel, "MJB", model.MID + "审核该会员", MyHs);
                }
                BLL.Accounts.BDInsert(account, MyHs);

                shmodel.MState = true;
                shmodel.MDate = DateTime.Now;
                shmodel.IsNewMemberSH = true;
                shmodel.MConfig.SHMoney = shmodel.SHMoney;
                DAL.Member.Update(shmodel, MyHs);
                if (DAL.CommonBase.RunHashtable(MyHs))
                {
                    BLL.Task.ManageSend(shmodel, "恭喜您已成功激活成为正式会员");
                    return "操作成功";
                }
                DAL.Member.tempMemberList.Clear();//清空临时字典
                return "操作失败";
            }
        }

        /// <summary>
        /// 会员充值货币
        /// </summary>
        /// <param name="mid"></param>
        /// <param name="money"></param>
        /// <param name="mType"></param>
        /// <returns></returns>
        public static Hashtable CZMoneyChange(string frommid, string tomid, decimal money, string mType, Hashtable MyHs)
        {
            HBChangeTran(money, frommid, tomid, "CZ", null, mType, "", MyHs);
            return MyHs;
        }

        /// <summary>
        /// 会员扣费
        /// </summary>
        /// <param name="frommid"></param>
        /// <param name="tomid"></param>
        /// <param name="money"></param>
        /// <param name="mType"></param>
        /// <param name="MyHs"></param>
        /// <returns></returns>
        public static Hashtable KFMoneyChange(string frommid, string tomid, decimal money, string mType, Hashtable MyHs)
        {
            HBChangeTran(money, frommid, tomid, "KZ", null, mType, "", MyHs);
            return MyHs;
        }

        public static string GMMoneyChange(int money, string mid, string from, string to, Hashtable MyHs)
        {
            lock (DAL.Member.tempMemberList)
            {
                DAL.Member.tempMemberList.Clear();
                BLL.ChangeMoney.HBChangeTran(money, mid, BLL.Member.ManageMember.TModel.MID, "GM", null, from, BLL.Reward.List[to].RewardName, MyHs);
                BLL.ChangeMoney.HBChangeTran(money, BLL.Member.ManageMember.TModel.MID, mid, "GM", null, to, "", MyHs);

                if (BLL.CommonBase.RunHashtable(MyHs))
                    return "购买成功";
                return "购买失败";
            }
        }

        #endregion

        #region 公共货币及财务转移操作

        /// <summary>
        /// 转账货币
        /// </summary>
        /// <param name="money">货币数目</param>
        /// <param name="model">当前对象</param>
        /// <param name="tomid">目标对象</param>
        /// <returns></returns>
        public static string ZZMoneyChange(int money, string fromid, string tomid, string changetype, string moneyType)
        {
            if (!EnoughChange(fromid, money, moneyType))
                return "您的可用" + BLL.Reward.List[moneyType].RewardName + "不足";
            if (money < DAL.Configuration.TModel.B_ZZMinMoney)
                return "转账金额最小为" + DAL.Configuration.TModel.B_ZZMinMoney;
            else if ((money - DAL.Configuration.TModel.B_ZZMinMoney) % DAL.Configuration.TModel.B_ZZBaseMoney != 0)
                return "转账金额应是" + DAL.Configuration.TModel.B_ZZBaseMoney + "的倍数";


            Hashtable MyHs = new Hashtable();
            lock (DAL.Member.tempMemberList)
            {
                DAL.Member.tempMemberList.Clear();
                HBChangeTran(money, fromid, tomid, "ZZ", null, moneyType, "", MyHs);
            }

            if (DAL.CommonBase.RunHashtable(MyHs))
                return "操作成功";
            return "操作失败";
        }

        /// <summary>
        /// 转移货币哈希表
        /// </summary>
        /// <param name="money">货币数目</param>
        /// <param name="model">当前对象</param>
        /// <param name="tomid">目标对象</param>
        /// <returns></returns>
        public static decimal HBChangeTran(decimal money, string frommid, string tomid, string changetype, Model.Member shmodel, string moneytype, string remark, Hashtable MyHs, string source = "", string source1 = "", string source2 = "")
        {
            frommid = frommid.ToLower().Trim();
            tomid = tomid.ToLower().Trim();

            if (!DAL.Member.HasMemberConfigInDic(frommid))
            {
                Model.Member frommodel = DAL.Member.GetModel(frommid);
                DAL.Member.tempMemberAdd(frommodel);
            }
            if (!DAL.Member.HasMemberConfigInDic(tomid))
            {
                Model.Member tomodel = DAL.Member.GetModel(tomid);
                DAL.Member.tempMemberAdd(tomodel);
            }
            Model.ChangeMoney changemoney = new Model.ChangeMoney();

            changemoney.ChangeType = changetype;
            changemoney.ChangeDate = DateTime.Now;
            changemoney.FromMID = frommid;
            changemoney.MoneyType = moneytype;
            changemoney.Money = money;//交易金额
            changemoney.ToMID = tomid;
            changemoney.CRemarks = remark;
            changemoney.source = source;
            changemoney.source1 = source1;
            changemoney.source2 = source2;
            if (shmodel == null)
                changemoney.SHMID = "";
            else
                changemoney.SHMID = shmodel.MID;

            if (DAL.Member.tempMemberList[tomid].IsClock)//如果被冻结或者未激活。
            {
                return 0;
            }
            //else if ((changemoney.ChangeType == "R_LD" || changemoney.ChangeType == "R_RFH" || changemoney.ChangeType == "R_TJ") && !DAL.Member.tempMemberList[tomid].MState)
            //{
            //    return 0;
            //}
            else
            {
                changemoney.CState = true;//是否自动结算
                TakeOffMoneyTran(changemoney, DAL.Member.tempMemberList[frommid], DAL.Member.tempMemberList[tomid], shmodel, MyHs);
            }
            if (changemoney.Money >= 0.01m)
            {
                InsertTran(changemoney, MyHs);
                TranChangeTran(changemoney, MyHs);
            }
            return changemoney.Money;
        }

        # endregion

        # region 系统自动业务奖励

        /// <summary>
        /// 解冻秒结奖
        /// </summary>
        /// <returns></returns>
        public static bool R_JDReward()
        {
            List<Model.ChangeMoney> list = DAL.ChangeMoney.GetList(" CState = 0 and ChangeType in (" + BLL.Reward.AllRewardStr + ") ");
            Hashtable MyHs = new Hashtable();
            foreach (var model in list)
            {
                model.CState = true;//有效状态
                DistributeMoney(model, DAL.Member.GetModel(model.ToMID), null, MyHs);//分配钱
                DAL.ChangeMoney.UpdataTran(model, MyHs);//更新状态
                TranChangeTran(model, MyHs);//转钱
            }
            return CommonBase.RunHashtable(MyHs);
        }

        /// <summary>
        /// 重复消费，封顶
        /// </summary>
        /// <param name="changemoney"></param>
        private static void TakeOffMoneyTran(Model.ChangeMoney changemoney, Model.Member FromModel, Model.Member ToModel, Model.Member shmodel, Hashtable MyHs)
        {
            if (DAL.Reward.List.Any(emp => emp.Value.NeedProcess && emp.Key == changemoney.ChangeType && emp.Value.RewardState))
            {
                if (!ToModel.MConfig.JJTypeList.Contains(changemoney.ChangeType.ToString()))
                {
                    changemoney.Money = 0;
                    return;
                }

                if (changemoney.ChangeType == "R_RFH")
                {
                    if (!ToModel.MConfig.JTFHState)
                    {
                        changemoney.Money = 0;
                        return;
                    }
                }
                else
                {
                    if (!ToModel.MConfig.DTFHState)
                    {
                        changemoney.Money = 0;
                        return;
                    }
                }
                //if (changemoney.ChangeType == "R_DP")
                //{
                //    decimal money = BLL.ChangeMoney.GetDayFHMoney(ToModel.MID, "'R_DP'", 0);

                //    if (money + changemoney.Money > ToModel.MAgencyType.DPTopMoney)
                //    {
                //        changemoney.Money = ToModel.MAgencyType.DPTopMoney - money;
                //    }
                //    if (changemoney.Money <= 0)
                //    {
                //        changemoney.Money = 0;
                //        return;
                //    }
                //    R_GL(changemoney.Money, ToModel, shmodel, MyHs);
                //}

                //if (changemoney.ChangeType == "R_GL")
                //{
                //    decimal money = BLL.ChangeMoney.GetDayFHMoney(ToModel.MID, "'R_GL'", 0);
                //    if (money + changemoney.Money > ToModel.MAgencyType.YJMoney)
                //    {
                //        changemoney.Money = ToModel.MAgencyType.YJMoney - money;
                //    }
                //    if (changemoney.Money <= 0)
                //    {
                //        changemoney.Money = 0;
                //        return;
                //    }
                //    DAL.Member.CPListAdd(ToModel.MID, changemoney.Money);
                //}

                //changemoney.ReBuyMoney = changemoney.Money * ToModel.MAgencyType.ReBuyFloat;
                DistributeMoney(changemoney, ToModel, shmodel, MyHs);

                if (!DAL.Member.HasMemberConfigInDic(ToModel.MID))//不存在
                {
                    DAL.Member.tempMemberAdd(ToModel);
                }
                else//存在
                {
                    DAL.Member.tempMemberList[ToModel.MID] = ToModel;
                }
                if (BLL.Accounts.tempAccount != null && changemoney.Money > 0)
                {
                    if (BLL.Accounts.tempAccount.AccountMember.ContainsKey(ToModel.MID))
                        BLL.Accounts.tempAccount.AccountMember[ToModel.MID] = changemoney.Money;
                    else
                        BLL.Accounts.tempAccount.AccountMember.Add(ToModel.MID, changemoney.Money);
                }
            }
            else if (changemoney.ChangeType == "TX")
            {
                decimal txfloat = Convert.ToDecimal(BLL.ConfigDictionaryNew.GetConfigDictionary(Convert.ToInt32(changemoney.Money), "TXTake", "").DValue);
                changemoney.TakeOffMoney = Math.Round(changemoney.Money * txfloat, 2);
                decimal fjmoney = Convert.ToDecimal(BLL.CommonBase.GetSingle("SELECT ISNULL(SUM(Money),0) FROM dbo.ChangeMoney WHERE ChangeType='appplyIn' AND DATEDIFF(WEEK,ChangeDate,GETDATE())=1 AND FromMID IN(SELECT mid FROM  dbo.getSubBDMember('" +changemoney.FromMID+ "'));"));
                if (fjmoney<FromModel.MAgencyType.DPFloat)
                    changemoney.ReBuyMoney=(changemoney.Money-changemoney.TakeOffMoney)*FromModel.MAgencyType.ReBuyFloat;
            }
        }

        /// <summary>
        /// 分配实际钱数
        /// </summary>
        private static Hashtable DistributeMoney(Model.ChangeMoney changemoney, Model.Member ToModel, Model.Member shmodel, Hashtable MyHs)
        {
            if (changemoney.CState)
            {
                //重复消费
                ToModel.MConfig.MCW += changemoney.ReBuyMoney;
                //重复消费
                DAL.MemberConfig.UpdateConfigTran(ToModel.MID, "MCW", changemoney.ReBuyMoney.ToString(), shmodel, false, SqlDbType.Decimal, MyHs);

                //总分红
                ToModel.MConfig.TotalMoney += changemoney.Money;
                //总分红
                DAL.MemberConfig.UpdateConfigTran(ToModel.MID, "TotalMoney", changemoney.Money.ToString(), shmodel, false, SqlDbType.Decimal, MyHs);

                //真实钱数
                ToModel.MConfig.RealMoney += changemoney.Money - changemoney.TakeOffMoney - changemoney.ReBuyMoney - changemoney.MCWMoney - changemoney.extra1;
                //真实钱数
                DAL.MemberConfig.UpdateConfigTran(ToModel.MID, "RealMoney", (changemoney.Money - changemoney.TakeOffMoney - changemoney.ReBuyMoney - changemoney.MCWMoney - changemoney.extra1).ToString(), shmodel, false, SqlDbType.Decimal, MyHs);

                //总扣费
                ToModel.MConfig.TakeOffMoney += changemoney.TakeOffMoney;
                //总扣费
                DAL.MemberConfig.UpdateConfigTran(ToModel.MID, "TakeOffMoney", changemoney.TakeOffMoney.ToString(), shmodel, false, SqlDbType.Decimal, MyHs);

                //总B网基金数
                ToModel.MConfig.ReBuyMoney += changemoney.ReBuyMoney;
                //总B网基金数
                DAL.MemberConfig.UpdateConfigTran(ToModel.MID, "ReBuyMoney", changemoney.ReBuyMoney.ToString(), shmodel, false, SqlDbType.Decimal, MyHs);
            }
            return MyHs;
        }

        public static Hashtable GWChangeTran(string mid, decimal money, Hashtable MyHs)
        {
            lock (DAL.Member.tempMemberList)
            {
                Model.Member member = DAL.Member.GetModel(mid);
                DAL.Member.tempMemberList.Clear();
                //获取业绩小的会员
                List<Model.Member> list = new BLL.Member().GetMemberEntityList(" MState = 1 and MBD = '" + mid + "' ");
                if (list != null && list.Any())
                {
                    Model.Member model = list.OrderBy(m => m.MConfig.UpSumMoney).FirstOrDefault();
                    model.MConfig.YJMoney += (int)money;
                    DAL.MemberConfig.UpdateConfigTran(model.MID, "YJMoney", money.ToString(), member, false, SqlDbType.Int, MyHs);
                    model.MConfig.UpSumMoney += (int)money;
                    DAL.MemberConfig.UpdateConfigTran(model.MID, "UpSumMoney", money.ToString(), member, false, SqlDbType.Int, MyHs);
                    if (!DAL.Member.tempMemberAdd(model))
                    {
                        DAL.Member.tempMemberList[model.MID].MConfig.YJMoney = model.MConfig.YJMoney;
                        DAL.Member.tempMemberList[model.MID].MConfig.UpSumMoney = model.MConfig.UpSumMoney;
                        DAL.Member.tempMemberList[model.MID].MConfig.YJCount = model.MConfig.YJCount;
                    }

                    //R_LP(model, member, MyHs);
                }

                DAL.Member.tempMemberList.Clear();
            }

            return MyHs;
        }

        /// <summary>
        /// 分红奖
        /// </summary>
        /// <param name="model">待审核会员</param>
        /// <param name="MyHs">SQL批处理</param>
        /// <returns></returns>
        public static Hashtable FHChangeTran(Model.Accounts model, Hashtable MyHs)
        {
            BLL.Accounts.tempAccount = model;
            if (model.PCode == "001" || model.PCode == "005")
            {
                Model.Member shmodel = DAL.Member.GetModel(model.ARemark);
                if (DAL.Member.HasMemberConfigInDic(shmodel.MID))
                    shmodel = DAL.Member.tempMemberList[shmodel.MID];
                YJCountTran(shmodel, shmodel, MyHs);
                TJCountTran(shmodel, MyHs);
                R_JD(shmodel.SHMoney - shmodel.MConfig.SHMoney, shmodel, shmodel, 1, MyHs);
                //if (model.PCode == "001")
                //{
                //    R_HBRecord(shmodel, MyHs);
                //    R_QY(shmodel, MyHs);
                //}
                //R_LP(shmodel, shmodel, MyHs);

                DAL.MemberConfig.UpdateConfigTran(shmodel.MID, "SHMoney", shmodel.SHMoney.ToString(), shmodel, true, SqlDbType.Decimal, MyHs);
            }
            else if (model.PCode == "003")//静态分红
            {
                Model.Member shmodel = new Model.Member { MID = model.ACode };

                DataTable list = BLL.CommonBase.GetTable(@"select a.MID,CONVERT(int,dvalue) from Member a inner join MemberConfig b on a.MID=b.MID left join ConfigDictionary on DType='DFHMoney' and TJCount between StartLevel and EndLevel inner join SHMoney c on a.AgencyCode=c.MAgencyType where CHARINDEX('DFH',JJTypeList)>0 and MState='1' and JTFHState='1' and IsClock<>'1' and RoleCode in ('VIP','Nomal') and TotalDFHMoney<CONVERT(int,DKey) and datediff(dd,isnull((select top 1 changedate from changemoney where changetype='dfh' and ToMID=a.mid order by changedate desc),dateadd(dd,-1,mdate)),getdate())>=1");

                foreach (DataRow item in list.Rows)
                {
                    HBChangeTran(Convert.ToDecimal(item[1]), BLL.Member.ManageMember.TModel.MID, item["MID"].ToString(), "DFH", shmodel, "MHB", "", MyHs);
                }
            }
            else if (model.PCode == "007")//季度分红
            {
                Model.Member shmodel = new Model.Member { MID = model.ACode };

                DataTable list = BLL.CommonBase.GetTable(@"select a.MID, hlgqcount from Member a inner join MemberConfig b on a.MID=b.MID inner join SHMoney c on a.AgencyCode=c.MAgencyType where CHARINDEX('JDFH',JJTypeList)>0 and MState='1' and JTFHState='1' and IsClock<>'1' and RoleCode in ('VIP','Nomal')");

                decimal fhfloat = Convert.ToDecimal(model.ARemark);

                foreach (DataRow item in list.Rows)
                {
                    HBChangeTran(Convert.ToDecimal(item[1]) * fhfloat, BLL.Member.ManageMember.TModel.MID, item["MID"].ToString(), "JDFH", shmodel, "MHB", "", MyHs);
                }
            }

            model.FHCount = model.AccountMember.Count;
            model.TotalFHMoney = model.AccountMember.Values.Sum();

            return MyHs;
        }

        /// <summary>
        /// 业绩更新(迭代)
        /// </summary>
        /// <param name="model">待审核会员（迭代的变量）</param>
        /// <param name="MyHs">SQL批处理</param>
        /// <param name="shmodel">待审核会员</param>
        /// <returns></returns>
        public static Hashtable YJCountTran(Model.Member model, Model.Member shmodel, Hashtable MyHs)
        {
            //获取待审核会员的接点人
            Model.Member tempmodel = DAL.Member.GetModel(model.MBD);

            if (tempmodel != null)
            {
                if (!DAL.Member.tempMemberAdd(tempmodel))
                {
                    tempmodel = DAL.Member.tempMemberList[model.MBD];
                }
                decimal yjmoney = shmodel.SHMoney - shmodel.MConfig.SHMoney;
                if (shmodel.MConfig.SHMoney == 0)
                {
                    tempmodel.MConfig.YJCount += 1;
                    DAL.MemberConfig.UpdateConfigTran(tempmodel.MID, "YJCount", "1", shmodel, false, SqlDbType.Int, MyHs);
                    tempmodel.MConfig.UpSumMoney += yjmoney;
                    DAL.MemberConfig.UpdateConfigTran(tempmodel.MID, "UpSumMoney", yjmoney.ToString(), shmodel, false, SqlDbType.Decimal, MyHs);
                }
                if (!DAL.Member.tempMemberAdd(tempmodel))
                {
                    DAL.Member.tempMemberList[tempmodel.MID].MConfig.YJMoney = tempmodel.MConfig.YJMoney;
                    DAL.Member.tempMemberList[tempmodel.MID].MConfig.UpSumMoney = tempmodel.MConfig.UpSumMoney;
                    DAL.Member.tempMemberList[tempmodel.MID].MConfig.YJCount = tempmodel.MConfig.YJCount;
                }
            }
            if (tempmodel != null && tempmodel.MID != tempmodel.MBD)
            {
                YJCountTran(tempmodel, shmodel, MyHs);
            }
            return MyHs;
        }

        /// <summary>
        /// 业绩更新(迭代)
        /// </summary>
        /// <param name="model">待审核会员（迭代的变量）</param>
        /// <param name="MyHs">SQL批处理</param>
        /// <param name="shmodel">待审核会员</param>
        /// <returns></returns>
        public static Hashtable YJSJCountTran(Model.Member model, Model.Member shmodel, Hashtable MyHs)
        {
            //获取待审核会员的接点人
            Model.Member tempmodel = DAL.Member.GetModel(model.MBD);

            if (tempmodel != null)
            {
                if (!DAL.Member.tempMemberAdd(tempmodel))
                {
                    tempmodel = DAL.Member.tempMemberList[model.MBD];
                }
                UpMAgencyCode(tempmodel, MyHs);
            }
            if (tempmodel != null && tempmodel.MID != tempmodel.MBD)
            {
                YJSJCountTran(tempmodel, shmodel, MyHs);
            }
            return MyHs;
        }

        public static Hashtable UpMAgencyCode(Model.Member model, Hashtable MyHs)
        {
            string agencycode = model.AgencyCode;
            List<Model.SHMoney> list = BLL.Configuration.Model.SHMoneyList.Values.Where(emp =>  emp.YJMoney <= model.MConfig.YJMoney).ToList();
            foreach (Model.SHMoney item in list)
            {
                if (item.YJMoney > model.MAgencyType.YJMoney)
                {
                    model.AgencyCode = item.MAgencyType;
                    model.MAgencyType = item;
                }
            }
            if (agencycode != model.AgencyCode)
                MyHs.Add("update member set AgencyCode='" + model.AgencyCode + "' where mid='" + model.MID + "'", null);
            return MyHs;
        }

        /// <summary>
        /// 业绩更新(迭代)
        /// </summary>
        /// <param name="model">待审核会员（迭代的变量）</param>
        /// <param name="MyHs">SQL批处理</param>
        /// <param name="shmodel">待审核会员</param>
        /// <returns></returns>
        public static Hashtable YJCountTran(decimal money, Model.Member model, Model.Member shmodel, Hashtable MyHs)
        {
            DAL.Member.UpdateMemberTran(model.MID, "SHmoney", money.ToString(), null, false, SqlDbType.Decimal, MyHs);
            DAL.MemberConfig.UpdateConfigTran(model.MID, "SHmoney", money.ToString(), null, false, SqlDbType.Decimal, MyHs);
            MyHs.Add(string.Format(" update MemberConfig set YJMoney = YJMoney + {0} where MID in (select MID from [dbo].[getParentBDMember]('{1}')); select '" + Guid.NewGuid() + "' ", money, model.MID), null);
            return MyHs;
        }

        /// <summary>
        /// 业绩增加时判断等级
        /// </summary>
        /// <returns></returns>
        //public static Hashtable GetMemberLevel(Model.Member member, Hashtable MyHs)
        //{
        //    //获取下级所有会员
        //    var members = DAL.Member.GetModelList(string.Format(" MBD = '{0}' and MID <> '{0}'", member.MID));
        //    if (members != null && members.Any())
        //    {
        //        int sumYJ = member.MConfig.YJMoney - member.MConfig.SHMoney;// 
        //        //获取最大业绩会员
        //        int maxYJ = members.Max(m => m.MConfig.YJMoney - m.MConfig.SHMoney);
        //        //获取部门数
        //        int count = members.Count;
        //        //获取小业绩之和
        //        int sumOtherYJ = members.Sum(m => m.MConfig.YJMoney - m.MConfig.SHMoney) - maxYJ;
        //        //获取最小业绩
        //        int minYJ = members.Min(m => m.MConfig.YJMoney - m.MConfig.SHMoney);
        //        foreach (var nsh in DAL.NewSHMoney.GetNewSHMoneyList(null))
        //        {
        //            if (sumYJ >= nsh.Value.NTotalYJ && count >= nsh.Value.NDCount && minYJ >= nsh.Value.NMinYJ && sumOtherYJ >= nsh.Value.NSmallSumYJ)
        //            {
        //                member.NewSHMoney = nsh.Value;
        //                member.NAgencyCode = nsh.Key;
        //            }
        //        }
        //        DAL.Member.UpdateMemberTran(member.MID, "NAgencyCode", member.NAgencyCode, null, true, SqlDbType.VarChar, MyHs);
        //    }
        //    return MyHs;
        //}

        /// <summary>
        /// 推荐更新
        /// </summary>
        /// <param name="shmodel">待审核会员</param>
        /// <param name="MyHs">SQL批处理</param>
        /// <returns></returns>
        public static Hashtable TJCountTran(Model.Member shmodel, Hashtable MyHs)
        {
            //获取推荐人的model
            Model.Member tjmodel = GetMember_R(shmodel.MTJ);
            if (tjmodel != null)
            {
                decimal tjmoney = shmodel.SHMoney - shmodel.MConfig.SHMoney;
                tjmodel.MConfig.TJMoney += tjmoney;
                DAL.MemberConfig.UpdateConfigTran(tjmodel.MID, "TJMoney", tjmoney.ToString(), shmodel, false, SqlDbType.Decimal, MyHs);
                
                //团队股权
                //tjmodel.MConfig.HLGQCount += tjmoney;
                //DAL.MemberConfig.UpdateConfigTran(tjmodel.MID, "HLGQCount", tjmoney.ToString(), shmodel, false, SqlDbType.Int, MyHs);
                //R_SJ(tjmodel, MyHs);
                if (shmodel.MConfig.SHMoney == 0)
                {
                    tjmodel.MConfig.TJCount += 1;
                    DAL.MemberConfig.UpdateConfigTran(tjmodel.MID, "TJCount", "1", shmodel, false, SqlDbType.Int, MyHs);

                    Model.ConfigDictionary cd = DAL.ConfigDictionary.GetConfigDictionary(tjmodel.MConfig.TJCount,"TJFloat","");
                    if (cd != null)
                    {
                        HBChangeTran(Convert.ToDecimal(cd.DValue), BLL.Member.ManageMember.TModel.MID, tjmodel.MID, "R_TJ", shmodel, "MCW", "", MyHs);
                    }
                    //BLL.LuckyMoney.Add(tjmodel.MID, MyHs);
                }
                //if (!DAL.Member.HasMemberConfigInDic(tjmodel.MID))//不存在
                //{
                //    DAL.Member.tempMemberAdd(tjmodel);
                //}
                //else//存在
                //{
                //    DAL.Member.tempMemberList[tjmodel.MID] = tjmodel;
                //}
                if (!DAL.Member.tempMemberAdd(tjmodel))
                {
                    DAL.Member.tempMemberList[tjmodel.MID].MConfig.TJMoney = tjmodel.MConfig.TJMoney;
                    DAL.Member.tempMemberList[tjmodel.MID].MConfig.TJCount = tjmodel.MConfig.TJCount;
                }
            }
            return MyHs;
        }

        /// <summary>
        /// 报单补贴奖哈希表,管理员不给予奖励
        /// </summary>
        /// <param name="shmodel">待审核会员</param>
        /// <param name="MyHs">SQL批处理</param>
        /// <returns></returns>
        public static Hashtable BTMoneyChangeTran(Model.Member shmodel, Hashtable MyHs)
        {
            Model.Member bdmodel = DAL.Member.GetModel(shmodel.MSH);
            if (bdmodel != null && !bdmodel.Role.Super && bdmodel.Role.CanSH)
            {
                decimal btmoney = (shmodel.SHMoney - shmodel.MConfig.SHMoney) * bdmodel.MAgencyType.BTFloat;
                HBChangeTran(btmoney, BLL.Member.ManageMember.TModel.MID, bdmodel.MID, "R_BT", shmodel, "MHB", "", MyHs);
            }
            return MyHs;
        }
        /// <summary>
        /// 反哺奖
        /// </summary>
        /// <param name="shmodel">待审核会员</param>
        /// <param name="MyHs">SQL批处理</param>
        /// <returns></returns>
        public static List<Model.Member> FPMoneyChangeTran(List<Model.Member> limember, List<Model.Member> liall, int count)
        {
            if (limember != null && limember.Count != 0)
            {
                if (count < 6)
                {
                    List<Model.Member> temp = new List<Model.Member>();
                    //temp = null;
                    foreach (Model.Member li in limember)
                    {
                        List<Model.Member> tjlist = DAL.MemberCollection.GetMemberEntityList(string.Format("MTJ='{0}' and AgencyCode<>'001' and MState='1'", li.MID));
                        foreach (Model.Member itemmember in tjlist)
                        {
                            temp.Add(itemmember);
                        }

                        liall.Add(li);
                    }

                    FPMoneyChangeTran(temp, liall, count + 1);

                }
            }
            return liall;
        }

        /// <summary>
        /// 推荐奖励
        /// </summary>
        /// <param name="shmodel">待审核会员</param>
        /// <param name="MyHs">SQL批处理</param>
        /// <returns></returns>
        public static Hashtable TJMoneyChangeTran(Model.Member model, Model.Member shmodel, Hashtable MyHs)
        {
            Model.Member tjmodel = DAL.Member.GetModel(model.MTJ);

            if (tjmodel != null && tjmodel.MID != tjmodel.MTJ)
            {
                decimal tjmoney = tjmodel.MAgencyType.TJFloat;
                HBChangeTran(tjmoney, BLL.Member.ManageMember.TModel.MID, tjmodel.MID, "TJ", shmodel, "MHB", "", MyHs);
            }
            return MyHs;
        }
        /// <summary>
        /// 见点奖
        /// </summary>
        /// <param name="shmodel">待审核会员</param>
        /// <param name="MyHs">SQL批处理</param>
        /// <returns></returns>
        public static Hashtable LDMoneyChangeTran(Model.Member model, Model.Member shmodel, int level, Hashtable MyHs)
        {
            //Model.Member bdmodel = DAL.Member.GetModel(model.MTJ);
            //if (level <= BLL.Configuration.Model.ConfigDictionaryList["LDMoney"].Max(emp => emp.EndLevel))
            //{
            //    if (bdmodel != null && bdmodel.MID != bdmodel.MTJ)
            //    {
            //        if (bdmodel.MConfig.TJCount >= bdmodel.MAgencyType.LDTJCount && !bdmodel.Role.Super)
            //        {
            //            Model.ConfigDictionary dic = DAL.ConfigDictionary.GetConfigDictionary(level, "LDMoney", "");
            //            if (dic != null)
            //            {
            //                decimal money = Convert.ToDecimal(dic.DValue);
            //                HBChangeTran(money, BLL.Member.ManageMember.TModel.MID, bdmodel.MID, "LD", shmodel, "MHB", "", MyHs);
            //            }
            //        }
            //        LDMoneyChangeTran(bdmodel, shmodel, level + 1, MyHs);
            //    }
            //}
            return MyHs;
        }
        /// <summary>
        /// 对碰奖/平衡奖
        /// </summary>
        /// <param name="model"></param>
        /// <param name="shmodel"></param>
        /// <param name="dpcount"></param>
        /// <param name="MyHs"></param>
        /// <returns></returns>
        //private static Hashtable DPMoneyChangeTran(Model.Member model, Model.Member shmodel, decimal dptopmoney, int dpcount, Hashtable MyHs)
        //{
        //    Model.Member bdmodel = DAL.Member.GetModel(model.MBD);
        //    if (bdmodel != null && bdmodel.MBD != bdmodel.MID)
        //    {
        //        if (!bdmodel.Role.Super)
        //        {
        //            List<Model.Member> smodel = DAL.MemberCollection.GetMemberEntityList(string.Format("MBD='{0}' and AgencyCode<>'001' and MID<>'{1}' and MState='1'", bdmodel.MID, model.MID));
        //            if (smodel.Count > 0)
        //            {
        //                if (DAL.Member.HasMemberConfigInDic(model.MID))
        //                    model = DAL.Member.tempMemberList[model.MID];
        //                if (DAL.Member.HasMemberConfigInDic(smodel[0].MID))
        //                    smodel[0] = DAL.Member.tempMemberList[smodel[0].MID];
        //                if (!DAL.Member.tempMemberAdd(bdmodel))
        //                    bdmodel = DAL.Member.tempMemberList[bdmodel.MID];

        //                int dpmoney = smodel[0].MConfig.UpSumMoney > model.MConfig.UpSumMoney ? model.MConfig.UpSumMoney : smodel[0].MConfig.UpSumMoney;

        //                //if (dpmoney > 0 && dpcount <= 9999999)
        //                {
        //                    dpcount += 1;
        //                    decimal money = dpmoney * BLL.Configuration.Model.B_DPFloat;
        //                    if (bdmodel.MConfig.TJCount >= BLL.Configuration.Model.B_MaxDPCount)
        //                        HBChangeTran(money, BLL.Member.ManageMember.TModel.MID, bdmodel.MID, "R_DP", shmodel, "MHB", "", MyHs);
        //                }

        //                model.MConfig.UpSumMoney -= dpmoney;
        //                smodel[0].MConfig.UpSumMoney -= dpmoney;

        //                DAL.MemberConfig.UpdateConfigTran(model.MID, "UpSumMoney", (-dpmoney).ToString(), shmodel, false, SqlDbType.Int, MyHs);
        //                DAL.MemberConfig.UpdateConfigTran(smodel[0].MID, "UpSumMoney", (-dpmoney).ToString(), shmodel, false, SqlDbType.Int, MyHs);


        //            }
        //        }
        //        DPMoneyChangeTran(bdmodel, shmodel, dptopmoney, dpcount, MyHs);
        //    }
        //    return MyHs;
        //}

        public static bool HBJLChangeTran(Model.Member model, decimal money, string type)
        {
            lock (DAL.Member.tempMemberList)
            {
                Hashtable MyHs = new Hashtable();
                HBChangeTran(money, BLL.Member.ManageMember.TModel.MID, model.MID, type, model, "MHB", "", MyHs);
                return BLL.CommonBase.RunHashtable(MyHs);
            }
        }

        /// <summary>
        /// 服务订购
        /// </summary>
        /// <param name="model"></param>
        /// <param name="MyHs"></param>
        /// <returns></returns>
        public static Hashtable PayOrder(Model.Order model, Hashtable MyHs)
        {
            //Model.Member member = DAL.Member.GetModel(model.OrderMID);
            //if (member != null)
            //{
            //    if (!DAL.Member.tempMemberAdd(member))
            //        member = DAL.Member.tempMemberList[member.MID];

            //    member.SHMoney += model.GPrice;
            //    HBChangeTran(model.GPrice, member.MID, BLL.Member.ManageMember.TModel.MID, "GW", new Model.Member() { MID = model.OrderCode }, "MGP", "", MyHs);
            //}
            return MyHs;
        }

        public static Hashtable CJMoneyChangeTran(Model.BonusList model, Hashtable MyHs)
        {
            HBChangeTran(BLL.TicketBonus.Model.Money, model.MID, BLL.Member.ManageMember.TModel.MID, "GW", new Model.Member() { MID = model.BonusCode }, "MHB", "", MyHs);
            return MyHs;
        }

        public static Hashtable GetGiftMoneyChangeTran(Model.BonusList model, Hashtable MyHs)
        {
            Model.BonusGift gift = BLL.BonusGift.GetModel(model.GiftCode);
            if (gift.GiftType == "MHB" || gift.GiftType == "MJB")
            {
                HBChangeTran(Convert.ToDecimal(gift.GiftCount), BLL.Member.ManageMember.TModel.MID, model.MID, "CJ", new Model.Member() { MID = model.BonusCode }, gift.GiftType, "", MyHs);
            }
            return MyHs;
        }

        #endregion

        #region 算法及数据处理

        /// <summary>
        /// 转移货币事务哈希表
        /// </summary>
        public static Hashtable TranChangeTran(Model.ChangeMoney model, Hashtable MyHs)
        {
            if (model.CState)
            {
                if (model.ChangeType.ToUpper() == "TX")
                    return DAL.ChangeMoney.TranChangeTran(model.FromMID, model.ToMID, model.Money, model.MoneyType, MyHs);
                else
                    return DAL.ChangeMoney.TranChangeTran(model.FromMID, model.ToMID, model.Money - model.TakeOffMoney - model.ReBuyMoney - model.MCWMoney - model.extra1, model.MoneyType, MyHs);
            }
            return MyHs;
        }

        /// <summary>
        /// 判断是否可以转移货币
        /// </summary>
        /// <param name="model">来自会员对象</param>
        /// <param name="money">货币数目</param>
        /// <returns></returns>
        public static bool EnoughChange(string frommid, decimal money, string moneytype)
        {
            Model.Member model = DAL.Member.GetModel(frommid);

            if (model.Role.Super)
                return true;
            var list = moneytype.Split(';');
            decimal totalMoney = 0;
            foreach (string mt in list)
            {
                string mtmt = mt;
                if (!string.IsNullOrEmpty(mtmt))
                {
                    if (mtmt == "MHB")
                        mtmt = "MJJ";
                    PropertyInfo pinfo = typeof(Model.MemberConfig).GetProperty(mtmt);
                    totalMoney += Convert.ToDecimal(pinfo.GetValue(model.MConfig, null));
                }
            }
            if (totalMoney >= money)
            {
                return true;
            }
            return false;
        }

        public static Model.Member GetMember_R(string mid)
        {
            Model.Member member = new Model.Member();
            if (!DAL.Member.HasMemberConfigInDic(mid))//不存在
            {
                member = DAL.Member.GetModel(mid);
                DAL.Member.tempMemberAdd(member);
            }
            else//存在
            {
                member = DAL.Member.tempMemberList[mid];
            }
            return member;
        }

        public static List<Model.Member> GetMembers_R(string mid)
        {
            var list = DAL.Member.GetModelList(" MTJ = '" + mid + "' ");
            for (int index = 0; index < list.Count; index++)
            {
                if (!DAL.Member.HasMemberConfigInDic(list[index].MID))//不存在
                {
                    DAL.Member.tempMemberAdd(list[index]);
                }
                else//存在
                {
                    list[index] = DAL.Member.tempMemberList[list[index].MID];
                }
            }
            return list;
        }

        #endregion

        # region 获取数据列表

        public static List<Model.ChangeMoney> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.ChangeMoney.GetList(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.ChangeMoney> GetList(string strWhere)
        {
            return DAL.ChangeMoney.GetList(strWhere);
        }

        public static DataTable GetChangeTypeList(string mid, string changeType, string top)
        {
            return DAL.ChangeMoney.GetChangeTypeList(mid, changeType, top);
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="frommid">转出</param>
        /// <param name="tomid">转入</param>
        /// <param name="ChangeType">交易类型</param>
        /// <param name="MoneyType">币种</param>
        /// <param name="CRemarks">备注</param>
        public static bool IsExist(string frommid, string tomid, string ChangeType, string MoneyType, string CRemarks)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" 1 = 1 ");
            if (!string.IsNullOrEmpty(frommid))
            {
                strWhere.Append(" and FromMID = '" + frommid + "' ");
            }
            if (!string.IsNullOrEmpty(tomid))
            {
                strWhere.Append(" and ToMID = '" + tomid + "' ");
            }
            if (!string.IsNullOrEmpty(ChangeType))
            {
                strWhere.Append(" and ChangeType = '" + ChangeType + "' ");
            }
            if (!string.IsNullOrEmpty(MoneyType))
            {
                strWhere.Append(" and MoneyType = '" + MoneyType + "' ");
            }
            if (!string.IsNullOrEmpty(CRemarks))
            {
                strWhere.Append(" and CRemarks = '" + CRemarks + "' ");
            }
            List<Model.ChangeMoney> list = DAL.ChangeMoney.GetList(strWhere.ToString());
            if (list != null && list.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion 获取数据列表

        #region zx_270

        public static Hashtable R_TJ(decimal money, Model.Member member, Model.Member shmember, int level, Hashtable MyHs)
        {
            Model.Member MTJ = DAL.Member.GetModel(member.MTJ);
            if (MTJ != null && !MTJ.Role.IsAdmin)
            {
                if (level <= BLL.Configuration.Model.ConfigDictionaryList["TJFloat"].Max(emp => emp.EndLevel))
                {
                    decimal tjfloat = Convert.ToDecimal(DAL.ConfigDictionary.GetConfigDictionary(level, "TJFloat", "").DValue);
                    HBChangeTran(money * tjfloat, BLL.Member.ManageMember.TModel.MID, MTJ.MID, "R_TJ", shmember, "MHB", "", MyHs);
                    R_TJ(money, MTJ, shmember, level + 1, MyHs);
                }
            }
            return MyHs;
        }
        public static Hashtable R_JD(decimal money, Model.Member member, Model.Member shmember, int level, Hashtable MyHs)
        {
            Model.Member MTJ = DAL.Member.GetModel(member.MBD);
            if (MTJ != null && !MTJ.Role.IsAdmin)
            {
                if (level <= BLL.Configuration.Model.ConfigDictionaryList["JDFloat"].Max(emp => emp.EndLevel))
                {
                    decimal tjfloat = Convert.ToDecimal(DAL.ConfigDictionary.GetConfigDictionary(level, "JDFloat", "").DValue);
                    HBChangeTran( tjfloat, BLL.Member.ManageMember.TModel.MID, MTJ.MID, "R_JD", shmember, "MCW", "", MyHs);
                    R_JD(money, MTJ, shmember, level + 1, MyHs);
                }
            }
            return MyHs;
        }
        /// <summary>
        /// 日分红
        /// </summary>
        public static bool R_DFH()
        {
            Hashtable sqls = new Hashtable();
            sqls.Add("EXEC dbo.R_DFH", null);

            return CommonBase.RunHashtable(sqls);

            //BLL.ZFHTable bll = new ZFHTable();
            //var ff = bll.GetModel();
            //if (ff != null && ff.FHState == 0)
            //{
            //    //设置值
            //    Hashtable MyHs = new Hashtable();
            //    MyHs.Add(string.Format(" update ZFHTable set  FHState = 1 "), null);

            //    return BLL.CommonBase.RunHashtable(MyHs);
            //}
            //else
            //{
            //    if (ff != null)
            //    {
            //        if (ff.FHState == 1)
            //        {
            //            throw new Exception("任务已提交,请等待");
            //        }
            //        else
            //        {
            //            throw new Exception("分红正在执行,请等待");
            //        }
            //    }
            //    throw new Exception("参数错误");
            //}

            //DECLARE @FHState int
            //   select @FHState = FHState from ZFHTable
            //   if (@FHState = 1)
            //   BEGIN
            //       update ZFHTable set FHState = 2
            //       DECLARE @return_value int
            //       EXEC    @return_value = [dbo].[R_DFH]
            //       update ZFHTable set FHState = 0
            //   END
        }

        /// <summary>
        /// 提现
        /// </summary>
        public static bool TX()
        {
            lock (DAL.Member.tempMemberList)
            {
                Hashtable MyHs = new Hashtable();
                //获取参与日分红的人数
                DataTable dt = CommonBase.GetTable(string.Format(@"select a.MID,b.MHB from Member a
                                                            left join MemberConfig b on a.MID = b.MID
                                                            where  b.MHB >= {0} and a.isclock = 0 and a.isclose = 0 and TXStatus=1 and RoleCode not in ('Activation','Manage','Notactive') ", BLL.Configuration.Model.B_TXMinMoney));

                foreach (DataRow row in dt.Rows)
                {
                    if (row["MID"] != null)
                    {
                        decimal money = decimal.Parse(row["MHB"].ToString());
                        if (money > BLL.Configuration.Model.B_TXMaxMoney)
                        {
                            money = BLL.Configuration.Model.B_TXMaxMoney;
                        }
                        Model.Member model = BLL.Member.GetModelByMID(row["MID"].ToString());
                        Model.ChangeMoney changemoney = new Model.ChangeMoney();
                        changemoney.ChangeDate = DateTime.Now;
                        changemoney.ChangeType = "TX";
                        changemoney.FromMID = model.MID;
                        changemoney.Money = Math.Floor(money);
                        changemoney.MoneyType = "MHB";
                        changemoney.CState = false;
                        changemoney.ToMID = BLL.Member.ManageMember.TModel.MID;
                        string bankName = model.Bank;
                        try
                        {
                            bankName = new CommonBLL.Sys_BankInfoBLL().GetModel(model.Bank).Name;
                        }
                        catch
                        {

                        }
                        changemoney.CRemarks = model.Province + "~" + model.City + "~" + bankName + "~" + model.Branch + "~" + model.BankCardName + "~" + model.BankNumber;
                        TakeOffMoneyTran(changemoney, model, BLL.Member.ManageMember.TModel, null, MyHs);
                        DAL.MemberConfig.UpdateConfigTran(model.MID, "MHB", "-" + changemoney.Money, model, false, SqlDbType.Decimal, MyHs);
                        //DAL.MemberConfig.UpdateConfigTran(model.MID, "TotalTXMoney", money.ToString(), model, false, SqlDbType.Decimal, MyHs);
                        InsertTran(changemoney, MyHs);
                    }
                }
                bool result = DAL.CommonBase.RunHashtable(MyHs);
                if (result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion zx_270
    }
}