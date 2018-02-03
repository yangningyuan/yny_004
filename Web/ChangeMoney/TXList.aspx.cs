using System;
using System.Data;
using System.Linq;
using yny_004.Web.ExportExcel;

namespace yny_004.Web.ChangeMoney
{
    public partial class TXList : BasePage
    {
        protected decimal txCheked = 0;
        protected decimal txUnCheked = 0;
        protected override void SetPowerZone()
        {
            if (!TModel.Role.IsAdmin)
            {
                DivSearch.InnerHtml = "";
                DivOperation.InnerHtml = "";

                txCheked = TModel.MConfig.TotalTXMoney;
                txUnCheked = BLL.ChangeMoney.GetTXMoney(" ChangeType = 'TX' and FromMID = '" + TModel.MID + "' and CState = 0");
            }
            else
            {
                txCheked = BLL.ChangeMoney.GetTXMoney(" ChangeType = 'TX' and CState = 1 ");
                txUnCheked = BLL.ChangeMoney.GetTXMoney(" ChangeType = 'TX' and CState = 0 ");
            }
        }

        protected override string btnAdd_Click()
        {

            if (IsAdmin == false) return string.Empty;

            var rows = SQLServerHelper.GetDataSet(@"
			SELECT CM.CID,CM.ChangeDate,M.BankCardName,NumID,Tel,Bank,Province,City,Branch,BankNumber,([Money] - [TakeOffMoney]) 'RMB' FROM ChangeMoney AS CM INNER JOIN Member AS M ON(CM.FromMID = M.MID)
			WHERE ChangeType = 'TX' AND CState = 0 ").Tables[0].AsEnumerable();

            var items = rows.Select(x =>
            {
                var orderCode = x.Field<DateTime>("ChangeDate").ToString("yyyyMMddHHmmssfff") + x.Field<int>("CID");
                return new OrderItemInfo()
                {
                    OrderCode = orderCode,
                    Name = x.Field<string>("BankCardName"),
                    BankNumber = x.Field<string>("BankNumber"),
                    Bank = x.Field<string>("Bank"),
                    BankName = x.Field<string>("Branch"),
                    Provice = x.Field<string>("Province"),
                    City = x.Field<string>("City"),
                    Amount = Convert.ToDouble(Math.Round(x.Field<decimal>("RMB"), 2)),
                    AccountType = "2",
                    Remarks = "福利费"
                };
            });

            // DateTime.Now.ToString("yyyyMMddHHmmss")
            AgentPayInfo info = new AgentPayInfo() { Contact = "2395326457@qq.com", MerchantID = "0000000002000010017", Version = items.Count().ToString(), MerchantName = items.Sum(m => m.Amount).ToString("F2"), };
            AgentPayFileBuilder builder = new AgentPayFileBuilder(info);
            WriteWorkbook(builder.BuildWorkbook(items), string.Format("下发数据_{0}.xls", DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss")));
            return string.Empty;
        }
    }
}