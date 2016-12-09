<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="addlocation.aspx.cs" Inherits="guionlineticketing.addlocation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style8 {
            width: 220px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <asp:RadioButtonList ID="rblchoice" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rblchoice_SelectedIndexChanged" >
            <asp:ListItem Text="Add Location" Value="location" Selected="True" />
            <asp:ListItem Text="Add Category" Value="category" />
        </asp:RadioButtonList>
    </p>
   
            <asp:Table ID="tbllocation" runat="server">
              <asp:TableRow runat="server" class="auto-style8">
                <asp:TableCell runat="server">Add Location:</asp:TableCell>
             </asp:TableRow>
              <asp:TableRow runat="server" class="auto-style8">
                <asp:TableCell runat="server">Location Name:</asp:TableCell>
                   <asp:TableCell runat="server">
                   <asp:TextBox ID="txtlocationname" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" >
                <asp:TableCell runat="server">Location Address:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="txtlocationaddress" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" >
                <asp:TableCell runat="server">Number of Seats:</asp:TableCell>
                   <asp:TableCell runat="server">
                   <asp:TextBox ID="txtnoofseats" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" >
                <asp:TableCell runat="server">
                    <asp:Button ID="btnaddlocation" runat="server" Text="Add Location" OnClick="btnaddlocation_Click" />
                </asp:TableCell>
            </asp:TableRow>
                <asp:TableRow runat="server" >
                <asp:TableCell runat="server">
                    <asp:Label ID="lblmsglocation" Text="" runat="server"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

    
        <br />

    
        <asp:Table ID="tblcategory" runat="server">
              <asp:TableRow runat="server" class="auto-style8">
                <asp:TableCell runat="server">Add Event Category:</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" class="auto-style8">
                <asp:TableCell runat="server">Add Category</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="txtcategory" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" class="auto-style8">
                <asp:TableCell runat="server">
                     <asp:Button ID="btnaddcategory" runat="server" Text="Add Category" OnClick="btnaddcategory_Click" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" class="auto-style8">
                <asp:TableCell runat="server">
                    <asp:Label ID="lblmsgcategory" Text="" runat="server"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    
</asp:Content>
