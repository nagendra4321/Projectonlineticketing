<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="cancelreservation.aspx.cs" Inherits="guionlineticketing.cancelreservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2"  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to cancel this reservation?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>

    <asp:GridView ID="grdcancelreservation" AutoGenerateColumns="false" runat="server">
        <Columns>
        <asp:BoundField HeaderText="id" DataField="id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="false" />
        <asp:BoundField HeaderText="Event Name" DataField="eventname" SortExpression="eventname" />
        <asp:BoundField HeaderText="Event Category" DataField="eventcategory" SortExpression="eventcategory" />
        <asp:BoundField HeaderText="Auditorium Name" DataField="auditoriumname" SortExpression="auditoriumname" />
        <asp:BoundField HeaderText="Event Date" DataField="eventdate" SortExpression="eventdate" />
        <asp:BoundField HeaderText="Fare " DataField="fare" SortExpression="fare" />
        <asp:TemplateField HeaderText="cancel reservation">
             <ItemTemplate>
                <asp:Button ID="btncancel" pos runat="server" text="Cancel" OnClick="btnCancel_Click" OnClientClick = "Confirm()" CommandArgument='<%#Eval("id")%>' />
             </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    </asp:GridView>
</asp:Content>
