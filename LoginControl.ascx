<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControl.ascx.cs" Inherits="WebApplication1.LoginControl" %>
<table id="MyTable" cellpadding="4" runat="server">
    <tr>
        <td>User Name:</td>
        <td>
            <asp:TextBox ID="MyUserName" runat="server" />
        </td>
    </tr>
    <tr>
        <td>Password:</td>
        <td>
            <asp:TextBox ID="MyPassword" TextMode="password" runat="server" />
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:LinkButton ID="LogIn" Text="Log In" runat="server" /></td>
    </tr>
</table>
