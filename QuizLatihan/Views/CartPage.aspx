<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="QuizLatihan.Views.CartPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shopping Cart</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />

            <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" DataKeyNames="JewelID"
                OnRowCommand="gvCart_RowCommand">
                <Columns>
                    <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" />
                    <asp:BoundField DataField="BrandName" HeaderText="Brand" />
                    <asp:BoundField DataField="JewelPrice" HeaderText="Price" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />

                    <asp:TemplateField HeaderText="Update Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Quantity") %>' Width="50px" />
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="UpdateItem"
                                CommandArgument='<%# Container.DataItemIndex %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <br />

            <asp:Label ID="lblTotal" runat="server" Font-Bold="true" Font-Size="Large" />

            <br /><br />

            <asp:DropDownList ID="ddlPayment" runat="server" />

            <br /><br />

            <asp:Button ID="btnCheckout" runat="server" Text="Checkout" OnClick="btnCheckout_Click" />
            <asp:Button ID="btnClearCart" runat="server" Text="Clear Cart" OnClick="btnClearCart_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back" onClick="btnBack_Click"/>
        </div>
    </form>
</body>
</html>
