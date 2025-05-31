<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="QuizLatihan.Views.ProfilePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile Page</title>
</head>
<body>
    <form id="form2" runat="server">
        <h2>User Profile</h2>
         <asp:Label ID="lblWelcome1" runat="server" Font-Bold="true" /><br /><br />

        <h3>Change Password</h3>
        <table>
            <tr>
                <td>Old Password:</td>
                <td>
                    <asp:TextBox ID="txtOldPassword1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>New Password:</td>
                <td>
                    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="BtnChangePassword1" runat="server" Text="Change Password" OnClick="BtnChangePassword_Click"/>
        <asp:Button ID="BtnBack" runat="server" Text="Back" OnClick="BtnBack_Click"/>
        <br /><br />
        <asp:Label ID="lblMessage1" runat="server" ForeColor="Red" />
    </form>
</body>
</html>
