<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="yny_004.Web.Shop.Category" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "/Shop/Handler/CategoryList.ashx";
        tState = "";
        SearchByCondition();
        
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="pay" onclick="UpDateByID('../Shop/CategoryEdit.aspx?','修改类型',900,470);">
                修改</div>
            <div class="pay" onclick="v5.show('../Shop/CategoryEdit.aspx','添加类型','url',900,470)">
                新增</div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" id="txtKey" placeholder="分类名称" type="text" class="sinput" />
            </div>
        </div>
         
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" id="Result" class="tabcolor">
                <tr>
                    <th width="6%">
                        全选
                    </th>
                 
                    <th>
                        分类代码
                    </th>
                    <th>
                        分类名称
                    </th>
                  
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <%--<a href="javascript:void(0);" title="删除" onclick="RunAjaxByList('','DeleteCategoryInfo',',');">
                        删除</a>--%>
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
