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
            <asp:Label ID="Lbl_JewelID" runat="server" Text="Jewel ID: " />
            <br />
            <asp:Label ID="Lbl_JewelName" runat="server" Text="Jewel Name: " />
            <br />
            <asp:Label ID="Lbl_JewelPrice" runat="server" Text="Jewel Price: " />
            <br />
            <asp:Label ID="Lbl_CategoryName" runat="server" Text="Category Name: " />
            <br />
            <asp:Label ID="Lbl_BrandName" runat="server" Text="Brand Name: " />
            <br />
            <asp:Label ID="Lbl_BrandClass" runat="server" Text="Brand Class: "></asp:Label>
            <br />
            <asp:Label ID="Lbl_BrandCountry" runat="server" Text="Brand Country: " />
            <br />
            <asp:Label ID="Lbl_ReleaseYear" runat="server" Text="Release Year: "></asp:Label>
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
