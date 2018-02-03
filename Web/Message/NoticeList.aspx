<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeList.aspx.cs" Inherits="yny_004.Web.Message.NoticeList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tState = '';
        tUrl = "Message/Handler/NoticeList.ashx";
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0)" onclick="SearchByState('',this);" class="btn btn-danger">
                    所有</a> <a href="javascript:void(0);" onclick="SearchByState('1',this);" class="btn btn-success">
                        正常</a> <a href="javascript:void(0)" onclick="SearchByState('0',this);" class="btn btn-success">
                            已作废</a>
            </div>
            <div class="pay" onclick="UpDateByID('Message/NoticeModify.aspx?','修改公告',900,470);">
                修改公告</div>
            <div class="pay" onclick="v5.show('Message/NoticeAdd.aspx','发布公告','url',900,470)">
                发布公告</div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" /><input
                    id="nTitle" name="txtKey" data-name="txtKey" value="请输入标题" onfocus="if (value =='请输入标题'){value =''}"
                    onblur="if (value ==''){value='请输入标题'}" type="text" class="sinput" />
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
                    <th width="50%">
                        标题
                    </th>
                    <th>
                        发布日期
                    </th>
                    <th>
                        是否滚动
                    </th>
                    <th>
                        浏览次数
                    </th>
                    <th>
                        状态
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <a href="javascript:void(0);" title="" onclick="RunAjaxByList('0','ShowNotice',',');">
                        恢复</a> <a href="javascript:void(0);" title="" onclick="RunAjaxByList('1','HideNotice',',');">
                            作废</a> <a href="javascript:void(0);" title="" onclick="RunAjaxByList('','Del_Notice',',');">
                                删除</a>
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
