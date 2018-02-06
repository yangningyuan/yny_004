<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TXList.aspx.cs" Inherits="yny_004.Web.ChangeMoney.TXList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        tState = 'false';
        tUrl = 'ChangeMoney/Handler/TXList.ashx';
        SearchByCondition();

        // 导出Excel
        function exportExcel() {
            ExportExcel("ChangeMoney/Handler/ExportExcel.ashx", "TXExcel");
        }
        // 导出Excel
        function exportExcel1() {
            ExportExcel("ChangeMoney/Handler/ExportExcel.ashx", "TXExcel1");
        }
        // 导出Excel
        function exportExcelYT() {
            ExportExcel("ChangeMoney/Handler/ExportExcel.ashx", "exportExcelYT");
        }
        // 导出Excel
        function exportExcelKLT() {
            ExportExcel("ChangeMoney/Handler/ExportExcel.ashx", "exportExcelKLT");
        }
        // 导出Excel
        function exportExcelKLT1() {
            ExportExcel("ChangeMoney/Handler/ExportExcel.ashx", "exportExcelKLT1");
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0);" onclick="SearchByState('false',this);hideDiv('DivOperation',true);" class="btn btn-danger">未审核</a>
                <a href="javascript:void(0)" onclick="SearchByState('true',this);hideDiv('DivOperation',false);" class="btn btn-success">已审核</a>
            </div>
            <div class="pay" onclick="v5.show('ChangeMoney/TXChange.aspx','申请提现','url',620,400)">
                申请提现
            </div>
            <div class="search" id="DivSearch" runat="server">
                <%-- <input type="button" value="一键审核" class="ssubmit" onclick="RunAjaxByList11('', 'SHAllTX', ',')" />--%>
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <%--<a href="/ChangeMoney/TXList.aspx?Action=Add" target="_blank" class="btn btn-success">国付宝格式</a>--%>
                <%--<input type="button" value="导出Excel" class="btn btn-success" onclick="exportExcelYT()" />--%>
                <%--<input type="button" value="首信易格式" class="btn btn-success" onclick="exportExcel1()" />--%>
                <%--<input type="button" value="工行格式" class="btn btn-success" onclick="exportExcel()" />--%>
                <input type="button" value="开联通导出" class="btn btn-success" onclick="exportExcelKLT()" />
                <input name="txtKey" data-name="txtKey" id="mKey" placeholder="请输入会员账号" value="请输入会员账号" type="text"
                    class="sinput" />
                <input type="text" name="txtKey" data-name="txtKey" id="startDate" placeholder="开始日期" value="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({ maxDate: '#F{$dp.$D(\'endDate\')}' })" />
                <input type="text" name="txtKey" data-name="txtKey" id="endDate" placeholder="截止日期" value="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({ minDate: '#F{$dp.$D(\'startDate\')}' })" />
            </div>
            <div class="cheeckbox" style="float: right; min-width: 140px;">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <label style="color: white">
                                累计提现：</label>
                        </td>
                        <td style="color: white">已审核:<%=txCheked.ToString("F0")%>
                        </td>
                        <td style="color: white">未审核:<%=txUnCheked.ToString("F0")%>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" id="Result" class="tabcolor">
                <tr>
                    <th width="50px">全选
                    </th>
                    <th>序号
                    </th>
                    <th>会员账号
                    </th>
                    <th>开户省
                    </th>
                    <th>开户市
                    </th>
                    <th>开户行
                    </th>
                    <th>支行
                    </th>
                    <th>户名
                    </th>
                    <th>卡号
                    </th>
                    <th>提现
                    </th>
                    <%--<th>
                        手续费
                    </th>--%>
                    <th>实发
                    </th>
                    <th>提现币种
                    </th>
                    <th>是否批准
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
                    <span id="DivOperation" runat="server"><a href="javascript:void(0);" title="" onclick="RunAjaxByList('false','SHTX',',');">审核</a><a href="javascript:void(0);" title="删除" onclick="RunAjaxByList('false','Cancel_TX',',');">删除</a></span>

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
