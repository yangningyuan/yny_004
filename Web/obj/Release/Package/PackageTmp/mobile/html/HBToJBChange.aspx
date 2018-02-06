<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HBToJBChange.aspx.cs" Inherits="yny_004.Web.mobile.html.HBToJBChange" %>

<div class="content content-padded">
    <div class="list-block myinfo">
        <form id="form1">
            <ul>
                <!-- Text inputs -->
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label"><%=yny_004.BLL.Reward.List["MHB"].RewardName %></div>
                            <div class="item-input">
                                <input type="text" value=" <%=TModel.MConfig.MHB.ToFixedString() %>" disabled="disabled">
                            </div>
                        </div>
                    </div>
                </li>
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
                            <div class="item-title label">兑换金额</div>
                            <div class="item-input">
                                <input type="text" value="" runat="server" name="txtMHB" id="txtMHB" placeholder="请输入兑换金额">
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label"></div>
                            <div class="item-input">
                                <label class="label-checkbox item-content">
                                    <input type="radio" name="ddlFrom" checked="checked" value="MHB">
                                    <div class="item-media"><i class="icon icon-form-checkbox"></i></div>
                                    <div class="item-inner">
                                        <div class="item-title-row">
                                            <div class="item-title"><%=yny_004.BLL.Reward.List["MHB"].RewardName %></div>
                                        </div>
                                    </div>
                                </label>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">转换为</div>
                            <div class="item-input">
                                <label class="label-checkbox item-content">
                                    <input type="radio" name="ddlTo" checked="checked" value="MJB">
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
                <a href="javascript:checkChange();" id="btnOK" runat="server" class="button button-big button-fill button-success">提交</a>
                 <div id="divTips" runat="server" style="color: Red">
                                
                            </div>
            </div>
        </div>
    </div>
</div>


<script type="text/javascript">
        function checkChange() {
            var reg1 = /^\d+$/;
            if ($('#txtMHB').val().Trim() == "") {
                
                layer.msg("兑换金额不能为空");
            } else if (!$('#txtMHB').val().TryInt()) {
                
                layer.msg("兑换金额应该为整数");
            }
            else {
                ActionModel("/ChangeMoney/HBToJBChange.aspx?Action=add", $('#form1').serialize(), "/mobile/html/HBToJBChange.aspx", "", "会员转换");
            }
        }
    </script>