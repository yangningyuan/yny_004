<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cars.aspx.cs" Inherits="yny_004.Web.Shop.Cars" %>

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
        .nums
        {
            width: 35px;
        }
        .numVal
        {
            width: 42px;
            text-align: center;
        }
        .goodNum
        {
            margin-right: 5px;
            border: 1px solid #999;
            cursor: pointer;
            width: 13px;
            height: 13px;
        }
    </style>
    <script type="text/javascript">
        tUrl = "/Shop/Handler/CarList.ashx";
        tState = "";
        SearchByCondition();

        function updateGoodCarCount(carId, count) {
            var result = GetAjaxString('UpdateShopCar', carId + "&count=" + count);
        }

        function numDesc(obj) {
            var oldNum = $(obj).next().val();
            if (parseInt(oldNum) != 1) {
                var newNum = parseInt(oldNum) - 1;
                $(obj).next().val(newNum);
                var price = parseFloat($.trim($(obj).parent().parent().find(".spSprice").text()));
                var totalMoney = newNum * price;
                $(obj).parent().parent().find(".spTotal").text(totalMoney.toFixed(2));
                var cid = $.trim($(obj).parent().parent().find(".hidCId").val());
                updateGoodCarCount(cid, newNum);
            }
        }
        function numAsc(obj) {
            var oldNum = $(obj).prev().val();
            var newNum = parseInt(oldNum) + 1;
            $(obj).prev().val(newNum);
            var price = parseFloat($.trim($(obj).parent().parent().find(".spSprice").text()));
            var totalMoney = newNum * price;
            $(obj).parent().parent().find(".spTotal").text(totalMoney.toFixed(2));
            var cid = $.trim($(obj).parent().parent().find(".hidCId").val());
            updateGoodCarCount(cid, newNum);
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div class="ui_table">
            <form id="form1">
            <div id="receiveDiv" style="display: none; width:500px;">
                <table class="table">
                    <asp:Repeater ID="repReceiveList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <input type="radio" name="rdreecive" <%#Convert.ToBoolean(Eval("IsMain"))?"checked='checked'":""%>
                                        value="<%#Eval("Id")%>" />
                                </td>
                                <td>
                                    <%#Eval("Receiver")%>
                                </td>
                                <td>
                                    <%#Eval("DetailAddress")%>
                                </td>
                                <td>
                                    <%#Eval("Phone")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td colspan="4">
                            <input type="button" onclick="choiceReceive()" class="btn btn-success btn-sm" value="确定" />
                        </td>
                    </tr>
                </table>
            </div>
            <table cellpadding="0" cellspacing="0" id="Result" class="tabcolor">
                <tr>
                    <th width="6%">
                        全选
                    </th>
                    <th>
                        序号
                    </th>
                    <th>
                        商品名称
                    </th>
                    <th>
                        单价
                    </th>
                    <th>
                        数量
                    </th>
                    <th>
                        总价
                    </th>
                    <th>
                        库存数量
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <a href="javascript:void(0);" title="提交订单" onclick="showReceiveInfo()">提交订单</a>
                </div>
                <div class="pagebar">
                    <div id="Pagination">
                    </div>
                </div>
            </div>
            </form>
        </div>
    </div>
 

    <script type="text/javascript">
        var pageii;
        function showReceiveInfo() {
            pageii = layer.open({
                type: 1,
                shade: [0.5],
                area: ['500px', 'auto'],
                title: '选择收货人',
                border: [5, 0.3, '#000'],
                content:  $('#receiveDiv')
            });
        }
        function choiceReceive() {
            layer.close(pageii);
            var rid = $('input:radio:checked').val();
            if (typeof (rid) == "undefined" || rid == "") {
                v5.alert("您未添加收货人，请在[收货人地址]中添加收货人", '3', 'true');
                return false;
            }
            RunAjaxByListAddKey('', 'SubmitOrder', ',', rid);
        }

    </script>
      <%--  <script src="../Admin/pop/js/layer/layer.min.js" type="text/javascript"></script>--%>
</body>
</html>
