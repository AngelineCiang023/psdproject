<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="QuizLatihan.Views.Reports" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transaction Reports</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridViewReport" runat="server" AutoGenerateColumns="true" />
        <br />
        <asp:Button ID="btnExportExcel" runat="server" Text="Export to Excel" OnClick="btnExportExcel_Click" />
    </form>
</body>
</html>
