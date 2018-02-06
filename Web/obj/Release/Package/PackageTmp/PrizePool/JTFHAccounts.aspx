<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JTFHAccounts.aspx.cs" Inherits="yny_004.Web.PrizePool.JTFHAccounts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
                <table cellpadding="0" cellspacing="0">
                    <tr style="height: 50px;">
                        <td align="right"></td>
                        <td align="left">
                            <input class="normal_btnok" id="Button1" type="button" runat="server" value="生成子账号"
                                onclick="checkChange1();" />
                        </td>
                        <td align="right"></td>
                        <td align="left">
                            <%--<input class="normal_btnok" id="Button2" type="button" runat="server" value="提现"
                                onclick="checkChange2();" />--%>
                        </td>
                    </tr>
                    <%--<tr style="height: 50px;">
                        <td align="right">日分红执行状态:
                        </td>
                        <td align="left">
                            <span><%=fhzz %></span>
                        </td>
                    </tr>--%>
                </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function getTotalFHMoney(obj) {
            $("#txtTotalFHMoney").val(parseInt($(obj).val()) * parseInt($("#hdTotalMoney").val()));
        }
        function checkChange() {
            ActionModelBack11("PrizePool/JTFHAccounts.aspx?Action=Add", $('#form1').serialize(),
                function () {
                    $("#btnOK").removeAttr("onclick");
                    $("#btnOK").val("请等待...");
                });
        }
        function checkChange1() {
            ActionModelBack11("PrizePool/JTFHAccounts.aspx?Action=Modify", $('#form1').serialize(),
                function () {
                    $("#Button1").removeAttr("onclick");
                    $("#Button1").val("请等待...");
                });
        }
        function checkChange2() {
            ActionModelBack11("PrizePool/JTFHAccounts.aspx?Action=other", $('#form1').serialize(),
                function () {
                    $("#Button1").removeAttr("onclick");
                    $("#Button1").val("请等待...");
                });
        }
        function compute() {
            var count = parseInt($("#txtTotalMember").val());
            var total = parseFloat($("#txtTotalYj").val());
            var permoney = parseFloat($("#txtMoney").val());
            if (permoney == NaN) {
                v5.alert("请输入正确的金额", '1', 'true');
            } else {
                if (total > 0) {
                    $("#txtBoBi").val((count * permoney / total * 100).toFixed(2) + "%");
                }
            }
        }
    </script>
</body>
</html>
