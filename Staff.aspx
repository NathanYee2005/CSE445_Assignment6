<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="WebApplication1.Staff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Application Staff Page</title>
</head>
<body>
    <form id="form3" runat="server">
        <div>
            <h1>Staff Page</h1>
            <p>
                Logged in as:
                <asp:Label ID="lblUser" runat="server" />
            </p>

            <p>
                This page is only visible to authenticated staff.
                Administrators can open the Staff.xml to add more user credentials.
            </p>

            <p>
                <asp:Button ID="btnBackHome" runat="server"
                            Text="Back to Home"
                            OnClick="btnBackHome_Click" />
                <asp:Button ID="btnLogout" runat="server"
                            Text="Log out"
                            OnClick="btnLogout_Click" />
            </p>
        </div>
    </form>
</body>
</html>
