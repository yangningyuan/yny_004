<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="yny_004.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>
        <%=WebModel.WebTitle %></title>
 <%--   <link rel="Shortcut Icon" href="Admin/images/fac.ico" />--%>
    <%--    <link rel="stylesheet" type="text/css" href="Admin/login/css/login.css">--%>
    <link rel="stylesheet" type="text/css" href="Admin/login/css/bootstrap.css">
    <link rel="stylesheet" type="text/css" href="Admin/login/css/style1.css">


    <script type="text/javascript" src="login/js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="login/js/bootstrap.min.js"></script>
    <link href="plugin/layer/skin/layer.css" rel="stylesheet" type="text/css" />
    <script src="plugin/layer/layer.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="Admin/pop/css/V5-UI.css" />
    <script type="text/javascript" src="Admin/js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="Admin/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="Admin/pop/js/javascript_main.js"></script>
    <script type="text/javascript" src="Admin/pop/js/ajax.js"></script>
    <script type="text/javascript" src="Admin/pop/js/javascript_pop.js"></script>
    <script type="text/javascript" src="Admin/pop/js/V5-UI.js"></script>
    <script type="text/javascript" src="Admin/pop/js/uaredirect.js"></script>
    <%--<script type="text/javascript">        uaredirect("/mobile/html/Login.aspx");</script>--%>
  
    <!--<script type="text/javascript">
        var defaultKye = "";
        var GB2312Str = "<%=zhNames %>";
        var BIG5Str = "<%=enNames %>";
        var GBStr = GB2312Str.split('*');
        var BIGStr = BIG5Str.split('*');
    </script>
    <script src="Admin/pop/js/LanguageConvert.js" type="text/javascript"></script>-->
    <script type="text/javascript">
        function Login() {
            if ($("#txtname").val() == "") {
                v5.error('用户名不能为空', '1', 'true');
            } else if (pwd = $("#txtpwd").val() == "") {
                v5.error('密码不能为空', '1', 'true');
            } else {
                $.ajax({
                    type: "post",
                    url: "Login.aspx?type=login",
                    data: {
                        txtname: $("#txtname").val(), txtpwd: $("#txtpwd").val(), checkCode: $("#checkCode").val(), href: window.location.href
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
                            case "3":
                                v5.error('验证码错误', '1', 'true');
                                $("#imgcode").click();
                                break;
                            case "-1":
                                v5.error('限制登录', '1', 'true');
                                break;
                            case "0":
                                window.location.href = "/Default.aspx?type=pc";
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
        function reset() {
            $("#txtname").val("");
            $("#txtpwd").val("");
        }
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
        })
        function placeholderSupport() {
            return 'placeholder' in document.createElement('input');
        }
    </script>

</head>
<body onkeydown="keyLogin();">
    <div class="login-container">

        <div class="row">
            <div class="col-md-12">
                <!--<div class="text-center m-b-md"> <img src="images/logo1.png"> </div>-->
                <div class="hpanel">
                    <div class="title">
                        <img src="/mobile/html/img/logo-login.png"></div>
                    <div class="panel-body">

                        <form method="post" name="login" id="form1">
                            <div class="form-group">
                                <label class="control-label" for="username">用户名</label>
                                <input type="text" placeholder="请输入您的用户名" title="用户名" required value="" id="txtname" name="username" class="form-control">
                            </div>
                            <div class="form-group">
                                <label class="control-label" for="password">密&nbsp;&nbsp;&nbsp; 码</label>
                                <input type="password" title="请输入您的密码" placeholder="登录密码" required value="" id="txtpwd" name="password" class="form-control">
                            </div>
                            <div class="form-group">
                                <label class="control-label" for="password">验证码</label>
                                <div>
                                    <input title="请输入您的验证码" placeholder="验证码" required id="checkCode" name="checkCode" class="form-control" style="width: 50%;">
                                    <img src="CheckCode.aspx" style="margin-left: 5%; width: 86; height: 34px;" alt="点击刷新验证码" onclick="this.src='CheckCode.aspx?'+Math.random()">
                                </div>
                            </div>
                            <button class="btn btn-success btn-block" type="button" onclick="Login()">登录</button>
                            <a href="Regedit/Index.aspx?mid=admin" style="display: block; float: left; margin-left: 20px; margin-top: 18px; color: white;">注册会员</a>
                            <a href="SecurityCenter/FindPwd.aspx" style="display: block; float: right; margin-left: 20px; margin-top: 18px; color: white;">忘记密码？</a>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 text-center" style="color:#C8C7C8;"><strong>伯联国际  &nbsp;&nbsp;</strong>2017 All Right Reserved </div>
        </div>
    </div>
    <%-- <div id="main">
        <form method="post" name="login" id="form1">
            <div class="box">
                <div class="loginbg">
                    <div class="logo">
                     <img src="/Admin/login/images/logo.png">
                    </div>
                    <div class="loginbox">
                        <div class="loginboxtbl">
                            <ul>
                                <li>
                                    <!--	<h5>用户名：</h5>-->
                                    <label>
                                        <input  type="text" class="input"  id="txtname" name="username"  maxlength="20" value="" placeholder="用户名">
                                    </label>
                                </li>
                                <li>
                                    <!--<h5>密&nbsp;&nbsp;码：</h5>-->
                                    <input  type="password" class="input" id="txtpwd" name="password"  maxlength="20" warning="请输入密码！" value="" placeholder="密码">
                                </li>
                                <li>
                                    <!--<h5>验证码：</h5>-->
                                    <input  id="checkCode" name="checkCode" type="text"  warning="请输入验证码！" class="inputCode" size="4" maxlength="4" value="" title="点击图片可刷新验证码" placeholder="验证码">
                                    <img src="CheckCode.aspx"  width="56"  border="0" alt="点击刷新验证码"  onclick="this.src='CheckCode.aspx?'+Math.random()" style="cursor: pointer; width: 92px; border-radius: 4px; margin-right: 10px; height: 54px;" align="absmiddle"></li>
                            </ul>
                        </div>
                        <input type="button" value="登录"  onclick="Login()" class="btn_0">
                        <a href="SecurityCenter/FindPwd.aspx" class="forget">忘记密码</a>
                    </div>
                </div>
            </div>
        </form>
     
		</div>--%>
</body>
</html>
