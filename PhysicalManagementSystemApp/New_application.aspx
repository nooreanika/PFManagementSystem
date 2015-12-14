<%@ Page Title="" Language="C#" MasterPageFile="~/Main2.Master" AutoEventWireup="true" CodeBehind="New_application.aspx.cs" Inherits="phy_fac_bard.New_application" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <form id="form1" runat="server" style="height: 1016px">
        <br />
        <table style="width:100%; height: 724px; clip: rect(auto, auto, auto, auto); table-layout: auto; empty-cells: hide; border-collapse: collapse; caption-side: bottom; position: relative; border-spacing: inherit; top: 0px; left: 0px;">
            <tr>
                <td style="width: 251px; height: 45px;">

    <asp:Label ID="Label1" runat="server" Text="Application ID" style="font-weight: 700"></asp:Label></td>
                <td style="width: 152px; height: 45px;"><asp:TextBox ID="TextBox1" runat="server" Enabled="False" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                    <br />
                </td>
                <td style="height: 45px; width: 47px">&nbsp;</td>
                <td style="height: 45px">&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
&nbsp;&nbsp;&nbsp; </td>
            </tr>
             <tr>
                <td style="width: 251px; height: 168px;"><strong>&nbsp; Start Date&nbsp;:<br />
                    <asp:TextBox ID="TextBox2" runat="server" Enabled="False" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                    &nbsp; <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="..." />
                    <br />
        <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="125px" OnSelectionChanged="Calendar1_SelectionChanged" ShowGridLines="True" Visible="False" Width="154px">
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
        </asp:Calendar>
                    </strong>
                 </td>
                <td style="width: 152px; height: 168px;">&nbsp;E<strong>nd Date :<br />
                    <asp:TextBox ID="TextBox3" runat="server" Enabled="False"></asp:TextBox>
                    &nbsp; <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="..." />
                    <br />
        <asp:Calendar ID="Calendar2" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="79px" OnSelectionChanged="Calendar2_SelectionChanged" ShowGridLines="True" Visible="False" Width="156px">
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
        </asp:Calendar>
                    </strong>
                 </td>
                <td style="height: 168px; width: 47px;">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                <td style="height: 168px">
                    <br />
                 </td>
            </tr>
            <tr style="float: left; clip: rect(auto, auto, auto, auto)">
                <td style="width: 251px; height: 53px;" align="left">

                    <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Auditorium" Height="26px" Width="110px" />

                </td>
                <td style="width: 152px; height: 53px;" align="left">

                    <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Class" Width="101px" />

                </td>
                <td style="width: 47px; height: 53px" align="left">

                    <asp:Button ID="Button9" runat="server" Text="Lab" OnClick="Button9_Click1" Width="102px" />

                </td>
                <td style="height: 53px" align="left">
                    <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text="Conf Hall" Width="112px" />

                </td>
            </tr>
                
            <tr style="float: left; clip: rect(auto, auto, auto, auto)">
                <td style="width: 251px; height: 164px;" align="left">

                    <br />
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="214px" Height="129px" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Facility ID">
                                <ItemTemplate>
                                    <asp:Label ID="Label15" runat="server" Text='<%# Bind("FaciID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Morning">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox12" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Evening">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox13" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#2461BF" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
                <td style="width: 152px; height: 164px;" align="left">

                    <br />

                    <asp:GridView ID="GridView4" runat="server" CellPadding="4" AutoGenerateColumns="False" Height="127px" Width="211px" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Facility ID">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("FaciID") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label16" runat="server" Text='<%# Bind("FaciID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Morning">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox14" runat="server" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox15" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Evening">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox16" runat="server" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox17" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#666666" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>

                </td>
                <td style="width: 47px; height: 164px" align="left">

                    <br />

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Height="115px" Width="203px" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:TemplateField HeaderText="Facility ID">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("FaciID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label18" runat="server" Text='<%# Bind("FaciID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Morning">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox10" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Evening">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox11" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>

                </td>
                <td style="height: 164px" align="left">
                    <br />

                    <br />

                    <asp:GridView ID="GridView5" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" AutoGenerateColumns="False" Width="167px" ForeColor="Black" GridLines="None" Height="16px">
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                        <Columns>
                            <asp:TemplateField HeaderText="Facility ID">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("FaciID") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label17" runat="server" Text='<%# Bind("FaciID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Morning">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox18" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Evening">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox19" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="Tan" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <PagerStyle ForeColor="DarkSlateBlue" HorizontalAlign="Center" BackColor="PaleGoldenrod" />
                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <SortedAscendingCellStyle BackColor="#FAFAE7" />
                        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                        <SortedDescendingCellStyle BackColor="#E1DB9C" />
                        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                    </asp:GridView>

                    <br />

                </td>
            </tr>
                
            <tr>
                <td style="width: 251px; height: 235px;">
        <asp:Label ID="Label5" runat="server" Text="Subject"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox4" runat="server" Height="27px" Width="202px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Organization Name"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox5" runat="server" Height="42px" Width="203px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Detail"></asp:Label>
                    <asp:TextBox ID="TextBox6" runat="server" TextMode="MultiLine" Height="58px" Width="272px"></asp:TextBox>
       
                    <br />
                </td>
                <td style="width: 152px; height: 235px;">
                    <br />
                    <br />
       
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
                <td style="width: 47px; height: 235px">
        <asp:Label ID="Label7" runat="server" Text="Logistry"></asp:Label>
                    <br />
                    <asp:CheckBox ID="CheckBox4" runat="server" Text="Mike" />
                    <asp:CheckBox ID="CheckBox5" runat="server" OnCheckedChanged="CheckBox5_CheckedChanged" Text="Projector" />
            <asp:CheckBox ID="CheckBox6" runat="server" Text="Speaker" />
                    <asp:CheckBox ID="CheckBox7" runat="server" Text="Multiplug" />
        <asp:CheckBox ID="CheckBox9" runat="server" Text="Others" AutoPostBack="True" />
                    <asp:TextBox ID="TextBox7" runat="server" Visible="False" Height="26px" Width="198px"></asp:TextBox>
                </td>
                <td style="height: 235px">
                    <br />
                </td>
            </tr>
                
            <tr>
                <td style="width: 251px">
                    <br />
                    <asp:Button ID="Button5" runat="server" Text="Submit" OnClick="Button5_Click" style="height: 26px" />
                </td>
                <td style="width: 152px">&nbsp;</td>
                <td style="width: 47px">&nbsp;</td>
                <td>
                    <br />
                </td>
            </tr>
            </table>
        <br />

        <asp:Panel ID="Panel3" runat="server" Height="138px" Font-Bold="True" Font-Size="Medium" Visible="False">
            <br />
            Subject:<asp:Label ID="Label12" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Category"></asp:Label>
            :<asp:Label ID="Label9" runat="server"></asp:Label>
            <br />
            From:<asp:Label ID="Label10" runat="server"></asp:Label>
            <br />
            To:<asp:Label ID="Label11" runat="server"></asp:Label>
            <br />
            Selected
            <asp:Label ID="Label13" runat="server"></asp:Label>
            :<asp:Label ID="Label14" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Confirm" />
            &nbsp;&nbsp;
            <asp:Label ID="Label8" runat="server"></asp:Label>
           
        </asp:Panel>

    <br />
       
        <div>
            </div>
&nbsp;<asp:GridView ID="GridView2" runat="server" Visible="False">
                    </asp:GridView>
                <asp:Panel ID="Panel2" runat="server">
        </asp:Panel>
        
        
    </form>
</asp:Content>
