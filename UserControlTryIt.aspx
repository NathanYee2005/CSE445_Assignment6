<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserControlTryIt.aspx.cs" Inherits="WebApplication1.UserControlTryIt" %>
<%@ Register TagPrefix="user" TagName="LoginControl" src="LoginControl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Control TryIt Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>User Control Login Page - TryIt Page</h1>
            <p>
                This page allows you to test the login User Conrol object to demonstrate its functionality.
            </p>

            <div>
                <p>
                    <user:LoginControl ID="LoginControl" BackColor="#ccccff" runat="server" />
                </p>
                <p>
                    <asp:Label ID="outputUser" runat="server" Text=""></asp:Label>
                </p>
                <p>
                    <asp:Label ID="outputPass" runat="server" Text=""></asp:Label>
                </p>
            </div>
        </div>
    </form>
</body>
</html>
