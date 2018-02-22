using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Signup : Page
{
    public const string FaceBookAppKey = "208d02df5b5b65c4a081e7ee2e8b13e1";
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "KeenProfile Login";
        if (!this.Page.IsPostBack)
        {
            Model_Users u = UserSessionController.FrontAppAuthLogin(this);
            //if (u != null)
            //{
            //    Response.Redirect("/");
            //    Response.End();
            //}


            //string YearSel = string.Empty;
            //for(int i = 0; i < 60; i++)
            //{
            //    int yearstart = 1958;
            //    yearstart = yearstart + i;

            //    YearSel += "<option value=\""+ yearstart + "\" data-content=\""+ yearstart + "\" >"+ yearstart + "</option>";

            //}

            //yearlist.Text = YearSel;
        }


    }
    //private static string GetFacebookUserJSON(string access_token)
    //{
    //    string url = string.Format("https://graph.facebook.com/me?access_token={0}&fields=email,name,first_name,last_name,link", access_token);

    //    WebClient wc = new WebClient();
    //    Stream data = wc.OpenRead(url);
    //    StreamReader reader = new StreamReader(data);
    //    string s = reader.ReadToEnd();
    //    data.Close();
    //    reader.Close();

    //    return s;
    //}


    //protected void btnSignup_Click(object sender, EventArgs e)
    //{


    //    Model_Users mu = new Model_Users
    //    {
    //        Email = signup_email.Text.Trim(),
    //        UserName = signup_email.Text.Trim(),
    //        Password = signup_password.Text.Trim(),
    //        UserCatId = 1,
    //         UserLoginChannel= UserLoginChannel.Application
    //    };

    //    int ret = UsersController.InsertUser(mu);


    //    if( ret > 0)
    //    {
    //        Model_Users cmu = UsersController.GetUserbyID(ret);
    //        UserSessionController.CloseOtherCurrentLogin(cmu.UserID);
    //        UserSessionController.SessionCreateUserFront(cmu);
    //    }
    //    else
    //    {
    //        //RadioButton ra =(RadioButton)this.Page.FindControl("tab-2");
    //        //ra.Checked = true;
    //        emailerror.EnableClientScript = false;

    //        emailerror.ErrorMessage = "the Email has already use";


    //        ClientScript.RegisterClientScriptBlock(typeof(Page), "myscript", "checkpan()", true);

    //        // alert.Text = "the Email has already use";
    //    }




    //}
}