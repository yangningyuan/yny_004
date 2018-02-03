<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankInfo.aspx.cs" Inherits="yny_004.Web.SysManage.BankInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function guidGenerator() {
            var S4 = function () {
                return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
            };
            return (S4() + S4());
        }
        function addRow(obj) {
            var t = guidGenerator(); //  d + h + x + s + ms;
            var ownParent = $(".arrangeTab");
            var arrangeTable = $("#tabQuestion");
            var orgin = ownParent.html();
            //添加新的行程
            var appendHtml = "<tr id='append" + t + "' class='active realContain'>" + orgin + "</tr>";
            arrangeTable.append(appendHtml);

            $("#append" + t).find(".inputCode").attr("name", "Code_" + t).attr("require-type", "require").attr("require-msg", "银行代码");
            $("#append" + t).find(".inputName").attr("name", "Name_" + t).attr("require-type", "require").attr("require-msg", "银行名称");
            $("#append" + t).find('#remark').attr('name', 'remark_' + t).removeAttr('id');
            $("#append" + t).find('#btnUpload').attr('title', 'btnUpload_' + t).removeAttr('id');
            reCount();
        }

        function reCount() {
            $(".spCount").each(function (i) {
                $(this).html(i);
            });
        }

        function removeRow(obj) {
            if (confirm("确定要移除该行吗？")) {
                var delId = $(obj).prev('.hidId').val();
                var hidDelIds = $("#hidDelIds").val();

                if (typeof (delId) != 'undefined' && delId != "") {
                    if (typeof (hidDelIds) != 'undefined') {
                        hidDelIds += delId + ',';
                    }
                    $("#hidDelIds").val(hidDelIds);
                }
                $(obj).parent().parent().remove();
                reCount()
            }
        }
        function checkFormVal() {
            if (checkForm()) {
                $.ajax({
                    type: 'post',
                    url: 'SysManage/BankInfo.aspx?Action=Add',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        v5.alert('保存成功', '1', 'true');
                        //setTimeout(function () { v5.clearall(); }, 1000);
                        callhtml('SysManage/BankInfo.aspx', '银行管理');
                    }
                });
            }
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
                <input type="hidden" runat="server" id="hidDelIds" />
                <div class="ui_table">
                    <table cellpadding="0" cellspacing="0" class="tabcolor" id="tabQuestion">
                        <tr>
                            <th class="thCenter">编号
                            </th>
                            <th class="thCenter">银行编码
                            </th>
                            <th class="thCenter">银行名称
                            </th>
                            <th class="thCenter">备注说明
                            </th>
                            <th class="thCenter">操作
                            </th>
                        </tr>
                        <tr class="arrangeTab" style="display: none">
                            <td width="5%" align="center" class="tabIndex">
                                <span class="spCount"></span>
                            </td>
                            <td>
                                <input class="normal_input tabInput inputCode" type="text" />
                            </td>
                            <td>
                                <input class="normal_input tabInput inputName" type="text" />
                            </td>
                            <td>
                                <input class="normal_input tabInput" id="remark" type="text" />
                            </td>
                            <td>
                                <input type="hidden" class="hidId" />
                                <input type="button" value="删除" class="btn btn-danger" onclick="removeRow(this)" />
                            </td>
                        </tr>
                        <asp:Repeater ID="rep_List" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td width="5%" align="center">
                                        <span class="spCount">
                                            <%# Container.ItemIndex + 1%></span> :
                                    </td>
                                    <td>
                                        <input name="Code_<%# Container.ItemIndex + 1%>" value="<%#Eval("Code")%>" require-type="require"
                                            require-msg="银行编码" class="normal_input tabInput" type="text" />
                                    </td>
                                    <td>
                                        <input name="Name_<%# Container.ItemIndex + 1%>" value="<%#Eval("Name")%>" require-type="require"
                                            require-msg="银行名称" class="normal_input tabInput" type="text" />
                                    </td>
                                    <td>
                                        <input class="normal_input tabInput" name="remark_<%#Container.ItemIndex+1%>" value="<%#Eval("Remark")%>" type="text" />
                                    </td>
                                    <td>
                                        <input type="hidden" class="hidId" value="<%# Eval("Id")%>" name="hidId_<%# Container.ItemIndex + 1%>" />
                                        <input type="button" value="删除" class="btn btn-danger" onclick="removeRow(this)" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <div style="background-color: #fff; text-align: right">
                        <input type="button" value="添加" class="btn btn-info" onclick="addRow(this)" />
                        <input type="button" value="保存" class="btn btn-success" onclick="checkFormVal()"
                            style="margin-right: 15%" />
                    </div>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
