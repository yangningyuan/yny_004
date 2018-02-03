<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskAdd.aspx.cs" Inherits="yny_004.Web.mobile.html.TaskAdd" %>

<div class="content content-padded">
    <div class="list-block myinfo">
        <form id="form1">
            <ul>
                <!-- Text inputs -->

                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">邮件类型</div>
                            <div class="item-input">
                                <select id="ddlTType" runat="server">
                                    <option value="003">账户问题</option>
                                    <option value="004">充值问题</option>
                                    <option value="005">提现问题</option>
                                </select>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">邮件</div>
                            <div class="item-input">
                                <label class="label-checkbox item-content">
                                    <textarea id="txtMessage" runat="server" class="msg_input" type="text" maxlength="500"
                                        style="width: 300px; height: 120px;"></textarea>
                                </label>

                            </div>
                        </div>
                    </div>
                </li>

            </ul>
        </form>
    </div>
    <div class="content-block">
        <div class="row">
            <div class="col-100">
                <a href="javascript:checkChange();" class="button button-big button-fill button-success">提交</a>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    function checkChange() {
        if ($('#txtMessage').val().trim() == "") {
            layer.msg("邮件内容不能为空");

            return;
        } else {
            ActionModel("mobile/html/TaskAdd.aspx?Action=add", $('#form1').serialize());
        }
    }
</script>
