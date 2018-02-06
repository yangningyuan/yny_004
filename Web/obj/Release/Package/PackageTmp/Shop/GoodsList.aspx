<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsList.aspx.cs" Inherits="yny_004.Web.Shop.GoodsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .appImg
        {
            display: block;
            max-width: 100px;
            max-height: 100px;
        }
    </style>
    <script type="text/javascript">
        tUrl = "/Shop/Handler/GoodsList.ashx";
        tState = "";
        SearchByCondition();
        
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="pay" onclick="UpDateByID('../Shop/Publish.aspx?','商品修改',900,470);">
                修改</div>
            <div class="pay" onclick="v5.show('../Shop/Publish.aspx','商品添加','url',900,470)">
                新增</div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <select id="txtKey" runat="server">
                </select>
                <input name="txtKey" id="mKey" placeholder="商品名称" type="text" class="sinput" />
            </div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" id="Result" class="tabcolor">
                <tr>
                    <th width="6%">
                        全选
                    </th>
                    <th>
                        序号
                    </th>
                    <th>
                        商品分类
                    </th>
                    <th>
                        商品名称
                    </th>
                    <th>
                        价格
                    </th>
                    <th>
                        库存数量
                    </th>
                    <th>
                        售出数量
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
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
