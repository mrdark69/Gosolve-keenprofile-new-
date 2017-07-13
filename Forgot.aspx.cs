using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Forgot : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            Model_Users u = UserSessionController.FrontAppAuthLogin(this);
            if (u != null)
            {
                Response.Redirect("/");
                Response.End();
            }
        }
    }

    protected void btn_login_Click(object sender, EventArgs e)
    {
        string email = login_Email.Text.Trim();

        Model_Users mu =  UsersController.SendEmailForgot(email);

        if (mu != null)
        {


            lblerror.Visible = false;
            login_Email.Visible = false;
            //txtSuccess.Visible = true;
            ss.InnerHtml = "Check your email for a link to reset your password. <br/>If it doesn't appear within a few minutes,<br/> check your spam folder.";


            btn_login.Visible = false;
            btnBacklogin.Visible = true;

        }
        else
        {
            lblerror.Visible = true;
            lblerror.Text = "The email could not found. Please check your email again.";
        }
    }

    //protected void btnSignup_Click(object sender, EventArgs e)
    //{

    //}

    protected void btnBacklogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login");
        Response.End();
    }
}