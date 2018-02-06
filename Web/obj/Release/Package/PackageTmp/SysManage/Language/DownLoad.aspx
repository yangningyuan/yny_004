<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownLoad.aspx.cs" Inherits="yny_004.Web.Language.DownLoad" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" language="javascript">
        window.onload = function () {
            self.resizeTo(300, 250);
            self.focus();
        }
        setTimeout("self.close()", 3000); 
    </script>
    <style type="text/css">
        .text
        {
            mso-number-format: @;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="dbGridView" runat="server" Height="100%" Width="100%" AutoGenerateColumns="False"
            OnRowDataBound="gvUsers_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="中文名称">
                    <HeaderStyle HorizontalAlign="Center" Width="8%" />
                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                    <ItemTemplate>
                        <%#Eval("ZHName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="外文名称">
                    <HeaderStyle HorizontalAlign="Center" Width="8%" />
                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                    <ItemTemplate>
                        <%#Eval("ENName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="是否启用">
                    <HeaderStyle HorizontalAlign="Center" Width="13%" />
                    <ItemStyle HorizontalAlign="Center" Width="13%" />
                    <ItemTemplate>
                        <%#Eval("Status").ToString()=="1"?"否":"是"%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="语言">
                    <HeaderStyle HorizontalAlign="Center" Width="4%" />
                    <ItemStyle HorizontalAlign="Center" Width="4%" />
                    <ItemTemplate>
                        <%# Eval("Sort").ToString()=="1"?"英语":"日语"%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                没有记录！
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
