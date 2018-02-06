<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TypeList.aspx.cs" Inherits="yny_004.Web.SysManage.Language.TypeList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript">
        tUrl = "SysManage/Language/Handler/LanguageTypeList.ashx";
        tState = "";
        SearchByCondition();

        function downLoadExcel() {
            ActionModelNoVer('/SysManage/Language/TypeList.aspx?Action=modify', null);
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="pay" onclick="UpDateByID('SysManage/Language/TypeEdit.aspx?','语种修改',680,300)">
                &nbsp;修&nbsp;改&nbsp;</div>
            <div class="pay" onclick="callhtml('SysManage/Language/TypeEdit.aspx','添加语种')">
                &nbsp;添&nbsp;加&nbsp;</div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" data-name="txtKey" id="txtKey" placeholder="请输入语种代码" runat="server" style="width: 150px;"
                    type="text" class="sinput" />
                <input id="mKey" placeholder="请输入语种名称" style="width: 150px;" type="text" class="sinput" />
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
                        语种代码
                    </th>
                    <th>
                        语种名称
                    </th>
                    <th>
                        语种图片
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
