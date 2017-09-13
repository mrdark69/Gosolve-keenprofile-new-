<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PDF.aspx.cs" Inherits="dev_PDF" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:TextBox ID="txtpdf" runat="server" TextMode="MultiLine" Rows="60" Width="700"></asp:TextBox>
            <asp:Button ID="btnGenpdf" runat="server" Text="GeneratePDF" OnClick="btnGenpdf_Click" />
        </div>
    </form>
</body>
</html>
