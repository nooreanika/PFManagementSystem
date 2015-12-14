<%@ Page Title="" Language="C#" MasterPageFile="~/Main2.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="phy_fac_bard.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <form id="form1" runat="server">
     <h2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Welcome
            <asp:Label ID="Label9" runat="server"></asp:Label>
        </h2>
    <table style="width:100%; height: 201px;">
        <tr>
            <%--<td style="height: 201px; background-image: none;">
                <asp:ImageButton ID="ImageButton3" runat="server" Height="99px" ImageUrl="~/images/addfaci.png" Width="302px" OnClick="ImageButton3_Click" />
                <asp:ImageButton ID="ImageButton4" runat="server" Height="99px" ImageUrl="~/images/update.jpg" Width="302px" />
            </td>--%>
            <td style="height: 201px; background-image: none; width: 302px;">
                <asp:ImageButton ID="ImageButton3" runat="server" Height="204px" ImageUrl="~/images/menu-button-md.png" OnClick="ImageButton3_Click1" Width="295px" />
            </td>
            <td style="height: 201px; background-image: none; width: 302px;">
                <asp:ImageButton ID="ImageButton1" runat="server" Height="202px" ImageUrl="~/images/create.png" OnClick="ImageButton1_Click" Width="302px" />
            </td>
            <td style="height: 201px; background-image: none;">
                <asp:ImageButton ID="ImageButton2" runat="server" Height="202px" ImageUrl="~/images/search.jpg" Width="302px" OnClick="ImageButton2_Click" />
            </td>
        </tr>
    </table>
     </form>
</asp:Content>
