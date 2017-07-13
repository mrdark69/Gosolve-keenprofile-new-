using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
    public BasePage()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    protected override void OnLoad(EventArgs e)
    {

        // StaffSessionAuthorize.CheckCooikie();
        UserSessionController.AdminAppAuthorization(this);

        base.OnLoad(e);
    }

    public static void RequestLogin()
    {
        HttpContext.Current.Response.Redirect("accessdenie.aspx?error=loginfailed");
    }
}