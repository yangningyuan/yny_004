<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskList.aspx.cs" Inherits="yny_004.Web.mobile.html.TaskList" %>

<div class="content content-padded pull-to-refresh-content" data-ptr-distance="55">
    <!-- 默认的下拉刷新层 -->
    <div class="pull-to-refresh-layer">
        <div class="preloader"></div>
        <div class="pull-to-refresh-arrow"></div>
    </div>
    <p>
        <a href="javascript:void(0)" onclick="pcallhtml('/mobile/html/TaskAdd.aspx','发送邮件');" class="button button-fill button-success">发送邮件</a>
    </p>
    <form id="form1">
        <div class="buttons-tab">
            <input type="hidden" value="" id="state" runat="server" />
            <a href="javascript:void(0)" onclick="$('#state').val('FJ'); dianji(this); " class="tab-link active button requery">发件箱</a>
            <a href="javascript:void(0)" onclick="$('#state').val('SJ'); dianji(this); " class="tab-link button requery">收件箱</a>
        </div>
    </form>
    <div class="content-block">
        <div class="tabs">
            <div id="tab1" class="tab active">
                <script type="text/x-jquery-tmpl" id="TaskListTmpl">
                    <tr>
                        <td>${content}</td>
                        <%--<td>${type}</td>--%>
                        <td>${date}</td>
                    </tr>
                </script>
                <table class=" table table-striped table-bordered ">
                    <thead>
                        <tr>
                            <th>邮件</th>
                            <%--<th>邮件类型</th>--%>
                            <th>日期</th>
                        </tr>
                    </thead>
                    <tbody id="data_container">
                    </tbody>
                </table>
                <div id="page_container">
                </div>
            </div>
        </div>
    </div>

</div>
<script>
	$(".buttons-tab a").click(function () {
		var n = $(".buttons-tab a").index(this);
		$(".buttons-tab a").eq(n).addClass("active");
	})
    function dianji(obj)
    {
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
            TemplateContainer: '#TaskListTmpl',
            DataContainer: '#data_container',
            DataUrl: '/mobile/html/TaskList.aspx?Action=Other',
            QueryContainer: '#form1',
            Rendered: function () {
                window.MobileSelectAll();
            }
        });
    }, 50);
</script>
