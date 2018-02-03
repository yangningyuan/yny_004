<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WXChange.aspx.cs" Inherits="yny_004.Web.ChangeMoney.WXChange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #firstPage .M_head {
            line-height: 40px;
            background: #AB5800;
        }

        #secondPage .M_head {
            line-height: 40px;
            background: #f7f7f9;
        }

            #secondPage .M_head span {
                display: inline-block;
                line-height: 40px;
                padding: 0px 26px;
                font-size: 16px;
            }

                #secondPage .M_head span b {
                    color: red;
                }

        #firstPage .M_head span {
            display: inline-block;
            line-height: 40px;
            background: #ab5800;
            color: white;
            padding: 0px 40px 0px 26px;
            background: url(Admin/images/mian.png) no-repeat 140px center;
            font-size: 16px;
        }

        .explain {
            padding: 20px 0px;
            /* border: solid 1px #CFCFCF; */
            border-bottom: solid 1px #E8E8E8;
            margin: 0px 30px;
        }

        .recharge {
            margin: 18px 30px;
        }

        .info {
            overflow: hidden;
            margin-bottom: 18px;
        }

            .info label {
                float: left;
                line-height: 34px;
            }

        .txt {
            float: left;
            width: 50%;
        }

            .txt i {
                display: block;
                color: #ab5800;
                font-style: normal;
            }

            .txt input {
                width: 100%;
            }

            .txt span {
                height: 34px;
                line-height: 34px;
                font-weight: bold;
            }

        .bnext {
            text-align: center;
        }

            .bnext button {
                background: #DFA744;
                color: white;
            }

                .bnext button:hover {
                    background: #BE8B30;
                    color: white;
                }

        .bank_info {
            width: 100%;
            overflow: hidden;
        }

        table tr td label {
            display: inline-block;
            /* margin-bottom: 5px; */
            font-weight: bold;
            white-space: nowrap;
        }

        .bank_info .ts {
            padding: 16px 20px;
            background: #fffdf1;
            color: #ac5800;
            font-size: 15px;
        }

        .bank_info p {
            margin-bottom: 20px;
            font-size: 14px;
            color: black;
        }

        .bank_info table tr td b {
            color: #fd6517;
        }

        .bank_info table tr td i {
            color: #ac5800;
        }

        #txtTel {
            width: 50%;
        }

        @media (max-width: 480px) {
            #txtTel {
                width: 100%;
            }
        }
    </style>

     <script>
        layui.use("upload", function () {
            layui.upload({
                url: '/Admin/UpLoadPic/UploadImage.ashx',
                success: function (res) {
                    console.log(res); //上传成功返回值，必须为json格式
                    if (res.isSuccess) {
                        $("#upimage").attr("src", res.msg);
                        $("#uploadurl").val(res.msg);
                    } else {
                        v5.alert(res.msg, '1', 'true')
                    }
                  }
            });
        });

    </script>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <input type="hidden" id="bankauto" runat="server" />
            <form id="form1">
                <div id="firstPage">
                    <div class="M_head">
                        <span>微信转账充值</span>
                    </div>
                    <ul class="explain">
                    </ul>
                    <div class="recharge">
                        <div class="info">
                            <label>充值金额：</label>
                            <div class="txt">
                                <input type="text" id="txtRealMoney" name="txtRealMoney" style="width: 50%" /><%--<b>.<%=mantissa %></b>--%>
                                <%--   <i>*请严格按照上述金额转账汇款,包括小数点后两位<b>.<%=mantissa %></b>如金额不匹配，则会造成充值延迟到账</i>--%>
                            </div>
                        </div>
                        <div class="info">
                            <label>微信账号：</label>
                            <div class="txt">
                                <input type="text" id="txtTel" runat="server" style="" />请填写微信账号，否则无法到账！
                            </div>
                        </div>
                        <div class="info">
                            <label>预计到账时间：</label>
                            <div class="txt">
                                <span>5分钟</span>
                            </div>
                        </div>
                        <div class="bnext">
                            <button type="button" class="btn" onclick="firstButton()">下一步</button>
                        </div>
                    </div>
                </div>
                <div id="secondPage" style="display: none;">
                    <div class="M_head">
                        <span>微信转账汇款<b>(待付款)</b></span>
                        <input type="hidden" id="getsuiji" runat="server" />
                    </div>
                    <div class="bank_info">
                        <p class="ts">*请通过微信扫码转账</p>
                        <table cellpadding="0" cellspacing="0" class="tab">
                            <tbody>
                                <tr>
                                    <td>
                                        <label>微信二维码：</label></td>
                                    <td>
                                        <img src="/Admin/images/20171220093428.png" /></td>
                                </tr>

                                <tr>
                                    <td>
                                        <label>待支付金额：</label></td>
                                    <td><b><span id="txtmoney"></span></b></td>
                                </tr>
                                <tr>
                                    <td align="right">支付截图:
                                    </td>
                                    <td>
                                        <input type="file" name="upload" class="layui-upload-file">
                                        <input type="hidden" id="uploadurl" name="uploadurl" runat="server" />
                                        <img id="upimage" width="100px;" height="100px" />
                                    </td>
                                </tr>
                                <%--  <tr>
                                    <td>
                                        <label>备注/附言/摘要：</label></td>
                                    <td><i><%=TModel.Tel %></i></td>
                                </tr>--%>
                                <tr>
                                    <td></td>
                                    <td>
                                        <%--   <p>请在汇款【备注/附言】中严格按照要求填写充值附言码：<i><%=TModel.Tel %></i>.不要填写其他字符。否则不能正确到账！<%=WebModel.WebTitle %>会在收到汇款后30分钟内为您入账，在此期间无需联系客服，如有问题我们会主动联系您。</p>--%>
                                        <p style="color: red">为了您能快速入金，请在60分钟之内完成支付，系统会自动给您审核，如果超过60分钟未审核，请联系在线客服。</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <button type="button" class="btn btn-success btn-primary btn-stroke" onclick="SecondButton()">我已打款</button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function firstButton() {

            if ($('#bankauto').val().Trim()=="0")
            {
                layer.alert('您的个人资料尚未绑定，需先绑定后才可继续操作', {
                    skin: 'layui-layer-lan',
                    closeBtn: 0
                }, function(){
                    callhtml('/Member/Modify.aspx','完善资料');onclickMenu();
                    layer.closeAll();
                });
            }
            else if(!$("#txtRealMoney").val().TryInt()){
                v5.error('请输入正确的充值金额', '1', 'true');
            }else if($("#txtRealMoney").val()<100){                
                v5.error('充值金额最少为100', '1', 'true');
            }else if($("#txtTel").val()==""){                
                v5.error('微信账号不能为空', '1', 'true');
            }else{
                $("#firstPage").hide();
                $("#secondPage").show();
                $("#txtmoney").html($("#txtRealMoney").val()-$("#getsuiji").val());
            }
        }
        function SecondButton() {
            if($("#uploadurl").val()=="")
            {
                v5.error('请上传截图', '1', 'true');
            }else{
                v5.confirm("确认您已打款",function(){
                    ActionModel("ChangeMoney/WXChange.aspx?Action=add", $('#form1').serialize(),"ChangeMoney/HKList.aspx");
                })
            }
        }
        function setValidMoney(realobj, validobj) {
            $(validobj).val($(realobj).val() / <%=yny_004.BLL.Configuration.Model.B_InFloat %>);
        }
        function checkChange() {
            if ($('#txtHKDate').val().Trim() == "") {
                v5.error('汇款日期不能为空', '1', 'true');
            } else if ($('#txtBankName').val().Trim() == '') {
                v5.error('汇款人姓名不能为空', '1', 'true');
            } else {
                ActionModel("ChangeMoney/WXChange.aspx?Action=add", $('#form1').serialize());
            }
        }
    </script>
</body>
</html>
