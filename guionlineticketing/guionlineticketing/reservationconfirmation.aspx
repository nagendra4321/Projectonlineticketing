<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="reservationconfirmation.aspx.cs" Inherits="guionlineticketing.reservationconfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Thank you! your reservation is succesfull</p>
    <p>
       Your  Confirmation Number:<asp:Label ID="lblconfirmationnumber" runat="server" Text="Confirmation Number"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
