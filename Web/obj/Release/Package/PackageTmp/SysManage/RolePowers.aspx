<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RolePowers.aspx.cs" Inherits="yny_004.Web.SysManage.RolePowers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "SysManage/Handler/RolePowers.ashx";
        tState = "true";
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0)" onclick="SearchByState('true',this);" class="btn btn-danger">有验证</a>
                <a href="javascript:void(0)" onclick="SearchByState('false',this);" class="btn btn-success">无验证</a>
            </div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
            </div>
            <div class="cheeckbox">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <select id="RoleCode" name="txtKey" data-name="txtKey" onclick="SearchByCondition()">
                                <%= RoleListStr%>
                            </select>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" id="Result" class="tabcolor">
                <tr>
                    <th width="50px">
                        全选
                    </th>
                    <th>
                        序号
                    </th>
                    <th>
                        权限编号
                    </th>
                    <th>
                        菜单名称
                    </th>
                    <th>
                        密码验证
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <a href="javascript:void(0);" title="" onclick="RunAjaxByList('false','SetVerify&mType='+$('#RoleCode').val(),',');">
                        设置验证</a><a href="javascript:void(0);" title="" onclick="RunAjaxByList('true','SetVerify&mType='+$('#RoleCode').val(),',');">
                            取消验证</a>
                </div>
                <div class="pagebar">
                    <div id="Pagination">
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
