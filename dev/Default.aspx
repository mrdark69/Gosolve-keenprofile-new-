<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="dev_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView Id="gg" runat="server" AutoGenerateColumns="true"  ></asp:GridView>
            <asp:Literal ID="rawdup" runat="server"></asp:Literal>

            <br /><br />
              <asp:Literal ID="ret" runat="server"></asp:Literal>
             <asp:Button ID="btn" runat="server" Text="gen" OnClick="btn_Click" />
        </div>
    </form>
</body>
</html>
