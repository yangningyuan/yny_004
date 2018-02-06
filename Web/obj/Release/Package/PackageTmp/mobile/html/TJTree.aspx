<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TJTree.aspx.cs" Inherits="yny_004.Web.mobile.html.TJTree" %>

<link href="/plugin/ztree/css/zTreeStyle/zTreeStyle.css" rel="stylesheet" type="text/css" />
<script src="/plugin/ztree/js/jquery.ztree.core-3.5.js" type="text/javascript"></script>
<script src="/plugin/ztree/ztreeScript.js" type="text/javascript"></script>
<script type="text/javascript">
    var level = 1;
    var defalutinfo = "请输入会员账号,层级";
    LoadZtree($('#txtMid').val());
</script>

<div class="content content-padded pull-to-refresh-content" data-ptr-distance="55">
    <!-- 默认的下拉刷新层 -->
    <div class="pull-to-refresh-layer">
        <div class="preloader"></div>
        <div class="pull-to-refresh-arrow"></div>
    </div>
    <form id="form1" runat="server">
        <div id="mempay">
            <div class="control">
                <div class="search" id="DivSearch" runat="server" style="display: none;">

                    <input id="txtMid" runat="server" value="请输入会员账号" onfocus="if (value =='请输入会员账号'){value =''}"
                        onblur="if (value ==''){value='请输入会员账号'}" type="text" class="sinput" />
                </div>
            </div>
            <div class="tree_table">
             
                <%--<div class="zTreeDemoBackground left">--%>
                <ul id="treeDemo" class="ztree">
                </ul>
                <%--</div>--%>
            </div>
        </div>
    </form>
</div>

