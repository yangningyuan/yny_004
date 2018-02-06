<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvestApply.aspx.cs" Inherits="yny_004.Web.mobile.html.InvestApply" %>

<div class="content content-padded">
    <div class="list-block myinfo">
        <form id="form1">
            <input type="hidden" id="bankauto" runat="server" />
            <ul>
                <!-- Text inputs -->
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label"><%=yny_004.BLL.Reward.List["MJB"].RewardName %></div>
                            <div class="item-input">
                                <input type="text" value=" <%=TModel.MConfig.MJB.ToFixedString() %>" disabled="disabled">
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">投资金额</div>
                            <div class="item-input">
                                <input type="text" value="" name="txtMHB" id="txtMHB" placeholder="请输入投资金额">
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">选择币种</div>
                            <div class="item-input">
                                <label class="label-checkbox item-content">
                                    <input type="radio" name="rdo" checked="checked" value="MJB">
                                    <div class="item-media"><i class="icon icon-form-checkbox"></i></div>
                                    <div class="item-inner">
                                        <div class="item-title-row">
                                            <div class="item-title"><%=yny_004.BLL.Reward.List["MJB"].RewardName %></div>

                                        </div>

                                    </div>
                                </label>
                                
                            </div>
                        </div>
                    </div>
                </li>

            </ul>
        </form>
    </div>
    <div class="content-block">
        <div class="row">
            <div class="col-100">
                <a href="javascript:checkChange();" class="button button-big button-fill button-success">提交</a>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    function checkChange() {
        if ($('#txtMHB').val().trim() == "") {
            layer.msg("投资金额不能为空");
            return;
        }else if ($('#bankauto').val().Trim() == "0") {
            layer.alert('您的个人资料尚未绑定，需先绑定后才可继续操作', {
                skin: 'layui-layer-lan',
                closeBtn: 0
            }, function () {
                pcallhtml('/mobile/html/View.aspx', '基本资料');
                layer.closeAll();
            });
            return;
        } else {
            ActionModel("Module/Investment/InvestApply.aspx?Action=add", $('#form1').serialize());
        }
    }
</script>
