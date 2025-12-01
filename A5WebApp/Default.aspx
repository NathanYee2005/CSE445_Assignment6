<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="A5WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Assignment 5 Web Application – Team 122</h1>

    <p>
        This web application hosts my text-processing services from Assignment 3 and two local
        components required in Assignment 5 (DLL + cookie/session helper). This page is the
        public landing page and lists all components with their TryIt locations.
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
                <td>Main landing page, links to Member/Staff, local component demos.</td>
                <td>Ahmed Almoshawer</td>
                <td>Default.aspx</td>
            </tr>

            <tr>
                <td>SOAP text services</td>
                <td>SOAP / WSDL</td>
                <td>WordFilter, WordCountText, WordCountFromUrl, Top10ContentWords.</td>
                <td>Ahmed Almoshawer</td>
                <td>
                    <a href="http://localhost:51278/TryIt.aspx" target="_blank">
                        WcfServices TryIt.aspx
                    </a>
                </td>
            </tr>

            <tr>
                <td>WebDownload</td>
                <td>REST</td>
                <td>Downloads a web page and returns the raw HTML.</td>
                <td>Ahmed Almoshawer</td>
                <td>
                    <a href="https://localhost:44340/TryItRest.html" target="_blank">
                        REST WebDownload TryIt.html
                    </a>
                </td>
            </tr>

            <tr>
                <td>CookieSessionHelper</td>
                <td>Local helper</td>
                <td>Stores a nickname in cookie + session and reads it back.</td>
                <td>Ahmed Almoshawer</td>
                <td>“Nickname (Cookie / Session)” section below</td>
            </tr>

            <tr>
                <td>SecurityTools.HashString</td>
                <td>DLL (ClassLibrary)</td>
                <td>Hashes a string (used for simple hash demo on Default.aspx).</td>
                <td>Ahmed Almoshawer</td>
                <td>“Hash test (ClassLibrary DLL)” section below</td>
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

    <h2>Local Components Demo</h2>

    <h3>Nickname (Cookie / Session)</h3>
    <p>Enter a nickname. The helper stores it in both a cookie and the ASP.NET session.</p>
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
        <asp:TextBox ID="txtHashOutput" runat="server" Width="100%" ReadOnly="true" />
    </p>

</asp:Content>