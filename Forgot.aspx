<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Userlogin.Master" AutoEventWireup="true" CodeFile="Forgot.aspx.cs" Inherits="_Forgot" %>
<asp:Content ID="HeaderScript" ContentPlaceHolderID="HeaderScript" runat="server">
    <style>
        .login-wrap{
            min-height:400px !important;
        }
        .txt_success{
            display:block;
         
             text-transform: uppercase;
             color: #aaa;
    font-size: 12px;
        }
    </style>
    </asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="login-wrap" style="text-align:left">
	<div class="login-html">
		<input id="tab-1" type="radio" name="tab" class="sign-in" checked><label for="tab-1" class="tab">Forgot Password</label>
		<input id="tab-2" type="radio" name="tab" class="sign-up"><label for="tab-2" class="tab" ></label>
        <%--<asp:Label ID="txtSuccess" runat="server"  CssClass="txt_success" Visible="false"></asp:Label>--%>
		<div class="login-form" >
			<div class="sign-in-htm" style="text-align:left;">
				<div class="group">
                   
					<label style="line-height:20px;" runat="server" for="user" ID="ss" class="label">Enter your email address and <br /> we will send you a link to reset your password.</label>
					<%--<input id="user" type="text" class="input">--%>
                    <%--<asp:TextBox ID="login_user" runat="server" CssClass="input"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="login_user"
                                CssClass="text-danger" ErrorMessage="The user name field is required." />--%>
                  
                     <asp:TextBox runat="server" ID="login_Email" class="input" />
                <asp:RegularExpressionValidator  runat="server" CssClass="text-danger" Display="Dynamic" ErrorMessage="The Email invalid format." ControlToValidate="login_Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="login_Email"  Display="Dynamic"
                    CssClass="text-danger" ErrorMessage="The Email field is required." />
                      <asp:Label ID="lblerror" runat="server"  CssClass="text-danger" Visible="false"></asp:Label>
				</div>
			<%--	<div class="group">
					<label for="pass" class="label">Password</label>--%>
					<%--<input id="pass" type="password" class="input" data-type="password">--%>
                   <%-- <asp:TextBox ID="login_password" runat="server" TextMode="Password"  CssClass="input"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server"  Display="Dynamic" ControlToValidate="login_password" CssClass="text-danger" ErrorMessage="The password field is required." />--%>
			<%--	</div>--%>
				<%--<div class="group">
					<input id="check" type="checkbox" class="check" checked>
					<label for="check"><span class="icon"></span> Keep me Signed in</label>
				</div>--%>
				<div class="group">
					<%--<input type="submit" class="button" value="Sign In">--%>
                    <asp:Button ID="btn_login" runat="server" CssClass="button" OnClick="btn_login_Click" Text="Send Email Now" />
                     <asp:Button ID="btnBacklogin" runat="server" CssClass="button" OnClick="btnBacklogin_Click" Text="Return to sign in"  Visible="false"/>
				</div>
				<div class="hr"></div>
				<%--<div class="foot-lnk">
					<a href="#forgot">Forgot Password?</a>
				</div>--%>
			</div>
			
		</div>
	</div>
</div>
   
</asp:Content>
