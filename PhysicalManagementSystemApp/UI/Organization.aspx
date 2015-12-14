<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Organization.aspx.cs" Inherits="PhysicalManagementSystemApp.UI.Organization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="orgGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="orgGridView_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="485px" OnRowCancelingEdit="orgGridView_RowCancelingEdit" OnRowEditing="orgGridView_RowEditing" OnRowUpdating="orgGridView_RowUpdating">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
                <asp:CommandField HeaderText="Remove" ShowDeleteButton="True" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
            <asp:Label ID="Label3" runat="server"></asp:Label>
        <br />
        <br />
        <asp:LinkButton ID="addLinkButton" runat="server" OnClick="addLinkButton_Click">Add</asp:LinkButton>
        <br />
        <asp:Panel ID="Panel1" runat="server" Visible="False">
            Name :
            <asp:TextBox ID="nameTextBox" runat="server" OnTextChanged="nameTextBox_TextChanged"></asp:TextBox>
            <br />
            <br />
            Email&nbsp; :<asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="backButton" runat="server" OnClick="backButton_Click" Text="Back" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="saveButton" runat="server" OnClick="saveButton_Click" Text="Save" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="resetButton" runat="server" OnClick="resetButton_Click" Text="Reset" />
            <br />
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
