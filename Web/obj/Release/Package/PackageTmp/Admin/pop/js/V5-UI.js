var v5 = {};
var callbackFun;
var maskCount = 0;

v5.show = function (content, htmltitle, type, sw, sh) {
    callhtml(content, htmltitle, type, sw, sh);
    return;
    maskCount++;
    if ($("#v5_show").length <= 0 && type == "id") {
        var width = $("#" + content + "").width();
        var height = $("#" + content + "").height();
        var htmlcontent = $("#" + content + "").html();
        $("body").append("<div id='v5_show'><div class='title'>" + htmltitle + "</div><div class='close' onclick='v5.clearshow();'></div>" + htmlcontent + "</div>");
        $("body").append("<div id='shade'></div>");
        $("#v5_show").css("width", (width + 20) + "px");
        $("#v5_show").css("height", (height + 40) + "px");
        $("#v5_show").css("marginLeft", -(width + 20) / 2 + "px");
        $("#v5_show").css("marginTop", -(height + 40) / 2 + "px");
        $("#v5_show").stop().fadeIn(300);
        $("#shade").stop().fadeIn(300);
    }
    else if ($("#v5_show").length <= 0 && type == "url") {
        $("body").append("<div id='shade'></div>");
        $.get(content, function (data) {
            $("body").append("<div id='v5_show'><div class='title'>" + htmltitle + "</div><div class='close' onclick='v5.clearshow();'></div>" + data + "</div>");
            $("#v5_show").css("width", (sw + 20) + "px");
            $("#v5_show").css("height", (sh + 40) + "px");
            $("#v5_show").css("marginLeft", -(sw + 20) / 2 + "px");
            $("#v5_show").css("marginTop", -(sh + 40) / 2 + "px");
            $("#v5_show").stop().fadeIn(300);
            $("#shade").stop().fadeIn(300);
        }
		);
    }
}

v5.alert = function (content, time, mask, func) {
    callbackFun = func;
    layer.alert(content, {
        skin: 'layer-ext-moon',
        btn: '确定',
        yes: function (index, layero) {
            layer.close(index);
            if (func) {
                confirmcall();
            }
        }
    });
}

v5.error = function (content, time, mask) {
    layer.alert(content, {
        skin: 'layer-ext-moon',
        btn: '确定',
        yes: function (index, layero) {
            layer.close(index);
        }
    });
}

v5.shadeshow = function (content) {
    $("body").append("<div id='shade'></div>");
    $("body").append("<div id='v5_prompt'><div></div><div class='content'>" + content + "</div></div>");
    $("#v5_prompt").css("color", "#ffffff")
    $("#v5_prompt").css("marginLeft", -($("#v5_prompt").width() + 20) / 2 + "px");
    $("#v5_prompt").css("marginTop", -($("#v5_prompt").height() + 20) / 2 + "px");
    $("#v5_prompt").stop().fadeIn(300);
    $("#shade").stop().fadeIn(300);
    maskCount++;
}

v5.clearshade = function () {
    v5.clearprompt();
}

v5.success = function (content, time, mask) {
    layer.alert(content, {
        skin: 'layer-ext-moon',
        btn: '确定',
        yes: function (index, layero) {
            layer.close(index);
        }
    });
}

v5.confirm = function (content, callfuc, mask) {
    callbackFun = callfuc;
    layer.alert(content, {
        skin: 'layer-ext-moon',
        btn: ["确定", "取消"],
        yes: function (index, layero) {
            layer.close(index);
            if (callfuc) {
                confirmcall();
            }
        }
    });
}

function confirmcall() {
    callbackFun();
}

v5.prompt = function (content, callfuc, inputtype, mask) {
    callbackFun = callfuc;
    layer.open({
        type: 1,
        shade: [0.5],
        area: ['220px', 'auto'],
        title: content,
        border: [5, 0.3, '#000'],
        content: "<div style=\"padding: 10px 20px 0px;\"><input type='" + inputtype + "' id='inputid' class='normal_input callinput'></div>",
        btn: ["确定", "取消"],
        yes: function (index, layero) {
            promptcall();
            layer.close(index);
        }
    });
    $("#inputid").focus();
}

function promptcall() {
    var str = $("#inputid").val();
    //v5.clearprompt();
    callbackFun(str);
}

v5.clearshow = function () {
    maskCount--;
    $("#v5_show").remove();
    if (maskCount <= 0) {
        $("#shade").remove();
        maskCount = 0;
    }
}

v5.clearprompt = function () {
    maskCount--;
    $("#v5_prompt").remove();
    if (maskCount <= 0) {
        $("#shade").remove();
        maskCount = 0;
    }
}

v5.clearall = function () {
    maskCount = 1;
    v5.clearshow();
    maskCount = 1;
    v5.clearprompt();
    if (tUrl != '') {
        PageLoad();
    }
}