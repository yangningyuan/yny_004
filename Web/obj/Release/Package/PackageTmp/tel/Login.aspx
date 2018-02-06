<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="yny_004.Web.tel.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1.0,minimum-scale=1.0,user-scalable=no" />
    <title>
        <%=WebModel.WebTitle %></title>
    <link rel="stylesheet" href="css/style.css" />
    <script src="../Admin/js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../Admin/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="../plugin/layer/skin/layer.css" rel="stylesheet" type="text/css" />
    <script src="../plugin/layer/layer.js" type="text/javascript"></script>
    <script src="../Admin/pop/js/V5-UI.js" type="text/javascript"></script>
    <link href="../Admin/pop/css/V5-UI.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        //        var defaultKye = "";
        //        var GB2312Str = "<%=zhNames %>";
        //        var BIG5Str = "<%=enNames %>";
        //        var GBStr = GB2312Str.split('*');
        //        var BIGStr = BIG5Str.split('*');
    </script>
    <!--<script src="Admin/pop/js/LanguageConvert.js" type="text/javascript"></script>-->
    <script type="text/javascript">
        function Login() {
            if ($("#txtname").val() == "") {
                v5.error('会员账号不能为空', '1', 'true');
            } else if (pwd = $("#txtpwd").val() == "") {
                v5.error('密码不能为空', '1', 'true');
            } else {
                $.ajax({
                    type: "post",
                    url: "../Login.aspx?type=login",
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
</head>
<body>
    <div class="whole">
		
        <div class="logoBox">
				
            <img src="/Admin/login_phone/images/Login.png" />
        </div>
        <div class="information">
            <div class="user">
                <div class="inputBox">
                    <input id="txtname" name="txtname" type="text" placeholder="请输入用户名" />
                </div>
            </div>
            <div class="password">
                <div class="inputBox">
                    <input id="txtpwd" name="txtpwd" type="password" placeholder="请输入密码" />
                </div>
            </div>
            <div class="yzm">
                <div class="inputBox2">
                    <input type="text" id="checkCode" name="checkCode" placeholder="验证码" />
                </div>
                <div class="yzm_imgages">
                    <img src="../CheckCode.aspx" onclick="this.src='../CheckCode.aspx?'+Math.random()" />
                </div>
            </div>
        </div>
        <div class="login_btn">
            <input type="button" value="登录" class="login" onclick="Login();" />
            <input type="button" value="找回密码" class="remember" onclick="window.location.href = '../SecurityCenter/FindPwdByAnswer.aspx'" />
        </div>
    </div>
</body>
</html>
