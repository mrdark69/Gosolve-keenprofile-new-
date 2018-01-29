using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Verify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                string qId = StringUtility.DecryptedData(Request.QueryString["ID"]);

                try
                {
                    int UserID = int.Parse(qId);

                    UsersController.UpDateVerify(UserID);

                    Response.Redirect(globalHelper.BaseUrl());
                }
                catch  { }
            }
            
        }
    }

    
}