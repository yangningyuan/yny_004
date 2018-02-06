<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyLink.aspx.cs" Inherits="yny_004.Web.Member.MyLink" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        td span
        {
            color: Red;
        }
    </style>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="30%" align="right">
                        <div style="text-align: center;">
                            推广链接:</div>
                    </td>
                    <td>
                        <input style="width: 700px; height: 34px; padding: 0px; border: solid 1px #dcdcdc"
                            id="txtTuiGuang" runat="server" />
                        <input class="tuiglj" type="button" style="width: 60px; background: #cd635c; height: 36px;
                            border: solid 1px #bb5b54" data-clipboard-target="txtTuiGuang" id="fenxian" value="复制" />
                        <div class="ermw">
		                    <div id="qrcode_container">  <div class="h3 text-center" style="font-family: 华文行楷;
                                color:#A81D1D;text-align:left;    padding: 15px 0px;"> 抢占先机扫我注册
                            </div></div>
	                    </div>
                    </td>
                </tr>
                   
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript" src="plugin/ZeroClipboard/ZeroClipboard.js"></script>
    <script type="text/javascript">
        $(function () {

            var clip = new ZeroClipboard(document.getElementById("fenxian"), {
                moviePath: "/plugin/ZeroClipboard/ZeroClipboard.swf"
            });

            // 复制内容到剪贴板成功后的操作
            clip.on('complete', function (client, args) {
                layer.alert('复制成功！', {
                    skin: 'layer-ext-moon',
                    btn: 'ok',
                    yes: function (index, layero) {
                    }
                });
            });
        })
    </script>
     <script type="text/javascript">
        setTimeout(function () {
		    $('#qrcode_container').qrcode({ width: 400, height: 400, text: toUtf8('<%=base.GetPromoteLink()%>') });
	    }, 50);
    </script>
</body>
</html>
