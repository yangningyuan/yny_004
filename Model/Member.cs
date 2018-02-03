using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    public class Member
    {
        public static string MD5 = "SUBSTRING(sys.fn_VarBinToHexStr(hashbytes('MD5', replace(isnull(MID,'')+isnull(Tel,'')+isnull(Email,'')+isnull(Bank,'')+isnull(Branch,'')+isnull(BankNumber,'')+isnull(BankCardName,'')+isnull(Password,'')+isnull(SecPsd,'')+isnull(Salt,''),' ',''))),3,32) ";
        public static string UpThrPsd = "; update member set ThrPsd= " + MD5;

        #region 会员基本资料
        /// <summary>
        /// 充值ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 会员账号
        /// </summary>
        public string MID { get; set; }
        /// <summary>
        /// 会员账号
        /// </summary>
        public string FMID { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string MName { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 县区
        /// </summary>
        public string Zone { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 发货地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 开户银行
        /// </summary>
        public string Bank { get; set; }
        /// <summary>
        /// 开户支行
        /// </summary>
        public string Branch { get; set; }
        /// <summary>
        /// 银行卡号
        /// </summary>
        public string BankNumber { get; set; }
        /// <summary>
        /// 银行卡户主
        /// </summary>
        public string BankCardName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 资金密码
        /// </summary>
        public string SecPsd { get; set; }
        /// <summary>
        /// 较验码
        /// </summary>
        public string ThrPsd { get; set; }
        /// <summary>
        /// 核对较验码
        /// </summary>
        public string TempThrPsd { get; set; }
        /// <summary>
        /// 推荐人编号
        /// </summary>
        public string MTJ { get; set; }
        /// <summary>
        /// 审核人编号
        /// </summary>
        public string MSH { get; set; }
        /// <summary>
        /// 接点人
        /// </summary>
        public string MBD { get; set; }
        /// <summary>
        /// 安置点位：1（左），2（中），3（右）
        /// </summary>
        public int MBDIndex { get; set; }
        /// <summary>
        /// A区B区C区
        /// </summary>
        public string MBDIndexStr
        {
            get
            {
                return MBDIndex + "区";
            }
        }
        /// <summary>
        /// 报单日期
        /// </summary>
        public DateTime MDate { get; set; }
        /// <summary>
        /// 注册日期
        /// </summary>
        public DateTime MCreateDate { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        public bool MState { get; set; }
        /// <summary>
        /// 账户锁定
        /// </summary>
        public bool IsClose { get; set; }
        /// <summary>
        /// 账户冻结
        /// </summary>
        public bool IsClock { get; set; }
        /// <summary>
        /// 冻结资金
        /// </summary>
        public int MHBFreeze { get; set; }
        /// <summary>
        /// 预激活费用
        /// </summary>
        public int SHMoney { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string NumID { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string Salt { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        public string QQ { get; set; }

        public string Alipay { get; set; }

        public string WeChat { get; set; }
        #endregion

        /// <summary>
        /// 会员角色
        /// </summary>
        public string RoleCode { get; set; }
        public Model.Roles Role = new Roles();

        /// <summary>
        /// 会员代理级别
        /// </summary>
        public string AgencyCode { get; set; }
        public Model.SHMoney MAgencyType = new SHMoney();
        /// <summary>
        /// 注册等级
        /// </summary>
        public string RegistAgency { get; set; }

        /// <summary>
        /// 会员配置信息
        /// </summary>
        public MemberConfig MConfig { get; set; }

        public bool IsNewMemberSH { get; set; }

        public List<Model.BMember> BMemberList = new List<BMember>();

        public List<Model.Member> MemberList = new List<Member>();

        /// <summary>
        /// 备注说明
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; }

        public string NAgencyCode { get; set; }
        public Model.NewSHMoney NewSHMoney = new NewSHMoney();
        /// <summary>
        /// 分红状态
        /// </summary>
        public bool FHState { get; set; }
        /// <summary>
        /// 有效时间
        /// </summary>
        public DateTime? ValidTime { get; set; }

        /// <summary>
        /// 二维码路径
        /// </summary>
        public string QRCode { get; set; }
    }

}
