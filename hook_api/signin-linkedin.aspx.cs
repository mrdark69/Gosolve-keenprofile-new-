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

public partial class external_signin_linkedin : System.Web.UI.Page
{
   //public  Microsoft.Owin.IOwinContext Context { get; set; }
    public void Page_Load(object sender, EventArgs e)
    {

        LinkedInConnect.APIKey = "81h1zat2gc50un";
        LinkedInConnect.APISecret = "ZLi6H1m1k6EICMES";
        LinkedInConnect.RedirectUrl = Request.Url.AbsoluteUri.Split('?')[0];
       


        if (LinkedInConnect.IsAuthorized)
        {
            pnlDetails.Visible = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
            DataSet ds = LinkedInConnect.Fetch();
        
            imgPicture.ImageUrl = ds.Tables["person"].Rows[0]["picture-url"].ToString();
            lblName.Text = ds.Tables["person"].Rows[0]["first-name"].ToString();
            lblName.Text += " " + ds.Tables["person"].Rows[0]["last-name"].ToString();
            lblEmailAddress.Text = ds.Tables["person"].Rows[0]["email-address"].ToString();
            lblHeadline.Text = ds.Tables["person"].Rows[0]["headline"].ToString();
            lblIndustry.Text = ds.Tables["person"].Rows[0]["industry"].ToString();
            lblLinkedInId.Text = ds.Tables["person"].Rows[0]["id"].ToString();
            lblLocation.Text = ds.Tables["location"].Rows[0]["name"].ToString();
            imgPicture.ImageUrl = ds.Tables["person"].Rows[0]["picture-url"].ToString();
        }
    }

    public void GetUserProfile()

    {


        //var request = new RestRequest { Path = "~" };


        //var credentials = new Hammock.Authentication.OAuth.OAuthCredentials

        //{

        //    Type = Hammock.Authentication.OAuth.OAuthType.AccessToken,

        //    SignatureMethod = Hammock.Authentication.OAuth.OAuthSignatureMethod.HmacSha1,

        //    ParameterHandling = Hammock.Authentication.OAuth.OAuthParameterHandling.HttpAuthorizationHeader,

        //    ConsumerKey = "81h1zat2gc50un",

        //    ConsumerSecret = "ZLi6H1m1k6EICMES",

        //    Token = Session["AccessToken"].ToString(),

        //    TokenSecret = Session["AccessSecretToken"].ToString(),

        //    Verifier = Session["Verifier"].ToString()

        //};


        //var client = new
        //RestClient()

        //{

        //    Authority = "http://api.linkedin.com/v1/people&#8221;, Credentials = credentials, Method = WebMethod.Get"

        //};


        //var MyInfo = client.Request(request);


        //String content = MyInfo.Content.ToString();


        //var person = from c in
        //XElement.Parse(content).Elements()


        //             select c;


        //String fullName = String.Empty;


        //foreach (var element in person)

        //{


        //    if ((element.Name == "first-name") || (element.Name == "last-name"))

        //        fullName += element.Value.ToString();

        //}

        //lblName.Text = fullName;

    }
}