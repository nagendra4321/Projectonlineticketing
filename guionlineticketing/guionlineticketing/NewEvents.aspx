<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NewEvents.aspx.cs" Inherits="guionlineticketing.NewEvents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>New Events</h1>
    &nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1"  >
    <Columns>
        
        <asp:BoundField HeaderText="Event ID" DataField="id" Visible="false" InsertVisible="False" ReadOnly="True" SortExpression="id" />
        <asp:BoundField HeaderText="Event Name" DataField="eventname" SortExpression="eventname" />
        <asp:BoundField HeaderText="Event Category" DataField="eventcategory" SortExpression="eventcategory" />
        <asp:BoundField HeaderText="Auditorium Name" DataField="auditoriumname" SortExpression="auditoriumname" />
        <asp:TemplateField HeaderText="view event">
             <ItemTemplate>
                <asp:Button ID="btnview" runat="server" text="view" OnClick="btnview_Click" CommandArgument='<%#Eval("id")%>' />
             </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:onlineticketingConnectionString %>" SelectCommand="SELECT * FROM eventtable e inner join auditoriumtable a on e.auditoriumid=a.id"></asp:SqlDataSource>
</asp:Content>
