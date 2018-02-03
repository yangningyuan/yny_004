<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFTPayIndex.aspx.cs" Inherits="yny_004.Web.Payment.WFT.WFTPayIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/wechattrade.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="js/wechatpay.js"></script>
</head>

<body>
    <form id="form1" runat="server">
        <%--<div class="header">
            <div class="wrap">
                <a href="#">返回</a>
            </div>
        </div>--%>
        <div class="topwrap box-shadow-def">
            <div class="innerwrap box-border-def hide-coupon">
                <div class="innercnt">
                    <div class="innercnt-wrap clearfix">
                        <div class="orders show-orders-single" id="order_wrap">
                            <div class="orders-single">
                                <h2 class="orders-title">微信支付</h2>

                                <div class="orders-detail">
                                    <a href="#" class="js-detail"><span class="item-name">订单号：</span><span class="item-value"><asp:Label ID="orderno2" runat="server" Text=""></asp:Label></span></a>
                                    <div class="layer-tips layer-tips-wide layer-tips-stress detail-layer-tips">
                                        <span class="ico-direction-t">
                                            <!-- 图标 -->
                                        </span><a href="#none" class="btn-close js-close" title="关闭">关闭</a>
                                        <div class="layer-tips-main">
                                            <ul class="detail-list">
                                                <li><span class="item-name">订单号：</span><span class="item-value"><asp:Label ID="orderno" runat="server" Text=""></asp:Label></span></li>
                                                <li><span class="item-name">商品描述：</span><span class="item-value"><asp:Label ID="shopdesc" runat="server"></asp:Label></span></li>
                                                <li><span class="item-name">附加信息：</span><span class="item-value"><asp:Label ID="attach" runat="server"></asp:Label></span></li>
                                                <li><span class="item-name">总 金 额：</span><span class="item-value"><asp:Label ID="money" runat="server"></asp:Label>元</span></li>
                                                <%-- <li><span class="item-name">订 单 号：</span><span class="item-value">M1503160636</span></li>
                                            <li><span class="item-name">交易金额：</span><span class="item-value">1.00</span></li>--%>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                <div class="orders-money">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="pay_total_money" class="pay-money">
                    <div class="money-line">
                        应付：<strong id="total_fee_show" class="money"><asp:Label ID="totalmoney" runat="server"></asp:Label></strong>元
                    </div>
                </div>
            </div>
            <div id="payMsg">
                <div class="area" id="qr_normal">
                    <span class="qr_img_wrapper">
                        <img class="qrcode" alt="二维码" id="QRcode" src="#" runat="server" />

                        <img class="guide " src="image/webpay_guide.gif" alt="" id="guide" /></span>
                    <div class="msg_default_cg">
                        <i class="icon60_qr pngFix"></i>
                        <p>
                            请使用微信扫码<br />
                            二维码以完成支付
                        </p>

                    </div>
                </div>
            </div>
        </div>       
    </form>

</body>
</html>
