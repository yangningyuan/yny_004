<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskList.aspx.cs" Inherits="yny_004.Web.Message.TaskList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "Message/Handler/TaskList.ashx";
        tState = 'to';
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <%--<a href="javascript:void(0)" onclick="SearchByState('false',this);" class="btn btn-danger">未读邮件</a>--%>
                <a href="javascript:void(0);" onclick="SearchByState('to',this);" class="btn btn-danger">收件箱</a>
                <a href="javascript:void(0);" onclick="SearchByState('from',this);" class="btn btn-success">发件箱</a>
                <a href="javascript:void(0);" onclick="SearchByState('001',this);" class="btn btn-success">我的消息</a>
            </div>
            <div class="pay" onclick="UpDateByTaskID('Message/TaskAdd.aspx?','发送邮件',460,340)">
                发送邮件</div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition();" />
                <input id="mKey" name="txtKey" data-name="txtKey" value="请输入会员账号" onfocus="if (value =='请输入会员账号'){value =''}"
                    onblur="if (value ==''){value='请输入会员账号'}" type="text" class="sinput" />
                <input id="nTitle" name="txtKey" data-name="txtKey" value="请输入关键内容" onfocus="if (value =='请输入关键内容'){value =''}"
                    onblur="if (value ==''){value='请输入关键内容'}" type="text" class="sinput" />
            </div>
            <div class="cheeckbox" id="DivChk" runat="server" style="display: none;">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <input type="checkbox" id="chktrue" checked="checked" value="true" name="chkType"
                                onclick="SearchByCondition();" />
                        </td>
                        <td>
                            <label>
                                有效邮件</label>
                        </td>
                        <td>
                            <input type="checkbox" id="chkflase" value="false" name="chkType" onclick="SearchByCondition();" />
                        </td>
                        <td>
                            <label>
                                作废邮件</label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" class="tabcolor" id="Result">
                <tr>
                    <th width="50px">
                        全选
                    </th>
                    <th>
                        序号
                    </th>
                    <th>
                        发件会员
                    </th>
                    <th>
                        收件会员
                    </th>
                    <th style="width: 55%;">
                        邮件
                    </th>
                    <th>
                        邮件类型
                    </th>
                    <th>
                        日期
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <%--<a href="javascript:void(0);" title="" onclick="RunAjaxByList('to','HideTask',',');">
                        作废</a>--%>
                    <span id="span" runat="server"><a href="javascript:void(0);" title="" onclick="RunAjaxByList('','Del_Task',',');">
                        删除</a></span>
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
