<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="QuizLatihan.Views.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Email_Txt" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="Email_Tb" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Username_Label" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox ID="Username_Tb" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Password_Label" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="Password_Tb" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="ConfirmPassword_Label" runat="server" Text="Confirm Password:"></asp:Label>
            <asp:TextBox ID="ConfirmPassword_Tb" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Gender_Label" runat="server" Text="Gender:"></asp:Label><br />
            <asp:RadioButtonList ID="Gender_Rbl" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div>
             <asp:Label ID="Label1" runat="server" Text="Date of Birth:"></asp:Label>
            <asp:TextBox ID="BirthDate_Tb" runat="server" TextMode="Date" />
        </div>
        <div>
            <asp:Button ID="Register_Btn" runat="server" Text="Register" OnClick="Register_Btn_Click" />
        </div>
        <div>
            <asp:Label ID="Validasi" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
