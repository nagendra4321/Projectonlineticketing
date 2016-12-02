<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="events.aspx.cs" Inherits="guionlineticketing.events" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:DetailsView ID="dtvevent" AutoGenerateRows="false" runat="server" Height="50px" Width="125px"  >
        <Fields>
            <asp:BoundField DataField="eventname" HeaderText="Event Name" />
            <asp:BoundField DataField="eventcategory" HeaderText="Event Category" />
            <asp:BoundField DataField="eventdate" HeaderText="Event Date" />
            <asp:BoundField DataField="eventtime" HeaderText="Event Time" />
            <asp:BoundField DataField="noofseats" HeaderText="No Of Seats" />
            <asp:BoundField DataField="fare" HeaderText="Fare" />
            <asp:BoundField DataField="auditoriumname" HeaderText="Auditorium Name" />
            <asp:BoundField DataField="address" HeaderText="Address" />
        </Fields>
    </asp:DetailsView>
    <asp:Button ID="btnreserve" runat="server" Text="Reserve" OnClick="btnreserve_Click" CommandArgument='<%#Eval("id")%>' />
    <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
    </asp:Content>
