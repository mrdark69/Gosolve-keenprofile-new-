using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _ResetPassword : Page
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
            else
            {
                if (!string.IsNullOrEmpty(Request.QueryString["e"])){
                    HttpSessionState Hotels2Session = HttpContext.Current.Session;

                    string q = StringUtility.DecryptedData(Request.QueryString["e"]);
                    string[] arrq = q.Split('@');
                    string qUserID = arrq[0];
                    string qSession = arrq[1];

                    if(Hotels2Session[qSession] == null)
                    {
                        ss.InnerHtml = "Sorry the session is timeout";
                        signup_password.Visible = false;
                        ConfirmPassword.Visible = false;
                        btn_login.Visible = false;
                        bb.Visible = false;
                        btn_forgot.Visible = true;
                    }
                }
                else
                {
                    ss.InnerHtml = "Sorry the session is timeout";
                    signup_password.Visible = false;
                    ConfirmPassword.Visible = false;
                    btn_login.Visible = false;
                    bb.Visible = false;
                    btn_forgot.Visible = true;
                }
               
               
            }
        }
    }

    protected void btn_login_Click(object sender, EventArgs e)
    {

        if (!String.IsNullOrEmpty(Request.QueryString["e"]))
        {
            HttpSessionState Hotels2Session = HttpContext.Current.Session;
            string password = signup_password.Text.Trim();
            string q = StringUtility.DecryptedData(Request.QueryString["e"]);
            string[] arrq = q.Split('@');
            string qUserID = arrq[0];
            string qSession = arrq[1];

            if (Hotels2Session[qSession] == null)
            {
                ss.InnerHtml = "Sorry the session is timeout";
                signup_password.Visible = false;
                ConfirmPassword.Visible = false;
                btn_login.Visible = false;
                bb.Visible = false;
                btn_forgot.Visible = true;
            }
            else
            {
                Model_Users mu = new Model_Users
                {
                    UserID = int.Parse(qUserID),
                    Password = password
                };

                if(UsersController.UpdatePassword(mu))
                {
                    signup_password.Visible = false;
                    ConfirmPassword.Visible = false;
                    btn_login.Visible = false;
                    bb.Visible = false;
                    ss.InnerHtml = "New password set successfully.";
                    btn_login.Visible = false;

                    btnBacklogin.Visible = true;
                }
            }
           
        }
        else
        {
            ss.InnerHtml = "Sorry the session is timeout";
            signup_password.Visible = false;
            ConfirmPassword.Visible = false;
            btn_login.Visible = false;
            bb.Visible = false;
            btn_forgot.Visible = true;
        }
       
    }

    //protected void btnSignup_Click(object sender, EventArgs e)
    //{

    //}

    protected void btn_forgot_Click(object sender, EventArgs e)
    {
        Response.Redirect("Forgot");
        Response.End();
    }

    protected void btnBacklogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login");
        Response.End();
    }
}