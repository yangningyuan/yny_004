<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HBToJBChange.aspx.cs" Inherits="yny_004.Web.ChangeMoney.HBToJBChange"
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
                    <td align="right">
                        <span>我的<%=yny_004.BLL.Reward.List["MHB"].RewardName %>：</span>
                    </td>
                    <td>
                        <%=TModel.MConfig.MHB%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>我的<%=yny_004.BLL.Reward.List["MJB"].RewardName %>：</span>
                    </td>
                    <td>
                        <%=TModel.MConfig.MJB%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>兑换金额：</span>
                    </td>
                    <td>
                        <input name="txtMHB" id="txtMHB" class="normal_input" type="text" maxlength="6" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>兑换钱包：</span>
                    </td>
                    <td>
                        <select id="ddlFrom" runat="server">
                            <option value="MHB">奖金币</option>
                        </select>
                        转换为<select id="ddlTo" runat="server">
                            <option value="MJB">现金币</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if ($('#txtMHB').val().Trim() == "") {
                v5.error('转账金额不能为空', '1', 'true');
            } else if (!$('#txtMHB').val().TryInt()) {
                v5.error('转换金额应该为整数', '1', 'true');
            } else if (!$('#txtMHB').val().TryInt()) {
                v5.error('转换金额应该为整数', '1', 'true');
            } else {
                ActionModel("/ChangeMoney/HBToJBChange.aspx?Action=add", $('#form1').serialize());
            }
        }
    </script>
</body>
</html>
