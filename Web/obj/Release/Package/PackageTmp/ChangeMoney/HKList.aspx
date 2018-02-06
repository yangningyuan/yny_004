<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HKList.aspx.cs" Inherits="yny_004.Web.ChangeMoney.HKList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        tState = 'false';
        tUrl = 'ChangeMoney/Handler/HKList.ashx';
        SearchByCondition();
        function displayA(isShow) {
            if (isShow) {
                $("#DivOperation").show();
            } else {
                $("#DivOperation").hide();
            }
        }

        // 导出Excel
        function exportExcel() {
            ExportExcel("ChangeMoney/Handler/ExportExcel.ashx", "HKJLExcel");
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0)" onclick="SearchByState('false',this);displayA(true);"
                    class="btn btn-danger">未生效</a> <a href="javascript:void(0);" onclick="SearchByState('true',this);displayA(false);"
                        class="btn btn-success">已生效</a>
            </div>
            <div class="pay" onclick="v5.show('ChangeMoney/HKChangeFlow.aspx','支付宝快速入金','url',680,330)">
                支付宝快速入金
            </div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <%--<input type="button" value="导出Excel" class="btn btn-success" onclick="exportExcel()" />--%>
                <input name="txtKey" data-name="txtKey" id="mKey" placeholder="请输入会员账号" type="text" class="sinput" />
                <input type="text" name="txtKey" data-name="txtKey" id="startDate" placeholder="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({ maxDate: '#F{$dp.$D(\'endDate\')}' })" />
                <input type="text" name="txtKey" data-name="txtKey" id="endDate" placeholder="截止日期" onfocus="if (value =='截止日期'){value =''}"
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
                    <%--<th>
                        流水号
                    </th>--%>
                    <th>会员账号
                    </th>
                    <%--<th>
                        会员姓名
                    </th>--%>
                    <th>充值币种
                    </th>
                    <th>实际汇款
                    </th>
                    <th>充值金额
                    </th>
                    <th>日期
                    </th>
                    <th>是否生效
                    </th>
                    <th>汇款方式
                    </th>
                    <th>汇款截图
                    </th>
                    <th>支付宝姓名
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <span id="DivOperation" runat="server"><a href="javascript:void(0);" title="" onclick="RunAjaxByList('false','shHKModel',',');">审核</a></span> <a href="javascript:void(0);" title="" onclick="RunAjaxByList('false','del_HKModel',',');">删除</a>
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
