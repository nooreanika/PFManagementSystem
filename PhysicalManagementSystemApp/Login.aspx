<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="phy_fac_bard.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <form id="form1" runat="server">
        <br>
      <h1 style="border-style: double; text-decoration: underline">Login</h2>

        <table style="width: 100%; height: 165px;">
            <tr>
                <td style="height: 28px">
    <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>:</td>
                <td style="height: 28px"><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <br />
                </td>
                <td style="height: 28px"></td>
            </tr>
            <tr>
                <td>
    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                    :</td>
                <td><asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
    <asp:Button ID="Button1" runat="server" Text="Submit" Width="71px" OnClick="Button1_Click" />
                </td>
                <td>
        <asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    <br />
        <br />
    <br />
        :<br />
    <br />
    :<br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </form>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
</asp:Content>