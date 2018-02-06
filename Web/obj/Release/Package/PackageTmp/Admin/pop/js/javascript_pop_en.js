var cidList = new Array(); // 选择行数据
var typeList = ""; // 奖金类型
var mKey = ""; // 关键字
var defaultKye = '请输入会员账号,截止日期,开始日期,请输入奖金来源,请输入标题,请输入报单中心,服务名称或编码,订单号,请输入关键内容,请输入发件会员账号,请输入收件会员账号,产品名称或编码,请输入菜单名称,请输入推荐会员账号,会员账号或名称,请输入接点会员账号,请输入流水号';
var tState = ''; // 状态
//var startDate = ''; //时间
//var endDate = ''; //时间
var tUrl = ''; //查询URL
var tCondition = ''; //查询条件
var pageIndex = 0; // 页面索引初始值
var pageSize = 20; // 每页显示条数初始化，修改显示条数，修改这里即可
var count = 0;

/* 选择行数据 */
function SelectChk(obj) {
    var chks = document.getElementsByName("chkGroup");
    cidList.length = 0;
    if (obj.id == 'chkAll') {
        for (var i = 0; i < chks.length; i++) {
            chks[i].checked = obj.checked;
        }
    }
    for (var i = 0; i < chks.length; i++) {
        if (chks[i].checked) {
            cidList[cidList.length] = chks[i].id.split('_')[1];
        }
    }
}
/* 选择行数据 */

/* 查询行数据 */
function SearchByKey() {
    var keys = document.getElementsByName("txtKey");
    if (keys) {
        for (var i = 0; i < keys.length; i++) {
            mKey = $(keys[i]).val();
            if (defaultKye.indexOf(mKey) > -1)
                mKey = "";
            tCondition += "&" + $(keys[i]).attr('id') + "=" + mKey;
        }
    }
}

//按类型查询
function SearchByType() {
    var typechks = document.getElementsByName("chkType");
    if (typechks.length > 0) {
        typeList = '';
        for (var i = 0; i < typechks.length; i++) {
            if (typechks[i].checked)
                typeList += typechks[i].value + "|";
        }
    }
    tCondition += "&typeList=" + typeList;
}

//按状态查询
function SearchByState(state, obj) {
    if (obj) {
        tState = state;
        $(".select a").removeClass("a_on");
        $(".select a").addClass("a_off");
        $(obj).removeClass("a_off");
        $(obj).addClass("a_on");
        tCondition = '';
        tCondition += "&tState=" + tState;
        SearchByKey();
        SearchByType();
        PageLoad();
    }
}

function SearchByCondition() {
    tCondition = '';
    tCondition += "&tState=" + tState;
    SearchByKey();
    SearchByType();
    PageLoad();
}

//关键值，传值，是否验证，用户函数
function RunAjaxGetKey(ajaxKey, keys, v, userfunc) {
    if (v) {
        verifypsd(function () {
            var data = GetAjaxString(ajaxKey, keys);
            if (tUrl != "") {
                PageLoad();
            }
            if (userfunc) {
                userfunc();
            }
            v5.alert(data, '1', 'true');
            setTimeout(function () { v5.clearall(); }, 1000);
        });
    }
    else {
        var data = GetAjaxString(ajaxKey, keys);
        if (userfunc) {
            userfunc();
            v5.alert(data, '1', 'true');
            setTimeout(function () { v5.clearall(); }, 1000);
        }
        else
            return data;
    }
}
var tt = 0;
function PageLoad() {

    if (document.getElementById('chkAll')) {
        document.getElementById('chkAll').checked = false;
        cidList.length = 0;
        count = -1;
    }
    else {
        return;
    }
    if (tUrl == '') {
        //alert('tURL不能为空');
        return;
    } else if (tCondition == '') {
        alert('tCondition不能为空');
        return;
    }

    InitTable(0);

    function page(count) {
        $("#Pagination").pagination(count, {
            callback: PageCallback,
            prev_text: 'Previous ',       //上一页按钮里text
            next_text: 'Next',       //下一页按钮里text
            items_per_page: pageSize,  //显示条数
            num_display_entries: 6,    //连续分页主体部分分页条目数
            current_page: pageIndex,   //当前页索引
            num_edge_entries: 2        //两侧首尾分页条目数
        });
    }

    function PageCallback(index, jq) {
        InitTable(index);
    }

    function InitTable(pageIndex) {
        if (tt > 2)
            return;
        else
            tt++;
        $.ajax({
            type: "POST",
            dataType: "json",
            url: tUrl,      //确认到一般处理程序请求数据
            data: "pageIndex=" + (pageIndex + 1) + "&pageSize=" + pageSize + tCondition,
            success: function (arr) {
                $("#Result tr:gt(0)").remove();
                $("#Result").append(JsonToTable(arr.PageData));
                if (count != arr.TotalCount) {
                    count = arr.TotalCount;
                    page(arr.TotalCount);
                }
            }
        });
        tt = 0;
    }
}
/* 查询行数据 */

/* 对行数据操作 */

function UpDateByID(url, msg, sw, sh) {
    if (cidList.length > 0) {
        v5.show(url + '&id=' + cidList[0], msg, 'url', sw, sh);
    } else {
        v5.alert('请先选择行数据', '1', 'true');
    }
}
function UpDateByTaskID(url, msg, sw, sh) {
    if (cidList.length > 0) {
        v5.show(url + '&id=' + cidList[0], msg, 'url', sw, sh);
    } else {
        v5.show(url, msg, 'url', sw, sh);
    }
}

function UpDateByIDS(url, msg, sw, sh) {
    if (cidList.length > 0) {
        v5.show(url + '&id=' + cidList.join(','), msg, 'url', sw, sh);
    } else {
        v5.alert('请先选择行数据', '1', 'true');
    }
}

function RunAjaxByList(state, ajaxKey, joinKey) {
    if (cidList.length > 0) {
        if (state != '' && tState != state) {
            v5.error('操作无效', '1', 'true');
            return;
        }
        verifypsd(function () {
            var data = RunAjaxGetKey(ajaxKey, cidList.join(joinKey));
            PageLoad();
            v5.alert(data, '1', 'true');
        });
    } else {
        v5.alert('请先选择行数据', '1', 'true');
    }
}
/* 对行数据操作 */

//对对象的操作，新增，修改
function ActionModel(acturl, actdata, url) {
    //document.write(actdata);
    verifypsd(function () {
        $.ajax({
            type: 'post',
            url: acturl,
            data: actdata,
            success: function (info) {
                v5.alert(info, '1', 'true');
                setTimeout(function () { v5.clearall(); }, 1000);
                if (url) {
                    callhtml(url);
                } else {
                    PageLoad();
                }
            }
        });
    });
}


function ActionModelNoVer(acturl, actdata) {
    $.ajax({
        type: 'post',
        url: acturl,
        data: actdata,
        success: function (info) {
            v5.alert(info, '1', 'true');
            setTimeout(function () { v5.clearall(); }, 1000);
        }
    });
}
function ActionModelBack(acturl, actdata, url, fun) {
    verifypsd(function () {
        $.ajax({
            type: 'post',
            url: acturl,
            data: actdata,
            success: function (info) {
                v5.alert(info, '2', 'true');
                setTimeout(function () {
                    v5.clearall();
                    callhtml(url);
                }, 2000);
                PageLoad();
            }
        });
    }, fun);
}

function ActionModelBackWithTitle(acturl, actdata, url, fun, urlTitle) {
    verifypsd(function () {
        $.ajax({
            type: 'post',
            url: acturl,
            data: actdata,
            success: function (info) {
                v5.alert(info, '2', 'true');
                setTimeout(function () {
                    v5.clearall();
                    callhtml(url, urlTitle);
                }, 2000);
                PageLoad();
            }
        });
    }, fun);
}
//不带验证
function ActionModelBackWithTitleWithNoVerify(acturl, actdata, url, fun, urlTitle) {
        $.ajax({
            type: 'post',
            url: acturl,
            data: actdata,
            success: function (info) {
                v5.alert(info, '1', 'true');
                setTimeout(function () {
                    v5.clearall();
                    callhtml(url, urlTitle);
                }, 1000);
                PageLoad();
            }
        });
}

//资金密码验证
//update by zhuxy at 2015-5-14：修改弹出资金密码，不要弹出来的，直接跳转到一个页面 ，这里不能使用页面，所以用了一个层
//*********************************begin*********************************************
function verifypsd(callfuc) {
    //    v5.prompt('请输入资金密码',
    //    function (str) {
    //        if (GetAjaxString('Verify', str) == "pass") {
    //            callfuc();
    //        } else {
    //            v5.error('资金密码错误', '1', 'true');
    //        }
    //    }
    //    , 'password'
    //            , 'true');
    $("#finance").css("display", "none");
    $("#container").append("<div id='enterVerifypsdDiv'></div>");
    $("#enterVerifypsdDiv").append("<div class='enterVerifypsdInnerDiv'>Please enter two password：<input id='txtVerifypsd' class='normal_input' type='password' /></div>");
    $("#enterVerifypsdDiv").append("<div  class='enterVerifypsdInnerDiv' style='margin-left:38%'><input class='btn btn-primary rounded-none'  id='enterVerifypsdInnerBtn' type='button' value='Confirm'  /> &emsp; <input class='btn btn-inverse' id='btnOK' type='button' value='Cancle' onclick='cancleCheckVerifypsd();' /></div>");

    $("#txtVerifypsd").focus();

    $("#enterVerifypsdInnerBtn").click(function () {
        if ($('#txtVerifypsd').val().Trim() == '') {
            v5.error('Two level password can not be empty', '1', 'true');
        } else {
            if (GetAjaxString('Verify', $('#txtVerifypsd').val().Trim()) == "pass") {
                callfuc();
                cancleCheckVerifypsd();
            }
            else {
                v5.alert('Two password error', 1, 'true');
            }
        }
    });
}

function cancleCheckVerifypsd() {
    $("#finance").css("display", "");
    $("#enterVerifypsdDiv").remove();
}
//*********************************end*********************************************

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
// 邮箱验证
String.prototype.TryEmail = function () {
    var patrn = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
    return patrn.test(this);
}
// 手机号码验证
String.prototype.TryTel = function () {
    var patrn = /^(13+\d{9})|(15+\d{9})|(18+\d{9})$/;
    return patrn.test(this);
}
// 带小数的金额验证
String.prototype.TryMoney = function () {
    var patrn = /^[0-9]+(.[0-9]{2})?$/;
    return patrn.test(this);
}
//得到当前日期
function GetNowDate() {
    var d = new Date();
    return d.getFullYear() + "-" + appendZero(d.getMonth() + 1) + "-" + appendZero(d.getDate());
}
function appendZero(s) {
    return ("00" + s).substr((s + "").length);
} //补0函数


function sendCode(obj) {
    if ($('#txtTel').val().Trim() == "") {
        v5.error('手机号码不能为空', '1', 'true');
    } else if (!$('#txtTel').val().TryTel()) {
        v5.error('手机号码格式不正确', '1', 'true');
    } else {
        $(obj).val("发送中...");
        $(obj).attr("disabled", "disabled");
        $("#txtTel").attr("readonly", "readonly");
        var sendstate = RunAjaxGetKey("SendCode", $("#txtTel").val().Trim());
        setTimeout(function () { alert(sendstate); $(obj).val(sendstate); }, 500);
    }
}
function sendCode2(obj) {
    if ($('#txtEmail').val().Trim() == "") {
        v5.error('邮箱不能为空', '1', 'true');
    } else if (!$('#txtEmail').val().TryEmail()) {
        v5.error('邮箱格式不正确', '1', 'true');
    } else {
        $(obj).val("发送中...");
        $(obj).attr("disabled", "disabled");
        $("#txtEmail").attr("readonly", "readonly");
        var sendstate = RunAjaxGetKey("sendCode2", $("#txtEmail").val().Trim());
        setTimeout(function () { alert(sendstate); $(obj).val(sendstate); }, 500);
    }
}

//table转josn
function TableToJson(tableid) {
    var txt = "[";
    var table = document.getElementById(tableid);
    var row = table.getElementsByTagName("tr");
    var col = row[0].getElementsByTagName("th");
    for (var j = 1; j < row.length; j++) {
        var r = "{";
        var tds = row[j].getElementsByTagName("td");
        for (var i = 0; i < col.length; i++) {
            r += "\"" + col[i].innerHTML + "\"\:\"" + tds[i].getElementsByTagName("input")[0].value + "\",";
        }
        r = r.substring(0, r.length - 1)
        r += "},";
        txt += r;
    }
    txt = txt.substring(0, txt.length - 1);
    txt += "]";
    return txt;
}


function JsonToTable(str) {
    var trs = str.split('≌');
    var table = '';
    for (var i = 0; i < trs.length - 1; i++) {
        table += '<tr><td>';
        var tds = trs[i].split('~');
        if (tds[0] != '') {
            if (trs[i].indexOf('#T') > 0) {
                table += "<em><input type='checkbox' id='chk_" + tds[0] + "' checked='checked' name='chkGroup' onclick='SelectChk(this);'/></em>";
            }
            else
                table += "<em><input type='checkbox' id='chk_" + tds[0] + "' name='chkGroup' onclick='SelectChk(this);'/></em>";
        }
        for (var j = 1; j < tds.length; j++) {
            table += "</td><td>";
            table += tds[j].replace('#T', '') + '&nbsp;';
        }
        table += "</td></tr>";
    }
    return table;
}

//网络图
function GetAjaxInfo(mkey) {
    $('#txtMid').val(mkey);
    level = $("#txtLevel").val();
    color = $("input[name='rdoColor']:checked").val();
    if (defalutinfo.indexOf(mkey) > -1)
        mkey = "";
    if (defalutinfo.indexOf(level) > -1 || !level)
        level = 3;
    $.ajax({
        type: "POST",
        dataType: "text",
        url: '/Handler/Structure.ashx',      //确认到一般处理程序请求数据
        data: "mkey=" + mkey + "&level=" + level + "&color=" + color,    //确认两个参数：mid(根会员账号)，level(显示层数)                
        success: function (data) {
            $("#chart").html("");
            if (data != '') {
                $("#org").html(data);
                SetOrg();
            }
        }
    });
}

//网络图
function GetAjaxInfoB(mkey) {
    $('#txtMid').val(mkey);
    level = $("#txtLevel").val();
    color = $("input[name='rdoColor']:checked").val();
    if (defalutinfo.indexOf(mkey) > -1)
        mkey = "";
    if (defalutinfo.indexOf(level) > -1 || !level)
        level = 3;
    $.ajax({
        type: "POST",
        dataType: "text",
        url: '/Handler/StructureB.ashx',      //确认到一般处理程序请求数据
        data: "mkey=" + mkey + "&level=" + level + "&color=" + color,    //确认两个参数：mid(根会员账号)，level(显示层数)                
        success: function (data) {
            $("#chart").html("");
            if (data != '') {
                $("#org").html(data);
                SetOrg();
            }
        }
    });
}

function GetAjaxTJInfo(mkey) {
    $('#txtMid').val(mkey);
    if ($("#txtLevel").val())
        level = $("#txtLevel").val();
    else
        level = 2;
    if (defalutinfo.indexOf(mkey) > -1)
        mkey = "";
    if (defalutinfo.indexOf(level) > -1)
        level = 2;
    $.ajax({
        type: "POST",
        dataType: "text",
        url: '/Handler/TJNet.ashx',      //确认到一般处理程序请求数据
        data: "mkey=" + mkey + "&level=" + level,    //确认两个参数：mid(根会员账号)，level(显示层数)                
        success: function (data) {
            $("#chart").html("");
            if (data != '') {
                $("#org").html(data);
                SetOrg();
            }
        }
    });
}

function SetOrg() {
    $("#org").jOrgChart({
        chartElement: '#chart',
        dragAndDrop: false
    });
}
//上传图片
var UEUploadImge = function () {
    var inputBox;
    var imgEditor = new UE.ui.Editor();
    imgEditor.render("imgEditor");
    imgEditor.ready(function () {
        imgEditor.setDisabled();
        imgEditor.hide();
        imgEditor.addListener('beforeInsertImage', function (t, args) {
            inputBox.val(args[0].src);
        });
    });
    this.uploadImage = function (o) {
        inputBox = $(o);
        var dlg = imgEditor.getDialog("insertimage");
        dlg.render();
        dlg.open();
    }
}
function uploadImage(obj) {
    var ue = new UEUploadImge();
    ue.uploadImage(obj);
}
function ChangeTitle(jjtitlelist, tables, lasttitle, role) {
    var jjtypes = jjtitlelist.split('|');
    var title = '<tr><th width="50px">All</th><th>Serial number</th>';
    //if (role == 'TRUE')
    title = title + '<th>Membership number </th><th>Investment matching</th>';
    for (var i = 0; i < jjtypes.length - 1; i++) {
        title += '<th>' + jjtypes[i] + '</th>';
    }
    title += '<th>Total assets</th><th>Net assets</th>';
    if (lasttitle && lasttitle != '')
        title += '<th>' + lasttitle + '</th>'; ;
    lasttitle += '</tr>';
    tables.html(title);
}

/**
* 时间对象的格式化;
*/
Date.prototype.format = function (format) {
    /*
    * eg:format="YYYY-MM-dd hh:mm:ss";
    */
    var o = {
        "M+": this.getMonth() + 1, // month
        "d+": this.getDate(), // day
        "h+": this.getHours(), // hour
        "m+": this.getMinutes(), // minute
        "s+": this.getSeconds(), // second
        "q+": Math.floor((this.getMonth() + 3) / 3), // quarter
        "S": this.getMilliseconds()
        // millisecond
    }
    if (/(y+)/.test(format)) {
        format = format.replace(RegExp.$1, (this.getFullYear() + "")
                .substr(4 - RegExp.$1.length));
    }
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(format)) {
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k]
                    : ("00" + o[k]).substr(("" + o[k]).length));
        }
    }
    return format;
}