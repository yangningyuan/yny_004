<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="yny_004.Web.Member.View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="15%" align="right">会员账号:
                    </td>
                    <td width="35%">
                        <%=TModel.MID %>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">会员姓名:
                    </td>
                    <td width="35%">
                        <%=TModel.MName %>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">会员类型:
                    </td>
                    <td width="35%">
                        <%=TModel.Role.RName %>
                    </td>
                </tr>
                <%--<tr>
                    <td width="15%" align="right">
                        会员等级:
                    </td>
                    <td width="35%">
                        <%=TModel.MAgencyType.MAgencyName %>
                    </td>
                </tr>--%>
                <%--<tr>
                    <td align="right">
                        手机号码:
                    </td>
                    <td>
                        <%=TModel.Tel %>
                    </td>
                </tr>--%>
                <%--<tr>
                    <td align="right">
                        支付宝:
                    </td>
                    <td>
                        <%=TModel.Alipay %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        微信:
                    </td>
                    <td>
                        <%=TModel.WeChat %>
                    </td>
                </tr>--%>
                <%--<tr>
                    <td align="right">
                        身份证号:
                    </td>
                    <td>
                        <%=TModel.NumID %>
                    </td>
                </tr>--%>
                <tr>
                    <td align="right">推荐人:
                    </td>
                    <td>
                        <%=TModel.MTJ %>
                    </td>
                </tr>
                <%--<tr>
                    <td align="right">
                        报单中心:
                    </td>
                    <td>
                        <%=TModel.MSH %>
                    </td>
                </tr>--%>
                <tr>
                    <td align="right">激活日期:
                    </td>
                    <td>
                        <%=TModel.MDate.ToString("yyyy-MM-dd HH:mm:ss") %>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <b>提现信息</b>
                    </td>
                </tr>
                <tr>
                    <td align="right">开户地区:
                    </td>
                    <td>
                        <%=TModel.Province %><%=TModel.City %>
                    </td>
                </tr>
                <tr>
                    <td align="right">开户银行:
                    </td>
                    <td>
                        <asp:Label ID="lbBank" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">开户支行:
                    </td>
                    <td>
                        <asp:Label ID="lbBranch" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">银行卡号:
                    </td>
                    <td>
                        <asp:Label ID="lbBankNumber" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">开户姓名:
                    </td>
                    <td>
                        <asp:Label ID="lbBankCardName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <b>账户信息</b>
                    </td>
                </tr>
                <%if (TModel.MConfig != null)
                    { %>
                <tr>
                    <td align="right">
                        <%=yny_004.BLL.Reward.List["MHB"].RewardName %>:
                    </td>
                    <td>
                        <%=TModel.MConfig.MJJ.ToFixedString()%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <%=yny_004.BLL.Reward.List["MJB"].RewardName %>:
                    </td>
                    <td>
                        <%=TModel.MConfig.MJB.ToFixedString()%>
                    </td>
                </tr>
                <%--<tr>
                    <td align="right">
                        <%=yny_004.BLL.Reward.List["MGP"].RewardName %>:
                    </td>
                    <td>
                        <%=TModel.MConfig.MGP.ToFixedString()%>
                    </td>
                </tr>--%>
                <%--<tr>
                    <td align="right">
                        <%=yny_004.BLL.Reward.List["MCW"].RewardName %>:
                    </td>
                    <td>
                        <%=TModel.MConfig.MCW.ToFixedString()%>
                    </td>
                </tr>--%>
                <%} %>
                <%--<tr>
                    <td colspan="2" align="center">
                        <b>图片认证</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <img alt="请上传身份证图片" src="<%=TModel.Address %>" />
                    </td>
                </tr>--%>
            </table>
        </div>
    </div>
</body>
</html>
