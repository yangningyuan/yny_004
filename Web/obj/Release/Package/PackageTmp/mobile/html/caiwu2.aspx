<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="caiwu2.aspx.cs" Inherits="yny_004.Web.mobile.html.caiwu2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ul class="fins_list box_shadow">
            <li>
                <a href="javascript:pcallhtml('/mobile/html/HBList.aspx','转账');">
                     <i class="iconfont">&#xe614;</i>
                     <p>转账</p>
                </a>
            </li>
            <li>
                <a href="javascript:pcallhtml('/mobile/html/HKChangeWY.aspx','汇款');">
                     <i class="iconfont">&#xe614;</i>
                    <p>汇款</p>
                </a>
            </li>
             <li>
                 <a href="javascript:pcallhtml('/mobile/html/LuckQDList.aspx','签到记录');">
                      <i class="iconfont">&#xe62c;</i>
                     <p>签到记录</p>

                 </a>

             </li>
             <li>
                 <a href="javascript:pcallhtml('/mobile/html/LuckTJList.aspx','推荐记录');">
                      <i class="iconfont">&#xe61f;</i>
                     <p>推荐记录</p>
                 </a>
             </li> 
            <li>
                <a href="javascript:pcallhtml('/mobile/html/LuckJDList.aspx','见点记录');">
                     <i class="iconfont">&#xe61e;</i>
                    <p>见点记录</p>
                </a>
            </li>
             <li>
                 <a href="javascript:pcallhtml('/mobile/html/LuckList.aspx','红包中心记录');">
                     <i class="iconfont">&#xe620;</i>
                     <p>红包中心记录</p>
                 </a>
             </li>
          <%--   <li>
                 <a href="systemEnvelope.html">
                     <i class="iconfont">&#xe66c;</i>
                      <p>系统红包</p>
                 </a>
             </li>--%>
        </ul>
    </div>
    </form>
</body>
</html>
