<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Findpwd.aspx.cs" Inherits="yny_004.Web.SecurityCenter.Findpwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
 <%--   <link href="FD/images/fac.ico" rel="shortcut icon" />--%>
    <title>
        <%=WebModel.WebTitle %></title>
    <link href="FD/css/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="FD/css/style.css" />
    <link type="text/css" rel="stylesheet" href="../Admin/pop/css/V5-UI.css" />
    <script src="../Admin/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <link href="../plugin/layer/skin/layer.css" rel="stylesheet" type="text/css" />
    <script src="../plugin/layer/layer.js" type="text/javascript"></script>
</head>
<body>
    <div class="web-header">
        <div class="container clearfix">
            <div class="pull-left logo">
                <a href="javascript:void(0)">
                    <img src="FD/images/rlogo.png" height="66">
            </div>
            <nav class="pull-right">
                <a href="../Login.aspx" class="pull-right text-white" style="margin-left:15px;">返回首页</a>
            </nav>
        </div>
    </div>
    <div class="container">
        <div class="mainbody">
            <div class="register-box">
                <form class="form-horizontal" method="post" id="form1">
                    <div class="form-group">
                        <div class="f"><h3>找回密码</h3></div>
                    </div>
                    <div class="form-group" >
                        <label class="col-sm-12 control-label">
                            登陆账号
                        </label>
                        <div class="col-sm-12">
                            <input class="form-control" type="text" id="txtname" name="username" runat="server">
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-12 control-label">
                            请设置您的登录密码
                        </label>
                        <div class="col-sm-12">
                            <input class="form-control" type="password" id="txtpwd" name="password" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-12 control-label">
                            请确认您的登录密码
                        </label>
                        <div class="col-sm-12">
                            <input class="form-control" type="password" id="txtpwd2" name="password" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-12 control-label">
                            请设置您的交易密码
                        </label>
                        <div class="col-sm-12">
                            <input class="form-control" type="password" id="txtChangePwd" name="password" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-12 control-label">
                            请确认您的交易密码
                        </label>
                        <div class="col-sm-12">
                            <input class="form-control" type="password" id="txtChangePwd2" name="password" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-12 control-label">
                            请输入您的注册手机号
                        </label>
                        <div class="col-sm-12">
                            <input class="form-control" type="text" id="txtTel" name="password" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-12 control-label">
                            手机验证码
                        </label>
                        <div class="col-sm-12">
                            <input type="text" id="checkCode" class="form-control" runat="server" style="width: 65%; display: inline;" />
                            <input class="form-control btn btn-success" title="发送验证码" value="发送验证码" onclick="sendTelCodeForFindPwd();"
                                type="button" style="width: 28%" />
                        </div>
                    </div>
                    <div class="form-group mt20">
                        <label class="col-sm-12 control-label">
                        </label>
                        <div class="col-sm-12">
                            <button type="button" class="btn btn-success btn-lg width200" onclick="setNewPwd();">
                                提交
                            </button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <script src="../Admin/pop/js/V5-UI.js" type="text/javascript"></script>
    <script src="../Admin/pop/js/javascript_main.js" type="text/javascript"></script>
    <script src="../Admin/pop/js/ajax.js" type="text/javascript"></script>
    <script src="../Admin/pop/js/javascript_pop.js" type="text/javascript"></script>
    <script src="../Admin/pop/js/MyValide.js" type="text/javascript"></script>
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
                    url: 'Findpwd.aspx?Action=add',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        v5.error(info, '2', 'true');
                        //setTimeout(function () {
                        //    v5.clearall();
                        //    window.location.href = '../Login.aspx'
                        //}, 2000);
                    }
                });
            }
        }
    </script>
</body>
</html>
