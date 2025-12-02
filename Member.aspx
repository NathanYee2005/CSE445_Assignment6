<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs"
    Inherits="WebApplication1.Member" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member Area</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Member Area</h1>
            <p>
                Logged in as:
                <asp:Label ID="lblUser" runat="server" />
            </p>

            <p>
                This page is only visible to authenticated members.
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