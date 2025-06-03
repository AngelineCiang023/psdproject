<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myOrders.aspx.cs" Inherits="QuizLatihan.Views.myOrders" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Orders</title>
    <style>
        table {
            border-collapse: collapse;
            width: 100%;
        }
        th, td {
            padding: 8px;
            border: 1px solid #ccc;
            text-align: left;
        }
        button {
            margin-right: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>My Orders</h2>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
        <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="false" OnRowCommand="gvOrders_RowCommand" OnRowDataBound="gvOrders_RowDataBound">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" DataFormatString="{0:dd MMM yyyy}" />
                <asp:BoundField DataField="PaymentMethod" HeaderText="Payment Method" />
                <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />

                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkDetails" runat="server"
                            NavigateUrl='<%# "TransactionDetails.aspx?transactionId=" + Eval("TransactionID") %>'>
                            View Details
                        </asp:HyperLink>
                        <asp:PlaceHolder ID="phActions" runat="server">
                            <asp:Button ID="btnConfirm" runat="server" Text="Confirm Package" CommandName="Confirm" CommandArgument='<%# Eval("TransactionID") %>' />
                            <asp:Button ID="btnReject" runat="server" Text="Reject Package" CommandName="Reject" CommandArgument='<%# Eval("TransactionID") %>' />
                        </asp:PlaceHolder>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="BtnBack" runat="server" Text="Back" Onclick="BtnBack_Click"/>
    </form>
</body>
</html>
