<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="QuizLatihan.Views.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h2>Login Page</h2>
    <div>
        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label><br />
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br /><br />

        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label><br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br /><br />

        <asp:CheckBox ID="chkRemember" runat="server" Text="Remember Me" /><br /><br />

        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" /><br /><br />

        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
