<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KFList.aspx.cs" Inherits="yny_004.Web.ChangeMoney.KFList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tState = 'false';
        tUrl = 'ChangeMoney/Handler/KFList.ashx';
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
            </div>
            
            <div class="search" id="DivSearch" runat="server">
                <div class="pay" onclick="v5.show('ChangeMoney/KFChange.aspx','会员扣费','url',620,400)">
                会员扣费</div>
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" data-name="txtKey" id="mKey" placeholder="请输入会员账号" value="请输入会员账号" type="text"
                    class="sinput" />
                <input type="text" name="txtKey" data-name="txtKey" id="endDate" placeholder="截止日期" value="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" />
                <input type="text" name="txtKey" data-name="txtKey" id="startDate" placeholder="开始日期" value="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({maxDate:'#F{$dp.$D(\'endDate\')}'})" /></div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" id="Result" class="tabcolor">
                <tr>
                    <th width="50px">
                        全选
                    </th>
                    <th>
                        序号
                    </th>
                    <th>
                        会员账号
                    </th>
                    <th>
                        扣费金额
                    </th>
                    <th>
                        扣费时间
                    </th>
                    <th>
                        扣费理由
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
