<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="yny_004.Web.Shop.OrderList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .seeExpress
        {
            cursor: pointer;
            color: Blue;
        }
    </style>
    <script src="/Admin3/js/TableToExcel.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            tUrl = "/Shop/Handler/OrderList2.ashx";
            tState = "<%=status %>";
            if (tState == 4) {
                $(".control .select > a:last").click();
            }
            else {
                SearchByCondition();
            }
        })
        //跳转到支付页面
        function payOrder(id) {
            callhtml('../Shop/PayOrder.aspx?id=' + id, '订单支付');
        }
        //管理员发货
        var pageii;
        var orderId = 0;
        function sendOrder(id) {
            orderId = id;
            pageii = layer.open({
                type: 1,
                shade: [0.5],
                area: ['285px', 'auto'],
                title: '填写快递单号',
                offset: ['', '50%'],
                border: [5, 0.5, '#000'],
                content: $('#receiveDiv')
            });
        }
        function choiceReceive() {
            if (checkForm()) {
                layer.close(pageii);
                var comp = $.trim($("#txtExpressCompany").val());
                var comCode = $.trim($("#txtExpressCode").val());
                var result = GetAjaxString('sendOrder', orderId + "&com=" + comp + "&code=" + comCode);
                if (result == 0) {
                    v5.alert("发货失败，请重试 ", '1', 'true');
                }
                else {
                    v5.alert("发货成功 ", '1', 'true');
                    $("#txtExpressCompany").val("圆通快递");
                    $("#txtExpressCode").val("");
                    //callhtml('../Shop/OrderList.aspx', '订单列表');
                }
            }
        }
        //确认收货
        function receiveOrder(id) {
            orderId = id;
            v5.confirm("确定收到货了吗？", realReceive);
        }
        function realReceive() {
            var result = GetAjaxString('receiveOrder', orderId);
            if (result == 0) {
                v5.alert("收货失败，请重试 ", '1', 'true');
            }
            else {
                v5.alert("确认收货成功 ", '1', 'true');
                callhtml('../Shop/OrderList.aspx', '订单列表');
            }
        }

        function delOrder(orderId) {
            var result = GetAjaxString('delOrder', orderId);
            if (result == 0) {
                v5.alert("删除失败，请重试 ", '1', 'true');
            }
            else {
                v5.alert("删除订单成功 ", '1', 'true');
                callhtml('../Shop/OrderList.aspx', '订单列表');
            }
        }

        // 导出Excel
        function exportExcel1() {
            ExportExcel("/Handler/ExportExcel.ashx", "OrdShop");
        }

        function seeExpress(id) {
            var result = GetAjaxString('seeExpress', id);
            if (result != "0") {
                $("#txtExpressCompany").val(result.split('≌')[1]).attr("readonly", "readonly");
                $("#txtExpressCode").val(result.split('≌')[0]).attr("readonly", "readonly");
                $("#btnSendExperee").hide();
                pageii = layer.open({
                    type: 1,
                    shade: [0.5],
                    area: ['285px', 'auto'],
                    title: '快递信息',
                    border: [5, 0.3, '#000'],
                    content: $('#receiveDiv')
                });
            }
        }

    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                 
                <a href="javascript:void(0);" onclick="SearchByState('',this);" class="btn btn-danger">
                    全部</a><a href="javascript:void(0)" onclick="SearchByState('1',this);" class="btn btn-success">未支付</a><a
                        href="javascript:void(0)" onclick="SearchByState('2',this);" class="btn btn-success">未发货</a><a
                            href="javascript:void(0)" onclick="SearchByState('3',this);" class="btn btn-success">未收货</a><a
                                href="javascript:void(0)" onclick="SearchByState('4',this);" class="btn btn-success">完成</a></div>
            <div class="search" id="DivSearch" runat="server">
                <%
                    if (TModel.Role.IsAdmin) {
                        %>
               <input type="button" value="导出" class="btn btn-success" onclick="exportExcel1()" />
                <%
                    }
                     %>
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" id="mKey" value="请输入会员账号" onfocus="if (value =='请输入会员账号'){value =''}"
                    onblur="if (value ==''){value='请输入会员账号'}" type="text" class="sinput" />
                <input type="text" name="txtKey" id="endDate" value="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" />
                <input type="text" name="txtKey" id="startDate" value="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({maxDate:'#F{$dp.$D(\'endDate\')}'})" />
            </div>
            <%--<div class="pay" onclick="UpDateByID('Member/UpMAgencyType.aspx?','升级会员',820,530)">
                升级会员</div>--%>
        </div>
        <div class="ui_table">
            <div id="receiveDiv" style="display: none">
                <table class="table">
                    <tr>
                        <td>
                            快递公司
                        </td>
                        <td>
                            <input id="txtExpressCompany" class="normal_input" value="圆通快递" type="text" maxlength="20" require-type="require"
                                require-msg="快递公司" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            快递单号
                        </td>
                        <td>
                            <input id="txtExpressCode" class="normal_input" type="text" require-type="require"
                                require-msg="快递单号" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <input type="button" id="btnSendExperee" onclick="choiceReceive()" class="btn btn-success btn-sm"
                                value="确定" />
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
                        订单编号
                    </th>
                    <th>
                        会员名称
                    </th>
                     <th>
                        注册时间
                    </th>
                    <th>
                        总价
                    </th>
                    <th>
                        商品名称
                    </th>
                    <th>
                        商品数量
                    </th>
                    <th>
                        订单时间
                    </th>
                    <th>
                        收货地址
                    </th>
                    <th>
                        订单状态
                    </th>
                    <th>
                        操作
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn" id="divOperator" runat="server">
                    
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
