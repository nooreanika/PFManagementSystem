<%@ Page Title="" Language="C#" MasterPageFile="~/UI/PhysicalFacilityManagement.Master" AutoEventWireup="true" CodeBehind="BookHistoryByCat.aspx.cs" Inherits="PhysicalManagementSystemApp.UI.BookHistoryByCat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                Category:<asp:DropDownList ID="categoryDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="categoryDropDownList_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Name:<asp:DropDownList ID="nameDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="nameDropDownList_SelectedIndexChanged"></asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td class="auto-style1">
                <asp:LinkButton ID="allLinkButton" runat="server" OnClick="allLinkButton_Click"> All</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br/>
     <p>
        <a href="Application.aspx">Booking History By Category</a>
        </p>
    <br/>
    <asp:GridView ID="detailsGridView" runat="server" Height="190px" Width="898px" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
        <Columns>
            <asp:BoundField DataField="BookingDate" HeaderText="Booking Date" />
            <asp:BoundField DataField="subject" HeaderText="Subject" />
             <asp:BoundField DataField="category" HeaderText="Category" Visible="False" />
            <asp:BoundField DataField="catname" HeaderText="Category Name" Visible="False" />
            <asp:BoundField DataField="startdate" HeaderText="Start Date" />
            <asp:BoundField DataField="EndDate" HeaderText="End Date" />
            <asp:BoundField DataField="TimeSlot" HeaderText="Time Slots" />
            <asp:BoundField DataField="logistic" HeaderText="Support" />
            <asp:BoundField DataField="orgname" HeaderText="Org. Name" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
</asp:GridView>
    
</asp:Content>
