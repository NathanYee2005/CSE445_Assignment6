<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Application Landing Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome to the Webpage & Text Analysis Application</h1>
            <p>
                This application provides various different tools to assist in the analysis of webpages and textual content.
            </p>
            <hr />
            <div>
                <h2>Service Directory</h2>
                <div>
                <p>
                    Explore available service components and TryIt pages:
                </p>
                    <p>
                        <asp:LinkButton ID="GlobalAsaxLinkButton1" href="GlobalAsaxTryIt.aspx" runat="server">Global.asax - TryIt</asp:LinkButton>
                    </p>
                    <p>
                        <asp:LinkButton ID="UserControlLinkButton2" href="UserControlTryIt.aspx" runat="server">User Control - TryIt</asp:LinkButton>
                    </p>
                    <p>
                        <asp:LinkButton ID="ServiceLinkButton" href="ServiceTryIt.aspx" runat="server">Web Service - TryIt</asp:LinkButton>
                    </p>
                </div>
            </div>
            <hr />
            <div>
                <h2>Navigation</h2>
                <div>
                    <p>
                        <asp:LinkButton ID="MemberLinkButton" href="Member.aspx" runat="server">Member Page</asp:LinkButton>
                    </p>
                    <p>
                        <asp:LinkButton ID="StaffLinkButton" href="Staff.aspx" runat="server">Staff Page</asp:LinkButton>
                    </p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
