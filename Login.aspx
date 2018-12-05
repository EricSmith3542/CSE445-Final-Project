<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CSE445Project5.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Login"></asp:Label>
    
    </div>
        <p>
            User:
            <asp:TextBox ID="userTextBox" runat="server"></asp:TextBox>
        </p>
        <p>
            Password:
            <asp:TextBox ID="passTextBox" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="loginButton" runat="server" OnClick="loginButton_Click" Text="Login" />
&nbsp;</p>
        <asp:Label ID="outputLabel" runat="server"></asp:Label>
    </form>
</body>
</html>
