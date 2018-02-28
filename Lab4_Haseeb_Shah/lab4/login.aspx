<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="lab4.login" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 422px;
        }
    </style>
</head>
<body>
    <h1>Login or Register</h1>
    <form id="form1" runat="server">

        <asp:Label ID="ErrorBox" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />

        Email:

        <asp:TextBox ID="emailBox" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        Password:
        <asp:TextBox ID="passwordBox" runat="server" TextMode="Password"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
        User Type:
        <asp:DropDownList ID="typeBox" runat="server" OnSelectedIndexChanged="typeBox_SelectedIndexChanged">
            <asp:ListItem Selected="True">admin</asp:ListItem>
            <asp:ListItem>user</asp:ListItem>
        </asp:DropDownList>
        <br />
        
        <asp:Button ID="login_btn" runat="server" Text="Login" style="margin-top: 11px" OnClick="login_btn_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        OR&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="register_btn" runat="server" Text="Register" OnClick="register_btn_Click" />
    </form>
</body>
</html>