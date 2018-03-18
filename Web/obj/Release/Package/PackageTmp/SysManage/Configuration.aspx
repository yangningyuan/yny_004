<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Configuration.aspx.cs"
    Inherits="yny_004.Web.SysManage.Configuration" EnableEventValidation="false" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <style type="text/css">
        .hideCont {
            display: none;
        }

        #GridView1 th {
            color: #000000;
        }
    </style>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1" class="contentForm" runat="server">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="text-align: right; width: 20%;">平台管理费:
                        </td>
                        <td>
                            <input id="txtYLMoney" runat="server" class="normal_input" type="text" require-type="int"
                                require-msg="平台管理费" /><font color="red">*正整数</font>
                        </td>
                        <td style="text-align: right; width: 20%;">激活默认角色:
                        </td>
                        <td>
                            <select id="ddlDefaultRole" runat="server">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width: 20%;">最少提现金额:
                        </td>
                        <td>
                            <input id="txtTXMinMoney" runat="server" class="normal_input" type="text" require-type="int"
                                require-msg="最少提现金额" /><font color="red">*正整数</font>
                        </td>
                        <td style="text-align: right; width: 20%;">提现倍数:
                        </td>
                        <td>
                            <input id="txtTXBaseMoney" runat="server" class="normal_input" type="text" require-type="int"
                                require-msg="提现倍数" /><font color="red">*正整数</font>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width: 20%;">最多提现金额:
                        </td>
                        <td>
                            <input id="txtTXMaxMoney" runat="server" class="normal_input" type="text" require-type="int"
                                require-msg="最多提现金额" /><font color="red">*正整数</font>
                        </td>
                        <td style="text-align: right; width: 20%;">提现开关:
                        </td>
                        <td>
                            <select id="txSwitch" name="txSwitch" runat="server">
                                <option value="0">关闭</option>
                                <option value="1">开启</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width: 20%;">最少转账金额:
                        </td>
                        <td>
                            <input id="txtZZMinMoney" runat="server" class="normal_input" type="text" require-type="int"
                                require-msg="最少转账金额" /><font color="red">*正整数</font>
                        </td>
                        <td style="text-align: right; width: 20%;">转账倍数:
                        </td>
                        <td>
                            <input id="txtZZBaseMoney" runat="server" class="normal_input" type="text" require-type="int"
                                require-msg="转账倍数" /><font color="red">*正整数</font>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width: 20%;">最少转换金额:
                        </td>
                        <td>
                            <input id="txtDHMinMoney" runat="server" class="normal_input" type="text" require-type="int"
                                require-msg="最少转换金额" /><font color="red">*正整数</font>
                        </td>
                        <td style="text-align: right; width: 20%;">转换倍数:
                        </td>
                        <td>
                            <input id="txtDHBaseMoney" runat="server" class="normal_input" type="text" require-type="int"
                                require-msg="转换倍数" /><font color="red">*正整数</font>
                        </td>
                    </tr>
                  
                    <tr style="display:none;">
                        <td style="text-align: right; width: 20%;">最小投资额:
                        </td>
                        
                    </tr>
                    <tr style="display:none;">
                        <td style="text-align: right; width: 20%;">投资倍数:
                        </td>
                        <td>
                            <input id="txtE_TZBase" runat="server" class="normal_input" type="text" require-type="int"
                                require-msg="投资倍数" /><font color="red">*正整数</font>
                        </td>
                        <td style="text-align: right; width: 20%;">退本扣费比例:
                        </td>
                        <td>
                            <input id="txtE_QuitFloat" runat="server" class="normal_input" type="text" require-type="decimal"
                                require-msg="退本扣费比例" /><font color="red">*</font>
                        </td>
                    </tr>
                  
                    <tr>
                         <td style="text-align: right; width: 20%;">推荐见点余额百分比:
                        </td>
                        <td>
                            <input id="txtE_BbinMoney" runat="server" class="normal_input" type="text" require-type="decimal"
                                require-msg="推荐见点余额百分比" /><font color="red">*</font>
                        </td>
                        <td style="text-align: right; width: 20%;">推荐见点公排复投百分比:</td>
                        <td>
                            <input id="txtE_BbinFHFloat" runat="server" class="normal_input" type="text" require-type="decimal"
                                require-msg="推荐见点公排复投百分比" /><font color="red">*</font>
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <td style="text-align: right; width: 20%;">每日最大投资额:</td>
                        <td>
                            <input id="txtE_MaxTouZi" runat="server" class="normal_input" type="text" require-type="decimal"
                                require-msg="每日最大投资额" /><font color="red">*</font>
                        </td>
                         <td style="text-align: right; width: 20%;">手机注册单数:
                        </td>
                        <td>
                            <input id="txtE_BbinMaxCount" runat="server" class="normal_input" type="text" require-type="int"
                                require-msg="手机注册单数" /><font color="red">*正整数</font>
                        </td>
                    </tr>
                     <tr style="display:none;">
                        
                         <td style="text-align: right; width: 20%;">烧伤金额:
                        </td>
                        <td>
                            <input id="txtB_TBTJMoney" runat="server" class="normal_input" type="text" require-type="decimal"
                                require-msg="烧伤金额" />
                        </td>
                    </tr>
                      <tr>
                        <td style="text-align: right; width: 20%;">每日签到金额:
                        </td>
                        <td>
                            <input id="txtE_DayFHFloat" runat="server" class="normal_input" type="text" require-type="decimal"
                                require-msg="每日签到金额" /><font color="red">*</font>
                           最多签到
                            <input id="txtE_BbinTimes" runat="server" class="normal_input" type="text"  style="width:50px;" require-type="int"
                                require-msg="签到次数" /><font color="red">*正整数</font>
                        次
                        </td>
                        <td style="text-align: right; width: 20%;">拆红包使用余额金额:
                        </td>
                        <td>
                            <input id="txtE_TJFloat" runat="server" class="normal_input" type="text" require-type="decimal"
                                require-msg="拆红包使用余额金额" /><font color="red">*</font>
                            拆包范围
                            <input id="txtE_TZMin" runat="server" class="normal_input" type="text" style="width:50px;" require-type="int"
                                require-msg="最小额度" /><font color="red"></font>
                            -
                            <input id="txtE_TZMax" runat="server" class="normal_input" type="text" style="width:50px;" require-type="int"
                                require-msg="最大额度" /><font color="red"></font>
                       
                        </td>
                    </tr>
                    <tr>  <td></td>
                        <td></td>
                        <td style="text-align: right; width: 20%;">拆小包最大金额:</td>
                        <td>
                            <input id="txtB_TBTJDate" runat="server" class="normal_input" type="text" require-type="int"
                                require-msg="拆小包最大金额" /><font color="red">*正整数</font>
                        </td>
                      
                    </tr>
                </table>
                <div style="overflow-x: auto; width: 100%;">
                    <asp:GridView ID="GridView1" OnRowDataBound="GridView1_RowDataBound" runat="server"
                        AutoGenerateColumns="False" AllowSorting="True">
                        <Columns>
                            <asp:TemplateField HeaderText="级别代码" HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <asp:TextBox Width="100%" ID="txtMAgencyType" runat="server" Text='<%#Eval("MAgencyType") %>'
                                        ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="级别名称" HeaderStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:TextBox Width="100%" ID="txtMAgencyName" runat="server" Text='<%#Eval("MAgencyName") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="报单金额" HeaderStyle-Width="120px">
                                <ItemTemplate>
                                    <asp:TextBox Width="70%" ID="txtMoney" require-type="require" runat="server" Text='<%#Bind("Money") %>' />小数
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="提现比例" HeaderStyle-Width="120px">
                                <ItemTemplate>
                                    <asp:TextBox Width="70%" ID="txtTXFloat" require-type="require" runat="server" Text='<%#Bind("TXFloat") %>' />小数
                                </ItemTemplate>
                            </asp:TemplateField>
                           <%-- <asp:TemplateField HeaderText="团队业绩" HeaderStyle-Width="120px">
                                <ItemTemplate>
                                    <asp:TextBox Width="70%" ID="txtYJMoney" require-type="require" runat="server" Text='<%#Bind("YJMoney") %>' />小数
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="每周完成业绩" HeaderStyle-Width="120px">
                                <ItemTemplate>
                                    <asp:TextBox Width="70%" ID="txtDPFloat" require-type="require" runat="server" Text='<%#Bind("DPFloat") %>' />小数
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="未完成提现扣除比例" HeaderStyle-Width="120px">
                                <ItemTemplate>
                                    <asp:TextBox Width="70%" ID="txtReBuyFloat" require-type="require" runat="server" Text='<%#Bind("ReBuyFloat") %>' />小数
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="每周提现次数" HeaderStyle-Width="120px">
                                <ItemTemplate>
                                    <asp:TextBox Width="70%" ID="txtSubCount" require-type="int" runat="server" Text='<%#Bind("SubCount") %>' />整数
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                               <asp:TemplateField HeaderText="可看图谱层数" HeaderStyle-Width="120px">
                                <ItemTemplate>
                                    <asp:TextBox Width="70%" ID="txtViewLevel" runat="server" Text='<%#Bind("ViewLevel") %>' />整数
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="颜色" HeaderStyle-Width="160px">
                                <ItemTemplate>
                                    <asp:TextBox Width="60%" ID="txtMColor" runat="server" Text='<%#Bind("MColor") %>' />#493823
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="lasttab">
                    <asp:GridView ID="GridView2" OnRowDataBound="GridView1_RowDataBound" runat="server"
                        AutoGenerateColumns="False" AllowSorting="True">
                        <Columns>
                            <asp:TemplateField HeaderText="参数编码">
                                <ControlStyle Width="80%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDType" runat="server" Text='<%#Eval("DType") %>' ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="说明">
                                <ControlStyle Width="80%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtRemark" runat="server" Text='<%#Eval("Remark") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="最小代数">
                                <ControlStyle Width="80%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtStartLevel" runat="server" Text='<%#Eval("StartLevel") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="最大代数">
                                <ControlStyle Width="80%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtEndLevel" runat="server" Text='<%#Eval("EndLevel") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="奖励金额">
                                <ControlStyle Width="80%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDValue" runat="server" Text='<%#Eval("DValue") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <%--<div>
                <asp:GridView ID="GridView4" OnRowDataBound="GridView1_RowDataBound" runat="server"
                    AutoGenerateColumns="False" AllowSorting="True">
                    <Columns>
                        <asp:TemplateField HeaderText="参数编码">
                            <ControlStyle Width="80%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtNDType" runat="server" Text='<%#Eval("NDTpye") %>' ReadOnly="true"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="说明">
                            <ControlStyle Width="100px" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtNRemark" runat="server" Text='<%#Eval("Remark") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="最小代数">
                            <ControlStyle Width="80%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtNStartLevel" runat="server" Text='<%#Eval("StartLevel") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="最大代数">
                            <ControlStyle Width="80%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtNEndLevel" runat="server" Text='<%#Eval("EndLevel") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="最小推荐人数">
                            <ControlStyle Width="80%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtNDStartRec" runat="server" Text='<%#Bind("StartRec") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="最大推荐人数">
                            <ControlStyle Width="80%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtNDEndRec" runat="server" Text='<%#Bind("EndRec") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="奖励比例">
                            <ControlStyle Width="80%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtNDValue" runat="server" Text='<%#Bind("DValue") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>--%>
                <%--<br />
                <br />
                <div>
                    <asp:GridView ID="GridView5" OnRowDataBound="GridView1_RowDataBound" runat="server"
                        AutoGenerateColumns="False" AllowSorting="True">
                        <Columns>
                            <asp:TemplateField HeaderText="参数编码">
                                <ControlStyle />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCode" runat="server" Text='<%#Eval("Code") %>' ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="类型">
                                <ControlStyle />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDkey" runat="server" Text='<%#Eval("Dkey") %>' ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="最小层数">
                                <ControlStyle />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtGJCount" runat="server" Text='<%#Bind("GJCount") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="最大层数">
                                <ControlStyle />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCJCount" runat="server" Text='<%#Bind("CJCount") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="奖励比例">
                                <ControlStyle />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHBFHFloat" runat="server" Text='<%#Bind("HBFHFloat") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="推荐人数">
                                <ControlStyle />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtTJCount" runat="server" Text='<%#Eval("TJCount") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="团队人数">
                                <ControlStyle />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSubTJCount" runat="server" Text='<%#Eval("SubTJCount") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>--%>
                <table cellpadding="0" cellspacing="0">
                    <tr style="height: 50px;">
                        <td style="text-align: center">
                            <input class="normal_btnok" id="Button1" type="button" value="确定" onclick="checkOk();" />
                        </td>
                        <td style="text-align: center">
                            <input class="normal_btnok" id="Button2" type="button" value="初始化" onclick="checkClear();" />
                        </td>
                        <td style="text-align: center">
                            <input class="normal_btnok" id="Button3" type="button" value="奖金清零" onclick="checkMHB('1');" />
                        </td>
                    </tr>
                </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("#__VIEWSTATE").remove();
        })
        function checkOk() {
            if (checkForm())
                ActionModel("SysManage/Configuration.aspx?Action=modify", $('#form1').serialize());
        }

        function checkClear() {
            ActionModel("SysManage/Configuration.aspx?Action=other", $('#form1').serialize());
        }

        function checkMHB(obj) {
            ActionModel("SysManage/Configuration.aspx?Action=Add&Type=" + obj, $('#form1').serialize());
        }

        $(function () {
            $("#moneyTran").click(function () {
                var state = $(this).attr("checked");
                var toUrl = "/SysManage/Configuration.aspx?Action=TRANMONEY&Type=";
                if (typeof (state) != "undefined" && state == "checked")
                    toUrl += "1";
                else
                    toUrl += "2";
                ActionModel(toUrl, $('#form1').serialize());
            });

        });

    </script>
</body>
</html>
