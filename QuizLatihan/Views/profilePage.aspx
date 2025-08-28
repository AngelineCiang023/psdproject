<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="QuizLatihan.Views.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
       <div>
       <h1>My Profile</h1>
       <div>
           <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label><br />
           <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label><br />
           <asp:Label ID="lblGender" runat="server" Text="Gender: "></asp:Label><br />
           <asp:Label ID="lblDOB" runat="server" Text="Date of Birth: "></asp:Label><br />
       </div>
       <hr />

       <h3>Change Your Password</h3>
       <div >
           <asp:Label ID="lblOldPassword" runat="server" Text="Enter Old Password: " />
           <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" /><br />
       </div>

       <div>
           <asp:Label ID="lblNewPassword" runat="server" Text="Enter New Password: " />
           <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" /><br />
       </div>
       <div>
           <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm New Password: " />
           <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" /><br /><br />
       </div>

       <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
       <br /><br />
       <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
   </div>
</asp:Content>
