<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JJJLList.aspx.cs" Inherits="yny_004.Web.ChangeMoney.JJJLList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        typeList = "<%=list %>";
        tUrl = "ChangeMoney/Handler/JJJLList.ashx";
        tState = '';
        SearchByCondition();
        var jjtitles = "<%=titles %>";
        ChangeTitle(jjtitles, $("#Result"), '日期', '<%=TModel.Role.Super.ToString().ToUpper() %>');

        // 导出Excel
        function exportExcel() {
            ExportExcel("ChangeMoney/Handler/ExportExcel.ashx", "JJCXExcel");
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0);" onclick="SearchByState('100',this);" class="btn btn-danger">每日奖金</a>
                <a href="javascript:void(0)" onclick="SearchByState('7',this);" class="btn btn-success">每月奖金</a>
            </div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <%--<input type="button" value="导出Excel" class="btn btn-success" onclick="exportExcel()" />--%>
                <input name="txtKey" data-name="txtKey" id="txtKey" runat="server" placeholder="请输入会员账号" value="请输入会员账号"  style="width: 150px;"
                    type="text" class="sinput" />
              
                <input type="text" name="txtKey" data-name="txtKey" id="startDate" placeholder="开始日期" value="开始日期"  onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({maxDate:'#F{$dp.$D(\'endDate\')}'})" /> 
                     <input type="text" name="txtKey" data-name="txtKey" id="endDate" placeholder="截止日期" value="截止日期"  onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" />
            </div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" class="tabcolor" id="Result">
                <tr>
                    <th width="50px">
                        全选
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <%--<a href="javascript:void(0);" onclick="javascript:tableToExcel('Result')">导出Excel</a>--%>
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
