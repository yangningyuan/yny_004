<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayOrder.aspx.cs" Inherits="yny_004.Web.Shop.PayOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .appImg
        {
            display: block;
            max-width: 100px;
            max-height: 100px;
        }
    </style>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <input type="hidden" id="hidId" runat="server" />
            <div class="goodinfo">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        商品名称
                                    </td>
                                    <td>
                                        价格
                                    </td>
                                    <td>
                                        库存
                                    </td>
                                    <td>
                                        订购数量
                                    </td>
                                    <td>
                                        合计价格
                                    </td>
                                </tr>
                                <asp:Repeater ID="repGoodList" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <img class="appImg" alt="<%#Eval("GName")%>" src="<%#Eval("ImageAddr")%>" />
                                                <%#Eval("GName")%>
                                            </td>
                                            <td>
                                                <%#Eval("CostPrice")%>/<%#Eval("Unit")%>
                                            </td>
                                            <td>
                                                <%#Eval("SellingCount")%>
                                            </td>
                                            <td>
                                                <%#GetOrderDetailCount(Eval("GID"))%>
                                            </td>
                                            <td>
                                                <%#Convert.ToDecimal(Eval("CostPrice")) * GetOrderDetailCount(Eval("GID"))%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="ReceiveDiv">
                                收货人:<%=ReceiveInfoModel.Receiver%>；联系电话<%=ReceiveInfoModel.Phone%>
                                <br />
                                地址:<%=ReceiveInfoModel.DetailAddress%>
                            </div>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td>
                            <strong>数量:</strong> <span class="goodNum numDesc" onclick="numDesc(this)">&nbsp;-&nbsp;</span>
                            <input type="text" id="choiceOrderNum" class="numVal" value="1" onchange="checkIsNum()" />
                            <span class="goodNum numAsc" onclick="numAsc(this)">&nbsp;+&nbsp;</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            支付金额：<%=orderModel.TotalPrice%>；我的<%=yny_004.BLL.Reward.List["MHB"].RewardName %>：<%=TModel.MConfig.MHB%>;我的<%=yny_004.BLL.Reward.List["MJB"].RewardName %>：<%=TModel.MConfig.MJB%>;我的<%=yny_004.BLL.Reward.List["MGP"].RewardName %>：<%=TModel.MConfig.MGP%>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            使用币种：<%=mtype %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input class="btn btn-danger" id="Button1" type="button" runat="server" value="确认支付"
                                onclick="checkBuyNow();" />
                        </td>
                    </tr>
                </table>
            </div>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkBuyNow() {
            ActionModel("/Shop/PayOrder.aspx?Action=Modify", $('#form1').serialize());
        }
    </script>
</body>
</html>
