<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WXChange.aspx.cs" Inherits="yny_004.Web.mobile.html.WXChange" %>

<script>
    layui.use("upload", function () {
        layui.upload({
            url: '/Admin/UpLoadPic/UploadImage.ashx',
            success: function (res) {
                console.log(res); //上传成功返回值，必须为json格式
                if (res.isSuccess) {
                    $("#upimage").attr("src", res.msg);
                    $("#uploadurl").val(res.msg);
                } else {
                    v5.alert(res.msg, '1', 'true')
                }
            }
        });
    });

</script>
<form id="form1">
    <input type="hidden" id="bankauto" runat="server" />
    <div class="content content-padded" id="firstPage">
        <div class="list-block myinfo">
            <%--<div class="tips">
                <label>充值说明</label>
                <p>充值金额方框里面填写100的整数倍进行汇款，带上后面二个小数点一起汇款到银行帐号</p>
            </div>--%>
            <ul>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">充值金额</div>
                            <div class="item-input" style="line-height: 2.2rem;">
                                <input type="text" value="" id="txtRealMoney" name="txtRealMoney" placeholder="请输入投资金额" style="width: 80%; float: left;"><%--.<%=mantissa %>--%>
                            </div>
                        </div>
                    </div>
                    <%-- <i class="ts">*请严格按照上述金额转账汇款,包括小数点后两位<b>.<%=mantissa %></b>如金额不匹配，则会造成充值延迟到账</i>--%>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">微信账号</div>
                            <div class="item-input">
                                <input type="text" id="txtTel" runat="server" value="" placeholder="微信账号">请填写微信的真实账号，否则无法到账！
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">预计到账时间</div>
                            <div class="item-input">
                                <input type="button" value="5分钟" disabled="disabled">
                            </div>
                        </div>
                    </div>
                </li>
            </ul>
        </div>
        <div class="content-block">
            <div class="row">
                <div class="col-100">
                    <a href="javascript:void(0)" onclick="firstButton()" class="button button-big button-fill button-warning">下一步</a>
                </div>
            </div>
        </div>
    </div>

    <div class="content content-padded" id="secondPage" style="display: none;">
        <div class="list-block myinfo">
            <div class="tips">
                <label>微信转账汇款<font style="color: red;">（待付款）</font></label>
                <p>*请通过微信转账</p>
                <input type="hidden" id="getsuiji" runat="server" />
            </div>
            <ul>
                <!-- Text inputs -->
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">收款人</div>
                            <div class="item-input">
                                <img src="/Admin/images/20171220093428.png" />
                            </div>
                        </div>
                    </div>
                </li>

                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">待支付金额</div>
                            <div class="item-input">
                                <span id="txtmoney"></span><%--.<%=mantissa %>--%>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">付款截图</div>
                            <div class="item-input">
                                <input type="file" name="upload" class="layui-upload-file">
                                <input type="hidden" id="uploadurl" name="uploadurl" runat="server" />
                                <img id="upimage" width="50px;" height="50px" />
                            </div>
                        </div>
                    </div>
                </li>
            </ul>
            <%-- <i class="ts">请在汇款【备注/附言】中严格按照要求填写充值附言码：<%=TModel.Tel %>.不要填写其他字符。否则不能正确到账！onecoin会在收到汇款后30分钟内为您入账，在此期间无需联系客服，如有问题我们会主动联系您。</i>--%>
            <i class="ts" style="color: red">为了您能快速入金，请在60分钟之内完成支付，系统会自动给您审核，如果超过60分钟未审核，请联系在线客服。</i>
        </div>
        <div class="content-block">
            <div class="row">
                <div class="col-100">
                    <a href="javascript:void(0)" onclick="SecondButton()" class="button button-big button-fill button-success">我已打款</a>
                </div>
            </div>
        </div>
    </div>
</form>

<script type="text/javascript">
    function firstButton() {

        if ($('#bankauto').val().Trim()=="0")
        {
            layer.alert('您的个人资料尚未绑定，需先绑定后才可继续操作', {
                skin: 'layui-layer-lan',
                closeBtn: 0
            }, function(){
                pcallhtml('/mobile/html/View.aspx','基本资料');
                layer.closeAll();
            });
        }
        else if(!$("#txtRealMoney").val().TryInt()){
            layer.msg("请输入正确的充值金额");
        }else if($("#txtRealMoney").val()<100){                
            layer.msg('充值金额最少为100');
        }else if($("#txtTel").val()==""){                
            layer.msg('微信账号不能为空');
        }else{
            $("#firstPage").hide();
            $("#secondPage").show();
            $("#txtmoney").html($("#txtRealMoney").val()-$("#getsuiji").val());
        }
    }
    function SecondButton() {
        if($("#uploadurl").val()=="")
        {
            layer.msg('请上传截图');
        }else{
            layer.confirm("确认您已打款",function(){
                ActionModel("ChangeMoney/WXChange.aspx?Action=add", $('#form1').serialize(),"/mobile/html/HKList.aspx");
            })
        }
        
    }
    function setValidMoney(realobj, validobj) {
        $(validobj).val($(realobj).val() / <%=yny_004.BLL.Configuration.Model.B_InFloat %>);
    }
    function checkChange() {
        if ($('#txtHKDate').val().Trim() == "") {
            layer.msg("汇款日期不能为空");
        } else if ($('#txtBankName').val().Trim() == '') {
            layer.msg("汇款人姓名不能为空");
        } else {
            ActionModel("ChangeMoney/WXChange.aspx?Action=add", $('#form1').serialize());
        }
    }
</script>

