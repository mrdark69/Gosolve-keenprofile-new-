﻿using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using gs_newsletter;

public partial class Account_Login : Page
{
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Model_Users u = UserSessionController.AdminAppAuthLogin(this);
            }
            //RegisterHyperLink.NavigateUrl = "Register";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            //var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            //if (!String.IsNullOrEmpty(returnUrl))
            //{
            //    RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            //}
        }

        protected void LogIn(object sender, EventArgs e)
        {


            
            Model_Users u  =  UsersController.AdminChecklogin(UserName.Text, Password.Text);
        if (u != null)
        {
            if (!u.Status)
            {
                HttpContext.Current.Response.Redirect("~/admin/accessdenie.aspx?error=noactivate");
            }
            else
            {
                //StaffSessionAuthorize StaffSession = new StaffSessionAuthorize();
                //StaffSession.CloseOtherCurrentLogin(clStaff.Staff_Id);
                UserSessionController.CloseOtherCurrentLogin(u.UserID);
                UserSessionController.SessionCreate(u);


            }
        }
        else
        {
            FailureText.Text = "UserName Invalid";
            ErrorMessage.Visible = true;
        }
        //if (IsValid)
        //{
        //    // Validate the user password
        //    //var manager = new UserManager();
        //    //ApplicationUser user = manager.Find(UserName.Text, Password.Text);
        //    //if (user != null)
        //    //{
        //    //    IdentityHelper.SignIn(manager, user, RememberMe.Checked);
        //    //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        //    //}
        //    //else
        //    //{
        //    //    FailureText.Text = "Invalid username or password.";
        //    //    ErrorMessage.Visible = true;
        //    //}
        //}
    }
}