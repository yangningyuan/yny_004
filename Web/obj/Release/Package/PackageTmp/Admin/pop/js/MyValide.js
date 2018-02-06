

// 去除空格
String.prototype.Trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, "");
}

// 正整数
String.prototype.TryInt = function () {
    var patrn = /^(?:[1-9]\d*|0)$/;
    return patrn.test(this);
}

// 小数
String.prototype.TryFloat = function () {
    var patrn = /^(?:0\.\d+|[01](?:\.0)?)$/;
    return patrn.test(this);
}

//身份证验证
String.prototype.TryIDCard = function () {
    var patrn = /^\d{6}(18|19|20)?\d{2}(0[1-9]|1[12])(0[1-9]|[12]\d|3[01])\d{3}(\d|X)$/i;
    return patrn.test(this);
}

//邮箱验证
String.prototype.TryEmail = function () {
    var patrn = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
    return patrn.test(this);
}

//邮箱验证或者为空(空返回true)
String.prototype.TryEmailOrEmpty = function () {
    if (this == null || this == '')
        return true;
    var patrn = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
    return patrn.test(this);
}

//手机号码验证
String.prototype.TryTel = function () {
    //return true;
    var patrn = /^(13+\d{9})$|(15+\d{9})$|(18+\d{9})$|(17+\d{9})$/;
    return patrn.test(this);
}

//手机验证或者为空(空返回true)
String.prototype.TryTelOrEmpty = function () {
    if (this == null || this == '')
        return true;
    var patrn = /^(13+\d{9})$|(15+\d{9})$|(18+\d{9})$|(17+\d{9})$/;
    return patrn.test(this);
}

String.prototype.TryBankCard = function () {
    var pat = /^\d{16,19}$/;
    return pat.test(this);
}

// 带小数的金额验证
String.prototype.TryMoney = function () {
    var patrn = /^[0-9]+(.[0-9]{2})?$/;
    return patrn.test(this);
}

//必须为数字和字母(6-20位字母数字的组合)
String.prototype.TryMID = function () {
    var reg1 = /^[a-zA-Z\d]{6,20}$/;
    return reg1.test(this);
    if (this.length >= 6 && this.length <= 20)
        return true;
    var reg = /^(([a-z]+[0-9]+)|([0-9]+[a-z]+))[a-z0-9]*$/i;
    if (this.length >= 6 && this.length <= 20)
        return reg.test(this);
    return false;
}

//必须为数字和字母
String.prototype.TryPassword = function () {
    var reg1 = /^[a-zA-Z\d]{6,20}$/;
    return reg1.test(this);
    var reg = /^(([a-z]+[0-9]+)|([0-9]+[a-z]+))[a-z0-9]*$/i;
    if (this.length >= 6 && this.length <= 20)
        return reg.test(this);
    return false;
}

//是否是中文
String.prototype.TryEN = function () {
    //var regex = /^[\u4E00-\uFA29]{2,5}|(?:·[\u4E00-\uFA29]{2,5})$/;
    var regex = /^[\u4E00-\u9FA5]{2,}$/;
    return regex.test(this);
}

//得到当前日期
function GetNowDate() {
    var d = new Date();
    return d.getFullYear() + "-" + appendZero(d.getMonth() + 1) + "-" + appendZero(d.getDate());
}
function appendZero(s) {
    return ("00" + s).substr((s + "").length);
} //补0函数


