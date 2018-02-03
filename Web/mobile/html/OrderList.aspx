<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="yny_004.Web.mobile.html.OrderList" %>

<%--<div id="pageHome" class="page out">--%>
    <div class="content">
        <div class="zh_head">
            <i class="iconfont">&#xe610;</i><span>订单列表</span>
        </div>
        <form id="form1">
            <div class="buttons-tab">
                <input type="hidden" value="" id="state" runat="server" />
                <a href="javascript:void(0)" onclick="$('#state').val(''); dianji(this); " class="btn_new background_2 requery">全部</a>
                <a href="javascript:void(0)" onclick="$('#state').val('1'); dianji(this); " class="btn_new background_3 requery">未支付</a>
                <a href="javascript:void(0)" onclick="$('#state').val('2'); dianji(this); " class="btn_new background_3 requery">未发货</a>
                <a href="javascript:void(0)" onclick="$('#state').val('3'); dianji(this); " class="btn_new background_3 requery">未收货</a>
                <a href="javascript:void(0)" onclick="$('#state').val('4'); dianji(this); " class="btn_new background_3 requery">完成</a>
            </div>
        </form>
        <%--<a href="#" class="btn_new background_4">备用</a>--%>

        <script type="text/x-jquery-tmpl" id="OrderListTmpl">
            <tr>
                <td>${Money}</td>
                <td>${GCount}</td>
                <td>${Date}</td>
                <td>${State}</td>
                <td>{{html op}}</td>
            </tr>
        </script>
        <table class="gridtable">
            <tr>
                <th>订单总价</th>
                <th>商品数量</th>
                <th>时间</th>
                <th>状态</th>
                <th style="width: 100px;">操作</th>
            </tr>
            <tbody id="data_container">
            </tbody>
        </table>
        <div id="page_container">
        </div>
    </div>
<%--</div>--%>
<script>
    $(function () {
        $('#data_container').on('click', '.list-detail', function () {
            //console.log(parseInt($(this).next().css('height')));
            if (parseInt($(this).next().css('height')) < 300) {
                $(this).next().css('height', '300px');
            }

            $(this).next().slideDown();
        })
        $('#data_container').on('click', '.detail-close', function () {
            $(this).parent().slideUp();
        })
    })
</script>
<script type="text/javascript">
    setTimeout(function () {
        $('#page_container').Paging({
            TemplateContainer: '#OrderListTmpl',
            DataContainer: '#data_container',
            DataUrl: '/mobile/html/OrderList.aspx?Action=Other',
            QueryContainer: '#form1',
            Rendered: function () {
                window.MobileSelectAll();
            }
        });
    }, 50);

    //跳转到支付页面
    function payOrder(id) {
        pcallhtml('/mobile/html/PayOrder.aspx?id=' + id, '订单支付');
    }


    //确认收货
    function receiveOrder(id) {
        orderId = id;
        layer.confirm("确定收到货了吗？", realReceive);
    }
    function realReceive() {
        var result = GetAjaxString('receiveOrder', orderId);
        if (result == 0) {
            layer.msg("收货失败，请重试 ");
        }
        else {
            layer.msg("确认收货成功 ");
            pcallhtml('/mobile/html/OrderList.aspx', '订单列表');
        }
    }

    function wuliu(content)
    {
        layer.open({
            type: 1,
            skin: 'layui-layer-demo', //样式类名
            closeBtn: 0, //不显示关闭按钮
            anim: 2,
            shadeClose: true, //开启遮罩关闭
            content: content
        });
    }
</script>
