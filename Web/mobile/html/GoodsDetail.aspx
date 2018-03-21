<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsDetail.aspx.cs" Inherits="yny_004.Web.mobile.html.GoodsDetail" %>

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
    <div class="content">
        <div class="zh_head">
            <i class="iconfont">&#xe620;</i><span>购买商品</span>
        </div>
        <input type="hidden" id="hidId" runat="server" />
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
            <div class="decribe_btn">
                <input type="button" value="加入购物车" onclick="checkAddCar();" class="buy_btn" />
                <%--<input type="submit" value="立即购买" class="buy_btn">--%>
            </div>
        </div>

    </div>
<%--</div>--%>
<script type="text/javascript">
    function numDesc(obj) {
        var oldNum = $(obj).next().val();
        if (parseInt(oldNum) != 1) {
            var newNum = parseInt(oldNum) - 1;
            $(obj).next().val(newNum);
        }
    }
    function numAsc(obj) {
        var oldNum = $(obj).prev().val();
        var newNum = parseInt(oldNum) + 1;
        $(obj).prev().val(newNum);
    }
    function checkIsNum() {
        var value = $.trim($("#choiceOrderNum").val());
        if (!(/(^\d+$)/.test(value)) || value < 0) {
            v5.error('购买数量只能输入正整数', '1', 'true');
            $("#choiceOrderNum").focus().val("1");
            return false;
        }
    }
    function checkAddCar() {
        var result = GetAjaxString('AddShopCar', $("#hidId").val() + "&count=" + $("#choiceOrderNum").val());
      //  var result = GetAjaxString('AddShopCar', $("#hidId").val() + "&count=" + $("#choiceOrderNum").val(), '/ajax/ajax.aspx');
        if (result == "0") {
            layer.msg("添加失败，请重试");
        }
        else {
            layer.msg("已添加到购物车，您可以在[购物车]中提交订单并结算");
        }
    }
    function checkBuyNow() {
        var result = GetAjaxString('AddShopCar', $("#hidId").val() + "&count=" + $("#choiceOrderNum").val() + "&pop=1");
       // var result = GetAjaxString('AddShopCar', $("#hidId").val() + "&count=" + $("#choiceOrderNum").val() + "&pop=1", '/ajax/ajax.aspx');
        if (result == "1") {

        }
    }

</script>
