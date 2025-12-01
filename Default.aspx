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
                        <td>Visit counter</td>
                        <td>Global.asax</td>
                        <td></td>
                        <td>Nathan Yee</td>
                        <td>GlobalAsaxTryIt.aspx</td>
                    </tr>

                    <tr>
                        <td>User control demo</td>
                        <td>User control</td>
                        <td></td>
                        <td>Nathan Yee</td>
                        <td>UserControlTryIt.aspx</td>
                    </tr>

                    <tr>
                        <td>Local web service</td>
                        <td>Web service</td>
                        <td></td>
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

            <h2>TryIt links</h2>
            <ul>
                <li>
                    <asp:HyperLink ID="lnkSoapTryIt" runat="server"
                        NavigateUrl="http://localhost:51278/TryIt.aspx"
                        Target="_blank">
                        SOAP text services TryIt (WordFilter, WordCount*, Top10ContentWords)
                    </asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="lnkRestTryIt" runat="server"
                        NavigateUrl="https://localhost:44340/TryItRest.html"
                        Target="_blank">
                        WebDownload REST TryIt
                    </asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="lnkGlobalAsaxTryIt" runat="server"
                        NavigateUrl="GlobalAsaxTryIt.aspx">
                        Global.asax visit counter TryIt
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
                        Local web service TryIt
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