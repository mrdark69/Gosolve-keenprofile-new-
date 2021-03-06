﻿using System;
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

      

        this.Page.Title = "KeenProfile Member";
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

                if (!u.EmailVerify)
                {
                    Do_assessment.Attributes.Add("disabled", "disabled");

                    Do_assessment.Attributes.Add("onclick", "ShowAlert(event);");
                    //btnReport1.Attributes.Add("disabled", "disabled");
                    //btnReport2.Attributes.Add("disabled", "disabled");
                    //btnReport3.Attributes.Add("disabled", "disabled");
                    //btnReport4.Attributes.Add("disabled", "disabled");

                    btnReport1.Attributes.Add("onclick", "ShowAlert(event);");
                    btnReport2.Attributes.Add("onclick", "ShowAlert(event);");
                    btnReport3.Attributes.Add("onclick", "ShowAlert(event);");
                    btnReport4.Attributes.Add("onclick", "ShowAlert(event);");
                }

                //btnReport1 //btnReport3 //btnReport2
                int intProductID = 1;
                int intProductCoach = 2;
                Model_Orders o = new Model_Orders();
                int paid = o.CountIsPaidByProduct(intProductID,u.UserID);

                int paidCoaching = o.CountIsPaidByProduct(intProductCoach,u.UserID);

                Model_UsersTransaction Uts = new Model_UsersTransaction();
                List<Model_UsersTransaction> TSL = Uts.getTsListByUserID(u.UserID);


                sample_r1.NavigateUrl = "http://www.keenprofile.com/wp-content/uploads/2018/01/Example-KEENCareer-Finder-Report.pdf";
                sample_r2.NavigateUrl = "http://www.keenprofile.com/wp-content/uploads/2018/01/Example-Your-Current-Job-Company-Fit-Report.pdf";
                sample_r3.NavigateUrl = "http://www.keenprofile.com/wp-content/uploads/2018/01/Example-The-Right-Job-Functions-Report.pdf";
                if (TSL.Count > 0)
                {
                    btnReport1.Text = "คลิกเพื่อ Download";
                    btnReport2.Text = "คลิกเพื่อ Download";
                    btnReport3.Text = paid > 0? "คลิกเพื่อ Download" : "ต้องการ Download";

                    btnReport4.Text = paidCoaching > 0? "รอการ Coaching" : "ต้องการ Coaching";

                    if(paidCoaching>0)
                    {
                        fa_r4_1.Visible = false;
                        fa_r4_2.Visible = true;
                        btnReport4.CssClass = "btn_button btn_coach";
                    }

                 
                    if(paid > 0)
                    {
                        fa_r3_1.Visible = true;
                        fa_r3_2.Visible = false;
                        btnReport3.CssClass = "btn_button btn_r3";

                        sample_r3.Visible = false;
                    }

                    sample_r1.Visible = false;
                    sample_r2.Visible = false;
                }
                else
                {
                    btnReport1.Text = "คลิกเพื่อ Download";
                    btnReport2.Text = "คลิกเพื่อ Download";
                    btnReport3.Text = "ต้องการ Download";

                    btnReport4.Text = "ต้องการ Coaching";

                    btnReport1.CommandArgument = "0";
                    btnReport2.CommandArgument = "0";
                    btnReport3.CommandArgument = "0";
                    btnReport4.CommandArgument = "0";

                   
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
        Model_Users u = this.UserActive;
        Model_Orders o = new Model_Orders();
        switch (ReportType)
        {
            case 0:
                Response.Redirect("Assessmentstep.aspx");
                Response.End();
                break;
            case 1:
         
                string report = AssessmentController.GetPaperReport1(u);
                byte[] html = pdfgen.pdfGenerate(report);

                pdfgen.ToClientSave(html, "KEENCareer-Finder-Report");
                break;
            case 2:
                string report2 = AssessmentController.GetPaperReport2(u);
                byte[] html2 = pdfgen.pdfGenerate(report2);

                pdfgen.ToClientSave(html2, "Your-Current-Job-Company-Fit-Report");
                break;
            case 3:

                int intProductID = 1;

               
                int paid = o.CountIsPaidByProduct(intProductID,u.UserID);

                if (paid > 0)
                {
                    string report3 = AssessmentController.GetPaperReport3(u);
                    byte[] html3 = pdfgen.pdfGenerate(report3);

                    pdfgen.ToClientSave(html3, "The-Right-Job-Functions-Report");
                }
                else
                {
                    int orderID = OrderController.MakeOrder(intProductID, u);
                    if (orderID > 0)
                    {
                        Response.Redirect("Orders.aspx?orderID=" + orderID + "&ProductID=1");
                        Response.End();
                    }

                    
                }
              
                break;
            case 4:

                 intProductID = 2;

               
                 paid = o.CountIsPaidByProduct(intProductID, u.UserID);

                if (paid > 0)
                {
                    //string report3 = AssessmentController.GetPaperReport3(u);
                    //byte[] html3 = pdfgen.pdfGenerate(report3);

                    //pdfgen.ToClientSave(html3, "The-Right-Job-Functions-Report");
                }
                else
                {
                    int orderID = OrderController.MakeOrder(intProductID, u);
                    if (orderID > 0)
                    {
                        Response.Redirect("Orders.aspx?orderID=" + orderID + "&ProductID=2");
                        Response.End();
                    }


                }

                break;
        }
    }
}