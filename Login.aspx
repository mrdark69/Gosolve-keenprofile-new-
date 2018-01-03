<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Userlogin.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Login" %>
<asp:Content ID="HeaderScript" ContentPlaceHolderID="HeaderScript" runat="server">
    
    </asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div id="fb-root"></div>
     <div class="login-wrap" style="text-align:left">
	<div class="login-html">
		<input id="tab-1" type="radio" name="tab" class="sign-in" checked><label for="tab-1" class="tab">Sign In</label>
		<input id="tab-2" type="radio" name="tab" class="sign-up"  ><label for="tab-2" class="tab" style="display:none;" >Sign Up</label>
		<div class="login-form">
			<div class="sign-in-htm" style="text-align:left;">
                
				<div class="group">
					<label for="user" class="label">Email Address</label>
					<%--<input id="user" type="text" class="input">--%>
                    <%--<asp:TextBox ID="login_user" runat="server" CssClass="input"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="login_user"
                                CssClass="text-danger" ErrorMessage="The user name field is required." />--%>

                     <asp:TextBox runat="server" ID="login_Email" class="input" />
                <asp:RegularExpressionValidator ID="aa" ValidationGroup="gg"  runat="server" CssClass="text-danger" Display="Dynamic" ErrorMessage="The Email invalid format." ControlToValidate="login_Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="bb" ValidationGroup="gg"  runat="server" ControlToValidate="login_Email"  Display="Dynamic"
                    CssClass="text-danger" ErrorMessage="The Email field is required." />
				</div>
				<div class="group">
					<label for="pass" class="label">Password</label>
					<%--<input id="pass" type="password" class="input" data-type="password">--%>
                    <asp:TextBox ID="login_password" runat="server" TextMode="Password"  CssClass="input"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="cc" ValidationGroup="gg"   runat="server"  Display="Dynamic" ControlToValidate="login_password" CssClass="text-danger" ErrorMessage="The password field is required." />
				</div>
				<%--<div class="group">
					<input id="check" type="checkbox" class="check" checked>
					<label for="check"><span class="icon"></span> Keep me Signed in</label>
				</div>--%>
				<div class="group">
					<%--<input type="submit" class="button" value="Sign In">--%>
                    <asp:Button ID="btn_login" runat="server" ValidationGroup="gg" CssClass="button" OnClick="btn_login_Click" Text="Sign In" />
                    <div class="foot-lnk">
                    <a href="Forgot">Forgot Password?</a>
                   </div>
				</div>
				<div class="hr"></div>
                
				<div class="foot-lnk">
					
                    <a href="Signup.aspx">Create a new Keen Profile account</a>
				</div>
			</div>
			
		</div>
	</div>

         
</div>
   
    <%--<asp:Button ID="Button1" CssClass="button" runat="server" OnClick="btnSignup_Click" Text="Sign Up" />--%>
</asp:Content>
<%--<div class="group">
                      <a href="#" onclick="loginByFacebook();" class="button">Login with Facebook</a>--%>

                    <%--<script type="text/javascript">
                        window.fbAsyncInit = function () {
                            FB.init({
                                appId: '358756381252009',
                                status: true, // check login status
                                cookie: true, // enable cookies to allow the server to access the session
                                xfbml: true, // parse XFBML
                                oauth: true // enable OAuth 2.0
                            });
                        };
                        (function () {
                            var e = document.createElement('script'); e.async = true;
                            e.src = document.location.protocol +
                                '//connect.facebook.net/en_US/all.js';
                            $('#fb-root').prepend(e);
                            // document.getElementById('fb-root').appendChild(e);
                        }());

                        function loginByFacebook() {
                            FB.login(function (response) {
                                if (response.authResponse) {
                                    FacebookLoggedIn(response);
                                } else {
                                    console.log('User cancelled login or did not fully authorize.');
                                }
                            }, { scope: 'public_profile,user_friends,email' });
                        }

                        function FacebookLoggedIn(response) {
                            var loc = '/hook_api/facebookcallback.aspx';
                            if (loc.indexOf('?') > -1)
                                window.location = loc + '&authprv=facebook&access_token=' + response.authResponse.accessToken;
                            else
                                window.location = loc + '?authprv=facebook&access_token=' + response.authResponse.accessToken;
                        }
    </script>--%>
                    <%--</div>--%>