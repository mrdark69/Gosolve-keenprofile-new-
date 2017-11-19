<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin - HotelWorld</title>
    <link href="/Content/bootstrap.min.css" rel="stylesheet" />
   
    <link href="/Content/font-awesome.css" rel="stylesheet" />
   
    <link href="/Content/animate.css" rel="stylesheet" />
    <link href="/Content/style.css" rel="stylesheet" />
   
    <style>
        .loginscreen.middle-box {
    width: 526px;
}

.middle-box {
    max-width: 453px;
    z-index: 100;
    margin: 0 auto;
    padding-top: 40px;
}
    </style>
</head>
<body class="gray-bg">

    <div class="middle-box text-center loginscreen animated fadeInDown">
        <div>
            <div>

                <h1 class="logo-name" style="width: 600px;text-align: center;margin-left: -98px;">KEEN PROFILE</h1>

            </div>
            <h3>Manage your world</h3>
            <%--<p>Perfectly designed and precisely prepared admin theme with over 50 pages with extra new web app views.
                <!--Continually expanded and constantly improved Inspinia Admin Them (IN+)-->
            </p>--%>
            <p>Login in. To see it in action.</p>
             <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
             </asp:PlaceHolder>
            <form class="m-t" role="form"  runat="server">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                CssClass="text-danger" ErrorMessage="The user name field is required." />
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                </div>
                <asp:Button runat="server" OnClick="LogIn" Text="Login" CssClass="btn btn-primary block full-width m-b" />
               <%-- <button type="submit" class="btn btn-primary block full-width m-b">Login</button>--%>

                <%--<a href="#"><small>Forgot password?</small></a>
                <p class="text-muted text-center"><small>Do not have an account?</small></p>--%>
                <%--<a class="btn btn-sm btn-white btn-block" href="register.html">Create an account</a>--%>
            </form>
            <p class="m-t"> <small>Gosolve development, base on Bootstrap 3 &copy; 2017</small> </p>
        </div>
    </div>

    <!-- Mainly scripts -->
   
    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    

</body></html>
