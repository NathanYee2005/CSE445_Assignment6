<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceTryIt.aspx.cs" Inherits="WebApplication1.ServiceTryIt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Word Count Service TryIt Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Word Count Service - TryIt Page</h1>
            <p>
                This page allows you to test the Word Count Service to demonstrate its functionality. Upload a .txt file and it will count how many of each word resides in it.
            </p>

            <div>
                <p>
                    <asp:FileUpload ID="FileUpload" runat="server" />
                </p>
                <p>
                    <asp:Button ID="upload" runat="server" Text="Upload and Count" OnClick="upload_Click" />
                </p>
                <p>
                    <asp:Label ID="status" runat="server" Text="No File Selected"></asp:Label>
                </p>
                <p>
                    <asp:Label ID="output" runat="server" Text=""></asp:Label>
                </p>

            </div>
        </div>
    </form>
</body>
</html>
