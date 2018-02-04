using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections;

namespace yny_004.Web.SysManage
{
    public partial class Configuration : BasePage
    {
        protected override void SetPowerZone()
        {
            ConfigurationModel = BLL.Configuration.Model;
        }

        public Model.Configuration ConfigurationModel
        {
            get
            {
                Model.Configuration model = BLL.Configuration.Model;
                # region 基础
                model.B_YLMoney = int.Parse(Request.Form["txtYLMoney"]);
                model.B_DefaultRole = Request.Form["ddlDefaultRole"];
                //model.OutFloat = decimal.Parse(Request.Form["txtOutFloat"]);
                //model.InFloat = decimal.Parse(Request.Form["txtInFloat"]);
                model.B_DHBaseMoney = int.Parse(Request.Form["txtDHBaseMoney"]);
                model.B_DHMinMoney = int.Parse(Request.Form["txtDHMinMoney"]);
                model.B_TXBaseMoney = int.Parse(Request.Form["txtTXBaseMoney"]);
                model.B_TXMinMoney = int.Parse(Request.Form["txtTXMinMoney"]);
                model.B_ZZBaseMoney = int.Parse(Request.Form["txtZZBaseMoney"]);
                model.B_ZZMinMoney = int.Parse(Request.Form["txtZZMinMoney"]);
                model.B_AutoDFH = (Request.Form["txtAutoDFH"] == "1");
                model.B_TXMaxMoney = int.Parse(Request.Form["txtTXMaxMoney"]);
                model.B_TXSwitch = (Request.Form["txSwitch"] == "1");
                //model.B_MaxRegister = int.Parse(Request.Form["txtMaxRegister"]);
                model.B_AutoJS = true;
                //model.B_DPFloat = decimal.Parse(Request.Form["txtB_DPFloat"]);
                //model.B_DPTopFloat = decimal.Parse(Request.Form["txtB_DPTopFloat"]);
                #endregion 基础
                #region 扩展

                model.E_DayFHFloat = decimal.Parse(Request.Form["txtE_DayFHFloat"]);
                model.E_TJFloat = decimal.Parse(Request.Form["txtE_TJFloat"]);
                model.E_TZMin = int.Parse(Request.Form["txtE_TZMin"]);
                model.E_TZMax = int.Parse(Request.Form["txtE_TZMax"]);
                model.E_TZBase = int.Parse(Request.Form["txtE_TZBase"]);
                model.E_QuitFloat = decimal.Parse(Request.Form["txtE_QuitFloat"]);
                model.E_BbinMoney = decimal.Parse(Request.Form["txtE_BbinMoney"]);
                model.E_BbinTimes = int.Parse(Request.Form["txtE_BbinTimes"]);
                model.E_BbinMaxCount = int.Parse(Request.Form["txtE_BbinMaxCount"]);
                model.E_BbinFHFloat = decimal.Parse(Request.Form["txtE_BbinFHFloat"]);
                model.E_MaxTouZi = decimal.Parse(Request.Form["txtE_MaxTouZi"]);

                model.B_TBTJDate = int.Parse(Request.Form["txtB_TBTJDate"]);
                model.B_TBTJMoney = decimal.Parse(Request.Form["txtB_TBTJMoney"]);

                # endregion 扩展

                model.SHMoneyList = GetSHMoneyList();
                ////model.NewSHMoneyList = GetNewSHMoneyList();
                model.ConfigDictionaryList = GetConfigDictionaryList();
                //model.NConfigDictionaryList = GetNConfigDictionaryList();
                //model.ConfigDictionaryNewList = GetConfigDictionaryNewList();
                ////model = BLL.Configuration.Model;

                return model;
            }
            set
            {
                if (value != null)
                {
                    # region 基础
                    txtYLMoney.Value = value.B_YLMoney.ToString();
                    txtDHBaseMoney.Value = value.B_DHBaseMoney.ToString();
                    txtDHMinMoney.Value = value.B_DHMinMoney.ToString();
                    txtTXBaseMoney.Value = value.B_TXBaseMoney.ToString();
                    txtTXMinMoney.Value = value.B_TXMinMoney.ToString();
                    txtZZBaseMoney.Value = value.B_ZZBaseMoney.ToString();
                    txtZZMinMoney.Value = value.B_ZZMinMoney.ToString();
                    txtTXMaxMoney.Value = value.B_TXMaxMoney.ToString();
                    txSwitch.Value = value.B_TXSwitch ? "1" : "0";
                    //txtMaxRegister.Value = value.B_MaxRegister.ToString();
                    //txtB_DPFloat.Value = value.B_DPFloat.ToString();
                    //txtB_DPTopFloat.Value = value.B_DPTopFloat.ToString();
                    #endregion 基础

                    #region 扩展

                    txtE_DayFHFloat.Value = value.E_DayFHFloat.ToString();
                    txtE_TJFloat.Value = value.E_TJFloat.ToString();
                    txtE_TZMin.Value = value.E_TZMin.ToString();
                    txtE_TZMax.Value = value.E_TZMax.ToString();
                    txtE_TZBase.Value = value.E_TZBase.ToString();
                    txtE_QuitFloat.Value = value.E_QuitFloat.ToString();
                    txtE_BbinMoney.Value = value.E_BbinMoney.ToString();
                    txtE_BbinTimes.Value = value.E_BbinTimes.ToString();
                    txtE_BbinMaxCount.Value = value.E_BbinMaxCount.ToString();
                    txtE_BbinFHFloat.Value = value.E_BbinFHFloat.ToString();
                    txtE_MaxTouZi.Value = value.E_MaxTouZi.ToString();

                    txtB_TBTJDate.Value = value.B_TBTJDate.ToString();
                    txtB_TBTJMoney.Value = value.B_TBTJMoney.ToString();

                    #endregion 扩展

                    GridView1.DataSource = value.SHMoneyTable;
                    GridView1.DataBind();
                    GridView2.DataSource = value.ConfigDictionaryTable;
                    GridView2.DataBind();
                    //GridView3.DataSource = value.NewSHMoneyTable;
                    //GridView3.DataBind();
                    //GridView4.DataSource = value.NConfigDictionaryTable;
                    //GridView4.DataBind();
                    //GridView5.DataSource = value.ConfigDictionaryNewTable;
                    //GridView5.DataBind();
                    List<Model.Roles> list = BLL.Roles.RolsList.Values.ToList().Where(emp => emp.VState).ToList();
                    for (int i = 0; i < list.Count; i++)
                    {
                        ddlDefaultRole.Items.Add(new ListItem(list[i].RName, list[i].RType));
                        if (BLL.Configuration.Model.B_DefaultRole == list[i].RType)
                            ddlDefaultRole.SelectedIndex = i;
                    }
                }
            }
        }

        private Dictionary<string, Model.SHMoney> GetSHMoneyList()
        {
            Dictionary<string, Model.SHMoney> SHMoneyList = new Dictionary<string, Model.SHMoney>();

            StringBuilder sb = new StringBuilder();
            int jishuqi = 0;
            foreach (string key in Request.Form.Keys)
            {
                if (key.Contains("GridView1"))
                {
                    jishuqi++;
                    sb.Append(Request.Form[key]);
                    if (jishuqi % 6 != 0)
                        sb.Append("|");
                    else
                        sb.Append("≌");
                }
            }
            string[] rows = sb.ToString().Split('≌');

            foreach (string row in rows)
            {
                if (string.IsNullOrEmpty(row))
                    continue;
                string[] cols = row.Split('|');
                SHMoneyList.Add(cols[0],
                new Model.SHMoney()
                {
                    MAgencyType = cols[0],
                    MAgencyName = cols[1],
                    Money = string.IsNullOrEmpty(cols[2]) ? 0 : decimal.Parse(cols[2]),
                    TXFloat = decimal.Parse(cols[3]),
                    //YJMoney = string.IsNullOrEmpty(cols[3]) ? 0 : decimal.Parse(cols[3]),
                    //DPFloat = string.IsNullOrEmpty(cols[4]) ? 0 : decimal.Parse(cols[4]),
                    //ReBuyFloat = string.IsNullOrEmpty(cols[5]) ? 0 : decimal.Parse(cols[5]),
                    //SubCount = int.Parse(cols[6]),
                    //DPTopMoney = decimal.Parse(cols[6]),

                    ViewLevel = int.Parse(cols[4]),
                    MColor = cols[5],
                });
            }
            return SHMoneyList;
        }

        private Dictionary<string, Model.NewSHMoney> GetNewSHMoneyList()
        {
            Dictionary<string, Model.NewSHMoney> newSHMoneyList = new Dictionary<string, Model.NewSHMoney>();

            StringBuilder sb = new StringBuilder();
            int jishuqi = 0;
            foreach (string key in Request.Form.Keys)
            {
                if (key.Contains("GridView3"))
                {
                    jishuqi++;
                    sb.Append(Request.Form[key]);
                    if (jishuqi % 7 != 0)
                        sb.Append("|");
                    else
                        sb.Append("≌");
                }
            }
            string[] rows = sb.ToString().Split('≌');

            foreach (string row in rows)
            {
                if (string.IsNullOrEmpty(row))
                    continue;
                string[] cols = row.Split('|');
                newSHMoneyList.Add(cols[0],
                new Model.NewSHMoney()
                {
                    NType = cols[0],
                    NName = cols[1],
                    NJCFloat = decimal.Parse(cols[2]),
                    NTotalYJ = decimal.Parse(cols[3]),
                    NSmallSumYJ = decimal.Parse(cols[4]),
                    NDCount = int.Parse(cols[5]),
                    NMinYJ = decimal.Parse(cols[6])
                });
            }
            return newSHMoneyList;
        }

        private Dictionary<string, List<Model.ConfigDictionary>> GetConfigDictionaryList()
        {
            List<Model.ConfigDictionary> ConfigDictionaryList = new List<Model.ConfigDictionary>();
            StringBuilder sb = new StringBuilder();
            int jishuqi = 0;
            foreach (string key in Request.Form.Keys)
            {
                if (key.Contains("GridView2"))
                {
                    jishuqi++;
                    sb.Append(Request.Form[key]);
                    if (jishuqi % 5 != 0)
                        sb.Append("|");
                    else
                        sb.Append("≌");
                }
            }
            string[] rows = sb.ToString().Split('≌');

            foreach (string row in rows)
            {
                if (string.IsNullOrEmpty(row))
                    continue;
                string[] cols = row.Split('|');
                ConfigDictionaryList.Add(
                new Model.ConfigDictionary()
                {
                    DType = cols[0],
                    Remark = cols[1],
                    StartLevel = int.Parse(cols[2]),
                    EndLevel = int.Parse(cols[3]),
                    DValue = decimal.Parse(cols[4]).ToFixedString(4),
                    DKey = "",
                });
            }
            Dictionary<string, List<Model.ConfigDictionary>> list = new Dictionary<string, List<Model.ConfigDictionary>>();
            foreach (Model.ConfigDictionary item in ConfigDictionaryList)
            {
                if (list.Keys.Contains(item.DType))
                    list[item.DType].Add(item);
                else
                    list.Add(item.DType, new List<Model.ConfigDictionary>() { item });
            }
            return list;
        }

        private Dictionary<string, List<Model.ConfigDictionaryNew>> GetConfigDictionaryNewList()
        {
            List<Model.ConfigDictionaryNew> ConfigDictionaryList = new List<Model.ConfigDictionaryNew>();
            StringBuilder sb = new StringBuilder();
            int jishuqi = 0;
            foreach (string key in Request.Form.Keys)
            {
                if (key.Contains("GridView5"))
                {
                    jishuqi++;
                    sb.Append(Request.Form[key]);
                    if (jishuqi % 7 != 0)
                        sb.Append("|");
                    else
                        sb.Append("≌");
                }
            }
            string[] rows = sb.ToString().Split('≌');

            foreach (string row in rows)
            {
                if (string.IsNullOrEmpty(row))
                    continue;
                string[] cols = row.Split('|');
                ConfigDictionaryList.Add(
                new Model.ConfigDictionaryNew()
                {
                    Code = cols[0],
                    Dkey = cols[1],
                    GJCount = int.Parse(cols[2]),
                    CJCount = int.Parse(cols[3]),
                    HBFHFloat = decimal.Parse(cols[4]),
                    TJCount = int.Parse(cols[5]),
                    SubTJCount = int.Parse(cols[6]),
                });
            }
            Dictionary<string, List<Model.ConfigDictionaryNew>> list = new Dictionary<string, List<Model.ConfigDictionaryNew>>();
            foreach (Model.ConfigDictionaryNew item in ConfigDictionaryList)
            {
                if (list.Keys.Contains(item.Code))
                    list[item.Code].Add(item);
                else
                    list.Add(item.Code, new List<Model.ConfigDictionaryNew>() { item });
            }
            return list;
        }

        private Dictionary<string, List<Model.NConfigDictionary>> GetNConfigDictionaryList()
        {
            List<Model.NConfigDictionary> ConfigDictionaryList = new List<Model.NConfigDictionary>();
            StringBuilder sb = new StringBuilder();
            int jishuqi = 0;
            foreach (string key in Request.Form.Keys)
            {
                if (key.Contains("GridView4"))
                {
                    jishuqi++;
                    sb.Append(Request.Form[key]);
                    if (jishuqi % 7 != 0)
                        sb.Append("|");
                    else
                        sb.Append("≌");
                }
            }
            string[] rows = sb.ToString().Split('≌');

            foreach (string row in rows)
            {
                if (string.IsNullOrEmpty(row))
                    continue;
                string[] cols = row.Split('|');
                ConfigDictionaryList.Add(
                new Model.NConfigDictionary()
                {
                    NDTpye = cols[0],
                    Remark = cols[1],
                    StartLevel = int.Parse(cols[2]),
                    EndLevel = int.Parse(cols[3]),
                    StartRec = int.Parse(cols[4]),
                    EndRec = int.Parse(cols[5]),
                    DValue = cols[6],
                    DKey = ""
                });
            }
            Dictionary<string, List<Model.NConfigDictionary>> list = new Dictionary<string, List<Model.NConfigDictionary>>();
            foreach (Model.NConfigDictionary item in ConfigDictionaryList)
            {
                if (list.Keys.Contains(item.NDTpye))
                    list[item.NDTpye].Add(item);
                else
                    list.Add(item.NDTpye, new List<Model.NConfigDictionary>() { item });
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnModify_Click()
        {
            if (BllModel.UpdateConfiguration(ConfigurationModel))
            {
                BLL.OperationRecordBLL.Add(TModel.MID, ChangeType.O_XGJJCS, "修改奖金参数");
                return "操作成功";
            }
            else
                return "操作失败";
        }

        protected override string btnOther_Click()
        {
            if (BllModel.ReSetSys())
            {
                return "操作成功";
            }
            else
                return "操作失败";
        }

        protected override string btnAdd_Click()
        {
            if (Request.QueryString["type"] == "1")
            {
                if (BllModel.MemberHBClear())
                    return "操作成功";
                return "操作失败";
            }
            else if (Request.QueryString["type"] == "2")
            {
                if (BllModel.MemberHBToJB())
                    return "操作成功";
                return "操作失败";
            }
            else
                return "参数异常";
        }
        /// <summary>
        /// 【现金币】 转 【循环币】 是否开启
        /// </summary>
        /// <returns></returns>
        protected string btnTranMoney_Click()
        {
            if (Request.QueryString["type"] == "1")
            {
                //这里需要换上自己的方法
                if (BLL.Configuration.IsTranMoney(true))
                    return "操作成功";
                return "操作失败";
            }
            else if (Request.QueryString["type"] == "2")
            {
                if (BLL.Configuration.IsTranMoney(false))
                    return "操作成功";
                return "操作失败";
            }
            else
                return "参数异常";
        }
        /// <summary>
        /// 在 GridView 控件中的某个行被绑定到一个数据记录时发生。此事件通常用于在某个行被绑定到数据时修改该行的内容。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }
    }
}