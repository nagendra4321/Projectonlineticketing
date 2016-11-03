<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="reservation.aspx.cs" Inherits="guionlineticketing.reservation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 300px;
        }
        .auto-style5 {
            width: 300px;
            height: 27px;
        }
        .auto-style6 {
            height: 27px;
        }
        .auto-style7 {
            width: 297px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Personal Information<br />
    <br />
    <table style="width:100%;">
        <tr>
            <td class="auto-style4">Name</td>
            <td>
                <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Event</td>
            <td>Event Name will be displayed here</td>
        </tr>
        <tr>
            <td class="auto-style4">Date</td>
            <td>Event Date will be displayed here</td>
        </tr>
        <tr>
            <td class="auto-style5">Timing</td>
            <td class="auto-style6">Event TIme will be displayed here</td>
        </tr>
        <tr>
            <td class="auto-style4">Email</td>
            <td>
                <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Phone Number</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtphonenum" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Contact Address</td>
            <td>
                <asp:TextBox ID="txtcontactinfo" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    Credit Card details<br />
    <br />
    <table style="width:100%;">
        <tr>
            <td class="auto-style7">Name on the card</td>
            <td>
                <asp:TextBox ID="txtcardname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Credit/Debit card number</td>
            <td>
                <asp:TextBox ID="txtcardnumber" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">CVV</td>
            <td>
                <asp:TextBox ID="txtcvv" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Expiration date</td>
            <td>
                <asp:TextBox ID="txtExpirationdate" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnconfirm" runat="server" Text="Confirm Reservation" OnClick="btnconfirm_Click" />
</asp:Content>
