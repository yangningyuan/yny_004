<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="yny_004.Web.Language.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "SysManage/Language/Handler/LanguageList.ashx";
        tState = "";
        SearchByCondition();

        function downLoadExcel() {
            ActionModelNoVer('/SysManage/Language/List.aspx?Action=modify', null);
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="pay" onclick="UpDateByID('SysManage/Language/Edit.aspx?','修改语言设置',680,300)">
                &nbsp;修&nbsp;改&nbsp;</div>
            <div class="pay" onclick="callhtml('SysManage/Language/Edit.aspx','添加语言设置')">
                &nbsp;添&nbsp;加&nbsp;</div>
            <%--<a href="Language/DownLoad.aspx" target="_blank" class="pay btn btn-success">下载模板</a>--%>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" data-name="txtKey" id="txtKey" placeholder="请输入中文名称" runat="server" style="width: 150px;"
                    type="text" class="sinput" />
                <input id="mKey" placeholder="请输入英文名称" style="width: 150px;" type="text" class="sinput" />
            </div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" class="tabcolor" id="Result">
                <tr>
                    <th width="50px">
                        全选
                    </th>
                    <th>
                        序号
                    </th>
                    <th>
                        中文名称
                    </th>
                    <th>
                        翻译名称
                    </th>
                    <th>
                        语种
                    </th>
                    <th>
                        是否启用
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn" runat="server" id="DivDelete">
                    <a href="javascript:void(0);" title="" onclick="RunAjaxByList('','DeleteLanguage',',');">
                        删除</a>
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
