<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpMAgencyType.aspx.cs" Inherits="yny_004.Web.mobile.html.UpMAgencyType" %>

    <form id="form1">
	<div class="content">
		<%--<div class="f_back">
<a class="button button-link button-nav pull-left" href="javascript:StackPop()">
      <span class="icon icon-left"></span>
      返回
    </a>
	</div>--%>
					<div class="zh_head">
						 <span class="icon icon-app"></span><span>激活账户</span>
					</div>
					<div class="list-block">
						<ul>
							<!-- Text inputs -->
						    <input id="hdmid" type="hidden" runat="server" />
							<li>
								<div class="item-content">
									<div class="item-inner">
										<div class="item-title label">会员账号</div>
										<div class="item-input">
											<%=sjmodel.MID %>
										</div>
									</div>
								</div>
							</li>
                            <li>
								<div class="item-content">
									<div class="item-inner">
										<div class="item-title label">会员姓名</div>
										<div class="item-input">
											<%=sjmodel.MName %>
										</div>
									</div>
								</div>
							</li>
                            <li>
								<div class="item-content">
									<div class="item-inner">
										<div class="item-title label">当前级别</div>
										<div class="item-input">
											<font style="font-weight: bold; color: red;"><%=sjmodel.MAgencyType.MAgencyName %></font>
										</div>
									</div>
								</div>
							</li>
                            <li>
								<div class="item-content">
									<div class="item-inner">
										<div class="item-title label"> <%=yny_004.BLL.Reward.List["MHB"].RewardName %></div>
										<div class="item-input">
											<%=TModel.MConfig.MHB %>
										</div>
									</div>
								</div>
							</li>
                              <li>
								<div class="item-content">
									<div class="item-inner">
										<div class="item-title label"></div>
										<div class="item-input">
											<%=MyMAgencyTypeRdo%>
										</div>
									</div>
								</div>
							</li>
						</ul>
					</div>
					<div class="content-block">
						<a href="javascript:void(0)"  class="button button-fill button-big button-success" id="btn" runat="server"  onclick="checkChange();">提交</a>

					</div>
				</div>
            </form>

<style>
    input{
        width:5%;
    }
</style>
<%--<div id="pageHome" class="page out">--%>
    <%--<form id="form1">
        <div class="content">--%>
            <!--         <div class="zh_head">
            <i class="iconfont">&#xe63d;</i><span>自助激活</span>
        </div> -->
         <%--   <input id="hdmid" type="hidden" runat="server" />
            <div class="margin">
                <span>会员账号：</span>
                <b class="result"><%=sjmodel.MID %></b>
            </div>
            <div class="margin">
                <span>会员姓名：</span>
                <b class="result"><%=sjmodel.MName %></b>
            </div>
            <div class="margin">
                <span>当前级别：</span>
                <b class="result"><font style="font-weight: bold; color: red;"><%=sjmodel.MAgencyType.MAgencyName %></font></b>
            </div>
            <div class="margin">
                <span>我的报单币：</span>
                <b class="result"><%=TModel.MConfig.MCW %></b>
            </div>
            <div class="margin">
                <span>升级：</span>
                <b class="result"><%=MyMAgencyTypeRdo%></b>
            </div>
            <a href="javascript:void(0)" title="" type="btn" runat="server" class="btn_qd" onclick="checkChange();">确定</a>
        </div>
    </form>--%>
<%--</div>--%>
<script>
    function checkChange() {
        ActionModel("/Member/UpMAgencyType.aspx?Action=modify", $('#form1').serialize(), "/mobile/html/geren.aspx",
        function () {
            $("#btnOK").removeAttr("onclick");
            $("#btnOK").val("请等待...");
        }, '升级管理');
    }
</script>
