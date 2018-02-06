<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddReceive.aspx.cs" Inherits="yny_004.Web.mobile.html.AddReceive" %>

<%--<div id="pageHome" class="page out">--%>
    <form id="form1">
        <div class="content">
            <div class="zh_head">
                <i class="iconfont">&#xe61e;</i><span>添加收货人</span>
            </div>
            <input id="hdBankCode" type="hidden" runat="server" />
            <input type="hidden" id="hidId" runat="server" />
            <div class="zc_in">
                <span>收货人姓名：</span>
                <input id="txtReceive" runat="server" type="text" maxlength="20" />
            </div>
            <div class="zc_in">
                <span>收货人地址：</span>
                <select id="ddlProvince" runat="server" style="">
                </select><span>*</span><br>
                <input type="hidden" runat="server" id="hidProvince" />
                <select id="ddlCity" runat="server" style="">
                </select><span>*</span><br>
                <select id="ddlZone" runat="server" style="">
                </select>
            </div>
            <div class="zc_in">
                <span>详细地址：</span>
                <input id="txtAddress" runat="server" type="text" />
            </div>
            <div class="zc_in">
                <span>邮编：</span>
                <input id="txtZipCode" runat="server" type="text" maxlength="50" />
            </div>
            <div class="zc_in">
                <span>固定电话：</span>
                <input id="txtTel" runat="server" type="text" maxlength="11" />
            </div>
            <div class="zc_in">
                <span>手机号码：</span>
                <input id="txtPhone" runat="server" type="text" maxlength="20" />
            </div>
            <div class="zc_in">
                <span>默认收货人：</span>
                <input id="chkIsMain" runat="server" type="checkbox" value="1" />
            </div>

            <a href="javascript:void(0)" title="" id="Button1" runat="server" class="btn_qd" style="display: block;" onclick="checkChange();">提交</a>

        </div>
    </form>
<%--</div>--%>
<script type="text/javascript">
    $(function () {
        setup();
    });
    function checkChange() {
        if ($('#txtReceive').val().Trim() == "") {
            layer.msg('收货人不能为空');
        } else if ($('#txtAddress').val() == "") {
            layer.msg('收货人地址不能为空');
        } else if ($('#txtPhone').val() == '') {
            layer.msg('手机不能为空');
        } else {
            if (checkForm()) {
                $.ajax({
                    type: 'post',
                    url: '/Shop/AddReceive.aspx?Action=add',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        layer.msg(info);
                        pcallhtml('/mobile/html/ReceiveInfo.aspx', '收货人管理');
                    }
                });
            }
        }
    }
</script>
