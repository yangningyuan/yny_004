<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TXChange.aspx.cs" Inherits="yny_004.Web.ChangeMoney.TXChange"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="15%" align="right">
                        <span>会员ID：</span>
                    </td>
                    <td width="35%">
                        <b id="bMID">
                            <%=TModel.MID %></b>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>会员姓名：</span>
                    </td>
                    <td width="35%">
                        <%=TModel.MName %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>可用<%=yny_004.BLL.Reward.List["MHB"].RewardName %>：</span>
                    </td>
                    <td class="tdAvalibleMoney">
                        <%=TModel.MConfig.MJJ.ToString("F2")%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>提现钱包：</span>
                    </td>
                    <td class="tdAvalibleMoney">
                        <select id="ddlFrom" name="ddlFrom">
                            <option value="MHB">余额</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>提现金额：</span>
                    </td>
                    <td>
                        <input name="txtMHB" id="txtMHB" maxlength="6" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input name="重置" type="reset" class="pay_reset" value="重置" style="display: none;" />
                    </td>
                    <td>
                        <input class="normal_btnok" id="Button1" type="button" runat="server" value="提交"
                            onclick="checkChange();" />
                        <div id="divTips" runat="server" style="color: Red">
                            您的账号暂不能提现，请联系管理员！</div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <span class="remak">
                            <%=WebModel.TXInfo %>
                        </span>
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if ($('#txtMHB').val().Trim() == "") {
                v5.error('提现金额不能为空', '1', 'true');
            } else if (!$('#txtMHB').val().TryInt()) {
                v5.error('提现金额应该为整数', '1', 'true');
                //            } else if ($('#bcardNum').html().Trim() == "") {
                //                v5.error('请先在[信息管理]－[银行卡管理]中添加提现银行卡', '1', 'true');
            } else {
                //                var avalibleMoney = $(".tdAvalibleMoney").text().Trim().TryFloat();
                //                var txMoney = $('#txtMHB').val().Trim().TryInt();
                //                if (parseFloat($('#txtMHB').val().Trim()) > parseFloat($(".tdAvalibleMoney").text().Trim())) {
                //                    v5.error('可用奖金不足', '1', 'true');
                //                } else {
                ActionModel("ChangeMoney/TXChange.aspx?Action=Add", $('#form1').serialize());
                //                }
            }
        }
    </script>
</body>
</html>
