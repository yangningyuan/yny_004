<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="findpwd.aspx.cs" Inherits="yny_004.Web.mobile.html.findpwd" %>

<!--密保安全-->
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>找回密码</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <link rel="shortcut icon" href="/favicon.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <link rel="stylesheet" href="../plugin/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="../plugin/SUI/css/sm.css">
    <link rel="stylesheet" href="../css/main.css">

    <script src="/Admin/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <link href="/plugin/layer/skin/layer.css" rel="stylesheet" type="text/css" />
    <script src="/plugin/layer/layer.js" type="text/javascript"></script>
</head>

<body>
    <div class="page-group">
        <div class="page page-current" id="Encrypted">
            <header class="bar bar-nav">
                <a class="icon icon-left pull-left back"></a>
                <h1 class="title">忘记密码</h1>
            </header>

            <div class="content">
                <img src="../img/findpwd_bg.jpg">
                <!--   <div class="content-block-title">密保问题</div>-->
                <div class="content-padded findpwd">
                    <form class="form-horizontal" method="post" id="form1">
                        <div class="list-block">
                            <ul>
                                <li>
                                    <div class="item-content item-content2">
                                        <div class="item-inner">
                                            <div class="item-input">
                                                <input type="text" placeholder="登陆账号" id="txtname" name="username" runat="server">
                                            </div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="item-content item-content2">
                                        <div class="item-inner">
                                            <div class="item-input">
                                                <input type="password" placeholder="登录密码" id="txtpwd" name="password" runat="server">
                                            </div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="item-content item-content2">
                                        <div class="item-inner">
                                            <div class="item-input">
                                                <input type="password" placeholder="确认登录密码" id="txtpwd2" name="password" runat="server">
                                            </div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="item-content item-content2">
                                        <div class="item-inner">
                                            <div class="item-input">
                                                <input type="password" placeholder="交易密码" id="txtChangePwd" name="password" runat="server">
                                            </div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="item-content item-content2">
                                        <div class="item-inner">
                                            <div class="item-input">
                                                <input type="password" placeholder="确认交易密码" id="txtChangePwd2" name="password" runat="server">
                                            </div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="item-content item-content2">
                                        <div class="item-inner">
                                            <div class="item-input">
                                                <input type="text" placeholder="手机号码" id="txtTel" name="txtTel" runat="server">
                                            </div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div class="row">
                                        <div class="col-60 item-content item-content2 ">
                                            <div class="item-inner">
                                                <div class="item-input">
                                                    <input type="text" id="checkCode" runat="server" placeholder="短信验证码">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-40">
                                            <button class="button button-big button-fill" type="button" onclick="sendTelCodeForFindPwd();">获取验证码</button>
                                        </div>
                                    </div>
                                </li>


                            </ul>
                        </div>
                    </form>
                    <div class="content-block">
                        <div class="row">
                            <div class="col-100">
                                <a href="javascript:void(0)" class="button button-big button-fill button-primary" onclick="setNewPwd();">提交</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
   <script src="/mobile/plugin/SUI/js/zepto.js"></script>    
    <script type='text/javascript' src='/mobile/plugin/SUI/js/sm.js' charset='utf-8'></script>
    <script type='text/javascript' src='/mobile/plugin/SUI/js/sm-city-picker.js' charset='utf-8'></script>
    <script type='text/javascript' src='/mobile/js/main.js' charset='utf-8'></script>


    <script src="/Admin/pop/js/V5-UI.js" type="text/javascript"></script>
    <script src="/mobile/js/javascript_main.js" type="text/javascript"></script>
    <script src="/mobile/js/ajax.js" type="text/javascript"></script>
    <script src="/mobile/js/javascript_pop.js" type="text/javascript"></script>
    <script src="/Admin/pop/js/MyValide.js" type="text/javascript"></script>
    <script type="text/javascript">
        
        function TestEmail() {
            var regex = new RegExp("^([\u4E00-\uFA29]|[\uE7C7-\uE7F3]|){1,10}$");
            if ($('#txtname').val() == "") {
                v5.error('会员账号不能为空', '1', 'true');
                return false;
            } else if ($('#txtpwd').val() == "" || $('#txtpwd').val().length < 6) {
                v5.error('登录密码应至少6个字母或数字', '1', 'true');
                return false;
            } else if ($('#txtpwd2').val() == "") {
                v5.error('确认登录密码不能为空', '1', 'true');
                return false;
            } else if ($('#txtChangePwd').val() != $('#txtChangePwd2').val()) {
                v5.error('登录密码与确认登录密码不一样', '1', 'true');
                return false;
            } else if ($('#txtChangePwd').val() == "" || $('#txtChangePwd').val().length < 6) {
                v5.error('交易密码应至少6个字母或数字', '1', 'true');
                return false;
            } else if ($('#txtChangePwd2').val() == "") {
                v5.error('确认交易密码不能为空', '1', 'true');
                return false;
            } else if ($('#txtChangePwd').val() != $('#txtChangePwd2').val()) {
                v5.error('交易密码与确认交易密码不一样', '1', 'true');
                return false;
            } else if ($('#txtChangePwd').val() == $('#txtpwd').val()) {
                v5.error('交易密码与登录密码不能相同', '1', 'true');
                return false;
            }
            return true;
        }
        function validMid() {
            var mid = $('#txtname').val();
            var num = 0;
            var number = 0;
            var letter = 0;
            var bigLetter = 0;
            if (mid.search(/[0-9]/) != -1) {
                num += 1;
                number = 1;
            }
            if (mid.search(/[A-Z]/) != -1) {
                num += 1;
                bigLetter = 1;
            }
            if (mid.search(/[a-z]/) != -1) {
                num += 1;
                letter = 1;
            }
            if (num == 1) {
                if (number == 1) {
                    return false;
                }
                if (letter == 1) {
                    return false;
                }
                if (bigLetter == 1) {
                    return false;
                }
            }
            return true;
        }

        function sendTelCodeForFindPwd() {
            var tel = $("#txtTel").val();
            var mid = $("#txtname").val();
            if (!$('#txtTel').val().TryTel()) {
                v5.error('请输入正确的手机号', '2', 'true');
            }
            else {
                if (TestEmail()) {
                    var relVal = RunAjaxGetKey('sendTelCodeForFindPwd', tel + "&txtMID=" + mid);
                    alert(relVal);
                }
            }
        }

        function setNewPwd() {
            if (TestEmail()) {
                $.ajax({
                    type: 'post',
                    url: 'findpwd.aspx?Action=add',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        v5.error(info, '2', 'true');
                        setTimeout(function () {
                            v5.clearall();
                            window.location.reload()
                            //window.location.href = '../Login.aspx'
                        }, 2000);
                    }
                });
            }
        }
    </script>
</body>

</html>
