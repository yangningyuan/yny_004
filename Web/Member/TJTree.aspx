<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TJTree.aspx.cs" Inherits="yny_004.Web.Member.TJTree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="plugin/ztree/css/zTreeStyle/zTreeStyle.css" rel="stylesheet" type="text/css" />
    <script src="plugin/ztree/js/jquery.ztree.core-3.5.js" type="text/javascript"></script>
    <script src="plugin/ztree/ztreeScript.js" type="text/javascript"></script>
    <script type="text/javascript">
        var level = 1;
        var defalutinfo = "请输入会员账号,层级";
        LoadZtree($('#txtMid').val());
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="mempay">
        <div class="control">
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="返回顶层" class="ssubmit btn btn-danger" onclick="callhtml('Member/TJTree.aspx','推荐图谱');" />
                <input type="button" value="查询" class="ssubmit btn btn-danger" onclick="LoadZtree($('#txtMid').val())" />
                <input id="txtMid" runat="server" value="请输入会员账号" onfocus="if (value =='请输入会员账号'){value =''}"
                    onblur="if (value ==''){value='请输入会员账号'}" type="text" class="sinput" />
            </div>
        </div>
        <div class="tree_table">
            <table cellpadding="0" cellspacing="0" style="width: auto; display: none;">
                <tr>
                    <%=MAgencyTypeColor%>
                </tr>
            </table>
            <%--<div class="zTreeDemoBackground left">--%>
            <ul id="treeDemo" class="ztree">
            </ul>
            <%--</div>--%>
        </div>
    </div>
    </form>
</body>
</html>
