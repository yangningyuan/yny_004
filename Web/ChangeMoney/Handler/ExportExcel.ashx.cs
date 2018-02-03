using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using yny_004.Web.Payment.ShouXinyi;

namespace yny_004.Web.ChangeMoney.Handler
{
    /// <summary>
    /// ExportExcel 的摘要说明
    /// </summary>
    public class ExportExcel : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string result = "非法操作";
            if (!string.IsNullOrEmpty(_context.Request["type"]))
                result = Operation(_context.Request["type"]);

            context.Response.Write(result);
        }

        private string Operation(string type)
        {
            switch (type)
            {
                case "exportExcelYT"://易通支付
                    return exportExcelYT();
                case "exportExcelKLT"://开联通
                    return exportExcelKLT();
                case "exportExcelKLT1"://开联通
                    return exportExcelKLT1();
                case "TXExcel"://提现导出
                    return TXExcel();
                case "TXExcel1"://提现导出
                    return TXExcel1();
                case "CZExcel"://充值
                    return CZExcel();
                case "JJMXExcel"://奖金明细
                    return JJMXExcel();
                case "JJCXExcel"://奖金查询
                    return JJCXExcel();
                case "HKJLExcel"://汇款记录
                    return HKJLExcel();
                case "KCMXExcel"://库存出入明细
                    return KCMXExcel();
                case "DPLBExcel"://店铺列表
                    return DPLBExcel();
                case "TDTPExcel"://团队图谱
                    return TDTPExcel();
                case "TJLBExcel"://推荐列表
                    return TJLBExcel();
                case "SJJLExcel"://升级记录
                    return SJJLExcel();
                case "BWHYExcel"://B网会员
                    return BWHYExcel();
                case "BWTPExcel"://B网图谱
                    return BWTPExcel();
                case "JHLBExcel"://进货列表
                    return JHLBExcel();
                case "THLBExcel"://提货列表
                    return THLBExcel();
                case "ZZCXExcel"://转账查询
                    return ZZCXExcel();
                case "BBLSExcel"://拨比流水
                    return BBLSExcel();
                case "SRTJExcel"://收入统计
                    return SRTJExcel();
                
            }
            return "非法操作";
        }

        # region func

        # region 提现


        private string exportExcelKLT()
        {
            try
            {
                bool state = false;
                string mkey = "";
                string strWhere = " '1'='1' ";
                if (!string.IsNullOrEmpty(_context.Request["tState"]))
                {
                    state = bool.Parse(_context.Request["tState"]);
                }
                if (!string.IsNullOrEmpty(_context.Request["mKey"]))
                {
                    mkey = _context.Request["mKey"];
                }
                if (!string.IsNullOrEmpty(_context.Request["startDate"]))
                {
                    strWhere += " and changedate>'" + _context.Request["startDate"] + " 00:00:00' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["endDate"]))
                {
                    strWhere += " and changedate<'" + _context.Request["endDate"] + " 23:59:59' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["ddlCRemarks"]))
                {
                    strWhere += " and CRemarks='" + _context.Request["ddlCRemarks"] + "' ";
                }
                Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
                if (!memberModel.Role.Super)
                    mkey = memberModel.MID;

                List<Model.ChangeMoney> orderlist = BllModel.GetChangeMoneyEntityList(mkey, BLL.Member.ManageMember.TModel.MID, "", state.ToString(), new List<string> { "TX" }, new List<string> { "MHB" }, strWhere);

                decimal totalmoney = orderlist.Sum(m => m.Money - m.TakeOffMoney - m.ReBuyMoney).ToFixedDecimal(0);

                // 2.设置单元格抬头
                // key：实体对象属性名称，可通过反射获取值
                // value：Excel列的名称
                Dictionary<string, string> cellheader = new Dictionary<string, string> {
                    { "a1", "代付明细表"},
                    { "a2", ""},
                    { "a3", ""},
                    { "a4", "" },
                    { "a5", "" },
                    { "a6", "" },
                    { "a7", "" },
                    { "a8", "" },
                    { "a9", "" },
                };
                List<object> txobjlist = new List<object>();
                txobjlist.Add(new
                {
                    a1 = "版本号",
                    a2 = "201501012001",
                    a3 = "",
                    a4 = "",
                    a5 = "",
                    a6 = "",
                    a7 = "",
                    a8 = "",
                    a9 = "",
                }
                );
                txobjlist.Add(new
                {
                    a1 = "商户信息",
                    a2 = "",
                    a3 = "",
                    a4 = "",
                    a5 = "",
                    a6 = "",
                    a7 = "",
                    a8 = "",
                    a9 = "",

                }
                );
                txobjlist.Add(new
                {
                    a1 = "商户名称",
                    a2 = "北京玉至清科技有限公司",
                    a3 = "",
                    a4 = "",
                    a5 = "商户号",
                    a6 = "101000180103009",
                    a7 = "",
                    a8 = "",
                    a9 = "",

                }
               );
                txobjlist.Add(new
                {
                    a1 = "联系人",
                    a2 = "",
                    a3 = "联系电话",
                    a4 = "",
                    a5 = "",
                    a6 = "",
                    a7 = "",
                    a8 = "",
                    a9 = "",

                }
              );
                txobjlist.Add(new
                {
                    a1 = "商户批次号",
                    a2 = "20150501001",
                    a3 = "",
                    a4 = "",
                    a5 = "",
                    a6 = "",
                    a7 = "",
                    a8 = "",
                    a9 = "",

                }
              );
                txobjlist.Add(new
                {
                    a1 = "订单信息",
                    a2 = "",
                    a3 = "",
                    a4 = "",
                    a5 = "",
                    a6 = "",
                    a7 = "",
                    a8 = "",
                    a9 = "",
                }
              );
                txobjlist.Add(new
                {
                    a1 = "商户订单号",
                    a2 = "收款人名称",
                    a3 = "收款人账号",
                    a4 = "收款账户类型",
                    a5 = "交易金额",
                    a6 = "开户行行号",
                    a7 = "开户行名称",
                    a8 = "用途",
                    a9 = "备注",
                }
                );
                int i = 1;
                orderlist.ForEach(emp => txobjlist.Add(new
                {
                    a1 = emp.CID,
                    a2 = emp.CRemarks.Split('~')[4],
                    a3 = emp.CRemarks.Split('~')[5],
                    a4 = "个人",
                    a5 = ((emp.Money - emp.TakeOffMoney - emp.ReBuyMoney)).ToFixedDecimal(0),
                    a6 = "000000000000",
                    a7 = emp.CRemarks.Split('~')[2],
                    a8 = "工资发放",
                    a9 = "代发",
                }
                )
                );

                // 3.进行Excel转换操作，并返回转换的文件下载链接
                string urlPath = ExcelHelper.EntityListToExcel2003(cellheader, txobjlist, "开联通用户提现列表");

                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                _context.Response.ContentType = "text/plain";
                return js.Serialize(urlPath); // 返回Json格式的内容
            }
            catch (Exception e)
            {
                return "导出失败";
            }
        }

        private string exportExcelKLT1()
        {
            try
            {
                bool state = false;
                string mkey = "";
                string strWhere = " '1'='1' ";
                if (!string.IsNullOrEmpty(_context.Request["tState"]))
                {
                    state = bool.Parse(_context.Request["tState"]);
                }
                if (!string.IsNullOrEmpty(_context.Request["mKey"]))
                {
                    mkey = _context.Request["mKey"];
                }
                if (!string.IsNullOrEmpty(_context.Request["startDate"]))
                {
                    strWhere += " and changedate>'" + _context.Request["startDate"] + " 00:00:00' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["endDate"]))
                {
                    strWhere += " and changedate<'" + _context.Request["endDate"] + " 23:59:59' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["ddlCRemarks"]))
                {
                    strWhere += " and CRemarks='" + _context.Request["ddlCRemarks"] + "' ";
                }
                Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
                if (!memberModel.Role.Super)
                    mkey = memberModel.MID;

                List<Model.ChangeMoney> orderlist = BllModel.GetChangeMoneyEntityList(mkey, BLL.Member.ManageMember.TModel.MID, "", state.ToString(), new List<string> { "TX" }, new List<string> { "MHB" }, strWhere);

                decimal totalmoney = orderlist.Sum(m => m.Money - m.TakeOffMoney - m.ReBuyMoney).ToFixedDecimal(0);

                // 2.设置单元格抬头
                // key：实体对象属性名称，可通过反射获取值
                // value：Excel列的名称
                Dictionary<string, string> cellheader = new Dictionary<string, string> {
                    { "a1", "国付宝账号"},
                    { "a2", "注册国付宝Email"},
                    { "a3", "总金额（元）"},
                    { "a4", "总笔数" },
                    { "a5", "日期" },
                    { "a6", "" },
                    { "a7", "" },
                    { "a8", "" },
                    { "a9", "" },
                    { "a10", "" },
                };
                List<object> txobjlist = new List<object>();
                txobjlist.Add(new
                {
                    a1 = "0000000001000001046",
                    a2 = "guofubao@163.com",
                    a3 = totalmoney,
                    a4 = "",
                    a5 = "" + System.DateTime.Now.ToString("yyyyMMdd"),
                    a6 = "",
                    a7 = "",
                    a8 = "",
                    a9 = "",
                    a10 = "",
                }
                );
               
              
               
                txobjlist.Add(new
                {
                    a1 = "商户流水号",
                    a2 = "收款银行户名",
                    a3 = "收款银行账号",
                    a4 = "收款开户银行",
                    a5 = "收款开户网点名称",
                    a6 = "开户行省份",
                    a7 = "开户行所在市",
                    a8 = "金额",
                    a9 = "对公私标识",
                    a10 = "备注",
                }
                );
                int i = 1;
                orderlist.ForEach(emp => txobjlist.Add(new
                {
                    a1 = System.DateTime.Now.Ticks+""+i,
                    a2 = emp.CRemarks.Split('~')[4],
                    a3 = emp.CRemarks.Split('~')[5],
                    a4 = emp.CRemarks.Split('~')[2],
                    a5 ="",
                    a6 = "",
                    a7 = "",
                    a8 = ((emp.Money - emp.TakeOffMoney - emp.ReBuyMoney)).ToFixedDecimal(0),
                    a9 = "2",
                    a10 = "备注",
                    i=i+1,
                }
                )
                );

                // 3.进行Excel转换操作，并返回转换的文件下载链接
                string urlPath = ExcelHelper.EntityListToExcel2003(cellheader, txobjlist, "开联通用户提现列表");

                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                _context.Response.ContentType = "text/plain";
                return js.Serialize(urlPath); // 返回Json格式的内容
            }
            catch (Exception e)
            {
                return "导出失败";
            }
        }




        private string exportExcelYT()
        {
            try
            {
                bool state = false;
                string mkey = "";
                string strWhere = " '1'='1' ";
                if (!string.IsNullOrEmpty(_context.Request["tState"]))
                {
                    state = bool.Parse(_context.Request["tState"]);
                }
                if (!string.IsNullOrEmpty(_context.Request["mKey"]))
                {
                    mkey = _context.Request["mKey"];
                }
                if (!string.IsNullOrEmpty(_context.Request["startDate"]))
                {
                    strWhere += " and changedate>'" + _context.Request["startDate"] + " 00:00:00' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["endDate"]))
                {
                    strWhere += " and changedate<'" + _context.Request["endDate"] + " 23:59:59' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["ddlCRemarks"]))
                {
                    strWhere += " and CRemarks='" + _context.Request["ddlCRemarks"] + "' ";
                }
                Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
                if (!memberModel.Role.Super)
                    mkey = memberModel.MID;

                List<Model.ChangeMoney> orderlist = BllModel.GetChangeMoneyEntityList(mkey, BLL.Member.ManageMember.TModel.MID, "", state.ToString(), new List<string> { "TX" }, new List<string> { "MHB" }, strWhere);

                decimal totalmoney = orderlist.Sum(m => m.Money - m.TakeOffMoney - m.ReBuyMoney).ToFixedDecimal(0);

                // 2.设置单元格抬头
                // key：实体对象属性名称，可通过反射获取值
                // value：Excel列的名称
                Dictionary<string, string> cellheader = new Dictionary<string, string> {
                    { "a1", "代付商户编号"},
                    { "a2", "代付业务批次名称"},
                    { "a3", "代付金额"},
                    { "a4", "" },
                    { "a5", "" },
                    

                };
                List<object> txobjlist = new List<object>();
                txobjlist.Add(new
                {
                    a1 = "888201707080102",
                    a2 = "批量代付-2013济南代付01-虚拟(可提现)",
                    a3 = totalmoney,
                    a4 = "",
                    a5 = "",
                   
                }
                );
                txobjlist.Add(new
                {
                    a1 = "代付任务",
                    a2 = "",
                    a3 = "",
                    a4 = "",
                    a5 = "",

                }
                );
                txobjlist.Add(new
                {
                    a1 = "银行账号",
                    a2 = "真实姓名",
                    a3 = "开户行名称",
                    a4 = "代付金额",
                    a5 = "代付类型",
                }
                );
                int i = 1;
                orderlist.ForEach(emp => txobjlist.Add(new
                {
                    a1 = emp.CRemarks.Split('~')[5],
                    a2 = emp.CRemarks.Split('~')[4],
                    a3 = emp.CRemarks.Split('~')[3],
                    a4 = ((emp.Money - emp.TakeOffMoney - emp.ReBuyMoney) ).ToFixedDecimal(0),
                    a5 = "个人",
                   
                }
                )
                );

                // 3.进行Excel转换操作，并返回转换的文件下载链接
                string urlPath = ExcelHelper.EntityListToExcel2003(cellheader, txobjlist, "用户提现列表");

                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                _context.Response.ContentType = "text/plain";
                return js.Serialize(urlPath); // 返回Json格式的内容
            }
            catch (Exception e)
            {
                return "导出失败";
            }
        }

        private string TXExcel1()
        {
            try
            {
                bool state = false;
                string mkey = "";
                string strWhere = " '1'='1' ";
                if (!string.IsNullOrEmpty(_context.Request["tState"]))
                {
                    state = bool.Parse(_context.Request["tState"]);
                }
                if (!string.IsNullOrEmpty(_context.Request["mKey"]))
                {
                    mkey = _context.Request["mKey"];
                }
                if (!string.IsNullOrEmpty(_context.Request["startDate"]))
                {
                    strWhere += " and changedate>'" + _context.Request["startDate"] + " 00:00:00' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["endDate"]))
                {
                    strWhere += " and changedate<'" + _context.Request["endDate"] + " 23:59:59' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["ddlCRemarks"]))
                {
                    strWhere += " and CRemarks='" + _context.Request["ddlCRemarks"] + "' ";
                }
                Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
                if (!memberModel.Role.Super)
                    mkey = memberModel.MID;

                List<Model.ChangeMoney> orderlist = BllModel.GetChangeMoneyEntityList(mkey, BLL.Member.ManageMember.TModel.MID, "", state.ToString(), new List<string> { "TX" }, new List<string> { "MHB" }, strWhere);

                // 2.设置单元格抬头
                // key：实体对象属性名称，可通过反射获取值
                // value：Excel列的名称
                Dictionary<string, string> cellheader = new Dictionary<string, string> {
                    { "a2", orderlist.Count.ToString() },
                    { "a3", orderlist.Sum(m=>m.Money - m.TakeOffMoney).ToString() },
                    { "a4", GetTransactionFlow() },
                    { "a5", "" },
                    { "a6", "" },
                    { "a1", "" },
                    { "a7", "" },
                    { "a8", "" },
                };

                List<object> txobjlist = new List<object>();
                orderlist.ForEach(emp => txobjlist.Add(new
                {
                    a1 = (emp.Money - emp.TakeOffMoney).ToFixedDecimal(),
                    a7 = ShouXinYi.v_mid,
                    a5 = emp.CRemarks.Split('~')[0],
                    a6 = emp.CRemarks.Split('~')[1],
                    a4 = emp.CRemarks.Split('~')[2],
                    a3 = emp.CRemarks.Split('~')[4],
                    a2 = emp.CRemarks.Split('~')[5],
                    a8 = GetBankNum(emp.CRemarks.Split('~')[2]),
                }
                ));

                // 3.进行Excel转换操作，并返回转换的文件下载链接
                string urlPath = ExcelHelper.EntityListToExcel2003(cellheader, txobjlist, "用户提现列表");

                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                _context.Response.ContentType = "text/plain";
                return js.Serialize(urlPath); // 返回Json格式的内容
            }
            catch (Exception e)
            {
                return "导出失败";
            }
        }

        public string GetTransactionFlow()
        {
            Random r = new Random();
            return ShouXinYi.v_mid + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + r.Next(0, 1000).ToString().PadLeft(3, '0');
        }

        public string GetBankNum(string bank)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("中国农业银行", "103100000026");
            dic.Add("中国建设银行", "105100000017");
            dic.Add("中国民生银行", "305100000013");
            dic.Add("平安银行", "313584099990");
            dic.Add("中国工商银行", "102100099996");
            dic.Add("招商银行", "308584000013");
            dic.Add("中国邮政储蓄银行", "403100000004");
            dic.Add("中国银行", "104100000004");
            dic.Add("中信银行", "302100011000");
            dic.Add("兴业银行", "309391000011");
            if (dic.ContainsKey(bank))
            {
                return dic[bank];
            }
            return "";
        }

        private string TXExcel()
        {
            try
            {
                bool state = false;
                string mkey = "";
                string strWhere = " '1'='1' ";
                if (!string.IsNullOrEmpty(_context.Request["tState"]))
                {
                    state = bool.Parse(_context.Request["tState"]);
                }
                if (!string.IsNullOrEmpty(_context.Request["mKey"]))
                {
                    mkey = _context.Request["mKey"];
                }
                if (!string.IsNullOrEmpty(_context.Request["startDate"]))
                {
                    strWhere += " and changedate>'" + _context.Request["startDate"] + " 00:00:00' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["endDate"]))
                {
                    strWhere += " and changedate<'" + _context.Request["endDate"] + " 23:59:59' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["ddlCRemarks"]))
                {
                    strWhere += " and CRemarks='" + _context.Request["ddlCRemarks"] + "' ";
                }
                Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
                if (!memberModel.Role.Super)
                    mkey = memberModel.MID;

                List<Model.ChangeMoney> orderlist = BllModel.GetChangeMoneyEntityList(mkey, BLL.Member.ManageMember.TModel.MID, "", state.ToString(), new List<string> { "TX" }, new List<string> { "MHB" }, strWhere);

                // 2.设置单元格抬头
                // key：实体对象属性名称，可通过反射获取值
                // value：Excel列的名称
                Dictionary<string, string> cellheader = new Dictionary<string, string> {
                    { "a1", "金额" },
                    { "a2", "收款人帐号" },
                    { "a3", "收款人名称" },
                    { "a4", "收款帐号开户行名称" },
                    { "a5", "收款方所在省" },
                    { "a6", "收款方所在市县" },
                    { "a7", "转账类型" },
                    { "a8", "汇款用途" },
                };

                List<object> txobjlist = new List<object>();
                orderlist.ForEach(emp => txobjlist.Add(new
                {
                    a1 = (emp.Money - emp.TakeOffMoney).ToFixedDecimal(),
                    a7 = GetZZType(emp),
                    a5 = emp.CRemarks.Split('~')[0],
                    a6 = emp.CRemarks.Split('~')[1],
                    a4 = emp.CRemarks.Split('~')[2],
                    a3 = emp.CRemarks.Split('~')[4],
                    a2 = emp.CRemarks.Split('~')[5],
                    a8 = "",
                }
                ));

                // 3.进行Excel转换操作，并返回转换的文件下载链接
                string urlPath = ExcelHelper.EntityListToExcel2003(cellheader, txobjlist, "用户提现列表");

                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                _context.Response.ContentType = "text/plain";
                return js.Serialize(urlPath); // 返回Json格式的内容
            }
            catch (Exception e)
            {
                return "导出失败";
            }
        }

        private string GetZZType(Model.ChangeMoney cm)
        {
            Model.Member member = BLL.Member.GetModelByMID(BLL.Member.ManageMember.TModel.MID);
            if (member.City == cm.CRemarks.Split('~')[1])//同城
            {
                if (member.Bank == cm.CRemarks.Split('~')[2])
                {//同城同行
                    return "行内转账";
                }
                else
                {//同城跨行
                    return "同城跨行";
                }
            }
            else
            {
                if (member.Bank == cm.CRemarks.Split('~')[2])
                {//异地同行
                    return "行内转账";
                }
                else
                {//异地跨行
                    return "异地跨行";
                }
            }
        }

        # endregion 提现

        # region 充值

        private string CZExcel()
        {
            try
            {
                string mKey = "";
                string strWhere = " '1'='1' ";
                if (!string.IsNullOrEmpty(_context.Request["startDate"]))
                {
                    strWhere += " and changedate>'" + _context.Request["startDate"] + " 00:00:00' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["endDate"]))
                {
                    strWhere += " and changedate<'" + _context.Request["endDate"] + " 23:59:59' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["mKey"]))
                {
                    mKey = _context.Request["mKey"];
                }
                Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
                if (!memberModel.Role.Super)
                    mKey = memberModel.MID;
                if (!string.IsNullOrEmpty(mKey))
                {
                    strWhere += " and ToMID='" + mKey + "'";
                }
                int count = 0;
                StringBuilder sb = new StringBuilder();
                List<Model.ChangeMoney> ListChangeMoney;
                if (!TModel.Role.Super)
                {
                    ListChangeMoney = BllModel.GetChangeMoneyEntityList("", TModel.MID, "", "true", new List<string> { "CZ" }, new List<string> { "MHB", "MJB", "MGP", "MCW", "TotalYFHMoney" }, strWhere);
                }
                else
                {
                    ListChangeMoney = BllModel.GetChangeMoneyEntityList("", mKey, "", "true", new List<string> { "CZ" }, new List<string> { "MHB", "MJB", "MGP", "MCW", "TotalYFHMoney" }, strWhere);
                }

                // 2.设置单元格抬头
                // key：实体对象属性名称，可通过反射获取值
                // value：Excel列的名称
                Dictionary<string, string> cellheader = new Dictionary<string, string> {
                    { "mid", "会员帐号" },
                    { "name", "会员姓名" },
                    { "money", "充值金额" },
                    { "status", "是否生效" },
                    { "MoneyType", "充值钱包" },
                    { "createtime", "日期" }
                };

                List<object> txobjlist = new List<object>();
                ListChangeMoney.ForEach(emp => txobjlist.Add(new
                {
                    mid = emp.FromMID,
                    name = BLL.Member.GetModelByMID(emp.FromMID).MName,
                    money = emp.Money,
                    status = (emp.CState ? "已生效" : "未生效"),
                    MoneyType = BLL.Reward.List[emp.MoneyType].RewardName,
                    createtime = emp.ChangeDate.ToString("yyyy-MM-dd HH:mm:ss")
                }
                ));

                // 3.进行Excel转换操作，并返回转换的文件下载链接
                string urlPath = ExcelHelper.EntityListToExcel2003(cellheader, txobjlist, "用户充值列表");

                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                _context.Response.ContentType = "text/plain";
                return js.Serialize(urlPath); // 返回Json格式的内容
            }
            catch
            {
                return "导出失败";
            }
        }

        # endregion 充值

        # region 奖金明细

        private string JJMXExcel()
        {
            try
            {
                List<string> cTypeList = new List<string>();
                List<string> mTypeList = new List<string> { "MHB", "MJB", "MCW" };
                string mKey = "", shmKey = "", cState = "";
                string strWhere = " '1'='1' ";
                if (!string.IsNullOrEmpty(_context.Request["typeList"]))
                {
                    string types = _context.Request["typeList"].Remove(_context.Request["typeList"].Length - 1);
                    cTypeList = new List<string>(types.Split('|'));
                }
                if (!string.IsNullOrEmpty(_context.Request["mKey"]))
                {
                    mKey = _context.Request["mKey"];
                }
                if (!string.IsNullOrEmpty(_context.Request["tState"]))
                {
                    cState = _context.Request["tState"];
                }
                if (!string.IsNullOrEmpty(_context.Request["txtKey"]))
                {
                    shmKey = _context.Request["txtKey"];
                }
                if (!string.IsNullOrEmpty(_context.Request["startDate"]))
                {
                    strWhere += " and changedate>'" + _context.Request["startDate"] + " 00:00:00' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["endDate"]))
                {
                    strWhere += " and changedate<'" + _context.Request["endDate"] + " 23:59:59' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["moneyType"]))
                {
                    mTypeList = new List<string> { _context.Request["moneyType"] };
                }

                Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
                if (!memberModel.Role.Super)
                {
                    mKey = memberModel.MID;
                }
                int count;
                List<Model.ChangeMoney> ListChangeMoney = BllModel.GetChangeMoneyEntityList(BLL.Member.ManageMember.TModel.MID, mKey, shmKey, cState, cTypeList, mTypeList, strWhere);

                // 2.设置单元格抬头
                // key：实体对象属性名称，可通过反射获取值
                // value：Excel列的名称
                Dictionary<string, string> cellheader = new Dictionary<string, string> {
                    { "mid", "会员帐号" },
                    { "Role", "会员角色" },
                    { "Name", "会员名称" },
                    { "Money", "金额" },
                    { "changeType", "奖励类型" },
                    { "status", "状态" },
                    { "createtime", "日期" }
                };

                List<object> txobjlist = new List<object>();
                ListChangeMoney.ForEach(emp => txobjlist.Add(new
                {
                    mid = emp.ToMID,
                    Role = BLL.Member.GetModelByMID(emp.ToMID).MAgencyType._MAgencyName,
                    Name = BLL.Member.GetModelByMID(emp.ToMID).MName,
                    Money = emp.Money,
                    changeType = BLL.Reward.List[emp.ChangeType].RewardName,
                    state = (emp.CState ? "已生效" : "未生效"),
                    createtime = emp.ChangeDate.ToString("yyyy-MM-dd HH:mm")
                }
                ));

                // 3.进行Excel转换操作，并返回转换的文件下载链接
                string urlPath = ExcelHelper.EntityListToExcel2003(cellheader, txobjlist, "奖金明细列表");

                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                _context.Response.ContentType = "text/plain";
                return js.Serialize(urlPath); // 返回Json格式的内容
            }
            catch
            {
                return "导出失败";
            }
        }

        # endregion 奖金明细

        # region 奖金查询

        private string JJCXExcel()
        {
            try
            {
                List<string> cTypeList = new List<string>();
                List<string> mTypeList = new List<string> { "MHB", "MJB", "MCW" };
                string strWhere = " and '1'='1' ";
                string TypeLength = "100";
                string mKey = "";
                if (!string.IsNullOrEmpty(_context.Request["typeList"]))
                {
                    string types = _context.Request["typeList"].Remove(_context.Request["typeList"].Length - 1);
                    cTypeList = new List<string>(types.Split('|'));
                }
                if (!string.IsNullOrEmpty(_context.Request["txtKey"]))
                {
                    mKey = _context.Request["txtKey"];
                }
                if (!string.IsNullOrEmpty(_context.Request["startDate"]))
                {
                    strWhere += " and changedate>'" + _context.Request["startDate"] + " 00:00:00' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["endDate"]))
                {
                    strWhere += " and changedate<'" + _context.Request["endDate"] + " 23:59:59' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["moneyType"]))
                {
                    mTypeList = new List<string> { _context.Request["moneyType"] };
                }
                if (!string.IsNullOrEmpty(_context.Request["tState"]))
                {
                    TypeLength = _context.Request["tState"];
                }

                Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
                if (!memberModel.Role.Super)
                    mKey = memberModel.MID;

                if (!string.IsNullOrEmpty(mKey))
                {
                    strWhere += " and ( tomid = '" + mKey + "' or ToMName like '%" + mKey + "%' )";
                }

                StringBuilder sqlstr = new StringBuilder("select tomid,");
                foreach (string CType in cTypeList)
                {
                    sqlstr.AppendFormat("sum(case when changetype='{0}' then money else 0 end) as '{0}',", CType);
                }
                sqlstr.Append("sum(TakeOffMoney) as 'Take',");
                sqlstr.Append("sum(ReBuyMoney) as 'ReBuy',");
                sqlstr.Append("sum(MCWMoney) as 'MCW',");
                sqlstr.Append("sum(money) as 'HeJi',");
                sqlstr.Append("sum(money-TakeOffMoney-ReBuyMoney-MCWMoney) as 'JJ'");
                sqlstr.AppendFormat(",CONVERT(varchar(" + TypeLength + "), changedate, 23) as 'Date' from changemoney a where ");
                sqlstr.AppendFormat(" changetype in ('{0}') ", String.Join("','", cTypeList.ToArray()));
                sqlstr.Append(strWhere);
                sqlstr.Append("group by CONVERT(varchar(" + TypeLength + "), changedate, 23),tomid order by CONVERT(varchar(" + TypeLength + "), changedate, 23) desc");
                DataTable table = BLL.CommonBase.GetTable(sqlstr.ToString());

                StringBuilder sb = new StringBuilder();
                decimal[] heji = new decimal[cTypeList.Count + 4];


                // 2.设置单元格抬头
                // key：实体对象属性名称，可通过反射获取值
                // value：Excel列的名称
                Dictionary<string, string> cellheader = new Dictionary<string, string> {
                    { "mid", "会员帐号" },
                    { "Role", "会员角色" },
                    { "Name", "会员名称" },
                    { "ppj", "回本奖" },
                    { "s533", "对碰奖" },
                    { "scbt", "管理奖" },
                    { "xshk", "区域奖" },
                    { "xshk1", "额外区域奖" },
                    { "zjj", "总奖金" },
                    { "createtime", "日期" }
                };
                List<object> txobjlist = new List<object>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Model.Member member = BllModel.GetModel(table.Rows[i]["ToMID"].ToString());
                    txobjlist.Add(new
                    {
                        mid = member.MID,
                        Role = member.MAgencyType._MAgencyName,
                        Name = member.MName,
                        ppj = Convert.ToDecimal(table.Rows[i][cTypeList[0]]).ToFixedDecimal(),
                        s533 = Convert.ToDecimal(table.Rows[i][cTypeList[1]]).ToFixedDecimal(),
                        scbt = Convert.ToDecimal(table.Rows[i][cTypeList[2]]).ToFixedDecimal(),
                        xshk = Convert.ToDecimal(table.Rows[i][cTypeList[3]]).ToFixedDecimal(),
                        xshk1 = Convert.ToDecimal(table.Rows[i][cTypeList[4]]).ToFixedDecimal(),
                        zjj = Convert.ToDecimal(table.Rows[i]["HeJi"]).ToFixedDecimal(),
                        createtime = table.Rows[i]["Date"]
                    });
                }

                // 3.进行Excel转换操作，并返回转换的文件下载链接
                string urlPath = ExcelHelper.EntityListToExcel2003(cellheader, txobjlist, "奖金明细列表");

                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                _context.Response.ContentType = "text/plain";
                return js.Serialize(urlPath); // 返回Json格式的内容
            }
            catch
            {
                return "导出失败";
            }
        }

        # endregion 奖金查询

        # region 汇款记录

        private string HKJLExcel()
        {
            try
            {
                string mkey = "";
                string strWhere = " '1'='1' ";
                if (!string.IsNullOrEmpty(_context.Request["tState"]))
                {
                    strWhere += " and HKState='" + _context.Request["tState"] + "' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["mKey"]))
                {
                    mkey = _context.Request["mKey"];
                }
                if (!string.IsNullOrEmpty(_context.Request["startDate"]))
                {
                    strWhere += " and HKDate>'" + _context.Request["startDate"] + " 00:00:00' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["endDate"]))
                {
                    strWhere += " and HKDate<'" + _context.Request["endDate"] + " 23:59:59' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["hkType"]))
                {
                    strWhere += " and HKType='" + _context.Request["hkType"] + "' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["IsAuto"]))
                {
                    strWhere += " and IsAuto='" + _context.Request["IsAuto"] + "' ";
                }
                Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
                if (!memberModel.Role.Super)
                    mkey = memberModel.MID;
                if (!string.IsNullOrEmpty(mkey))
                {
                    strWhere += " and MID='" + mkey + "' ";
                }
                int count;
                List<Model.HKModel> List = BLL.HKModel.GetList(strWhere);

                // 2.设置单元格抬头
                // key：实体对象属性名称，可通过反射获取值
                // value：Excel列的名称
                Dictionary<string, string> cellheader = new Dictionary<string, string> {
                    { "mid", "会员帐号" },
                    { "Name", "会员名称" },
                    { "HKName", "汇款姓名" },
                    { "money", "实际金额" },
                    { "createtime", "汇款日期" },
                    //{ "pic", "汇款凭证" },
                    { "status", "是否生效" }
                };

                List<object> txobjlist = new List<object>();
                List.ForEach(emp => txobjlist.Add(new
                {
                    mid = emp.MID,
                    Name = BLL.Member.GetModelByMID(emp.MID).MName,
                    HKName = emp.BankName,
                    money = emp.ValidMoney.ToFixedDecimal(),
                    createtime = emp.HKDate.ToString("yyyy-MM-dd HH:mm"),
                    //pic = string.Format("<img src=\"{0}\" width=\"140\" height=\"140\">", emp.Img),
                    status = (emp.HKState ? "已生效" : "未生效"),
                }
                ));

                // 3.进行Excel转换操作，并返回转换的文件下载链接
                string urlPath = ExcelHelper.EntityListToExcel2003(cellheader, txobjlist, "用户汇款列表");

                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                _context.Response.ContentType = "text/plain";
                return js.Serialize(urlPath); // 返回Json格式的内容
            }
            catch
            {
                return "导出失败";
            }
        }

        # endregion 汇款记录

        # region 库存出入明细

        private string KCMXExcel()
        {
            try
            {
                string mkey = "", state = "rz";
                string strWhere = " '1'='1' ";
                if (!string.IsNullOrEmpty(_context.Request["tState"]))
                {
                    state = _context.Request["tState"];
                }
                if (!string.IsNullOrEmpty(_context.Request["mKey"]))
                {
                    mkey = _context.Request["mKey"];
                }
                if (!string.IsNullOrEmpty(_context.Request["startDate"]))
                {
                    strWhere += " and changedate>'" + _context.Request["startDate"] + " 00:00:00' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["endDate"]))
                {
                    strWhere += " and changedate<'" + _context.Request["endDate"] + " 23:59:59' ";
                }
                string toMID = "", fromMID = "";

                Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
                if (!memberModel.Role.Super)//不是管理员
                {
                    if (state == "rz")
                    {
                        toMID = memberModel.MID;
                        fromMID = mkey;
                    }
                    else
                    {
                        toMID = mkey;
                        fromMID = memberModel.MID;
                    }
                }
                else
                { //是管理员
                    if (state == "rz")
                    {
                        toMID = mkey;
                    }
                    else
                    {
                        fromMID = mkey;
                    }
                }

                int count;
                List<Model.ChangeMoney> ListChangeMoney = BllModel.GetChangeMoneyEntityList(fromMID, toMID, "", "", new List<string> { "O_JH", "O_SJ" }, new List<string> { "MCW" }, pageIndex, pageSize, strWhere, out count);

                // 2.设置单元格抬头
                // key：实体对象属性名称，可通过反射获取值
                // value：Excel列的名称
                Dictionary<string, string> cellheader = new Dictionary<string, string> {
                    { "frommid", "出账帐号" },
                    { "fromName", "会员姓名" },
                    { "ToMid", "入账帐号" },
                    { "ToName", "会员姓名" },
                    { "count", "数量" },
                    { "createtime", "申请时间" },
                };

                List<object> txobjlist = new List<object>();
                ListChangeMoney.ForEach(emp => txobjlist.Add(new
                {
                    frommid = emp.FromMID,
                    fromName = BLL.Member.GetModelByMID(emp.FromMID).MName,
                    ToMid = emp.ToMID,
                    ToName = BLL.Member.GetModelByMID(emp.ToMID).MName,
                    count = emp.Money.ToFixedString(0),
                    createtime = emp.ChangeDate.ToString("yyyy-MM-dd HH:mm")
                }
                ));

                // 3.进行Excel转换操作，并返回转换的文件下载链接
                string urlPath = ExcelHelper.EntityListToExcel2003(cellheader, txobjlist, "库存出入明细");

                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                _context.Response.ContentType = "text/plain";
                return js.Serialize(urlPath); // 返回Json格式的内容
            }
            catch
            {
                return "导出失败";
            }
        }

        # endregion 库存出入明细

        # region 店铺列表

        private string DPLBExcel()
        {
            try
            {
                string strWhere = "'1'='1'";
                string RoleCode = "";
                foreach (Model.Roles item in BLL.Roles.RolsList.Values.ToList().Where(emp => emp.VState && !emp.IsAdmin).ToList())
                    RoleCode += "'" + item.RType + "',";
                RoleCode = RoleCode.Substring(0, RoleCode.Length - 1);
                if (!string.IsNullOrEmpty(_context.Request["mKey"]))
                {
                    strWhere += string.Format(" and ( MID='{0}' or MName='{0}') ", (_context.Request["mKey"]));
                }
                if (!string.IsNullOrEmpty(_context.Request["tState"]))
                {
                    strWhere += string.Format(" and MType={0} ", (_context.Request["tState"]));
                }
                if (!string.IsNullOrEmpty(_context.Request["startDate"]))
                {
                    strWhere += " and MDate>'" + _context.Request["startDate"] + " 00:00:00' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["endDate"]))
                {
                    strWhere += " and MDate<'" + _context.Request["endDate"] + " 23:59:59' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["RoleCode"]))
                {
                    strWhere += " and RoleCode in ('" + _context.Request["RoleCode"] + "') ";
                }
                else
                {
                    strWhere += " and RoleCode in (" + RoleCode + ") ";
                }
                if (!string.IsNullOrEmpty(_context.Request["JXType"]))
                {
                    if (_context.Request["JXType"] == "no")
                        strWhere += " and JXType is NULL ";
                    else
                        strWhere += " and JXType='" + _context.Request["JXType"] + "'";
                }
                if (!string.IsNullOrEmpty(_context.Request["IsClose"]))
                {
                    strWhere += " and IsClose='" + _context.Request["IsClose"] + "' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["IsClock"]))
                {
                    strWhere += " and IsClock='" + _context.Request["IsClock"] + "' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["AgencyCode"]))
                {
                    strWhere += " and AgencyCode='" + _context.Request["AgencyCode"] + "' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["NAgencyCode"]))
                {
                    strWhere += " and NAgencyCode='" + _context.Request["NAgencyCode"] + "' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["ddlPCode"]))
                {
                    strWhere += " and (select PCode from MemberConfig where MID=Member.MID)='" + _context.Request["ddlPCode"] + "' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["OnlyOnLine"]))
                {
                    strWhere += " and mid in ('" + String.Join("','", BLL.Member.OnLineMember.ToArray()) + "') ";
                }

                int count;
                List<Model.Member> ListMember = BllModel.GetMemberEntityList(strWhere);

                // 2.设置单元格抬头
                // key：实体对象属性名称，可通过反射获取值
                // value：Excel列的名称
                Dictionary<string, string> cellheader = new Dictionary<string, string> {
                    { "mid", "会员帐号" },
                    { "Name", "会员姓名" },
                    { "Agency", "会员角色" },
                    { "MHB", "现金币" },
                    { "MCW", "库存" },
                    { "MTJ", "推荐人" },
                    { "IsClose", "锁定状态" },
                    { "IsClock", "冻结状态"},
                    { "MDate", "激活日期 " }
                };

                List<object> txobjlist = new List<object>();
                ListMember.ForEach(emp => txobjlist.Add(new
                {
                    mid = emp.MID,
                    Name = emp.MName,
                    Agency = emp.Role.RName,
                    MHB = emp.MConfig.MJJ.ToFixedString(),
                    MCW = emp.MConfig.MCW.ToFixedString(),
                    MTJ = emp.MTJ,
                    IsClose = (emp.IsClose ? "已锁定" : "未锁定"),
                    IsClock = (emp.IsClock ? "已冻结" : "未冻结"),
                    MDate = emp.MDate.ToString("yyyy-MM-dd HH:mm"),
                }
                ));

                // 3.进行Excel转换操作，并返回转换的文件下载链接
                string urlPath = ExcelHelper.EntityListToExcel2003(cellheader, txobjlist, "店铺列表");

                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                _context.Response.ContentType = "text/plain";
                return js.Serialize(urlPath); // 返回Json格式的内容
            }
            catch
            {
                return "导出失败";
            }
        }

        # endregion 店铺列表

        # region 团队图谱

        private string TDTPExcel()
        {
            try
            {
                return "";
                //                int level = 3;
                //                string mkey = memberModel.MID;
                //                if (!string.IsNullOrEmpty(_context.Request["level"]))
                //                {
                //                    level = int.Parse(_context.Request["level"]);
                //                }
                //                if (!string.IsNullOrEmpty(_context.Request["mkey"]))
                //                {
                //                    mkey = _context.Request["mkey"];
                //                }

                //                level = GetLevel(level, ref mkey, true);

                //                if (!TModel.Role.IsAdmin)
                //                {
                //                    int count = Convert.ToInt32(BLL.CommonBase.GetSingle(string.Format(@"
                //                            -- 查找所有父节点
                //                            with tab as
                //                            (
                //                             select MID,MBD from member where MID='{0}' --子节点
                //                             union all
                //                             select b.MID,b.MBD
                //                             from
                //                              tab a,--子节点数据集
                //                              member b  --父节点数据集
                //                             where a.MBD=b.MID and b.MID <> '{1}'  --子节点数据集.parendID=父节点数据集.ID
                //                            )
                //                            select count(*) from tab where MID = '{2}';
                //                            ", mkey, BLL.Member.ManageMember.TModel.MID, TModel.MID)));
                //                    //int mcount = Convert.ToInt32(BLL.CommonBase.GetSingle("select COUNT(*) from GetAllSubBDMember('" + TModel.MID + "') where mid='" + mkey + "';"));
                //                    if (count <= 0)
                //                    {
                //                        mkey = TModel.MID;
                //                    }
                //                }

                //                List<Model.Member> orderlist = BllModel.GetMemberStruct("", mkey, level);

                //                // 2.设置单元格抬头
                //                // key：实体对象属性名称，可通过反射获取值
                //                // value：Excel列的名称
                //                Dictionary<string, string> cellheader = new Dictionary<string, string> {
                //                    { "MBD", "上级会员" },
                //                    { "mid", "会员帐号" },
                //                    { "Agency", "店铺级别" },
                //                    { "Name", "会员姓名" },
                //                    { "Count", "人数" },
                //                    { "TotalMoney", "业绩" },
                //                };

                //                List<object> txobjlist = new List<object>();
                //                orderlist.ForEach(emp => txobjlist.Add(new
                //                {
                //                    MBD = emp.MBD,
                //                    mid = emp.MID,
                //                    Agency = emp.MAgencyType._MAgencyName,
                //                    Name = emp.MName,
                //                    Count = (emp.MConfig.YJCount == 0 ? 0 : emp.MConfig.YJCount - 1),
                //                    TotalMoney = emp.MConfig.YJMoney,
                //                }
                //                ));

                //                // 3.进行Excel转换操作，并返回转换的文件下载链接
                //                string urlPath = ExcelHelper.EntityListToExcel2003(cellheader, txobjlist, "会员团队图谱");

                //                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                //                _context.Response.ContentType = "text/plain";
                //                return js.Serialize(urlPath); // 返回Json格式的内容
            }
            catch
            {
                return "导出失败";
            }
        }

        private int GetLevel(int level, ref string mkey, bool IsMBD)
        {
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.Super)
            {
                if (mkey == memberModel.MID)
                {
                    if (level > memberModel.MAgencyType.ViewLevel)
                        level = memberModel.MAgencyType.ViewLevel;
                }
                else
                {
                    int levelCount = BllModel.GetLevelForView(mkey, IsMBD);
                    if (levelCount >= 0)
                    {
                        if (level + levelCount > memberModel.MAgencyType.ViewLevel)
                            level = memberModel.MAgencyType.ViewLevel - levelCount > level ? level : memberModel.MAgencyType.ViewLevel - levelCount;
                    }
                    else
                    {
                        mkey = memberModel.MID;
                    }
                }
            }
            return level;
        }

        # endregion 团队图谱

        # region 推荐列表

        private string TJLBExcel()
        {
            try
            {
                string RoleCode = "";
                foreach (Model.Roles item in BLL.Roles.RolsList.Values.ToList().Where(emp => !emp.IsAdmin && emp.VState).ToList())
                    RoleCode += "'" + item.RType + "',";
                RoleCode = RoleCode.Substring(0, RoleCode.Length - 1);
                string strWhere = "RoleCode in (" + RoleCode + ")";

                string sh = " and AgencyCode='001' ";
                if (!string.IsNullOrEmpty(_context.Request["tState"]))
                {
                    if (_context.Request["tState"] == "true")
                    {
                        sh = " and AgencyCode<>'001' ";

                        if (!TModel.Role.Super)
                        {
                            sh += " and MSH = '" + TModel.MID + "'";
                        }
                    }
                    else
                    {
                        sh = " and AgencyCode='001' ";
                    }
                }
                if (!string.IsNullOrEmpty(_context.Request["mKey"]))
                {
                    strWhere += string.Format(" and ( MID='{0}' or MName='{0}') ", (_context.Request["mKey"]));
                }
                if (!string.IsNullOrEmpty(_context.Request["startDate"]))
                {
                    strWhere += " and MCreateDate>'" + _context.Request["startDate"] + " 00:00:00' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["endDate"]))
                {
                    strWhere += " and MCreateDate<'" + _context.Request["endDate"] + " 23:59:59' ";
                }
                //strWhere += " and RegistAgency = 0 ";

                //Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
                if (!TModel.Role.Super)
                    strWhere += string.Format(" and MSH='{0}' ", TModel.MID);
                else
                {
                    if (!string.IsNullOrEmpty(_context.Request["mSHKey"]))
                    {
                        strWhere += string.Format(" and MSH='{0}' ", _context.Request["mSHKey"]);
                    }
                }
                List<Model.Member> ListMember = BllModel.GetMemberEntityList(strWhere + sh);

                // 2.设置单元格抬头
                // key：实体对象属性名称，可通过反射获取值
                // value：Excel列的名称
                Dictionary<string, string> cellheader = new Dictionary<string, string> {
                    { "mid", "会员帐号" },
                    { "Name", "会员姓名" },
                    { "Agency", "会员角色" },
                    { "MTJ", "推荐人" },
                    { "MTJCount", "推荐人数" },
                    { "MHB", BLL.Reward.List["MHB"].RewardName },
                    { "MJB", BLL.Reward.List["MJB"].RewardName },
                    { "MCW", BLL.Reward.List["MCW"].RewardName },
                    { "status", "状态" },
                    { "MDate", "注册/激活日期" },
                };

                List<object> txobjlist = new List<object>();
                ListMember.ForEach(emp => txobjlist.Add(new
                {
                    mid = emp.MID,
                    Name = emp.MName,
                    Agency = emp.Role.RName,
                    MTJ = emp.MTJ,
                    MTJCount = emp.MConfig.TJCount,
                    MHB = emp.MConfig.MJJ,
                    MJB = emp.MConfig.MJB,
                    MCW = emp.MConfig.MCW,
                    status = (emp.MState ? "已激活" : "未激活"),
                    MDate = (emp.MState ? emp.MDate.ToString("yyyy-MM-dd HH:mm") : emp.MCreateDate.ToString("yyyy-MM-dd HH:mm")),
                }
                ));

                // 3.进行Excel转换操作，并返回转换的文件下载链接
                string urlPath = ExcelHelper.EntityListToExcel2003(cellheader, txobjlist, "推荐列表");

                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                _context.Response.ContentType = "text/plain";
                return js.Serialize(urlPath); // 返回Json格式的内容
            }
            catch
            {
                return "导出失败";
            }
        }

        # endregion 推荐列表

        # region 升级记录

        private string SJJLExcel()
        {
            try
            {
                return "";
                //string strWhere = " 1=1 ";
                //if (!string.IsNullOrEmpty(_context.Request["tState"]))
                //{
                //    if (_context.Request["tState"] == "2")
                //    {
                //        strWhere += " and U_Status='2' ";
                //    }
                //    else
                //    {
                //        strWhere += " and U_Status<>'2' ";
                //    }
                //}
                //if (TModel.Role.IsAdmin)
                //{
                //    if (!string.IsNullOrEmpty(_context.Request["mKey"]))
                //    {
                //        strWhere += " and U_MID='" + _context.Request["mKey"] + "' ";
                //    }
                //}
                //else
                //{
                //    strWhere += " and U_MID='" + TModel.MID + "' ";
                //}
                //if (!string.IsNullOrEmpty(_context.Request["startDate"]))
                //{
                //    strWhere += " and U_Createtime>'" + _context.Request["startDate"] + " 00:00:00' ";
                //}
                //if (!string.IsNullOrEmpty(_context.Request["endDate"]))
                //{
                //    strWhere += " and U_Createtime<'" + _context.Request["endDate"] + " 23:59:59' ";
                //}

                //int count;
                //List<Model.UpGrade> upgrade = BLL.UpGrade.GetModelList(strWhere);

                //// 2.设置单元格抬头
                //// key：实体对象属性名称，可通过反射获取值
                //// value：Excel列的名称
                //Dictionary<string, string> cellheader = new Dictionary<string, string> {
                //    { "U_CargoCode", "订单编号" },
                //    { "U_MID", "店铺帐号" },
                //    { "MName", "会员名称" },
                //    { "U_Createtime", "申请时间" },
                //    { "U_OldGrade", "原等级" },
                //    { "U_NewGrade", "升级等级" },
                //    { "U_Status", "状态" },
                //    { "U_ValidDateTime", "生效时间" },
                //};

                //List<object> txobjlist = new List<object>();
                //upgrade.ForEach(emp => txobjlist.Add(new
                //{
                //    U_CargoCode = emp.U_CargoCode,
                //    U_MID = emp.U_MID,
                //    MName = BllModel.GetModel(emp.U_MID).MName,
                //    U_Createtime = emp.U_Createtime.ToString("yyyy-MM-dd HH:mm:ss"),
                //    U_OldGrade = BLL.Configuration.Model.SHMoneyList[emp.U_OldGrade].MAgencyName,
                //    U_NewGrade = BLL.Configuration.Model.SHMoneyList[emp.U_OldGrade].MAgencyName,
                //    U_Status = (emp.U_Status == 2 ? "已生效" : (emp.U_Status == 1 ? "已付款" : "未付款")),
                //    U_ValidDateTime = (emp.U_Status == 2 ? emp.U_ValidDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : (emp.U_Status == 1 ? "预计:" + emp.U_PayTime.Value.AddMinutes(BLL.Configuration.Model.UpGradeWaitTime).ToString("yyyy-MM-dd HH:mm:ss") : "")),
                //}
                //));

                //// 3.进行Excel转换操作，并返回转换的文件下载链接
                //string urlPath = ExcelHelper.EntityListToExcel2003(cellheader, txobjlist, "升级记录列表");

                //System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                //_context.Response.ContentType = "text/plain";
                //return js.Serialize(urlPath); // 返回Json格式的内容
            }
            catch
            {
                return "导出失败";
            }
        }

        # endregion 升级记录

        # region B网会员

        private string BWHYExcel()
        {
            try
            {
                return "";
                //string strWhere = " 1 = 1";
                //if (!string.IsNullOrEmpty(_context.Request["mKey"]))
                //{
                //    strWhere += " and ( BMID = '" + _context.Request["mKey"] + "' or MName like '%" + _context.Request["mKey"] + "%' ) ";
                //}
                //if (!string.IsNullOrEmpty(_context.Request["startDate"]))
                //{
                //    strWhere += " and BMDate>'" + _context.Request["startDate"] + " 00:00:00' ";
                //}
                //if (!string.IsNullOrEmpty(_context.Request["endDate"]))
                //{
                //    strWhere += " and BMDate<'" + _context.Request["endDate"] + " 23:59:59' ";
                //}
                //if (!TModel.Role.Super)
                //mKey = TModel.MID;
                //if (!TModel.Role.IsAdmin)
                //{
                //    strWhere += " and BMBD = '" + TModel.MID + "' ";
                //}

                //int count;
                //List<Model.BMember> ListMember = BLL.BMember.GetList(strWhere);

                // 2.设置单元格抬头
                // key：实体对象属性名称，可通过反射获取值
                // value：Excel列的名称
                //Dictionary<string, string> cellheader = new Dictionary<string, string> {
                //    { "BMID", "店铺帐号" },
                //    { "MName", "会员姓名" },
                //    { "BMBD", "上级店铺" },
                //    { "BMCreateDate", "进入时间" },
                //    { "IsValid", "是否有效" },
                //    { "NeedLayUp", "是否安置" },
                //};

                //List<object> txobjlist = new List<object>();
                //ListMember.ForEach(emp => txobjlist.Add(new
                //{
                //    BMID = emp.BMID,
                //    MName = BLL.Member.GetModelByMID(emp.BMID).MName,
                //    BMBD = emp.BMBD,
                //    BMCreateDate = emp.BMCreateDate.ToString("yyyy-MM-dd HH:mm:ss"),
                //    IsValid = (emp.IsValid ? "有效" : "无效"),
                //    NeedLayUp = (emp.NeedLayUp ? "未安置" : "已安置"),
                //}
                //));

                // 3.进行Excel转换操作，并返回转换的文件下载链接
                //string urlPath = ExcelHelper.EntityListToExcel2003(cellheader, txobjlist, "B网会员");

                //System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                //_context.Response.ContentType = "text/plain";
                //return js.Serialize(urlPath); // 返回Json格式的内容
            }
            catch
            {
                return "导出失败";
            }
        }

        # endregion B网会员

        # region B网图谱

        private string BWTPExcel()
        {
            try
            {
                bool state = false;
                string mkey = "";
                string strWhere = " '1'='1' ";
                if (!string.IsNullOrEmpty(_context.Request["tState"]))
                {
                    state = bool.Parse(_context.Request["tState"]);
                }
                if (!string.IsNullOrEmpty(_context.Request["mKey"]))
                {
                    mkey = _context.Request["mKey"];
                }
                if (!string.IsNullOrEmpty(_context.Request["startDate"]))
                {
                    strWhere += " and changedate>'" + _context.Request["startDate"] + " 00:00:00' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["endDate"]))
                {
                    strWhere += " and changedate<'" + _context.Request["endDate"] + " 23:59:59' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["ddlCRemarks"]))
                {
                    strWhere += " and CRemarks='" + _context.Request["ddlCRemarks"] + "' ";
                }
                Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
                if (!memberModel.Role.Super)
                    mkey = memberModel.MID;

                List<Model.ChangeMoney> orderlist = BllModel.GetChangeMoneyEntityList(mkey, BLL.Member.ManageMember.TModel.MID, "", state.ToString(), new List<string> { "TX" }, new List<string> { "MHB" }, strWhere);

                // 2.设置单元格抬头
                // key：实体对象属性名称，可通过反射获取值
                // value：Excel列的名称
                Dictionary<string, string> cellheader = new Dictionary<string, string> {
                    { "mid", "会员帐号" },
                    { "bank", "开户行" },
                    { "branch", "开户支行" },
                    { "bankname", "开户名" },
                    { "banknumber", "卡号" },
                    { "txmoney", "提现金额" },
                    { "sfmoney", "实发金额" },
                    { "mhb", BLL.Reward.List["MHB"].RewardName },
                    { "state", "是否批准" },
                    { "createtime", "申请时间" }
                };

                List<object> txobjlist = new List<object>();
                orderlist.ForEach(emp => txobjlist.Add(new
                {
                    mid = emp.FromMID,
                    bank = emp.CRemarks.Split('~')[0],
                    branch = emp.CRemarks.Split('~')[1],
                    bankname = emp.CRemarks.Split('~')[2],
                    banknumber = emp.CRemarks.Split('~')[3],
                    txmoney = emp.Money.ToFixedDecimal(),
                    sfmoney = (emp.Money - emp.TakeOffMoney).ToFixedDecimal(),
                    mhb = ((emp.Money - emp.TakeOffMoney) * BLL.Configuration.Model.B_OutFloat).ToFixedDecimal(),
                    state = (emp.CState ? "已批准" : "未批准"),
                    createtime = emp.ChangeDate.ToString("yyyy-MM-dd HH:mm")
                }
                ));

                // 3.进行Excel转换操作，并返回转换的文件下载链接
                string urlPath = ExcelHelper.EntityListToExcel2003(cellheader, txobjlist, "用户提现列表");

                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                _context.Response.ContentType = "text/plain";
                return js.Serialize(urlPath); // 返回Json格式的内容
            }
            catch
            {
                return "导出失败";
            }
        }

        # endregion B网图谱

        # region 进货列表

        private string JHLBExcel()
        {
            try
            {
                return "";
                //string strWhere = " 1=1 ";
                //if (!string.IsNullOrEmpty(_context.Request["tState"]))
                //{
                //    strWhere += " and O_Status='" + _context.Request["tState"] + "' ";
                //}
                //if (TModel.Role.IsAdmin)
                //{
                //    if (!string.IsNullOrEmpty(_context.Request["mKey"]))
                //    {
                //        strWhere += " and O_GetMID='" + _context.Request["mKey"] + "' or MName like '%" + _context.Request["mKey"] + "%' ";
                //    }
                //}
                //else
                //{
                //    strWhere += " and O_GetMID='" + TModel.MID + "' ";
                //}
                //if (!string.IsNullOrEmpty(_context.Request["startDate"]))
                //{
                //    strWhere += " and O_CreateTime>'" + _context.Request["startDate"] + " 00:00:00' ";
                //}
                //if (!string.IsNullOrEmpty(_context.Request["endDate"]))
                //{
                //    strWhere += " and O_CreateTime<'" + _context.Request["endDate"] + " 23:59:59' ";
                //}

                //int count;
                //List<Model.Cargo> cargos = BLL.Cargo.GetList(strWhere, pageIndex, pageSize, out count);

                //// 2.设置单元格抬头
                //// key：实体对象属性名称，可通过反射获取值
                //// value：Excel列的名称
                //Dictionary<string, string> cellheader = new Dictionary<string, string> {
                //    { "O_Code", "订单编号" },
                //    { "O_GetMID", "收货人" },
                //    { "MName", "收货人姓名" },
                //    { "O_CreateTime", "订单时间" },
                //    { "O_Count", "商品数量" },
                //    { "O_SendCount", "会员发货数量" },
                //    { "O_Money", "商品总价" },
                //    { "O_SendMID", "发货人"},
                //    { "O_SendTime", "发货时间" },
                //    { "O_Status", "状态" },
                //    { "O_TypeStr", "类型" }
                //};

                //List<object> txobjlist = new List<object>();
                //cargos.ForEach(emp => txobjlist.Add(new
                //{
                //    O_Code = emp.O_Code,
                //    O_GetMID = emp.O_GetMID,
                //    MName = BllModel.GetModel(emp.O_GetMID).MName,
                //    O_CreateTime = emp.O_CreateTime.ToString("yyyy-MM-dd HH:mm"),
                //    O_Count = emp.O_Count,
                //    O_SendCount = emp.O_SendCount,
                //    O_Money = emp.O_Money,
                //    O_SendMID = emp.O_SendMID,
                //    O_SendTime = (emp.O_SendTime == null ? "" : emp.O_SendTime.Value.ToString("yyyy-MM-dd HH:mm")),
                //    O_Status = ((emp.O_Status == 0 && BLL.HKModel.GetList(" ToBank = '" + emp.ID + "' ").Any()) ? "等待审核汇款" : emp.O_StatusStr),
                //    O_TypeStr = emp.O_TypeStr,
                //}
                //));

                //// 3.进行Excel转换操作，并返回转换的文件下载链接
                //string urlPath = ExcelHelper.EntityListToExcel2003(cellheader, txobjlist, "用户提现列表");

                //System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                //_context.Response.ContentType = "text/plain";
                //return js.Serialize(urlPath); // 返回Json格式的内容
            }
            catch
            {
                return "导出失败";
            }
        }

        # endregion 进货列表

        # region 提货列表

        private string THLBExcel()
        {
            try
            {
                return "";
                //string strWhere = " IsDeleted=0 ";
                //if (!memberModel.Role.Super)
                //{
                //    strWhere += " and MID='" + memberModel.MID + "'";
                //}
                //if (!string.IsNullOrEmpty(_context.Request["tState"]))
                //{
                //    strWhere += " and Status = " + _context.Request["tState"] + " ";
                //}
                //if (!string.IsNullOrEmpty(_context.Request["mKey"]))
                //{
                //    if (memberModel.Role.Super)
                //    {
                //        strWhere += string.Format(" and ( MID='{0}' or MName='{0}') ", (_context.Request["mKey"]));
                //    }
                //}
                //if (!string.IsNullOrEmpty(_context.Request["startDate"]))
                //{
                //    strWhere += " and CreatedTime>'" + _context.Request["startDate"] + " 00:00:00' ";
                //}
                //if (!string.IsNullOrEmpty(_context.Request["endDate"]))
                //{
                //    strWhere += " and CreatedTime<'" + _context.Request["endDate"] + " 23:59:59' ";
                //}

                //List<Model.Order> List = BLL.Order.GetList(strWhere);

                //// 2.设置单元格抬头
                //// key：实体对象属性名称，可通过反射获取值
                //// value：Excel列的名称
                //Dictionary<string, string> cellheader = new Dictionary<string, string> {
                //    { "Code", "订单编号" },
                //    { "MID", "会员帐号" },
                //    { "MName", "会员姓名" },
                //    { "GoodCount", "商品数量" },
                //    { "OrderTime", "订单时间" },
                //    { "Status", "订单状态" },
                //};

                //List<object> txobjlist = new List<object>();
                //List.ForEach(emp => txobjlist.Add(new
                //{
                //    Code = emp.Code,
                //    MID = emp.MID,
                //    MName = BllModel.GetModel(emp.MID),
                //    GoodCount = emp.GoodCount,
                //    OrderTime = emp.OrderTime.ToString("yyyy-MM-dd HH:mm"),
                //    Status = GetTHLBStatus(emp.Status),
                //}
                //));

                //// 3.进行Excel转换操作，并返回转换的文件下载链接
                //string urlPath = ExcelHelper.EntityListToExcel2003(cellheader, txobjlist, "提货列表");

                //System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                //_context.Response.ContentType = "text/plain";
                //return js.Serialize(urlPath); // 返回Json格式的内容
            }
            catch
            {
                return "导出失败";
            }
        }

        private string GetTHLBStatus(int status)
        {
            string resu = string.Empty;
            switch (status)
            {
                case 1:
                    resu = "已提交";
                    break;
                case 2:
                    resu = "未发货";
                    break;
                case 3:
                    resu = "已发货";
                    break;
                case 4:
                    resu = "已完成";
                    break;
                case 5:
                    resu = "退货中";
                    break;
                case 6:
                    resu = "已退货";
                    break;
            }
            return resu;
        }

        # endregion 提货列表

        # region 转账查询

        private string ZZCXExcel()
        {
            try
            {
                string type = "";
                string mkey = "";
                string strWhere = " '1'='1' ";
                if (!string.IsNullOrEmpty(_context.Request["tState"]))
                {
                    type = _context.Request["tState"];
                }
                if (!string.IsNullOrEmpty(_context.Request["mKey"]))
                {
                    mkey = _context.Request["mKey"];
                }
                if (!string.IsNullOrEmpty(_context.Request["startDate"]))
                {
                    strWhere += " and changedate>'" + _context.Request["startDate"] + " 00:00:00' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["endDate"]))
                {
                    strWhere += " and changedate<'" + _context.Request["endDate"] + " 23:59:59' ";
                }
                Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
                if (!memberModel.Role.Super)
                    mkey = memberModel.MID;
                int count = 0;
                StringBuilder sb = new StringBuilder();
                List<Model.ChangeMoney> ListChangeMoney;

                // 2.设置单元格抬头
                // key：实体对象属性名称，可通过反射获取值
                // value：Excel列的名称
                Dictionary<string, string> cellheader = new Dictionary<string, string> {
                    { "frommid", "会员帐号" },
                    { "fromName", "会员姓名" },
                    { "money", "金额" },
                    { "ToMID", "目标ID" },
                    { "toName", "会员姓名" },
                    { "status", "状态" },
                    { "remarks", "备注" },
                    { "createtime", "日期" }
                };
                List<object> txobjlist = new List<object>();
                if (type == "zc")
                {
                    ListChangeMoney = BllModel.GetChangeMoneyEntityList(mkey, "", "", "true", new List<string> { "ZZ" }, new List<string> { "MHB", "MJB" }, strWhere);

                    for (int i = 0; i < ListChangeMoney.Count; i++)
                    {
                        Model.Member member = BllModel.GetModel(ListChangeMoney[i].FromMID);
                        Model.Member member2 = BllModel.GetModel(ListChangeMoney[i].ToMID);
                        //sb.Append(ListChangeMoney[i].CID + "~");
                        //sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                        //sb.Append(ListChangeMoney[i].FromMID + "~");
                        //sb.Append(member2.MName + "~");
                        //sb.Append(ListChangeMoney[i].Money.ToFixedDecimal() + "~");
                        //sb.Append(ListChangeMoney[i].ToMID + "~");
                        //sb.Append(member.MName + "~");
                        //sb.Append((ListChangeMoney[i].CState ? "已生效" : "未生效") + "~");
                        //sb.Append(BLL.Reward.List[ListChangeMoney[i].MoneyType].RewardName + "~");
                        //sb.Append(ListChangeMoney[i].ChangeDate.ToString("yyyy-MM-dd HH:mm"));
                        //sb.Append("≌");
                        txobjlist.Add(new
                        {
                            frommid = ListChangeMoney[i].FromMID,
                            fromName = member2.MName,
                            money = ListChangeMoney[i].Money.ToFixedDecimal(),
                            ToMID = ListChangeMoney[i].ToMID,
                            toName = member.MName,
                            status = (ListChangeMoney[i].CState ? "已生效" : "未生效"),
                            remarks = BLL.Reward.List[ListChangeMoney[i].MoneyType].RewardName,
                            createtime = ListChangeMoney[i].ChangeDate.ToString("yyyy-MM-dd HH:mm"),
                        });
                    }
                }
                else if (type == "zr")
                {
                    ListChangeMoney = BllModel.GetChangeMoneyEntityList("", mkey, "", "true", new List<string> { "ZZ" }, new List<string> { "MHB", "MJB" }, strWhere);

                    for (int i = 0; i < ListChangeMoney.Count; i++)
                    {
                        Model.Member member = BllModel.GetModel(ListChangeMoney[i].FromMID);
                        Model.Member member2 = BllModel.GetModel(ListChangeMoney[i].ToMID);
                        //sb.Append(ListChangeMoney[i].CID + "~");
                        //sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                        //sb.Append(ListChangeMoney[i].ToMID + "~");
                        //sb.Append(member2.MName + "~");
                        //sb.Append(ListChangeMoney[i].Money.ToFixedDecimal() + "~");
                        //sb.Append(ListChangeMoney[i].FromMID + "~");
                        //sb.Append(member.MName + "~");
                        //sb.Append((ListChangeMoney[i].CState ? "已生效" : "未生效") + "~");
                        //sb.Append(BLL.Reward.List[ListChangeMoney[i].MoneyType].RewardName + "~");
                        //sb.Append(ListChangeMoney[i].ChangeDate);
                        //sb.Append("≌");
                        txobjlist.Add(new
                        {
                            frommid = ListChangeMoney[i].ToMID,
                            fromName = member2.MName,
                            money = ListChangeMoney[i].Money.ToFixedDecimal(),
                            ToMID = ListChangeMoney[i].FromMID,
                            toName = member.MName,
                            status = (ListChangeMoney[i].CState ? "已生效" : "未生效"),
                            remarks = BLL.Reward.List[ListChangeMoney[i].MoneyType].RewardName,
                            createtime = ListChangeMoney[i].ChangeDate.ToString("yyyy-MM-dd HH:mm"),
                        });
                    }
                }
                else if (type == "dh")
                {
                    ListChangeMoney = BllModel.GetChangeMoneyEntityList(mkey, BLL.Member.ManageMember.TModel.MID, "", "true", new List<string> { "DH" }, new List<string> { "MHB", "MJB" }, strWhere);

                    for (int i = 0; i < ListChangeMoney.Count; i++)
                    {
                        Model.Member member = BllModel.GetModel(ListChangeMoney[i].FromMID);
                        //sb.Append(ListChangeMoney[i].CID + "~");
                        //sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                        //sb.Append(ListChangeMoney[i].FromMID + "~");
                        //sb.Append(member.MName + "~");
                        //sb.Append(ListChangeMoney[i].Money.ToFixedDecimal() + "~");
                        //sb.Append(ListChangeMoney[i].FromMID + "~");
                        //sb.Append(member.MName + "~");
                        //sb.Append((ListChangeMoney[i].CState ? "已生效" : "未生效") + "~");
                        //sb.Append(BLL.Reward.List[ListChangeMoney[i].MoneyType].RewardName + "-" + ListChangeMoney[i].CRemarks + "~");
                        //sb.Append(ListChangeMoney[i].ChangeDate);
                        //sb.Append("≌");
                        txobjlist.Add(new
                        {
                            frommid = ListChangeMoney[i].FromMID,
                            fromName = member.MName,
                            money = ListChangeMoney[i].Money.ToFixedDecimal(),
                            ToMID = ListChangeMoney[i].FromMID,
                            toName = member.MName,
                            status = (ListChangeMoney[i].CState ? "已生效" : "未生效"),
                            remarks = BLL.Reward.List[ListChangeMoney[i].MoneyType].RewardName,
                            createtime = ListChangeMoney[i].ChangeDate.ToString("yyyy-MM-dd HH:mm"),
                        });
                    }
                }

                // 3.进行Excel转换操作，并返回转换的文件下载链接
                string urlPath = ExcelHelper.EntityListToExcel2003(cellheader, txobjlist, "转账查询列表");

                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                _context.Response.ContentType = "text/plain";
                return js.Serialize(urlPath); // 返回Json格式的内容
            }
            catch
            {
                return "导出失败";
            }
        }

        # endregion 转账查询

        # region 拨比流水

        private string BBLSExcel()
        {
            try
            {
                string jjtype = "'";
                foreach (Model.Reward item in BLL.Reward.List.Values)
                {
                    if (item.NeedProcess)
                        jjtype += item.RewardType + "','";
                }
                jjtype = jjtype.Substring(0, jjtype.LastIndexOf(",'"));

                string strWhere = " select " +
    " isnull((select SUM(SHMoney) from MemberConfig where MID in (select ACode from Accounts where AccountsDate between CONVERT(varchar(100), a.ChangeDate, 23)+ ' 00:00:00' and CONVERT(varchar(100), a.ChangeDate, 23)+' 23:59:59')),0) as 'yj'," +
    " SUM(case when ChangeType in ('sj','sh') then money else 0 end) 'sj'," +
    " SUM(case when ChangeType in (" + jjtype + ") then money else 0 end) 'bc'," +
    " SUM(case when ChangeType in (" + jjtype + ") then MCWMoney else 0 end) 'cw'," +
    " SUM(case when ChangeType in (" + jjtype + ") then ReBuyMoney else 0 end) 'fx'," +
    " SUM(case when ChangeType in (" + jjtype + ") then TakeOffMoney else 0 end) 'ks'," +
    " SUM(case when ChangeType in ('cz') then money else 0 end) 'cz'," +
    " SUM(case when ChangeType in ('tx') and CState='1' then money else 0 end) 'tx'," +
    " SUM(case when ChangeType in ('gm') and MoneyType='mcw' then money else 0 end) 'jj'," +
    " CONVERT(varchar(100), ChangeDate, 23) as 'date' from ChangeMoney a where '1'='1' ";

                if (!string.IsNullOrEmpty(_context.Request["startDate"]))
                {
                    strWhere += " and changedate>'" + _context.Request["startDate"] + " 00:00:00' ";
                }
                else
                {
                    strWhere += " and changedate>'" + DateTime.Now.ToShortDateString() + " 00:00:00' ";
                }
                if (!string.IsNullOrEmpty(_context.Request["endDate"]))
                {
                    strWhere += " and changedate<'" + _context.Request["endDate"] + " 23:59:59' ";
                }
                strWhere += " group by CONVERT(varchar(100), ChangeDate, 23) order by CONVERT(varchar(100), ChangeDate, 23) desc ";

                StringBuilder sb = new StringBuilder();
                DataTable table = BLL.CommonBase.GetTable(strWhere);

                // 2.设置单元格抬头
                // key：实体对象属性名称，可通过反射获取值
                // value：Excel列的名称
                Dictionary<string, string> cellheader = new Dictionary<string, string> {
                    { "bdyj", "报单业绩" },
                    { "hycz", "会员充值" },
                    { "jjbc", "奖金拨出" },
                    { "glf", "管理费" },
                    { "cfxf", "重复消费" },
                    { "txsq", "提现申请" },
                    { "bcbl", "拨出比率" },
                    { "rq", "日期" },
                };
                List<object> txobjlist = new List<object>();
                int count = pageIndex * pageSize < table.Rows.Count ? pageIndex * pageSize : table.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    string bc = "";
                    if ((Convert.ToDecimal(table.Rows[i]["yj"]) + Convert.ToDecimal(table.Rows[i]["sj"])) > 0)
                    {
                        bc = string.Format("{0:N2}%~", (Convert.ToDecimal(table.Rows[i]["bc"])) / (Convert.ToDecimal(table.Rows[i]["yj"]) + Convert.ToDecimal(table.Rows[i]["sj"])) * 100);
                    }

                    txobjlist.Add(new
                    {
                        bdyj = table.Rows[i]["sj"],
                        hycz = table.Rows[i]["cz"],
                        jjbc = table.Rows[i]["bc"],
                        glf = table.Rows[i]["ks"],
                        cfxf = table.Rows[i]["fx"],
                        txsq = table.Rows[i]["tx"],
                        bcbl = bc,
                        rq = table.Rows[i]["date"],
                    });
                }


                // 3.进行Excel转换操作，并返回转换的文件下载链接
                string urlPath = ExcelHelper.EntityListToExcel2003(cellheader, txobjlist, "拨比流水列表");

                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                _context.Response.ContentType = "text/plain";
                return js.Serialize(urlPath); // 返回Json格式的内容
            }
            catch
            {
                return "导出失败";
            }
        }

        # endregion 拨比流水

        # region 收入统计

        private string SRTJExcel()
        {
            try
            {
                string RoleCode = "";
                foreach (Model.Roles item in BLL.Roles.RolsList.Values.ToList().Where(emp => !emp.IsAdmin && emp.VState).ToList())
                    RoleCode += "'" + item.RType + "',";
                RoleCode = RoleCode.Substring(0, RoleCode.Length - 1);
                string strWhere = "MState='1' and RoleCode in (" + RoleCode + ")";
                List<string> typeList = new List<string>();
                List<string> needTakeOff = new List<string>();
                string startDate = "", endDate = "", mKey = "";
                if (!string.IsNullOrEmpty(_context.Request["typeList"]))
                {
                    string types = _context.Request["typeList"].Remove(_context.Request["typeList"].Length - 1);
                    typeList = new List<string>(types.Split('|'));
                }
                if (!string.IsNullOrEmpty(_context.Request["typeList"]))
                {
                    string types = _context.Request["typeList"].Remove(_context.Request["typeList"].Length - 1);
                    needTakeOff = new List<string>(types.Split('|'));
                }
                if (!string.IsNullOrEmpty(_context.Request["mKey"]))
                {
                    strWhere += string.Format(" and ( MID='{0}' or MName='{0}') ", _context.Request["mKey"]);
                    mKey = _context.Request["mKey"];
                }
                if (!string.IsNullOrEmpty(_context.Request["startDate"]))
                {
                    startDate = _context.Request["startDate"];
                }
                if (!string.IsNullOrEmpty(_context.Request["endDate"]))
                {
                    endDate = _context.Request["endDate"];
                }
                List<Model.Member> ListMember = BllModel.GetMemberEntityList(strWhere);

                // 2.设置单元格抬头
                // key：实体对象属性名称，可通过反射获取值
                // value：Excel列的名称
                Dictionary<string, string> cellheader = new Dictionary<string, string> {
                    { "hyzh", "会员帐号" },
                    { "hydj", "会员等级" },
                    { "CJ", "层奖" },
                    { "LP", "量碰" },
                    { "LD", "领导奖" },
                    { "JQFH", "加权分红" },
                    { "ZJJ", "总奖金" },
                };
                List<object> txobjlist = new List<object>();
                Dictionary<string, decimal> JJInfo;
                StringBuilder sb = new StringBuilder();
                int sumCount = 0; decimal sumMoney = 0;
                for (int i = 0; i < ListMember.Count; i++)
                {
                    sumCount = 0; sumMoney = 0;
                    JJInfo = BllModel.GetJJInfo(ListMember[i].MID, typeList, needTakeOff, startDate, endDate);
                    foreach (string item in typeList)
                    {
                        sumCount += Convert.ToInt32(JJInfo[item + "Count"]);
                        sumMoney += JJInfo[item + "Money"];
                    }
                    string hyzh = ListMember[i].MID;
                    string hydj = GetMemberType(ListMember[i]);
                    string CJ = JJInfo[typeList[0] + "Money"].ToFixedString();
                    string LP = JJInfo[typeList[1] + "Money"].ToFixedString();
                    string LD = JJInfo[typeList[2] + "Money"].ToFixedString();
                    string JQFH = JJInfo[typeList[3] + "Money"].ToFixedString();
                    string ZJJ = sumMoney.ToFixedString();
                    txobjlist.Add(new
                    {
                        hyzh = hyzh,
                        hydj = hydj,
                        CJ = CJ,
                        LP = LP,
                        LD = LD,
                        JQFH = JQFH,
                        ZJJ = ZJJ,
                    });
                }


                // 3.进行Excel转换操作，并返回转换的文件下载链接
                string urlPath = ExcelHelper.EntityListToExcel2003(cellheader, txobjlist, "收入统计列表");

                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                _context.Response.ContentType = "text/plain";
                return js.Serialize(urlPath); // 返回Json格式的内容
            }
            catch
            {
                return "导出失败";
            }
        }

        # endregion 收入统计

        # endregion func
    }

    # region 导出类

    # endregion 导出类
}