<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="guionlineticketing.Signin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style5 {
            height: 59px;
            width: 307px;
        }
        .auto-style6 {
            width: 307px;
        }
        .auto-style7 {
            height: 62px;
        }
        .auto-style9 {
            height: 59px;
            width: 276px;
        }
        .auto-style11 {
            width: 276px;
        }
        .auto-style12 {
            height: 43px;
            width: 307px;
        }
        .auto-style13 {
            height: 43px;
            width: 276px;
        }
        .auto-style14 {
            width: 100%;
            margin-left: 198;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Panel ID="pnlDefault" runat="server" DefaultButton="btnlogin">
    <table align="left" >
        <tr>
            <td colspan="2" align="center" class="auto-style7">Log In</td>
        </tr>
        <tr>
            <td class="auto-style5" align="right">User Name:</td>
            <td class="auto-style9" >
                <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style12" align="right" >Password:</td>
            <td class="auto-style13" >
                <asp:TextBox TextMode="Password" ID="txtpassword" runat="server"></asp:TextBox>
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
                <asp:Button align="right" ID="btnlogin" runat="server" Text="Log In" OnClick="btnlogin_Click" />
            </td>
        </tr>
    </table>
        </asp:Panel>
    <br />
</asp:Content>
