<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddReceive.aspx.cs" Inherits="yny_004.Web.Shop.AddReceive" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="/Admin/pop/js/linkage.js" type="text/javascript"></script>
    <title></title>
    <style type="text/css">
        .spRed
        {
            color: Red;
        }
    </style>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <input type="hidden" id="hidId" runat="server" />
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right">
                        收货人姓名:
                    </td>
                    <td>
                        <input id="txtReceive" runat="server" class="normal_input" type="text" maxlength="20" />
                        <span class="spRed">*</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        收货人地址:
                    </td>
                    <td>
                         <select id="ddlProvince" runat="server">
                        </select>
                        <input type="hidden" runat="server" id="hidProvince" />
                        <select id="ddlCity" runat="server">
                        </select>
                        <select id="ddlZone" runat="server">
                        </select><span class="spRed">*</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        详细地址:
                    </td>
                    <td>
                        <input id="txtAddress" runat="server" class="normal_input" type="text" style="width: 50%" /><span
                            class="spRed">*</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        邮编:
                    </td>
                    <td>
                        <input id="txtZipCode" runat="server" class="normal_input" type="text" maxlength="50" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        固定电话:
                    </td>
                    <td>
                        <input id="txtTel" runat="server" class="normal_input" type="text" maxlength="11" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        手机号码:
                    </td>
                    <td>
                        <input id="txtPhone" runat="server" class="normal_input" type="text" maxlength="20" /><span
                            class="spRed">*</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        默认收货人:
                    </td>
                    <td>
                        <input id="chkIsMain" runat="server" type="checkbox" value="1" />
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td align="right">
                        <input name="重置" type="reset" class="normal_btnok" value="重置" style="display: none;" />
                    </td>
                    <td align="left">
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        setTimeout(function () { setup(); }, 200);
        function checkChange() {
            if ($('#txtReceive').val().Trim() == "") {
                v5.error('收货人不能为空', '1', 'true');
            } else if ($('#txtAddress').val() == "") {
                v5.error('收货人地址不能为空', '1', 'true');
            } else if ($('#txtPhone').val() == '') {
                v5.error('手机不能为空', '1', 'true');
            } else {
                if (checkForm()) {
                    $.ajax({
                        type: 'post',
                        url: '/Shop/AddReceive.aspx?Action=add',
                        data: $('#form1').serialize(),
                        success: function (info) {
                            v5.alert(info, '1', 'true');
                            setTimeout(function () { v5.clearall(); }, 1000);
                            callhtml('../Shop/ReceiveInfo.aspx', '收货人管理');
                        }
                    });
                }
            }
        }
    </script>
</body>
</html>
