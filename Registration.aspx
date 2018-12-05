<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="CSE445Project5.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Create a Member Account<br />
        <br />
        Username:
        <asp:TextBox ID="userBox" runat="server"></asp:TextBox>
        <br />
        <br />
        Password:
        <asp:TextBox ID="passBox" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        Retype
        <br />
        Password:<asp:TextBox ID="repassBox" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Image ID="Image1" runat="server" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="New Image" />
        <br />
        Verify: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Register" />
    
    </div>
        <asp:Label ID="output" runat="server"></asp:Label>
    </form>
</body>
</html>
