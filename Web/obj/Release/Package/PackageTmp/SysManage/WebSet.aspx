<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebSet.aspx.cs" Inherits="yny_004.Web.SysManage.WebSet" %>

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
                    <td width="20%" align="right">
                        网站标题:
                    </td>
                    <td width="30%">
                        <input id="txtWebTitle" runat="server" class="normal_input" style="width: 80%;" type="text"
                            maxlength="255" />
                    </td>
                    <td width="20%" align="right">
                        网站状态:
                    </td>
                    <td width="30%">
                        <input id="rdoOpen" name="rdoState" runat="server" value="true" type="radio" />开放&nbsp;
                        <input id="rdoClose" name="rdoState" runat="server" value="false" type="radio" />关闭
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        SEO关键字:
                    </td>
                    <td colspan="3">
                        <input id="txtWKeyword" runat="server" class="normal_input" style="width: 80%;" type="text"
                            maxlength="255" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        SEO描述:
                    </td>
                    <td colspan="3">
                        <input id="txtWDescription" runat="server" class="normal_input" style="width: 80%;"
                            type="text" maxlength="255" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        版权信息:
                    </td>
                    <td colspan="3">
                        <input id="txtWCopyright" runat="server" class="normal_input" style="width: 80%;"
                            type="text" maxlength="255" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        开放时间:
                    </td>
                    <td colspan="3">
                        <input id="txtOpenTimeStr" runat="server" class="normal_input" style="width: 80%;"
                            type="text" maxlength="100" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        关闭信息:
                    </td>
                    <td colspan="3">
                        <input id="txtCloseInfo" runat="server" class="normal_input" style="width: 80%;"
                            type="text" maxlength="255" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        提现提示:
                    </td>
                    <td colspan="3">
                        <input id="txtTXInfo" runat="server" class="normal_input" style="width: 80%;" type="text"
                            maxlength="255" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        汇款提示:
                    </td>
                    <td colspan="3">
                        <input id="txtHKInfo" runat="server" class="normal_input" style="width: 80%;" type="text"
                            maxlength="255" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        单页行数:
                    </td>
                    <td colspan="3">
                        <input id="txtPageSize" runat="server" class="normal_input" type="text" maxlength="20" />
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td colspan="2" align="right">
                        <input name="重置" type="reset" class="normal_btnok" value="重置" style="display:none;" />
                    </td>
                    <td colspan="2" align="left">
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            ActionModel("SysManage/WebSet.aspx?Action=Modify", $('#form1').serialize());
        }
    </script>
</body>
</html>
