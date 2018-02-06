// Ajax通用请求与返回值方法集 2011-02(zh)
Function.prototype.bind = function (obj) {
    var method = this;
    temp = function () {
        return method.apply(obj, arguments);
    }
    return temp;
}


//function GetAjaxString(type, pramname) {
//    var link = "/ajaxM/ajaxM.aspx?type=" + type + "&pram=" + pramname ;     //Ajax调用的页面URL
//    return $.ajax({ url: link, async: false }).responseText; 
//}

function GetAjaxString(types, pramname) {
    var retstr = $.ajax({
        url: "/AjaxM/ajax.aspx?type=" + types + "&pram=" + pramname,     //Ajax调用的页面URL
        data: {},
        type: "get",
        dataType: 'text',
        async: false,
        success: function (info) {
            return info;
        },
        error: function (er) {
            return er;
        }
    });
//    if (retstr.responseText.indexOf('html') > 0) {
//        return "操作失败，请重试！";
//    }
//    else
        return retstr.responseText;
}
function GetAjaxString(type, pramname, _url) {
    var link = "/AjaxM/ajax.aspx";
    if (_url) {
        link = _url;
    }
    link = link + "?type=" + type + "&pram=" + pramname;     //Ajax调用的页面URL
    return $.ajax({ url: link, async: false, type: "POST", cache: false }).responseText;
}
