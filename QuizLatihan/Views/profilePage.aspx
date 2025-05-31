<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profilePage.aspx.cs" Inherits="QuizLatihan.Views.profilePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>My Profile</h2>
        <asp:Label ID="LblWelcome" runat="server" Font-Bold="true" />

        <h3>Change Password</h3>
        <table>
            <tr>
                <td>Old Password</td>
                <td><asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" /></td>
            </tr>
            <tr>
                <td>New Password</td>
                <td><asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" /></td>
            </tr>
            <tr>
                <td>Confirm Password</td>
               <td><asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" /></td>
            </tr>
        </table>
        <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
        <asp:Button ID="Btnback" runat="server" Text="Back" Onclick="Btnback_Click" />
        <br />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
