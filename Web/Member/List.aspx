<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="yny_004.Web.Member.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "Member/Handler/MemberList.ashx";
        tState = "";
        SearchByCondition();
        //        setup();

        // 导出Excel
        function exportExcel() {
            ExportExcel("ChangeMoney/Handler/ExportExcel.ashx", "DPLBExcel");
        }
        //setup();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="cheeckbox" style="float: left;">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <select id="AgencyCode" name="txtKey" data-name="txtKey" onchange="SearchByCondition()">
                                <option value="">会员级别</option>
                                <%=AgencyListStr%>
                            </select>
                        </td>
                        <td>
                            <select id="RoleCode" name="txtKey" data-name="txtKey" onchange="SearchByCondition()">
                                <option value="">会员类型</option>
                                <%=RoleListStr %>
                            </select>
                            <input type="hidden" id="OnlyOnLine" name="txtKey" data-name="txtKey" value="" />
                        </td>
                        <td>
                            <select id="IsClose" name="txtKey" data-name="txtKey" onchange="SearchByCondition()">
                                <option value="">锁定状态</option>
                                <option value="true">已锁定</option>
                                <option value="false">未锁定</option>
                            </select>
                        </td>
                        <td>
                            <select id="IsClock" name="txtKey" data-name="txtKey" onchange="SearchByCondition()">
                                <option value="">冻结状态</option>
                                <option value="true">已冻结</option>
                                <option value="false">未冻结</option>
                            </select>
                        </td>
                        <%--<td>
                            <select id="ddlProvince" runat="server" data-name="txtKey">
                            </select>
                            <select id="ddlCity" runat="server" data-name="txtKey">
                            </select>
                            <select id="ddlZone" runat="server" data-name="txtKey">
                            </select>
                        </td>--%>
                    </tr>
                </table>
            </div>
            <%--<div id="Div1" runat="server" class="pay" onclick="UpDateByIDOrEmpty('Member/SMSSend.aspx?','发送短信',820,530)">
                发送短信</div>--%>
            <div id="editMember" runat="server" class="pay" onclick="UpDateByID('Member/ModifyMember.aspx?','修改会员',820,530)">
                修改会员
            </div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <%--<input type="button" value="导出Excel" class="btn btn-success" onclick="exportExcel()" />--%>
                <input name="txtKey" data-name="txtKey" id="mKey" placeholder="会员账号或名称" value="会员账号或名称"
                    onfocus="if (value =='会员账号或名称'){value =''}" onblur="if (value ==''){value='会员账号或名称'}"
                    type="text" class="sinput" style="width: 120px;" />
                <input type="text" name="txtKey" data-name="txtKey" id="startDate" placeholder="开始日期"
                    value="开始日期" onfocus="if (value =='开始日期'){value =''}" class="daycash_input" style="width: 120px;"
                    onclick="WdatePicker({ maxDate: '#F{$dp.$D(\'endDate\')}' })" />
                <input type="text" name="txtKey" data-name="txtKey" id="endDate" placeholder="截止日期"
                    value="截止日期" onfocus="if (value =='截止日期'){value =''}" class="daycash_input" style="width: 120px;"
                    onclick="WdatePicker({ minDate: '#F{$dp.$D(\'startDate\')}' })" />
            </div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" id="Result" class="tabcolor">
                <tr>
                    <th width="50px">全选
                    </th>
                    <th>序号
                    </th>
                    <th>会员账号
                    </th>
                    <th>会员姓名
                    </th>
                    <th>会员类型
                    </th>
                      <th>会员等级
                    </th>
                    <th>
                        <%=yny_004.BLL.Reward.List["MHB"].RewardName %>
                    </th>
                    <th>
                        <%=yny_004.BLL.Reward.List["MJB"].RewardName%>
                    </th>
                    <th>
                        <%=yny_004.BLL.Reward.List["MGP"].RewardName%>
                    </th>
                  <%--   <th>
                        <%=yny_004.BLL.Reward.List["MCW"].RewardName%>
                    </th>--%>
                    <th>推荐人
                    </th>
                    <%--<th>地区
                    </th>--%>
                    <th>锁定状态
                    </th>
                    <th>冻结状态
                    </th>
                    <%--<th>身份证图片
                    </th>--%>
                    <th>有效投资额
                    </th>
                    <th>团队有效投资额
                    </th>
                    <th>投资日期
                    </th>
                    <th>操作
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                </div>
                <div class="pagebar">
                    <div id="Pagination">
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
