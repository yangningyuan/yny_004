<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HKList.aspx.cs" Inherits="yny_004.Web.mobile.html.HKList" %>

<div class="content content-padded pull-to-refresh-content" data-ptr-distance="55">
    <!-- 默认的下拉刷新层 -->
    <div class="pull-to-refresh-layer">
        <div class="preloader"></div>
        <div class="pull-to-refresh-arrow"></div>
    </div>
    <%-- <p>
        <a href="javascript:void(0)"  onclick="pcallhtml('/mobile/html/PayHB.aspx','在线充值');" class="button button-fill button-success"> 网银支付</a>
    </p>--%>

    <p>
        <a href="javascript:void(0)" onclick="pcallhtml('/mobile/html/HKChangeFlow.aspx','银行汇款');" class="button button-fill button-success">支付宝快速入金
        </a>
    </p>
    <p>
        <a href="javascript:void(0)" onclick="pcallhtml('/mobile/html/HKChangeWY.aspx','网银汇款');" class="button button-fill button-success">网银汇款
        </a>
    </p>
    <p>
        <a href="javascript:void(0)" onclick="pcallhtml('/mobile/html/WXChange.aspx','微信汇款');" class="button button-fill button-success">微信汇款
        </a>
    </p>
    <script type="text/x-jquery-tmpl" id="HKListTmpl">
        <tr>
            <td>${MoneyType}</td>
            <td>${Money}</td>
            <td>${State}</td>
            <td>${Date}</td>
            <td>${Type}</td>
        </tr>
    </script>
    <table class=" table table-striped table-bordered ">
        <thead>
            <tr>

                <th>充值币种</th>
                <th>实际汇款</th>
                <th>是否生效</th>
                <th>汇款时间</th>
                <th>汇款方式</th>
            </tr>
        </thead>
        <tbody id="data_container">
        </tbody>
    </table>
    <div id="page_container" class="paginList">
    </div>
</div>
<script type="text/javascript">

    setTimeout(function () {
        $('#page_container').Paging({
            TemplateContainer: '#HKListTmpl',
            DataContainer: '#data_container',
            DataUrl: '/mobile/html/HKList.aspx?Action=Other',
            QueryContainer: '#form1',
            Rendered: function () {
                window.MobileSelectAll();
            }
        });
        $('a:contains(批量删除)').click(function () {
            var result = $('.select_item:checked').toEnumerable().Select('item=>item.attr("id")').ToArray();
            //                var result = $('.select_item:checked').toEnumerable().Select(function (self) {
            //                    return "'" + self.attr('id') + "'";
            //                }).ToArray();
            console.log(result.join(','));
        });
    }, 50);
</script>
