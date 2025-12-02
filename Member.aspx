<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="WebApplication1.Member" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Member Page</h1>

            <p>
                This page lets a user register as a member and then log in.
                Member accounts are stored in App_Data/Member.xml with a hashed password.
            </p>

            <hr />

            <h2>Register</h2>
            <asp:Label ID="lblRegisterStatus" runat="server" ForeColor="Red" /><br />

            <p>
                Username:
                <asp:TextBox ID="txtNewUser" runat="server" />
            </p>
            <p>
                Password:
                <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password" />
            </p>
            <p>
                Confirm password:
                <asp:TextBox ID="txtNewPass2" runat="server" TextMode="Password" />
            </p>

            <p>
                <asp:Button ID="btnRegister" runat="server"
                            Text="Register"
                            OnClick="btnRegister_Click" />
            </p>

            <hr />

            <h2>Login</h2>
            <asp:Label ID="lblLoginStatus" runat="server" ForeColor="Red" /><br />

            <p>
                Username:
                <asp:TextBox ID="txtLoginUser" runat="server" />
            </p>
            <p>
                Password:
                <asp:TextBox ID="txtLoginPass" runat="server" TextMode="Password" />
            </p>

            <p>
                <asp:Button ID="btnLogin" runat="server"
                            Text="Login"
                            OnClick="btnLogin_Click" />
            </p>

            <hr />

            <asp:Panel ID="pnlMemberArea" runat="server" Visible="false">
                <h2>Member Area</h2>
                <asp:Label ID="lblWelcome" runat="server" /><br /><br />

                <asp:Button ID="btnLogout" runat="server"
                            Text="Logout"
                            OnClick="btnLogout_Click" />
            </asp:Panel>

            <br />

            <asp:Button ID="btnBack" runat="server"
                        Text="Back to Home"
                        OnClick="btnBack_Click" />
        </div>
    </form>
</body>
</html>