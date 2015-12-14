<%@ Page Title="View Details" Language="C#" MasterPageFile="~/UI/PhysicalFacilityManagement.Master" AutoEventWireup="true" CodeBehind="ViewDetailsByTime.aspx.cs" Inherits="PhysicalManagementSystemApp.UI.ViewDetailsByTime" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    
    <style type="text/css">
        .auto-style1 {
            width: 172px;
        }
    </style>
   
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/jquery-2.1.4.min.js"></script>
    <script src="../Scripts/jquery-ui-1.11.4.min.js"></script>
    <table>
        <tr>
            <td>
                Type :
            </td>
            <td class="auto-style1">
                <asp:DropDownList ID="typeDropDownList" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Month :
                
            </td>
            <td class="auto-style1">
                <asp:DropDownList ID="monthDropDownList" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="1">January</asp:ListItem>
                    <asp:ListItem Value="2">February</asp:ListItem>
                    <asp:ListItem Value="3">March</asp:ListItem>
                    <asp:ListItem Value="4">April</asp:ListItem>
                    <asp:ListItem Value="5">May</asp:ListItem>
                    <asp:ListItem Value="6">June</asp:ListItem>
                    <asp:ListItem Value="7">July</asp:ListItem>
                    <asp:ListItem Value="8">Augest</asp:ListItem>
                    <asp:ListItem Value="9">September</asp:ListItem>
                    <asp:ListItem Value="10">October</asp:ListItem>
                    <asp:ListItem Value="11">November</asp:ListItem>
                    <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList>
                
            </td>
            <td>
                Year :
            
                <asp:DropDownList ID="yearDropDownList" runat="server" AutoPostBack="True">
                    <asp:ListItem>2010</asp:ListItem>
                    <asp:ListItem>2011</asp:ListItem>
                    <asp:ListItem>2012</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2020</asp:ListItem>
                    <asp:ListItem>2021</asp:ListItem>
                    <asp:ListItem>2022</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Date From :
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="fromTextBox" runat="server" Height="26px" Width="170px"></asp:TextBox>
            </td>
            <td>Date TO :&nbsp; </td>
            <td>
                <asp:TextBox ID="toTextBox" runat="server" Height="26px" Width="152px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            </td>
        </tr>
    </table>
    <br/><br/>
    <asp:GridView ID="detailsGridView" runat="server" Height="176px" Width="827px"></asp:GridView>
    <script>
        $(function () {
            $("#<%= fromTextBox.ClientID %>").datepicker({
                dateFormat: "yy/mm/dd"
            });
        });
        $(function () {
            $("#<%= toTextBox.ClientID %>").datepicker({
                dateFormat: "yy/mm/dd"
            });
        });
  </script>

    
</asp:Content>
