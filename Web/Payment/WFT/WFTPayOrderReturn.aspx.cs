using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WFTSwiftpass;

namespace yny_004.Web.Payment.WFT
{
    public partial class WFTPayOrderReturn : System.Web.UI.Page
    {
        private ClientResponseHandler resHandler = new ClientResponseHandler();
        private Dictionary<string, string> cfg = new Dictionary<string, string>(1);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //加载配置数据
                this.cfg = Utils.loadCfg();
                //初始化数据
                using (StreamReader sr = new StreamReader(Request.InputStream))
                {
                    this.resHandler.setContent(sr.ReadToEnd());
                    this.resHandler.setKey(this.cfg["key"]);

                    Hashtable resParam = this.resHandler.getAllParameters();
                    if (this.resHandler.isTenpaySign())
                    {
                        if (int.Parse(resParam["status"].ToString()) == 0 && int.Parse(resParam["result_code"].ToString()) == 0)
                        {
                            var billno = resParam["out_trade_no"].ToString();
                            if (!BLL.HKModel.tempList.Contains(billno))
                            {
                                BLL.HKModel.tempList.Add(billno);
                                try
                                {
                                    if (yny_004.BLL.Member.ManageMember.SHPayHB(billno))
                                    {
                                        Response.Write("交易成功！");
                                        Response.End();
                                    }
                                    else
                                    {
                                        Response.Write("交易失败！");
                                        Response.End();
                                    }
                                }
                                finally
                                {
                                    if (BLL.HKModel.tempList.Contains(billno))
                                        BLL.HKModel.tempList.Remove(billno);
                                }
                            }

                            Utils.writeFile("接口回调", resParam); //通知返回参数写入result.txt文本文件。
                            //此处可以在添加相关处理业务 ，更新数据库表中的记录。 resParam可获得订单号等参数值。 
                            Response.Write("success");
                        }
                        else
                        {
                            Response.Write("failure1");
                        }
                    }
                    else
                    {
                        Response.Write("failure2");
                    }
                }
            }
            catch (Exception ex)
            {
                BLL.Task.SendManage(BLL.Member.ManageMember.TModel, "", ex.Source);
            }
        }
    }
}