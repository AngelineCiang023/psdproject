<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="QuizLatihan.Views.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Home Page</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="JewelID" HeaderText="JewelID" SortExpression="JewelID" />
            <asp:BoundField DataField="JewelName" HeaderText="JewelName" SortExpression="JewelName" />
            <asp:BoundField DataField="JewelPrice" HeaderText="JewelPrice" SortExpression="JewelPrice" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="Btn_Details" runat="server" Text="Details" OnClick="Btn_Details_Click" UseSubmitBehavior="false" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
