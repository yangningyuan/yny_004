function changetabcolor(title) {
    // if (title)
    $("#mempay").prepend("<div class=\"alert alert-danger\" style='margin-bottom:0px;'><strong>" + title + "</strong></div>");
    $("#finance").find("table").addClass('table table-bordered table-striped table-white').css("overflow-y", "auto");
    $("#mempay .control").addClass('alert');
    $("#mempay .control").find(".ssubmit").addClass('btn btn-success');
    $("#mempay .control .pay").addClass('btn btn-success');
    $("#mempay .control .cheeckbox table").find("td").css('padding-right', '5px');
    $("#mempay").find(".ui_table").find("table").addClass(' table table-bordered table-hover').css("background-color", "rgb(252, 252, 252)");
    $("#mempay").find(".ui_table").find("th").css('background-color', 'rgb(255, 249, 229)').css('color', '#000000').css('text-align', 'left');

    $("#mempay #finance").find("table").find("td").removeAttr('align');
    $("#mempay #finance").find("table").find("td").css('text-indent', '10px');
    $("#mempay #finance").find("table").css('border', 'solid 1px #8e846b');
    $("#mempay #finance").find("table").find("tr").css('height', '26px');

    $("#finance").find(".normal_btnok").addClass('btn btn-success');
    $(".ui_table_control .pn").find("a").addClass('btn btn-warning');
    $("#mempay .control").css("padding-bottom", "38px").css("margin-bottom", "2px");

    //$("#mempay").css("padding-top", "50px");
    LoadPlaceholder();
}
// JavaScript Document
function LoadPlaceholder() {
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
}

function placeholderSupport() {
    return 'placeholder' in document.createElement('input');
}

function pcallhtmlNoV(url, title, isback) {
    var urlpage = url;
    cur_pageIndex = 0;
    if (url.indexOf("?") > -1)
        url += "&r=" + Math.random();
    else
        url += "?r=" + Math.random();
    if (isback) {
    }
    else {
        StackPush(url, title);
    }

    setTimeout(function () { $("#pageHome").load(url, function () { changetabcolor(title); }); }, 10);


}


function pcallhtml(url, title, isback) {
    var urlpage = url;
    cur_pageIndex = 0;
    if (url.indexOf("?") > -1)
        url += "&r=" + Math.random();
    else
        url += "?r=" + Math.random();
    if (isback) {
    }
    else {
        StackPush(url, title);
    }
    if (RunAjaxGetKey('VerifyBase', urlpage) == 'TRUE') {
        if (RunAjaxGetKey('VerifyUrl', url) == 'TRUE') {
            //appverifypsd(function () {
                setTimeout(function () { $("#pageHome").load(url, function () { changetabcolor(title); }); }, 10);
            //});
        }
        else {
            setTimeout(function () { $("#pageHome").load(url, function () { changetabcolor(title); }); }, 10);
        }
    } else {
        layer.msg('没有权限');
    }


}

function checkForm() {
    var result = true;
    $("[require-type]").each(function () {
        var rtype = $(this).attr("require-type");
        var rMsg = $(this).attr("require-msg");
        if (typeof (rMsg) == 'undefined') {
            rMsg = '';
        }
        var value = $.trim($(this).val());
        if (rtype == "int") {
            if (!(/(^\d+$)/.test(value)) || value < 0) {
                v5.error(rMsg + '：只能输入正整数', '1', 'true');
                result = false;
                $(this).focus();
                return false;
            }
        }
        if (rtype == "decimal") {
            if (!$.isNumeric(value)) {
                v5.error(rMsg + '：只能输入数字', '1', 'true');
                result = false;
                $(this).focus();
                return false;
            }
        }
        if (rtype == "require") {
            if (value == '') {
                v5.error(rMsg + '：不能为空', '1', 'true');
                result = false;
                $(this).focus();
                return false;
            }
        }
    });
    return result;
}


