<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="guionlineticketing.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        your orders<asp:Button ID="btncancelres" runat="server" OnClick="btncancelres_Click" Text="Cancel Reservation" />
    </p>
    <p>
        <asp:RadioButton ID="rbnall" runat="server" Text="All Events" GroupName="orders" AutoPostBack="True" Checked="True" OnCheckedChanged="rbnall_CheckedChanged" />
        <asp:RadioButton ID="rbnactive" runat="server" Text="Active Events" GroupName="orders" AutoPostBack="True" OnCheckedChanged="rbnactive_CheckedChanged" />
        <asp:RadioButton ID="rbncancelled" runat="server" Text="Cancelled Events" GroupName="orders" AutoPostBack="True" OnCheckedChanged="rbncancelled_CheckedChanged" />
        <asp:RadioButton ID="rbnpast" runat="server" Text="Past Events" GroupName="orders" AutoPostBack="True" OnCheckedChanged="rbnpast_CheckedChanged" />
        &nbsp;<asp:GridView ID="grdorders" runat="server">
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
        <asp:GridView ID="grdactive" runat="server">
        </asp:GridView>
    <br />
        <asp:GridView ID="grdcancelled" runat="server">
        </asp:GridView>
    <br />
        <asp:GridView ID="grdpastevents" runat="server">
        </asp:GridView>
    </asp:Content>
