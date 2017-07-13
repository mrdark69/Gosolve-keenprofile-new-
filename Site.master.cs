using gs_newsletter;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class SiteMaster : MasterPage
{
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;

    protected void Page_Init(object sender, EventArgs e)
    {
        //Response.Write();
        //Response.End();

        //if (!Context.User.Identity.IsAuthenticated)
        //{
        //   // IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        //    //Response.Redirect("Demo");
        //    //Response.End();
        //}


        //var manager = new UserManager();
        //ApplicationUser user = manager.FindById(HttpContext.Current.User.Identity.GetUserId());
        //Response.Write(user.FirstName);
        //Response.End();


        //var manager = new UserManager();
        //UserLoginInfo login = manager.(HttpContext.Current.User.Identity.GetUserId()).FirstOrDefault();
        //login.

        // ApplicationUser user = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(User.Identity.GetUserId());
        //string currentUserId = HttpContext.Current.User.Identity.GetUserId();
        //ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

        // The code below helps to protect against XSRF attacks
        //var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        //Guid requestCookieGuidValue;
        //if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
        //{
        //    // Use the Anti-XSRF token from the cookie
        //    _antiXsrfTokenValue = requestCookie.Value;
        //    Page.ViewStateUserKey = _antiXsrfTokenValue;
        //}
        //else
        //{
        //    // Generate a new Anti-XSRF token and save to the cookie
        //    _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
        //    Page.ViewStateUserKey = _antiXsrfTokenValue;

        //    var responseCookie = new HttpCookie(AntiXsrfTokenKey)
        //    {
        //        HttpOnly = true,
        //        Value = _antiXsrfTokenValue
        //    };
        //    if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
        //    {
        //        responseCookie.Secure = true;
        //    }
        //    Response.Cookies.Set(responseCookie);
        //}

        //Page.PreLoad += master_Page_PreLoad;
    }

    public string getUser()
    {
        return "";
        //var manager = new UserManager();
        //ApplicationUser user = manager.FindById(HttpContext.Current.User.Identity.GetUserId());

        //if (user != null)
        //    return user.FirstName;
        //else
        //    return string.Empty;
    }


    public string UserStatus()
    {
        StringBuilder ret = new StringBuilder();
        if (Session["staff"] != null)
        {
           
            Model_Session ms = new Model_Session();
            ms = ms.IsHaveSessionRecord(UserSessionController.CurrentCookieLog);


            ret.Append("<span class=\"clear\"> <span class=\"block m-t-xs\"> <strong class=\"font-bold\">Welcome "+ms.FirstName+" </strong>");
            ret.Append("</span> <span class=\"text-muted text-xs block\">" + ms.UserRoleName + " <b class=\"caret\"></b></span> </span> </a>");
           
        }

        return ret.ToString();
    }

    
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
       
    }

    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        //Context.GetOwinContext().Authentication.SignOut();
    }

    protected string MenuActive(string file, string ischild = "")
    {
        string ret = string.Empty;


        string[] arrcurrentFile = Request.PhysicalPath.Split('\\');
        string currentFile = arrcurrentFile[arrcurrentFile.Length - 1];

        string[] child = ischild.Split(',');

        if (file.ToLower() == currentFile.ToLower()) { ret = "class=\"active\""; } 
        if (child.Length > 0 && !string.IsNullOrEmpty(ischild))
        {
            for(int i = 0;i < child.Length; i++)
            {
                if (currentFile.ToLower() == child[i].ToLower())
                {
                    ret = "class=\"active\"";
                    break;
                }
                   
            }
            //if (currentFile.IndexOf(child[i]) >= 0)

            //if (Array.IndexOf(child, currentFile) >= 0)
            //    ret = "class=\"active\"";
            //foreach (string ch in child)
            //{
            //    if (Array.IndexOf(child, currentFile) >= 0)
            //        ret = "class=\"active\"";

                //    break;
                //}

        }

        return ret;
    }

    protected string GetSideMenu()
    {
        StringBuilder ret = new StringBuilder();
        //List<Model_AppFeature> cmf = UsersController.GetMenu();

        //List<Model_AppFeature> cmf_child = UsersController.GetMenuChild();

        //foreach (Model_AppFeature item in cmf)
        //{
        //    List<Model_AppFeature> cmf_s = cmf_child.Where(c => c.IDRef == item.AppID).ToList();

        //    string slug = Page.ResolveClientUrl("~/" + item.Permarlink);
        //    bool IsChild = false;
        //    string arrow = string.Empty;
        //    string child = string.Empty;
        //    if (cmf_s.Count() > 0)
        //    {
        //        slug = "#";
        //        IsChild = true;
        //        arrow = "<span class=\"fa arrow\"></span>";

        //        child = String.Join(",", cmf_s.Select(r => r.Permarlink).ToArray());
        //    }
            

        //    ret.Append("<li "+ MenuActive(item.Permarlink , child) + ">");
        //    ret.Append("<a href=\""+ slug + "\"><i class=\"fa fa-th-large\"></i> <span class=\"nav-label\">"+item.Title+ "</span>"+ arrow + "</a>");



        //    if (IsChild)
        //    {
        //        ret.Append("<ul class=\"nav nav-second-level\">");
        //        foreach (Model_AppFeature i in cmf_s)
        //        {
        //            string slug_child = Page.ResolveClientUrl("~/" + i.Permarlink);
        //            ret.Append("<li " + MenuActive(i.Permarlink) + "><a href=\"" + slug_child + "\"><i class=\"fa fa-th-large\"></i> <span class=\"nav-label\">" + i.Title + "</span></a></li>");
        //        }
        //        ret.Append("</ul>");
        //    }

        //    ret.Append("</li>");

          
        //}


        return ret.ToString();
    }
}