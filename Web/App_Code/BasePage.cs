using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace yny_004.Web
{
    public class BasePage : BasePageNoLogin
    {
        public static readonly JavaScriptSerializer jss = new JavaScriptSerializer();

        //protected Model.Member TModel;
        //protected BLL.Member BllModel
        //{
        //    get
        //    {
        //        if (Session["Member"] == null)
        //        {
        //            if (!string.IsNullOrEmpty(User.Identity.Name))
        //            {
        //                Model.Member model = BLL.Member.ManageMember.GetModel(User.Identity.Name);
        //                if (model != null)
        //                {
        //                    Session["Member"] = new BLL.Member { TModel = model };
        //                }
        //            }
        //        }
        //        BLL.Member bllmodel = (Session["Member"] as BLL.Member);
        //        if (bllmodel != null)
        //        {
        //            bllmodel.TModel = bllmodel.GetSelf();
        //            if (bllmodel.TModel == null)
        //                bllmodel = null;
        //            else
        //                TModel = bllmodel.TModel;
        //        }
        //        Session["Member"] = bllmodel;
        //        return bllmodel;
        //    }
        //    set
        //    {
        //        Session["Member"] = value;
        //    }
        //}
        public int CurrentPage
        {
            get
            {
                try
                {
                    return Convert.ToInt32(Request["CurrentPage"]);
                }
                catch (Exception)
                {
                    return 1;
                }
            }
        }

        /// <summary>
        /// 每页显示多少条数据
        /// </summary>
        public int ItemsPerPage
        {
            get
            {
                try
                {
                    return Convert.ToInt32(Request["ItemsPerPage"]);
                }
                catch (Exception)
                {
                    return 1;
                }
            }
        }
        public string GetPromoteLink()
        {
            //int mbdIndex;
            //var mbd = MemberBLL.GetSuitableLocation(TModel.MID, out mbdIndex);
            return string.Format("{0}?mid={1}", HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, "/Regedit/Index.aspx"), TModel.MID);
        }
        public string GetPromoteLinkTel()
        {
            //int mbdIndex;
            //var mbd = MemberBLL.GetSuitableLocation(TModel.MID, out mbdIndex);
            return string.Format("{0}?mid={1}", HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, "/mobile/html/Register.aspx"), TModel.MID);
        }
        /// <summary>
        /// 获取逻辑上登陆的用户是否是管理员
        /// </summary>
        public bool IsAdmin
        {
            get
            {
                return TModel.Role.IsAdmin;
            }
        }

        /// <summary>
        /// 实际登陆的用户是否是管理员
        /// </summary>
        public bool ActualUserIsAdmin
        {
            get
            {
                return ActualTModel.Role.IsAdmin;
            }
        }

        private Model.Member _actualTModel;

        /// <summary>
        /// 实际上当前登陆的用户
        /// </summary>
        protected Model.Member ActualTModel
        {
            get
            {
                if (_actualTModel == null)
                {
                    _actualTModel = BLL.Member.GetModelByMID(CurrentUserName);
                }

                return _actualTModel;
            }
        }

        private static readonly string LoggedInFlag = "LoggedInMID";

        private Model.Member _tModel;

        private static readonly Regex loggedInUserRegex = new Regex("LoggedInMID=(?<MID>[^&]+)&*");


        private string _loggedInMID;

        /// <summary>
        /// 在参数中指定的当前登陆的用户的账号
        /// </summary>
        protected string LoggedInMID
        {
            get
            {
                if (_loggedInMID == null)
                {
                    var request = HttpContext.Current.Request;
                    var referer = request.Headers["Referer"];
                    if (string.IsNullOrEmpty(referer))
                    {
                        _loggedInMID = string.Empty;
                    }
                    else
                    {
                        var matchResult = loggedInUserRegex.Match(referer);
                        if (!matchResult.Success)
                        {
                            _loggedInMID = string.Empty;
                        }
                        else
                        {
                            _loggedInMID = matchResult.Groups["MID"].Value;
                        }
                    }
                    if (string.IsNullOrEmpty(_loggedInMID))
                    {
                        _loggedInMID = request.Params[LoggedInFlag];
                        _loggedInMID = _loggedInMID ?? string.Empty;
                    }
                }
                return _loggedInMID;
            }
        }

        public int PageIndex
        {
            get
            {
                return Convert.ToInt32(Request["pageIndex"]);
                //return Request.To<int>("pageIndex");
            }
        }

        public int PageSize
        {
            get
            {
                return Convert.ToInt32(Request["pageSize"]);
                //var size = Request.To<int>("pageSize");
                //return size == 0 ? 15 : size;
            }
        }
        public int totalCount;
        public int TotalPage(int pageCount)
        {
            pageCount = pageCount == 0 ? 1 : pageCount;
            var result = totalCount % pageCount;
            if (result == 0)
            {
                return totalCount / pageCount;
            }
            else
            {
                return totalCount / pageCount + 1;
            }
        }

        public int TotalPage()
        {
            return TotalPage(PageSize);
        }

        protected int pcount;


        /// <summary>
        /// 逻辑上当前登陆的用户
        /// </summary>
        protected Model.Member TModel
        {
            get
            {
                if (_tModel == null)
                {
                    if (ActualTModel == null)
                    {
                        _tModel = null;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(LoggedInMID) && ActualUserIsAdmin)
                        {
                            _tModel = BLL.Member.GetModelByMID(LoggedInMID);
                        }
                        else
                        {
                            _tModel = ActualTModel;
                        }
                    }
                }
                return _tModel;
            }
        }

        /// <summary>
        /// 当前的用户的名字
        /// </summary>
        protected string CurrentUserName
        {
            get
            {
                var mid = User.Identity.Name;
                return string.IsNullOrEmpty(mid) ? Session["LoggedInMID"] as string : mid;
            }
        }

        private BLL.Member _bllModel;
        protected BLL.Member BllModel
        {
            get
            {
                if (_bllModel == null)
                {
                    if (TModel == null)
                    {
                        _bllModel = null;
                    }
                    else
                    {
                        _bllModel = new BLL.Member();
                        _bllModel.TModel = TModel;
                    }
                }
                return _bllModel;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            if (BllModel != null && BllModel.TModel != null)
            {
                //TModel = BllModel.TModel;
                if (TModel.IsClose)
                {
                    Response.Write("<script>window.top.location.href='SysManage/Out.aspx'</script>");
                    Response.End();
                    return;
                }
                //else if (BllModel.VerifyUrl(Context.Request.Url.AbsolutePath) && (Session["pass"] == null || Session["pass"].ToString() != "pass"))
                //{
                //    Response.Write("<script>window.top.location.href='/SysManage/Out.aspx'</script>");
                //    Response.End();
                //    return;
                //}
            }
            //else
            //    TModel = null;
            if (!IsPostBack)
            {
                if (!WebModel.WebState || !TestCloseTime())
                {
                    if ((TModel == null || !TModel.Role.Super) && !Context.Request.Url.AbsolutePath.ToUpper().Contains("MQL/LOGIN.ASPX"))
                    {
                        Response.Write("<script>window.top.location.href='SysManage/Out.aspx'</script>");
                        Response.End();
                    }
                    else
                    {
                        VerifyPower();
                    }
                }
                else
                {
                    VerifyPower();
                }
            }
        }

        /// <summary>
        /// 验证授权
        /// </summary>
        private void VerifyPower()
        {
            if (!BLL.CommonBase.TestSql(Request.QueryString.ToString() + Request.Form.ToString()))
            {
                Response.Write("非法关键字符");
                Response.End();
                return;
            }

            if (BLL.Member.VerifyPower(HttpContext.Current, BllModel))
            {
                SetLanguage();
                if (!string.IsNullOrEmpty(Request.QueryString["Action"]))
                {
                    try
                    {
                        if (Request.QueryString["Action"].ToUpper() == "ADD")
                        {
                            Response.Write(btnAdd_Click());
                        }
                        else if (Request.QueryString["Action"].ToUpper() == "MODIFY")
                        {
                            Response.Write(btnModify_Click());
                        }
                        else if (Request.QueryString["Action"].ToUpper() == "OTHER")
                        {
                            Response.Write(btnOther_Click());
                        }
                        else
                        {
                            Response.Write("未提供该操作的函数");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                    Response.End();
                    return;
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    SetValue(Request.QueryString["ID"]);
                }
                else
                {
                    var opt = Request["opt"];
                    if (!string.IsNullOrEmpty(opt))
                    {
                        SetPowerZone();
                        RaiseCallbackEvent(opt);
                        Response.Write(GetCallbackResult());
                        Response.End();
                        return;
                    }
                    SetValue();
                }
                SetPowerZone();
            }
            else
            {
                if (NoPower())
                {
                    Response.Write("<script>window.top.location.href='/mobile/html/Login.aspx'</script>");
                    Response.End();
                }
            }
        }

        private string eventArgument;
        public void RaiseCallbackEvent(string eventArgument)
        {
            this.eventArgument = eventArgument;
        }

        public string GetCallbackResult()
        {
            try
            {
                var method = this.GetType().GetMethods().FirstOrDefault(m => m.Name.StartsWith("Opt_" + eventArgument, StringComparison.OrdinalIgnoreCase) && m.ReturnType == typeof(string) && m.GetParameters().Length == 0);
                if (method != null)
                {
                    return (string)method.Invoke(this, null);
                }
                return string.Empty;
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    return e.InnerException.Message;
                }
                return e.Message;
            }
        }


        protected virtual string btnAdd_Click()
        {
            return "未重载";
        }

        protected virtual string btnModify_Click()
        {
            return "未重载";
        }

        protected virtual string btnOther_Click()
        {
            return "未重载";
        }

        protected virtual void SetValue(string id)
        {

        }

        protected virtual void SetValue()
        {

        }

        protected virtual void SetPowerZone()
        {

        }

        protected virtual bool NoPower()
        {
            return true;
        }

        private bool TestCloseTime()
        {
            string nowDate = DateTime.Now.ToString("yyyy-MM-dd ");
            foreach (string time in WebModel.OpenTimeList)
            {
                string[] times = time.Split('-');
                if (DateTime.Parse(nowDate + times[0]) < DateTime.Now && DateTime.Parse(nowDate + times[1]) > DateTime.Now)
                    return true;
            }
            return false;
        }

        public List<string> GetTimeList(string opentimestr)
        {
            if (!string.IsNullOrEmpty(opentimestr))
                return opentimestr.Split(';').Where(emp => !string.IsNullOrEmpty(emp)).ToList();
            return new List<string>();
        }

        public bool TestCloseTime(string openTimeList)
        {
            var OpenTimeList = GetTimeList(openTimeList);
            string nowDate = DateTime.Now.ToString("yyyy-MM-dd ");
            foreach (string time in OpenTimeList)
            {
                string[] times = time.Split('-');
                if (DateTime.Parse(nowDate + times[0]) < DateTime.Now && DateTime.Parse(nowDate + times[1]) > DateTime.Now)
                    return true;
            }
            return false;
        }

        //Add by zhuxy,其他页面可能公众的方法
        protected IList<string> GetSetedGuid(IList<string> newDetailListTrain)
        {
            IList<string> strFlagsTrain = new List<string>();
            foreach (string str in newDetailListTrain)
            {
                string keyFlags = string.Empty;
                keyFlags = str.Split('_')[1];
                if (!strFlagsTrain.Contains(keyFlags))
                {
                    strFlagsTrain.Add(keyFlags);
                }
            }
            return strFlagsTrain;
        }

        public long ToNullLong(object l)
        {
            long ret;
            try
            {
                if (long.TryParse(l.ToString(), out ret))
                {
                    return ret;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        public bool EditTableNeedSaveKeys(string key, string[] EditTableKeys)
        {
            if (EditTableKeys != null && EditTableKeys.Length > 0)
            {
                foreach (string o in EditTableKeys)
                {
                    if (o.Equals(key, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 校验密保问题
        /// </summary>
        /// <returns></returns>
        public bool Check_SQ_Answer()
        {
            bool flag = true;
            //找到该会员的密保问题及答案
            Model.Sys_SQ_Answer obj = null;
            BLL.Sys_SQ_Answer BLL = new BLL.Sys_SQ_Answer();
            string whereStr = " IsDeleted=0 and Status=1 and MID=" + TModel.ID;
            IList<Model.Sys_SQ_Answer> list = BLL.GetList(whereStr);
            if (list != null && list.Count > 0)
            {
                obj = list[0];
                if (obj.QId != long.Parse(Request.Form["ddl_PwdQuestion"]))
                {
                    flag = false;
                }
                if (obj.Answer != Request.Form["pwdAnswer"])
                {
                    flag = false;
                }
            }
            return flag;
        }

        public string GetMemberType(Model.Member member)
        {
            return member.MAgencyType._MAgencyName;
            //if (!member.MState)
            //{
            //    return "未激活会员";
            //}
            //return member.MConfig.DTFHState ? "正式会员" : "<span style='color:blue;'>金种子帐号<span>";
        }


        public Model.Configuration Config
        {
            get
            {
                return BLL.Configuration.Model;
            }
        }

        public string GetRealUserIp()
        {
            string userIP = "未获取用户IP";
            try
            {
                if (HttpContext.Current == null || HttpContext.Current.Request == null || HttpContext.Current.Request.ServerVariables == null)
                    return "";
                string CustomerIP = "";
                //CDN加速后取到的IP  
                CustomerIP = HttpContext.Current.Request.Headers["Cdn-Src-Ip"];
                if (!string.IsNullOrEmpty(CustomerIP))
                {
                    return CustomerIP;
                }
                CustomerIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (!String.IsNullOrEmpty(CustomerIP))
                    return CustomerIP;
                if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                {
                    CustomerIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (CustomerIP == null)
                        CustomerIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                else
                {
                    CustomerIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                if (string.Compare(CustomerIP, "unknown", true) == 0)
                    return HttpContext.Current.Request.UserHostAddress;
                return CustomerIP;
            }
            catch { }
            return userIP;
        }

        public string GetUserIp()
        {
            return "127.0.0.1";
            string userIP = "未获取用户IP";
            try
            {
                if (HttpContext.Current == null || HttpContext.Current.Request == null || HttpContext.Current.Request.ServerVariables == null)
                    return "";
                string CustomerIP = "";
                //CDN加速后取到的IP  
                CustomerIP = HttpContext.Current.Request.Headers["Cdn-Src-Ip"];
                if (!string.IsNullOrEmpty(CustomerIP))
                {
                    return CustomerIP;
                }
                CustomerIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (!String.IsNullOrEmpty(CustomerIP))
                    return CustomerIP;
                if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                {
                    CustomerIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (CustomerIP == null)
                        CustomerIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                else
                {
                    CustomerIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                if (string.Compare(CustomerIP, "unknown", true) == 0)
                    return HttpContext.Current.Request.UserHostAddress;
                return CustomerIP;
            }
            catch { }
            return userIP;
        }

        protected string GetKeyName(string value)
        {
            string str = value.ToString();
            Regex objRegExp = new Regex("<(.|\n)+?>");
            string newStr = objRegExp.Replace(str, "");
            newStr = newStr.Replace("<", "&lt;");
            newStr = newStr.Replace(">", "&gt;");
            return newStr;
        }

        /// <summary>
        /// 获取银行
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public string GetBank(Model.Member member)
        {
            string error = "";
            //member.Bank = Request.Form["txtBank"];
            //member.BankCardName = Request.Form["txtBankCardName"];
            //member.BankNumber = Request.Form["txtBankNumber"];
            //member.Branch = Request.Form["txtBranch"];
            if (string.IsNullOrWhiteSpace(member.Province))
            {
                error= "省不能为空";
            }
            else if (string.IsNullOrWhiteSpace(member.City))
            {
                error= "市不能为空";
            }
            else if (string.IsNullOrEmpty(member.Bank))
            {
                error = "开户银行不能为空";
            }
            else if (string.IsNullOrEmpty(member.BankCardName))
            {
                error = "开户姓名不能为空";
            }
            else if (string.IsNullOrEmpty(member.BankNumber))
            {
                error = "银行卡号不能为空";
            }
            else if (string.IsNullOrEmpty(member.Branch))
            {
                error = "开户支行不能为空";
            }
            //else if (member.BankCardName != member.MName)
            //{
            //    error = "开户姓名必须和会员昵称一直";
            //}

            return error;
        }
        protected bool IsMobile()
        {
            HttpContext context = HttpContext.Current;
            if (context != null)
            {
                HttpRequest request = context.Request;
                if (request.Browser.IsMobileDevice)
                    return true;
                string MobileUserAgent = System.Configuration.ConfigurationManager.AppSettings["MobileUserAgent"];
                Regex MOBILE_REGEX = new Regex(MobileUserAgent);
                if (string.IsNullOrEmpty(request.UserAgent) || MOBILE_REGEX.IsMatch(request.UserAgent.ToLower()))
                    return true;
            }
            return false;
        }

    }
}