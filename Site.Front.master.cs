﻿using gs_newsletter;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteFrontMaster : MasterPage
{
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
   // private string _antiXsrfTokenValue;

    //protected void Page_Init(object sender, EventArgs e)
    //{
    //    //Response.Write();
    //    //Response.End();

    //    if (!Context.User.Identity.IsAuthenticated)
    //    {
    //       // IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
    //        //Response.Redirect("Demo");
    //        //Response.End();
    //    }

    //    // The code below helps to protect against XSRF attacks
    //    var requestCookie = Request.Cookies[AntiXsrfTokenKey];
    //    Guid requestCookieGuidValue;
    //    if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
    //    {
    //        // Use the Anti-XSRF token from the cookie
    //        _antiXsrfTokenValue = requestCookie.Value;
    //        Page.ViewStateUserKey = _antiXsrfTokenValue;
    //    }
    //    else
    //    {
    //        // Generate a new Anti-XSRF token and save to the cookie
    //        _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
    //        Page.ViewStateUserKey = _antiXsrfTokenValue;

    //        var responseCookie = new HttpCookie(AntiXsrfTokenKey)
    //        {
    //            HttpOnly = true,
    //            Value = _antiXsrfTokenValue
    //        };
    //        if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
    //        {
    //            responseCookie.Secure = true;
    //        }
    //        Response.Cookies.Set(responseCookie);
    //    }

    //    Page.PreLoad += master_Page_PreLoad;
    //}

    protected void master_Page_PreLoad(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    // Set Anti-XSRF token
        //    ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
        //    ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
        //}
        //else
        //{
        //    // Validate the Anti-XSRF token
        //    if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
        //        || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
        //    {
        //        throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
        //    }
        //}
    }

    protected void Page_Load(object sender, EventArgs e)
    {
     
        Page p = new Page();
        Model_Users u = UserSessionController.FrontAppAuthorization(p);

        if (u != null)
        {

            string fullname = u.FirstName + " " + u.LastName;
            profilename.Text = fullname;
            string strImageUrl = "Theme/fronttheme/assets/keenimg/profileempty.png";

            if (!string.IsNullOrEmpty(u.PicturePath))
            {
                strImageUrl = u.PicturePath;
            }

            imageProfile.ImageUrl = strImageUrl;
            imageProfile2.ImageUrl = strImageUrl;
            imageProfile2.AlternateText = fullname;

           // lblprofile.Text = "<i class=\"fa fa-user\" aria-hidden=\"true\"></i> " + u.FirstName + " |&nbsp; <a style=\"color:#fff;\" href=\"http://member.keenprofile.com/logout\" />Log out <i class=\"fa fa-sign-out\" aria-hidden=\"true\"></i></a>";
        }
    }

    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        //Context.GetOwinContext().Authentication.SignOut();
    }

    protected void sendmailverify_Click(object sender, EventArgs e)
    {
        LinkButton el = (LinkButton)sender;

        if (!string.IsNullOrEmpty(el.CommandArgument))
        {
            
            //Model_Users mu = new Model_Users
            //{
            //    UserID = int.Parse(el.CommandArgument)
            //};
            UsersController.SendEmailVerify(int.Parse(el.CommandArgument));

           

            Response.Redirect(Request.Url.ToString().Split('?')[0] + "?resend=completed");
           
        }
         
    }
}