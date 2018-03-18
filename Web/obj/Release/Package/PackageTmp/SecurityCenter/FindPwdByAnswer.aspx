<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FindPwdByAnswer.aspx.cs" Inherits="yny_004.Web.SecurityCenter.FindPwdByAnswer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link href="FD/images/fac.ico" rel="shortcut icon" />
    <title>
        <%=WebModel.WebTitle %></title>
   
         <link href="images/fac.ico" rel="shortcut icon" />
		<link href="FD/css/bootstrap.css" rel="stylesheet" />
		<link rel="stylesheet" href="FD/css/style.css" />

    <link type="text/css" rel="stylesheet" href="../Admin/pop/css/V5-UI.css" />
    <script src="../Admin/js/jquery-1.9.1.min.js" type="text/javascript"></script>
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
        })
        function placeholderSupport() {
            return 'placeholder' in document.createElement('input');
        }
    </script>
    <style>
        .findPwdByAnswerLogo {
            float:left;
            height: 72px;
            line-height: 72px;
        }
        .findPwdByAnswerLogo img{
                float:left;
                height: 44px;
                vertical-align: inherit;
                display: inline-block;
                margin-top: 14px;
        }
            .findPwdByAnswerLogo p {
                margin:0;
                margin-left:10px;
                float:left;
                font-size:24px;
                height:72px;
                line-height:72px;
            }
    </style>
</head>
<body>
  <div class="web-header">
			<div class="container clearfix">
				<div class="pull-left logo">
					<a href="#" class="findPwdByAnswerLogo"><img src="/Admin/find_password/images/rlogo.png" class=""><p>贝贝美商城</p>
				</div>
				<nav class="blog-nav pull-left">
					<%--<span class="blog-nav-item active" href="#">找回密码</span>--%>
				</nav>
				<nav class="pull-right">
					<a href="/mobile/html/Login.aspx" class="pull-right text-white" style="margin-left:15px;">返回登陆</a>
				</nav>
			</div>
		</div>
		<div class="container">
			<div class="mainbody">
				<!--<div class="title">
					<span>找回密码</span>
					<a href="#" class="pull-right rightlink text-danger">直接登陆</a>
				</div>-->
				<div class="register-box">
					<form class="form-horizontal" method="post" id="form1" runat="server">
						<div class="form-group">
							<div class="f">
								<h3>找回密码</h3></div>
						</div>
						<div class="form-group">
							<label for="qq" class="col-sm-12 control-label">会员账号</label>
							<div class="col-sm-12">
								<input id="txtMemberMID" type="text" class="form-control" placeholder="用户名" runat="server" />
								<small class="text-muted">请输入您的会员账号</small>
							</div>
						</div>
						<div class="form-group">
							<label for="qq" class="col-sm-12 control-label">请选择密保问题</label>
							<div class="col-sm-12">
								<select id="ddlQuestion" runat="server" class="form-control">
                            </select>
								<small class="text-muted">请选择密保问题</small>
							</div>
						</div>
						<div class="form-group">
							<label for="qq" class="col-sm-12 control-label">请填写密保答案</label>
							<div class="col-sm-12">
								  <input id="txtAnswer" runat="server" type="text" class="form-control" placeholder="密保答案" />
								<small class="text-muted">请输入您的密保答案</small>
							</div>
						</div>
					
						<div class="form-group mt20">
							<div class="col-sm-12 commit">
								
                                <asp:Button ID="Button2" runat="server" Text="提交" OnClick="btnSubmit2_Click" CssClass="btn btn-success btn-lg width200" />
                            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text=""></asp:Label>
							</div>
						</div>
					</form>
				</div>
			</div>
		</div>
</body>
</html>
