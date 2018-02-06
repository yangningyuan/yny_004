<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HKChangeFlow.aspx.cs" Inherits="yny_004.Web.mobile.html.HKChangeFlow" %>

<form id="form1">
    <input type="hidden" id="bankauto"  runat="server" />
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
                                <input type="text" value=""  id="txtRealMoney" name="txtRealMoney" placeholder="请输入投资金额" style="width: 80%; float: left;"><%--.<%=mantissa %>--%>
                            </div>

                        </div>

                    </div>
                   <%-- <i class="ts">*请严格按照上述金额转账汇款,包括小数点后两位<b>.<%=mantissa %></b>如金额不匹配，则会造成充值延迟到账</i>--%>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">支付宝姓名</div>
                            <div class="item-input">
                                <input type="text"  id="txtTel" runat="server" value="" placeholder="支付宝姓名">请填写支付宝的真实姓名，否则无法到账！
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">预计到账时间</div>
                            <div class="item-input">
                                <input type="button" value="5分钟"   disabled="disabled">
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

    <div class="content content-padded"   id="secondPage" style="display: none;">
        <div class="list-block myinfo">
            <div class="tips">
                <label>支付宝转账汇款<font style="color: red;">（待付款）</font></label>
                <p>*请通过支付宝或者网银转账到银行卡</p>
                <input type="hidden" id="getsuiji" runat="server" />
            </div>
            <ul>
                <!-- Text inputs -->
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">收款人</div>
                            <div class="item-input">
                                <input type="text" value="<%=adminBankCardName %>" disabled="disabled">
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">银行账户</div>
                            <div class="item-input">
                                <input type="email" value="<%=adminBankNumber %>" disabled="disabled">
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">开户行</div>
                            <div class="item-input">
                                <input type="text" value="<%=adminBank + adminBranch  %>" disabled="disabled">
                            </div>
                        </div>
                    </div>
                </li>
               <%-- <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">支付宝付款人</div>
                            <div class="item-input">
                                <input type="text" value="<%=alipayname %>" disabled="disabled">
                            </div>
                        </div>
                    </div>
                </li>--%>
               <%-- <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">支付宝账号</div>
                            <div class="item-input">
                                <input type="text" value="<%=alipay %>" disabled="disabled">
                            </div>
                        </div>
                    </div>
                </li>--%>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">待支付金额</div>
                            <div class="item-input">
                                <span id="txtmoney"></span>.<%=mantissa %>
                            </div>
                        </div>
                    </div>
                </li>
              <%--  <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">备注/附言/摘要</div>
                            <div class="item-input">
                                <input type="text" value="<%=TModel.Tel %>" disabled="disabled">
                            </div>
                        </div>
                    </div>
                </li>--%>
            </ul>
           <%-- <i class="ts">请在汇款【备注/附言】中严格按照要求填写充值附言码：<%=TModel.Tel %>.不要填写其他字符。否则不能正确到账！onecoin会在收到汇款后30分钟内为您入账，在此期间无需联系客服，如有问题我们会主动联系您。</i>--%>
			 <i class="ts" style="color:red">为了您能快速入金，请在60分钟之内完成支付，系统会自动给您审核，如果超过60分钟未审核，请联系在线客服。</i>
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
                layer.msg('支付宝姓名不能为空');
            }else{
                $("#firstPage").hide();
                $("#secondPage").show();
                $("#txtmoney").html($("#txtRealMoney").val()-$("#getsuiji").val());
            }
        }
        function SecondButton() {
            layer.confirm("确认您已打款",function(){
                ActionModel("ChangeMoney/HKChangeFlow.aspx?Action=add", $('#form1').serialize(),"/mobile/html/HKList.aspx");
            })
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
                ActionModel("ChangeMoney/HKChangeFlow.aspx?Action=add", $('#form1').serialize());
            }
        }
    </script>
