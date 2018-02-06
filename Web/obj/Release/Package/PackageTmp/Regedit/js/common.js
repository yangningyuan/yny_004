
/**
新项目公共JS类

修改：
    1.李晓林 [2015-03-24]  新增flashChecker检测浏览器是否安装了flash
    2.李晓林 [2015-03-28]  新增时间格式话函数
    3.

*/
var Comm = {
    onloading: function (msg) {
        $("<div class=\"datagrid-mask\"></div>").css({ display: "block", width: "100%", height: $(window).height() }).appendTo("body");
        $("<div class=\"datagrid-mask-msg\"></div>").html(msg).appendTo("body").css({ display: "block", left: ($(document.body).outerWidth(true) - 190) / 2, top: ($(window).height() - 45) / 2 });
    },
    removeload: function () {
        $(".datagrid-mask").remove();
        $(".datagrid-mask-msg").remove();
    },
    /**格式化时间戳的时间格式yyyy-MM-dd HH:mm:ss
    @timestamp：时间戳
    @fmt：格式yyyy-MM-dd
    */
    formattime: function (timestamp, fmt) {
        if (timestamp == null || timestamp == undefined || timestamp == '') {
            return "";
        }
        var date = new Date(parseInt(timestamp.replace("/Date(", "").replace(")/", ""), 10));
        var o = {
            "M+": date.getMonth() + 1, //月份 
            "d+": date.getDate(), //日 
            "h+": date.getHours(), //小时 
            "H+": date.getHours(), //小时 
            "m+": date.getMinutes(), //分 
            "s+": date.getSeconds(), //秒 
            "q+": Math.floor((date.getMonth() + 3) / 3), //季度 
            "S": date.getMilliseconds() //毫秒 
        };
        if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (date.getFullYear() + "").substr(4 - RegExp.$1.length));
        for (var k in o)
            if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
        return fmt;
    },
    /**@检测浏览器是否安装了flash插件*/
    flashChecker: function () {
        /*0-未安装,1-已安装*/
        var hasFlash = 0;
        /*flash版本*/
        var flashVersion = 0;
        if (document.all) {
            var swf = new ActiveXObject('ShockwaveFlash.ShockwaveFlash');
            if (swf) {
                hasFlash = 1;
                VSwf = swf.GetVariable("$version");
                flashVersion = parseInt(VSwf.split(" ")[1].split(",")[0]);
            }
        } else {
            if (navigator.plugins && navigator.plugins.length > 0) {
                var swf = navigator.plugins["Shockwave Flash"];
                if (swf) {
                    hasFlash = 1;
                    var words = swf.description.split(" ");
                    for (var i = 0; i < words.length; ++i) {
                        if (isNaN(parseInt(words[i]))) continue;
                        flashVersion = parseInt(words[i]);
                    }
                }
            }
        }
        return {
            f: hasFlash,
            v: flashVersion
        };
    },
    /**@s:传入的float数字@n:希望返回小数点几位*/
    formatMoney: function (s, n) {
        n = n > 0 && n <= 20 ? n : 2;
        s = parseFloat((s + "").replace(/[^\d\.-]/g, "")).toFixed(n) + "";
        var l = s.split(".")[0].split("").reverse(),
        r = s.split(".")[1];
        t = "";
        for (i = 0; i < l.length; i++) {
            t += l[i] + ((i + 1) % 3 == 0 && (i + 1) != l.length ? "," : "");
        }
        return t.split("").reverse().join("") + "." + r;
    }
}