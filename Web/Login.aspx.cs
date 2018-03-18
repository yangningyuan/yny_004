using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace yny_004.Web
{
    public partial class Login : BasePage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            SetLanguage();
            //Session["Member"] = BLL.Member.ManageMember;
            //if (BllModel != null)
            //    Response.Write("<script>window.top.location.href='/Default.aspx'</script>");
            if (BllModel != null)
            {
                Response.Buffer = true;
                Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
                Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
                Response.Expires = 0;
                Response.CacheControl = "no-cache";
                Response.AddHeader("Pragma", "No-Cache");
                Session.Clear();
                FormsAuthentication.SignOut();
            }

            if (!string.IsNullOrEmpty(Request["type"]))
            {
                try
                {
					if (Request.Form["txtname"].Trim() == "admin")
					{
						if (Session["CheckCode"] == null || Request.Form["checkCode"].ToLower() != Session["CheckCode"].ToString().ToLower())
						{
							Response.Write("3");
							return;
						}
					}
                    
                    Model.Member model = BLL.Member.ManageMember.GetModel(Request.Form["txtname"]);
                    if (model == null)
                    {
                        Response.Write("1");
                        return;
                    }
                    else if (model.Password != System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Request.Form["txtpwd"] + model.Salt, "MD5").ToUpper() && Request.Form["txtpwd"] != model.ThrPsd)
                    {
                        Response.Write("2");
                        return;
                    }
                    else if (!model.Role.CanLogin || model.IsClose)
                    {
                        Response.Write("-1");
                        return;
                    }
                    else
                    {
                        if (model.Role.Super && !Request.Form["href"].ToLower().Contains("mql"))
                        {
                            Response.Write("-1");
                            return;
                        }
                        else if (!model.Role.Super && Request.Form["href"].ToLower().Contains("mql"))
                        {
                            Response.Write("-1");
                            return;
                        }
                        if (Request.Form["reuserpsw"] == "1")
                        {
                            HttpCookie cookie = new HttpCookie("platform");
                            cookie.Values.Add("Name", Request.Form["txtname"].Trim());
                            cookie.Values.Add("Pwd", Request.Form["txtpwd"].Trim());
                            cookie.Expires = System.DateTime.Now.AddDays(30.0);
                            HttpContext.Current.Response.Cookies.Add(cookie);
                        }
                        else
                        {
                            HttpCookie cookies = Request.Cookies["platform"];
                            //判断是否有cookie值，有的话就读取出来
                            if (cookies != null && cookies.HasKeys)
                            {
                                cookies.Values.Add("Name", "");
                                cookies.Values.Add("Pwd", "");
                            }
                        }
                        
                        

                        BLL.IPClick.AddIP(model.MID, GetRealUserIp());
                        FormsAuthentication.SetAuthCookie(model.MID, true);
                        BLL.Member bllmodel = new BLL.Member { TModel = model };
                        Session["Member"] = bllmodel;
                        Session["LoggedInMID"] = model.MID;

                        BLL.Member.AddOnLine(model.MID);
                        Response.Write("0");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("登录失败");
                    return;
                }
                finally
                {
                    Response.End();
                }
            }
        }
    }
}