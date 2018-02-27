<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="CMS.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 313px;
        }
    </style>
</head>
<body style="height: 550px">
    <form id="form1" runat="server">
    <div>
    
    </div>
    <h1 style="text-align:center; background-color: powderblue; font-size: xx-large; height: 61px; margin-top: 0px;">Our Menu</h1>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Height="109px" Width="672px">
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
 				<Columns>
					<asp:BoundField DataField="FoodID" HeaderText="ID" />
					<asp:BoundField DataField="FName" HeaderText="Item" />
					<asp:BoundField DataField="Price" HeaderText="Price" />
					
                    <asp:ButtonField Text="Order" CommandName="Select" ItemStyle-Width="30"  />
				</Columns>
        </asp:GridView>
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" style="margin-bottom: 32px" Text="Place an order" />
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" Width="673px">
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
 				<Columns>
					<asp:BoundField DataField="FoodID" HeaderText="ID" />
					<asp:BoundField DataField="FName" HeaderText="Item" />
					<asp:BoundField DataField="Price" HeaderText="Price" />
					
                    <asp:ButtonField Text="Remove" CommandName="Select" ItemStyle-Width="30"  />
				</Columns>
        </asp:GridView>
    </form>
    </body>
</html>
