<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FMIDList.aspx.cs" Inherits="yny_004.Web.Member.FMIDList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tState = 'true'
        tUrl = "Member/Handler/FMIDList.ashx";
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
              
            </div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
               
                <input name="txtKey" data-name="txtKey" id="mBDKey" value="请输入主会员账号" onfocus="if (value =='请输入主会员账号'){value =''}"
                    onblur="if (value ==''){value='请输入主会员账号'}" type="text" class="sinput" />
            </div>
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
                        会员姓名
                    </th>
                    <th>
                        会员角色
                    </th>
                    <th>
                        主账号
                    </th>
                    
                    <th>
                        状态
                    </th>
                    <th>
                        注册/激活日期
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
