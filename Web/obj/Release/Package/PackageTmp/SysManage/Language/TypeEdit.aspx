<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TypeEdit.aspx.cs" Inherits="yny_004.Web.SysManage.Language.TypeEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1" method="post" action="/Admin/UpLoadPic/IbeaconHandler.ashx" target='frameFile'
            enctype="multipart/form-data">
            <input id="hidId" type="hidden" runat="server" />
            <input id="hduploadPic1" type="hidden" runat="server" />
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="15%" align="right">
                        <span>语种代码：</span>
                    </td>
                    <td width="35%">
                        <input id="txtCode" runat="server" style="width: 40%" class="pay_input" type="text"
                            require-type="require" require-msg="语种代码" readonly="readonly" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>语种名称：</span>
                    </td>
                    <td>
                        <input id="txtName" style="width: 40%" runat="server" require-type="require" class="pay_input"
                            require-msg="语种名称" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>语种图片：</span>
                    </td>
                    <td>
                        <input type="button" class="btn btn-success btn-sm" value="上传图片" onclick="UpLoadPic()" />
                        <input type='file' id='fileUp' name='fileUp' onchange="changeform();" style="display: none" />
                        <div id='uploadLog'>
                        </div>
                        <img src="" alt="图片" runat="server" id="imgPic" style="width: 38px; height: 24px;" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>是否启用：</span>
                    </td>
                    <td width="35%">
                        <input id="chkStatus" runat="server" type="checkbox" value="1" checked="checked" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
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
                $("#imgPic").attr("src", msg.split('|')[1]);

            } else {
                $('#uploadLog').html(msg);
            }
        }
        function checkChange() {
            if (checkForm())
                ActionModelBackWithTitleWithNoVerify("/SysManage/Language/TypeEdit.aspx?Action=add", $('#form1').serialize(), "/SysManage/Language/TypeList.aspx", null, '语种设置');
        }
    </script>
</body>
</html>
