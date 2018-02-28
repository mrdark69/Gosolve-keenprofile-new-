using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Interface_API;
using ASPSnippets.LinkedInAPI;
using System.Data;
using Owin;
using RestSharp;
using Newtonsoft.Json;

public partial class external_signin_linkedin : System.Web.UI.Page
{
    //public  Microsoft.Owin.IOwinContext Context { get; set; }
    public void Page_Load(object sender, EventArgs e)
    {



        string client_id = "81h1zat2gc50un";
        string client_secret = "ZLi6H1m1k6EICMES";
        string code = Request.QueryString["code"];
        string redirect = Request.Url.AbsoluteUri.Split('?')[0].Replace("http", "https");



        string URI = "https://www.linkedin.com/uas/oauth2/accessToken";


       // string URI = "http://www.myurl.com/post.php";
        string myParameters = "grant_type=authorization_code&client_id=" + client_id + "&client_secret=" + client_secret + "&code=" + code + "&redirect_uri=" + redirect;

        //Response.Write(URI + "?" + myParameters);
        //Response.End();
        string HtmlResult = string.Empty;
        using (WebClient wc = new WebClient())
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
             HtmlResult = wc.UploadString(URI, myParameters);
        }


        var jsonHtmlResult = JsonHelper.JsonTODynamic(HtmlResult);






        string urlprofile = "https://api.linkedin.com/v1/people/~:(id,formatted-name,first-name,last-name,email-address,picture-url,picture-urls::(original),headline,public-profile-url,positions)";
        string param = "oauth2_access_token=" + jsonHtmlResult["access_token"] + "&format=json";


        string userdata = string.Empty;
        //using (WebClient wc = new WebClient())
        //{
        //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        //    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

        //    userdata = wc.UploadString(urlprofile, param);
        //}

        string urlcom = urlprofile + "?" + param;
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(urlcom);
        request.Method = "GET";
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            userdata = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
        }

        

        var UserJson = JsonHelper.JsonTODynamic(userdata);


        //firstName

        //    lastName emailAddress pictureUrl

        string firstName = UserJson["firstName"];

        string lastName = UserJson["lastName"];

        string emailAddress = UserJson["emailAddress"];

        string pictureUrl = UserJson["pictureUrl"];  

        Model_Users u = UsersController.UserCheckloginExternal(emailAddress.Trim());
        if (u != null)
        {
            if (string.IsNullOrEmpty(u.PicturePath))
            {
                u.PicturePath = pictureUrl;
                u.UpdateUserProfilePicutre(u);
            }


            UserSessionController.CloseOtherCurrentLogin(u.UserID);
            UserSessionController.SessionCreateUserFront(u);



        }
        else
        {

            Model_Users mu = new Model_Users
            {
                Email = emailAddress.Trim(),
                UserName = emailAddress.Trim(),
                Gender = 3,
                Password = DateTime.Now.ToString("ddmmyyyyhhmmss"),
                UserCatId = 1,
                UserLoginChannel = UserLoginChannel.Facebook,
                FirstName = firstName,
                LastName = lastName,
                EmailVerify = false,
                PicturePath = pictureUrl


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



        //LinkedInConnect.APIKey = "81h1zat2gc50un";
        //LinkedInConnect.APISecret = "ZLi6H1m1k6EICMES";
        //LinkedInConnect.RedirectUrl = Request.Url.AbsoluteUri.Split('?')[0];



        //if (LinkedInConnect.IsAuthorized)
        //{

        //    string ff = (string)Session["access_token"];
        //    pnlDetails.Visible = true;
        //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        //    DataSet ds = LinkedInConnect.Fetch();

        //    string json = ds.ObjectToJSON();

        //    Response.Write(json);
        //    Response.End();


        //    imgPicture.ImageUrl = ds.Tables["person"].Rows[0]["picture-url"].ToString();
        //    lblName.Text = ds.Tables["person"].Rows[0]["first-name"].ToString();
        //    lblName.Text += " " + ds.Tables["person"].Rows[0]["last-name"].ToString();
        //    lblEmailAddress.Text = ds.Tables["person"].Rows[0]["email-address"].ToString();
        //    lblHeadline.Text = ds.Tables["person"].Rows[0]["headline"].ToString();
        //    lblIndustry.Text = ds.Tables["person"].Rows[0]["industry"].ToString();
        //    lblLinkedInId.Text = ds.Tables["person"].Rows[0]["id"].ToString();
        //    lblLocation.Text = ds.Tables["location"].Rows[0]["name"].ToString();
        //    imgPicture.ImageUrl = ds.Tables["person"].Rows[0]["picture-url"].ToString();
        //}
    }




}