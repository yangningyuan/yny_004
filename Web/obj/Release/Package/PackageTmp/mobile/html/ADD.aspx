<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADD.aspx.cs" Inherits="yny_004.Web.mobile.html.ADD" %>

<div class="content Register resbg2" style="top: 0;">
    <!--  <h1>注册用户</h1>-->
    <div class="Register_Info">
        <div class="Register_List">
            <form id="form1">
                <div class="list-block">
                    <ul>
                        <!-- Text inputs -->
						  <h4 style="color:#000;padding-left:10px;"> <span>推荐人:</span></h4>
                        <li>
                            <div class="item-content in_register">
                                <div class="item-inner">
                                    <div class="item-input">
                                        <input type="text" id="txtMTJ" name="txtMTJ" runat="server" placeholder="推荐会员帐号">
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li>
                            <div class="item-content in_register">
                                <div class="item-inner">
                                    <div class="item-input">
                                        <input type="text"  id="txtTel" name="txtTel" placeholder="手机号码">
                                    </div>
                                </div>
                            </div>
                            <p>
                                <a class="button button-fill button-success button-big" href="javascript:sendTelCode()">获取验证码</a>
                            </p>
                        </li>
                         <li>
                            <div class="item-content in_register">

                                <div class="item-inner">
                                    <div class="item-input">
                                        <input type="text"  id="txtTelCode" name="txtTelCode" placeholder="手机验证码">
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li>
                            <div class="item-content in_register">

                                <div class="item-inner">
                                    <div class="item-input">
                                        <input type="text" id="txtMName" name="txtMName" placeholder="会员姓名">
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li>
                            <div class="item-content in_register">

                                <div class="item-inner">
                                    <div class="item-input">
                                        <input type="password"  id="txtPassword" name="txtPassword"  placeholder="登录密码">
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li>
                            <div class="item-content in_register">

                                <div class="item-inner">
                                    <div class="item-input">
                                        <input type="password"  id="txtPassword2" name="txtPassword2" placeholder="确认登录密码">
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li style=" display:none;">
                            <div class="item-content in_register">

                                <div class="item-inner">
                                    <div class="item-input">
                                        <input type="password" id="txtSecPsd" name="txtSecPsd" placeholder="资金密码">
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li style=" display:none;">
                            <div class="item-content in_register">

                                <div class="item-inner">
                                    <div class="item-input">
                                        <input type="password" id="txtSecPsd2" name="txtSecPsd2"  placeholder="确认资金密码">
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li style=" display:none;">
                            <div class="item-content in_register">
                                <div class="item-inner">
                                    <div class="item-input">
                                         <select id="ddlProvince" runat="server">
                                        </select>
                                        <select id="ddlCity" runat="server">
                                        </select>
                                        <select id="ddlZone" runat="server" style="display: none;">
                                        </select>
                                    </div>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
            </form>
            <div class="content-block ">
                <div class="row" style="margin: auto">
                    <a href="javascript:checkChange();" class="button button-big button-fill button-warning">立即注册</a>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    setup();
    //setTimeout(function () {
    //    $('#ddlProvince')[0].selectedIndex = 1;
    //    $('#ddlProvince').change();
    //    $('#ddlCity')[0].selectedIndex = 1;
    //    $('#ddlCity').change();
    //    $('#ddlZone')[0].selectedIndex = 1;
    //}, 50);
    function sendTelCode() {
        var tel = $.trim($("#txtTel").val());
        if (tel == "") {
            layer.msg("手机号码不能为空");
            
            return false;
        }
        if (!tel.TryTel()) {
            layer.msg("手机号格式不正确");
            
            return false;
        }
        var relVal = GetAjaxString('SendCode', tel);
        layer.msg(relVal);
        
    }
    function checkChange() {
        if (!$('#txtMName').val().TryEN()) {
            layer.msg("会员姓名只能输入两位以上的中文字符");
            
        } else if ($('#txtMTJ').val() == '') {
            layer.msg("推荐会员帐号不能为空");
           
            //} else if ($('#txtMBD').val() == '') {
            //    v5.error('接点会员不能为空', '1', 'true');
        } else if (!$('#txtPassword').val().TryPassword()) {
            layer.msg("登录密码不能为空，且必须为6-20位字母或数字组合");
            
        } else if ($('#txtPassword').val() != $('#txtPassword2').val()) {
            layer.msg("登录密码与确认登录密码不一样");
            
        } else if (!$('#txtSecPsd').val().TryPassword()) {
            layer.msg("资金密码不能为空，且必须为6-20位字母或数字组合");
            
        //} else if ($('#txtSecPsd').val() != $('#txtSecPsd2').val()) {
        //    layer.msg("资金密码与确认资金密码不一样");
            
        //} else if ($('#txtPassword').val() == $('#txtSecPsd').val()) {
        //    layer.msg("资金密码与登录密码不能相同");
            
        } else if (!$('#txtTel').val().TryTel()) {
            layer.msg("手机号码格式不正确");
        } else if ($('#txtTelCode').val() == "") {
            layer.msg("手机验证码不能为空");
            //} else if ($('#ddlCity').val() == '地市') {
            //    v5.error('请选择开户地区', '1', 'true');
            //} else if ($('#txtBranch').val() == '') {
            //    v5.error('请输入开户支行', '1', 'true');
            //} else if (!$('#txtBankCardName').val().TryEN()) {
            //    v5.error('会员姓名只能输入两位以上的中文字符', '1', 'true');
            //} else if ($('#txtBankCardName').val() != $('#txtMName').val()) {
            //    v5.error('开户姓名必须与会员姓名一直', '1', 'true');
            //} else if (!$('#txtBankNumber').val().TryBankCard()) {
            //    v5.error('银行卡号只能是16-19位数字', '1', 'true');
            //} else if ($('#txtAnswer').val() == '') {
            //    v5.error('密保答案不能为空', '1', 'true');
        } else {
            if (checkForm()) {
                $.ajax({
                    type: 'post',
                    url: 'AjaxM/Regedit.ashx?Action=add',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        layer.msg(info);
                        //setTimeout(function () {
                        //    v5.clearall();
                        //    //if (info == '注册成功') {
                        //    //callhtml('Member/UpMemberSJ.aspx?id=' + $("#txtMID").val(), '升级会员');
                        //    //}
                        //}, 1000);
                    }
                });
            }
        }
    }
</script>
