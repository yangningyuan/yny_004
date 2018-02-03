using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;

namespace yny_004.Web.ExportExcel
{

    /// <summary>
    /// 代付文件生成器
    /// </summary>
    public class AgentPayFileBuilder
    {
        public AgentPayInfo AgentPayInfo { get; private set; }

        public AgentPayFileBuilder(AgentPayInfo agentPayInfo)
        {
            if (agentPayInfo == null) throw new ArgumentNullException(nameof(agentPayInfo));
            AgentPayInfo = agentPayInfo;
        }

        private int BuildFileHead(ISheet sheet)
        {
            #region 注释

            //#region 代付明细表标题
            //var firstRow = sheet.CreateRow(0);
            //var titleCell = firstRow.CreateCell(0);
            //titleCell.SetCellValue("代付明细表");
            //titleCell.SetCellType(CellType.String);

            //sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 6));  //合并标题单元格
            //#endregion

            //#region 版本号和打印日期
            //var versionAndPrintDate = sheet.CreateRow(1);

            //var versionLabelCell = versionAndPrintDate.CreateCell(0);
            //versionLabelCell.SetCellValue("版本号");
            //versionLabelCell.SetCellType(CellType.String);

            //var versionContentCell = versionAndPrintDate.CreateCell(1);
            //versionContentCell.SetCellValue(AgentPayInfo.Version);
            //versionContentCell.SetCellType(CellType.String);

            //var printDateLabelCell = versionAndPrintDate.CreateCell(7);
            //printDateLabelCell.SetCellValue("打印日期");
            //printDateLabelCell.SetCellType(CellType.String);

            //var printDateContentCell = versionAndPrintDate.CreateCell(8);
            //printDateContentCell.SetCellValue(AgentPayInfo.PrintDate);
            //printDateContentCell.SetCellType(CellType.String);

            //sheet.AddMergedRegion(new CellRangeAddress(1, 1, 1, 6));
            //#endregion

            //#region 商户信息标题

            //var merchantInfoTitleRow = sheet.CreateRow(2);

            //var merchantInfoTitleCell = merchantInfoTitleRow.CreateCell(0);
            //merchantInfoTitleCell.SetCellValue("商户信息");
            //merchantInfoTitleCell.SetCellType(CellType.String);

            //sheet.AddMergedRegion(new CellRangeAddress(2, 2, 0, 8));
            //#endregion

            //#region 商户名称和商户号
            //var merchantNameAndIDRow = sheet.CreateRow(3);
            //var merchantNameLabelCell = merchantNameAndIDRow.CreateCell(0);
            //merchantNameLabelCell.CellValue("商户名称").StringCell();

            //var merchantNameContentCell = merchantNameAndIDRow.CreateCell(1);
            //merchantNameContentCell.CellValue(AgentPayInfo.MerchantName).StringCell();

            //var merchantIDLabelCell = merchantNameAndIDRow.CreateCell(4);
            //merchantIDLabelCell.CellValue("商户号").StringCell();

            //var merchantIDContentCell = merchantNameAndIDRow.CreateCell(5);
            //merchantIDContentCell.CellValue(AgentPayInfo.MerchantID).StringCell();

            //sheet.AddMergedRegion(new CellRangeAddress(3, 3, 1, 3));
            //sheet.AddMergedRegion(new CellRangeAddress(3, 3, 5, 8));

            //#endregion

            //#region 联系人和联系电话

            //var contactAndContactNumberRow = sheet.CreateRow(4);
            //var contactLabelCell = contactAndContactNumberRow.CreateCell(0);
            //contactLabelCell.CellValue("联系人").StringCell();

            //var contactContentCell = contactAndContactNumberRow.CreateCell(1);
            //contactContentCell.CellValue(AgentPayInfo.Contact).StringCell();

            //var contactNumberLabelCell = contactAndContactNumberRow.CreateCell(4);
            //contactNumberLabelCell.CellValue("联系人电话").StringCell();

            //var contactNumberContentCell = contactAndContactNumberRow.CreateCell(5);
            //contactNumberContentCell.CellValue(AgentPayInfo.ContactNumber).StringCell();

            //sheet.AddMergedRegion(new CellRangeAddress(4, 4, 1, 3));
            //sheet.AddMergedRegion(new CellRangeAddress(4, 4, 5, 8));
            //#endregion

            //#region 商户批次号

            //var merchantBatchNumberRow = sheet.CreateRow(5);
            //var merchantBatchNumberLabelCell = merchantBatchNumberRow.CreateCell(0);
            //merchantBatchNumberLabelCell.CellValue("商户批次号").StringCell();

            //var merchantBatchNumberContentCell = merchantBatchNumberRow.CreateCell(1);
            //merchantBatchNumberContentCell.CellValue(AgentPayInfo.MerchantBatchNumber).StringCell();

            //sheet.AddMergedRegion(new CellRangeAddress(5, 5, 1, 8));
            //#endregion

            //#region 订单信息标题

            //var orderInfoTitleRow = sheet.CreateRow(6);
            //var orderInfoTitleCell = orderInfoTitleRow.CreateCell(0);
            //orderInfoTitleCell.CellValue("订单信息").StringCell();

            //sheet.AddMergedRegion(new CellRangeAddress(6, 6, 0, 8));
            //#endregion

            #endregion 注释

            #region 订单信息

            //第一行
            var m0 = sheet.CreateRow(0);

            var m00 = m0.CreateCell(0);
            m00.CellValue("国付宝账号").StringCell();

            var m0l = m0.CreateCell(1);
            m0l.CellValue("注册国付宝Email").StringCell();

            var m02 = m0.CreateCell(2);
            m02.CellValue("总金额（元）").StringCell();

            var m03 = m0.CreateCell(3);
            m03.CellValue("总笔数").StringCell();

            var m04 = m0.CreateCell(4);
            m04.CellValue("日期").StringCell();

            //第二行
            var m1 = sheet.CreateRow(1);

            var m10 = m1.CreateCell(0);
            m10.CellValue(AgentPayInfo.MerchantID).StringCell();

            var m1l = m1.CreateCell(1);
            m1l.CellValue(AgentPayInfo.Contact).StringCell();

            var m12 = m1.CreateCell(2);
            m12.CellValue(AgentPayInfo.MerchantName).StringCell();

            var m13 = m1.CreateCell(3);
            m13.CellValue(AgentPayInfo.Version).StringCell();

            var m14 = m1.CreateCell(4);
            m14.CellValue("").StringCell();

            #endregion 订单信息


            #region 订单表格标题
            var orderTableCellRow = sheet.CreateRow(2);

            orderTableCellRow.CreateCell(0).CellValue("商户流水号").StringCell();
            orderTableCellRow.CreateCell(1).CellValue("收款银行户名").StringCell();
            orderTableCellRow.CreateCell(2).CellValue("收款银行账号").StringCell();
            orderTableCellRow.CreateCell(3).CellValue("收款开户银行").StringCell();
            orderTableCellRow.CreateCell(4).CellValue("收款开户网点名称").StringCell();
            orderTableCellRow.CreateCell(5).CellValue("开户行省份").StringCell();
            orderTableCellRow.CreateCell(6).CellValue("开户行所在市").StringCell();
            orderTableCellRow.CreateCell(7).CellValue("金额").StringCell();
            orderTableCellRow.CreateCell(8).CellValue("对公私标识").StringCell();
            orderTableCellRow.CreateCell(9).CellValue("备注").StringCell();

            #endregion

            return 3;
        }

        /// <summary>
        /// 生成订单项行
        /// </summary>
        /// <param name="sheet"></param>
        private void BuildOrderItemRow(ISheet sheet, int rowID, OrderItemInfo orderItemInfo)
        {
            var row = sheet.CreateRow(rowID);
            row.CreateCell(0).CellValue(orderItemInfo.OrderCode).StringCell();
            row.CreateCell(1).CellValue(orderItemInfo.Name).StringCell();
            row.CreateCell(2).CellValue(orderItemInfo.BankNumber).StringCell();
            row.CreateCell(3).CellValue(orderItemInfo.Bank).StringCell();
            row.CreateCell(4).CellValue(orderItemInfo.BankName).StringCell();
            row.CreateCell(5).CellValue(orderItemInfo.Provice).StringCell();
            row.CreateCell(6).CellValue(orderItemInfo.City).StringCell();
            row.CreateCell(7).CellValue(orderItemInfo.Amount.ToString("0.00")).StringCell();
            row.CreateCell(8).CellValue(orderItemInfo.AccountType).StringCell();
            row.CreateCell(9).CellValue(orderItemInfo.Remarks).StringCell();
        }

        public IWorkbook BuildWorkbook(IEnumerable<OrderItemInfo> orderItems)
        {
            //IWorkbook workBook = new XSSFWorkbook();
            IWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("代付明细表");
            var rowID = BuildFileHead(sheet);

            foreach (var orderItemInfo in orderItems)
            {
                BuildOrderItemRow(sheet, rowID, orderItemInfo);
                rowID++;
            }
            return workbook;
        }
    }

    public static class NpoiExtensions
    {
        public static ICell CellValue(this ICell self, string cellValue)
        {
            self.SetCellValue(cellValue);
            return self;
        }
        public static ICell CellValue(this ICell self, bool cellValue)
        {
            self.SetCellValue(cellValue);
            return self;
        }

        public static ICell CellValue(this ICell self, DateTime cellValue)
        {
            self.SetCellValue(cellValue);
            return self;
        }

        public static ICell CellValue(this ICell self, double cellValue)
        {
            self.SetCellValue(cellValue);
            return self;
        }

        public static ICell CellValue(this ICell self, IRichTextString cellValue)
        {
            self.SetCellValue(cellValue);
            return self;
        }

        public static ICell CellType(this ICell self, CellType cellType)
        {
            self.SetCellType(cellType);
            return self;
        }

        public static ICell StringCell(this ICell self)
        {
            return self.CellType(NPOI.SS.UserModel.CellType.String);
        }
    }
}