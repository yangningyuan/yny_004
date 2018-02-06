<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Code.aspx.cs" Inherits="yny_004.Web.mobile.html.Code" %>

<div class="page-group">
    <div class="page page-current" id="Register">
        <div class="content Register" style="top: 0;">
            <img src="/mobile/img/ewm.jpg" class="bg" />
            <div class="Register_Info">
                <%--<a class="pull-left back wi"><img src="/mobile/img/back.png"></a>--%>
                <div class="ewmpanel">
                 <div class="tit">
                       <%-- <img src="/mobile/img/ewmtil.png">--%>
                    </div>
                    <div class="ewm">
                        <%--<img src="/mobile/img/ewm.png">--%>

                        <div class="ermw">
                            <div id="qrcode_container">
                                
                            </div>
                        </div>
                    </div>
                  <%--  <div class="ewmbottom">
                        <img src="/mobile/img/ewnbottom.png">
                    </div>--%>

                </div>
            </div>
        </div>
    </div>
</div>
 <script type="text/javascript">
        setTimeout(function () {
		    $('#qrcode_container').qrcode({ width: 250, height: 250, text: toUtf8('<%=base.GetPromoteLinkTel()%>') });
	    }, 50);
    </script>
