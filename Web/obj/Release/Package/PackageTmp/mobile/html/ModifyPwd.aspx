<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyPwd.aspx.cs" Inherits="yny_004.Web.mobile.html.ModifyPwd" %>

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
                                        <input type="password" id="lbOPassword" runat="server" placeholder="原登录密码">
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li>
                            <div class="item-content in_register">
                                <div class="item-inner">
                                    <div class="item-input">
                                        <input type="password"  id="lbNPassword"  runat="server" placeholder="新登录密码">
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li>
                            <div class="item-content in_register">
                                <div class="item-inner">
                                    <div class="item-input">
                                        <input type="password"  id="lbConfirm" runat="server" placeholder="确认登录密码">
                                    </div>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
                <div class="content-block ">
                    <div class="row" style="margin: auto">
                        <a href="javascript:void(0)" onclick="checkChange();" class="button button-big button-fill button-success">提交</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</form>
 <script type="text/javascript">
        function checkChange() {
            if ($('#lbOPassword').val().Trim() == '') {
                layer.msg("原登录密码不能为空");
            } else if ($('#lbNPassword').val().Trim() == '' || $('#lbNPassword').val().length < 6) {
                layer.msg("新登录密码应至少6个字母或数字");
            } else if ($('#lbNPassword').val().Trim() != $('#lbConfirm').val().Trim()) {
                layer.msg("新登录密码与确认登录密码不一致");
                //            } else if ($('#pwdAnswer').val().Trim() == '') {
                //                v5.error('密保问题不能为空', '1', 'true');
            } else {
                ActionModel("SecurityCenter/ModifyPwd.aspx?Action=modify", $('#form1').serialize());
            }
        }
       
    </script>