<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="TryIt.aspx.cs"
    Inherits="WcfServices.TryIt"
    ValidateRequest="false" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>TryIt – WcfServices</title>
    <style>
        body { font-family: system-ui, sans-serif; margin: 2rem; }
        h2 { margin-top: 2rem; }
        textarea, input[type=text] { width: 100%; font: inherit; }
        textarea { height: 140px; white-space: pre; }
        .row { display: grid; grid-template-columns: 1fr auto; gap: .5rem; align-items: start; }
        .small { color:#555; font-size:.9rem; }
        ul { margin:.5rem 0 0 1rem; }
        .out { height: 180px; }
        .ok { color: #0a0; }
        .err { color: #a00; }
        .box { border:1px solid #ddd; padding:1rem; border-radius:.5rem; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>TryIt – WcfServices (SOAP/WSDL)</h1>
        <p class="small">
            Service URL: <asp:Literal runat="server" ID="litSvcUrl" /> |
            WSDL: <asp:Literal runat="server" ID="litWsdlUrl" />
        </p>



        <!-- WordFilter -->
        <div class="box">
            <h2>WordFilter(string)</h2>
            <p class="small">Removes tags &amp; common stop-words; returns cleaned text.</p>
            <asp:TextBox runat="server" ID="txtFilterIn" TextMode="MultiLine" />
            <div class="row" style="margin-top:.5rem">
                <div></div>
                <asp:Button runat="server" ID="btnFilter" Text="Invoke WordFilter" OnClick="btnFilter_Click" />
            </div>
            <p class="small ok" id="fStatus" runat="server"></p>
            <asp:TextBox runat="server" ID="txtFilterOut" CssClass="out" TextMode="MultiLine" ReadOnly="true" />
        </div>

        <!-- WordCountText -->
        <div class="box">
            <h2>WordCountText(string)</h2>
            <p class="small">Returns JSON: {"word": count, ...}</p>
            <asp:TextBox runat="server" ID="txtCountTextIn" TextMode="MultiLine" />
            <div class="row" style="margin-top:.5rem">
                <div></div>
                <asp:Button runat="server" ID="btnCountText" Text="Invoke WordCountText" OnClick="btnCountText_Click" />
            </div>
            <asp:TextBox runat="server" ID="txtCountTextOut" CssClass="out" TextMode="MultiLine" ReadOnly="true" />
        </div>

        <!-- WordCountFromUrl -->
        <div class="box">
            <h2>WordCountFromUrl(string url)</h2>
            <p class="small">Downloads a page and returns word JSON.</p>
            <div class="row">
                <asp:TextBox runat="server" ID="txtCountUrlIn" />
                <asp:Button runat="server" ID="btnCountUrl" Text="Invoke WordCountFromUrl" OnClick="btnCountUrl_Click" />
            </div>
            <asp:TextBox runat="server" ID="txtCountUrlOut" CssClass="out" TextMode="MultiLine" ReadOnly="true" />
        </div>

        <!-- Top10ContentWords -->
        <div class="box">
            <h2>Top10ContentWords(string url)</h2>
            <p class="small">Downloads, filters + stems words, and returns the 10 most frequent content words.</p>
            <div class="row">
                <asp:TextBox runat="server" ID="txtTopUrlIn" />
                <asp:Button runat="server" ID="btnTop" Text="Invoke Top10ContentWords" OnClick="btnTop_Click" />
            </div>
            <ul>
                <asp:Repeater runat="server" ID="repTop">
                    <ItemTemplate>
                        <li><%# Container.DataItem %></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>

    </form>
</body>
</html>