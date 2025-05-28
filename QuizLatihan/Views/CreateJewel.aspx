<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateJewel.aspx.cs" Inherits="QuizLatihan.Views.CreateJewel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="JewelName" runat="server" Text="Jewel Name"></asp:Label>
            <asp:TextBox ID="TxtJewelName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="JewelCategory" runat="server" Text="Jewel Category"></asp:Label>
            <asp:DropDownList ID="DropDownCategory" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="JewelBrand" runat="server" Text="Jewel Brand"></asp:Label>
            <asp:DropDownList ID="DropDownBrand" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="JewelPrice" runat="server" Text="Jewel Price"></asp:Label>
            <asp:TextBox ID="TxtJewelPrice" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="JewelReleaseYear" runat="server" Text="Release Year"></asp:Label>
            <asp:TextBox ID="TxtReleaseYear" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LblErrorMessage" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="BtnCancel" runat="server" Text="Cancel" Onclick="Button1_Click"/>
            <asp:Button ID="BtnAdd" runat="server" Text="Add Jewel" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
