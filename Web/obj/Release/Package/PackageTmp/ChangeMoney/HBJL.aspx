<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HBJL.aspx.cs" Inherits="yny_004.Web.ChangeMoney.HBJL"
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
                        <span>会 员ID：</span>
                    </td>
                    <td>
                        <input id="txtMID" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>奖励金额:</span>
                    </td>
                    <td>
                        <input name="txtMHB" id="txtMHB" class="normal_input" type="text" maxlength="6" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>奖项类型：</span>
                    </td>
                    <td>
                        <select id="ddlChangeType" runat="server">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <input class="btn btn-success" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if ($('#txtMHB').val().Trim() == "") {
                v5.error('奖励金额不能为空', '1', 'true');
            }
            else if (RunAjaxGetKey('getMName', $('#txtMID').val()) == '') {
                v5.error('不存在奖励会员', '1', 'true');
                return;
            } else {
                ActionModel("ChangeMoney/HBJL.aspx?Action=add", $('#form1').serialize());
            }
        }
    </script>
</body>
</html>
