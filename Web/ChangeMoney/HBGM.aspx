<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HBGM.aspx.cs" Inherits="yny_004.Web.ChangeMoney.HBGM"
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
                    <td width="35%" align="right">
                        <span>会 员ID:</span>
                    </td>
                    <td>
                        <input id="txtMID" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>充值金额:</span>
                    </td>
                    <td>
                        <input name="txtMHB" id="txtMHB" class="normal_input" type="text" maxlength="9" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>充值钱包:</span>
                    </td>
                    <td>
                        <input id="rdoMJB" value="MJB" type="radio" name="rdo" checked="checked" /><%=yny_004.BLL.Reward.List["MJB"].RewardName %>
                        <input id="rdoMHB" value="MHB" type="radio" name="rdo"  /><%=yny_004.BLL.Reward.List["MHB"].RewardName %>
                       <%-- <input id="rdoMCW" value="MCW" type="radio" name="rdo"  /><%=yny_004.BLL.Reward.List["MCW"].RewardName %>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <input class="btn btn-success" id="btnOK" type="button" runat="server" value="提交"
                            onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if ($('#txtMHB').val().Trim() == "") {
                v5.error('充值金额不能为空', '1', 'true');
                return;
            }
            else {
                var reg1 = /^\d+$/;
                if (!reg1.test(parseInt($('#txtMHB').val()))) {
                    v5.error('充值金额应该为正数', '1', 'true');
                    return;
                }
            } if (RunAjaxGetKey('getMName', $('#txtMID').val()) == '') {
                v5.error('不存在购买会员', '1', 'true');
                return;
            }
            ActionModel("ChangeMoney/HBGM.aspx?Action=add", $('#form1').serialize());
        }
    </script>
</body>
</html>
