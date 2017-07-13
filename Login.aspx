<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Userlogin.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Login" %>
<asp:Content ID="HeaderScript" ContentPlaceHolderID="HeaderScript" runat="server">
    
    </asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="login-wrap" style="text-align:left">
	<div class="login-html">
		<input id="tab-1" type="radio" name="tab" class="sign-in" checked><label for="tab-1" class="tab">Sign In</label>
		<input id="tab-2" type="radio" name="tab" class="sign-up" ><label for="tab-2" class="tab" >Sign Up</label>
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
				</div>
				<div class="hr"></div>
				<div class="foot-lnk">
					<a href="Forgot">Forgot Password?</a>
				</div>
			</div>
			<div class="sign-up-htm" style="text-align:left;">
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
				</div>
				<div class="hr"></div>
				<div class="foot-lnk">
					<a><label for="tab-1">Already Member?</label></a>
				</div>
			</div>
		</div>
	</div>

         
</div>
   
    <%--<asp:Button ID="Button1" CssClass="button" runat="server" OnClick="btnSignup_Click" Text="Sign Up" />--%>
</asp:Content>
