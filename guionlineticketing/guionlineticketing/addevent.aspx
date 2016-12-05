<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="addevent.aspx.cs" Inherits="guionlineticketing.addevent" %>
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
                <asp:RequiredFieldValidator ID="rfveventname" runat="server" ControlToValidate="txteventmane" ErrorMessage="Enter Name" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="reveventname" runat="server" ControlToValidate="txteventmane" ErrorMessage="Enter valid Name with Aplhabets" SetFocusOnError="True" ValidationExpression="[a-zA-Z]+"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Categoryy</td>
            <td>
                <asp:DropDownList ID="ddlcategory" runat="server" DataSourceID="categoryDataSource3" DataTextField="categoryname" DataValueField="categoryname">
                    <asp:ListItem>Sports</asp:ListItem>
                    <asp:ListItem>Meeting</asp:ListItem>
                    <asp:ListItem>Lecture</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="categoryDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:onlineticketingConnectionString %>" SelectCommand="SELECT [categoryname] FROM [eventcategory]"></asp:SqlDataSource>
                <asp:RequiredFieldValidator ID="rfvcategory" runat="server" ControlToValidate="ddlcategory" ErrorMessage="choose one category" SetFocusOnError="True"></asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ID="rfvtime" runat="server" ControlToValidate="txttime" ErrorMessage="enter time" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revtime" runat="server" ControlToValidate="txttime" ErrorMessage="enter a valid 24 hours time format with hours and minutes Example 13:44" SetFocusOnError="True" ValidationExpression="^([0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Location</td>
            <td>
                <asp:DropDownList ID="ddllocation" runat="server" DataSourceID="SqlDataSource1" DataTextField="auditoriumname" DataValueField="id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:onlineticketingConnectionString2 %>" SelectCommand="SELECT [id], [auditoriumname], [noseats], [address] FROM [auditoriumtable]"></asp:SqlDataSource>
                <asp:RequiredFieldValidator ID="rfvlocation" runat="server" ControlToValidate="ddllocation" ErrorMessage="Select a Location" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">No of Seats Available</td>
            <td>
                <asp:TextBox ID="txtnoofseats" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvseats" runat="server" ControlToValidate="txtnoofseats" ErrorMessage="Enter no of seats" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revnoofseats" runat="server" ControlToValidate="txtnoofseats" ErrorMessage="Enter number of seats as number format" SetFocusOnError="True" ValidationExpression="^[0-9]{1,3}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Fare</td>
            <td>
                <asp:TextBox ID="txtfare" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvfare" runat="server" ControlToValidate="txtfare" ErrorMessage="Enter fare amount" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revfare" runat="server" ControlToValidate="txtfare" ErrorMessage="enter fare in number format" SetFocusOnError="True" ValidationExpression="^[+]?([0-9]+(?:[\.][0-9]*)?|\.[0-9]+)$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Image</td>
            <td>
                <asp:FileUpload ID="imageupload" runat="server" OnLoad="imageupload_Load" Enabled="False" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Button ID="btnaddevent" runat="server" Text="Add Event" OnClick="btnaddevent_Click" />
            </td>
            <td class="auto-style3">
                <asp:Label ID="lblmsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
