<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPNetLesson1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server" Height="30px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
            <asp:GridView ID="GridView1" runat="server" style="margin-bottom: 2px"></asp:GridView>
            
        </div>
        <asp:TextBox ID="TextBox2" runat="server" Text="CustomerID..."></asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server" Text="City..."></asp:TextBox>
        <asp:TextBox ID="TextBox4" runat="server" Text="Country..."></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="Add" OnClick="Button2_Click" />
        </form>
</body>
</html>
