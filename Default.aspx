<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="WebApplication1.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Assignment 5/6 Web Application – Team 122</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h1>Assignment 5/6 Web Application – Team 122</h1>

            <p>
                This default page shows the application components and links to their TryIt pages
                and demo sections.
            </p>

            <h2>Application &amp; Components Summary</h2>
            <table border="1" cellpadding="4" cellspacing="0">
                <thead>
                    <tr>
                        <th>Component</th>
                        <th>Type</th>
                        <th>Description</th>
                        <th>Provider</th>
                        <th>TryIt / UI location</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Default.aspx</td>
                        <td>GUI</td>
                        <td>Landing page, navigation and local demos.</td>
                        <td>Ahmed Almoshawer, Nathan Yee</td>
                        <td>Default.aspx</td>
                    </tr>

                    <tr>
                        <td>Member self-enrollment</td>
                        <td>GUI + XML</td>
                        <td>Member sign-up, login, and password change using Member.xml.</td>
                        <td>Ahmed Almoshawer</td>
                        <td>Self-enrollment section on Default.aspx</td>
                    </tr>

                    <tr>
                        <td>Member.aspx</td>
                        <td>GUI</td>
                        <td>Member-only page, visible only to authenticated members.</td>
                        <td>Ahmed Almoshawer, Nathan Yee</td>
                        <td>Member.aspx</td>
                    </tr>

                    <tr>
                        <td>Staff Login</td>
                        <td>GUI + XML</td>
                        <td>Staff login using Staff.xml.</td>
                        <td>Ahmed Almoshawer, Nathan Yee</td>
                        <td>Log-In (Staff) section on Default.aspx</td>
                    </tr>

                    <tr>
                        <td>Staff.aspx</td>
                        <td>GUI</td>
                        <td>Staff-only page, visible only to authenticated staff members.</td>
                        <td>Ahmed Almoshawer, Nathan Yee</td>
                        <td>Staff.aspx</td>
                    </tr>

                    <tr>
                        <td>SOAP text services</td>
                        <td>SOAP / WSDL</td>
                        <td>WordFilter, WordCountText, WordCountFromUrl, Top10ContentWords.</td>
                        <td>Ahmed Almoshawer</td>
                        <td>SOAP TryIt link below</td>
                    </tr>

                    <tr>
                        <td>WebDownload</td>
                        <td>REST</td>
                        <td>Downloads a web page and returns the HTML.</td>
                        <td>Ahmed Almoshawer</td>
                        <td>REST TryIt link below</td>
                    </tr>

                    <tr>
                        <td>CookieSessionHelper</td>
                        <td>Local helper</td>
                        <td>Stores a nickname in cookie and session.</td>
                        <td>Ahmed Almoshawer</td>
                        <td>Nickname (Cookie / Session) section below</td>
                    </tr>

                    <tr>
                        <td>SecurityTools.HashString</td>
                        <td>DLL (ClassLibrary)</td>
                        <td>Hashes a string for the hash demo.</td>
                        <td>Ahmed Almoshawer</td>
                        <td>Hash test (ClassLibrary DLL) section below</td>
                    </tr>

                    <tr>
                        <td>Error Event Handler</td>
                        <td>Global.asax</td>
                        <td>Throws a test error to demonstrate the functionality of the Error Event Handler</td>
                        <td>Nathan Yee</td>
                        <td>GlobalAsaxTryIt.aspx</td>
                    </tr>

                    <tr>
                        <td>Demo Login Page</td>
                        <td>User control</td>
                        <td>Shows off an example User Control object that implements a demo login page</td>
                        <td>Nathan Yee</td>
                        <td>UserControlTryIt.aspx</td>
                    </tr>

                    <tr>
                        <td>Word Count from file</td>
                        <td>Web service</td>
                        <td>Gets the word count from a .txt file upload.</td>
                        <td>Nathan Yee</td>
                        <td>ServiceTryIt.aspx</td>
                    </tr>
                </tbody>
            </table>

            <h2>Navigation</h2>
            <p>
                <asp:Button ID="btnMember" runat="server"
                            Text="Member Page"
                            OnClick="btnMember_Click" />
                <asp:Button ID="btnStaff" runat="server"
                            Text="Staff Page"
                            OnClick="btnStaff_Click" />
            </p>

            

            <h2>Self-enrollment (Members)</h2>

            <h3>New member sign-up</h3>
            <p>Username:
                <asp:TextBox ID="txtSignupUser" runat="server" />
            </p>
            <p>Password:
                <asp:TextBox ID="txtSignupPass" runat="server" TextMode="Password" />
            </p>
            <p>Confirm password:
                <asp:TextBox ID="txtSignupConfirm" runat="server" TextMode="Password" />
            </p>
            <p>
                <asp:Button ID="btnSignUp" runat="server" Text="Sign up"
                            OnClick="btnSignUp_Click" />
            </p>
            <p>
                <asp:Label ID="lblSignUpMsg" runat="server" />
            </p>

            <h3>Login</h3>
            <p>Username:
                <asp:TextBox ID="txtLoginUser" runat="server" />
            </p>
            <p>Password:
                <asp:TextBox ID="txtLoginPass" runat="server" TextMode="Password" />
            </p>
            <p>
                <asp:Button ID="btnLogin" runat="server" Text="Log in"
                            OnClick="btnLogin_Click" />
            </p>
            <p>
                <asp:Label ID="lblLoginMsg" runat="server" />
            </p>

            <h3>Change password</h3>
            <p>Username:
                <asp:TextBox ID="txtChangeUser" runat="server" />
            </p>
            <p>Old password:
                <asp:TextBox ID="txtChangeOld" runat="server" TextMode="Password" />
            </p>
            <p>New password:
                <asp:TextBox ID="txtChangeNew" runat="server" TextMode="Password" />
            </p>
            <p>Confirm new password:
                <asp:TextBox ID="txtChangeConfirm" runat="server" TextMode="Password" />
            </p>
            <p>
                <asp:Button ID="btnChangePwd" runat="server" Text="Change password"
                            OnClick="btnChangePwd_Click" />
            </p>
            <p>
                <asp:Label ID="lblChangeMsg" runat="server" />
            </p>

            <p>
                <asp:Button ID="btnLogout" runat="server" Text="Log out"
                            OnClick="btnLogout_Click" />
            </p>

            <h2>Log-In (Staff)</h2>

            <h3>Login</h3>
            <p>Username:
                <asp:TextBox ID="txtStaffUser" runat="server" />
            </p>
            <p>Password:
                <asp:TextBox ID="txtStaffPass" runat="server" TextMode="Password" />
            </p>
            <p>
                <asp:Button ID="btn" runat="server" Text="Log in"
                            OnClick="btnStaffLogin_Click" />
            </p>
            <p>
                <asp:Label ID="lblStaffLoginMsg" runat="server" />
            </p>

            <p>
                <asp:Button ID="btnStaffLogout" runat="server" Text="Log out"
                            OnClick="btnStaffLogout_Click" />
            </p>

            <h2>TryIt links</h2>
            <ul>
                <li>
                    <asp:HyperLink ID="lnkSoapTryIt" runat="server"
                        NavigateUrl="TryIt.aspx">
                        SOAP text services TryIt (WordFilter, WordCount*, Top10ContentWords)
                    </asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="lnkRestTryIt" runat="server"
                        NavigateUrl="http://webstrar122.fulton.asu.edu/page2/TryItRest.html"
                        Target="_blank">
                        WebDownload REST TryIt
                    </asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="lnkGlobalAsaxTryIt" runat="server"
                        NavigateUrl="GlobalAsaxTryIt.aspx">
                        Global.asax error handler TryIt
                    </asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="lnkUserControlTryIt" runat="server"
                        NavigateUrl="UserControlTryIt.aspx">
                        User control TryIt
                    </asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="lnkServiceTryIt" runat="server"
                        NavigateUrl="ServiceTryIt.aspx">
                        Word count from file TryIt
                    </asp:HyperLink>
                </li>
            </ul>

            <h2>Local Components Demo</h2>

            <h3>Nickname (Cookie / Session)</h3>
            <p>Enter a nickname. It is stored in a cookie and in the session.</p>
            <p>
                <asp:TextBox ID="txtNick" runat="server" />
                <asp:Button ID="btnSaveNick" runat="server"
                            Text="Save nickname"
                            OnClick="btnSaveNick_Click" />
            </p>
            <p>
                <asp:Label ID="lblNick" runat="server" />
            </p>

            <h3>Hash test (ClassLibrary DLL)</h3>
            <p>
                <asp:TextBox ID="txtHashInput" runat="server" Width="400" />
                <asp:Button ID="btnHash" runat="server"
                            Text="Hash"
                            OnClick="btnHash_Click" />
            </p>
            <p>
                <asp:TextBox ID="txtHashOutput" runat="server"
                             Width="100%" ReadOnly="true" />
            </p>

        </div>
    </form>
</body>
</html>