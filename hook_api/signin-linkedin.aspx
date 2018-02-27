<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signin-linkedin.aspx.cs" Inherits="external_signin_linkedin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <asp:Panel ID="pnlDetails" runat="server" Visible="false">
    <hr />
    <asp:Image ID="imgPicture" runat="server" /><br />
    Name:
    <asp:Label ID="lblName" runat="server" /><br />
    LinkedInId:
    <asp:Label ID="lblLinkedInId" runat="server" /><br />
    Location:
    <asp:Label ID="lblLocation" runat="server" /><br />
    EmailAddress:
    <asp:Label ID="lblEmailAddress" runat="server" /><br />
    Industry:
    <asp:Label ID="lblIndustry" runat="server" /><br />
    Headline:
    <asp:Label ID="lblHeadline" runat="server" /><br />
</asp:Panel>
        </div>
    </form>
</body>
</html>
