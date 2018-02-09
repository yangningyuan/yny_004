<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="yny_004.Web.Admin.Index" %>

<!DOCTYPE html>
<html lang="en">
	<head>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0" />
		<meta http-equiv="X-UA-Compatible" content="IE=edge" />
	<%--	<link rel="Shortcut Icon" href="Admin/images/fac.ico"/>--%>
		<title><%=WebModel.WebTitle %></title>
		<link href="/Admin/css/bootstrap.min.css" rel="stylesheet" />
		<link href="/Admin/assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
		<link href="/Admin/css/style.css" rel="stylesheet" />
		<link href="/Admin/css/style-responsive.css" rel="stylesheet" />
		<link href="/Admin/css/reset.css" rel="stylesheet" />
		<link href="/Admin/css/main.css" rel="stylesheet" />
		<link href="/Admin/css/add-ons.min.css" rel="stylesheet" />
		<%--<script src="/Admin/js/jquery-1.8.3.min.js"></script>--%><%--<script src="/Admin/js/jquery-1.11.1.min.js"></script>--%>
    <script src="/Admin/js/jquery-1.9.1.min.js"></script>
		<script src="/Admin/js/jquery-scroll.js"></script>
			<%--<script language="JavaScript" src="http://code.54kefu.net/kefu/js/b38/1031638.js" type="text/javascript" charset="utf-8"></script>--%>
	</head>

    
	<body>
	
		<div id="container">

			<div class="header white-bg">
				<div class="sidebar-toggle-box">
					<div data-original-title="菜单" data-placement="right" class="icon-reorder tooltips"></div>
				</div>
				<span class="welcome">欢迎您的到来，<%=TModel.MID %></span>
				<div class="top-nav ">
					<ul class="nav pull-right top-menu">
					<%--	<li class="dropdown">
							<a><span>分红：6666</span></a>
						</li>--%>
							<li>
							<%--<a href="https://tb.53kf.com/code/client/10150595/1 " target="_blank" style="    background: none;
    border: none;    padding: 0px;"><img src="Admin/images/contect_us.png" /></a>--%>
					    </li>
						<li class="dropdown">
							<a href="#"><img src="/Admin/images/man.png" />&nbsp;<%=TModel.MID %></a>
						</li>
						<li class="dropdown">
							<a href="/SysManage/Out.aspx"><img src="/Admin/images/exit.png" />&nbsp;退出</a>
						</li>
					
					</ul>
				</div>
			</div>
			<aside>
				<div id="sidebar" class="nav-collapse ">
					<a href="#" class="logo" ><img src="/Admin/images/logo.png" alt="" style="margin-bottom:10px;margin-top:20px;width: 75px;">
                        <p class="indexLogo">派派红包</p>
					</a>
					<ul class="sidebar-menu">
						<li class="sub-menu">
							<a class="" href="javascript:location.reload()"> <i class="icon-dashboard"></i> <span>首页</span> </a>
						</li>
                         <%
                        foreach (yny_004.Model.RolePowers item in GetPowers("0"))
                        {
                        %>
                        <li class="sub-menu">
                            <a href="javascript:void(0)">
                                <i class="icon-book"></i> <span><%=item.Content.CTitle %></span> <span class="arrow"></span>
                            </a>
                            <ul class="sub">
                                <%foreach (yny_004.Model.RolePowers item2 in GetPowers(item.CID))
                                    {
                                        if (item2.Content.IsOuterLink)
                                        {
                                %>
                                <li><a href="<%=item2.Content.CAddress %>" target="_blank"><%=item2.Content.CTitle%></a></li>
                                <%
                                    }
                                    else
                                    {
                                %>
                                <li><a href="javascript:callhtml('<%=item2.Content.CAddress %>','<%=item2.Content.CTitle %>');onclickMenu()"><%=item2.Content.CTitle%></a></li>
                                <%
                                        }
                                    } %>
                            </ul>
                        </li>
                        <%} %>



					</ul>
				</div>
			</aside>
			<div id="main-content">
				<div class="w1000 min_height row">
					<div class="col-md-12 gao">
						<div class="notice">
							<div class="news2" style=" margin-left:80px;">
								<marquee direction="top" scrollamount="6" behavior="scroll" onmouseover=this.stop() onmouseout=this.start() style="height: 28px;
    line-height: 24px;">
									<%
                                        if (notice != null)
                                        {
                                            %>
                                        <%=notice.NContent %>
                                    <%
                                        }
                                         %>
								</marquee>
							</div>
						</div>
					</div>
					<div class="col-md-12">
						<div class="row">
							<div class="row-fluid">
								<div class="col-md-3">
									<div class="info-box red-bg">
										<a><div onclick="javascript:callhtml('/ChangeMoney/HKList.aspx','汇款管理');onclickMenu()" class="icon01"></div>
										<div class="count">汇款管理</div></a>
									</div>
								</div>
								<div class="col-md-3 ">
									<div class="info-box green-bg">
										<a><div class="icon02" onclick="javascript:callhtml('/Member/FMIDList.aspx','子账号列表');onclickMenu()"></div>
										<div class="count">子账号列表</div></a>
									</div>
								</div>
							</div>
							<div class="col-md-3 ">
								<div class="info-box blue-bg">
									<a><div class="icon03" onclick="callhtml('/ChangeMoney/JJList.aspx','奖金明细');onclickMenu()"></div>
									<div class="count">奖金明细</div></a>
								</div>
							</div>
							<div class="col-md-3">
								<div class="info-box magenta-bg">
									<a><div class="icon04" onclick="callhtml('/Member/Add.aspx','注册会员');onclickMenu()"></div>
									<div class="count">快速注册</div></a>
								</div>
							</div>
						</div>
					</div>
					<div class="box1 col-md-8">
						<div class="account">
							<table style="width:100%" cellpadding="0" cellspacing="0" class="personinfo">
								<thead>
									<tr>
										<th colspan="2">我的账户</th>
									</tr>
								</thead>
								</tabel>
								<table style="width: 100%;" cellpadding="0" cellspacing="0" class="acount_body">
									<tbody>
										<tr>
											<td>
												姓名：<%=TModel.MName %>
											</td>
											<td>会员类型：<%=TModel.Role.RName %></td>
										</tr>
										<tr>
											<td>会员账号:<%=TModel.MID %></td>
											<td>推荐人：<%=TModel.MTJ %></td>
										</tr>
										<tr>
											<td><%=yny_004.BLL.Reward.List["MHB"].RewardName %>：<%=TModel.MConfig.MHB %></td>
											<td>
												<%=yny_004.BLL.Reward.List["MJB"].RewardName %>：<%=TModel.MConfig.MJB %>
											</td>
										</tr>
										<tr>
											<td>奖金累计：<%=TModel.MConfig.TotalMoney %></td>
											<td>
												
                                                有效投资额：<%=TModel.MConfig.SHMoney %>
											</td>
										</tr>
										<%--<tr>
											<td>团队有效投资额：<%=TModel.MConfig.YJMoney %></td>
											<td>
												
											</td>
										</tr>--%>
									</tbody>
								</table>
								<div class="tg">
									推广链接：
									<input type="text"  id="txtTuiGuang" runat="server" readonly="readonly" style="width:70%;" class="form-control">
									<input type="button" data-clipboard-target="txtTuiGuang" id="fenxian"  value="复制" class="btn btn-info fz">
									</td>
								</div>
						</div>
					</div>
					<div class="box2 col-md-4">
						<div class="news">
							<table style="width:100%" cellpadding="0" cellspacing="0" class="personinfo">
								<thead>
									<tr>
										<th colspan="2" style="width:100%;   border-bottom: dotted 2px #4ab9ad">最新资讯</th>
									</tr>
								</thead>
								<tbody>
									<tr>
										<td>
											<ul class="recent-posts">
                                                  <asp:Repeater ID="repNoticeList" runat="server">
                                                        <ItemTemplate>
                                                            <li>
													            <div class="article-post">
														            <p>
															            <a href="javascript:callhtml('Message/NoticeView.aspx?id=<%#Eval(" ID")%>','<%#Eval("NTitle")%>')">>> <%#Eval("NTitle")%></a><%#Eval("NCreateTime","{0:yyyy-MM-dd}")%>
														            </p>
													            </div>
												            </li>
                                                        
                                                        </ItemTemplate>
                                                    </asp:Repeater>
									
											</ul>
										</td>
									</tr>
								</tbody>
							</table>
						</div>
					</div>

				</div>
			</div>
			</div>
             <%--<script type="text/javascript" src="Admin/js/main.js"></script>--%>
    <script type="text/javascript" src="Admin/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="Admin/js/jquery.scrollTo.min.js"></script>
    <script type="text/javascript" src="Admin/js/jquery.nicescroll.js"></script>
    <script type="text/javascript" src="Admin/js/common-scripts.js"></script>
    <link rel="stylesheet" type="text/css" href="Admin/pop/css/pop.css" />
    <link rel="stylesheet" type="text/css" href="Admin/pop/css/V5-UI.css" />
    <link rel="stylesheet" type="text/css" href="Admin/pop/css/next_page_search.css" />
    <link rel="stylesheet" type="text/css" href="plugin/layer/skin/layer.css" />
    <link rel="stylesheet" type="text/css" href="plugin/kindeditor/themes/default/default.css" />

        <link href="/plugin/layui/css/layui.css" rel="stylesheet" />
        <script src="/plugin/layui/layui.js"></script>

    <script type="text/javascript" src="plugin/layer/layer.js"></script>
    <script type="text/javascript" src="Admin/pop/js/MyValide.js"></script>
    <script type="text/javascript" src="Admin/pop/js/TableToExcel.js"></script>
    <script type="text/javascript" src="Admin/pop/js/linkage.js"></script>
    <%--<script type="text/javascript" src="Shop/js/shopJs.js"></script>--%>
    <script type="text/javascript" src="Module/Investment/js/invest.js"></script>
    <script type="text/javascript" src="Admin/pop/js/javascript_main.js"></script>
    <script type="text/javascript" src="Admin/pop/js/ajax.js"></script>
    <script type="text/javascript" src="Admin/pop/js/javascript_pop.js"></script>
    <script type="text/javascript" src="Admin/pop/js/V5-UI.js"></script>
    <script type="text/javascript" src="Admin/pop/js/jquery.pagination.js" charset="gbk"></script>
    <script type="text/javascript" src="plugin/date/WdatePicker.js"></script>
    <script type="text/javascript" src="plugin/ZeroClipboard/ZeroClipboard.js"></script>
    <script type="text/javascript" src="plugin/kindeditor/kindeditor-min.js"></script>
            <script src="/Admin/js/jquery.qrcode.min.js"></script>
    <!-- 数据库定时备份 -->
   <%-- <script src="admin/js/ajaxForm.js" type="text/javascript"></script>
    <script src="admin/js/paginationHelper.js" type="text/javascript"></script>
    <script src="admin/js/jquery.tmpl.js" type="text/javascript"></script>
    <script src="admin/js/pagination/jquery.twbsPagination.js" type="text/javascript"></script>--%>
    <!-- 数据库定时备份 -->
    <script type="text/javascript">
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

            var clip = new ZeroClipboard(document.getElementById("fenxian"), {
                moviePath: "plugin/ZeroClipboard/ZeroClipboard.swf"
            });
            // 复制内容到剪贴板成功后的操作 
            clip.on('complete', function (client, args) {
                layer.alert('复制成功！', {
                    skin: 'layer-ext-moon',
                    btn: '确定',
                    yes: function (index, layero) {
                        layer.close(index);
                    }
                });
            });
        });

        KindEditor.ready(function (K) {
            window.KKKK = K;
        });
    </script>
    <script type="text/javascript">
        function onclickMenu() {
            var width = $(window).width();
            if (width <= 768) {
                var className = document.getElementById("container").className;
                if (className == "") {
                	$(".tooltips").click();
                }
            }
        }
    </script>


		<%--	<script src="/Admin/js/bootstrap.min.js"></script>
			<script src="/Admin/js/jquery.scrollTo.min.js"></script>
			<script src="/Admin/js/jquery.nicescroll.js"></script>
			<script src="/Admin/js/common-scripts.js"></script>
			<script language="javascript">
				jQuery(".imgsilder_box").slide({
					mainCell: ".imgsilder_wrap ul",
					effect: "left",
					autoPlay: true,
					switchLoad: "_src",
					vis: 5,
					autoPage: true
				});
			</script>--%>
	</body>
    <iframe id='frameFile' name='frameFile' style='display: none;'></iframe>
</html>
