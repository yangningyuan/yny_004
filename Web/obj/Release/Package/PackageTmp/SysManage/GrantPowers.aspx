<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GrantPowers.aspx.cs" Inherits="yny_004.Web.SysManage.GrantPowers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "SysManage/Handler/GrantPowers.ashx";
        tState = "";
        SearchByCondition();

    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0)" onclick="SearchByState('',this);" class="btn btn-danger">全 部</a>
                <a href="javascript:void(0)" onclick="SearchByState('true',this);" class="btn btn-success">有权限</a>
                <a href="javascript:void(0)" onclick="SearchByState('false',this);" class="btn btn-success">无权限</a>
            </div>
            <div class="search" id="DivSearch" runat="server">
                <input id="startDate" name="txtKey" data-name="txtKey" placeholder="请输入菜单名称" value="请输入菜单名称" style="width: 150px;" type="text" class="sinput" />
                <input type="button" value="查询" class="btn btn-danger" onclick="SearchByCondition();" />
                <input type="button" value="添加菜单" class="btn btn-success" onclick="callhtml('SysManage/MenuEdit.aspx', '菜单编辑');" />
            </div>
            <div class="cheeckbox">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <select id="txtKey" name="txtKey" data-name="txtKey" runat="server" onclick="SearchByCondition();">
                            </select>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" id="Result" class="tabcolor">
                <tr>
                    <th width="50px">全选
                    </th>
                    <th>序号
                    </th>
                    <th>权限编号
                    </th>
                    <th>菜单名称
                    </th>
                    <th>是否授权
                    </th>
                    <%--<th>是否快捷菜单
                    </th>
                    <th>菜单图标
                    </th>--%>
                    <th>修改
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <a href="javascript:void(0);" title="" onclick="RunAjaxByList('','GrantVerify&mType='+$('#txtKey').val(),',');">重新授权</a>
                </div>
                <%--<div class="pagebar">
                    <div id="Pagination">
                    </div>
                </div>--%>
            </div>
        </div>
    </div>
</body>
</html>
