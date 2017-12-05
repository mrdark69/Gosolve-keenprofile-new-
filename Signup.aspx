<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Userlogin.Master" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="_Signup" %>
<asp:Content ID="HeaderScript" ContentPlaceHolderID="HeaderScript" runat="server">
    
    </asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div id="fb-root"></div>
     <div class="login-wrap" style="text-align:left">
	<div class="login-html">
		<input id="tab-1" type="radio" name="tab" class="sign-in" checked><label for="tab-1" class="tab">Sign Up</label>
		<input id="tab-2" type="radio" name="tab" class="sign-up" ><label for="tab-2" class="tab" style="display:none;" >Sign Up</label>
		<div class="login-form">
			<div class="sign-in-htm" style="text-align:left;">
                
				<%--<div class="group">
					<label for="user" class="label">Username</label>
                    
					<input id="user" type="text" class="input">
				</div>--%>
                <div class="group">
					<label for="pass" class="label">Email Address</label>
                    <%--<asp:Label ID="alert" runat="server"></asp:Label>--%>
					<%--<input id="pass" type="text" class="input">--%>
                    <asp:TextBox runat="server" ID="signup_email" class="input" />
                <asp:RegularExpressionValidator ValidationGroup="gs" ID="emailerror" runat="server" CssClass="text-danger" Display="Dynamic" ErrorMessage="The Email invalid format." ControlToValidate="signup_email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ValidationGroup="gs" runat="server" ControlToValidate="signup_email"  Display="Dynamic"
                    CssClass="text-danger" ErrorMessage="The Email field is required." />
				</div>
				<div class="group">
					<label for="pass" class="label">Password</label>
					<%--<input id="pass" type="password" class="input" data-type="password">--%>
                    <asp:TextBox ID="signup_password" runat="server" TextMode="Password"  CssClass="input"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="gs" runat="server"   Display="Dynamic" ControlToValidate="signup_password" CssClass="text-danger" ErrorMessage="The password field is required." />

                      <asp:RegularExpressionValidator  ValidationGroup="gs" runat="server" CssClass="text-danger" Display="Dynamic" ErrorMessage="must be between 8 and 15 characters long and string must contain at least one uppercase letter.  " ControlToValidate="signup_password" ValidationExpression="^(?=.*[A-Z]).{8,15}$"></asp:RegularExpressionValidator>
                    
				</div>
				<div class="group">
					<label for="pass" class="label">Repeat Password</label>
					<%--<input id="pass" type="password" class="input" data-type="password">--%>
                    
                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password"  CssClass="input" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" ValidationGroup="gs"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator ValidationGroup="gs" runat="server" ControlToCompare="signup_password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
				</div>
				
				<div class="group">
				<%--	<input type="submit" class="button" value="Sign Up">--%>
                    <asp:Button ID="btnSignup" CssClass="button" ValidationGroup="gs"  runat="server" OnClick="btnSignup_Click" Text="Sign Up" />

                    <div class="foot-lnk">
					<a href="Login.aspx">Already Member?</a>
				</div>
                   
				</div>
				<div class="hr"></div>

                	<div class="group">
                        <input type="button" onclick="loginByFacebook();"  class="button" value="Sign Up with Facebook"/>
                         <%--<a href="#" onclick="loginByFacebook();">Sign Up with Facebook</a>--%>

                    <script type="text/javascript">
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
    </script>
                        </div>
				
			</div>
			
		</div>
	</div>

         
</div>
   
    <%--<asp:Button ID="Button1" CssClass="button" runat="server" OnClick="btnSignup_Click" Text="Sign Up" />--%>
</asp:Content>
