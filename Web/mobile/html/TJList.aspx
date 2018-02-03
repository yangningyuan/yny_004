<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TJList.aspx.cs" Inherits="yny_004.Web.mobile.html.TJList" %>

<div class="content content-padded pull-to-refresh-content" data-ptr-distance="55">
    <!-- 默认的下拉刷新层 -->
    <div class="pull-to-refresh-layer">
        <div class="preloader"></div>
        <div class="pull-to-refresh-arrow"></div>
    </div>


    <script type="text/x-jquery-tmpl" id="TJListTmpl">
        <tr>
            <td>${MID}</td>
            <td>${MHB}</td>
            <td>${MJB}</td>
            <td>${Date}</td>
            
        </tr>
    </script>

    <table class=" table table-striped table-bordered ">
        <thead>
            <tr>
                <th>会员账号</th>
                <th><%=yny_004.BLL.Reward.List["MHB"].RewardName %></th>
                <th><%=yny_004.BLL.Reward.List["MJB"].RewardName %></th>
                <th>注册/激活时间</th>
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
            TemplateContainer: '#TJListTmpl',
            DataContainer: '#data_container',
            DataUrl: '/mobile/html/TJList.aspx?Action=Other',
            QueryContainer: '#form1',
            Rendered: function () {
                window.MobileSelectAll();
            }
        });
    }, 50);
</script>
