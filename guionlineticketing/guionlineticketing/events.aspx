<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="events.aspx.cs" Inherits="guionlineticketing.events" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 238px;
        }
        .auto-style5 {
            width: 238px;
            height: 27px;
        }
        .auto-style6 {
            height: 27px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style5">
                <asp:Label ID="Label1" runat="server" Text="Event Name"></asp:Label>
            </td>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="lbleventname" runat="server" Text="Event Image"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="lbleventvenue" runat="server" Text="Venue"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="lbleventtime" runat="server" Text="Timings"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="lblseatsavailable" runat="server" Text="Seats Available"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:Button ID="btnreserve" runat="server" Text="Reserve" OnClick="btnreserve_Click" />
</asp:Content>
