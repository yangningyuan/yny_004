<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayOrder.aspx.cs" Inherits="yny_004.Web.mobile.html.PayOrder" %>
<style>
    #rdoMJB,#rdoXFB{
        width:5%;
        line-height:14px;
        height:14px;
        margin:0;
    }
</style>
<%--<div id="pageHome" class="page out">--%>
    <form id="form1">
        <div class="content">
            <div class="zh_head">
                <i class="iconfont">&#xe61e;</i><span>订单支付</span>
            </div>
          <input id="hdBankCode" type="hidden" runat="server" />
            <input type="hidden" id="hidId" runat="server" />
            <div class="zc_in">
                <span>商品详细信息：</span>
                <p>总件数：<%=orderModel.GoodCount%>件</p>
                <p>商品金额：￥<%=orderModel.TotalPrice%></p>
                <p><%=strgoods %></p>
            </div>
            <div class="zc_in">
                <span>收货信息：</span>
                <table class="table">
                    <tbody>
                    <tr>
                        <td>收货人：</td>
                        <td><%=ReceiveInfoModel.Receiver%></td>
                        <td>电话：</td>
                        <td><%=ReceiveInfoModel.Phone%></td>
                    </tr>
                    <tr>
                        <td>收货地址:</td>
                        <td colspan="3"><%=ReceiveInfoModel.DetailAddress%></td>
                    </tr>
                   
                    </tbody>
                </table>
            </div>
            <div class="zc_in">
                <span>支付方式：</span>

                <input id="rdoXFB" value="MHB" type="radio" name="rdo"/><label for="wx"><%=yny_004.BLL.Reward.List["MHB"].RewardName%></label>
            </div>
            <div class="zc_in">
                <span>币种余额：</span>
              我的<%=yny_004.BLL.Reward.List["MHB"].RewardName %>：<%=TModel.MConfig.MHB%>
            </div>
            <a href="javascript:void(0)" title="" id="Button1" runat="server" class="btn_qd" style="display: block;" onclick="checkBuyNow();">支付</a>

        </div>
    </form>
<%--</div>--%>
  <script type="text/javascript">
    function checkBuyNow() {
        ActionModel("/Shop/PayOrder.aspx?Action=Modify", $('#form1').serialize(), "/mobile/html/OrderList.aspx");
    }
    </script>
