<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="yny_004.Web.MQL.Login" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=WebModel.WebTitle %></title>
    <link rel="Shortcut Icon" href="../Admin/images/fac.ico" />
    <script src="../Admin/pop/js/ajax.js" type="text/javascript"></script>
    <script src="js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <link href="../plugin/layer/skin/layer.css" rel="stylesheet" type="text/css" />
    <script src="../plugin/layer/layer.js" type="text/javascript"></script>
    <script src="../Admin/pop/js/V5-UI.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="css/base.css" media="all">
    <link rel="stylesheet" type="text/css" href="css/login.css" media="all">
  
    <script type="text/javascript">
        function Login() {
            if ($("#txtname").val() == "") {
                v5.error('用户不能为空', '1', 'true');
            } else if (pwd = $("#txtpwd").val() == "") {
                v5.error('密码不能为空', '1', 'true');
            } else {
                $.ajax({
                    type: "post",
                    url: "../Login.aspx?type=login",
                    data: { txtname: $("#txtname").val(), txtpwd: $("#txtpwd").val(), checkCode: $("#checkCode").val(), href: window.location.href
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
                                window.location.href = "../Default.aspx";
                                break;
                            default:
                                if (data)
                                    v5.error(data, '1', 'true');
                                break;
                        }
                    }
                })
            }
        }

        function keyLogin() {
            if (event.keyCode == 13)   //回车键的键值为13   
                Login();
        }
        function reset() {
            $("#txtname").val("");
            $("#txtpwd").val("");
        }

        function OpenWindow(url, title, width, height) {
            var iTop = (window.screen.height - 30 - height) / 2; //获得窗口的垂直位置;
            var iLeft = (window.screen.width - 10 - width) / 2; //获得窗口的水平位置;
            window.open(url, title, 'height=' + height + ', width=' + width + ', top=' + iTop + ', left=' + iLeft + ', toolbar=no, menubar=no, scrollbars=no,resizable=no,location=no, status=no');
        }
    </script>
</head>
<body onkeydown="keyLogin();">
    <div id="main">
        <div class="box">
            <p>
            </p>
            <div class="foot">
                <%=WebModel.WCopyright%><span><%=WebModel.WCopyright%></span></div>
            <div class="login_from">
                <div class="title">
                    <span>登录</span><%=WebModel.WebTitle %>管理系统</div>
                <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="54">
                            账号
                        </td>
                        <td height="70" colspan="2" align="left" valign="middle">
                            <input class="input_style frsd" type="text" id="txtname" value="" maxlength="20">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            密码
                        </td>
                        <td height="70" colspan="2" align="left" valign="middle">
                            <input class="input_style frsd" type="password" id="txtpwd" value="" maxlength="32">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            验证码
                        </td>
                        <td width="122" align="left" valign="middle">
                            <input maxlength="4" class="input_style thrd" type="text" id="checkCode" style="text-transform: uppercase;">
                        </td>
                        <td width="161" height="70" align="left" valign="middle">
                            <img id="imgcode" src="../CheckCode.aspx" onclick="this.src='../CheckCode.aspx?'+Math.random()"
                                style="cursor: pointer" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="center" valign="middle">
                         
                        </td>
                        <td height="70" align="center" valign="middle">
                            <input class="btn_ok" value="" type="button" onclick="Login();" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</body>
</html>--%>




<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title> <%=WebModel.WebTitle %></title>
	<link rel="Shortcut Icon" href="../Admin/images/fac.ico" />
    <link href="/mql/css/style.css" rel="stylesheet" type="text/css" />
	<script language="JavaScript" src="/mql/js/jquery.js"></script>
	<script src="/mql/js/cloud.js" type="text/javascript"></script>
    
    <script src="../Admin/pop/js/ajax.js" type="text/javascript"></script>
    <script src="js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <link href="../plugin/layer/skin/layer.css" rel="stylesheet" type="text/css" />
    <script src="../plugin/layer/layer.js" type="text/javascript"></script>
    <script src="../Admin/pop/js/V5-UI.js" type="text/javascript"></script>
   <%-- <link rel="stylesheet" type="text/css" href="css/base.css" media="all">
    <link rel="stylesheet" type="text/css" href="css/login.css" media="all">--%>
  
    <script type="text/javascript">
        function Login() {
            if ($("#txtname").val() == "") {
                v5.error('用户不能为空', '1', 'true');
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
                                window.location.href = "../Default.aspx";
                                break;
                            default:
                                if (data)
                                    v5.error(data, '1', 'true');
                                break;
                        }
                    }
                })
            }
        }

        function keyLogin() {
            if (event.keyCode == 13)   //回车键的键值为13   
                Login();
        }
        function reset() {
            $("#txtname").val("");
            $("#txtpwd").val("");
        }

        function OpenWindow(url, title, width, height) {
            var iTop = (window.screen.height - 30 - height) / 2; //获得窗口的垂直位置;
            var iLeft = (window.screen.width - 10 - width) / 2; //获得窗口的水平位置;
            window.open(url, title, 'height=' + height + ', width=' + width + ', top=' + iTop + ', left=' + iLeft + ', toolbar=no, menubar=no, scrollbars=no,resizable=no,location=no, status=no');
        }
    </script>
	<script language="javascript">
		$(function () {
			$('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
			$(window).resize(function () {
				$('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
			})
		});
	</script>

</head>

<body style="background-color:#1c77ac; background-image:url(/mql/images/light.png); background-repeat:no-repeat; background-position:center top; overflow:hidden;" onkeydown="keyLogin();">



	<div id="mainBody">
		<div id="cloud1" class="cloud"></div>
		<div id="cloud2" class="cloud"></div>
	</div>


	<div class="logintop">
		<span>欢迎登录后台管理界面平台</span>
		<ul>
			<%--<li><a href="#">回首页</a></li>--%>
			<li><a href="#">帮助</a></li>
			<li><a href="#">关于</a></li>
		</ul>
	</div>

	<div class="loginbody">

		<span class="systemlogo"></span>

		<div class="loginbox">

			<ul>
				<li><input  id="txtname" type="text" class="loginuser" value="admin" onclick="JavaScript:this.value=''" /></li>
				<li><input  id="txtpwd" type="password" class="loginpwd" value="密码" onclick="JavaScript:this.value=''" /></li>
                <li><input  id="checkCode" type="text" class="loginuser" value="验证码" style="width:100px;" onclick="JavaScript:this.value=''" /><img src="../CheckCode.aspx"  width="56"  border="0" alt="点击刷新验证码"  onclick="this.src='../CheckCode.aspx?'+Math.random()" style="cursor: pointer; width: 92px; border-radius: 4px; margin-right: 10px; margin-top:-4px; margin-left:10px; height: 48px;" align="absmiddle"/></li>
                
				<li><input name="" type="button" class="loginbtn" value="登录"  onclick="Login();"  /><label><a href="javascript:window.location.href='/SecurityCenter/FindPwdByAnswer.aspx'">忘记密码？</a></label></li>
			</ul>


		</div>

	</div>



	<div class="loginbm">版权所有  2018  <a href=""><%=WebModel.WebTitle %></a> </div>


</body>

</html>
