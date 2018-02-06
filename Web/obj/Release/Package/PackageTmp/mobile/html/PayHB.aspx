<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayHB.aspx.cs" Inherits="yny_004.Web.mobile.html.PayHB" %>

<%--<script src="http://api.map.baidu.com/api?v=1.3" type="text/javascript"></script>
<script type="text/javascript" src="convertor.js"></script>
<script>
    function Redirect() {
        if ($('#bankauto').val() == "0") {

            layer.alert('您的个人资料尚未绑定，需先绑定后才可继续操作', {
                skin: 'layui-layer-lan',
                closeBtn: 0
            }, function () {
                pcallhtml('/Member/Modify.aspx', '完善资料'); onclickMenu();
                layer.closeAll();
            });
        }
        else if ($('#txtValidMoney').val() == "") {
            layer.msg('充值金额不能为空');
        } else {
            var ss = $("input:radio:checked").val();
            if (ss == '1') {
                document.forms[0].action = "Payment/cai1pay/redirect.aspx";
                if ($("input[name='yh']:checked").val() == '03100') {
                    document.forms[0].action = "Payment/WFT/WFTPayIndex.aspx";
                }
            }
            else if (ss == '2') {
                document.forms[0].action = "Payment/ShouXinyi/Redirect.aspx";
            }
            else if (ss == '3') {
                document.forms[0].action = "Payment/ShouXinyi/WeiXin.aspx";
            }
            else {
                if ($('#txtValidMoney').val() > 500) {
                    layer.msg("支付宝单笔充值最高500，可以分多笔支付");
                    return;
                }
                document.forms[0].action = "Payment/ShouXinyi/ZhiFuBao.aspx";
            }
            document.forms[0].submit();
         
            document.forms[0].submit();
        }
    }
</script>
<style type="text/css">
    .list-block table tr td {
        width: 50%;
    }
</style>
<form id="form1" method="post" target="_blank" action="Payment/GuoFuBao/Redirect.aspx">
    <input type="hidden" id="tmid" runat="server" />
    <div class="content content-padded pull-to-refresh-content" data-ptr-distance="55">
        <!-- 默认的下拉刷新层 -->
        <div class="pull-to-refresh-layer">
            <div class="preloader"></div>
            <div class="pull-to-refresh-arrow"></div>
        </div>
        <div class="list-block">
            <table class=" table table-striped table-bordered ">
                <tbody>
                    <tr>
                        <td>充值类型
                        </td>
                        <td style="text-align: left;">

                            <input type="radio" value="1" name="zf" checked="checked">在线支付<br />
                         
                            <input type="radio" value="5" name="zf" onclick="pcallhtml('/mobile/html/HKChangeFlow.aspx', '支付宝快速入金', 'url', 680, 330)">支付宝快速入金<br />
                            <input type="radio" value="6" name="zf" onclick="pcallhtml('/mobile/html/HKChangeWY.aspx', '网银汇款', 'url', 680, 330)">网银汇款
                        </td>
                    </tr>
                    <tr>
                        <td>充值金额</td>
                        <td>

                            <input id="txtValidMoney" placeholder="请输入充值金额" runat="server" class="normal_input" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input name="yh" type="radio" value="01106">
                            <img src="/Payment/banks/jianshe.gif">
                        </td>

                        <td>
                            <input name="yh" type="radio" value="01101">
                            <img src="/Payment/banks/nongye.gif">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input name="yh" type="radio" value="01100" checked="checked">
                            <img src="/Payment/banks/gongshang.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="01102">
                            <img src="/Payment/banks/zhaohang.gif">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input name="yh" type="radio" value="01108">
                            <img src="/Payment/banks/jiaotong.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="01119">
                            <img src="/Payment/banks/youzheng.gif">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input name="yh" type="radio" value="01107">
                            <img src="/Payment/banks/zhongguo.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="01112">
                            <img src="/Payment/banks/guangda.gif">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input name="yh" type="radio" value="01104">
                            <img src="/Payment/banks/zhongxin.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="01114">
                            <img src="/Payment/banks/guangfa.gif">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input name="yh" type="radio" value="01109">
                            <img src="/Payment/banks/shangpufa.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="01113">
                            <img src="/Payment/banks/beijing.gif">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input name="yh" type="radio" value="01111">
                            <img src="/Payment/banks/huaxia.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="01103">
                            <img src="/Payment/banks/cib.gif">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input name="yh" type="radio" value="01110">
                            <img src="/Payment/banks/minsheng.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="01121">
                            <img src="/Payment/banks/pingan.gif">
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td>
                            <input name="yh" type="radio" value="03200">
                            <img src="/Payment/banks/zhifubao.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="03100" onclick="pcallhtml('/mobile/html/WXChange.aspx', '微信支付', 'url', 680, 330)">
                            <img width="154px" height="33" src="../Payment/banks/weixin.gif">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="file" accept="image/*" capture="camera">
                            <input type="file" accept="video/*" capture="camcorder">
                            <input type="file" accept="audio/*" capture="microphone">
                        </td>
                        <td>
                            <div id="map" style="width: 600px; height: 400px"></div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="content-block">
            <a class="button button-fill button-big button-success" onclick="Redirect()">确定</a>
        </div>
    </div>

    <script src="/mobile/js/convertor.js"></script>

    <script type="text/javascript">
        if (window.navigator.geolocation) {
            var options = {
                enableHighAccuracy: true,
            };
            window.navigator.geolocation.getCurrentPosition(handleSuccess, handleError, options);
        } else {
            alert("浏览器不支持html5来获取地理位置信息");
        }

        function handleSuccess(position) {
            // 获取到当前位置经纬度  本例中是chrome浏览器取到的是google地图中的经纬度
            var lng = position.coords.longitude;
            var lat = position.coords.latitude;
            // 调用百度地图api显示
            var map = new BMap.Map("map");
            var ggPoint = new BMap.Point(lng, lat);
            // 将google地图中的经纬度转化为百度地图的经纬度
            BMap.Convertor.translate(ggPoint, 2, function (point) {
                var marker = new BMap.Marker(point);
                map.addOverlay(marker);
                map.centerAndZoom(point, 15);
            });
        }

        function handleError(error) {

        }
    </script>
</form>--%>
<script>
    function Redirect() {
        if ($('#bankauto').val() == "0") {

            layer.alert('您的个人资料尚未绑定，需先绑定后才可继续操作', {
                skin: 'layui-layer-lan',
                closeBtn: 0
            }, function () {
                pcallhtml('/Member/Modify.aspx', '完善资料'); onclickMenu();
                layer.closeAll();
            });
        }
        else if ($('#txtValidMoney').val() == "") {
            layer.msg('充值金额不能为空');
        } else {
            var ss = $("input:radio:checked").val();
            //if (ss == '1') {
            //    document.forms[0].action = "Payment/cai1pay/redirect.aspx";
            //}
            //else if (ss == '2') {
            //    document.forms[0].action = "Payment/ShouXinyi/Redirect.aspx";
            //}
            //else if (ss == '3') {
            //    document.forms[0].action = "Payment/ShouXinyi/WeiXin.aspx";
            //}
            //else {
            //    if ($('#txtValidMoney').val() > 500) {
            //        layer.msg("支付宝单笔充值最高500，可以分多笔支付");
            //        return;
            //    }
                //document.forms[0].action = "Payment/ShouXinyi/ZhiFuBao.aspx";
            //}

            document.forms[0].action = "/Payment/KaiLT/post.aspx";
            document.forms[0].method = "get";
            document.forms[0].submit();
        }
    }
</script>
<style type="text/css">
	.list-block table tr td {
	width:50%
	}
</style>
<form id="form1" method="post" target="_blank" action="Payment/GuoFuBao/Redirect.aspx">
    <input type="hidden" id="tmid" runat="server" />
    <div class="content content-padded pull-to-refresh-content" data-ptr-distance="55">
        <!-- 默认的下拉刷新层 -->
        <div class="pull-to-refresh-layer">
            <div class="preloader"></div>
            <div class="pull-to-refresh-arrow"></div>
        </div>
        <div class="list-block">
            <table class=" table table-striped table-bordered ">
                <tbody>
                    <tr>
                        <td>充值类型
                        </td>
                        <td style="text-align: left;">

                            <input type="radio" value="yh" name="zf" checked="checked">在线支付<br />
                            <%--<input  type="radio" value="3" name="zf">微信支付--%>
<%--                            <input type="radio" value="5" name="zf" onclick="pcallhtml('/mobile/html/HKChangeFlow.aspx', '支付宝快速入金', 'url', 680, 330)">支付宝快速入金<br />
                            <input type="radio" value="6" name="zf" onclick="pcallhtml('/mobile/html/HKChangeWY.aspx', '网银汇款', 'url', 680, 330)">网银汇款--%>
                        </td>
                    </tr>
                    <tr>
                        <td>充值金额</td>
                        <td>

                            <input id="txtValidMoney" name="txtValidMoney" placeholder="请输入充值金额" runat="server" class="normal_input" type="text" />
                        </td>
                    </tr>
                  <%--  <tr>
                        <td>
                            <input name="yh" type="radio" value="ccb">
                            <img src="/Payment/banks/jianshe.gif">
                        </td>

                        <td>
                            <input name="yh" type="radio" value="abc">
                            <img src="/Payment/banks/nongye.gif">
                        </td>
						 </tr>
						 <tr>
                        <td>
                            <input name="yh" type="radio" value="icbc" checked="checked">
                            <img src="/Payment/banks/gongshang.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="cmb">
                            <img src="/Payment/banks/zhaohang.gif">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input name="yh" type="radio" value="comm">
                            <img src="/Payment/banks/jiaotong.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="psbc">
                            <img src="/Payment/banks/youzheng.gif">
                        </td>
						 </tr>
						 <tr>
                        <td>
                            <input name="yh" type="radio" value="boc">
                            <img src="/Payment/banks/zhongguo.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="ceb">
                            <img src="/Payment/banks/guangda.gif">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input name="yh" type="radio" value="citic">
                            <img src="/Payment/banks/zhongxin.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="cgb">
                            <img src="/Payment/banks/guangfa.gif">
                        </td>
						 </tr>
						 <tr>
                        <td>
                            <input name="yh" type="radio" value="spdb">
                            <img src="/Payment/banks/shangpufa.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="bob">
                            <img src="/Payment/banks/beijing.gif">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input name="yh" type="radio" value="hxb">
                            <img src="/Payment/banks/huaxia.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="cib">
                            <img src="/Payment/banks/cib.gif">
                        </td>
						 </tr>
						 <tr>
                        <td>
                            <input name="yh" type="radio" value="cmbc">
                            <img src="/Payment/banks/minsheng.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="pingan">
                            <img src="/Payment/banks/pingan.gif">
                        </td>
                    </tr>--%>
                  
                </tbody>
            </table>
        </div>
        <div class="content-block">
            <a class="button button-fill button-big button-success" onclick="Redirect()">确定</a>
        </div>
    </div>
</form>
