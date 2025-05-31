<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HandleOrders.aspx.cs" Inherits="QuizLatihan.Views.HandleOrders" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Handle Orders</title>
    <style>
        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
            padding: 8px;
        }
        th {
            background-color: #f2f2f2;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridViewOrders" runat="server" AutoGenerateColumns="False"
            OnRowCommand="GridViewOrders_RowCommand" DataKeyNames="TransactionID">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" />
                <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="btnAction" runat="server"
                            Text='<%# GetActionText(Eval("TransactionStatus").ToString()) %>'
                            CommandName='<%# GetActionCommand(Eval("TransactionStatus").ToString()) %>'
                            CommandArgument='<%# Container.DataItemIndex %>'
                            Visible='<%# ShowActionButton(Eval("TransactionStatus").ToString()) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>

    <script runat="server">
        protected string GetActionText(string status)
        {
            if (status == "Payment Pending") return "Confirm Payment";
            if (status == "Shipment Pending") return "Ship Package";
            return "";
        }

        protected string GetActionCommand(string status)
        {
            if (status == "Payment Pending") return "ConfirmPayment";
            if (status == "Shipment Pending") return "ShipPackage";
            return "";
        }

        protected bool ShowActionButton(string status)
        {
            return status == "Payment Pending" || status == "Shipment Pending";
        }
    </script>
</body>
</html>
