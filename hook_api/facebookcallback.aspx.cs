using FacebookLogin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class hook_api_facebookcallback : System.Web.UI.Page
{
    public const string FaceBookAppKey = "208d02df5b5b65c4a081e7ee2e8b13e1";
    private char[] userInfo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["access_token"])) return; //ERROR! No token returned from Facebook!!

        //let's send an http-request to facebook using the token            
        string json = GetFacebookUserJSON(Request.QueryString["access_token"]);


        //and Deserialize the JSON response
        JavaScriptSerializer js = new JavaScriptSerializer();

        FacebookUser oUser = js.Deserialize<FacebookUser>(json);
        if (oUser != null)
        {
            //Response.Write("Welcome, " + oUser.name);
            //// Response.Write("<br />id, " + oUser.id);
            //Response.Write("<br />Email : " + oUser.email);
            //Response.Write("<br />First_name: " + oUser.first_name);
            //Response.Write("<br />Last_name: " + oUser.last_name);
            //Response.Write("<br />Gender: " + oUser.gender);
            //Response.Write("<br />Link: " + oUser.link);

            //checkuser facebook channel

            string sex = oUser.gender;

            string userID = oUser.id.ToString();

           



           // http://graph.facebook.com/10159605614725366/picture?type=large

            string strPicturePath = "http://graph.facebook.com/" + userID + "/picture?type=large";

            Model_Users u = UsersController.UserCheckloginExternal(oUser.email.Trim());
            if (u != null)
            {
                if (string.IsNullOrEmpty(u.PicturePath))
                {
                    u.PicturePath = strPicturePath;
                    u.UpdateUserProfilePicutre(u);
                }


                UserSessionController.CloseOtherCurrentLogin(u.UserID);
                UserSessionController.SessionCreateUserFront(u);


               
            }
            else
            {

                Model_Users mu = new Model_Users
                {
                    Email = oUser.email,
                    UserName = oUser.email,
                    Gender = (byte)(oUser.gender == "male" ? 1 : 2),
                    Password = DateTime.Now.ToString("ddmmyyyyhhmmss"),
                    UserCatId = 1,
                    UserLoginChannel = UserLoginChannel.Facebook,
                    FirstName = oUser.first_name,
                    LastName = oUser.last_name,
                    EmailVerify = false,
                    PicturePath = strPicturePath


                };
                int ret = UsersController.InsertUserExternal(mu);


                if (ret > 0)
                {
                    Model_Users cmu = UsersController.GetUserbyID(ret);
                    UserSessionController.CloseOtherCurrentLogin(cmu.UserID);
                    UserSessionController.SessionCreateUserFront(cmu);
                }
                else
                {
                    //RadioButton ra =(RadioButton)this.Page.FindControl("tab-2");
                    //ra.Checked = true;
                    //emailerror.EnableClientScript = false;

                    //emailerror.ErrorMessage = "the Email has already use";


                    //ClientScript.RegisterClientScriptBlock(typeof(Page), "myscript", "checkpan()", true);

                    // alert.Text = "the Email has already use";
                }
            }

           

            

        }
    }

    private static string GetFacebookUserJSON(string access_token)
    {
        string url = string.Format("https://graph.facebook.com/me?access_token={0}&fields=email,name,first_name,last_name,link,birthday,cover,devices,gender", access_token);

        WebClient wc = new WebClient();
        Stream data = wc.OpenRead(url);
        StreamReader reader = new StreamReader(data);
        string s = reader.ReadToEnd();
        data.Close();
        reader.Close();

        return s;
    }
}