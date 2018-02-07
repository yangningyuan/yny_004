<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LuckTJList.aspx.cs" Inherits="yny_004.Web.mobile.html.LuckTJList" %>

<div class="content content-padded pull-to-refresh-content" data-ptr-distance="55">
    <!-- 默认的下拉刷新层 -->
    <div class="pull-to-refresh-layer">
        <div class="preloader"></div>
        <div class="pull-to-refresh-arrow"></div>
    </div>
    <div class="row searchbar">
        <form id="form1">
            <input type="hidden" name="txtKey" id="countdate" />
            <input name="txtKey" id="mKey" type="hidden" class="sinput" />

            <div class="clear"></div>
            <div class="search-time">
                <input type="text" placeholder="开始时间" id="begin_time" runat="server" class="laydate-icon" />
                <input type="text" placeholder="结束时间" id="end_time" runat="server" class="laydate-icon" />
                <button type="button" class="requery searchh">查询</button>
            </div>

        </form>
    </div>

    <script type="text/x-jquery-tmpl" id="JJListTmpl">
        <tr>
            <td>${Money}</td>
            <td>${ChangeType}</td>
            <td>${SHMID}</td>
            <td>${ChangeDate}</td>
            <td>${html caozuo}</td>
        </tr>
    </script>
    <table class=" table table-striped table-bordered ">
        <thead>
            <tr>
                <th>奖金合计</th>
                <th>奖金类型</th>
                <th>来源</th>
                <th>日期</th>
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
            TemplateContainer: '#JJListTmpl',
            DataContainer: '#data_container',
            DataUrl: '/mobile/html/LuckTJList.aspx?Action=Other',
            QueryContainer: '#form1',
            Rendered: function () {
                window.MobileSelectAll();
            }
        });
    }, 50);
</script>
<script>
    var start = {
        elem: '#begin_time',
        format: 'YYYY-MM-DD',
        min: '2009-06-16', //设定最小日期为当前日期
        max: '2099-06-16', //最大日期
        istoday: false,
        choose: function (datas) {
            end.min = datas; //开始日选好后，重置结束日的最小日期
            end.start = datas //将结束日的初始值设定为开始日
        }
    };
    var end = {
        elem: '#end_time',
        format: 'YYYY-MM-DD',
        min: start.toString(),
        max: '2099-06-16',
        istoday: false,
        choose: function (datas) {
            start.max = datas; //结束日选好后，重置开始日的最大日期
        }
    };
    //    laydate.skin("molv");
    laydate(start);
    laydate(end);
</script>