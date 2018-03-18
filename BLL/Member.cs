using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Transactions;

namespace yny_004.BLL
{
    public class Member
    {
        public Model.Member TModel { get; set; }
        public static List<string> upmidlist = new List<string>();

        private static Member _ManageMember;
        public static Member ManageMember
        {
            get
            {
                if (_ManageMember == null || _ManageMember.TModel == null)
                {
                    _ManageMember = new Member();
                    _ManageMember.TModel = DAL.Member.ManageMember;
                }
                return _ManageMember;
            }
            set
            {
                _ManageMember = value;
            }
        }
        public static void AddOnLine(string mid)
        {
            DAL.Member.AddOnLine(mid);
        }

        public static bool IfOnLine(string mid)
        {
            return DAL.Member.IfOnLine(mid);
        }

        public static string GetOnlineInfo(string mid)
        {
            return "";
            if (BLL.Member.IfOnLine(mid))
                return "<b style='color:#A8FF24;cursor:help;' title='我在线请对话' onclick='OpenTask(\"" + mid + "\");'><img src='SourceFiles/AcmeBlue/images/on.jpg'/></b>";
            else
                return "<b style='cursor:help;' title='我不在线请留言' onclick='OpenTask(\"" + mid + "\");'><img src='SourceFiles/AcmeBlue/images/off.jpg'/></b>";
        }

        public static int OnLineCount
        {
            get
            {
                return DAL.Member._onLineMember.Where(emp => DAL.Member.IfOnLine(emp.Key)).Count();
            }
        }
        public static List<string> OnLineMember
        {
            get
            {
                return DAL.Member._onLineMember.Keys.Where(emp => IfOnLine(emp)).ToList();
            }
        }
        /// <summary>
        /// 更新会员资料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.Member model)
        {
            return DAL.Member.Update(model);
        }

        public Hashtable Update(Model.Member model, Hashtable MyHs)
        {
            return DAL.Member.Update(model, MyHs);
        }

        public bool MemberClose(Model.Member model)
        {
            return DAL.Member.MemberClose(model);
        }

        public string ShFTMember(Model.Member member)
        {
            Hashtable MyHs = new Hashtable();
            lock (DAL.Member.tempMemberList)
            {
                //if (!BLL.ChangeMoney.EnoughChange(member.MID, BLL.Configuration.Model.BCenterMoney, "MJB"))
                //    return "您的报单币不足，复投失败";

                //BLL.ChangeMoney.HBChangeTran(BLL.Configuration.Model.BCenterMoney, member.MID, ManageMember.TModel.MID, "FT", member, "MJB", "复投", MyHs);
                //member.FHState = true;
                //member.ValidTime = DateTime.Now;
                //DAL.Member.UpdateRole(member, MyHs);
                //if (DAL.CommonBase.RunHashtable(MyHs))
                //{
                //    return "复投成功";
                //}
                //else
                {
                    return "复投失败";
                }
            }
        }

        public string UpMAgencyTypeJZZ(Model.SHMoney shmoney, string mid, Model.Member shmodel, int appendMoney)
        {
            Hashtable MyHs = new Hashtable();
            Model.Member model = DAL.Member.GetModel(mid);
            string agencyCode = model.AgencyCode;
            if (model == null)
                return "升级会员不存在";
            if (string.IsNullOrEmpty(model.MTJ))
                return "请联系管理员设置您的推荐人";
            decimal sjmoney = shmoney.Money - model.MAgencyType.Money;
            lock (DAL.Member.tempMemberList)
            {
                //DAL.Member.tempMemberList.Clear();
                //DAL.Member.tempMemberAdd(model);
                //if (!BLL.ChangeMoney.EnoughChange(shmodel.MID, BLL.Configuration.Model.JTFHMoney, "MCW"))
                //    return "您的金种子积分不足，不能激活金种子会员";
                //if (BLL.ChangeMoney.HBChangeTran(BLL.Configuration.Model.JTFHMoney, shmodel.MID, ManageMember.TModel.MID, "SH", model, "MCW", model.MAgencyType.MAgencyName + "->" + shmoney.MAgencyName, MyHs) > 0)
                //{
                //    model.MConfig.YJMoney += sjmoney;
                //    DAL.MemberConfig.UpdateConfigTran(model.MID, "YJMoney", sjmoney.ToString(), model, false, SqlDbType.Int, MyHs);
                //    model.SHMoney += sjmoney;
                //    string PCode = "005";//升级
                //    if (!model.MState)
                //    {
                //        PCode = "001";//激活升级
                //        model.MSH = shmodel.MID;
                //        string error = Validation2(model);
                //        if (!string.IsNullOrEmpty(error))
                //        {
                //            return error;
                //        }
                //        model.MConfig.YJCount += 1;
                //        DAL.MemberConfig.UpdateConfigTran(model.MID, "YJCount", "1", model, false, SqlDbType.Int, MyHs);
                //        model.MConfig.JTFHState = true;
                //        DAL.MemberConfig.UpdateConfigTran(model.MID, "JTFHState", "1", model, true, SqlDbType.Bit, MyHs);
                //        model.MConfig.DTFHState = false;
                //        DAL.MemberConfig.UpdateConfigTran(model.MID, "DTFHState", "0", model, true, SqlDbType.Bit, MyHs);
                //        model.MConfig.UpSumMoney += 1;
                //        DAL.MemberConfig.UpdateConfigTran(model.MID, "UpSumMoney", "1", model, false, SqlDbType.Int, MyHs);

                //        model.RoleCode = "Nomal";
                //        model.Role = BLL.Roles.RolsList["Nomal"];
                //        model.MDate = DateTime.Now;
                //        model.MState = true;
                //        model.FHState = true;
                //        model.ValidTime = DateTime.Now;
                //    }
                //    // 二次升级的奖金按照升级之前的级别拿比例
                //    model.AgencyCode = shmoney.MAgencyType;
                //    model.MAgencyType = shmoney;
                //    model.MSH = shmodel.MID;

                //    DAL.Member.UpdateRole(model, MyHs);
                //    Model.Accounts account = new Model.Accounts()
                //    {
                //        AccountsDate = DateTime.MaxValue,
                //        ACode = model.MID + "_" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                //        CreateDate = DateTime.Now,
                //        IfAccount = false,
                //        IsAuto = true,
                //        PCode = PCode,
                //        TotalFHMoney = 0,
                //        FHCount = 0,
                //        ARemark = model.MID
                //    };
                //    if (model.MSH != shmodel.MID)
                //        account.ID = -1;
                //    BLL.Accounts.BDInsert(account, MyHs, false);

                //    if (DAL.CommonBase.RunHashtable(MyHs))
                //    {
                //        DAL.Member.tempMemberList.Clear();//清空临时字典
                //        return "恭喜您成功升级至" + shmoney.MAgencyName + "，本次消耗" + sjmoney;
                //    }
                //}
            }
            return "升级失败";
        }
        protected object sjobj = new object();
        public string UpMAgencyType(Model.SHMoney shmoney, string mid, string moneyType, Model.Member shmodel, decimal appendMoney, string bdmid = "")
        {
            lock (sjobj)
            {
                Model.Member model = DAL.Member.GetModel(mid);
                if (model == null)
                    return "升级会员不存在";
                if (string.IsNullOrEmpty(model.MTJ))
                    return "请联系管理员设置您的推荐人";
                decimal sjmoney = appendMoney;
                Hashtable MyHs = new Hashtable();
                lock (DAL.Member.tempMemberList)
                {
                    DAL.Member.tempMemberList.Clear();
                    DAL.Member.tempMemberAdd(model);
                    if (!BLL.ChangeMoney.EnoughChange(shmodel.MID, sjmoney, moneyType))
                        return "您的" + BLL.Reward.List[moneyType].RewardName + "不足";
                    if (BLL.ChangeMoney.HBChangeTran(sjmoney, shmodel.MID, ManageMember.TModel.MID, "SH", model, moneyType, model.MAgencyType._MAgencyName + " -> " + shmoney._MAgencyName, MyHs) > 0)
                    {
                        model.MConfig.YJMoney += sjmoney;
                        DAL.MemberConfig.UpdateConfigTran(model.MID, "YJMoney", sjmoney.ToString(), model, false, SqlDbType.Decimal, MyHs);

                        string PCode = "005";//升级
                        if (!model.MState)
                        {
                            string error = Validation2(model, shmoney);
                            if (!string.IsNullOrEmpty(error))
                            {
                                return error;
                            }
                            PCode = "001";//激活升级
                            model.MConfig.YJCount += 1;
                            DAL.MemberConfig.UpdateConfigTran(model.MID, "YJCount", "1", model, false, SqlDbType.Int, MyHs);
                            model.MConfig.JTFHState = true;
                            DAL.MemberConfig.UpdateConfigTran(model.MID, "JTFHState", "1", model, true, SqlDbType.Bit, MyHs);
                            model.MConfig.DTFHState = true;
                            DAL.MemberConfig.UpdateConfigTran(model.MID, "DTFHState", "1", model, true, SqlDbType.Bit, MyHs);
                            model.MConfig.UpSumMoney += sjmoney;
                            DAL.MemberConfig.UpdateConfigTran(model.MID, "UpSumMoney", sjmoney.ToString(), model, false, SqlDbType.Decimal, MyHs);

                            model.RoleCode = "Nomal";
                            model.Role = BLL.Roles.RolsList["Nomal"];
                            model.MDate = DateTime.Now;
                            model.MState = true;
                            model.FHState = false;
                            model.ValidTime = DateTime.Now;
                        }
                        if (shmoney != null)
                        {
                            // 二次升级的奖金按照升级之前的级别拿比例
                            model.AgencyCode = shmoney.MAgencyType;
                            model.MAgencyType = shmoney;
                            //if (model.AgencyCode == "004")
                            //{
                            //    model.RoleCode = "VIP";
                            //}
                        }

                        DAL.Member.UpdateRole(model, MyHs);
                        model.SHMoney += sjmoney;

                        Model.Accounts account = new Model.Accounts()
                        {
                            AccountsDate = DateTime.MaxValue,
                            ACode = model.MID + "_" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                            CreateDate = DateTime.Now,
                            IfAccount = false,
                            IsAuto = true,
                            PCode = PCode,
                            TotalFHMoney = 0,
                            FHCount = 0,
                            ARemark = model.MID
                        };

                        BLL.Accounts.BDInsert(account, MyHs);

                        if (DAL.CommonBase.RunHashtable(MyHs))
                        {
                            DAL.Member.tempMemberList.Clear();//清空临时字典
                            DAL.BMember.tempBMemberList.Clear();//清空临时字典

                            return "恭喜您升级成功，本次消耗" + sjmoney.ToString("F2");
                        }
                    }
                }
                return "升级失败";
            }
        }

		public string ShopUpMAgencyType(Model.SHMoney shmoney, string mid, string moneyType, Model.Member shmodel, decimal appendMoney, string bdmid = "")
		{
			lock (sjobj)
			{
				Model.Member model = DAL.Member.GetModel(mid);
				if (model == null)
					return "升级会员不存在";
				if (string.IsNullOrEmpty(model.MTJ))
					return "请联系管理员设置您的推荐人";
				decimal sjmoney = appendMoney;
				Hashtable MyHs = new Hashtable();
				lock (DAL.Member.tempMemberList)
				{
					DAL.Member.tempMemberList.Clear();
					DAL.Member.tempMemberAdd(model);
					//if (!BLL.ChangeMoney.EnoughChange(shmodel.MID, sjmoney, moneyType))
					//	return "您的" + BLL.Reward.List[moneyType].RewardName + "不足";
					//if (BLL.ChangeMoney.HBChangeTran(sjmoney, shmodel.MID, ManageMember.TModel.MID, "SH", model, moneyType, model.MAgencyType._MAgencyName + " -> " + shmoney._MAgencyName, MyHs) > 0)
					{
						model.MConfig.YJMoney += sjmoney;
						DAL.MemberConfig.UpdateConfigTran(model.MID, "YJMoney", sjmoney.ToString(), model, false, SqlDbType.Decimal, MyHs);

						string PCode = "005";//升级
						if (!model.MState)
						{
							string error = Validation2(model, shmoney);
							if (!string.IsNullOrEmpty(error))
							{
								return error;
							}
							PCode = "001";//激活升级
							model.MConfig.YJCount += 1;
							DAL.MemberConfig.UpdateConfigTran(model.MID, "YJCount", "1", model, false, SqlDbType.Int, MyHs);
							model.MConfig.JTFHState = true;
							DAL.MemberConfig.UpdateConfigTran(model.MID, "JTFHState", "1", model, true, SqlDbType.Bit, MyHs);
							model.MConfig.DTFHState = true;
							DAL.MemberConfig.UpdateConfigTran(model.MID, "DTFHState", "1", model, true, SqlDbType.Bit, MyHs);
							model.MConfig.UpSumMoney += sjmoney;
							DAL.MemberConfig.UpdateConfigTran(model.MID, "UpSumMoney", sjmoney.ToString(), model, false, SqlDbType.Decimal, MyHs);

							model.RoleCode = "Nomal";
							model.Role = BLL.Roles.RolsList["Nomal"];
							model.MDate = DateTime.Now;
							model.MState = true;
							model.FHState = false;
							model.ValidTime = DateTime.Now;
						}
						if (shmoney != null)
						{
							// 二次升级的奖金按照升级之前的级别拿比例
							model.AgencyCode = shmoney.MAgencyType;
							model.MAgencyType = shmoney;
							//if (model.AgencyCode == "004")
							//{
							//    model.RoleCode = "VIP";
							//}
						}

						DAL.Member.UpdateRole(model, MyHs);
						model.SHMoney += sjmoney;

						Model.Accounts account = new Model.Accounts()
						{
							AccountsDate = DateTime.MaxValue,
							ACode = model.MID + "_" + DateTime.Now.ToString("yyyyMMddHHmmss"),
							CreateDate = DateTime.Now,
							IfAccount = false,
							IsAuto = true,
							PCode = PCode,
							TotalFHMoney = 0,
							FHCount = 0,
							ARemark = model.MID
						};

						BLL.Accounts.BDInsert(account, MyHs);

						if (DAL.CommonBase.RunHashtable(MyHs))
						{
							DAL.Member.tempMemberList.Clear();//清空临时字典
							DAL.BMember.tempBMemberList.Clear();//清空临时字典

							return "恭喜您升级成功，本次消耗" + sjmoney.ToString("F2");
						}
					}
				}
				return "升级失败";
			}
		}

		public static Hashtable UpdateRole(Model.Member member, Hashtable MyHs)
        {
            return DAL.Member.UpdateRole(member, MyHs);
        }

        public static string UpMAgencyType(Model.SHMoney shmoney, string mid, string moneyType, Model.Member shmodel, decimal appendMoney, Hashtable MyHs)
        {
            Model.Member model = DAL.Member.GetModel(mid);
            if (model == null)
                return "升级会员不存在";
            if (string.IsNullOrEmpty(model.MTJ))
                return "请联系管理员设置您的推荐人";
            decimal sjmoney = appendMoney;

            lock (DAL.Member.tempMemberList)
            {
                DAL.Member.tempMemberList.Clear();
                DAL.Member.tempMemberAdd(model);
                DAL.Member._CPList.Clear();
                if (!BLL.ChangeMoney.EnoughChange(shmodel.MID, sjmoney, moneyType))
                    return "您的" + BLL.Reward.List[moneyType].RewardName + "不足";
                if (BLL.ChangeMoney.HBChangeTran(sjmoney, shmodel.MID, ManageMember.TModel.MID, "SH", model, moneyType, model.MAgencyType._MAgencyName + " -> " + shmoney._MAgencyName, MyHs) > 0)
                {
                    model.MConfig.YJMoney += (int)sjmoney;
                    DAL.MemberConfig.UpdateConfigTran(model.MID, "YJMoney", sjmoney.ToString(), model, false, SqlDbType.Int, MyHs);

                    model.SHMoney += (int)sjmoney;
                    string PCode = "005";//升级
                    if (!model.MState)
                    {
                        string error = Validation2(model, shmoney);
                        if (!string.IsNullOrEmpty(error))
                        {
                            return error;
                        }
                        PCode = "001";//激活升级
                        model.MConfig.YJCount += 1;
                        DAL.MemberConfig.UpdateConfigTran(model.MID, "YJCount", "1", model, false, SqlDbType.Int, MyHs);
                        model.MConfig.JTFHState = true;
                        DAL.MemberConfig.UpdateConfigTran(model.MID, "JTFHState", "1", model, true, SqlDbType.Bit, MyHs);
                        model.MConfig.DTFHState = true;
                        DAL.MemberConfig.UpdateConfigTran(model.MID, "DTFHState", "1", model, true, SqlDbType.Bit, MyHs);
                        model.MConfig.UpSumMoney += (int)sjmoney;
                        DAL.MemberConfig.UpdateConfigTran(model.MID, "UpSumMoney", sjmoney.ToString(), model, false, SqlDbType.Int, MyHs);

                        model.RoleCode = "Nomal";
                        model.Role = BLL.Roles.RolsList["Nomal"];
                        model.MDate = DateTime.Now;
                        model.MState = true;
                        model.FHState = false;
                        model.ValidTime = DateTime.Now;
                    }
                    if (shmoney != null)
                    {
                        // 二次升级的奖金按照升级之前的级别拿比例
                        model.AgencyCode = shmoney.MAgencyType;
                        model.MAgencyType = shmoney;
                        if (model.AgencyCode == "004")
                        {
                            model.RoleCode = "VIP";
                        }
                    }

                    DAL.Member.UpdateRole(model, MyHs);

                    Model.Accounts account = new Model.Accounts()
                    {
                        AccountsDate = DateTime.MaxValue,
                        ACode = model.MID + "_" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                        CreateDate = DateTime.Now,
                        IfAccount = false,
                        IsAuto = true,
                        PCode = PCode,
                        TotalFHMoney = 0,
                        FHCount = 0,
                        ARemark = model.MID
                    };

                    BLL.Accounts.BDInsert(account, MyHs);

                    if (DAL.CommonBase.RunHashtable(MyHs))
                    {
                        DAL.Member.tempMemberList.Clear();//清空临时字典
                        DAL.BMember.tempBMemberList.Clear();//清空临时字典
                        DAL.Member._CPList.Clear();

                        return "恭喜您升级成功，本次消耗" + sjmoney.ToString("F2");
                    }
                }
            }
            return "";
        }

        public static bool TestMID(string mid)
        {
            return DAL.Member.TestMID(mid);
        }

        public static bool Insert(Model.Member model)
        {
            return DAL.Member.Insert(model);
        }

        /// <summary>
        /// 推荐人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insert(Model.Member model, bool NeedEmail, ref string retStr)
        {
            if (model.AgencyCode == "001")
            {
                model.MState = false;
                model.RoleCode = BLL.Roles.RolsList["Notactive"].RType;
                model.MBDIndex = 0;
                model.MCreateDate = DateTime.Now;
                model.MDate = DateTime.MaxValue;
                model.MConfig = new Model.MemberConfig
                {
                    MID = model.MID,
                    JJTypeList = DAL.Reward.RewardStr,
                    DTFHState = true,
                    JTFHState = true
                };
            }
            retStr = Validation(model);
            if (retStr != "")
                return false;
            string password = model.Password;
            string secpsd = model.SecPsd;
            if (string.IsNullOrEmpty(model.FMID))
            {
                model.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password + model.Salt, "MD5").ToUpper();
                model.SecPsd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.SecPsd + model.Salt, "MD5").ToUpper();
            }
            if (DAL.Member.Insert(model))
            {
                Model.Member mtjmodel = DAL.Member.GetModel(model.MTJ);

                retStr = "恭喜您注册成功，您的会员账号为：" + model.MID +
                            "，登录密码是：" + password + "，资金密码是：" + secpsd + "！";
                Model.SMS smsmodel = new Model.SMS { MID = model.MID, SContent = retStr, Email = model.Email, SType = Model.SMSType.QT };

                BLL.Task.ManageSend(model, "尊敬的" + model.MID +
                       "会员：恭喜成功注册，为了您的账户安全，请妥善保管您的密码，并且定期在[安全中心]修改密码，为了使您能够享受更多的服务，请及时购币激活账号，您的推荐人QQ号码：" + mtjmodel.QQ + "，手机号码：" + mtjmodel.Tel);

                string emailerr = "";
                if (NeedEmail)
                    BLL.Email.Insert(smsmodel, ref emailerr);

                emailerr = "恭喜您，会员账号" + model.MID + "成功注册为您伞下体验会员，请尽快协助新会员购币激活账号，谢谢合作！";
                BLL.Task.ManageSend(mtjmodel, emailerr);
                smsmodel = new Model.SMS { MID = mtjmodel.MID, SContent = emailerr, Email = mtjmodel.Email, SType = Model.SMSType.QT };
                if (NeedEmail)
                    BLL.Email.Insert(smsmodel, ref emailerr);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 注册会员
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回注册成功之后的会员信息</returns>
        public static Model.Member InsertAndReturnEntity(Model.Member model, int count, bool NeedEmail, ref string retStr)
        {
            string p1 = model.Password;
            string p2 = model.SecPsd;
            Model.Member inserModel = null;
            if (model.AgencyCode == "001")
            {
                model.MState = false;
                model.RoleCode = BLL.Roles.RolsList["Notactive"].RType;
                model.NAgencyCode = "001";
                model.MCreateDate = DateTime.Now;
                model.MDate = DateTime.MaxValue;
                model.FHState = false;
                model.MConfig = new Model.MemberConfig
                {
                    MID = model.MID,
                    JJTypeList = DAL.Reward.RewardStr,
                    DTFHState = true,
                    JTFHState = true,
                    TXStatus = true,
                    ZZStatus = true,
                    GQCount = count,
                    HLGQCount = count,
                    TJFloat = 0
                };
            }
            //model.Country = GetArea(model.Province);
            retStr = Validation(model);
            if (retStr != "")
                return inserModel;
            string password = model.Password;
            //string secpsd = model.SecPsd;
            //if (string.IsNullOrEmpty(model.FMID))
            {
                model.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password + model.Salt, "MD5").ToUpper();
                //model.SecPsd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.SecPsd + model.Salt, "MD5").ToUpper();
            }
            if (DAL.Member.Insert(model))
            {
                inserModel = DAL.Member.GetModel(model.MID);
            }
            else
            {
                retStr = "注册失败";
            }
            return inserModel;
        }

        /// <summary>
        /// 注册会员
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回注册成功之后的会员信息</returns>
        public static Model.Member InsertAndReturnEntityft(Model.Member model, int count, bool NeedEmail, ref string retStr)
        {
            string p1 = model.Password;
            string p2 = model.SecPsd;
            Model.Member inserModel = null;
            if (model.AgencyCode == "001")
            {
                model.MState = false;
                model.RoleCode = BLL.Roles.RolsList["Notactive"].RType;
                model.NAgencyCode = "001";
                model.MCreateDate = DateTime.Now;
                model.MDate = DateTime.MaxValue;
                model.FHState = false;
                model.MConfig = new Model.MemberConfig
                {
                    MID = model.MID,
                    JJTypeList = DAL.Reward.RewardStr,
                    DTFHState = true,
                    JTFHState = true,
                    TXStatus = true,
                    ZZStatus = true,
                    GQCount = count,
                    HLGQCount = count,
                    TJFloat = 0
                };
            }
            //model.Country = GetArea(model.Province);
            retStr = Validation(model, false);
            if (retStr != "")
                return inserModel;
            string password = model.Password;
            //string secpsd = model.SecPsd;
            //if (string.IsNullOrEmpty(model.FMID))
            {
                model.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password + model.Salt, "MD5").ToUpper();
                //model.SecPsd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.SecPsd + model.Salt, "MD5").ToUpper();
            }
            if (DAL.Member.Insert(model))
            {
                inserModel = DAL.Member.GetModel(model.MID);
            }
            else
            {
                retStr = "注册失败";
            }
            return inserModel;
        }


        private static string GetArea(string pr)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("华东区", "上海市,山东省,江苏省,浙江省,安徽省,福建省");//0
            dic.Add("华南区", "广东省,广西省,湖南省,湖北省,江西省,海南省");//1
            dic.Add("华西区", "重庆市,四川省,云南省,贵州省,青海省,新疆省,西藏省");//2
            dic.Add("华北区", "天津市,黑龙江省,辽宁省,吉林省,内蒙古,宁夏省");//3
            dic.Add("华中区", "河北省,河南省,陕西省,山西省,北京市,甘肃省");//4
            dic.Add("港澳台", "香港,澳门,台湾省");
            foreach (string key in dic.Keys)
            {
                if (dic[key].Contains(pr))
                {
                    return key;
                }
            }

            return "";
        }

        /// <summary>
        /// 得到会员的累记提现申请总额
        /// </summary>
        /// <param name="Mid"></param>
        /// <returns></returns>
        public int GetAllTX()
        {
            return DAL.ChangeMoney.GetAllTx(TModel.MID);
        }

        /// <summary>
        /// 得到会员对象
        /// </summary>
        /// <param name="MID"></param>
        /// <returns></returns>
        public Model.Member GetModel(string MID)
        {
            return DAL.Member.GetModel(MID);
        }

        /// <summary>
        /// 得到会员对象
        /// </summary>
        /// <param name="MID"></param>
        /// <returns></returns>
        public static Model.Member GetModelByMID(string MID)
        {
            return DAL.Member.GetModel(MID);
        }

        /// <summary>
        /// 得到个人信息
        /// </summary>
        /// <returns></returns>
        public Model.Member GetSelf()
        {
            if (TModel == null)
                return null;
            Model.Member model = DAL.Member.GetModel(TModel.MID);
            if (model != null && !model.Role.Super)
            {
                if (string.IsNullOrEmpty(model.TempThrPsd) || model.ThrPsd != model.TempThrPsd)
                {
                    if (!model.IsClose)
                    {
                        model.IsClose = true;
                        MemberClose(model);
                        string Msg = "会员：" + model.MID + "于当前时间[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]账号异常，已锁定，未冻结";
                        Model.SMS smsmodel = new Model.SMS { SType = Model.SMSType.ZCYZ, Tel = BLL.WebBase.Model.MonitorTel, SContent = Msg };
                        string error = "";
                        if (BLL.SMS.Insert(smsmodel, ref error))
                        {
                            Msg += "[已发送您手机]";
                        }
                        Task.SendManage(model, "001", Msg);

                    }
                    return null;
                }

            }
            return model;
        }
        #region 会员集合查询
        /// <summary>
        /// 得到会员实体列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<Model.Member> GetMemberEntityList(string strWhere)
        {
            return DAL.MemberCollection.GetMemberEntityList(strWhere);
        }
        /// <summary>
        /// 得到会员实体列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<Model.Member> GetMemberAndConfigEntityList(string strWhere)
        {
            return DAL.MemberCollection.GetMemberAndConfigEntityList(strWhere);
        }


        /// <summary>
        /// 得到分页会员信息实体列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="count">out类型总计</param>
        /// <returns>返回会员List集合</returns>
        public List<Model.Member> GetMemberEntityList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.MemberCollection.GetMemberEntityList(strWhere, pageIndex, pageSize, out count);
        }

        #endregion


        #region 会员权限查询及验证

        /// <summary>
        /// 验证权限
        /// </summary>
        /// <returns></returns>
        public bool VerifyUrl(string url)
        {
            return BLL.Roles.VerifyUrl(TModel.RoleCode, url.ToUpper());
        }

        /// <summary>
        /// 得到权限资源实体列表
        /// </summary>
        /// <returns></returns>
        public static bool VerifyPower(System.Web.HttpContext context, BLL.Member model)
        {
            if (model != null && model is BLL.Member)
            {
                return BLL.Roles.VerifyPower(model.TModel, context.Request.Url.AbsolutePath.ToUpper());
            }
            return false;
        }

        public List<Model.Notice> GetNoticeEntityList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.Notice.GetNoticeEntityList(strWhere, pageIndex, pageSize, out count);
        }

        #endregion

        #region 会员奖金及附属信息查询

        /// <summary>
        /// 得到提现实体列表
        /// </summary>
        /// <returns></returns>
        public List<Model.ChangeMoney> GetChangeMoneyEntityList(string frommid, string tomid, string shmid, string state, List<string> TypeList, List<string> mType, int pageIndex, int pageSize, string strWhere, out int count)
        {
            return DAL.ChangeMoneyCollection.GetChangeMoneyEntityList(frommid, tomid, shmid, state, TypeList, mType, pageIndex, pageSize, strWhere, out count);
        }

        /// <summary>
        /// 奖金信息
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public Dictionary<string, decimal> GetJJInfo(string mid, List<string> ChangeTypeList, List<string> NeedTakeOff, string startDate, string endDate)
        {
            return DAL.ChangeMoney.GetJJInfo(mid, ChangeTypeList, NeedTakeOff, startDate, endDate);
        }

        /// <summary>
        /// 会员直绑定数
        /// </summary>
        /// <param name="MBD"></param>
        /// <returns></returns>
        public static int GetMBDCount(string MBD, bool MState)
        {
            return DAL.Member.GetBDCount(MBD, MState);
        }

        #endregion

        /// <summary>
        /// 服务中心
        /// </summary>
        /// <param name="shmid">待服务中心ID</param>
        /// <returns></returns>
        public string SHMember(string shmid)
        {
            return BLL.ChangeMoney.SHMember(TModel, shmid);
        }

        public static string GetTestMID()
        {
            Random rand = new Random();
            string mid = "pp" + rand.Next(100000, 999999).ToString();
            while (DAL.Member.TestMID(mid))
            {
                mid = "pp" + rand.Next(100000, 999999).ToString();
            }
            return mid;
        }

        public static string GetTestMID2(int i)
        {
            Random rand = new Random(i);
            string mid = "" + rand.Next(10000000, 99999999).ToString();
            while (DAL.Member.TestMID(mid))
            {
                mid = "" + rand.Next(10000000, 99999999).ToString();
            }
            return mid;
        }

        public List<Model.Task> GetTaskEntityList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.Task.GetTaskEntityList(strWhere, pageIndex, pageSize, out count);
        }

        public string HideTask(string idlist)
        {
            if (DAL.Task.HideTask(idlist))
                return "操作成功";
            return "操作失败";
        }

        public string ShowTask(string idlist)
        {
            if (DAL.Task.ShowTask(idlist))
                return "操作成功";
            return "操作失败";
        }
        public string ReadTask(string idlist)
        {
            if (DAL.Task.ReadTask(idlist))
                return "操作成功";
            return "操作失败";
        }
        public string NoReadTask(string idlist)
        {
            if (DAL.Task.NoReadTask(idlist))
                return "操作成功";
            return "操作失败";
        }

        /// <summary>
        /// 服务中心提现
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public string ShTx(string cidList)
        {
            return ChangeMoney.ShTx(cidList);
        }

        /// <summary>
        /// 服务中心提现
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public string SHAllTX()
        {
            return ChangeMoney.SHAllTX();
        }

        /// <summary>
        /// 拒绝提现
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public string Cancel_TX(string cidList, Model.Member member)
        {
            return ChangeMoney.Cancel_TX(cidList, member);
        }

        /// <summary>
        /// 删除会员
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public string DeleteMember(string midList)
        {
            if (TModel.Role.Super)
                return DAL.Member.DeleteMember(midList);
            return "操作失败";
        }

        /// <summary>
        /// 删除会员
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public string DeleteMemberW(string midList)
        {
            return DAL.Member.DeleteMemberW(midList, this.TModel);
        }

        /// <summary>
        /// 修改配置信息
        /// </summary>
        /// <param name="ConfigurationModel"></param>
        /// <returns></returns>
        public bool UpdateConfiguration(yny_004.Model.Configuration ConfigurationModel)
        {
            return DAL.Configuration._Update(ConfigurationModel);
        }

        /// <summary>
        /// 初始化系统
        /// </summary>
        /// <returns></returns>
        public bool ReSetSys()
        {
            return DAL.Member.ReSetSys(TModel);
        }

        public string HideNotice(string IDList)
        {
            if (DAL.Notice.HideNotice(IDList))
                return "操作成功";
            return "操作失败";
        }

        public object ShowNotice(string IDList)
        {
            if (DAL.Notice.ShowNotice(IDList))
                return "操作成功";
            return "操作失败";
        }

        public object DeleteNotice(string IDList)
        {
            if (DAL.Notice.DeleteNotice(IDList))
                return "操作成功";
            return "操作失败";
        }

        //public string FH(Model.FHList fhModel, bool isInsert)
        //{
        //    DAl.Member.tempMemberList.Clear();
        //    lock (DAl.Member.tempMemberList)
        //    {
        //        return BLL.ChangeMoney.FHChangeTran(fhModel, isInsert);
        //    }
        //}
        public string Del_ChangeMoney(string cidlist)
        {
            if (DAL.ChangeMoney.Delete(cidlist))
                return "删除成功";
            return "删除失败";
        }

        public string DeleteTask(string idlist)
        {
            if (DAL.Task.DeleteTask(idlist))
                return "操作成功";
            return "操作失败";
        }

        public string SetVerify(string cidList, string mType)
        {
            if (DAL.Roles.SetVerify(cidList, mType))
            {
                DAL.Roles.RolsList = null;
                return "操作成功";
            }
            return "操作失败";
        }

        /// <summary>
        /// 自动排列
        /// </summary>
        /// <returns></returns>
        public static string GetMBD(string mtjmid)
        {
            return DAL.Member.GetMBD(mtjmid, BLL.Configuration.Model.B_BDCount);
        }

        public List<Model.BankModel> GetMyBankInfo()
        {
            return BLL.BankModel.GetList(string.Format(" MID='{0}' order by IsPrimary desc,BankCreateDate asc ", this.TModel.MID));
        }

        public string SHHKModel(string hkCodeStr)
        {
            string[] hkCodeList = hkCodeStr.Split(',');
            Hashtable MyHs = new Hashtable();
            Dictionary<Model.Member, decimal> midlist = new Dictionary<Model.Member, decimal>();
            foreach (string hkcode in hkCodeList)
            {
                Model.HKModel model = BLL.HKModel.GetModel(hkcode);
                if (model == null)
                    continue;
                if (!model.HKState)
                {
                    Model.Member member = DAL.Member.GetModel(model.MID);
                    model.HKState = true;
                    model.HKDate = DateTime.Now;
                    //model.ValidMoney = model.RealMoney / BLL.Configuration.Model.B_InFloat;
                    if (model.HKType == 1)//如果是激活且未激活
                    {
                        BLL.ChangeMoney.HBChangeTran(model.ValidMoney, BLL.Member.ManageMember.TModel.MID, model.MID, "HKSH", null, "MHB", "汇款审核" + model.HKCode, MyHs);
                    }
                    else
                    {
                        //BLL.Task.ManageSend(member, "尊敬的会员：" + model.MID + ",非常抱歉，您本次充值报单币" + model.ValidMoney + "充值失败！");
                        continue;
                    }
                    BLL.HKModel.Update(model, MyHs);
                    midlist.Add(member, model.ValidMoney);
                }
            }

            if (DAL.CommonBase.RunHashtable(MyHs))
            {
                foreach (KeyValuePair<Model.Member, decimal> mid in midlist)
                {
                    BLL.Task.SendManage(mid.Key, "001", "会员于当前时间向公司汇款人民币：" + mid.Value.ToString());
                    BLL.Task.ManageSend(mid.Key, "尊敬的会员：" + mid.Key.MID + ",您的汇款记录已于当前时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "成功审核，请及时查看您的账户信息，如有疑问，请联系客服");
                }
                return "操作成功";
            }
            else
            {
                return "操作失败";
            }
        }

        private List<string> guidlist = new List<string>();
        private string GetGUID()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", "").Replace(" ", "").ToUpper().Substring(0, 15);
            if (guidlist.Contains(guid))
                guid = GetGUID();
            return guid;
        }

        /// <summary>
        /// 处理交易结果
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool SHPayHBIPS(string code)
        {
            Model.HKModel model = BLL.HKModel.GetModel(code);
            if (model == null)
                return false;
            if (!model.HKState)
            {
                guidlist.Clear();
                Hashtable MyHs = new Hashtable();
                Model.Member member = DAL.Member.GetModel(model.MID);
                model.HKState = true;
                model.HKDate = DateTime.Now;
                BLL.HKModel.Update(model, MyHs);
                //充值MJB
                BLL.ChangeMoney.HBChangeTran(model.RealMoney, BLL.Member.ManageMember.TModel.MID, model.MID, "CZ", member, "MJB", "在线充值", MyHs);

                //if (model.Remark[0] == '0')
                //{
                //    BuyActiveCode(model, MyHs);
                //}
                //else
                //{
                //    BuyMMM(model, MyHs);
                //}

                if (BLL.CommonBase.RunHashtable(MyHs))
                {
                    return true;
                }
            }
            return false;
        }

        public bool SHPayHB(string code)
        {
            Model.HKModel model = BLL.HKModel.GetModel(code);
            if (model == null)
                return false;
            if (!model.HKState)
            {
                Hashtable MyHs = new Hashtable();
                //Model.Member member = DAl.Member.GetModel(model.MID);
                model.HKState = true;
                model.HKDate = DateTime.Now;
                model.ValidMoney = model.RealMoney / BLL.Configuration.Model.B_InFloat;
                if (model.HKType == 1)//如果是激活且未激活
                {
                    BLL.ChangeMoney.CZMoneyChange(BLL.Member.ManageMember.TModel.MID, model.MID, model.ValidMoney, "MJB", MyHs);
                    //DAl.ChangeMoney.TranChangeTran("", member.MID, model.ValidMoney, "MJB", MyHs);
                }
                BLL.HKModel.Update(model, MyHs);

                return BLL.CommonBase.RunHashtable(MyHs);
            }
            return false;
        }

        public string DeleteHKModel(string hkCodeStr)
        {
            hkCodeStr = hkCodeStr.Replace(",", "','"); ;
            Hashtable MyHs = new Hashtable();
            BLL.HKModel.Delete("'" + hkCodeStr + "'", MyHs);
            if (DAL.CommonBase.RunHashtable(MyHs))
                return "操作成功";
            return "操作失败";
        }

        public static string Validation(Model.Member shmodel,bool istel=true)
        {
            //if (DAL.Member.GetNumIDCount(shmodel.BankNumber, "BankNumber") >= 1)
            //{
            //    return "一个银行卡号只能注册1单";
            //}
            if (istel)
            {
                if (DAL.Member.GetNumIDCount(shmodel.Tel, "Tel") >= BLL.Configuration.Model.E_BbinMaxCount)
                {
                    return "一个手机号只能注册1单";
                }
            }
            
            //if (DAL.Member.GetNumIDCount(shmodel.MName, "MName") >= 1)
            //{
            //    return "一个会员姓名只能注册1单";
            //}
            //if (DAL.Member.GetNumIDCount(shmodel.MName, "MName") >= 1)
            //{
            //    return "一个会员姓名只能注册1单";
            //}
            if (DAL.Member.GetModel(shmodel.MID) != null)
            {
                return "已存在该ID会员";
            }
            //if (!DAL.CommonBase.TestSql(shmodel.MID))
            //{
            //    return "会员ID不合法，请重新填写";
            //}
            //if (string.IsNullOrEmpty(shmodel.MSH))
            //{
            //    shmodel.MSH = BLL.Agents.GetLeader(shmodel);
            //}
            Model.Member MTJ = DAL.Member.GetModel(shmodel.MTJ);
            //Model.Member MBD = DAL.Member.GetModel(shmodel.MBD);
            //Model.Member MSH = DAL.Member.GetModel(shmodel.MSH);
            if (MTJ == null)
            {
                return "推荐人不存在";
            }
            if (!string.IsNullOrEmpty(MTJ.FMID))
            {
                return "此会员不能当推荐人";
            }
            //if (MSH == null || !MSH.MState || !MSH.Role.CanSH)
            //{
            //    return "不存在该报单中心或其没有审核权限";
            //}
            //if (MBD == null || !MBD.MState)
            //{
            //    return "不存在该接点人";
            //}
            //if (!DAL.Member.CanMBD(shmodel))
            //{
            //    return "该位置已被占用,请更换位置";
            //}

            return "";
        }

        public static bool GetSHModel(string mbd, string msh)
        {
            if (mbd == msh)
            {
                return true;
            }
            Model.Member model = DAL.Member.GetModel(mbd);
            if (model == null || model.Role.Super)
            {
                return false;
            }
            else
            {
                return GetSHModel(model.MBD, msh);
            }
        }

        public static string Validation2(Model.Member shmodel, Model.SHMoney sh = null)
        {
            //if (shmodel.MState)
            //    return "该会员已被激活";

            Model.Member MTJ = DAL.Member.GetModel(shmodel.MTJ);
            //Model.Member MSH = DAL.Member.GetModel(shmodel.MSH);
            Model.Member MBD = DAL.Member.GetModel(shmodel.MBD);

            if (MTJ == null || (!MTJ.MState && MTJ.AgencyCode != "001"))
            {
                return "不存在该推荐人";
            }
            shmodel.MBD = DAL.Member.GetMBD2(BLL.Member.ManageMember.TModel.MID, 3);
            int count = DAL.Member.GetBDCount(shmodel.MBD, true);
            shmodel.MBDIndex = count + 1;

            return "";
        }
        public static string GetMBD2(string mtjmid)
        {
            return DAL.Member.GetMBD2(mtjmid, DAL.Configuration.TModel.B_BDCount);
        }

        public bool MemberHBClear()
        {
            bool result = DAL.Member.MemberHBClear();
            return result;
        }

        public bool MemberHBToJB()
        {
            return DAL.Member.MemberHBToJB();
        }

        public DataTable GetPowers(string strWhere, string mType)
        {
            return DAL.Roles.GetPowers(strWhere, mType);
        }

        public string GrantVerify(string cidList, string mType)
        {
            return DAL.Roles.GrantPowers(cidList, mType);
        }

        public static decimal GetTypeSumJJ(string mid, string type, DateTime day)
        {
            return DAL.Member.GetTypeSumJJ(mid, type, day);
        }

        public object DeleteGoogs(string goodsCodeStr)
        {
            if (BLL.Goods.Delete("'" + goodsCodeStr + "'"))
                return "操作成功";
            return "操作失败";
        }

        public object SendOrder(string strList)
        {
            Hashtable MyHs = new Hashtable();
            foreach (string str in strList.Split(','))
            {
                //Model.GoodsOrder order = BLL.GoodsOrder.GetModel(str);
                //order.SendDate = DateTime.Now;
                //order.IfSendGoods = true;
                //BLL.GoodsOrder.Update(order, MyHs);
            }
            if (BLL.CommonBase.RunHashtable(MyHs))
                return "操作成功";
            return "操作失败";
        }

        public static string Accounts(string CodeList)
        {
            int success = 0, fail = 0;
            foreach (string str in CodeList.Split(','))
            {
                Model.Accounts account = DAL.Accounts.GetModel(str);
                if (!account.IfAccount)
                {
                    Hashtable MyHs = new Hashtable();
                    account.IsAuto = false;
                    BLL.Accounts.Update(account, MyHs);
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

        public int GetLevelForView(string mid, bool viewType)
        {
            return DAL.Member.GetLevelForView(this.TModel, mid, viewType);
        }

        public List<Model.ChangeMoney> GetChangeMoneyEntityList(string StrWhere)
        {
            return DAL.ChangeMoneyCollection.GetChangeMoneyEntityList(StrWhere);
        }

        /// <summary>
        /// 得到提现实体列表
        /// </summary>
        /// <returns></returns>
        public List<Model.ChangeMoney> GetChangeMoneyEntityList(string frommid, string tomid, string shmid, string state, List<string> TypeList, List<string> mType, string strWhere)
        {
            return DAL.ChangeMoneyCollection.GetChangeMoneyEntityList(frommid, tomid, shmid, state, TypeList, mType, strWhere);
        }

        public List<Model.ChangeMoney> GetChangeMoneyEntityList(int top, string StrWhere)
        {
            return DAL.ChangeMoneyCollection.GetChangeMoneyEntityList(top, StrWhere);
        }

        public List<Model.ChangeMoney> GetTopChangeMoneyEntityList(int top, string StrWhere)
        {
            return DAL.ChangeMoneyCollection.GetTopChangeMoneyEntityList(top, StrWhere);
        }

        public Hashtable UpdateBankInfo(Model.Member model, Hashtable MyHs)
        {
            return DAL.Member.UpdateBankInfo(model, MyHs);
        }

        public string Recover(string mids)
        {
            string[] midlist = mids.Split(',');
            Hashtable MyHs = new Hashtable();
            foreach (string item in midlist)
            {
                Model.Member model = DAL.Member.GetModel(item);
                if (model != null && model.FMID == this.TModel.MID)
                {
                    model.Password = this.TModel.Password;
                    model.SecPsd = this.TModel.SecPsd;
                    model.Salt = this.TModel.Salt;
                    DAL.Member.Update(model, MyHs);
                }
            }
            if (BLL.CommonBase.RunHashtable(MyHs))
                return "恢复成功";
            return "恢复失败";
        }

        public static Hashtable UpdateConfigTran(string mid, string fieldName, string fieldValue, Model.Member shmodel, bool isEqual, SqlDbType dataType, Hashtable MyHs)
        {
            return DAL.MemberConfig.UpdateConfigTran(mid, fieldName, fieldValue, shmodel, isEqual, dataType, MyHs);
        }

        public static bool ChangeMemberRole(Model.Member model)
        {
            Hashtable MyHs = new Hashtable();
            //BLL.ChangeMoney.CZMoneyChange(BLL.Member.ManageMember.TModel.MID, model.MID, 5100, "MJB", MyHs);
            MyHs.Add("update member set RoleCode='" + model.RoleCode + "' where mid='" + model.MID + "'", null);
            return BLL.CommonBase.RunHashtable(MyHs);
        }

        public static List<Model.Member> GetJTFHMembers(string shmid, string lastmid, int count)
        {
            List<Model.Member> members = new List<Model.Member>();
            members = DAL.Member.GetJTFHMembers(shmid, lastmid, count);
            return members;
        }

        public static decimal GetSum(string filed, string strWhere)
        {
            string strSql = string.Format(" select SUM({0}) from memberconfig where MID in (select MID from member where {1}) ", filed, strWhere);

            object obj = BLL.CommonBase.GetSingle(strSql);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }

        public static int GetNewMember(Model.Member model)
        {
            string strSql = " select count(1) from member where MTJ = '" + model.MID + "' and DATEDIFF(day,MCreateDate,getdate()) = 0 and RoleCode not in ('Activation','Manage') ";
            if (model.Role.Super)
            {
                strSql = " select count(1) from member where DATEDIFF(day,MCreateDate,getdate()) = 0 and RoleCode not in ('Activation','Manage')  ";
            }

            object obj = BLL.CommonBase.GetSingle(strSql);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 获取会员人数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static int GetMemberCount(string strWhere)
        {
            return DAL.Member.GetMemberCount(strWhere);
        }

        public static Model.SHMoney GetSHMoneyByMoney(int money)
        {
            if (money <= 0)
            {
                return null;
            }
            return DAL.SHMoney.GetSHMoneyList().Where(emp => emp.Money == money).FirstOrDefault();
        }

        public static Model.Member GetParentVIP(string mid)
        {
            return DAL.Member.GetParentVIP(mid);
        }

        public static bool CanMBD(Model.Member member)
        {
            return DAL.Member.CanMBD(member);
        }

        # region zx_242

        /// <summary>
        /// 根据省市县获取上级领导
        /// </summary>
        public static string GetLeader(Model.Member member)
        {
            //是否有县区领导
            Model.Member leader = DAL.Member.GetModelList(GetLeaderCondition(member, 4)).FirstOrDefault();
            //县级代理
            if (leader != null)
            {
                return leader.MID;
            }
            leader = DAL.Member.GetModelList(GetLeaderCondition(member, 3)).FirstOrDefault();
            //市级代理
            if (leader != null)
            {
                return leader.MID;
            }
            leader = DAL.Member.GetModelList(GetLeaderCondition(member, 2)).FirstOrDefault();
            //省级代理
            if (leader != null)
            {
                return leader.MID;
            }
            leader = DAL.Member.GetModelList(GetLeaderCondition(member, 1)).FirstOrDefault();
            //大区代理
            if (leader != null)
            {
                return leader.MID;
            }
            return DAL.Member.ManageMember.MID;
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <param name="level">1:大区;2:省;3:市;4:县</param>
        private static string GetLeaderCondition(Model.Member member, int level, bool needCode = true)
        {
            string strWhere = " 1 = 1 ";
            string strrole = "";
            if (level > 0)//大区
            {
                strWhere += string.Format(" and Country = '{0}' ", member.Country);
                strrole = " and RoleCode = 'VIP4' ";
            }
            if (level > 1)//省
            {
                strWhere += string.Format(" and Province = '{0}' ", member.Province);
                strrole = " and RoleCode = 'VIP3' ";
            }
            if (level > 2)//市
            {
                strWhere += string.Format(" and City = '{0}' ", member.City);
                strrole = " and RoleCode = 'VIP2' ";
            }
            if (level > 3)//县
            {
                strWhere += string.Format(" and Zone = '{0}' ", member.Zone);
                strrole = " and RoleCode = 'VIP1' ";
            }
            if (needCode)
            {
                return strWhere + strrole;
            }
            else
            {
                return strWhere + " and RoleCode in ('Nomal','Notactive') ";
            }
        }

        public static string GetLeaderCondition(Model.Member member)
        {
            switch (member.RoleCode)
            {
                case "VIP1":
                    return GetLeaderCondition(member, 4, false);
                case "VIP2":
                    return GetLeaderCondition(member, 3, false);
                case "VIP3":
                    return GetLeaderCondition(member, 2, false);
                case "VIP4":
                    return GetLeaderCondition(member, 1, false);
            }
            return " 1 = 0";
        }

        /// <summary>
        /// 是否可以设置成为代理
        /// </summary>
        /// <returns>返回空为可以</returns>
        public static string CanSetAgency(Model.Member member)
        {
            Model.Member leader = null;
            switch (member.RoleCode)
            {
                case "VIP1":
                    leader = DAL.Member.GetModelList(GetLeaderCondition(member, 4)).FirstOrDefault();
                    if (leader != null && leader.MID != member.MID)
                    {
                        return "当前县已存在[县级合伙公司],不能重复设置";
                    }
                    leader = DAL.Member.GetModelList(GetLeaderCondition(member, 3)).FirstOrDefault();
                    if (leader == null)
                    {
                        return "当前市不存在[市级合伙公司],请先设置[市级合伙公司]";
                    }
                    break;
                case "VIP2":
                    leader = DAL.Member.GetModelList(GetLeaderCondition(member, 3)).FirstOrDefault();
                    if (leader != null && leader.MID != member.MID)
                    {
                        return "当前市已存在[市级合伙公司],不能重复设置";
                    }
                    leader = DAL.Member.GetModelList(GetLeaderCondition(member, 2)).FirstOrDefault();
                    if (leader == null)
                    {
                        return "当前省不存在[省级合伙公司],请先设置[省级合伙公司]";
                    }
                    break;
                case "VIP3":
                    leader = DAL.Member.GetModelList(GetLeaderCondition(member, 2)).FirstOrDefault();
                    if (leader != null && leader.MID != member.MID)
                    {
                        return "当前省已存在[省级合伙公司],不能重复设置";
                    }
                    leader = DAL.Member.GetModelList(GetLeaderCondition(member, 1)).FirstOrDefault();
                    if (leader == null)
                    {
                        return "当前大区不存在[大区合伙公司],请先设置[大区合伙公司]";
                    }
                    break;
                case "VIP4":
                    leader = DAL.Member.GetModelList(GetLeaderCondition(member, 1)).FirstOrDefault();
                    if (leader != null && leader.MID != member.MID)
                    {
                        return "当前大区已存在[大区合伙公司],不能重复设置";
                    }
                    break;
            }
            return "";
        }

        # endregion zx_242
    }
}