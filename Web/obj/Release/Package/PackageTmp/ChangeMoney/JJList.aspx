<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JJList.aspx.cs" Inherits="yny_004.Web.ChangeMoney.JJList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "ChangeMoney/Handler/JJList.ashx";
        tState = 'True';
        SearchByCondition();

        // 导出Excel
        function exportExcel() {
            ExportExcel("ChangeMoney/Handler/ExportExcel.ashx", "JJMXExcel");
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <%--<input type="button" value="导出Excel" class="btn btn-success" onclick="exportExcel()" />--%>
                <input name="txtKey" data-name="txtKey" id="txtKey" placeholder="请输入奖金来源" value="请输入奖金来源" runat="server"
                    style="width: 150px;" onfocus="if (value =='请输入奖金来源'){value =''}" onblur="if (value ==''){value='请输入奖金来源'}"
                    type="text" class="sinput" />
                <input name="txtKey" data-name="txtKey" id="mKey" placeholder="请输入会员账号" value="请输入会员账号" style="width: 150px;"
                    onfocus="if (value =='请输入会员账号'){value =''}" onblur="if (value ==''){value='请输入会员账号'}"
                    type="text" class="sinput" />
                <input type="text" name="txtKey" data-name="txtKey" id="startDate" placeholder="开始日期" value="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({ maxDate: '#F{$dp.$D(\'endDate\')}' })" />
                <input type="text" name="txtKey" data-name="txtKey" id="endDate" placeholder="截止日期" value="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({ minDate: '#F{$dp.$D(\'startDate\')}' })" />
            </div>
            <div class="cheeckbox">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <% for (int i = 0; i < list.Count; i++)
                            {%>
                        <td>
                            <div class="checkbox">
                                <label style="color:white">
                                    <input type="checkbox" checked="checked" id="chk<%=list[i].RewardType %>" value="<%=list[i].RewardType %>"
                                        name="chkType" onclick="SearchByCondition();" /><%=list[i].RewardName%></label>
                            </div>
                        </td>
                        <%} %>
                    </tr>
                </table>
            </div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" class="tabcolor" id="Result">
                <tr>
                    <th width="50px">全选
                    </th>
                    <th>序号
                    </th>
                    <% if (TModel.Role.Super)
                        { %>
                    <th>会员账号
                    </th>
                    <th>会员姓名
                    </th>
                    <th>会员角色
                    </th>
                    <%} %>
                    <th>奖金合计
                    </th>
                    <%--<th>
                        <%=yny_004.BLL.Reward.List["MHB"].RewardName %>
                    </th>--%>
                    <%--<th>
                        <%=yny_004.BLL.Reward.List["MCW"].RewardName %>
                    </th>--%>
                    <th>奖励类型
                    </th>
                    <th>奖励来源
                    </th>
                    <th>状态
                    </th>
                    <th>日期
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn" runat="server" id="DivDelete">
                    <%--<a href="javascript:void(0);" onclick="javascript:tableToExcel('Result')">导出Excel</a>--%>
                    <a href="javascript:void(0);" title="" onclick="RunAjaxByList('','Del_ChangeMoney',',');">删除</a>
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
