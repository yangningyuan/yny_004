//// Ajax通用请求与返回值方法集 2011-02(zh)
//Function.prototype.bind = function (obj) {
//    var method = this;
//    temp = function () {
//        return method.apply(obj, arguments);
//    }
//    return temp;
//}


function GetAjaxString(type, pramname, _url) {
    var link = "/AjaxM/ajax.aspx";
    if (_url) {
        link = _url;
    }
    link = link + "?type=" + type + "&pram=" + pramname;     //Ajax调用的页面URL
    return $.ajax({ url: link, async: false, type: "POST", cache: false }).responseText;
}