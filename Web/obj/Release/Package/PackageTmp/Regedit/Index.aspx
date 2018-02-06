<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="yny_004.Web.Regedit.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>
        <%=WebModel.WebTitle%></title>
<%--    <link rel="Shortcut Icon" href="images/fac.ico"/>--%>
    <meta name="renderer" content="webkit" />
    <meta http-equiv="Cache-Control" content="no-siteapp" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/font-awesome.css" rel="stylesheet">
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" type="text/css" href="../plugin/kindeditor/themes/default/default.css" />
    <link href="../Admin/pop/css/pop.css" rel="stylesheet" type="text/css" />
    <link href="../Admin/pop/css/V5-UI.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Admin/js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="../Admin/pop/js/MyValide.js"></script>
    <link href="../plugin/layer/skin/layer.css" rel="stylesheet" type="text/css" />
    <script src="../plugin/layer/layer.js" type="text/javascript"></script>
    <script src="../Admin/pop/js/ajax.js" type="text/javascript"></script>
    <script src="../Admin/pop/js/V5-UI.js" type="text/javascript"></script>
    <script src="../Admin/pop/js/javascript_pop.js" type="text/javascript"></script>
    <script type="text/javascript" src="../plugin/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="../Admin/pop/js/linkage.js"></script>
    <script type="text/javascript">
        $(function () {
            if (!placeholderSupport()) {   // 判断浏览器是否支持 placeholder
                $('[placeholder]').focus(function () {
                    var input = $(this);
                    if (input.val() == input.attr('placeholder')) {
                        input.val('');
                        input.removeClass('placeholder');
                    }
                }).blur(function () {
                    var input = $(this);
                    if (input.val() == '' || input.val() == input.attr('placeholder')) {
                        input.addClass('placeholder');
                        input.val(input.attr('placeholder'));
                    }
                }).blur();
            };
            setup();
        })
        function placeholderSupport() {
            return 'placeholder' in document.createElement('input');
        }
        function TestEmail() {
            if (!$('#txtMName').val().TryEN()) {
                v5.error('会员姓名只能输入两位以上的中文字符', '1', 'true');
            } else if ($('#txtMTJ').val() == '') {
                v5.error('推荐会员帐号不能为空', '1', 'true');
                //} else if ($('#txtMBD').val() == '') {
                //    v5.error('接点会员不能为空', '1', 'true');
            } else if (!$('#txtPassword').val().TryPassword()) {
                v5.error('登录密码不能为空，且必须为6-20位字母或数字组合', '1', 'true');
            } else if ($('#txtPassword').val() != $('#txtPassword2').val()) {
                v5.error('登录密码与确认登录密码不一样', '1', 'true');
            } else if (!$('#txtSecPsd').val().TryPassword()) {
                v5.error('资金密码不能为空，且必须为6-20位字母或数字组合', '1', 'true');
            } else if ($('#txtSecPsd').val() != $('#txtSecPsd2').val()) {
                v5.error('资金密码与确认资金密码不一样', '1', 'true');
            } else if ($('#txtPassword').val() == $('#txtSecPsd').val()) {
                v5.error('资金密码与登录密码不能相同', '1', 'true');
            } else if (!$('#txtTel').val().TryTel()) {
                v5.error('手机号码格式不正确', '1', 'true');
            } else if ($('#txtTelCode').val() == "") {
                v5.error("手机验证码不能为空", '1', 'true');
            //} else if ($('#ddlCity').val() == '地市') {
            //    v5.error('请选择开户地区', '1', 'true');
            //} else if ($('#txtBranch').val() == '') {
            //    v5.error('请输入开户支行', '1', 'true');
            //} else if (!$('#txtBankCardName').val().TryEN()) {
            //    v5.error('会员姓名只能输入两位以上的中文字符', '1', 'true');
            //} else if ($('#txtBankCardName').val() != $('#txtMName').val()) {
            //    v5.error('开户姓名必须与会员姓名一直', '1', 'true');
            //} else if (!$('#txtBankNumber').val().TryBankCard()) {
            //    v5.error('银行卡号只能是16-19位数字', '1', 'true');
            //} else if ($('#txtAnswer').val() == '') {
            //    v5.error('密保答案不能为空', '1', 'true');
            } else {
                $.ajax({
                    type: 'post',
                    url: '../AjaxM/Regedit.ashx?Action=add',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        v5.alert(info, '1', 'true');
                        setTimeout(function () {
                            v5.clearall();
                            //if (info == '注册成功') {
                            //callhtml('Member/UpMemberSJ.aspx?id=' + $("#txtMID").val(), '升级会员');
                            //}
                        }, 1000);
                    }
                });
            }
        }
        function sendTelCode() {
            var tel = $.trim($("#txtTel").val());
            if (tel == "") {
                v5.error('手机号码不能为空', '1', 'true');
                return false;
            }
            if (!tel.TryTel()) {
                v5.error('手机号格式不正确', '1', 'true');
                return false;
            }
            var relVal = GetAjaxString('SendCode', tel);
            v5.error(relVal, '1', 'true');
        }
    </script>
</head>
<body>
    <div class="web-header">
        <div class="container clearfix">
            <div class="pull-left logo">
                <a href="Index.aspx">
                    <img src="images/rlogo.png" height="66px"></a>
            </div>
            <nav class="blog-nav pull-left">
                <span class="blog-nav-item active" href="../Regedit/Index.aspx">会员注册</span>
            </nav>
        </div>
    </div>
    <div class="container">
        <div class="mainbody">
          <div class="title"> <span>注册</span>
					<a href="../Login.aspx" class="pull-right rightlink text-danger">已有账号，直接登陆</a>
				</div>
            <div class="register-box">
                <form class="form-horizontal" method="post" id="form1">
                    <div class="form-group">
                        <label class="col-sm-3 control-label">
                            推荐会员帐号
                        </label>
                        <div class="col-sm-9">
                            <input id="txtMTJ" class="form-control" name="txtMTJ" type="text" runat="server"
                                placeholder="请输入您的推荐人帐号" />请输入您的推荐会员帐号
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">
                            手机号码(登录帐号)
                        </label>
                        <div class="col-sm-9">
                            <input id="txtTel" name="txtTel" class="form-control" maxlength="11" type="text"
                                placeholder="请输入您的手机号码" />
                            <input type="text" id="txtTelCode" name="txtTelCode" placeholder="请输入验证码" style="width: 30%;
                            float: left; height: 34px; line-height: 34px;" />
                            <input type="button" value="获取验证码" onclick="sendTelCode()" class="btn btn-success"
                                   style="float: left;" />
                        </div>
                    </div>
                    <%--<div class="form-group">
                        <label class="col-sm-3 control-label">
                            接点人账号
                        </label>
                        <div class="col-sm-9">
                            <input id="txtMBD" class="form-control" name="txtMTJ" type="text" runat="server"
                                placeholder="请输入您的接点人账号" />请输入您的接点人账号
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">
                            接点位置
                        </label>
                        <div class="col-sm-9">
                            <select id="ddlMBDIndex" name="ddlMBDIndex" runat="server">
                                <option value="1">左区</option>
                                <option value="2">右区</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">
                            报单中心账号
                        </label>
                        <div class="col-sm-9">
                            <input id="txtMSH" class="form-control" name="txtMTJ" type="text" runat="server"
                                placeholder="请输入您的报单中心账号" />请输入您的报单中心账号
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">
                            会员帐号
                        </label>
                        <div class="col-sm-9">
                            <input id="txtMID" class="form-control" name="txtMID" type="text" maxlength="20"
                                placeholder="请输入您的会员账号" />6-20字母或数字组合
                        </div>
                    </div>--%>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">
                            会员姓名
                        </label>
                        <div class="col-sm-9">
                            <input id="txtMName" class="form-control" name="txtMName" type="text" placeholder="请输入您的会员姓名"
                                maxlength="30" />
                        </div>
                    </div>
                    <hr />
                    <div class="form-group">
                        <label class="col-sm-3 control-label">
                            登录密码
                        </label>
                        <div class="col-sm-9">
                            <input id="txtPassword" class="form-control" name="txtPassword" type="password" maxlength="20"
                                value="" placeholder="请输入您的登录密码" />6-20个字母或数字组合
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">
                            确认登录密码
                        </label>
                        <div class="col-sm-9">
                            <input id="txtPassword2" class="form-control" name="txtPassword2" type="password"
                                value="" maxlength="20" placeholder="请再次输入您的登录密码" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">
                            资金密码
                        </label>
                        <div class="col-sm-9">
                            <input id="txtSecPsd" class="form-control" name="txtSecPsd" type="password" maxlength="20"
                                value="" placeholder="请输入您的资金密码" />6-20个字母或数字组合
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">
                            确认资金密码
                        </label>
                        <div class="col-sm-9">
                            <input id="txtSecPsd2" class="form-control" name="txtSecPsd2" type="password" maxlength="20"
                                value="" placeholder="请再次输入您的资金密码" />
                        </div>
                    </div>
                    <hr />
                    <div class="form-group" style="display:none;">
                        <label class="col-sm-3 control-label">
                            开户地区
                        </label>
                        <div class="col-sm-9">
                            <select id="ddlProvince" runat="server"></select>
                            <select id="ddlCity" runat="server"></select>
                            <select id="ddlZone" runat="server" style="display: none;"></select>
                        </div>
                    </div>
                    <%--<div class="form-group">
                        <label class="col-sm-3 control-label">
                            身份证号
                        </label>
                        <div class="col-sm-9">
                            <input name="txtNumID" id="txtNumID" class="form-control" type="text" placeholder="请输入您的身份证号" />
                        </div>
                    </div>--%>
                    <%--<div class="form-group">
                        <label class="col-sm-3 control-label">
                            上传身份证
                        </label>
                        <div class="col-sm-9">
                            <input type="button" id="GatheringPic" value="上传身份证" />
                            <div id='uploadLog'>
                            </div>
                            <input type="hidden" id="hduploadPic1" name="hduploadPic1" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">
                        </label>
                        <div class="col-sm-9">
                            <div style="float: left" id="tablePic">
                            </div>
                        </div>
                    </div>--%>
                    <div class="form-group" style="display:none;">
                        <label class="col-sm-3 control-label">
                            开户银行
                        </label>
                        <div class="col-sm-9">
                            <select id="txtBank" runat="server" class="form-control"></select>
                        </div>
                    </div>
                    <div class="form-group" style="display:none;">
                        <label class="col-sm-3 control-label">
                            开户支行
                        </label>
                        <div class="col-sm-9">
                            <input id="txtBranch" name="txtBranch" class="form-control" maxlength="20" type="text"
                                placeholder="请输入您的开户支行" /><span>广州***支行</span>
                        </div>
                    </div>
                    <div class="form-group" style="display:none;">
                        <label class="col-sm-3 control-label">
                            开户姓名
                        </label>
                        <div class="col-sm-9">
                            <input id="txtBankCardName" name="txtBankCardName" class="form-control" maxlength="20"
                                type="text" placeholder="请输入开户姓名" />
                        </div>
                    </div>
                    <div class="form-group" style="display:none;">
                        <label class="col-sm-3 control-label">
                            银行卡号
                        </label>
                        <div class="col-sm-9">
                            <input name="txtBankNumber" id="txtBankNumber" class="form-control" type="text" maxlength="19" placeholder="请输入您的银行卡号" />
                        </div>
                    </div>
                    <div class="form-group" style="display:none;">
                        <label class="col-sm-3 control-label">
                            密保问题
                        </label>
                        <div class="col-sm-9">
                            <select id="ddlQuestion" name="ddlQuestion" runat="server"></select>
                        </div>
                    </div>
                    <div class="form-group" style="display:none;">
                        <label class="col-sm-3 control-label">
                            密保答案
                        </label>
                        <div class="col-sm-9">
                            <input name="txtAnswer" id="txtAnswer" class="form-control" type="text" placeholder="请输入您的密保答案" />
                        </div>
                    </div>
                  <%--  <hr />--%>
                    <div class="form-group mt20">
                        <label class="col-sm-3 control-label">
                        </label>
                        <div class="col-sm-9">
                            <input type="button" class="btn btn-success btn-lg width300" onclick="TestEmail()" value="注册账号" />
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
