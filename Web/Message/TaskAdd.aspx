<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskAdd.aspx.cs" Inherits="yny_004.Web.Message.TaskAdd"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>发送信息</title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <%if (TModel.Role.Super)
                  { %>
                <tr>
                    <td width="25%" align="right">
                        会员账号：
                    </td>
                    <td width="75%" style="height: 40px;">
                        <select id="ddlAdmin" style="display: none;" runat="server" onclick="$('#txtMID').val($(this).val());">
                        </select>
                        <input id="txtMID" runat="server" style="width: 120px;" class="normal_input" name="txtMID"
                            type="text" />
                        <input id="hdMID" runat="server" type="hidden" />
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td align="right">
                        邮件类型
                    </td>
                    <td>
                        <select id="ddlTType" runat="server">
                            <option value="003">账户问题</option>
                            <option value="004">充值问题</option>
                            <option value="005">提现问题</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        邮件：
                    </td>
                    <td>
                        <textarea id="txtMessage" runat="server" class="msg_input" type="text" maxlength="500"
                            style="width: 300px; height: 120px;"></textarea>
                    </td>
                </tr>
                <tr style="height: 40px;">
                    <td align="right">
                        <input name="重置" type="reset" class="normal_btnok" value="重置" style="display: none;" />
                    </td>
                    <td>
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            <span class="remak">温馨提示：请简明扼要地填写您要反映的内容，公司客服人员将在1-2个工作日之内回复您的邮件，谢谢合作！</span>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if ($('#txtMessage').val().Trim() == '') {
                v5.error('请输入信息内容', '1', 'true');
            } else {
                <%if(TModel.Role.Super){ %>
                ActionModelNoVer("Message/TaskAdd.aspx?Action=add", $('#form1').serialize());
                <%} else {%>
                ActionModel("Message/TaskAdd.aspx?Action=add", $('#form1').serialize());
                <%} %>
            }
        }
    </script>
</body>
</html>
