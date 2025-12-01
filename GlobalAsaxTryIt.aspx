<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GlobalAsaxTryIt.aspx.cs" Inherits="WebApplication1.GlobalAsaxTryIt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Global.asax TryIt Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Global.asax Event Handler - TryIt Page</h1>
            <p>
                This page allows you to test the Application_Error event handler to demonstrate Global.asax functionality.
            </p>

            <div>
                <p>
                    <asp:Button ID="testError" runat="server" Text="Throw Test Error" OnClick="testError_Click"/>
                </p>
                <p>
                    <asp:Label ID="output" runat="server" Text=""></asp:Label>
                </p>
            </div>
        </div>
    </form>
</body>
</html>
