<%@ Page Title="" Language="C#" MasterPageFile="~/Main2.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="phy_fac_bard.Booking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <form id="form1" runat="server">
        <br />
        <br />
        <h2>
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Book New Approvals</asp:LinkButton>
            <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="Large" OnClick="LinkButton1_Click">Cancel Booking</asp:LinkButton>
    &nbsp;&nbsp; </b></h2>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
            <Columns>
                <asp:BoundField DataField="BookID" HeaderText="Booking ID" />
                <asp:BoundField DataField="AppID" HeaderText="Application ID" />
                <asp:BoundField DataField="TimeSlot" HeaderText="Time Slot" />
                <asp:BoundField DataField="BookDate" HeaderText="Booking Date" />
                <asp:BoundField DataField="BookStatus" HeaderText="Status" />
                <asp:BoundField DataField="FaciID" HeaderText="Facility ID" />
                <asp:BoundField DataField="CDate" HeaderText="Cancel Date" />
                <asp:BoundField DataField="username" HeaderText="Booked By" />
                <asp:BoundField DataField="Cusername" HeaderText="Cancel By" />
                <asp:BoundField DataField="CReason" HeaderText="Cancel Reason" />
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
        <br />
        <br />
    </form>
</asp:Content>
