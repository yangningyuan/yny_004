
function filter(treeId, parentNode, responseData) {
    if (!responseData) return null;
    for (var i = 0, l = responseData.length; i < l; i++) {
        responseData[i].name = responseData[i].name.replace(/\.n/g, '.');
    }
    return responseData;
}

function onClick(e, treeId, treeNode) {
    var zTree = $.fn.zTree.getZTreeObj("treeDemo");
    zTree.expandNode(treeNode);
}

function GetSetting(smid) {
    var setting = {
        view: {
            dblClickExpand: true,
            showLine: false,
            nameIsHTML: true
        },
        data: {
            simpleData: {
                enable: true
            }
        },
        //        callback: {
        //            onClick: onClick,
        //            beforeAsync: zTreeBeforeAsync
        //        },
        async: {
            enable: true,
            url: "Member/Handler/TJTree.ashx",
            autoParam: ["id"],
            dataType: "json",
            type: "post",
            cache: false,
            otherParam: ["serachId", smid],
            dataFilter: filter
        }
    };
    return setting;
}

function LoadZtree(smid) {
    if (smid == "请输入会员账号") {
        smid = "";
    }
    $("#treeDemo").html("");
    $.fn.zTree.init($("#treeDemo"), GetSetting(smid));
}