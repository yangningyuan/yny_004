<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HBChange.aspx.cs" Inherits="yny_004.Web.mobile.html.HBChange" %>

<div class="content content-padded">
    <div class="list-block myinfo">
        <form id="form1">
            <ul>
                <!-- Text inputs -->
              <%--  <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label"><%=yny_004.BLL.Reward.List["MJB"].RewardName %></div>
                            <div class="item-input">
                                <input type="text" value=" <%=TModel.MConfig.MJB.ToFixedString() %>" disabled="disabled">
                            </div>
                        </div>
                    </div>
                </li>--%>
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
                <li style="display:none;">
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">转出会员</div>
                            <div class="item-input">
                                <input type="text" value="" name="txtFromMID" runat="server" id="txtFromMID" placeholder="请输入转出会员">
                            </div>
                        </div>
                    </div>
                </li>
                  <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">转入会员</div>
                            <div class="item-input">
                                <input type="text" value="" name="txtMID"  onchange="getName();" runat="server" id="txtMID" placeholder="请输入转入会员">
                            </div>
                        </div>
                    </div>
                </li>
                 <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">会员姓名</div>
                            <div class="item-input">
                                <input type="text" value="" readonly="readonly" name="txtMName" runat="server" id="txtMName" placeholder="请输入会员姓名">
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">转账金额</div>
                            <div class="item-input">
                                <input type="text" value="" runat="server" name="txtMHB" id="txtMHB" placeholder="请输入转账金额">
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
                                    <input type="radio" name="RioHK"  value="MHB" checked="checked">
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

            </ul>
        </form>
    </div>
    <div class="content-block">
        <div class="row">
            <div class="col-100">
                <a href="javascript:checkChange();" id="btnOK" runat="server" class="button button-big button-fill button-success">提交</a>
                 <div id="divTips" runat="server" style="color: Red">
                                您的账号暂不能转账，请联系管理员！
                            </div>
            </div>
        </div>
    </div>
</div>


<script type="text/javascript">
        function checkChange() {
            var reg1 = /^\d+$/;
            if ($('#txtMHB').val().Trim() == "") {
                
                layer.msg("转账金额不能为空");
            } else if (!$('#txtMHB').val().TryInt()) {
                
                layer.msg("转账金额应该为整数");
            } else if (RunAjaxGetKey('getMName', $('#txtMID').val()) == '') {
                
                layer.msg("不存在转入会员");
            } else if (RunAjaxGetKey('getMName', $('#txtFromMID').val()) == '') {
                
                layer.msg("不存在转出会员");
            } else if ($('#txtFromMID').val() == $('#txtMID').val()) {
                
                layer.msg("不能自己给自己转账");
            }
            else {
                ActionModel("/ChangeMoney/HBChange.aspx?Action=add", $('#form1').serialize(), "/mobile/html/HBChange.aspx", "", "会员转账");
            }
        }
        //转账只能转给有推荐关系的会员之间转账,该函数校验转出会员与转入会员之间是否有推荐或被推荐关系
        function isCanChangeByMember() {
            var fromMID = $('#txtFromMID').val().Trim();
            var toMID = $('#txtMID').val().Trim();
            var result = GetAjaxString("isCanChangeByMember", fromMID + "|" + toMID);
            if (result == "1")
                return true;
            else
                return false;
        }

        function getName() {
            $("#txtMName").val(RunAjaxGetKey('getMName', $('#txtMID').val()));
        }

        function findMoney() {
            var re = $('input[name="RioHK"]:checked').val();
            if (re == "MHB") {
                findMHB();
            } else {
                findMJB();
            }
        }

        function findMHB() {
            var reuslt = RunAjaxGetKey('FindMHB', $('#txtFromMID').val());
            if (reuslt == '') {
                v5.error('不存在转出会员', '1', 'true');
            } else {
                $('#txtMJB').html(reuslt);
            }
        }

        function findMGP() {
            var reuslt = RunAjaxGetKey('FindMGP', $('#txtFromMID').val());
            if (reuslt == '') {
                v5.error('不存在转出会员', '1', 'true');
            } else {
                $('#txtMGP').html(reuslt);
            }
        }

        function findMCW() {
            var reuslt = RunAjaxGetKey('FindMCW', $('#txtFromMID').val());
            if (reuslt == '') {
                v5.error('不存在转出会员', '1', 'true');
            } else {
                $('#txtMGP').html(reuslt);
            }
        }

        function findMJB() {
            var reuslt = RunAjaxGetKey('FindMJB', $('#txtFromMID').val());
            if (reuslt == '') {
                v5.error('不存在转出会员', '1', 'true');
            } else {
                $('#txtMJB').html(reuslt);
            }
        }
    </script>