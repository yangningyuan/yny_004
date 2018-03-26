<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="yny_004.Web.mobile.html.Login" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>登录</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
   <%-- <link rel="shortcut icon" href="/favicon.ico">--%>
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
     <script src="/Admin/js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <link href="/plugin/layer/skin/layer.css" rel="stylesheet" type="text/css" />
    <script src="/plugin/layer/layer.js" type="text/javascript"></script>
    <script src="/Admin/pop/js/V5-UI.js" type="text/javascript"></script>
    <link href="/Admin/pop/css/V5-UI.css" rel="stylesheet" type="text/css" />


    <link rel="stylesheet" href="../plugin/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="../plugin/SUI/css/sm.css">
    <link rel="stylesheet" href="../css/main.css">

    <script type="text/javascript">
       
        $(function () {
            $("#txtpwd").val($("#inpwd").val());
            
        });
        function Login() {
            if ($("#txtname").val() == "") {
                v5.error('会员账号不能为空', '1', 'true');
            } else if (pwd = $("#txtpwd").val() == "") {
                v5.error('密码不能为空', '1', 'true');
            } else {
                $.ajax({
                    type: "post",
                    url: "/Login.aspx?type=login",
                    data: {
                        txtname: $("#txtname").val(), txtpwd: $("#txtpwd").val(), checkCode: $("#checkCode").val(), href: window.location.href, reuserpsw: $("#reuserpsw").val()
                    },
                    async: true,
                    success: function (data) {
                        switch (data) {
                            case "1":
                                v5.error('用户名不存在', '1', 'true');
                                break;
                            case "2":
                                v5.error('密码不正确', '1', 'true');
                                break;
                            //case "3":
                            //    v5.error('验证码错误', '1', 'true');
                            //    $("#imgcode").click();
                            //    break;
                            case "-1":
                                v5.error('限制登录', '1', 'true');
                                break;
                            case "0":
                                window.location.href = "/Default.aspx?type=tel";
                                break;
                            default:
                                if (data)
                                    v5.error(data, '1', 'true');
                                break;
                        }
                    }
                })
            }
            return false;
        }
        function keyLogin() {
            if (event.keyCode == 13)   //回车键的键值为13   
                Login();
        }
    </script>
    <style>
        .list-block .item-inner {
        padding-right:0;
        }
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current" id="login">
            <div class="content Register" style="top: 0;">
            <img src="../img/login.jpg" />
                <img src="../img/wlogo-2.png" class="logo-login" />
               <%-- <p class="logoTitle"></p>--%>
                <input type="hidden" id="inpwd" runat="server" />
                <div class="Register_Info row" style="top: 8rem;">
                    <div class="Register_List">
                        <div class="list-block">
                            <ul>
                                <!-- Text inputs -->
                                <li>
                                    <div class="item-content">
                                        <div class="item-media">
                                            <i class="fa icon-user icon-large"></i>
                                        </div>
                                        <div class="item-inner">
                                            <div class="item-input">
                                                <input type="text" id="txtname" name="txtname" runat="server" placeholder="用户名">
                                            </div>
                                        </div>
                                    </div>
                                </li>

                                <li>
                                    <div class="item-content">
                                        <div class="item-media"><i class="fa icon-lock icon-large"></i></div>
                                        <div class="item-inner">
                                            <div class="item-input">
                                                <input type="password" id="txtpwd" name="txtpwd" runat="server" placeholder="密码">
                                            </div>
                                        </div>
                                    </div>
                                </li>
                                <li style="display:none;">
                                    <div class="item-content">
                                        <div class="item-media"><i class="fa icon-lock icon-large"></i></div>
                                        <div class="item-inner">
                                            <div class="item-input">
                                                <input type="text" id="checkCode" name="checkCode" placeholder="验证码"  style=" width:100px; float: left;">
												<img id="imgcode" src="/CheckCode.aspx" onclick="this.src='/CheckCode.aspx?'+Math.random()" style="height: 47px;width: auto;float: right;"/>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                            <div class="remember" style="display:none;"> <input name="reuserpsw" id="reuserpsw" runat="server" type="checkbox" value="1" />&nbsp;<span>记住密码</span> </div>
                        </div>
                        <div class="content-block">
                            <div class="row" style="margin: auto">
                                <a href="javascript:Login();" class="button button-big button-fill button-success memberbtn">登录</a>
                            </div>
							 <div class="row" style="margin: auto;margin-top:15px;">
                                    <a href="javascript:window.location.href='/SecurityCenter/FindPwdByAnswer.aspx'" class="button button-big" style=" background-color: #A29D94;color:white;border: none;"><span class="fa icon-key"></span>忘记密码</a>
                                </div>
                               
                                <%--<div class="row" style="margin: auto;margin-top:15px;">
                                    <a href="javascript:window.location.href='/mobile/html/Register.aspx?mid=admin'" class="button button-big button-fill button-success"><span class="icon icon-edit"></span>立即注册</a>
                                </div>--%>
                        </div>
                      <%--  <div class="quickenter">
                            <img src="../img/quickenter.png">
                        </div>--%>
                      <%--  <div class="content-block">
                            <div class="row">
                                
                               
                            </div>
                        </div>--%>
                    </div>
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
