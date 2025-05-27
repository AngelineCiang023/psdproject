<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JewelDetailPage.aspx.cs" Inherits="QuizLatihan.Views.JewelDetailPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Jewel Details</h2>
            <asp:Label ID="Lbl_JewelID" runat="server" Text="JewelID: " />
            <br />
            <asp:Label ID="Lbl_JewelName" runat="server" Text="JewelName: " />
            <br />
            <asp:Label ID="Lbl_JewelPrice" runat="server" Text="JewelPrice: " />
            <br />
            <asp:Label ID="Lbl_CategoryName" runat="server" Text="CategoryName: " />
            <br />
            <asp:Label ID="Lbl_BrandName" runat="server" Text="BrandName: " />
            <br />
            <asp:Label ID="Lbl_BrandCountry" runat="server" Text="BrandCountry: " />
            <br />

            <asp:Button ID="Btn_AddToCart" runat="server" Text="Add To Cart" OnClick="Btn_AddToCart_Click" />
            <br />
            <asp:Button ID="Btn_Edit" runat="server" Text="Edit" OnClick="Btn_Edit_Click" />
            <br />
            <asp:Button ID="Btn_Delete" runat="server" Text="Delete" OnClick="Btn_Delete_Click" />
        </div>
    </form>
</body>
</html>
