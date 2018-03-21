<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsDetailGP.aspx.cs" Inherits="yny_004.Web.mobile.html.GoodsDetailGP" %>

<style>
    body {
        background-color: #FFFFFF;
    }

    p > a {
        color: green;
    }

    .btn {
        background-color: #0074d9;
    }

    .tab {
        position: absolute;
        width: 100%;
        height: 100%;
        white-space: nowrap;
        text-align: center;
    }

        .tab:after {
            content: '';
            display: inline-block;
            width: 0;
            height: 100%;
            vertical-align: middle;
        }

        .tab img {
            vertical-align: middle;
        }

    .tab-inner {
        height: 256px;
        position: relative;
        overflow: hidden;
    }
</style>
<%--<div id="pageHome" class="page out">--%>
<form id="form1">
    <div class="content">
        <div class="zh_head">
            <i class="iconfont">&#xe620;</i><span>购买商品</span>
        </div>
        <input type="hidden" id="hidId" runat="server" />
        <input type="hidden" id="isautoreceive" runat="server" />
        <input type="hidden" id="remid" runat="server" />
        <input type="hidden" id="choiceOrderNum" class="numVal" value="1" onchange="checkIsNum()" />
        <div class="bannerBox2">

            <asp:repeater id="rep_PicList" runat="server">
                                    <ItemTemplate>
                                            <img width="100%"  src="<%#Eval("PicURL") %>" />
                                    </ItemTemplate>
                                </asp:repeater>


        </div>
        <div class="decribe_product">
            <div class="product_header">
                <div class="dectibe_sales">
                    <h2><%=model.GName%>&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: slategrey;"> <%=GetCategory(model.GParentCode)%></span> </h2>
                    <%--  <p>总销量：<span class="orange"><%=model.SelledCount%></span></p>
                <p class="gray">库存：<%=model.SellingCount%><span>单位：<%=model.Unit%></span><span></span></p>--%>
                    <!--         <label>总销量：<span>3057</span></label>
 -->
                    <!--         <label><a>点击收藏</a><img src="images/wuxing.png"/></label>
 -->
                </div>
                <div class="sales_price">
                    <span>￥<%=model.CostPrice%></span>
                </div>
            </div>
            <div class="decribe_tab">
                <ul class="tab_btn">
                    <li class="color_tab"><a>产品详情</a></li>
                    <!--           <li><a>产品详情</a></li>  
          <li><a>产品详情</a></li>  
          <li><a>产品详情</a></li>  -->
                </ul>
                <div class="area01">
                    <p><%=model.Remark%></p>
                    <div class="product_bi">
                        <div class="product_02">
                            <%--<img src="/mobile/images/product_02.png" />--%>
                        </div>

                    </div>
                </div>

            </div>
            <div style="display: none; margin-left: 5%; margin-top: 20px;" id="shrdiv">
                <div class="zc_in">
                    <span>收货人姓名：</span>
                    <input id="txtReceive" runat="server" type="text" maxlength="20" />
                </div>
                <div class="zc_in">
                    <span>收货人地址：</span>
                    <select id="ddlProvince" runat="server" style="">
                    </select><span>*</span><br>
                    <input type="hidden" runat="server" id="hidProvince" />
                    <select id="ddlCity" runat="server" style="">
                    </select><span>*</span><br>
                    <select id="ddlZone" runat="server" style="">
                    </select>
                </div>
                <div class="zc_in">
                    <span>详细地址：</span>
                    <input id="txtAddress" runat="server" type="text" />
                </div>

                <div class="zc_in">
                    <span>手机号码：</span>
                    <input id="txtPhone" runat="server" type="text" maxlength="20" />
                </div>
                <div class="zc_in" style="display: none;">
                    <span>默认收货人：</span>
                    <input id="chkIsMain" runat="server" type="checkbox" value="1" />
                </div>

            </div>
        </div>
        <div class="decribe_btn" style="margin-left: 5%; margin-top: 20px;">
            使用币种：<%=mtype %>
        </div>
        <%--<div class="item-content">
        <div class="item-inner">
            <div class="item-title label">使用币种</div>
            <div class="item-input">
                <select name="rdoXFB" id="rdoXFB">
                    <%=mtype %>
                </select>
            </div>
        </div>
    </div>--%>
        <div class="decribe_btn" style="padding-bottom: 20px;" id="addreceive">
            <input type="button" value="立即购买" onclick="checkAddCar();" class="buy_btn" />

        </div>
        <div class="decribe_btn" style="padding-bottom: 20px; display: none;" id="addOrder">
            <input type="button" value="立即购买" onclick="checkSubOrder();" class="buy_btn" />

        </div>



    </div>
</form>
<%--</div>--%>
<script type="text/javascript">
    $(function () {
        setup();
    });

    function checkAddCar() {
        if ($("#isautoreceive").val().Trim() == "0") {
            document.getElementById("shrdiv").style.display = "block";
            document.getElementById("addreceive").style.display = "none";
            document.getElementById("addOrder").style.display = "block";
        } else {
            $.ajax({
                type: 'post',
                url: '/Shop/PayOrder.aspx?Action=add',
                data: $('#form1').serialize(),
                success: function (info) {
                    layer.msg(info);
                    pcallhtml('/mobile/html/OrderList.aspx', '订单管理');
                }
            });
        }

    }

    function checkSubOrder() {
        if ($('#txtReceive').val().Trim() == "") {
            layer.msg('收货人不能为空');
        } else if ($('#txtAddress').val() == "") {
            layer.msg('收货人地址不能为空');
        } else if ($('#txtPhone').val() == '') {
            layer.msg('手机不能为空');
        } else {
            if (checkForm()) {
                $.ajax({
                    type: 'post',
                    url: '/Shop/PayOrder.aspx?Action=add',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        layer.msg(info);
                        pcallhtml('/mobile/html/OrderList.aspx', '订单管理');
                    }
                });
            }
        }
    }

</script>
