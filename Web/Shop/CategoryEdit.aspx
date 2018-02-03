<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryEdit.aspx.cs" Inherits="yny_004.Web.Shop.CategoryEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <input type="hidden" id="hidId" runat="server" />
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        分类代码：
                        <input type="text" id="txtCode" runat="server" class="normal_input" />
                    </td>
                </tr>
                <tr>
                    <td>
                        分类名称：<input type="text" id="txtName" runat="server" class="normal_input" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="button" onclick="checkChange()" class="btn btn-success btn-sm" value="确定" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">

        function checkChange() {
            if ($('#txtCode').val().Trim() == "") {
                v5.error('分类编码不能为空', '1', 'true');
            }

            else if ($('#txtName').val() == "") {
                v5.error('分类名称不能为空', '1', 'true');
            }
            else {
                if (checkForm()) {
                    $.ajax({
                        type: 'post',
                        url: '/Shop/CategoryEdit.aspx?Action=add',
                        data: $('#form1').serialize(),
                        success: function (info) {
                            if (info == "1") {
                                v5.alert('添加成功', '1', 'true');
                                setTimeout(function () { v5.clearall(); }, 1000);
                                callhtml('../Shop/Category.aspx', '商品分类管理');
                            } else if (info == "2") {
                                v5.alert("已存在该编号，请重新输入", '1', 'true');
                                $("#txtCode").val("").focus();
                            }
                            else {
                                v5.alert('添加失败，请重试', '1', 'true');
                            }
                        }
                    });
                }
            }
        }
    </script>
</body>
</html>
