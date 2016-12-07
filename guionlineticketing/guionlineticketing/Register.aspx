<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="guionlineticketing.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 627px;
            height: auto;
        }
        .auto-style4 {
            width: auto;
        }
        .auto-style5 {
            width: auto;
            height: 31px;
        }
        .auto-style6 {
            height: 31px;
        }
        .auto-style7 {
            width: auto;
            height: 77px;
        }
        .auto-style8 {
            height: 77px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Registration Form</h1>
    <table align="center";class="auto-style1" style="margin-right: 1px;" class="auto-style1">
            <tr>
                <td class="auto-style4">Name</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txtname" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvname" runat="server" ValidationGroup="submit" ErrorMessage="Enter Name " ControlToValidate="txtname" SetFocusOnError="True" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revname" runat="server" ValidationGroup="submit" ErrorMessage="Enter name in characters or alphabets" ControlToValidate="txtname" ValidationExpression="^[a-zA-Z ]*$" SetFocusOnError="True"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">User ID</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvid" runat="server" ValidationGroup="submit" ErrorMessage="Enter a new user name" ControlToValidate="txtid" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revid" runat="server" ValidationGroup="submit" ErrorMessage="Enter user name in numbers and character and special symbols" ControlToValidate="txtid" SetFocusOnError="True" ValidationExpression="^[a-zA-Z0-9_.-]*$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">New Password</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txtnewpass" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvnewpass" ValidationGroup="submit" runat="server" ErrorMessage="Enter new password" ControlToValidate="txtnewpass" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Confirm New Password</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtconnewpass" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvcomnewpass" ValidationGroup="submit" runat="server" ErrorMessage="Reenter the password" ControlToValidate="txtconnewpass" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cpvpass" runat="server" ValidationGroup="submit" ControlToCompare="txtnewpass" ControlToValidate="txtconnewpass" ErrorMessage="password does not match" SetFocusOnError="True"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Gender</td>
                <td class="auto-style17">
                    <asp:DropDownList ID="ddlgender" runat="server">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                        <asp:ListItem>male</asp:ListItem>
                        <asp:ListItem>female</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvgender" runat="server" ErrorMessage="Select a gender" ValidationGroup="submit" ControlToValidate="ddlgender" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Age</td>
                <td class="auto-style17">
                    <asp:DropDownList ID="ddlage" runat="server">
                        <asp:ListItem Value="1">18</asp:ListItem>
                        <asp:ListItem Value="2">19</asp:ListItem>
                        <asp:ListItem Value="3">20</asp:ListItem>
                        <asp:ListItem Value="4">21</asp:ListItem>
                        <asp:ListItem Value="5">22</asp:ListItem>
                        <asp:ListItem Value="6">23</asp:ListItem>
                        <asp:ListItem Value="7">24</asp:ListItem>
                        <asp:ListItem Value="8">25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvselectage" runat="server" ValidationGroup="submit" ErrorMessage="Select age" ControlToValidate="ddlage" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Security Question</td>
                <td class="auto-style17">
                    <asp:DropDownList ID="ddlquestion" runat="server">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                        <asp:ListItem>What is your favourite car</asp:ListItem>
                        <asp:ListItem>Where do you born?</asp:ListItem>
                        <asp:ListItem>he palce you like the most?</asp:ListItem>
                        <asp:ListItem>your vehicle number?</asp:ListItem>
                        <asp:ListItem>your best friend name</asp:ListItem>
                        <asp:ListItem>your favourite food?</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvquestion" runat="server" ValidationGroup="submit" ErrorMessage="Select a security question" ControlToValidate="ddlquestion" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Security Answer</td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtsecans" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvanswer" runat="server" ValidationGroup="submit" ErrorMessage="Enter answer for security question" ControlToValidate="txtsecans" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ValidationGroup="submit" runat="server" ErrorMessage="Enter answer in numbers and charaters" ControlToValidate="txtsecans" SetFocusOnError="True" ValidationExpression="^[a-zA-Z0-9_.-]*$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Address</td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvaddress" runat="server" ValidationGroup="submit" ErrorMessage="Enter address" ControlToValidate="txtaddress" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revaddress" runat="server" ValidationGroup="submit" ErrorMessage="enter address with out special charecters" ControlToValidate="txtaddress" SetFocusOnError="True" ValidationExpression="^[a-zA-Z0-9_.-/]*$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Email</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvemail" runat="server" ValidationGroup="submit" ErrorMessage="enter email" ControlToValidate="txtemail" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revemail" runat="server" ValidationGroup="submit" ErrorMessage="enter correct email format" ControlToValidate="txtemail" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Phone Number</td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtphonenumber" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvphonenum" runat="server" ValidationGroup="submit" ErrorMessage="enter phone number" ControlToValidate="txtphonenumber" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revphonenum" runat="server" ValidationGroup="submit" ErrorMessage="enter 10 digit phone number" ControlToValidate="txtphonenumber" SetFocusOnError="True" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">DOB(yyyy-mm-dd)</td>
                <td class="auto-style17">
                   
                
                    <asp:TextBox ID="txtdob" runat="server"></asp:TextBox>
                   
                
                    <asp:RequiredFieldValidator ID="rfvdob" runat="server" ValidationGroup="submit" ErrorMessage="enter date of birth" ControlToValidate="txtdob" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revdob" runat="server" ValidationGroup="submit" ErrorMessage="enter date of birth in correct format (yyyy-MM-dd)" ControlToValidate="txtdob" SetFocusOnError="True" ValidationExpression="^\d{4}-((0[1-9])|(1[012]))-((0[1-9]|[12]\d)|3[01])$"></asp:RegularExpressionValidator>
                   
                
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Button ID="btnsubmit" runat="server" ValidationGroup="submit" Text="Submit" OnClick="btnsubmit_Click" />
                </td>
                <td class="auto-style5">
                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
</asp:Content>
