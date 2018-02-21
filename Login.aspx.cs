using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Login : Page
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
    //protected void btn_login_Click(object sender, EventArgs e)
    //{
    //    Model_Users u = UsersController.UserChecklogin(login_Email.Text.Trim(), login_password.Text.Trim());
    //    if (u != null)
    //    {
    //        UserSessionController.CloseOtherCurrentLogin(u.UserID);
    //        UserSessionController.SessionCreateUserFront(u);
    //    }
    //    else
    //    {
    //        //FailureText.Text = "UserName Invalid";
    //        //ErrorMessage.Visible = true;
    //    }
    //}


}