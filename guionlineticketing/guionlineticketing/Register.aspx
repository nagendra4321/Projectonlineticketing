<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="guionlineticketing.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 627px;
            height: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Registration Form</h1>
    <table align="center";class="auto-style1" style="margin-right: 1px;" class="auto-style1">
            <tr>
                <td class="auto-style16">Name</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txtname" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style16">User ID</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style16">New Password</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txtnewpass" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style16">Confirm New Password</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txtconnewpass" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style16">Gender</td>
                <td class="auto-style17">
                    <asp:DropDownList ID="ddlgender" runat="server">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style16">Age</td>
                <td class="auto-style17">
                    <asp:DropDownList ID="ddlage" runat="server">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                        <asp:ListItem Value="1">18</asp:ListItem>
                        <asp:ListItem Value="2">19</asp:ListItem>
                        <asp:ListItem Value="3">20</asp:ListItem>
                        <asp:ListItem Value="4">21</asp:ListItem>
                        <asp:ListItem Value="5">22</asp:ListItem>
                        <asp:ListItem Value="6">23</asp:ListItem>
                        <asp:ListItem Value="7">24</asp:ListItem>
                        <asp:ListItem Value="8">25</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style16">Security Question</td>
                <td class="auto-style17">
                    <asp:DropDownList ID="ddlquestion" runat="server">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">Security Answer</td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtsecans" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style16">Address</td>
                <td class="auto-style17">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style16">Email</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">Phone Number</td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtphonenumber" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style16">DOB</td>
                <td class="auto-style17">
                   
                
                    <asp:TextBox ID="txtdob" runat="server"></asp:TextBox>
                   
                
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" />
                </td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
        </table>
</asp:Content>
