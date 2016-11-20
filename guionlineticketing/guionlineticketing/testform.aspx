<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testform.aspx.cs" Inherits="guionlineticketing.testform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">


*
{ margin: 0;
  padding: 0;}

span
{ color: #B1521A;
  text-shadow: none;}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
                                    <asp:FormView ID="FormView1" runat="server" DataSourceID="testds">
                                        <EditItemTemplate>
                                            eventname:
                                            <asp:TextBox ID="eventnameTextBox" runat="server" Text='<%# Bind("eventname") %>' />
                                            <br />
                                            eventcategory:
                                            <asp:TextBox ID="eventcategoryTextBox" runat="server" Text='<%# Bind("eventcategory") %>' />
                                            <br />
                                            auditoriumid:
                                            <asp:TextBox ID="auditoriumidTextBox" runat="server" Text='<%# Bind("auditoriumid") %>' />
                                            <br />
                                            eventtime:
                                            <asp:TextBox ID="eventtimeTextBox" runat="server" Text='<%# Bind("eventtime") %>' />
                                            <br />
                                            fare:
                                            <asp:TextBox ID="fareTextBox" runat="server" Text='<%# Bind("fare") %>' />
                                            <br />
                                            noofseats:
                                            <asp:TextBox ID="noofseatsTextBox" runat="server" Text='<%# Bind("noofseats") %>' />
                                            <br />
                                            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                                            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                                        </EditItemTemplate>
                                        <InsertItemTemplate>
                                            eventname:
                                            <asp:TextBox ID="eventnameTextBox0" runat="server" Text='<%# Bind("eventname") %>' />
                                            <br />
                                            eventcategory:
                                            <asp:TextBox ID="eventcategoryTextBox0" runat="server" Text='<%# Bind("eventcategory") %>' />
                                            <br />
                                            auditoriumid:
                                            <asp:TextBox ID="auditoriumidTextBox0" runat="server" Text='<%# Bind("auditoriumid") %>' />
                                            <br />
                                            eventtime:
                                            <asp:TextBox ID="eventtimeTextBox0" runat="server" Text='<%# Bind("eventtime") %>' />
                                            <br />
                                            fare:
                                            <asp:TextBox ID="fareTextBox0" runat="server" Text='<%# Bind("fare") %>' />
                                            <br />
                                            noofseats:
                                            <asp:TextBox ID="noofseatsTextBox0" runat="server" Text='<%# Bind("noofseats") %>' />
                                            <br />
                                            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                                            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                                        </InsertItemTemplate>
                                        <ItemTemplate>
                                            eventname:
                                            <asp:Label ID="eventnameLabel" runat="server" Text='<%# Bind("eventname") %>' />
                                            <br />
                                            eventcategory:
                                            <asp:Label ID="eventcategoryLabel" runat="server" Text='<%# Bind("eventcategory") %>' />
                                            <br />
                                            auditoriumid:
                                            <asp:Label ID="auditoriumidLabel" runat="server" Text='<%# Bind("auditoriumid") %>' />
                                            <br />
                                            eventtime:
                                            <asp:Label ID="eventtimeLabel" runat="server" Text='<%# Bind("eventtime") %>' />
                                            <br />
                                            fare:
                                            <asp:Label ID="fareLabel" runat="server" Text='<%# Bind("fare") %>' />
                                            <br />
                                            noofseats:
                                            <asp:Label ID="noofseatsLabel" runat="server" Text='<%# Bind("noofseats") %>' />
                                           
                                            <br />

                                        </ItemTemplate>
                                    </asp:FormView>
                                    <asp:SqlDataSource ID="testds" runat="server" ConnectionString="<%$ ConnectionStrings:onlineticketingConnectionString %>" SelectCommand="SELECT [eventname], [eventcategory], [auditoriumid], [eventtime], [fare], [noofseats], [id] FROM [eventtable] ORDER BY [eventdate], [fare]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
