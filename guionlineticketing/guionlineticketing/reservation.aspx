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
        .auto-style8 {
            margin-top: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Personal Information<br />
    <br />
    <table style="width:100%;">
        <tr>
            <td class="auto-style5">User Id</td>
            <td class="auto-style6">
                <asp:Label ID="lbluserid" runat="server" Text="Guest"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Name</td>
            <td>
                <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvusername" ValidationGroup="reserve" runat="server" ErrorMessage="Enter Name" ControlToValidate="txtname"></asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="revname" ValidationGroup="reserve"  runat="server" ErrorMessage="Enter name in characters or alphabets" ControlToValidate="txtname" ValidationExpression="^[a-zA-Z ]*$" SetFocusOnError="True"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Event</td>
            <td class="auto-style6">
                <asp:Label ID="lbleventname" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Date</td>
            <td>
                <asp:Label ID="lbleventdate" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Timing</td>
            <td class="auto-style6">
                <asp:Label ID="lbleventtime" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Email</td>
            <td>
                <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvemail" ValidationGroup="reserve" runat="server" ErrorMessage="Enter Emailid" ControlToValidate="txtemail"></asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="revemail" ValidationGroup="reserve" runat="server" ErrorMessage="enter correct email format" ControlToValidate="txtemail" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Phone Number</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtphonenum" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvnumber" ValidationGroup="reserve" runat="server" ErrorMessage="Enter phone number" ControlToValidate="txtphonenum"></asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="revphonenum" ValidationGroup="reserve" runat="server" ErrorMessage="enter 10 digit phone number" ControlToValidate="txtphonenum" SetFocusOnError="True" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Contact Address</td>
            <td>
                <asp:TextBox ID="txtcontactinfo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvaddress" ValidationGroup="reserve" runat="server" ErrorMessage="Enter Contact Address" ControlToValidate="txtcontactinfo"></asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="revaddress" ValidationGroup="reserve" runat="server" ErrorMessage="enter address with out special charecters" ControlToValidate="txtcontactinfo" SetFocusOnError="True" ValidationExpression="^[a-zA-Z0-9_.-/]*$"></asp:RegularExpressionValidator>
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
                <asp:RequiredFieldValidator ID="rfvcardname" ValidationGroup="reserve" runat="server" ErrorMessage="Enter Name on the card" ControlToValidate="txtcardname"></asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="revcardname" ValidationGroup="reserve" runat="server" ErrorMessage="Enter name in characters or alphabets" ControlToValidate="txtcardname" ValidationExpression="^[a-zA-Z ]*$" SetFocusOnError="True"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Credit/Debit card number</td>
            <td>
                <asp:TextBox ID="txtcardnumber" runat="server" CssClass="auto-style8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvcardnumber" ValidationGroup="reserve" runat="server" ErrorMessage="Enter card Number" ControlToValidate="txtcardnumber"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revcardnum" ValidationGroup="reserve" runat="server" ControlToValidate="txtcardnumber" ErrorMessage="Enter Your 16 digit card number correctly" ValidationExpression="\d{16}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">CVV</td>
            <td>
                <asp:TextBox ID="txtcvv" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvcvv" ValidationGroup="reserve" runat="server" ErrorMessage="Enter CVV of the card" ControlToValidate="txtcvv"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revcardnum0" ValidationGroup="reserve" runat="server" ControlToValidate="txtcvv" ErrorMessage="Enter Your 3 digit card CVV number correctly" ValidationExpression="\d{3}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Expiration date(MM/YYYY)</td>
            <td>
                <asp:TextBox ID="txtExpirationdate" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvexpirationdate" ValidationGroup="reserve" runat="server" ErrorMessage="Enter Expiration date of the card" ControlToValidate="txtExpirationdate"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rexexpdate" ValidationGroup="reserve" runat="server" ControlToValidate="txtExpirationdate" ErrorMessage="Enter your expiration date in (MM/YYYY) format" ValidationExpression="^(0[1-9]|1[0-2])/(19|2[0-1])\d{2}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnconfirm" runat="server" ValidationGroup="reserve" Text="Reserve" OnClick="btnconfirm_Click"  />
</asp:Content>
