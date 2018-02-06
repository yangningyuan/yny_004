<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="yny_004.Web.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>当前网站已关闭</title>
    <style type="text/css">
        body
        {
            margin: 0px;
            padding: 0px;
            background: #fff;
        }
        .main
        {
            width: 998px;
            height: 525px;
            border: 1px solid #d9d9d9;
            margin: 10px auto;
            background: url(img/bkpic.jpg) no-repeat 156px 126px;
        }
        .main .mat
        {
            width: 552px;
            margin: 146px 0px 0px 235px;
        }
        .main .mat p
        {
            font: bold 16px/24px simsun;
            text-align: center;
            margin-bottom: 80px;
        }
        .main .mat p span
        {
            color: #ba2835;
            padding-right: 10px;
        }
        .main .mat .tit
        {
            font: normal 12px simsun;
            color: #515151;
            padding-left: 20px;
            height: 28px;
            background: url(img/bklin.gif) repeat-x left bottom;
        }
        .main .mat ul
        {
            margin: 5px 20px;
            padding: 0px;
        }
        .main .mat ul li
        {
            background: url(img/picli.gif) no-repeat left center;
            height: 20px;
            list-style: none;
            font: normal 14px/20px simsun;
            padding-left: 12px;
        }
        a:link
        {
            color: #004276;
            text-decoration: none;
        }
        a:visited
        {
            color: #004276;
            text-decoration: none;
        }
        a:hover
        {
            text-decoration: underline;
            color: #ba2636;
        }
    </style>
</head>
<body>
    <div class="main">
        <div class="mat">
            <p>
                <%=WebModel.CloseInfo %></p>
        </div>
    </div>
</body>
</html>
