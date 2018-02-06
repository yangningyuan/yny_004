<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberYJList.aspx.cs" Inherits="yny_004.Web.Member.MemberYJList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        typeList = "<%=list %>";
        tUrl = "Member/Handler/MemberYJList.ashx";
        tState = 'true';
        SearchByCondition();
        var jjtitles = "<%=titles %>";
        ChangeTitle(jjtitles, $("#Result"), '', '<%=TModel.Role.Super.ToString().ToUpper() %>');

        // 导出Excel
        function exportExcel() {
            ExportExcel("ChangeMoney/Handler/ExportExcel.ashx", "SRTJExcel");
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control" id="DivSearch" runat="server">
            <div class="search">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <%--<input type="button" value="导出Excel" class="btn btn-success" onclick="exportExcel()" />--%>
                <input name="txtKey" data-name="txtKey" id="mKey" value="会员账号或名称" onfocus="if (value =='会员账号或名称'){value =''}"
                    onblur="if (value ==''){value='会员账号或名称'}" type="text" class="sinput" />
                <input type="text" name="txtKey" data-name="txtKey" id="startDate" value="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({maxDate:'#F{$dp.$D(\'endDate\')}'})" />
                <input type="text" name="txtKey" data-name="txtKey" id="endDate" value="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" />
            </div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" id="Result" class="tabcolor">
                <tr>
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
