<%@ Page Title="" Language="C#" MasterPageFile="~/Main2.Master" AutoEventWireup="true" CodeBehind="Add_facility.aspx.cs" Inherits="phy_fac_bard.Add_facility" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <form id="form1" runat="server">
        <br>
        <h2 style="text-decoration: underline; vertical-align: middle">Add Facility</h2>
    <table style="width:100%;">
        <tr>
            <td style="width: 322px">Category:</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Auditorium</asp:ListItem>
                    <asp:ListItem>Class</asp:ListItem>
                    <asp:ListItem>Lab</asp:ListItem>
                    <asp:ListItem>Conference Hall</asp:ListItem>
                </asp:DropDownList>
&nbsp;&nbsp;
                <br />
            </td>

            <td rowspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 322px">Facility ID:</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 322px">Category Name:</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 322px; height: 175px;">Details:</td>
            <td style="height: 175px">
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                &nbsp;
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Suggestions" />
                <br />
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Height="118px" Width="325px">
                    <Columns>
                        <asp:TemplateField HeaderText="Details">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("CatDetails") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" OnCheckedChanged="RadioButton1_CheckedChanged1" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 322px">Actual Price:</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" AutoPostBack="True" OnTextChanged="TextBox5_TextChanged"></asp:TextBox>
                <br />
            </td>
            <tr>
            <td style="width: 322px">Discount Price:</td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                <br />
                </td>
        </tr>
            <tr>
            <td style="width: 322px">&nbsp;</td>
            <td>
                &nbsp;
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
&nbsp;
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Back" />
&nbsp;
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                </td>
        </tr>
        </tr>
    </table>

    </form>
</asp:Content>
