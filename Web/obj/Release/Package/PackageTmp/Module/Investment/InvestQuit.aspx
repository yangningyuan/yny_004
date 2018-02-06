<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvestQuit.aspx.cs" Inherits="yny_004.Web.Module.Investment.InvestQuit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        $(function () {
            tUrl = "Module/Investment/Handler/InvestQuit.ashx";
            tState = "false";
            SearchByCondition();
        })

        // 导出Excel
        function exportExcel() {
            ExportExcel("ChangeMoney/Handler/ExportExcel.ashx", "THLBExcel");
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0)" onclick="SearchByState('false',this);hideDiv('divOperator',true);" class="btn btn-danger">未审核</a>
                <a href="javascript:void(0)" onclick="SearchByState('true',this);hideDiv('divOperator',false);" class="btn btn-success">已审核</a>
            </div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <%--<input type="button" value="导出Excel" class="btn btn-success" onclick="exportExcel()" />--%>
                <input name="txtKey" data-name="txtKey" id="mKey" value="请输入会员账号" onfocus="if (value =='请输入会员账号'){value =''}"
                    onblur="if (value ==''){value='请输入会员账号'}" type="text" class="sinput" />
                <input type="text" name="txtKey" data-name="txtKey" id="startDate" value="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({ maxDate: '#F{$dp.$D(\'endDate\')}' })" />
                <input type="text" name="txtKey" data-name="txtKey" id="endDate" value="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({ minDate: '#F{$dp.$D(\'startDate\')}' })" />
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
                    <th>会员姓名
                    </th>
                    <th>投资时间
                    </th>
                    <th>投资金额
                    </th>
                    <th>实际退本
                    </th>
                    <th>收益天数
                    </th>
                    <th>累计收益
                    </th>
                    <th>状态
                    </th>
                    <th>退本时间
                    </th>
                    <th>操作
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn" id="divOperator" runat="server">
                    <a href="javascript:void(0);" title="审核" onclick="RunAjaxByListInvest('Audit',',');">审核</a>
                    <a href="javascript:void(0);" title="拒绝" onclick="RunAjaxByListInvest('refuse',',');">拒绝</a>
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
