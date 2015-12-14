<%@ Page Title="" Language="C#" MasterPageFile="~/UI/PhysicalFacilityManagement.Master" AutoEventWireup="true" CodeBehind="Approved.aspx.cs" Inherits="PhysicalManagementSystemApp.UI.Approved" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
        <a href="Application.aspx">Approved Applications</a>:
          <asp:Label ID="countLabel" runat="server" Text=""></asp:Label>
       
    <asp:GridView ID="ApprovedGridView" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanging="ApprovedGridView_SelectedIndexChanging" Width="889px" Height="161px" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <Columns>
            <asp:TemplateField HeaderText="SL NO">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="appid" HeaderText="AppID" />
            <asp:BoundField DataField="Asubject" HeaderText="Subject" />
            <asp:BoundField DataField="orgname" HeaderText="Organization" />
            <asp:TemplateField HeaderText="Details" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="More....."></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Full Details">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("appdetails") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("appdetails") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CatName" HeaderText="Category Name" />
            <asp:BoundField DataField="timeslot" HeaderText="Time slot" />
            <asp:BoundField DataField="startdate" HeaderText="start time" />
            <asp:BoundField DataField="enddate" HeaderText="End date" />
            <asp:BoundField DataField="status" HeaderText="Status" />
        </Columns>
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <SortedAscendingCellStyle BackColor="#FAFAE7" />
        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
        <SortedDescendingCellStyle BackColor="#E1DB9C" />
        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
    </asp:GridView>
    <br />
    <br />
  
    <asp:Label ID="headerLabel" runat="server" Text=""></asp:Label><br/>
      <br />
<asp:Label ID="approveLabel" runat="server"></asp:Label><br/>
    <asp:Label ID="nulMsgLabel" runat="server" Text=""></asp:Label><br/>
    <asp:TextBox ID="detailTextBox" runat="server" Height="67px" TextMode="MultiLine" Visible="False" Width="554px"></asp:TextBox>
<br />
     

</asp:Content>
