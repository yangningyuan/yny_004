<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelFindP.aspx.cs" Inherits="yny_004.Web.tel.TelFindP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1.0,minimum-scale=1.0,user-scalable=no" />
    <title>
        <%=WebModel.WebTitle %></title>
    <!--<link rel="stylesheet" href="css/style.css"/>-->
    <link href="css/newIndex.css" rel="stylesheet" type="text/css">
</head>
<body>
    <div class="whole">
        <form id="Form1" runat="server">
        <div class="newLogin91_border marginAuto">
            <div class="mengban" style="display: none; height: 891px;">
            </div>
            <div class="new_logo">
                <img src="images/logo.png">
            </div>
            <div class="newLogin91">
                <div class="newLogin91_newLoginBackground1" style="position: relative; top: 0px;
                    left: 0px;">
                    <div class="h_50">
                    </div>
                    <div class="main_title">
                        重置密码</div>
                    <div class="newLoginForm">
                        <ol class="newLoginForm_user">
                            <!--用户名-->
                            <li class="newLoginUser" style="margin-top: 20px;"><strong>用户名: </strong>
                                <input id="txtMemberMID" type="text" class="s_input3" style="line-height: 35px;"
                                    maxlength="20" placeholder="用户名" runat="server" />
                            </li>
                            <!--密码-->
                            <li class="newLoginPwd" style="margin-top: 20px;"><strong>请选择密保问题 : </strong>
                                <select id="ddlQuestion" runat="server" class="form-control" placeholder="密保问题" style="    width: 60%;
    height: 40px;
    line-height: 35px;
    overflow: hidden;">
                                </select>
                            </li>
                            <!--重复密码-->
                            <li class="newLoginPwd" style="margin-top: 20px;"><strong>密码确认 : </strong>
                                <input id="txtAnswer" runat="server" style="line-height: 35px;" type="text" class="input310 s_input3"
                                    placeholder="密保答案" />
                            </li>
                        </ol>
                        <ol class="newLoginForm_sub clearfix">
                            <li class="newLoginForm_sub1 marginAuto" style="cursor: pointer;" id="btnSubmit">
                                <asp:Button ID="Button2" runat="server" Text="确认" OnClick="btnSubmit2_Click" />
                            </li>
                            <li>
                                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text=""></asp:Label>
                            </li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>
        </form>
    </div>
</body>
</html>
