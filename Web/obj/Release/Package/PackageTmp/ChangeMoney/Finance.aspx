<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Finance.aspx.cs" Inherits="yny_004.Web.ChangeMoney.Finance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>财务流水</title>
    <script type="text/javascript">
        tUrl = "ChangeMoney/Handler/Finance.ashx";
        SearchByCondition();

        // 导出Excel
        function exportExcel() {
            ExportExcel("ChangeMoney/Handler/ExportExcel.ashx", "BBLSExcel");
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <%--<input type="button" value="导出Excel" class="btn btn-success" onclick="exportExcel()" />--%>
                <input type="text" name="txtKey" data-name="txtKey" id="startDate" placeholder="开始日期"
                    value="开始日期" onfocus="if (value =='开始日期'){value =''}" class="daycash_input" style="width: 120px;"
                    onclick="WdatePicker({ maxDate: '#F{$dp.$D(\'endDate\')}' })" />
                <input type="text" name="txtKey" data-name="txtKey" id="endDate" placeholder="截止日期"
                    value="截止日期" class="daycash_input" style="width: 120px;" onclick="WdatePicker({ minDate: '#F{$dp.$D(\'startDate\')}' })" />
            </div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" class="tabcolor" id="Result">
                <tr>
                    <th width="50px">全选
                    </th>
                    <th>序号
                    </th>
                    <th>报单业绩
                    </th>
                    <th>会员充值
                    </th>
                    <th>奖金拨出
                    </th>
                    <th>管理费
                    </th>
                    <th>重复消费
                    </th>
                    <th>提现申请
                    </th>
                    <th>拨出比率
                    </th>
                    <th>日期
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <%--<a href="javascript:void(0);" onclick="javascript:tableToExcel('Result')">导出Excel</a>--%>
                </div>
                <div class="pagebar">
                    <div id="Pagination">
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
