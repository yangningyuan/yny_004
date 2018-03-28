<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KFChange.aspx.cs" Inherits="yny_004.Web.ChangeMoney.KFChange" %>

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
                            <input name="txtMID" id="txtMID" class="normal_input" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span>扣费钱包：</span>
                        </td>
                        <td>
                            <select runat="server" id="kfType">
                                <option value="MHB">余额</option>
                                <option value="MJB">公排复投币</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span>扣费金额：</span>
                        </td>
                        <td>
                            <input name="txtMHB" id="txtMHB" maxlength="6" class="normal_input" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span>扣费说明：</span>
                        </td>
                        <td>
                            <input name="txtRemark" id="txtRemark" class="normal_input" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input name="重置" type="reset" class="pay_reset" value="重置" style="display: none;" />
                        </td>
                        <td>
                            <input class="normal_btnok" id="Button1" type="button" runat="server" value="提交"
                                onclick="checkChange();" />
                        </td>
                    </tr>
                </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if ($('#txtMID').val().Trim() == "") {
                v5.error('会员ID不能为空', '1', 'true');
            } else if ($('#txtMHB').val().Trim() == "") {
                v5.error('扣费金额不能为空', '1', 'true');
            } else if (!$('#txtMHB').val().TryInt()) {
                v5.error('扣费金额应该为整数', '1', 'true');
            } else {
                ActionModel("ChangeMoney/KFChange.aspx?Action=Add", $('#form1').serialize());
                setTimeout(function () {
                    v5.show('ChangeMoney/KFChange.aspx', '会员扣费', 'url', 620, 400);
                }, 1000);
            }
        }
    </script>
</body>
</html>
