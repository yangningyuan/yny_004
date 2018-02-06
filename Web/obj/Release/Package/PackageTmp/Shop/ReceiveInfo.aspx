<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiveInfo.aspx.cs" Inherits="yny_004.Web.Shop.ReceiveInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "/Shop/Handler/ReceiveList.ashx";
        tState = "";
        SearchByCondition();
        
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="pay" onclick="UpDateByID('../Shop/AddReceive.aspx?','修改收货人',900,470);">
                修改</div>
            <div class="pay" onclick="v5.show('../Shop/AddReceive.aspx','添加收货人','url',900,470)">
                新增</div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" id="mKey" placeholder="收货人" type="text" class="sinput" />
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
                        收货人
                    </th>
                    <th>
                        电话
                    </th>
                    <th>
                        地址
                    </th>
                    <th>
                        默认收货人
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <a href="javascript:void(0);" title="删除" onclick="RunAjaxByList('','DeleteReceiveInfo',',');">
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
