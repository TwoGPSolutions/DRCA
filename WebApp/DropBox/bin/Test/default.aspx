<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DropBox.Messages"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="Posts" runat="server" method="get" >
    <div>
           <asp:gridview ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1" EnableModelValidation="True"  ShowHeader="False" 
            style="text-align: right" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Messages" SortExpression="mContent">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("mContent") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <table style="width:100%;">
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label1" runat="server" 
                                        style="font-family: 'Courier New', Courier, monospace; font-weight: 700" 
                                        Text='<%# Bind("mContent") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label ID="Label3" runat="server" 
                                        style="font-size: xx-small; font-family: 'Arial Unicode MS'; text-align: left" 
                                        Text='<%# Eval("MAC_ID") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" 
                                        style="font-size: xx-small; font-family: Arial, Helvetica, sans-serif" 
                                        Text='<%# Eval("mTime") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:gridview>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT [mContent], [mTime], [MAC_ID] FROM [msgdb]">
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
