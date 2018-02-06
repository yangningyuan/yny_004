<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeList.aspx.cs" Inherits="yny_004.Web.mobile.html.NoticeList" %>

<div class="content Notice pull-to-refresh-content native-scroll infinite-scroll infinite-scroll-bottom" data-distance="55" data-ptr-distance="55" id="index">
    <!-- 默认的下拉刷新层 -->
    <div class="pull-to-refresh-layer">
        <div class="preloader"></div>
        <div class="pull-to-refresh-arrow"></div>
    </div>
    <div class="content-block-title"><%=DateTime.Now.DayOfWeek %>，<%=DateTime.Now.Day %>，<%=DateTime.Now.Month %>，<%=DateTime.Now.Year %></div>
    <div class="list-block myinfo">
        <ul>
            <asp:repeater id="repNoticeList" runat="server">
                                                        <ItemTemplate>
                                                         
                                                          <li class="item-content">
                                                            <div class="item-inner create-actions">
                                                                <div class="item-title"  onclick="noticedetails('<%#Eval("ID")%>','<%#Eval("NTitle")%>')">
                                                                   <%#Eval("NTitle")%>
									
                                                                    <p><%#Eval("NCreateTime","{0:yyyy-MM-dd}")%></p>
                                                                </div>
                                                            </div>
                                                        </li>
                                                        </ItemTemplate>
                                                    </asp:repeater>

        </ul>
    </div>

    <script>
        //iframe层
        function noticedetails(obj,title)
        {
            layer.open({
                type: 2,
                title: title,
                shadeClose: true,
                shade: 0.8,
                area: ['90%', '50%'],
                content: '/mobile/html/NoticeView.aspx?id='+obj //iframe的url
            });
        }
    </script>
    <!-- 加载提示符 -->
