


var convertTag = true;
//var GBStr = GB2312Str.split(',');
//var BIGStr = BIG5Str.split(',');
function traditionalized(cc) {
    convertTag = false;
    var str = '';
    var temp = '';
    for (var i = 0; i < GBStr.length; i++) {
        if (cc.indexOf(GBStr[i]) != -1) {
            cc = cc.replace(new RegExp(GBStr[i], 'gm'), BIGStr[i]);
        }
    }
    return cc;
}

function convertLanguage(istranslate) {
    if (istranslate || convertTag) {
        //转换网页title部分和body中的内容，一般都是这样，无特殊需求的话不做改动；
        document.title = traditionalized(document.title);
        document.body.innerHTML = traditionalized(document.body.innerHTML);
        if (defaultKye) {
            defaultKye = traditionalized(defaultKye);
        }
    }
    erMenu();
}

$(function () {
    convertLanguage();
    //选择语言
    $(".lng .lngbtn").click(function () {
        $.ajax({
            url: "/Admin/pop/Handler/Language.ashx",
            type: "POST",
            data: { type: "LanguageType", lan_EN: $(this).find(":first").attr("lng") },
            success: function (result) {
                if (result == "1") {
                    location.reload();
                }
            }
        });
    });
});

function erMenu() {
    $(".menuLi").mouseover(function () {
        $(this).find(".ermenu").show();
    });
    $(".menuLi").mouseleave(function () {
        $(this).find(".ermenu").hide();
    });
}
