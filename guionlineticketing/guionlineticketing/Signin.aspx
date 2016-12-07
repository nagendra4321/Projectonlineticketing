<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="guionlineticketing.Signin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style6 {
            width: 307px;
        }
        .auto-style7 {
            height: 62px;
        }
        .auto-style11 {
            width: 276px;
        }
        .auto-style12 {
            margin-right: 0;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnlogin">
    <table align="left" class="auto-style12" >
        <tr>
            <td colspan="2" align="center" class="auto-style7">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Log In</td>
        </tr>
        <tr>
            <td  align="right">User Name:</td>
            <td  >
                <br />
                <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvid" runat="server" ControlToValidate="txtusername" ErrorMessage="Enter a user name" SetFocusOnError="True" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td  align="right" >Password:</td>
            <td  >
                <br />
                <asp:TextBox TextMode="Password" ID="txtpassword" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvnewpass" runat="server" ControlToValidate="txtpassword" ErrorMessage="Enter password" SetFocusOnError="True" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style11">
                <asp:Label ID="lblmsg" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style11" >
                <asp:Button align="right" ID="btnlogin" runat="server" ValidationGroup="submit" Text="Log In" OnClick="btnlogin_Click" />
            </td>
        </tr>
    </table>
        </asp:Panel>
    <br />
</asp:Content>
