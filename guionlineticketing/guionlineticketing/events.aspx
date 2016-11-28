<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="events.aspx.cs" Inherits="guionlineticketing.events" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:DetailsView ID="dtvevent" runat="server" Height="50px" Width="125px"  >
    </asp:DetailsView>
    <asp:Button ID="btnreserve" runat="server" Text="Reserve" OnClick="btnreserve_Click" CommandArgument='<%#Eval("id")%>' />
    </asp:Content>
