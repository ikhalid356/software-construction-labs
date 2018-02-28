<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="lab4.user" %>

<!DOCTYPE html>

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
    <h1>Enter your information</h1>
    <form id="form1" runat="server">

        <asp:Label ID="ErrorBox" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />

        Enter your first Name:

        <asp:TextBox ID="fnameBox" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <br />
        Enter your last name:
        <asp:TextBox ID="lnameBox" runat="server" TextMode="Password"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        Enter your bank balance:
        <asp:TextBox ID="bankBox" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        
        <asp:Button ID="submit_btn" runat="server" Text="Submit" style="margin-top: 11px" OnClick="submit_btn_Click" />
    </form>
</body>
</html>