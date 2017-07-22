using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePageFront : System.Web.UI.Page
{
    public Model_Users UserActive { get; set; }
    public BasePageFront()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    protected override void OnLoad(EventArgs e)
    {

        // StaffSessionAuthorize.CheckCooikie();
      Model_Users u =  UserSessionController.FrontAppAuthorization(this);

       

        if (u != null)
        {
            this.UserActive = u;
            if (!u.EmailVerify)
            {
              
                Page.Master.FindControl("alertbar").Visible = true;
                LinkButton l = (LinkButton)Page.Master.FindControl("sendmailverify");
                l.CommandArgument = u.UserID.ToString();

                if (!string.IsNullOrEmpty(Request.QueryString["resend"]))
                {
                    Page.Master.FindControl("alertbarsentmailcompleted").Visible = true;
                    //Page.Master.FindControl("alertbar").Visible = false;
                }
                else
                {
                    Page.Master.FindControl("alertbarsentmailcompleted").Visible = false;
                }
            }
                //Page.ClientScript.RegisterClientScriptBlock(GetType(), "alertVerify", "alertshow();", true);
           
        }

        base.OnLoad(e);
    }

    public static void RequestLogin()
    {
        HttpContext.Current.Response.Redirect("accessdenie.aspx?error=loginfailed");
    }
}