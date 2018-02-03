<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HBChange.aspx.cs" Inherits="yny_004.Web.ChangeMoney.HBChange"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="right">
                            <span>转出会员：</span>
                        </td>
                        <td>
                            <input id="txtFromMID" runat="server" class="normal_input" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span>
                                <%=yny_004.BLL.Reward.List["MJB"].RewardName%>余额：</span>
                        </td>
                        <td>
                            <label id="txtMGP">
                                <%=TModel.MConfig.MJB.ToString("F2")%></label>
                            <%if (TModel.Role.Super)
                                { %><input type="button" class="normal_btnok btn btn-success" value="查询" onclick="findMJB()" /><%} %>
                        </td>
                    </tr>
                      <tr>
                        <td align="right">
                            <span>
                                <%=yny_004.BLL.Reward.List["MHB"].RewardName%>余额：</span>
                        </td>
                        <td>
                            <label id="txtMGP">
                                <%=TModel.MConfig.MHB.ToString("F2")%></label>
                           
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span>转入会员：</span>
                        </td>
                        <td>
                            <input id="txtMID" runat="server" class="normal_input" type="text" onchange="getName();" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span>会员姓名：</span>
                        </td>
                        <td>
                            <input id="txtMName" readonly="readonly" runat="server" class="normal_input" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span>转账钱包：</span>
                        </td>
                        <td>
                            
                            <input id="Radio1" type="radio" value="MJB" name="RioHK" checked="checked" /><%=yny_004.BLL.Reward.List["MJB"].RewardName%>
                            <input id="RioJB" type="radio" value="MHB" name="RioHK"/><%=yny_004.BLL.Reward.List["MHB"].RewardName %>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span>转账金额：</span>
                        </td>
                        <td>
                            <input name="txtMHB" id="txtMHB" class="normal_input" type="text" maxlength="6" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                            <div id="divTips" runat="server" style="color: Red">
                                您的账号暂不能转账，请联系管理员！
                            </div>
                        </td>
                    </tr>
                </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            var reg1 = /^\d+$/;
            if ($('#txtMHB').val().Trim() == "") {
                v5.error('转账金额不能为空', '1', 'true');
            } else if (!$('#txtMHB').val().TryInt()) {
                v5.error('转账金额应该为整数', '1', 'true');
            } else if (RunAjaxGetKey('getMName', $('#txtMID').val()) == '') {
                v5.error('不存在转入会员', '1', 'true');
            } else if (RunAjaxGetKey('getMName', $('#txtFromMID').val()) == '') {
                v5.error('不存在转出会员', '1', 'true');
            } else if ($('#txtFromMID').val() == $('#txtMID').val()) {
                v5.error('不能自己给自己转账', '1', 'true');
            }
                //            else if (!isCanChangeByMember()) {
                //                v5.error('转出会员与转入会员没有推荐关系，不能转账', '2', 'true');
                //            }
            else {
                ActionModel("ChangeMoney/HBChange.aspx?Action=add", $('#form1').serialize(), "ChangeMoney/HBChange.aspx", "", "会员转账");
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
</body>
</html>
