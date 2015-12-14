<%@ Page Title="" Language="C#" MasterPageFile="~/UI/PhysicalFacilityManagement.Master" AutoEventWireup="true" CodeBehind="Application.aspx.cs" Inherits="PhysicalManagementSystemApp.UI.Application" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        
            <a href="Application.aspx">New Applications</a>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="countLabel" runat="server" Text=""></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Application NO:
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <script src="../Scripts/jquery-2.1.4.min.js"></script>
    <script src="../Scripts/jquery-ui-1.11.4.min.js"></script>
    
        
            &nbsp;:
        <asp:GridView ID="appGridView" runat="server" AutoGenerateColumns="False" Height="177px" Width="896px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSelectedIndexChanging="appGridView_SelectedIndexChanging" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:TemplateField HeaderText="SlNo">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AppID">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("AppId") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("AppId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Subject">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Asubject") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Asubject") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="OrgName" HeaderText="Organization Name" />
                <asp:CommandField HeaderText="Details" SelectText="More..." ShowSelectButton="True" />
                <asp:TemplateField HeaderText="Full Details" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Appdetails") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Appdetails") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("CatName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="catLabel" runat="server" Text='<%# Bind("CatName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TimeSlot" HeaderText="Time Slot" />
                <asp:BoundField DataField="StartDate" HeaderText="Start Date" />
                <asp:BoundField DataField="EndDate" HeaderText="End Date" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:RadioButton ID="appRadioButton" runat="server" AutoPostBack="True" OnCheckedChanged="appRadioButton_CheckedChanged1" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FaciId" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("FaciId") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="facIDLabel" runat="server" Text='<%# Bind("FaciId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
   
 <%-- <asp:TextBox ID="detailTextBox" runat="server" Height="109px" TextMode="MultiLine" Width="481px" Visible="False"></asp:TextBox>--%>
    <asp:Label ID="headerlabel" runat="server" Text=""></asp:Label><br/>
    <asp:Label ID="radionotifyLabel" runat="server" Visible="False"></asp:Label>
    <br/>
    <asp:Label ID="detailsLabel" runat="server" Text=""></asp:Label>
    
     
   
    
         <asp:Label ID="remarkLabel" runat="server" Text="Remark  :"></asp:Label><br/>
         <asp:Label ID="nullMsgLabel" runat="server" Text=""></asp:Label> <br/>
        <asp:TextBox ID="remarkTextBox" runat="server" Height="46px" Width="469px" OnTextChanged="remarkTextBox_TextChanged" ></asp:TextBox><br/>
   
        <asp:Label ID="Label7" runat="server" Text="Label" Visible="False"></asp:Label><br />
        <asp:Label ID="facilityLabel" runat="server" Text="Label" Visible="False"></asp:Label><br/>
    <asp:Label ID="notificLabel" runat="server"></asp:Label>
    <br />
    <asp:Button ID="ApprButton" runat="server" Height="38px" OnClick="ApprButtonButton_Click" Text="Approve" Width="149px" />
       
    
    &nbsp; &nbsp;&nbsp;<asp:Button ID="rejectButton" runat="server" Height="38px" OnClick="rejectButton_Click" Text="Reject" Width="150px" />
    
    
    
      
   <%-- <script>
       
        $(function () {
            $("#<%= dateTextBox.ClientID %>").datepicker({
                dateFormat: "yy/mm/dd"
            });
        });
  </script>--%>
   
</asp:Content>
