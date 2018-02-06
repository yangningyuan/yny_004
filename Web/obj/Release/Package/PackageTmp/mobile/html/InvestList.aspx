<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvestList.aspx.cs" Inherits="yny_004.Web.mobile.html.InvestList" %>

<div class="content content-padded pull-to-refresh-content" data-ptr-distance="55">
    <!-- 默认的下拉刷新层 -->
    <div class="pull-to-refresh-layer">
        <div class="preloader"></div>
        <div class="pull-to-refresh-arrow"></div>
    </div>
   <%-- <div class="searchbar row">
        <div class="search-input col-80">
            <input type="search" placeholder="会员账号" id="search" />
        </div>
        <a class="button button-fill button-primary col-20">查询</a>
    </div>--%>
    <%--<p>
        <a class="button button-fill button-success">我要退本</a>
    </p>--%>

    <script type="text/x-jquery-tmpl" id="InvestListTmpl">
        <tr>
            
            <td>${Money}</td>
            <td>${DayCount}</td>
            <td>${LJMoney}</td>
            <td>${Date}</td>
            <td>{{html dhtml}}</td>
        </tr>
    </script>

    <table class=" table table-striped table-bordered ">
        <thead>
            <tr>
                <th>投资金额</th>
                <th>收益天数</th>
                <th>累计收益</th>
                <th>时间</th>
                <th>操作</th>
            </tr>
        </thead>
        <tbody id="data_container">
        </tbody>
    </table>
    <div id="page_container">
    </div>
</div>

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
            TemplateContainer: '#InvestListTmpl',
            DataContainer: '#data_container',
            DataUrl: '/mobile/html/InvestList.aspx?Action=Other',
            QueryContainer: '#form1',
            Rendered: function () {
                window.MobileSelectAll();
            }
        });
    }, 50);


    function InvestOperate(ajaxKey, id, func) {
        
            var data = RunAjaxGetKey(ajaxKey, id, null, null, 'Module/Investment/Handler/Ajax.ashx');
            PageLoad();
            layer.msg(data);
        
    }
</script>
