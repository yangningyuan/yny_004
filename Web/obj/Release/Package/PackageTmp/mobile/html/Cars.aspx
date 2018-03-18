<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cars.aspx.cs" Inherits="yny_004.Web.mobile.html.Cars" %>

<style>
    .goods-num span {
        font-size: 2.3rem;
        padding: 5px 8px;
    }

    .goods-num span {
        font-size: 2.3rem;
        padding: 5px 8px;
    }

    .goods-num input {
        width: 35px;
        text-align: center;
        overflow: visible;
        font-size: 1.3rem;
    }

    .yes {
        height: 25px;
        margin: 0 10px;
        width: auto;
        display: inline-block;
    }

    .pro_logo {
        height: 20px;
        margin-right: 5px;
        width: auto;
        display: inline-block;
    }

    .media-object {
        display: inline-block;
    }

    .produce {
        width: 80px;
        height: 80px;
        background: #fff;
    }

    .btn_qd {
        bottom: 80px;
        display: block;
        position: fixed;
    }

    .yes {
        float: left;
    }

    .pro_y {
        margin-top: 35px;
    }

    .left {
        float: left;
    }

    .media {
        padding: 10px 0;
        background-color: white;
        height: 100px;
    }
</style>

<body class="shoppingCar">
    <div data-role="page" class="page2" id="page3">
        <div class="zh_head">
            <i class="iconfont">&#xe620;</i><span>购买商品</span>
        </div>
        <form id="form1">
            <div id="receiveDiv">
                <table class="table">
                    <asp:Repeater ID="repReceiveList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <input type="radio" name="rdreecive" <%#Convert.ToBoolean(Eval("IsMain"))?"checked='checked'":""%>
                                        value="<%#Eval("Id")%>" />
                                </td>
                                <td>
                                    <%#Eval("Receiver")%>
                                </td>
                                <td>
                                    <%#Eval("DetailAddress")%>
                                </td>
                                <td>
                                    <%#Eval("Phone")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <%--<tr>
                    <td colspan="4">
                        <input type="button" onclick="choiceReceive()" class="btn btn-success btn-sm" value="确定" />
                    </td>
                </tr>--%>
                </table>
            </div>
            <section id="main">
                <%--  <div class="buy_handle finish_edit">
                    <p>
                        <img src="/mobile/images/circle.png" alt="" class="yes">
                        <img src="/mobile/images/p_logo.png" alt="" class="pro_logo">&nbsp; &gt;<span class="edit">编辑</span></p>

                    <%
                        foreach (yny_004.Model.ShopCar item in listshop)
                        {
                            yny_004.Model.Goods goods = yny_004.BLL.Goods.GetModel(item.GId);
                    %>
                    <div class="media">
                        <a class="pull-left" href="#">
                            <img class="media-object yes" src="/mobile/images/circle.png" alt="<%=item.Id %>"><img class="media-object produce" src="<%=goods.ImageAddr %>" alt="<%=goods.GName %>">
                        </a>
                        <div class="media-body">
                            <p><%=goods.GName %>
                                <br>
                                <%=goods.GParentCode %></p>
                            <p class="handle_price"><span>￥<b><%=item.BuyPrice%></b></span> <span id="<%=item.Id %>"><%=item.GCount %></span></p>
                        </div>
                    </div>
                    <%
                        }
                    %>
                </div>--%>

                <div class="buy_handle edit_goods">
                    <p style="margin:10px;">
                        <img src="/mobile/img/circle.png" alt="" class="yes">
                        <img src="/mobile/img/p_logo.png" alt="" class="pro_logo">
                        <span class="left">全选</span>

                    </p>

                    <%
                        foreach (yny_004.Model.ShopCar item in listshop)
                        {
                            yny_004.Model.Goods goods = yny_004.BLL.Goods.GetModel(item.GId);
                    %>
                    <div class="media">
                        <a class="pull-left" href="#">
                            <img class="media-object yes pro_y" src="/mobile/img/circle.png" alt="<%=item.Id %>">
                            <%if (yny_004.BLL.GoodsPic.GetList("IsDeleted=0 and GId='" + goods.GoodsCode + "'").FirstOrDefault() == null)
                                {%>
                            <img class="media-object produce" src="../img/a1.jpg" >

                            <% }
                                else
                                {%>
                            <img class="media-object produce" src="<%= yny_004.BLL.GoodsPic.GetList("IsDeleted=0 and GId='" + goods.GoodsCode + "'").FirstOrDefault().PicURL %>" alt="<%=goods.GName %>">

                            <% } %>

                        </a>
                        <div class="media-body goods-num">
                            <span class="reduce glyphicon-minus">
                                <input type="hidden" value="<%=item.Id %>" />-</span>
                            <input type="text" style="width: 50px;" value="<%=item.GCount %>">
                            <span class="add glyphicon-plus">
                                <input type="hidden" value="<%=item.Id %>" />+</span>
                        </div>
                        <%--<div class="delete" onclick="deletecar(<%=item.Id %>)">
                            删除
                        </div>--%><a class="del_xiangqing" style="float:right; margin-right:20px;" href="javascript:deletecar('<%=item.Id %>')">删除</a>
                    </div>
                    <%
                        }
                    %>

                    <input type="hidden" id="del_id" value="" runat="server" />

                </div>
            </section>
            <a href="javascript:void(0)" onclick="choiceReceive();" title="" class="btn_qd" style="display: block;">提交订单</a>
        </form>
    </div>
    <div class="alert1" style="display: none">
        <div class="alert1_content">
            <p>
                更多功能，敬请期待...
            </p>
        </div>
        <span class="alert1_close">X</span>
    </div>
    <script type="text/javascript">
        function updateGoodCarCount(carId, count) {
            var result = GetAjaxString('UpdateShopCar', carId + "&count=" + count, '/AjaxM/ajax.aspx');
            if (result != "0" && result != "1")
            {
                $("#" + carId).html("1");
                layer.msg(result);
            }
        }
        function deletecar(obj) {
            $("#del_id").val(obj);
            ActionModel("/mobile/html/Cars.aspx?Action=Modify", $('#form1').serialize(), "/mobile/html/Cars.aspx");
        }
    </script>
    <script>
        $('.reduce').on('click', function () {
            var num = parseInt($(this).next().val());
            if (num > 1) {
                var num1 = num - 1;
                $(this).next().val(num1);
                var id = $(this).children("input").val();
                $("#" + id).html(num1);
                updateGoodCarCount(id, num1);
            }
        })
        $('.add').on('click', function () {
            var num = parseInt($(this).prev().val());
            var num1 = num + 1;
            $(this).prev().val(num1);
            var id = $(this).children("input").val();
            $("#" + id).html(num1);
            updateGoodCarCount(id, num1);
        })
        $('.edit').on('click', function () {
            $('.edit_goods').css('display', 'block');
            $('.finish_edit').css('display', 'none');
            var yes_list = $(this).parent().siblings().children(':first-child').children(':first-child');
            for (var i = 0; i < yes_list.length; i++) {
                if (yes_list[i].getAttribute('src') == '/mobile/img/circle.png') {
                    $($('.edit_goods').children('div')[i]).css('display', 'none');
                } else {
                    $($('.edit_goods').children('div')[i]).css('display', 'block');
                }
            }
        })
        $('.finish').on('click', function () {
            $('.edit_goods').css('display', 'none');
            $('.finish_edit').css('display', 'block');
        })
        $('.buy_handle p img:first-child').on('click', function () {
            if ($(this).attr('src') == '/mobile/img/yes.png') {
                $(this).attr('src', '/mobile/img/circle.png').parent().siblings().children(':first-child').children(':first-child').attr('src', '/mobile/img/circle.png').removeClass('yes-checked');
            } else {
                $(this).attr('src', '/mobile/img/yes.png').parent().siblings().children(':first-child').children(':first-child').attr('src', '/mobile/images/yes.png').addClass('yes-checked');
            }
        })
        $('.buy_handle .pull-left img:first-child').on('click', function () {
            if ($(this).attr('src') == '/mobile/img/yes.png') {
                $(this).removeClass('yes-checked').attr('src', '/mobile/img/circle.png').parent().parent().parent().children(':first-child').children(':first-child').attr('src', '/mobile/images/circle.png');
            } else {
                $(this).addClass('yes-checked').attr('src', '/mobile/img/yes.png');
                var list = $(this).parent().parent().siblings().children(':first-child').children(':first-child');
                for (var i = 0; i < list.length; i++) {
                    if (list[i].getAttribute('src') == '/mobile/img/circle.png') {
                        break;
                    }
                    $(this).parent().parent().parent().children(':first-child').children(':first-child').attr('src', '/mobile/img/yes.png');
                }
            }
            //        if($(this).parent().parent().siblings().children(':first-child').children(':first-child').attr('src')==){
            //
            //        }

        })

    </script>
    <script type="text/javascript">
        var pageii;
        function showReceiveInfo() {
            if ($("#receiveDiv tr").length < 2) {
                layer.msg("您未添加收货人，请先添加收货人");
                setTimeout(function () {
                    //跳转到收货人
                    //callhtml('../Shop/AddReceiveAuto.aspx', '购物车');
                }, 1000);
                return;
            }

            pageii = layer.open({
                type: 1,
                shade: true,
                title: "选择收货人", //不显示标题
                skin: 'layui-layer-rim', //加上边框
                content: $('#receiveDiv'), //捕获的元素
                cancel: function (index) {
                    layer.close(index);
                }
            });
        }
        function choiceReceive() {
            layer.close(pageii);
            var rid = $('input:radio:checked').val();
            if (typeof (rid) == "undefined" || rid == "") {
                layer.msg("您未添加收货人，请在[收货人管理]中添加收货人");
                return false;
            }
            if ($(".edit_goods .yes-checked").length > 0) {
                var cid = "";
                for (var i = 0; i < $(".edit_goods .yes-checked").length; i++) {
                    cid += $($(".edit_goods .yes-checked")[i]).attr("alt") + ",";
                }

                $("#receiveDiv").attr('style', 'display:block');
                //RunAjaxByListAddKeyShop('', 'SubmitOrder', ',', rid, cid.substring(0, cid.length - 1));

                var result = GetAjaxString('SubmitOrder', cid.substring(0, cid.length - 1) + "&otherParm=" + rid);
                if (result == "订单提交成功") {
                    layer.msg(result);
                    setTimeout(pcallhtml('/mobile/html/OrderList.aspx', '订单列表'), 500);
                } else {
                    layer.msg(result);
                }
            } else {
                layer.msg("请选择商品再提交");
            }
        }
    </script>
</body>
