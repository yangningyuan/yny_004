<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderPay.aspx.cs" Inherits="yny_004.Web.Payment.cai1pay.OrderPay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-Type" content="text/html; charset=gb2312" />
    <title>标准商户订单支付接口</title>
    <style type="text/css">
        <!--
        TD {
            FONT-SIZE: 9pt;
        }

        SELECT {
            FONT-SIZE: 9pt;
        }

        OPTION {
            COLOR: #5040aa;
            FONT-SIZE: 9pt;
        }

        INPUT {
            FONT-SIZE: 9pt;
        }
        -->
    </style>
</head>
<body bgcolor="#FFFFFF">
    <form action="/Payment/cai1pay/redirect.aspx" method="POST" name="frm1">
        <table width="450px" border="1" cellspacing="0" cellpadding="3" bordercolordark="#FFFFFF"
            bordercolorlight="#333333" bgcolor="#F0F0FF" align="center">
            <tr bgcolor="#8070FF">
                <td colspan="2" align="center">
                    <font color="#FFFF00"><b>标准商户订单支付接口</b></font>
                </td>
            </tr>
            <tr>
                <td width="37%">提交地址
                </td>
                <td width="63%">
                    <select name="test">
                        <option value="1">测试环境</option>
                        <option value="0" selected="selected">正式环境</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>交易账户号
                </td>
                <td>
                    <input type="text" name="Mer_code" size="18" value="T0000601" /><!--测试交易账户号-->
                </td>
            </tr>
            <tr>
                <td>商户证书
                </td>
                <td>
                    <input type="text" name="Mer_key" size="40" value="5ZHutEUzonmP8rIe18DBuOiP4qAjplzTJ5gaIbfHLcDXh50MQTR6THNHRRQceLkcNsfdkHvz2VQsllIYQOsvuTacHzjQldDZRAkOzxBj71dYR55FjRmp2PITsdvL75oz" /><!--测试商户号-->
                </td>
            </tr>
            <tr>
                <td>订单号
                </td>
                <td>
                    <input type="text" name="Billno" size="24" id="Billno" runat="server" />
                </td>
            </tr>
            <tr>
                <td>金&nbsp;&nbsp;额
                </td>
                <td>
                    <input type="text" name="Amount" size="18" value="0.10" /><!--保留两位小数-->
                </td>
            </tr>
            <tr>
                <td>日&nbsp;&nbsp;期
                </td>
                <td>
                    <input type="text" name="Date" size="18" id="Date" runat="server" />
                </td>
            </tr>
            <tr>
                <td>支付币种
                </td>
                <td>
                    <select name="Currency_Type">
                        <option value="RMB" selected="selected">人民币</option>
                        <option value="HKD">港币</option>
                        <option value="USD">USD</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>支付方式
                </td>
                <td>
                    <select name="Gateway_Type">
                        <option value="01" selected="selected">人民币借记卡</option>
                        <option value="02">国际信用卡</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>语言
                </td>
                <td>
                    <select name="Lang">
                        <option value="GB" selected="selected">GB中文</option>
                        <option value="EN">英语</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>支付成功返回URL
                </td>
                <td>
                    <input type="text" name="Merchanturl" size="40" id="Merchanturl" runat="server" />
                </td>
            </tr>
            <tr>
                <td>商户附加数据包
                </td>
                <td>
                    <input type="text" name="Attach" size="40" value="" />
                </td>
            </tr>
            <tr>
                <td>订单支付加密方式
                </td>
                <td>
                    <select name="OrderEncodeType">
                        <option value="2" selected="selected">md5摘要</option>
                        <option value="9">错误</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>交易返回加密方式
                </td>
                <td>
                    <select name="RetEncodeType">
                        <option value="11">md5withRsa</option>
                        <option value="12" selected="selected">md5摘要</option>
                        <option value="9">错误</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>是否提供Server返回方式
                </td>
                <td>
                    <select name="Rettype">
                        <option value="0">无Server to Server</option>
                        <option value="1" selected="selected">有Server to Server</option>
                        <option value="9">错误</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>Server to Server返回页面
                </td>
                <td>
                    <input type="text" name="ServerUrl" id="ServerUrl" size="40" value="" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <input type="submit" value="提交" />
                    <input type="reset" value="重写" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
