<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyGoods.aspx.cs" Inherits="yny_004.Web.mobile.html.BuyGoods" %>

<link rel="stylesheet" href="/mobile/css/btn.css">
<link rel="stylesheet" href="/mobile/css/style.css">
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
    <div class="banner">
        <div class="banner_Carousel">
            <div class="carousel slide" data-ride="carousel" id="carousel3">
                <div class="carousel-inner">
                    <div class="Z">
                        <div class="zh_head">
                            <i class="iconfont">&#xe620;</i><span>购买商品</span>
                        </div>
                        <%
                            foreach (yny_004.Model.GoodCategory item in listcate)
                            {
                        %>
                        <ul class="zhanjaiBOx">
                            <%
                                foreach (yny_004.Model.Goods item2 in yny_004.BLL.Goods.GetList(" GParentCode='" + item.Code + "' and IsDeleted=0;"))
                                {
                            %>
                            <li>
                                <a href="javascript:pcallhtml('/mobile/html/GoodsDetail.aspx?id=<%=item2.GID %>', '商品详细');">

                                    <%if (yny_004.BLL.GoodsPic.GetList("IsDeleted=0 and GId='" + item2.GoodsCode + "'").FirstOrDefault() == null)
                                        {%>

                                    <img src="../img/a1.jpg" />
                                    <% }
                                        else
                                        {%>
                                    <img src="<%= yny_004.BLL.GoodsPic.GetList("IsDeleted=0 and GId='" + item2.GoodsCode + "'").FirstOrDefault().PicURL %>">

                                    <% } %>

                                    <h4><%=item2.GName %></h4>
                                    <b>￥<%=item2.CostPrice %></b>
                                </a>
                            </li>
                            <%
                                }
                            %>
                        </ul>
                        <%
                            }
                        %>
                    </div>
                </div>
            </div>
        </div>
    </div>


</div>
<%--</div>--%>
