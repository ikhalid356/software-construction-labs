<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="staff.aspx.cs" Inherits="CMS.staff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <strong>Menu List</strong>
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        <br />
        <strong>Delete Item:</strong>&nbsp;&nbsp;&nbsp;&nbsp; FoodID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="deleteBox" runat="server" Width="33px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="delete_food_btn" runat="server" Text="Delete" OnClick="delete_food_btn_Click" />
        <br />
        <strong>Add Item:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>Food Name:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="foodnameBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Price:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="priceBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="add_food_btn" runat="server" Text="Add" Width="55px" OnClick="add_food_btn_Click" />
        <br />
        <br />
        Order List<asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        <br />
        Order Completed:&nbsp;&nbsp;&nbsp; OrderID:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="orderBox" runat="server" Width="36px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="complete_btn" runat="server" Text="Mark as complete" OnClick="complete_btn_Click" />
    </form>
</body>
</html>
