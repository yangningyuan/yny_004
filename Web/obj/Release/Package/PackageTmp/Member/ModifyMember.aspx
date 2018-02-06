<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyMember.aspx.cs" Inherits="yny_004.Web.Member.ModifyMember"
    EnableEventValidation="false" %>

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
                        <td width="15%" align="right">会员账号:
                        </td>
                        <td width="35%">
                            <input id="txtMID" runat="server" class="normal_input" type="text" readonly="readonly"
                                maxlength="20" />
                        </td>
                        <td width="15%" align="right">会员姓名:
                        </td>
                        <td width="35%">
                            <input id="txtMName" runat="server" class="normal_input" type="text" maxlength="30" />
                        </td>
                    </tr>
                    <%--<tr>
                        <td align="right">角色:
                        </td>
                        <td>
                            <select id="ddlMemberType" runat="server" disabled="disabled">
                            </select>
                        </td>
                      
                    </tr>--%>
                    <%--<tr>
                        <td align="right">手机号码:
                        </td>
                        <td>
                            <input id="txtTel" runat="server" class="normal_input" type="text" maxlength="15" />
                        </td>
                    </tr>--%>
                    <%--<tr>
                    <td align="right">
                        省市县区:
                    </td>
                    <td colspan="3">
                        <select id="ddlRegion" runat="server">
                        </select>
                        <select id="ddlProvince" runat="server">
                        </select>
                        <select id="ddlCity" runat="server">
                        </select>
                        <select id="ddlZone" runat="server">
                        </select>
                    </td>
                    </tr>--%>
                    <tr>
                        <%--<td align="right">身份证号码:
                        </td>
                        <td>
                            <input id="txtNumID" runat="server" class="normal_input" type="text" maxlength="18" />
                        </td>--%>
                        <td align="right">角色:
                        </td>
                        <td>
                            <select id="ddlMemberType" runat="server">
                            </select>
                        </td>
                        <td align="right">推荐人:
                        </td>
                        <td>
                            <input id="txtMTJ" runat="server" class="normal_input" type="text" maxlength="20"
                                readonly="readonly" />
                        </td>
                        <%--<td align="right">接点人:
                        </td>
                        <td>
                            <input id="txtMBD" runat="server" class="normal_input" type="text" maxlength="20"
                                readonly="readonly" />
                        </td>--%>
                    </tr>
                    <tr>
                          <td align="right">会员级别:
                        </td>
                        <td>
                            <select id="ddlSHMoney" runat="server">
                            </select>
                        </td>
                          <td align="right">开户地区:
                        </td>
                        <td>
                            <select id="ddlProvince" runat="server">
                            </select>
                            <select id="ddlCity" runat="server">
                            </select>
                            <select id="ddlZone" runat="server" style="display: none;">
                            </select>
                        </td>

                    </tr>
                    <tr>
                        <td align="right">开户银行:
                        </td>
                        <td>
                            <select id="txtBank" runat="server">
                            </select>
                        </td>
                        <td align="right">开户支行:
                        </td>
                        <td>
                            <input id="txtBranch" name="txtBranch" runat="server" maxlength="25" class="pay_input" type="text"
                                require-msg="开户支行" value="11" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">开户姓名:
                        </td>
                        <td>
                            <input id="txtBankCardName" name="txtBankCardName" runat="server" maxlength="10" class="pay_input"
                                type="text" value="11" require-msg="开户姓名" /><span>*</span>
                        </td>
                        <td align="right">开户姓名:
                        </td>
                        <td>
                            <input id="txtBankNumber" name="txtBankNumber" runat="server" maxlength="30" class="pay_input" type="text"
                                value="11" require-msg="卡号" /><span>*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">静态奖金:
                        </td>
                        <td>
                            <select id="ddlJTFHState" runat="server">
                                <option value="True">启用</option>
                                <option value="False">停止</option>
                            </select>
                        </td>
                        <td align="right">动态奖金:
                        </td>
                        <td>
                            <select id="ddlDTFHState" runat="server">
                                <option value="True">启用</option>
                                <option value="False">停止</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">锁定状态:
                        </td>
                        <td>
                            <input id="chkIsClose" runat="server" type="checkbox" />禁止登录|<input id="chkCloseAll"
                                runat="server" type="checkbox" />伞下同步
                        </td>
                        <td align="right">冻结状态:
                        </td>
                        <td>
                            <input id="chkIsClock" runat="server" type="checkbox" />冻结账户|<input id="chkClockAll"
                                runat="server" type="checkbox" />伞下同步
                        </td>
                    </tr>
                    <tr>
                        <td align="right">奖金类型:
                        </td>
                        <td colspan="3">
                            <input id="txtJJTypeList" runat="server" class="normal_input" style="width: 80%"
                                type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">密保问题:
                        </td>
                        <td>
                            <select id="ddlQuestion" name="ddlQuestion" runat="server">
                            </select>
                        </td>
                        <td align="right">密保答案:
                        </td>
                        <td>
                            <input id="txtAnswer" name="txtAnswer" runat="server" type="text" /><span class="dotted">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">登录密码:
                        </td>
                        <td>
                            <input id="txtPassword" runat="server" class="normal_input" type="text" maxlength="32" />
                        </td>
                        <td align="right">资金密码:
                        </td>
                        <td>
                            <input id="txtSecPsd" runat="server" class="normal_input" type="text" maxlength="32" />
                        </td>
                    </tr>
                    <%if (TModel.Role.Super)
                        { %>
                    <tr>
                        <td align="right">可以提现:
                        </td>
                        <td>
                            <input type="checkbox" id="cbkIsTX" runat="server" value="1" />
                        </td>
                        <td align="right">可以转账:
                        </td>
                        <td>
                            <input type="checkbox" id="chkIsZZ" runat="server" value="1" />
                        </td> 
                    </tr>
                    <%} %>
                    <tr style="height: 50px;">
                        <td colspan="2" style="text-align: right;"></td>
                        <td colspan="2" align="left">
                            <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                        </td>
                    </tr>
                </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
         setup();
      
        function checkChange() {
            if ($('#txtMName').val().Trim() == '') {
                v5.error('会员姓名不能为空', '1', 'true');
            //} else if (RunAjaxGetKey('getMName', $('#txtMTJ').val()) == '') {
            //    v5.error('推荐人不存在', '1', 'true');
                //} else if ($('#ddlZone').val() == '县市') {
                //    v5.error('请选择地区', '1', 'true');
            } else {
                ActionModel("Member/ModifyMember.aspx?Action=Modify", $('#form1').serialize());
            }
        }
    </script>
</body>
</html>
