<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifySecPwd.aspx.cs" Inherits="yny_004.Web.mobile.html.ModifySecPwd" %>

<form id="form1">
    <div class="content Register resbg2" style="top: 0;">
        <!--  <h1>注册用户</h1>-->
        <div class="Register_Info">
            <div class="Register_List">
                <div class="list-block">
                    <ul>
                        <!-- Text inputs -->
                        <li>
                            <div class="item-content in_register">

                                <div class="item-inner">
                                    <div class="item-input">
                                        <input type="password" id="lbNSecPsd" runat="server" placeholder="新资金密码">
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li>
                            <div class="item-content in_register">
                                <div class="item-inner">
                                    <div class="item-input">
                                        <input type="password" id="lbConfirm"  runat="server" placeholder="确认资金密码">
                                    </div>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
                <div class="content-block ">
                    <div class="row" style="margin: auto">
                        <a href="javascript:checkChange()" class="button button-big button-fill button-success">提交</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</form>
<script type="text/javascript">
        function checkChange() {
            if ($('#lbNSecPsd').val().Trim() == '' || $('#lbNSecPsd').val().length < 6) {
                layer.msg("新资金密码不能为空，且至少6个字母或数字");
            } else if ($('#lbNSecPsd').val().Trim() != $('#lbConfirm').val().Trim()) {
                layer.msg("新资金密码与确认资金密码不一致");
                //            } else if ($('#pwdAnswer').val().Trim() == '') {
                //                v5.error('密保问题不能为空', '1', 'true');
            } else {
                ActionModel("SecurityCenter/ModifySecPwd.aspx?Action=modify", $('#form1').serialize());
            }
        }
   </script>
