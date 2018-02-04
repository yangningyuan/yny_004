<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="yny_004.Web.mobile.html.Register" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>注册</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <link rel="shortcut icon" href="/favicon.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <link rel="stylesheet" href="../plugin/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="../plugin/SUI/css/sm.css">
    <link rel="stylesheet" href="../css/main.css">

    <link href="/Admin/pop/css/pop.css" rel="stylesheet" type="text/css" />
    <link href="/Admin/pop/css/V5-UI.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/Admin/js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="/Admin/pop/js/MyValide.js"></script>
    <link href="/plugin/layer/skin/layer.css" rel="stylesheet" type="text/css" />
    <script src="/plugin/layer/layer.js" type="text/javascript"></script>
    <script src="/Admin/pop/js/ajax.js" type="text/javascript"></script>
    <script src="/Admin/pop/js/V5-UI.js" type="text/javascript"></script>
    <script src="/Admin/pop/js/javascript_pop.js" type="text/javascript"></script>
    <script type="text/javascript" src="/plugin/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="/Admin/pop/js/linkage.js"></script>
    <script type="text/javascript">
        $(function () {
            if (!placeholderSupport()) {   // 判断浏览器是否支持 placeholder
                $('[placeholder]').focus(function () {
                    var input = $(this);
                    if (input.val() == input.attr('placeholder')) {
                        input.val('');
                        input.removeClass('placeholder');
                    }
                }).blur(function () {
                    var input = $(this);
                    if (input.val() == '' || input.val() == input.attr('placeholder')) {
                        input.addClass('placeholder');
                        input.val(input.attr('placeholder'));
                    }
                }).blur();
            };
            setup();
        })
        function placeholderSupport() {
            return 'placeholder' in document.createElement('input');
        }

        

        function TestEmail() {
            if (!$('#txtMName').val().TryEN()) {
                v5.error('会员姓名只能输入两位以上的中文字符', '1', 'true');
            } else if ($('#txtMTJ').val() == '') {
                v5.error('推荐会员帐号不能为空', '1', 'true');
                //} else if ($('#txtMBD').val() == '') {
                //    v5.error('接点会员不能为空', '1', 'true');
            } else if (!$('#txtPassword').val().TryPassword()) {
                v5.error('登录密码不能为空，且必须为6-20位字母或数字组合', '1', 'true');
            } else if ($('#txtPassword').val() != $('#txtPassword2').val()) {
                v5.error('登录密码与确认登录密码不一样', '1', 'true');
            } else if (!$('#txtSecPsd').val().TryPassword()) {
                v5.error('资金密码不能为空，且必须为6-20位字母或数字组合', '1', 'true');
            //} else if ($('#txtSecPsd').val() != $('#txtSecPsd2').val()) {
            //    v5.error('资金密码与确认资金密码不一样', '1', 'true');
            //} else if ($('#txtPassword').val() == $('#txtSecPsd').val()) {
            //    v5.error('资金密码与登录密码不能相同', '1', 'true');
            } else if (!$('#txtTel').val().TryTel()) {
                v5.error('手机号码格式不正确', '1', 'true');
            } else if ($('#txtTelCode').val() == "") {
                v5.error("手机验证码不能为空", '1', 'true');
             
            } else {
                $.ajax({
                    type: 'post',
                    url: '/AjaxM/Regedit.ashx?Action=add',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        v5.alert(info, '1', 'true');
                        setTimeout(function () {
                            v5.clearall();
                            //if (info == '注册成功') {
                            //callhtml('Member/UpMemberSJ.aspx?id=' + $("#txtMID").val(), '升级会员');
                            //}
                        }, 1000);
                    }
                });
            }
        }
        function sendTelCode() {
            var tel = $.trim($("#txtTel").val());
            if (tel == "") {
                v5.error('手机号码不能为空', '1', 'true');
                return false;
            }
            if (!tel.TryTel()) {
                v5.error('手机号格式不正确', '1', 'true');
                return false;
            }
            var relVal = GetAjaxString('SendCode', tel);
            v5.error(relVal, '1', 'true');
        }
    </script>
</head>

<body>
    <div class="page-group">
        <div class="page page-current" id="Register">
            <header class="bar bar-nav">
                <%--<a href="#" class="icon icon-left pull-left back"></a>--%>
                <h1 class="title">会员注册</h1>
            </header>

            <div class="content Register resbg" style="top: 0;">
                <img src="../img/login.jpg" />
                <!--  <h1>注册用户</h1>-->
                <div class="Register_Info">
                    <!--<div class="Register_Img">
                    <input type="file"  name="file" id="doc" multiple="multiple"  onchange="javascript:setImagePreviews();" accept="image/*" />
                    <i class="fa icon-camera-retro icon-2x"></i>
                </div>-->
                    <form class="form-horizontal" method="post" id="form1">
                        <input type="hidden" id="ddlProvince" name="ddlProvince" />
                        <input type="hidden" id="ddlCity" name="ddlCity" />
                        <input type="hidden" id="ddlZone" name="ddlZone" />
                        <%--<input type="hidden" id="ddlProvince" name="ddlProvince" />
                        <input type="hidden" id="ddlProvince" name="ddlProvince" />--%>
                        <div class="Register_List">
                            <div class="list-block" style="margin-top:50px;">
                                <ul>
                                    <!-- Text inputs -->
                                  <h4 style="color:#fff;padding-left:10px;"> <span>推荐人:</span></h4>
                                    <li>
                                        <div class="item-content">
                                            <div class="item-media"><i class="fa icon-large icon-thumbs-up"></i></div>
                                            <div class="item-inner">
                                                <div class="item-input">
                                                    <input type="text"  id="txtMTJ" class="form-control" name="txtMTJ"  runat="server" placeholder="jjd">
													
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    
                                     <li>
                                        <div class="item-content">
                                            <div class="item-media">
                                                <i class="fa icon-user icon-large"></i>
                                            </div>
                                            <div class="item-inner">
                                                <div class="item-input">
                                                    <input type="text"  id="txtTel" name="txtTel" maxlength="11"  placeholder="手机号码">
                                                    
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                     <li>
                                       <a class="button button-fill button-success button-big" href="javascript:sendTelCode()">获取验证码</a>
                                    </li>
                                     <li>
                                        <div class="item-content">
                                            <div class="item-media">
                                                <i class="fa icon-user icon-large"></i>
                                            </div>
                                            <div class="item-inner">
                                                <div class="item-input">
                                                    <input type="text"  id="txtTelCode" name="txtTelCode" placeholder="手机验证码">
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                     <li>
                                        <div class="item-content">
                                            <div class="item-media">
                                                <i class="fa icon-user icon-large"></i>
                                            </div>
                                            <div class="item-inner">
                                                <div class="item-input">
                                                    <input type="text"  id="txtMName"  name="txtMName"   placeholder="会员姓名">
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="item-content">
                                            <div class="item-media"><i class="fa icon-lock icon-large"></i></div>
                                            <div class="item-inner">
                                                <div class="item-input">
                                                    <input id="txtPassword"  name="txtPassword" type="password" placeholder="设置密码">
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="item-content">
                                            <div class="item-media"><i class="fa icon-lock icon-large"></i></div>
                                            <div class="item-inner">
                                                <div class="item-input">
                                                    <input type="password" id="txtPassword2"  name="txtPassword2" placeholder="确认密码">
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                   
                                </ul>
                            </div>
                            <div class="content-block">
                                <div class="row" style="margin: auto">
                                    <a href="javascript:void(0)" onclick="TestEmail()" class="button button-big button-fill button-primary  rule">立即注册</a>

                                    <a href="javascript:window.location.href='/mobile/html/Login.aspx'" class="button button-big button-fill button-warning">已有账号，快速登录</a>

                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <script type='text/javascript' src='//g.alicdn.com/sj/lib/zepto/zepto.js' charset='utf-8'></script>
    <script type='text/javascript' src='../plugin/SUI/js/sm.js' charset='utf-8'></script>
    <script type='text/javascript' src='../plugin/SUI/js/sm-city-picker.js' charset='utf-8'></script>
    <script type='text/javascript' src='../js/main.js' charset='utf-8'></script>
</body>

</html>
