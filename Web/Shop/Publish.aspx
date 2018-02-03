<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Publish.aspx.cs" Inherits="yny_004.Web.Shop.Publish" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .appImg
        {
            margin-left: 15px;
            margin-top: 10px;
        }
        .xClose
        {
            cursor: pointer;
        }
        .appDiv
        {
            display: inline-table;
        }
        .xMain
        {
            cursor: pointer;
        }
        .mainDiv
        {
            border-color: rgb(34, 177, 36);
            border-style: solid;
            border-width: 3px;
        }
        .AppTB tr
        {
            height: 30px;
        }
        .AppTB a, #TBSrcAtt a, #TBSqlAtt a
        {
            color: Blue;
        }
        .AttDiv
        {
            left: 44%; /*FF IE7*/
            top: 30%; /*FF IE7*/
            z-index: 1002;
            outline: 0px none;
            height: auto;
            width: 460px;
            margin-left: -150px !important; /*FF IE7 该值为本身宽的一半 */
            margin-top: -60px !important; /*FF IE7 该值为本身高的一半*/
            margin-top: 0px;
            position: fixed !important; /*FF IE7*/
            position: absolute; /*IE6*/
            background-color: rgb(37, 247, 191);
        }
        .ui-dialog-titlebar-close
        {
            float: right;
        }
        .AttBg
        {
            background-color: #FDFDFD;
            width: 100%;
            height: 100%;
            left: 0;
            top: 0; /*FF IE7*/
            filter: alpha(opacity=50); /*IE*/
            opacity: 0.5; /*FF*/
            z-index: 1;
            position: fixed !important; /*FF IE7*/
            position: absolute; /*IE6*/
        }
        .cancel
        {
            width: 100%;
        }
        .spRed
        {
            color: Red;
        }
    </style>
    <%--<link href="../Common/uploadify/uploadify.css" rel="stylesheet" type="text/css" />
    <script src="../Common/uploadify/jquery.uploadify.js" type="text/javascript"></script>--%>
</head>
<body>

    <div id="mempay">
        <div id="finance">
            <form id="form1" method="post" action="../Admin/UpLoadPic/IbeaconHandler.ashx" target='frameFile'
            enctype="multipart/form-data">
            <input type="hidden" id="hidDelIds" runat="server" />
            <input type="hidden" id="hidMainPic" runat="server" />
            <input type="hidden" id="hidId" runat="server" />
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="8%" align="right">
                        商品分类:
                    </td>
                    <td width="35%">
                        <select id="ddlCategory" runat="server">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td width="8%" align="right">
                        商品名称:
                    </td>
                    <td width="35%">
                        <input id="txtName" runat="server" class="normal_input" type="text" require-type="require"
                            style="width: 50%" require-msg="商品名称" />
                        <span class="spRed">*</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        价格
                    </td>
                    <td>
                        <input id="txtPrice" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="价格" />
                        <span class="spRed">*</span> &emsp;单位：<input id="txtUnit" runat="server" class="normal_input"
                            type="text" style="width: 50px" require-type="require" require-msg="单位" />
                        <span class="spRed">*</span> &emsp; 库存:
                        <input id="txtStock" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="库存" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        商品描述:
                    </td>
                    <td>
                        <textarea  placeholder="上传图片时，请上传相同尺寸的图片。" id="txtRemark" runat="server" style="width: 60%; height: 80px"></textarea>&emsp;
                        <input type="button" class="btn btn-success btn-sm" value="上传图片" onclick="UpLoadPic()" />
                        <input type='file' id='fileUp' name='fileUp' onchange="changeform();" style="display: none" />
                        <div id='uploadLog'>
                        </div>
                        <input type="hidden" id="hduploadPic1" runat="server" name="hduploadPic1" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        图标说明:
                    </td>
                    <td>
                        <img class="xClose" title="删除" src="../images/uploadify-cancel.png" />删除图片;&emsp;
                        <img class="xMain " title="首页图片" src="../images/home_main.png" />列表显示主图片
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        <div style="float: left" id="tablePic">
                            <asp:Repeater ID="rep_PicList" runat="server">
                                <ItemTemplate>
                                    <div class="appDiv <%#Eval("IsMain").ToString()=="True"?"mainDiv":"" %>">
                                        <img class="appImg" src="<%#Eval("PicURL") %>" />
                                        <img class="xClose" onclick="deletePic(this)" title="删除" src="../images/uploadify-cancel.png" />
                                        <img class="xMain " onclick="setMain(this)" title="首页图片" src="../images/home_main.png" />
                                        <input type="hidden" name="uploadPic" class="hidPicurl" value="<%#Eval("PicURL") %>" />
                                        <input type="hidden" class='hidId' value="<%#Eval("Id") %>" />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td style="text-align: right;">
                    </td>
                    <td align="left">
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            <%--<div id="AttBg" class="AttBg" style="display: none; margin-top: 1%;">
            </div>
            <div id="AttDiv" class="ui-dialog ui-widget ui-widget-content ui-corner-all AttDiv"
                style="display: none;">
                <div class="ui-dialog-titlebar ui-widget-header ui-helper-clearfix" style="width: 100;
                    height: 50;">
                    <span class="ui-dialog-title" id="ui-dialog-title-alertDialog" style="visibility: visible;
                        -moz-user-select: none;">上传附件</span> <a href="javascript:void(0);" id="spForClose"
                            class="ui-dialog-titlebar-close ui-corner-all closeUpload"></a>
                </div>
                <div class="ui-dialog-content ui-widget-content" id="flash_uploader" style="max-height: 300px;
                    overflow-y: auto">
                    <input type="file" name="uploadify" id="uploadify" />
                    <div id="fileQueue2">
                    </div>
                </div>
                <div class="ui-dialog-buttonpane ui-widget-content ui-helper-clearfix" style="padding: 0.3em 1em 0.5em;
                    margin-top: 45px">
                    <button type="button" id="btnSaveAtts" class="btn btn-success btn-sm" onclick="saveatts()">
                        上传</button>
                    &nbsp;&nbsp;
                    <button type="button" id="btnCloseAtts" class="btn btn-sm">
                        关闭</button>
                </div>
            </div>--%>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            //            loadUploadify();
            //            //关闭上传附件窗口
            //            $("#btnCloseAtts").click(function () {
            //                $("#AttBg").hide();
            //                $("#AttDiv").hide();
            //            });
            //            $("#spForClose").click(function () {
            //                $("#AttBg").hide();
            //                $("#AttDiv").hide();
            //            });
        });
        function loadUploadify() {
            var list = "fileQueue2";
            $("#uploadify").uploadify({
                'swf': '../Common/uploadify/uploadify.swf',
                'uploader': '../Common/UploadExcel.ashx', //相对路径的后端脚本，它将处理您上传的文件。绝对路径前缀或'/'或'http'的路径
                'folder': '../Attachment/',
                'cancelImg': '../Common/uploadify/uploadify-cancel.png',
                'script': 'UploadExcel.ashx',
                'queueID': list,
                'auto': false,
                'multi': true,
                'fileTypeDesc': '图像文件', //出现在上传对话框中的文件类型描述
                'fileTypeExts': '*.jpg;*.bmp;*.jpeg;*.gif;*.png',  //控制可上传文件的扩展名，启用本项时需同时声明fileDesc
                'buttonText': '选择文件',
                'onUploadSuccess': function (file, data, response) {
                    var count = $(".appImg").length;
                    var appendHtml = "<div class='appDiv'><img class='appImg' src='../../Attachment/" + data + "'/><img class='xClose' onclick='deletePic(this)'  title='删除' src='../images/uploadify-cancel.png'/><img class='xMain' onclick='setMain(this)'  title='首页展示' src='../images/home_main.png'/><input type='hidden' name='uploadPic' class='hidPicurl' value='" + data + "'/></div>";
                    $("#tablePic").append(appendHtml);
                },
                'onAllComplete': function (event, data) {
                    alert("111");
                    $("#AttBg").hide();
                    $("#AttDiv").hide();
                }
            });
        }
        function showUpload() {
            var attsType = $(this).attr("AttsType");
            $("#btnSaveAtts").attr("AttsType", attsType);
            $("#AttBg").show();
            $("#AttDiv").show();
            return false;
        }
        function deletePic(obj) {
            if (confirm("确定要删除吗？")) {
                var fileName = $(obj).parent().find(".hidPicurl").val();
                var hidId = $(obj).parent().find(".hidId").val();
                var hidDelIds = $("#hidDelIds").val();
                if (typeof (fileName) != "undefined" && fileName != "") {
                    $.ajax({
                        type: "Post",
                        url: "../Common/DeleteUPFile.ashx?path=" + fileName,
                        success: function (data) {
                            if (typeof (hidId) != "undefined" && hidId != "") {
                                hidDelIds += hidId + ",";
                                $("#hidDelIds").val(hidDelIds);
                            }
                            //如果是把首页图片删除了，就要重新设定首页图片
                            if ($(obj).parent().hasClass("mainDiv")) {
                                $(obj).parent().remove();
                                $(".appDiv").first().addClass("mainDiv");
                                //给首页图片的隐藏控件重新赋值
                                $("#hidMainPic").val($(".appDiv").first().find(".hidPicurl").val());
                            }
                            else {
                                $(obj).parent().remove();
                            }
                        },
                        error: function (err) {
                            alert(err);
                        }
                    });
                }
            }
        }
        function saveatts() {
            jQuery('#uploadify').uploadify('upload', '*');
        }
        function setMain(obj) {
            $(".appDiv").removeClass("mainDiv");
            $(obj).parent().addClass("mainDiv");
            $("#hidMainPic").val($(obj).parent().find(".hidPicurl").val());
        }
        function checkChange() {
            if (checkForm()) {
                if ($("#ddlCategory").val() == "") {
                    v5.alert("请选择商品分类", '1', 'true');
                }
                ActionModel("/Shop/Publish.aspx?Action=Modify", $('#form1').serialize());
            }
        }

        function UpLoadPic() {
            $("#fileUp").click();
        }
        function changeform() {
            $("#uploadLog").html("上传中...");
            $('#form1').submit();
        }

        function uploadSuccess(msg) {
            if (msg.split('|').length > 1) {//成功
                $("#uploadLog").html("上传成功...");
                $('#hduploadPic1').val(msg.split('|')[1]);
                var appendHtml = "<div class='appDiv'><img class='appImg' src='" + msg.split('|')[1] + "'/><img class='xClose' onclick='deletePic(this)'  title='删除' src='/images/uploadify-cancel.png'/><img class='xMain' onclick='setMain(this)'  title='首页展示' src='/images/home_main.png'/><input type='hidden' name='uploadPic' class='hidPicurl' value='" + msg.split('|')[1] + "'/></div>";
                $("#tablePic").append(appendHtml);

            } else {
                $('#uploadLog').html(msg);
            }
        }
    </script>
</body>
</html>
