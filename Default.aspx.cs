using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

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


                //btnReport1 //btnReport3 //btnReport2

                Model_UsersTransaction Uts = new Model_UsersTransaction();
                List<Model_UsersTransaction> TSL = Uts.getTsListByUserID(u.UserID);
                if(TSL.Count > 0)
                {
                    btnReport1.Text = "Download Now";
                    btnReport2.Text = "Download Now";
                    btnReport3.Text = "Contact Us now";
                }
                else
                {
                    btnReport1.Text = "Do Assessment Now";
                    btnReport2.Text = "Do Assessment Now";
                    btnReport3.Text = "Do Assessment Now";

                    btnReport1.CommandArgument = "0";
                    btnReport2.CommandArgument = "0";
                    btnReport3.CommandArgument = "0";
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("sss");
        Response.End();
    }

    protected void btnReport1_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        int ReportType = btn.CommandArgument != string.Empty ? int.Parse(btn.CommandArgument) : 0;

        switch (ReportType)
        {
            case 0:
                Response.Redirect("Assessmentstep.aspx");
                Response.End();
                break;
            case 1:

                string report = AssessmentController.GetPaperReport1();
                byte[] html = pdfgen.pdfGenerate(report);

                pdfgen.ToClientSave(html, "KEENCareer-Finder-Report");
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }
}