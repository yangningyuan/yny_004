<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvestApply.aspx.cs" Inherits="yny_004.Web.Module.Investment.InvestApply" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        $(function () {
            tUrl = "Module/Investment/Handler/InvestList.ashx";
            tState = "";
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
        <div id="finance">
            <form id="form1">
                <input type="hidden" id="bankauto" runat="server" />
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="right">
                            <span><%=yny_004.BLL.Reward.List["MJB"].RewardName %>:</span>
                        </td>
                        <td>
                            <%=TModel.MConfig.MJB.ToFixedString() %>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span>投资金额:</span>
                        </td>
                        <td>
                            <input name="txtMHB" id="txtMHB" class="normal_input" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span>选择币种:</span>
                        </td>
                        <td>
                            <input id="Radio1" value="MJB" type="radio" name="rdo" checked="checked" /><%=yny_004.BLL.Reward.List["MJB"].RewardName %>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <input class="btn btn-success" id="btnOK" type="button" runat="server" value="提交"
                                onclick="checkChange();" />
                        </td>
                    </tr>
                </table>
            </form>
        </div>
        <div class="control">
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <%--<input type="button" value="导出Excel" class="btn btn-success" onclick="exportExcel()" />--%>
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
                    <th>收益天数
                    </th>
                    <th>累计收益
                    </th>
                    <th>投资币种
                    </th>
                    <th>状态
                    </th>
                    <th>操作
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn" id="divOperator" runat="server">
                </div>
                <div class="pagebar">
                    <div id="Pagination">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if ($('#txtMHB').val().trim() == "") {
                v5.error('投资金额不能为空', '1', 'true');
                return;
            }
            if ($('#bankauto').val().Trim() == "0") {
                layer.alert('您的个人资料尚未绑定，需先绑定后才可继续操作', {
                    skin: 'layui-layer-lan',
                    closeBtn: 0
                }, function () {
                    callhtml('/Member/Modify.aspx', '完善资料'); onclickMenu();
                    layer.closeAll();
                });
                return;
            }

            verifypsd(function () {
                $.ajax({
                    type: 'post',
                    url: "Module/Investment/InvestApply.aspx?Action=add",
                    data: $('#form1').serialize(),
                    success: function (info) {
                        v5.alert(info, '1', 'true');
                        if (info == "申请成功") {
                            callhtml("Module/Investment/InvestApply.aspx", "申请投资");
                        }
                    }
                });
            });
        }
    </script>
</body>
</html>
