<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="yny_004.Web.Member.Modify"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        //var K = window.KKKK;
        //var uploadbutton = K.uploadbutton({
        //    button: K('#GatheringPic')[0],
        //    fieldName: 'imgFile',
        //    url: 'plugin/kindeditor/asp.net/upload_json.ashx?dir=image',
        //    afterUpload: function (data) {
        //        if (data.error === 0) {
        //            var url = K.formatUrl(data.url, 'absolute');
        //            K('#hduploadPic1').val(url);
        //            K('#uploadLog').html("上传成功");
        //            uploadSuccess("上传成功|" + url);
        //        } else {
        //            $('#uploadLog').html(data.message);
        //        }
        //    },
        //    afterError: function (str) {
        //        alert('自定义错误信息: ' + str);
        //    }
        //});
        //uploadbutton.fileBox.change(function (e) {
        //    uploadbutton.submit();
        //});

        //function deletePic(obj) {
        //    if (confirm("确定要删除吗？")) {
        //        var fileName = $(obj).parent().find(".hidPicurl").val();
        //        var hidId = $(obj).parent().find(".hidId").val();
        //        var hidDelIds = $("#hidDelIds").val();
        //        if (typeof (fileName) != "undefined" && fileName != "") {
        //            if (typeof (hidId) != "undefined" && hidId != "") {
        //                hidDelIds += hidId + ",";
        //                $("#hidDelIds").val(hidDelIds);
        //            }
        //            //如果是把首页图片删除了，就要重新设定首页图片
        //            if ($(obj).parent().hasClass("mainDiv")) {
        //                $(obj).parent().remove();
        //                $(".appDiv").first().addClass("mainDiv");
        //                //给首页图片的隐藏控件重新赋值
        //                $("#hidMainPic").val($(".appDiv").first().find(".hidPicurl").val());
        //            }
        //            else {
        //                $(obj).parent().remove();
        //            }
        //        }
        //    }
        //}

        //function uploadSuccess(msg) {
        //    if (msg.split('|').length > 1) {//成功
        //        $("#uploadLog").html("上传成功...");
        //        $('#hduploadPic1').val(msg.split('|')[1]);
        //        var appendHtml = "<div class='appDiv'><img class='appImg' src='" + msg.split('|')[1] + "'/><img class='xClose' onclick='deletePic(this)'  title='删除' src='/Admin/pop/images/uploadify-cancel.png'/><input type='hidden' name='uploadPic' class='hidPicurl' value='" + msg.split('|')[1] + "'/></div>";
        //        $("#tablePic").append(appendHtml);
        //    } else {
        //        $('#uploadLog').html(msg);
        //    }
        //}
    </script>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
                <input id="hdBankCode" type="hidden" runat="server" />
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="15%" align="right">会员账号:
                        </td>
                        <td width="35%">
                            <input id="txtMID" runat="server" class="normal_input" type="text" readonly="readonly" />
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">会员姓名:
                        </td>
                        <td width="35%">
                            <input id="txtMName" maxlength="30" runat="server" class="normal_input" type="text" />
                        </td>
                    </tr>
                    <%--<tr>
                        <td align="right">手机号码:
                        </td>
                        <td>
                            <input id="txtTel" runat="server" class="normal_input" type="text" />
                        </td>
                    </tr>--%>
                    <%
                        if (TModel.Role.IsAdmin)
                        {
                    %>
                    <tr>
                        <td width="15%" align="right">
                            <span>支付宝开户名：</span>
                        </td>
                        <td>
                            <input id="txtQRCode" name="txtQRCode" runat="server" class="pay_input"
                                type="text" value="11" require-msg="支付宝开户名" /><span>*</span>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            <span>支付宝：</span>
                        </td>
                        <td>
                            <input id="txtAlipay" name="txtAlipay" runat="server" class="pay_input"
                                type="text" value="11" require-msg="支付宝" /><span>*</span>
                        </td>
                    </tr>
                    
                    <%
                        }
                    %>
                    <tr>
                        <td align="right">开户地区:
                        </td>
                        <td>
                            <select id="ddlProvince" runat="server">
                            </select>
                            <select id="ddlCity" runat="server">
                            </select>
                            <select id="ddlZone" runat="server" style="display: none;">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            <span>开户银行：</span>
                        </td>
                        <td>
                            <select id="txtBank" runat="server">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            <span>开户支行：</span>
                        </td>
                        <td>
                            <input id="txtBranch" name="txtBranch" runat="server" maxlength="25" class="pay_input" type="text"
                                require-msg="开户支行" value="11" />
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            <span>开户姓名：</span>
                        </td>
                        <td>
                            <input id="txtBankCardName" name="txtBankCardName" runat="server" maxlength="20" class="pay_input"
                                type="text" value="11" require-msg="开户姓名" /><span>*</span>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            <span>卡号：</span>
                        </td>
                        <td>
                            <input id="txtBankNumber" name="txtBankNumber" runat="server" maxlength="19" class="pay_input" type="text"
                                value="11" require-msg="卡号" /><span>*</span>
                        </td>
                    </tr>

                    <tr>
                        <td width="15%" align="right">
                            <span>设置交易密码：</span>
                        </td>
                        <td>
                          <input id="txtSePwd" name="txtSePwd" runat="server" maxlength="20" type="text"  />
                        </td>
                    </tr>
                  <tr>
                        <td width="15%" align="right">
                            <span>密保问题：</span>
                        </td>
                        <td>
                           <select id="ddlQuestion" name="ddlQuestion" runat="server">
                            </select>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%" align="right">
                            <span>密保答案：</span>
                        </td>
                        <td>
                          <input id="txtAnswer" name="txtAnswer" runat="server" type="text" />
                        </td>
                    </tr>
                    <%--<tr>
                    <td align="right">
                        身份证号:
                    </td>
                    <td>
                        <input id="txtNumID" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        身份证图片:
                    </td>
                    <td>
                        <input type="button" id="GatheringPic" value="上传凭证" />
                        <div id='uploadLog'>
                        </div>
                        <input type="hidden" id="hduploadPic1" name="hduploadPic1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td>
                        <div style="float: left" id="tablePic">
                            <%=pic%>
                        </div>
                    </td>
                </tr>--%>
                    <tr style="height: 50px;">
                        <td align="right">
                            <input name="重置" type="reset" class="normal_btnok" value="重置" style="display: none;" />
                        </td>
                        <td align="left">
                            <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                        </td>
                    </tr>
                </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        setup();
        $(function () {
            $("#ddlProvince").val('<%=provice%>');
            change(1);
            $("#ddlCity").val('<%=City%>');
        });
        function checkChange() {
            if ($('#txtMName').val() == '') {
                v5.error('会员姓名不能为空', '1', 'true');
            } else if ($('#txtBranch').val() == '') {
                v5.error('请输入开户支行', '1', 'true');
            } else if ($('#txtBankCardName').val() == '') {
                v5.error('请输入开户姓名', '1', 'true');
            } else if ($('#ddlCity').val() == '地市') {
                v5.error('请选择开户地区', '1', 'true');
            } else if (!$('#txtBankNumber').val().TryBankCard()) {
                v5.error('银行卡号只能是16-19位数字', '1', 'true');
            } else {
                ActionModel("Member/Modify.aspx?Action=modify", $('#form1').serialize());
            }
        }
    </script>
</body>
</html>
