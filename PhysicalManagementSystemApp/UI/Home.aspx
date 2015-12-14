<%@ Page Title="Home" Language="C#" MasterPageFile="~/UI/PhysicalFacilityManagement.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PhysicalManagementSystemApp.UI.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Label ID="welcomeLabel" runat="server" Text=""></asp:Label>
    <h3>Notifications</h3>
     <p>You have <asp:Label ID="notificationLabel" runat="server" Text="">
                     
    </asp:Label><asp:LinkButton ID="showAppLinkButton" runat="server" OnClick="showAppLinkButton_Click"> New applications</asp:LinkButton> </p>
</asp:Content>
