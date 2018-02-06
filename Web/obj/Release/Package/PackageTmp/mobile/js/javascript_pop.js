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
var cur_pageIndex = 0; //当前页

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
        $(".select a").removeClass("btn btn-danger");
        $(".select a").addClass("btn btn-success");
        $(obj).removeClass("btn btn-success");
        $(obj).addClass("btn btn-danger");
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
            layer.msg(data);
            setTimeout(function () { v5.clearall(); }, 1000);
        });
    }
    else {
        var data = GetAjaxString(ajaxKey, keys);
        if (userfunc) {
            userfunc();
            layer.msg(data);
            setTimeout(function () { v5.clearall(); }, 1000);
        }
        else
            return data;
    }
}




//关键值，传值，是否验证，用户函数
function RunAjaxGetKey(ajaxKey, keys, v, userfunc, _url) {
    if (v) {
        verifypsd(function () {
            var data = GetAjaxString(ajaxKey, keys, _url);
            if (tUrl != "") {
                PageLoad();
            }
            if (userfunc) {
                userfunc();
            }
            v5.alert(data, '1', 'true');
            setTimeout(function () {
                v5.clearall();
            }, 1000);
        });
    } else {
        var data = GetAjaxString(ajaxKey, keys, _url);
        if (userfunc) {
            userfunc();
            v5.alert(data, '1', 'true');
            setTimeout(function () {
                v5.clearall();
            }, 1000);
        } else
            return data;
    }
}



var tt = 0;
var PageLoad = function () {

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

    InitTable(cur_pageIndex); //0刷新为首页,cur_pageIndex刷新为当前页

    function page(count) {
        $("#Pagination").pagination(count, {
            callback: PageCallback,
            prev_text: '上一页', //上一页按钮里text
            next_text: '下一页', //下一页按钮里text
            items_per_page: pageSize, //显示条数
            num_display_entries: 6, //连续分页主体部分分页条目数
            current_page: cur_pageIndex, //当前页索引     pageIndex刷新为首页,cur_pageIndex刷新为当前页
            num_edge_entries: 2, //两侧首尾分页条目数
            jump_text: '转到', //跳转按钮里text
            isSum: true, //是否显示总数
            isJump: true, //是否显示跳转
            first_text: '首页', //跳转按钮里text
            last_text: '末页', //跳转按钮里text
            isFirst: true //是否显示总数
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
        //        StackPush(url + '&id=' + cidList[0], msg);
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

//选中行带参数跳转到下个页面
function OfferPutScramble(id) {
    if (id) {
        var result = GetAjaxString('OfferPutScramble', id);
        v5.alert(result, '1', 'true');
        setTimeout(function () { v5.clearall(); PageLoad(); }, 1000);
    }
    else {
        if (cidList.length > 0) {
            var result = GetAjaxString('OfferPutScramble', cidList.join(',').toString());
            v5.alert(result, '1', 'true');
            setTimeout(function () { v5.clearall(); PageLoad(); }, 1000);
        } else {
            v5.alert('请先选择行数据', '1', 'true');
        }
    }
}

//选中行带参数跳转到下个页面
function OfferScramble(id) {
    var result = GetAjaxString('OfferScramble', id);
    v5.alert(result, '1', 'true');
    setTimeout(function () { v5.clearall(); PageLoad(); }, 1000);
}

//选中行带参数跳转到下个页面
function MatchOtherPage(url, title) {
    if (cidList.length > 0) {
        callhtml(url + '?id=' + cidList.join(',').toString(), title);
    } else {
        v5.alert('请先选择行数据', '1', 'true');
    }
}

//选中行带参数跳转到下个页面
function MatchOtherPageOffSure(getid) {
    if (cidList.length > 0) {
        var result = GetAjaxString('HandmatchHelp', cidList.join(',').toString() + "|" + getid);
        v5.alert(result, '1', 'true');
        setTimeout(function () { v5.clearall(); PageLoad(); }, 1000);
    } else {
        v5.alert('请先选择行数据', '1', 'true');
    }
}

//选中行带参数跳转到下个页面
function MatchOtherPageGetSure(offid) {
    if (cidList.length > 0) {
        var result = GetAjaxString('HandmatchHelp', offid + "|" + cidList.join(',').toString());
        v5.alert(result, '1', 'true');
        setTimeout(function () { v5.clearall(); PageLoad(); }, 1000);
    } else {
        v5.alert('请先选择行数据', '1', 'true');
    }
}

function costMHB(str) {
    verifypsd(function () {
        var data = RunAjaxGetKey('costMHB', cidList.join(',') + "&money=" + str);
        PageLoad();
        v5.alert(data, '1', 'true');
    });
}

function RunAjaxToCostMHBByList(state, ajaxKey, joinKey) {
    if (cidList.length > 0) {
        v5.prompt("请输入金额：正数为充值;负数为扣费！", costMHB, "text", true);
    } else {
        v5.alert('请先选择行数据', '1', 'true');
    }
}


function RunAjaxByList11(state, ajaxKey, keys) {
    verifypsd(function () {
        var data = RunAjaxGetKey(ajaxKey, keys);
        PageLoad();
        v5.alert(data, '1', 'true');
    });
}
/* 对行数据操作 */

//对对象的操作，新增，修改
function ActionModel(acturl, actdata, url) {
    //document.write(actdata);
    appverifypsd(function () {
        $.ajax({
            type: 'post',
            url: acturl,
            data: actdata,
            success: function (info) {
                if (info == "1" || info == "1*0") {
                    layer.msg("操作成功");
                } else {
                    layer.msg(info);
                }
                if (url) {
                    pcallhtml(url, "常青树");
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
            if (info == "操作成功") {
                var dizi = "../Message/TaskList.aspx?r=0.17982682021400853", title = "留言记录";
                setTimeout(function () { $("#mainbody").load(dizi, function () { changetabcolor(title); }); }, 10);
            }
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

function appverifypsd(callfuc) {
    layer.prompt({ title: '输入资金密码，并确认', formType: 1 }, function (pass, index) {
        if (GetAjaxString('Verify', pass) == "pass") {
            layer.close(index);
            callfuc();
        } else {
            layer.msg('资金密码错误');
        }
    });
}



function verifypsd(callfuc) {
    v5.prompt('请输入资金密码',
        function (str) {
            if (GetAjaxString('Verify', str) == "pass") {
                callfuc();
            } else {
                v5.error('资金密码错误', '1', 'true');
            }
        }, 'password', 'true');
}

function cancleCheckVerifypsd() {
    $("#finance").css("display", "");
    $("#enterVerifypsdDiv").remove();
}

//*********************************end*********************************************

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
        if (trs[i][0] == "@") {//隐藏列
            var tds = trs[i].split('@');
            table += '<tr style="display:none"><td colspan="' + tds[1] + '">' + tds[2] + '</td></tr>';
        }
        else {
            var tds = trs[i].split('~');
            if (tds[0] != '') {
                if (trs[i].indexOf('#T') > 0) {
                    table += "<tr><td><em><input type='checkbox' id='chk_" + tds[0] + "' checked='checked' name='chkGroup' onclick='SelectChk(this);'/></em>";
                }
                else
                    table += "<tr><td><em><input type='checkbox' id='chk_" + tds[0] + "' name='chkGroup' onclick='SelectChk(this);'/></em>";
            }
            else {
                table += "<tr><td>";
            }
            for (var j = 1; j < tds.length; j++) {
                table += "</td><td>";
                table += tds[j].replace('#T', '') + '&nbsp;';
            }
            table += "</td></tr>";
        }
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

//function GetAjaxTJInfo(mkey) {
//    $('#txtMid').val(mkey);
//    if ($("#txtLevel").val())
//        level = $("#txtLevel").val();
//    else
//        level = 2;
//    if (defalutinfo.indexOf(mkey) > -1)
//        mkey = "";
//    if (defalutinfo.indexOf(level) > -1)
//        level = 2;
//    $.ajax({
//        type: "POST",
//        dataType: "text",
//        url: '/Handler/TJNet.ashx',      //确认到一般处理程序请求数据
//        data: "mkey=" + mkey + "&level=" + level,    //确认两个参数：mid(根会员账号)，level(显示层数)                
//        success: function (data) {
//            $("#chart").html("");
//            if (data != '') {
//                $("#org").html(data);
//                SetOrg();
//            }
//        }
//    });
//}

//网络图
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
        dataType: "json",
        url: '/Handler/TJNet.ashx',      //确认到一般处理程序请求数据
        data: "mkey=" + mkey + "&level=" + level,    //确认两个参数：mid(根会员账号)，level(显示层数)                
        success: function (data) {
            $("#treeDemo").html("");
            if (data.data != '') {
                LoadZtree(data.data);
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
    var title = '<tr><th width="80px">全选</th><th>序号</th>';
    //if (role == 'TRUE')
    title = title + '<th>会员账号</th><th>会员级别</th>';
    for (var i = 0; i < jjtypes.length - 1; i++) {
        title += '<th>' + jjtypes[i] + '</th>';
    }
    title += '<th>总计奖金</th>';
    if (lasttitle && lasttitle != '')
        title += '<th>' + lasttitle + '</th>';
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

//tr点击事件
function trClick(obj) {
    if ($("#distr").length > 0) {
        var next = $(obj).next();
        if (next.is(":hidden")) {
            next.show();
        }
        else {
            next.hide();
        }
    }
}

function QDJ() {
    verifypsd(function () {
        var data = GetAjaxString("QDJ", "");
        v5.alert(data, '1', 'true');
        setTimeout(function () {
            v5.clearall();
            window.location.reload();
        }, 1000);
    });
}



function RunAjaxByListAddKeyShop(state, ajaxKey, joinKey, otherParam,cidList) {
    if (ajaxKey != "DeleteMemberW") {
        if (state != '' && tState != state) {
            layer.msg('操作无效');
            return;
        }
    }
    var data = RunAjaxGetKey(ajaxKey, cidList + "&otherParm=" + otherParam, null, null, '/Shop/Handler/Ajax.ashx');
    PageLoad();
    layer.msg(data);
}