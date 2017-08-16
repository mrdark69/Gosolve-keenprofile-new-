using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : BasePageFront
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            Model_Users u = this.UserActive;
            if (u != null)
            {
                name.Text = (String.IsNullOrEmpty( u.FirstName)?"XXXX": u.FirstName) + " " + (String.IsNullOrEmpty(u.LastName) ? "XXXX" : u.LastName) ;
                //cjf.Text = (u.UserCJF.Count > 0 ? u.UserCJF[0].Title : "XXX");
                //nation.InnerHtml = u.NationalityTitle;
                dob.Text = (u.DateofBirth != null?  u.DateofBirth.ToString("dd MMM yyyy") +
                    " ("+(DatetimeHelper._UTCNow().Year - u.DateofBirth.Year).ToString() + ")": "XXXX");
                gender.Text = (u.Gender == 1 ? "Male" : "Female");

               // fc.Text = string.Join(", ", u.UserFC.Select(r => r.Title).ToArray());
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("sss");
        Response.End();
    }
}