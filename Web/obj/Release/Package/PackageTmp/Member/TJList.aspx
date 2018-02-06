<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TJList.aspx.cs" Inherits="yny_004.Web.Member.TJList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tState = 'true'
        tUrl = "Member/Handler/MemberTJList.ashx";
        SearchByCondition();

        // 导出Excel
        function exportExcel() {
            ExportExcel("ChangeMoney/Handler/ExportExcel.ashx", "TJLBExcel");
        }

        var layerID = 0;
        function transferForm(fromMID) {
            document.getElementById('transferForm').reset();
            $('#txtFromMID').val(fromMID);
            layerID = layer.open({
                type: 1,
                content: $('#transferWindow'),
                area: ['400px', '300px']
            });
        }
        function toggleActivationWay(way) {
            if (way == 'activationCode') {
                $('#activationCodeRow').show();
            } else {
                $('#activationCodeRow').hide();
            }
        }
        function transfer() {
            var txtMoney = $.trim($('#txtMoney').val());
            if (txtMoney == '') {
                layer.alert('请输入转出金额');
                return;
            }
            if (!/^\d+$/.test(txtMoney)) {
                layer.alert('请输入正确的转出金额');
                return;
            }

            var txtThrPwd = $.trim($('#txtThrPwd').val());
            if (txtThrPwd == '') {
                layer.alert('请输入转出会员资金密码');
                return;
            }

            layer.close(layerID);
            verifypsd(function () {
                $.ajax({
                    type: 'post',
                    url: 'Member/TJList.aspx?Action=Modify',
                    data: $('#transferForm').serialize(),
                    success: function (info) {
                        layer.alert(info);
                        if (info == '操作成功') {
                            SearchByCondition();
                        }
                    }
                });
            });
        }


    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0);" onclick="SearchByState('true',this);" class="btn btn-danger">
                    已投资</a> <a href="javascript:void(0)" onclick="SearchByState('false',this);" class="btn btn-success">
                        未投资</a>
            </div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <%--<input type="button" value="导出Excel" class="btn btn-success" onclick="exportExcel()" />--%>
                <input name="txtKey" data-name="txtKey" id="mKey" value="请输入会员账号" onfocus="if (value =='请输入会员账号'){value =''}"
                    onblur="if (value ==''){value='请输入会员账号'}" type="text" class="sinput" />
                <input name="txtKey" data-name="txtKey" id="mTJKey" value="请输入推荐会员账号" onfocus="if (value =='请输入推荐会员账号'){value =''}"
                    onblur="if (value ==''){value='请输入推荐会员账号'}" type="text" class="sinput" />
                <input name="txtKey" data-name="txtKey" id="mBDKey" value="请输入接点会员账号" onfocus="if (value =='请输入接点会员账号'){value =''}"
                    onblur="if (value ==''){value='请输入接点会员账号'}" type="text" class="sinput" />
            </div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" id="Result" class="tabcolor">
                <tr>
                    <th width="50px">
                        全选
                    </th>
                    <th>
                        序号
                    </th>
                    <th>
                        会员账号
                    </th>
                    <th>
                        会员姓名
                    </th>
                    <th>
                        会员角色
                    </th>
                    <th>
                        推荐人
                    </th>
                    <th>
                        推荐人数
                    </th>
                    <th>
                        <%=yny_004.BLL.Reward.List["MHB"].RewardName %>
                    </th>
                    <th>
                        <%=yny_004.BLL.Reward.List["MJB"].RewardName %>
                    </th>
                    <%--<th>
                        <%=yny_004.BLL.Reward.List["MCW"].RewardName %>
                    </th>--%>
                    <th>
                        状态
                    </th>
                    <th>
                        注册/激活日期
                    </th>
                    <%--<th>
                        操作
                    </th>--%>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                </div>
                <div class="pagebar">
                    <div id="Pagination">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--<div style="display: none" id="transferWindow">
        <form id="transferForm">
        <table style="width: auto; margin-left: auto; margin-right: auto;">
            <tr>
                <td style="text-align: right;">
                    转出源：
                </td>
                <td>
                    <input type="text" readonly="readonly" id="txtFromMID" name="txtFromMID" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    货币类型：
                </td>
                <td>
                    <label>
                        <input type="radio" value="MHB" name="txtCurrencyType" checked="checked" /><%=yny_004.BLL.Reward.List["MHB"].RewardName %></label>
                    <label>
                        <input type="radio" name="txtCurrencyType" value="MJB" /><%=yny_004.BLL.Reward.List["MJB"].RewardName %></label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    转出金额：
                </td>
                <td>
                    <input type="text" id="txtMoney" name="txtMoney" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    转出会员资金密码：
                </td>
                <td>
                    <input type="password" id="txtThrPwd" name="txtThrPwd" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <input type="button" class="btn btn-danger" value="转出" onclick="transfer()" />
                </td>
            </tr>
        </table>
        </form>
    </div>--%>
</body>
</html>
