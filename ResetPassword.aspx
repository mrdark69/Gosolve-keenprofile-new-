<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Userlogin.Master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="_ResetPassword" %>
<asp:Content ID="HeaderScript" ContentPlaceHolderID="HeaderScript" runat="server">
    
    </asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="login-wrap" style="text-align:left">
	<div class="login-html">
		<input id="tab-1" type="radio" name="tab" class="sign-in" checked><label for="tab-1" class="tab">Reset Password</label>
		<input id="tab-2" type="radio" name="tab" class="sign-up"><label for="tab-2" class="tab" ></label>
		<div class="login-form">
			<div class="sign-in-htm" style="text-align:left;">
				<div class="group">
					<label for="pass" class="label" id="ss" runat="server">Password</label>
					<%--<input id="pass" type="password" class="input" data-type="password">--%>
                    <asp:TextBox ID="signup_password" runat="server" TextMode="Password"  CssClass="input"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="gs" runat="server"   Display="Dynamic" ControlToValidate="signup_password" CssClass="text-danger" ErrorMessage="The password field is required." />

                      <asp:RegularExpressionValidator  ValidationGroup="gs" runat="server" CssClass="text-danger" Display="Dynamic" ErrorMessage="must be between 8 and 15 characters long and string must contain at least one uppercase letter.  " ControlToValidate="signup_password" ValidationExpression="^(?=.*[A-Z]).{8,15}$"></asp:RegularExpressionValidator>
                    
				</div>
				<div class="group">
					<label for="pass" class="label" id="bb" runat="server">Repeat Password</label>
					<%--<input id="pass" type="password" class="input" data-type="password">--%>
                    
                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password"  CssClass="input" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" ValidationGroup="gs"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator ValidationGroup="gs" runat="server" ControlToCompare="signup_password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
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
                    <asp:Button ID="btn_forgot" runat="server" CssClass="button" OnClick="btn_forgot_Click" Text="Go to Send Email" Visible="false" />
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
