<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateJewel.aspx.cs" Inherits="QuizLatihan.Views.UpdateJewel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div>
            <asp:Label runat="server" Text="Jewel Name"></asp:Label>
            <asp:TextBox ID="TxtJewelName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="Category"></asp:Label>
            <asp:DropDownList ID="DropDownCategory" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:Label runat="server" Text="Brand"></asp:Label>
            <asp:DropDownList ID="DropDownBrand" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:Label runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="TxtPrice" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="Release Year"></asp:Label>
            <asp:TextBox ID="TxtReleaseYear" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LblErrorMessage" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
        </div>
    </form>
</body>
</html>
