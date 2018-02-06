<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HBList.aspx.cs" Inherits="yny_004.Web.mobile.html.HBList" %>

<div class="content content-padded pull-to-refresh-content" data-ptr-distance="55">
    <!-- 默认的下拉刷新层 -->
    <div class="pull-to-refresh-layer">
        <div class="preloader"></div>
        <div class="pull-to-refresh-arrow"></div>
    </div>
    <p>
        <a href="javascript:void(0)" onclick="pcallhtml('/mobile/html/HBChange.aspx','转账');" class="button button-fill button-success">转账</a>
    </p>
     <%--<p>
        <a href="javascript:void(0)" onclick="pcallhtml('/mobile/html/HBToJBChange.aspx','转换');" class="button button-fill button-success">转换</a>
    </p>--%>
    <form id="form1">
        <div class="buttons-tab">
            <input type="hidden" value="ZC" id="state" runat="server" />
            <a href="javascript:void(0)" onclick="$('#state').val('ZC'); dianji(this); " class="tab-link active button requery">转出</a>
            <a href="javascript:void(0)" onclick="$('#state').val('ZR'); dianji(this); " class="tab-link button requery">转入</a>
            <%--<a href="javascript:void(0)" onclick="$('#state').val('DH'); dianji(this); " class="tab-link button requery">转换</a>--%>
        </div>
    </form>
    <script type="text/x-jquery-tmpl" id="HBListTmpl">
        <tr>
            <td>${MID}</td>
            <td>${Money}</td>
            <td>${MoneyType}</td>
            <td>${ChangeDate}</td>
        </tr>
    </script>

    <table class=" table table-striped table-bordered ">
        <thead>
            <tr>
                <th>会员账号</th>
                <th>金额</th>
                <th>币种</th>
                <th>时间</th>
            </tr>
        </thead>
        <tbody id="data_container">
        </tbody>

    </table>
    <div id="page_container">
    </div>
</div>
<script>

    $(".buttons-tab a").click(function () {
        var n = $(".buttons-tab a").index(this);
        $(".buttons-tab a").eq(n).addClass("active");
    })
    function dianji(obj) {
        $(".tab-link").removeClass('active');
        obj.addClass('active');
    }

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
            TemplateContainer: '#HBListTmpl',
            DataContainer: '#data_container',
            DataUrl: '/mobile/html/HBList.aspx?Action=Other',
            QueryContainer: '#form1',
            Rendered: function () {
                window.MobileSelectAll();
            }
        });
    }, 50);
</script>
