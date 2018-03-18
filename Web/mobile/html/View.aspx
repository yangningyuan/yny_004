<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="yny_004.Web.mobile.html.View" %>

<div class="content content-padded">
    <div class="list-block myinfo">
        <form id="form1">
            <ul>
                <!-- Text inputs -->
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">会员账号</div>
                            <div class="item-input">
                                <%=TModel.MID %>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">会员名称</div>
                            <div class="item-input">
                                <input type="text" id="txtMName" runat="server" >
                            </div>
                        </div>
                    </div>
                </li>
                <%--<li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">开户地区</div>
                            <div class="item-input">
                                <select id="ddlProvince" runat="server">
                                </select>
                                <select id="ddlCity" runat="server">
                                </select>
                                <select id="ddlZone" runat="server" style="display: none;">
                                </select>
                            </div>
                        </div>
                    </div>
                </li>--%>
                 <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">支付宝</div>
                            <div class="item-input">
                                <input id="txtAlipay" name="txtAlipay" runat="server" maxlength="50" type="text"  />
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">开户银行</div>
                            <div class="item-input">
                                <select id="txtBank" runat="server">
                                </select>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">开户支行</div>
                            <div class="item-input">
                                <input id="txtBranch" name="txtBranch" runat="server" maxlength="25" type="text"  />
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">开户姓名</div>
                            <div class="item-input">
                                <input id="txtBankCardName" name="txtBankCardName" runat="server" maxlength="20"
                                    type="text"  />
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">卡号</div>
                            <div class="item-input">
                                <input id="txtBankNumber" name="txtBankNumber" runat="server" maxlength="19" type="text"  />
                            </div>
                        </div>
                    </div>
                </li>
                 <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">设置交易密码</div>
                            <div class="item-input">
                                <input id="txtSePwd" name="txtSePwd" runat="server" maxlength="20" type="password"  />
                            </div>
                        </div>
                    </div>
                </li>
                 <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">密保问题</div>
                            <div class="item-input">
                                 <select id="ddlQuestion" name="ddlQuestion" runat="server">
                            </select>
                            </div>
                        </div>
                    </div>
                </li>
                 <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">密保答案</div>
                            <div class="item-input">
                                <input id="txtAnswer" name="txtAnswer" runat="server"  maxlength="6" type="text" />
                            </div>
                        </div>
                    </div>
                </li>
               
            </ul>
        </form>
    </div>
    <div class="content-block" id="btn" runat="server">
        <div class="row">
            <div class="col-100">
                <a href="javascript:void(0)" onclick="checkChange();" class="button button-big button-fill button-success">修改资料</a>
            </div>
        </div>
    </div>
</div>
<script>

    <%--setup();
    $(function () {
        $("#ddlProvince").val('<%=provice%>');
        change(1);
        $("#ddlCity").val('<%=City%>');
    });--%>

        function checkChange() {
            if ($('#txtMName').val() == '') {
                layer.msg('会员姓名不能为空');
                
            } else if ($('#txtBranch').val() == '') {
                layer.msg('请输入开户支行');
                
            } else if ($('#txtBankCardName').val() == '') {
                layer.msg('请输入开户姓名');
                
            //} else if ($('#ddlCity').val() == '地市') {
            //    layer.msg('请选择开户地区');
            } else if (!$('#txtBankNumber').val().TryBankCard()) {
                layer.msg('银行卡号只能是16-19位数字');
            } else if ($('#txtSePwd').val() == "") {
                layer.msg('交易密码不能为空');
            } else if ($('#txtAnswer').val() == "") {
                layer.msg('密保答案不能为空');
            } else if ($('#txtAnswer').val().length > 6 || $('#txtAnswer').val().length < 6) {
                layer.msg('密保答案为6位幸运数字');
            } else {
                //ActionModel("Member/Modify.aspx?Action=modify", $('#form1').serialize());
                $.ajax({
                    type: 'post',
                    url: 'Member/Modify.aspx?Action=modify',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        layer.msg(info);
                        setTimeout(function () {
                            window.location.reload();
                        }, 1000);
                    }
                });
            }
        }
</script>
