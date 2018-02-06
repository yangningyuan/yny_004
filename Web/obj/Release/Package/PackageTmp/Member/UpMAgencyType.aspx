<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpMAgencyType.aspx.cs"
    Inherits="yny_004.Web.Member.UpMAgencyType" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 30%" align="right">
                        激活会员账号:
                    </td>
                    <td>
                        <%=sjmodel.MID%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        激活会员昵称:
                    </td>
                    <td>
                        <%=sjmodel.MName%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        激活会员当前级别:
                    </td>
                    <td style="font-weight: bold; color: Red;">
                        <%=sjmodel.MAgencyType.MAgencyName%>
                        <input id="hdmid" type="hidden" runat="server" />
                    </td>
                </tr>
              
                   <tr>
                    <td align="right">
                        我的<%=yny_004.BLL.Reward.List["MHB"].RewardName%>:
                    </td>
                    <td>
                        <%=TModel.MConfig.MHB %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        级别:
                    </td>
                    <td>
                        <table style="width: 700px;">
                            <tr>
                                <%=MAgencyTypeColor%>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        升级:
                    </td>
                    <td>
                        <%=MyMAgencyTypeRdo%>
                    </td>
                </tr>
                 
                <tr style="height: 50px;">
                    <td align="right">
                        <input name="重置" type="reset" class="normal_btnok" value="重置" style="display: none;" />
                    </td>
                    <td align="left">
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function ActionModelAndRefreathPage(acturl, actdata, fun) {
            verifypsd(function () {
                $.ajax({
                    type: 'post',
                    url: acturl,
                    data: actdata,
                    success: function (info) {
                        v5.error(info, '2', 'true');
                        if (info.indexOf('*') <= 0) {
                            setTimeout(function () {
                                v5.clearall();
                                window.location.reload();
                            }, 2000);
                        }
                    }
                });
            }, fun);
        }
        function upAgency() {
            var roleCode = '<%=TModel.RoleCode %>';
            if (roleCode == "Notactive") {
                ActionModel("/Member/UpMAgencyType.aspx?Action=modify", $('#form1').serialize());
            }
            else {
                ActionModel("/Member/UpMAgencyType.aspx?Action=modify", $('#form1').serialize());
                //function () {
                //    $("#btnOK").removeAttr("onclick");
                //    $("#btnOK").val("请等待...");
                //}, '升级管理');
            }
        }

        function checkChange() {
            upAgency();
            //            if (checkForm()) {
            //            v5.confirm("确定要追加投资进行升级吗？", upAgency);
            //            }
        }
    </script>
</body>
</html>
