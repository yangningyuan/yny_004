<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifySecPwd.aspx.cs" Inherits="yny_004.Web.SecurityCenter.ModifySecPwd"
    EnableEventValidation="false" %>

<html>
<head>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right">
                        新资金密码:
                    </td>
                    <td>
                        <input id="lbNSecPsd" class="normal_input" runat="server" type="password" /><font
                            color="red">*</font>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        确认资金密码:
                    </td>
                    <td>
                        <input id="lbConfirm" class="normal_input" runat="server" type="password" /><font
                            color="red">*</font>
                    </td>
                </tr>
                <%--<tr>
                    <td align="right">
                    </td>
                    <td>
                        验证密保问题
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        密保问题:
                    </td>
                    <td>
                        <select id="ddl_PwdQuestion" width="175px" runat="server">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        密保问题答案:
                    </td>
                    <td>
                        <input type="hidden" runat="server" id="hidQuesId" />
                        <input id="pwdAnswer" class="normal_input" runat="server" type="text" /><font color="red">*</font>
                    </td>
                </tr>--%>
                <tr id="VerifyCode" runat="server">
                    <td align="right">
                        验证码:
                    </td>
                    <td>
                        <input id="txtTelCode" class="normal_input" runat="server" /><input type="button"
                            value="获取验证码" onclick="sendCode(this)" /><font color="red">*</font>
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td align="right">
                        <input name="重置" type="reset" class="normal_btnok" value="重置" style="display: none;" />
                    </td>
                    <td align="left">
                        <input class="normal_btnok" id="btnOK" type="button" value="提交" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if ($('#lbNSecPsd').val().Trim() == '' || $('#lbNSecPsd').val().length < 6) {
                v5.error('新资金密码不能为空，且至少6个字母或数字', '1', 'true');
            } else if ($('#lbNSecPsd').val().Trim() != $('#lbConfirm').val().Trim()) {
                v5.error('新资金密码与确认资金密码不一致', '1', 'true');
                //            } else if ($('#pwdAnswer').val().Trim() == '') {
                //                v5.error('密保问题不能为空', '1', 'true');
            } else {
                ActionModel("SecurityCenter/ModifySecPwd.aspx?Action=modify", $('#form1').serialize());
            }
        }
        function checkPwdAnswer() {
            var qid = $("#hidQuesId").val().Trim();
            var ans = $("#pwdAnswer").val().Trim();
            var result = GetAjaxString("checkPwdAnswer", "0&question=" + qid + "&answer=" + ans);
            if (result == '-1') {
                v5.error('参数错误', '1', 'true');
                return;
            } else if (result == '0') {
                v5.error('密保问题不正确', '1', 'true');
                return;
            }
            else if (result == '2') {
                v5.error('未设置密保问题', '1', 'true');
                return;
            }
            return true;
        }
        function sendCode(obj) {
            $(obj).val("发送中...");
            $(obj).attr("disabled", "disabled");
            $("#txtTel").attr("readonly", "readonly");
            var sendstate = RunAjaxGetKey("SendCodeModifySecPsd");
            setTimeout(function () { alert(sendstate); $(obj).val(sendstate); }, 500);
        }
    </script>
</body>
</html>
