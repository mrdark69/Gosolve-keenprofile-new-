using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            Model_Users u = UserSessionController.FrontAppAuthLogin(this);
            //if (u != null)
            //{
            //    Response.Redirect("/");
            //    Response.End();
            //}
        }
            

    }

    protected void btn_login_Click(object sender, EventArgs e)
    {
        Model_Users u = UsersController.UserChecklogin(login_Email.Text.Trim(), login_password.Text.Trim());
        if (u != null)
        {
            UserSessionController.CloseOtherCurrentLogin(u.UserID);
            UserSessionController.SessionCreateUserFront(u);
        }
        else
        {
            //FailureText.Text = "UserName Invalid";
            //ErrorMessage.Visible = true;
        }
    }

    protected void btnSignup_Click(object sender, EventArgs e)
    {


        Model_Users mu = new Model_Users
        {
            Email = signup_email.Text.Trim(),
            UserName = signup_email.Text.Trim(),
            Password = signup_password.Text.Trim(),
            UserCatId = 1
        };

        int ret = UsersController.InsertUser(mu);


        if( ret > 0)
        {
            Model_Users cmu = UsersController.GetUserbyID(ret);
            UserSessionController.CloseOtherCurrentLogin(cmu.UserID);
            UserSessionController.SessionCreateUserFront(cmu);
        }
        else
        {
            //RadioButton ra =(RadioButton)this.Page.FindControl("tab-2");
            //ra.Checked = true;
            emailerror.EnableClientScript = false;
            
            emailerror.ErrorMessage = "the Email has already use";


            ClientScript.RegisterClientScriptBlock(typeof(Page), "myscript", "checkpan()", true);

            // alert.Text = "the Email has already use";
        }
        
        


    }
}