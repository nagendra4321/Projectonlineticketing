<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="addevent.aspx.cs" Inherits="guionlineticketing.addevent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 290px;
        }
        .auto-style2 {
            width: 290px;
            height: 37px;
        }
        .auto-style3 {
            height: 37px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Add Event</h1>
    <table style="width:100%;">
        <tr>
            <td class="auto-style1">Event Name</td>
            <td>
                <asp:TextBox ID="txteventmane" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Category</td>
            <td>
                <asp:DropDownList ID="ddlcategory" runat="server">
                    <asp:ListItem>Sports</asp:ListItem>
                    <asp:ListItem>Meeting</asp:ListItem>
                    <asp:ListItem>Lecture</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Date</td>
            <td>
                <asp:Calendar ID="caldate" runat="server"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Time</td>
            <td>
                <asp:TextBox ID="txttime" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Location</td>
            <td>
                <asp:DropDownList ID="ddllocation" runat="server" DataSourceID="SqlDataSource1" DataTextField="auditoriumname" DataValueField="id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:onlineticketingConnectionString2 %>" SelectCommand="SELECT [id], [auditoriumname], [noseats], [address] FROM [auditoriumtable]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">No of Seats Available</td>
            <td>
                <asp:TextBox ID="txtnoofseats" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Fare</td>
            <td>
                <asp:TextBox ID="txtfare" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Image</td>
            <td>
                <asp:FileUpload ID="imageupload" runat="server" OnLoad="imageupload_Load" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Button ID="btnaddevent" runat="server" Text="Add Event" OnClick="btnaddevent_Click" />
            </td>
            <td class="auto-style3"></td>
        </tr>
    </table>
</asp:Content>
