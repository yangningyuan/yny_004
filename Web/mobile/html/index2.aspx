<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index2.aspx.cs" Inherits="yny_004.Web.mobile.html.index2" %>

<div class="row row1">
                    <div>
                        <img src="/mobile/img/轮播.png" />
                    </div>
                </div>
                <div class="notice_content">
                    <div class="news_panel">
                        <i class="iconfont">&#xe61b;</i>
                    </div>
                    <div class="news">
                        <marquee behavior="scroll" direction="left" scrolldelay="150"><%=noticecontent %></marquee>
                    </div>
                </div>
                <div class="qicon"><span>快捷图标</span></div>

                <div class="row margin-top-buttom">
                    <input id="MyLink" runat="server" />
                    <ul class="indexMenuList">
                        <li>
                            <a href="javascript:pcallhtml('/mobile/html/Code.aspx','二维码');" class="regist"><i class="iconfont">&#xe683;</i> <p>注册</p></a>
                        </li>
                        <li>
                            <a href="javascript:pcallhtml('/mobile/html/TXList.aspx','提现');" class="tixian"><i class="iconfont">&#xe624;</i> <p>提现</p></a>
                        </li>
                        <li>
                            <a href="javascript:pcallhtml('/mobile/html/HBList.aspx','转账');" class="zhuanzhang"><i class="iconfont">&#xe63f;</i> <p>转账</p></a>
                        </li>
                        <li>
                            <a href="" class="qiandao"><i class="iconfont">&#xe635;</i> <p>签到</p></a>
                        </li>
                    </ul>
                </div>
                <ul class="i_list overflow">
                    <li>
                        <a href="javascript:pcallhtml('/mobile/html/NoticeList.aspx','公告');" class="external">
                            <span>系统公告</span>
                        </a>
                    </li>
                    <li>
                        <a href="javascript:pcallhtml('/mobile/html/LuckList.aspx','抢红包');" class="external">
                            <span>红包区</span>
                        </a>
                    </li>
                </ul>
                <ul class="i_pay overflow box_shadow">
                    <li>
                        <span><%=yny_004.BLL.Reward.List["MHB"].RewardName %></span>
                         <p><%=TModel.MConfig.MHB.ToFixedDecimal(2) %></p>
                    </li>
                    <li>
                        <span><%=yny_004.BLL.Reward.List["MJB"].RewardName  %></span> 
                        <p><%=TModel.MConfig.MJB.ToFixedDecimal(2) %></p>
                    </li>
                </ul>
<script>
    $('.qiandao').on('click', function () {
        $('.i_opticy').css('display', 'block');
        $('.i_signIn').css('display', 'block')
    })
</script>