<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiveInfo.aspx.cs" Inherits="yny_004.Web.mobile.html.ReceiveInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title></title>
     <style>
        .caozuo a{
        display:inline !important;
        padding:4px 10px;
        border-radius:3px;
        background:#3b9e3b;
        color:#fff !important;
    }
         .opa input {
                padding: .5px 8px;
                margin:0 7px;
         }
    </style>
    <script>

        function delreceive(id) {
            ActionModel('/mobile/html/ReceiveInfo.aspx?Action=modify&id=' + id, $('#form1').serialize(), '/mobile/html/ReceiveInfo.aspx');
        }

    </script>
</head>
<body>
    <div class="content">
        <div class="zh_head">
            <i class="iconfont">&#xe610;</i><span>收货人管理</span>
        </div>
        <form id="form1">
             <input type="hidden" value="" id="state" runat="server" />
             
             <a href="javascript:void(0)"  onclick="pcallhtml('/mobile/html/AddReceive.aspx', '新增收货人');" title="" class="btn_qd" style="display:block; width:150px;">新增</a>
            <div class="clear"></div>
        </form>
        <script type="text/x-jquery-tmpl" id="ReceiveInfoTmpl">
				<tr>
					<td>${Name}</td>
					<td>${Tel}</td>
                    <td>{{html Address}}</td>
                    <td>${State}</td>
                    <td class="opa">{{html op}}</td>
				</tr>
        </script>
        <table class="gridtable">
            
                <tr>
                    <th>
                        收货人
                    </th>
                    <th>
                        电话
                    </th>
                    <th>
                        地址
                    </th>
                  <th>
                       默认收货人
                    </th>
                    <th>
                        操作
                    </th>
                </tr>
            
            <tbody id="data_container">
            </tbody>
        </table>
        <div id="page_container">
        </div>
    </div>
    <script>
        $(function () {
            $('#data_container').on('click', '.list-detail', function () {
                //console.log(parseInt($(this).next().css('height')));
                if (parseInt($(this).next().css('height')) < 300) {
                    $(this).next().css('height', '300px');
                }

                $(this).next().slideDown();
            })
            $('#data_container').on('click', '.detail-close', function () {
                $(this).parent().slideUp();
            })
        })
    </script>
    <script type="text/javascript">
        setTimeout(function () {
            $('#page_container').Paging({
                TemplateContainer: '#ReceiveInfoTmpl',
                DataContainer: '#data_container',
                DataUrl: '/mobile/html/ReceiveInfo.aspx?Action=Other',
                QueryContainer: '#form1',
                Rendered: function () {
                    window.MobileSelectAll();
                }
            });
        }, 50);
    </script>
</body>
</html>