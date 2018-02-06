<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyGood.aspx.cs" Inherits="yny_004.Web.Shop.BuyGood" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
    .appImg{ display:block; max-width:100px; max-height:100px}
    </style>
    <script type="text/javascript">
        tUrl = "/Shop/Handler/GoodsList.ashx";
        tState = "1";
        SearchByCondition();
        function lookMoreInfo(gid) {
            callhtml('../Shop/GoodsDetail.aspx?id='+gid, '商品详细');
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                  <select id="GParentCode" runat="server" name="GParentCode">
                   
                </select>
                <input name="txtKey" id="mKey" placeholder="商品名称"  type="text" class="sinput" />
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
                        剩余数量
                    </th>
                    <th>
                      售出数量
                    </th>
                       <th>
                      查看详细
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                   <a href="javascript:void(0);" title="加入购物车" onclick="RunAjaxByList('','BatchAddShopCar',',');">
                        加入购物车</a> 
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