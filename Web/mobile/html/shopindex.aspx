<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shopindex.aspx.cs" Inherits="yny_004.Web.mobile.html.shopindex" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title><%=WebModel.WebTitle %></title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <%--   <link rel="shortcut icon"  href="../../Admin/images/fac.ico">--%>
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <link rel="stylesheet" type="text/css" href="/mobile/font_icons/iconfont.css">
    <link rel="stylesheet" href="/mobile/conn/iconfont/iconfont.css">
    <link rel="stylesheet" href="/mobile/plugin/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="/mobile/plugin/SUI/css/sm.css">
    <link rel="stylesheet" href="/mobile/css/main.css">
    
    <link href="/plugin/layui/css/layui.css" rel="stylesheet" />

    <script src="/mobile/js/jquery-1.11.3.js"></script>
    <script src="/mobile/js/stack.js" type="text/javascript"></script>
    <script src="/mobile/conn/laydate/laydate.js"></script>
    <style>
       
        .row {
            margin-left:0;
        }
        .row1 img {
            border-radius: 0.5rem;
        }
       
    </style>
</head>

<body>
    <div class="page-group">
        <div class="page page-current" id="index">
            <header class="bar bar-nav">
                <a class="icon icon-left pull-left back" href="javascript:StackPop()"></a>
                <%--<a class="icon icon-home pull-right" href="javascript:window.location.reload();"></a>--%>
                <%--<i class="iconfont headerLeft">&#xe699;</i>--%>
                <i class="iconfont headerRight"  onclick="pcallhtmlNoV('/mobile/html/geren.aspx','个人中心');">&#xe680;</i>
                <h1 class="title" >贝贝美商城</h1>
            </header>
            <nav class="bar bar-tab">
                <a class="tab-item active" href="javascript:void(0)" onclick="javascript:window.location.reload();">
                    <i class="iconfont">&#xe607;</i>
                    <span class="tab-label">商城</span>
                </a>
                <a class="tab-item " href="javascript:pcallhtmlNoV('/mobile/html/index2.aspx','首页');">
                    <i class="iconfont">&#xe699;</i>
                    <span class="tab-label">首页</span>
                </a>
                <a class="tab-item" href="javascript:void(0)" onclick="javascript:pcallhtmlNoV('/mobile/html/caiwu2.aspx','财务');">
                    <i class="iconfont">&#xe7d1;</i>
                    <span class="tab-label">财务</span>
                </a>
               <%-- <a class="tab-item user-img-btn external" href="javascript:void(0)" onclick="pcallhtml('/mobile/html/Code.aspx','二维码注册');">
                    <img src="/mobile/img/userbtn.png" />
                </a>--%>
                 
                <a class="tab-item" href="javascript:void(0)" onclick="javascript:pcallhtmlNoV('/mobile/html/TD.aspx','团队管理');">
                    <i class="iconfont">&#xe61c;</i>
                    <span class="tab-label">团队</span>
                </a>
                <a class="tab-item" href="javascript:void(0)" onclick="pcallhtmlNoV('/mobile/html/geren.aspx','个人中心');">
                    <i class="iconfont">&#xe62d;</i>
                    <span class="tab-label">我的</span>
                </a>
            </nav>
            <div class="content native-scroll" id="pageHome">
                <div class="content">
    <div class="banner">
        <div class="banner_Carousel">
            <div class="carousel slide" data-ride="carousel" id="carousel3">
                <div class="carousel-inner">
                    <div class="Z">
                        
                        <%
                            foreach (yny_004.Model.GoodCategory item in listcate)
                            {
                        %>
                        <div class="zh_head">
                            <i class="iconfont">&#xe620;</i><span><%=item.Name %></span>
                        </div>
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
        </div>
           <div class="i_signIn " style="display: none; z-index: 10500;">
               <div class="i_popup">
                   <div class="i_signIn_cont">
                       <input type="button" class="i_signIn_btn">
                        <div class="i_signIn_pay hide">
                            <p class="i_signIn_top30">
                                <b id="chbmoney"></b></p> 
                            <p class="i_signIn_top40">已存入余额.</p>
                        </div> 
                        <p class="i_signIn_top50">每日签到抢红包</p>
                        <p class="i_signIn_top70 hide">签到奖</p>
                   </div>
               </div>
           </div>
            <div class="i_opticy" style="display: none;"></div>
    </div>
        <input type="hidden" id="isnotice2" runat="server" />
    <script src="/mobile/plugin/SUI/js/zepto.js"></script>
    <script type='text/javascript' src='/mobile/plugin/SUI/js/sm.js' charset='utf-8'></script>
    <script type='text/javascript' src='/mobile/plugin/SUI/js/sm-city-picker.js' charset='utf-8'></script>
    <script type='text/javascript' src='/mobile/js/main.js' charset='utf-8'></script>



    <script src="/mobile/js/linkage.js"></script>
    <script src="/mobile/js/mobile_services.js" type="text/javascript"></script>
    <script src="/Admin/pop/js/MyValide.js" type="text/javascript"></script>
    <script src="/mobile/layer/layer.js" type="text/javascript"></script>
    <script src="/mobile/js/mobilebone.js" type="text/javascript"></script>
    <script src="/mobile/js/main.js"></script>
    <script src="/mobile/js/javascript_main.js" type="text/javascript"></script>
    <script type="text/javascript" src="/mobile/js/ajax.js"></script>
    <script src="/mobile/js/javascript_pop.js" type="text/javascript"></script>
    <script src="/mobile/js/jquery.tmpl.js" type="text/javascript"></script>
    <script src="/mobile/js/mob_paging.js" type="text/javascript"></script>
    <script src="/mobile/js/MobileSelectAll.js" type="text/javascript"></script>
    <script src="/mobile/js/jquery.linq.min.js" type="text/javascript"></script>
   <%-- <script type="text/javascript" src="/plugin/ztree/js/jquery.ztree.core-3.5.js"></script>
    <script type="text/javascript" src="/plugin/ztree/ztreeScript.js"></script>--%>
    <script type="text/javascript" src="/plugin/kindeditor/kindeditor-min.js"></script>
    <script src="/Admin/js/jquery.qrcode.min.js"></script>

    <script type="text/javascript">
        $('.i_opticy').on('click', function () {
            $(this).css('display', 'none');
            $('.i_signIn').css('display', 'none')
            $('.i_signIn_pay').css('display', 'none');
            $('.i_signIn_top50').css('display', 'block');
            $('.i_signIn_top70').css('display', 'none');
            $('.i_signIn .i_popup').removeClass('envelope');
        })
        
        $('.i_signIn_btn').on('click', function () {

            $.ajax({
                type: 'post',
                url: 'Member/Modify.aspx?Action=add',
                data: "",
                success: function (info) {
                     document.getElementById("chbmoney").innerHTML=info;
                    $('.i_signIn_pay').css('display', 'block');
                    $('.i_signIn_top50').css('display', 'none');
                    $('.i_signIn_top70').css('display', 'block');
                    $('.i_signIn .i_popup').addClass('envelope');
                }
            });

            
        })
        function showPacket() {

        }
        $(function () {
            var AllLoad;
            $.ajaxSetup({
                cache: false,
                success: function (data) { },
                error: function (xhr, status, e) { },
                complete: function (xhr, status) { layer.close(AllLoad); },
                beforeSend: function (xhr) {
                    AllLoad = layer.load(2, { shade: [0] });
                }
            });
        });

        KindEditor.ready(function (K) {
            window.KKKK = K;
        });
    </script>

    <script>
        KindEditor.ready(function (K) {
            window.KKKK = K;
        });
    </script>
    <script>
        //二维码
        function toUtf8(str) {
            var out, i, len, c;
            out = "";
            len = str.length;
            for (i = 0; i < len; i++) {
                c = str.charCodeAt(i);
                if ((c >= 0x0001) && (c <= 0x007F)) {
                    out += str.charAt(i);
                } else if (c > 0x07FF) {
                    out += String.fromCharCode(0xE0 | ((c >> 12) & 0x0F));
                    out += String.fromCharCode(0x80 | ((c >> 6) & 0x3F));
                    out += String.fromCharCode(0x80 | ((c >> 0) & 0x3F));
                } else {
                    out += String.fromCharCode(0xC0 | ((c >> 6) & 0x1F));
                    out += String.fromCharCode(0x80 | ((c >> 0) & 0x3F));
                }
            }
            return out;
        }
    </script>

    <script src="/plugin/layui/layui.js"></script>
         <script>
            setTimeout(function(){
                var isnotice2= $("#isnotice2").val().trim();
          
                if(isnotice2=="1")
                {
                layer.confirm('是否进入完善资料页面？', {
                    btn : [ '是', '否' ]//按钮
                }, function(index) {
                    layer.close(index);
                    pcallhtmlNoV('/mobile/html/View.aspx', '完善资料');
                }); 
            }
        },500);
     
        </script>
</body>

</html>
