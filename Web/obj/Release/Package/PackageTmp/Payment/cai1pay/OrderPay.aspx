<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderPay.aspx.cs" Inherits="yny_004.Web.Payment.cai1pay.OrderPay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-Type" content="text/html; charset=gb2312" />
    <title>��׼�̻�����֧���ӿ�</title>
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
                    <font color="#FFFF00"><b>��׼�̻�����֧���ӿ�</b></font>
                </td>
            </tr>
            <tr>
                <td width="37%">�ύ��ַ
                </td>
                <td width="63%">
                    <select name="test">
                        <option value="1">���Ի���</option>
                        <option value="0" selected="selected">��ʽ����</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>�����˻���
                </td>
                <td>
                    <input type="text" name="Mer_code" size="18" value="T0000601" /><!--���Խ����˻���-->
                </td>
            </tr>
            <tr>
                <td>�̻�֤��
                </td>
                <td>
                    <input type="text" name="Mer_key" size="40" value="5ZHutEUzonmP8rIe18DBuOiP4qAjplzTJ5gaIbfHLcDXh50MQTR6THNHRRQceLkcNsfdkHvz2VQsllIYQOsvuTacHzjQldDZRAkOzxBj71dYR55FjRmp2PITsdvL75oz" /><!--�����̻���-->
                </td>
            </tr>
            <tr>
                <td>������
                </td>
                <td>
                    <input type="text" name="Billno" size="24" id="Billno" runat="server" />
                </td>
            </tr>
            <tr>
                <td>��&nbsp;&nbsp;��
                </td>
                <td>
                    <input type="text" name="Amount" size="18" value="0.10" /><!--������λС��-->
                </td>
            </tr>
            <tr>
                <td>��&nbsp;&nbsp;��
                </td>
                <td>
                    <input type="text" name="Date" size="18" id="Date" runat="server" />
                </td>
            </tr>
            <tr>
                <td>֧������
                </td>
                <td>
                    <select name="Currency_Type">
                        <option value="RMB" selected="selected">�����</option>
                        <option value="HKD">�۱�</option>
                        <option value="USD">USD</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>֧����ʽ
                </td>
                <td>
                    <select name="Gateway_Type">
                        <option value="01" selected="selected">����ҽ�ǿ�</option>
                        <option value="02">�������ÿ�</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>����
                </td>
                <td>
                    <select name="Lang">
                        <option value="GB" selected="selected">GB����</option>
                        <option value="EN">Ӣ��</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>֧���ɹ�����URL
                </td>
                <td>
                    <input type="text" name="Merchanturl" size="40" id="Merchanturl" runat="server" />
                </td>
            </tr>
            <tr>
                <td>�̻��������ݰ�
                </td>
                <td>
                    <input type="text" name="Attach" size="40" value="" />
                </td>
            </tr>
            <tr>
                <td>����֧�����ܷ�ʽ
                </td>
                <td>
                    <select name="OrderEncodeType">
                        <option value="2" selected="selected">md5ժҪ</option>
                        <option value="9">����</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>���׷��ؼ��ܷ�ʽ
                </td>
                <td>
                    <select name="RetEncodeType">
                        <option value="11">md5withRsa</option>
                        <option value="12" selected="selected">md5ժҪ</option>
                        <option value="9">����</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>�Ƿ��ṩServer���ط�ʽ
                </td>
                <td>
                    <select name="Rettype">
                        <option value="0">��Server to Server</option>
                        <option value="1" selected="selected">��Server to Server</option>
                        <option value="9">����</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>Server to Server����ҳ��
                </td>
                <td>
                    <input type="text" name="ServerUrl" id="ServerUrl" size="40" value="" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <input type="submit" value="�ύ" />
                    <input type="reset" value="��д" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
