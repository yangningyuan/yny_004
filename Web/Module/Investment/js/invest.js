
///单个
function InvestOperate(ajaxKey, id, func) {
    verifypsd(function () {
        var data = RunAjaxGetKey(ajaxKey, id, null, null, 'Module/Investment/Handler/Ajax.ashx');
        PageLoad();
        v5.alert(data, '1', 'true', func);
    });
}

///批量
function RunAjaxByListInvest(ajaxKey, joinKey, func) {
    if (cidList.length > 0) {
        verifypsd(function () {
            var data = RunAjaxGetKey(ajaxKey, cidList.join(joinKey), null, null, 'Module/Investment/Handler/Ajax.ashx');
            PageLoad();
            v5.alert(data, '1', 'true', func);
        });
    } else {
        v5.alert('请先选择行数据', '1', 'true');
    }
}