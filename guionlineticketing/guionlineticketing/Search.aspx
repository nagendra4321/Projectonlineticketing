<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="guionlineticketing.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 238px;
        }
        .auto-style3 {
            height: 27px;
            width: 238px;
        }
        .auto-style6 {
            width: 175px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Search Events</h1>    
    <table style="width:100%;">
        <tr>
            <td class="auto-style6" >
                <asp:Label ID="lbl_eventname" runat="server" Text="Event Name or Category"></asp:Label>
            &nbsp;</td>
            <td>
                <asp:TextBox ID="txteventname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style6" >
                <asp:Label ID="lbl_eventdate" runat="server" Text="Event Date"></asp:Label>
            </td>
            <td >
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td class="auto-style6" >
                <asp:Label ID="lbl_eventlocation" runat="server" Text="Event Location"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtlocation" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style6" >
                <asp:Button ID="btn_search" runat="server" OnClick="btn_search_Click" Text="Search" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    
    
    
</asp:Content>
