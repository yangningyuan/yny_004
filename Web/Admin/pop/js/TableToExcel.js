
//导出页面数据
var tableToExcel = (function () {
    var uri = 'data:application/vnd.ms-excel;base64,',
			  template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--><meta http-equiv="content-type" content="text/plain; charset=UTF-8"/></head><body><table>{table}</table></body></html>',
				base64 = function (s) { return window.btoa(unescape(encodeURIComponent(s))) },
				format = function (s, c) {
				    return s.replace(/{(\w+)}/g,
					function (m, p) { return c[p]; })
				}
    return function (table, name) {
        if (!table.nodeType) table = document.getElementById(table)
        var ctx = { worksheet: name || 'Worksheet', table: table.innerHTML }
        window.location.href = uri + base64(format(template, ctx))
    }
})()

function ajax(_url, _data, _callback, _isWaiting, _waitingMsg, _type, _datatype) {
    if (_isWaiting == undefined) { _isWaiting = true; }
    $.ajax({
        type: _type == undefined ? "post" : _type,
        url: _url,
        data: _data,
        dataType: _datatype == undefined ? "json" : _datatype,
        timeout: 30000,
        beforeSend: function (XMLHttpRequest) { if (_isWaiting) { } },
        success: _callback != undefined ? _callback : function (data) { },
        error: function (XMLHttpRequest, textStatus, errorThrown) { },
        complete: function (XMLHttpRequest, textStatus) { if (_isWaiting) { } }
    });
}


//导出数据库数据
function ExportExcel(tUrl, type) {
    tCondition = '';
    tCondition += "&tState=" + tState;
    SearchByKey();
    SearchByType();

    ajax(tUrl + "?type=" + type + tCondition, {}, function (data) {
        if (data != '') {
            location.href = location.origin + '/' + data;
        };
    });
}