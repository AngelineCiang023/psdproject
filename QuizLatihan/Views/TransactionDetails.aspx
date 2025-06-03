<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionDetails.aspx.cs" Inherits="QuizLatihan.Views.TransactionDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transaction Details</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Transaction Detail</h2>
            <asp:Label ID="lblTransactionId" runat="server" Font-Bold="true"></asp:Label>
            <br /><br />
            <asp:GridView ID="GridViewTransactionDetails" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
                    <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="BtnBack" runat="server" Text="Back" Onclick="BtnBack_Click"/>
        </div>
    </form>
</body>
</html>
