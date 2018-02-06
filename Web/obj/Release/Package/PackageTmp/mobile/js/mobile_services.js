/// <reference path="jquery-1.8.3.min" />
/// <reference path="../layermobile/layer.js" />


//对对象的操作，新增，修改
function APPActionModel(acturl, actdata, url) {
    $.ajax({
        type: 'post',
        url: acturl,
        data: actdata,
        success: function (info) {
            zx_alert(info);
        }
    });
}


function zx_alert(msg) {
    layer.open({
        content: msg,
        style: 'background-color:#09C1FF; color:#fff; border:none;',
        time: 2
    });
}

function zx_post(url, opt, data, callback, resultType) {
    var postData = { opt: opt }
    if (typeof data == 'string') {
        $.post(url, data + '&opt=' + opt, callback, resultType);
        return;
    }
    var postData = $.extend(postData, data);

    $.post(url, postData, callback, resultType);
}
function zx_ep_post(opt, data, callback, type) {
    zx_post('handlers/EPHandler.ashx', opt, data, callback, type);
}

function ep_sell(amount, secPwd) {
    zx_ep_post('sell', { amount: amount, secPwd: secPwd }, function (result) {
        zx_alert(result);
    }, 'text');
}

function ep_tradingList() {

}
function ep_query() {
    var p = $('#zx_page');
    var tmpl = p.data('tmpl');
    var data = {
        pageIndex: p.val(),
        pageSize: p.data('pagesize'),
        midOrAmount: $('#midOrAmount').val()
    }
    zx_ep_post(p.data('opt'), data, function (result) {
        var list = JSON.parse(result);
        $('#zx_page').data('totalpage', list.TotalPage);
        $('#data_container').html('');
        console.log(list);
        $('#' + tmpl).tmpl(list.PageData).appendTo('#data_container');
        $('.timer').timer();
    }, 'text');

}

function zx_add(now, max) {
    max = parseInt(max);
    var added = parseInt(now) + 1;
    if (added > max) {
        return max;
    } else {
        return added;
    }
}

function zx_reduce(now, min) {
    min = parseInt(min);
    var reduced = parseInt(now) - 1;
    if (reduced < min) {
        return min;
    } else {
        return reduced;
    }
}

function ep_buy(id) {
    zx_ep_post('buy', { id: id }, function (result) {
        zx_alert(result);
        if (result.indexOf('成功') != -1) {
            ep_query();
        }
    }, 'text');
}

function ep_pay(id) {
    var pzimg = $('#fileUp').data('pzimg');
    //if (!pzimg) {
    //	zx_alert('请上传打款凭证');
    //	return;
    //}
    zx_ep_post('pay', { id: id, imgSrc: pzimg }, function (result) {
        zx_alert(result);
    }, 'text');
}

function ep_confirm(id) {
    zx_ep_post('Confirm', { id: id }, function (result) {
        zx_alert(result);
    }, 'text');
}
function ep_rate(id, type) {
    var rate = $('[name=rate]:checked').val();
    zx_ep_post('rate', { id: id, type: type, rate: rate }, function (result) {
        zx_alert(result);
    }, 'text');
}

function uploadSuccess(result) {
    var arr = result.split('|');
    if (arr[0] == '上传成功!') {
        var url = arr[1];
        $('#fileUp').data('pzimg', url);
        $('#pzimg').attr('src', url);
        console.log(url);
    } else {
        zx_alert(arr[0]);
    }
}


function zx_member_post(opt, data, callback, type) {
    zx_post('handlers/Member.ashx', opt, data, callback, type);
}


function member_upgrade(newLevel, secPwd) {
    if (secPwd == '') {
        zx_alert('请输入资金密码');
        return;
    }
    var data = {
        newLevel: newLevel,
        secPwd: secPwd
    }
    zx_member_post("upgrade", data, function (result) {
        zx_alert(result);
    }, 'text');
}

function member_modify() {
    var tel = $.trim($('#txtTel').val());
    if (tel == '') {
        zx_alert('请输入手机号');
        return;
    }
    if (!/^(13[0-9]|14[0-9]|15[0-9]|18[0-9]|17[0-9])\d{8}$/i.test(tel)) {
        zx_alert('手机号错误');
        return;
    }
    var name = $.trim($('#txtMName').val());
    if (name == '') {
        zx_alert('请输入姓名');
        return;
    }

    zx_member_post('modify', $('#modifyForm').serialize(), function (result) {
        zx_alert(result);
    }, 'text');
}
function member_changePwd() {
    var orginalPwd = $.trim($('#orginalPwd').val());
    if (orginalPwd == '') {
        zx_alert('请输入原密码');
        return;
    }

    var newPwd = $.trim($('#newPwd').val());
    if (newPwd == '') {
        zx_alert('请输入新密码');
        return;
    }

    var newPwd2 = $.trim($('#newPwd2').val());
    if (newPwd2 == '') {
        zx_alert('请再次输入新密码');
        return;
    }

    if (newPwd2 != newPwd) {
        zx_alert('两次输入密码不一致');
        return;
    }

    var secPwd = $.trim($('#secPwd').val());
    if (secPwd == '') {
        zx_alert('请输入资金密码');
        return;
    }
    var data = {
        orginalPwd: orginalPwd,
        newPwd: newPwd,
        secPwd: secPwd
    };

    zx_member_post("changePwd", data, function (result) {
        zx_alert(result);
    }, 'text');
}

function money_convert() {
    var amount = $.trim($('#amount').val());
    amount = parseInt(amount);
    if (isNaN(amount) || amount <= 0) {
        zx_alert('转换金额不正确');
        return;
    }
    zx_member_post('convert', { amount: amount }, function (result) {
        zx_alert(result);
    }, 'text');
}


function member_activate() {
    var txtMID = $.trim($('#txtMID').val());
    if (txtMID == '') {
        zx_alert('请输入要激活的会员账号');
        return;
    }
    zx_member_post('activate', { txtMID: txtMID, level: $('#txtLevel').val() }, function (result) {
        zx_alert(result);
    }, 'text');
}
function levelChange() {
    $('#txtNeededMoney').text($($('#txtLevel')[0].selectedOptions[0]).data('money'));
}


function member_regidit() {
    var txtMID = $.trim($('#txtMID').val());
    if (txtMID == '') {
        zx_alert('请输入会员账号');
    }
    if (!/^(\d|[a-zA-Z]){6,30}$/.test(txtMID) || !/\d+/.test(txtMID)) {
        zx_alert('用户名由字母和数字组成，至少六位，最长30位');
        return false;
    }
    var txtMName = $.trim($('#txtMName').val());
    if (txtMName == '') {
        zx_alert('会员昵称不能为空');
        return false;
    }
    var txtTel = $.trim($('#txtTel').val());
    if (txtTel == '') {
        zx_alert('手机号码不能为空');
        return false;
    }
    if (!/^1\d{10}$/.test(txtTel)) {
        zx_alert('请输入正确的手机号码');
        return false;
    }

    var txtPwd = $.trim($('#txtPwd').val());
    if (txtPwd == '') {
        zx_alert('登录密码不能为空');
        return false;
    }
    if (!/^(\d|[a-zA-Z]){6,20}$/.test(txtPwd)) {
        zx_alert('登录密码长度6-20位，字母或数字组成');
        return false;
    }
    var txtPwd2 = $.trim($('#txtPwd2').val());
    if (txtPwd2 != txtPwd) {
        zx_alert('两次输入的登录密码不一致');
        return false;
    }


    var txtSecPwd = $.trim($('#txtSecPwd').val());
    if (txtSecPwd == '') {
        zx_alert('资金密码不能为空');
        return false;
    }
    if (!/^(\d|[a-zA-Z]){6,20}$/.test(txtSecPwd)) {
        zx_alert('资金密码长度6-20位，字母或数字组成');
        return false;
    }
    var txtSecPwd2 = $.trim($('#txtSecPwd2').val());
    if (txtSecPwd2 != txtSecPwd) {
        zx_alert('两次输入的资金密码不一致');
        return false;
    }

    var txtPwdAnswer = $.trim($('#txtPwdAnswer').val());
    if (txtPwdAnswer == '') {
        zx_alert('请输入密保回答');
        return false;
    }

    $('#registerForm').find('[name^=__]').remove();

    var data = $('#registerForm').serialize();
    zx_post("/regedit/index.aspx", 'register', data, function (result) {
        zx_alert(result);
    }, 'text');
}


function gonggaoQuery() {
    var p = $('#zx_page');
    var postObj = {
        pageIndex: p.val(),
        pageSize: p.data('pagesize')
    }
    $.post('xw_gonggao.aspx?action=add', postObj, function (result) {
        console.log(result);
        var list = result;
        $('#zx_page').data('totalpage', list.TotalPage);
        $('#data_container').html('');
        $('#gonggaoTmpl').tmpl(list.PageData).appendTo('#data_container');
    }, 'json');
}

function huifuQuery() {
    var p = $('#zx_page');
    var postObj = {
        pageIndex: p.val(),
        pageSize: p.data('pagesize')
    }
    $.post('huifulist.aspx?action=other', postObj, function (result) {
        console.log(result);
        var list = result;
        $('#zx_page').data('totalpage', list.TotalPage);
        $('#data_container').html('');
        $('#huifulistTmpl').tmpl(list.PageData).appendTo('#data_container');
    }, 'json');
}

function zhuanzhangQuery() {
    var p = $('#zx_page');
    var data = {
        pageIndex: p.val(),
        pageSize: p.data('pagesize'),
        midOrAmount: $('#midOrAmount').val(),
        type: $('#zztype').val()
    }
    $.post('zz_jilu.aspx?action=other', data, function (result) {
        console.log(result);
        var list = result;
        $('#zx_page').data('totalpage', list.TotalPage);
        $('#data_container').html('');
        $('#zz_jilu_tmpl').tmpl(list.PageData).appendTo('#data_container');
    }, 'json');
}

function member_zhuanzhang() {
    var mid = $.trim($('#txtMID').val());
    if (mid == '') {
        zx_alert('请输入账号');
        return;
    }

    var amount = $.trim($('#txtAmount').val());
    if (amount == '') {
        zx_alert('请输入金额');
        return;
    }
    amount = parseInt(amount);
    if (isNaN(amount)) {
        zx_alert('请输入正确的金额');
        return;
    }

    var secPwd = $.trim($('#secPwd').val());
    if (secPwd == '') {
        zx_alert('请输入安全密码');
        return;
    }
    var postObj = {
        mid: mid,
        amount: amount,
        secPwd: secPwd,
        currencyType: $('#sltMoneyType').val()
    };
    zx_post('handlers/member.ashx', 'zhuanzhang', postObj, function (result) {
        zx_alert(result);
        if (result.indexOf('成功') != -1) {
            setTimeout(function () {
                window.location.reload();
            }, 2000);
        }
    }, 'text');

}

function convertList() {
    var p = $('#zx_page');
    var data = {
        pageIndex: p.val(),
        pageSize: p.data('pagesize'),
        midOrAmount: $('#midOrAmount').val()
    }
    $.post('convertList.aspx?action=other', data, function (result) {
        console.log(result);
        var list = result;
        $('#zx_page').data('totalpage', list.TotalPage);
        $('#data_container').html('');
        $('#zz_convertListTmpl').tmpl(list.PageData).appendTo('#data_container');
    }, 'json');
}

function sendMsgCode() {
    var txtTel = $.trim($('#txtTel').val());
    if (txtTel == '') {
        layer.alert('手机号码不能为空');
        return false;
    }
    if (!/^1\d{10}$/.test(txtTel)) {
        layer.alert('请输入正确的手机号码');
        return false;
    }
    $('#btnSendCode').html('正在发送...').attr('onclick', '');
    var postObj = {
        txtTel: $('#txtTel').val()
    };
    zx_member_post('SendMsgCode', postObj, function (result) {
        $('#btnSendCode').html(result);
    }, 'text');
}


function TXListQuery() {
    var p = $('#zx_page');
    var postObj = {
        pageIndex: p.val(),
        pageSize: p.data('pagesize')
    }
    $.post('TXList.aspx?action=other', postObj, function (result) {
        console.log(result);
        var list = result;
        $('#zx_page').data('totalpage', list.TotalPage);
        $('#data_container').html('');
        $('#txlistTmpl').tmpl(list.PageData).appendTo('#data_container');
    }, 'json');
}


function ListQuery(strobj) {
    var p = $('#zx_page');
    var postObj = {
        pageIndex: p.val(),
        pageSize: p.data('pagesize')
    }
    $.post("/mobile/phone_html/" + strobj + 'List.aspx?action=other', postObj, function (result) {
        console.log(result);
        var list = result;
        $('#zx_page').data('totalpage', list.TotalPage);
        $('#data_container').html('');
        $("#" + strobj + "listTmpl").tmpl(list.PageData).appendTo('#data_container');
    }, 'json');
}

