<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SHListSJ.aspx.cs" Inherits="yny_004.Web.Member.SHListSJ" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "Member/Handler/SJList.ashx";
        tState = "false";
        SearchByCondition();
        function displayA(isShow) {
            if (isShow) {
                $("#DivOperation").show();
            } else {
                $("#DivOperation").hide();
            }
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0);" onclick="SearchByState('false',this);displayA(true);" class="btn btn-danger">未审核</a>
                <a href="javascript:void(0)" onclick="SearchByState('true',this);displayA(false);" class="btn btn-success">已审核</a>
            </div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" data-name="txtKey" id="mKey" value="请输入会员账号" onfocus="if (value =='请输入会员账号'){value =''}"
                    onblur="if (value ==''){value='请输入会员账号'}" type="text" class="sinput" />
                <input name="txtKey" data-name="txtKey" id="mSHKey" value="请输入报单中心" onfocus="if (value =='请输入报单中心'){value =''}"
                    onblur="if (value ==''){value='请输入报单中心'}" type="text" class="sinput" />
                <input type="text" name="txtKey" data-name="txtKey" id="startDate" value="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({ maxDate: '#F{$dp.$D(\'endDate\')}' })" />
                <input type="text" name="txtKey" data-name="txtKey" id="endDate" value="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({ minDate: '#F{$dp.$D(\'startDate\')}' })" />
            </div>
            <%
                if (TModel.Role.CanSH)
                {
            %>
            <div class="pay" onclick="UpDateByID('Member/UpMAgencyType.aspx?','升级会员',820,530)">
                升级会员
            </div>
            <%
                }
            %>
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
                    <th>手机号码
                    </th>
                    <th>会员级别
                    </th>
                    <th>报单费
                    </th>
                    <th>推荐人
                    </th>
                 <%--   <th>报单中心
                    </th>--%>
                    <th>是否审核
                    </th>
                    <th>日期
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <span id="DivOperation" runat="server"><a href="javascript:void(0);" title="删除" onclick="RunAjaxByList('false','DeleteMemberW',',');">删除</a></span>
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
