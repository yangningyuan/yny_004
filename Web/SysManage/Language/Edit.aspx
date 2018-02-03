<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="yny_004.Web.Language.Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <input id="hidId" type="hidden" runat="server" />
            <input id="hidExcelPath" type="hidden" runat="server" />
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="15%" align="right">
                        <span>中文名称：</span>
                    </td>
                    <td width="35%">
                        <input id="txtZHName" runat="server" style="width: 40%" class="pay_input" type="text"
                            require-type="require" require-msg="中文名称" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>对应名称：</span>
                    </td>
                    <td>
                        <input id="txtENName" style="width: 40%" runat="server" require-type="require" class="pay_input"
                            require-msg="对应名称" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>翻译语言：</span>
                    </td>
                    <td>
                        <select id="LanageList" runat="server">
                            <option value="EN">英文</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>是否启用：</span>
                    </td>
                    <td width="35%">
                        <input id="chkStatus" runat="server" type="checkbox" value="1" checked="checked" />
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
            if (checkForm())
                ActionModelBackWithTitleWithNoVerify("/SysManage/Language/Edit.aspx?Action=add", $('#form1').serialize(), "/SysManage/Language/List.aspx", null, '语言设置');
        }
    </script>
</body>
</html>
