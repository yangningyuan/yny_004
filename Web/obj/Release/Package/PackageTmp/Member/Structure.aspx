<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Structure.aspx.cs" Inherits="yny_004.Web.Member.Structure" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="plugin/jOrgChart/css/jquery.jOrgChart.css" />
    <script type="text/javascript" src="plugin/jOrgChart/prettify.js"></script>
    <script type="text/javascript" src="plugin/jOrgChart/jquery.jOrgChart.js"></script>
    <script type="text/javascript">
        var level = 3;
        var defalutinfo = "请输入会员账号,层级";
        GetAjaxInfo($('#txtMid').val());
    </script>
    <style type="text/css">
        .tablefilter td {
            width: auto;
            font-size: 14px;
            border: 1px solid #ddd;
            background: #0DADD5;
            color:black;
        }

        td a {
            color: #000;
        }

        #chart table {
            margin: auto;
        }
        table{
            background-color: rgba(244, 244, 244, 0 );
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="mempay">
            <div class="control">
                <div class="search" id="DivSearch" runat="server">
                    <input type="button" value="查询" class="ssubmit" onclick="GetAjaxInfo($('#txtMid').val())" /><input
                        id="txtMid" runat="server" value="请输入会员账号" onfocus="if (value =='请输入会员账号'){value =''}"
                        onblur="if (value ==''){value='请输入会员账号'}" type="text" class="sinput" /><input id="txtLevel"
                            runat="server" value="3" onfocus="if (value =='层级'){value =''}" onblur="if (value ==''){value='层级'}"
                            type="text" class="sinput" style="width: 100px;" />
                </div>
                <div class="cheeckbox">
                    <table cellpadding="0" cellspacing="0" style="font-size: 21px; color: White;">
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td style="display: none;">会员级别:<input id="rdoAgency" value="Agency" type="radio" name="rdoColor" checked="checked"
                                            onclick="GetAjaxInfo($('#txtMid').val())" />
                                        </td>
                                        <%=MAgencyTypeColor%>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="tree_table">
                <ul id="org" style="display: none">
                </ul>
                <div id="chart" class="jOrgChart">
                </div>
            </div>
        </div>
    </form>
</body>
</html>
