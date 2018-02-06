<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LuckList.aspx.cs" Inherits="yny_004.Web.mobile.html.LuckList" %>
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
    <p>
        <a class="button button-fill button-success qianghongbao">拆红包</a>
    </p>

    <script type="text/x-jquery-tmpl" id="InvestListTmpl">
        <tr>
            <td>${MID}</td>
            <td>${Money}</td>
            <td>${CreateDate}</td>
        </tr>
    </script>

    <table class=" table table-striped table-bordered ">
        <thead>
            <tr>
                <th>会员</th>
                <th>拆包金额</th>
                
                <th>时间</th>
                
            </tr>
        </thead>
        <tbody id="data_container">
        </tbody>
    </table>
    <div id="page_container">
    </div>
</div>
  <div class="i_signInqhb" style="display: none; z-index: 10500;">
               <div class="i_popup2">
                   <div class="i_signIn_cont2">
                       <input type="button" class="i_signIn_btnqhb">
                        <div class="i_signIn_pay2 hide">
                            <p class="i_signIn_top30">
                                <b id="chbmoney"></b></p> 
                            <p class="i_signIn_top40">已存入钱包</p>
                        </div> 
                        <p class="i_signIn_top502"><%=yny_004.BLL.Configuration.Model.E_TJFloat %>元拆红包</p>
                        <p class="i_signIn_top702 hide">恭喜发财</p>
                   </div>
               </div>
           </div>
            <div class="i_opticy2" style="display: none;"></div>
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
            DataUrl: '/mobile/html/LuckList.aspx?Action=Other',
            QueryContainer: '#form1',
            Rendered: function () {
                window.MobileSelectAll();
            }
        });
    }, 50);
    $('.i_opticy2').on('click', function () {
        $(this).css('display', 'none');
        $('.i_signInqhb').css('display', 'none')
        $('.i_signIn_pay2').css('display', 'none');
        $('.i_signIn_top50').css('display', 'block');
        $('.i_signIn_top70').css('display', 'none');
        $('.i_signInqhb .i_popup2').removeClass('envelope');
    })
    $('.qianghongbao').on('click', function () {
        $('.i_opticy2').css('display', 'block');
        $('.i_signInqhb').css('display', 'block')
    })
    $('.i_signIn_btnqhb').on('click', function () {

        $.ajax({
            type: 'post',
            url: 'Member/Modify.aspx?Action=other',
            data: "",
            success: function (info) {
                document.getElementById("chbmoney").innerHTML = info;
                $('.i_signIn_pay2').css('display', 'block');
                $('.i_signIn_top502').css('display', 'none');
                $('.i_signIn_top702').css('display', 'block');
                $('.i_signInqhb .i_popup2').addClass('envelope');
            }
        });


    })
   
</script>
