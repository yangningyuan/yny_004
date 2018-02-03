<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="yny_004.Web.Welcome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>欢迎使用本系统</title>
    <style>
        .table-bordered > tbody > tr > th {
            color: #000000;
        }
    </style>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <th scope="col">报单业绩累计
                    </th>
                    <th scope="col">充值累计
                    </th>
                    <th scope="col">总拔出累计
                    </th>
                   <%-- <th scope="col">未拔出累计
                    </th>--%>
                    <th scope="col">已提现累计
                    </th>
                    <th scope="col">未提现累计
                    </th>
                <%--    <th scope="col">重复消费累计
                    </th>--%>
                    <%--<th scope="col">
                        管理费累计
                    </th>--%>
                </tr>
                <tr>
                    <td class="row">
                        <%=model.Field1%>
                    </td>
                    <td class="row">
                        <%=model.Field10%>
                    </td>
                    <td class="row">
                        <%=model.Field2%>
                    </td>
                  <%--  <td class="row">
                        <%=model.Field3%>
                    </td>--%>
                    <td class="row">
                        <%=model.Field4%>
                    </td>
                    <td class="row">
                        <%=model.Field5%>
                    </td>
                    <%--<td class="row">
                        <%=model.Field20%>
                    </td>--%>
                  <%--  <td class="row">
                        <%=model.Field6%>
                    </td>--%>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0">
                <tr>
                 <%--   <th scope="col">报单数累计
                    </th>--%>
                    <th scope="col">级别累计
                    </th>
                    <th scope="col">总拨出比
                    </th>
                </tr>
                <tr>
                    <%--<td class="row">
                        <%=model.Field7%>
                    </td>--%>
                    <td class="row">
                        <%=model.Field8%>
                    </td>
                    <td class="row">
                        <%=model.Field9%>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</body>
</html>
