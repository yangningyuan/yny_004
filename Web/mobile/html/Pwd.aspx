<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pwd.aspx.cs" Inherits="yny_004.Web.mobile.html.Pwd" %>

<div class="content">
    <div class="list-block myinfo">
        <ul>
            <li>
                <a href="javascript:void(0)" onclick="pcallhtml('/mobile/html/ModifyPwd.aspx','登录密码修改');" class="item-link item-content">
                    <div class="item-inner">
                        <div class="item-title">登录密码修改</div>
                    </div>
                </a>
            </li>
            <li>
                <a href="javascript:void(0)" onclick="pcallhtml('/mobile/html/ModifySecPwd.aspx','资金密码修改');" class="item-link item-content">
                    <div class="item-inner">
                        <div class="item-title">资金密码修改</div>
                    </div>
                </a>
            </li>
               <li>
                <a href="javascript:void(0)" onclick="pcallhtmlNoV('/mobile/html/View.aspx','修改资料');" class="item-link item-content">
                    <div class="item-inner">
                        <div class="item-title">修改会员资料</div>
                    </div>
                </a>
            </li>
        </ul>
    </div>
</div>
