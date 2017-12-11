using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class _Orders : BasePageFront
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {

            //if (!string.IsNullOrEmpty(Request.QueryString["success"]))
            //{
            //    main_thanks.Visible = true;
            //    main_form.Visible = false;

            //    Model_AssesIntro intro = new Model_AssesIntro();
            //    intro = intro.GetIntro();
            //    ThanksTitle.Text = intro.ThanksTitle;
            //    ThanksDes.Text = convertcontent(intro.ThanksDes);
            //}

            Model_Users u = this.UserActive;
            if (u != null)

            {
                


                //Get Job Function
                Model_CJF cjf = new Model_CJF();
                List<Model_CJF> cjflist = cjf.GetCJFeAll();

                Model_UserCJF cjflistUser = new Model_UserCJF();
                List<Model_UserCJF> cjfuserChecked = cjflistUser.GetListUsercjf(u.UserID);

                //Get Functional Competencies
                Model_FC fc = new Model_FC();
                List<Model_FC> fclist = fc.GetFCAll();

                Model_UserFC fcuser = new Model_UserFC();
                List<Model_UserFC> fcuserchecked = fcuser.GetListUserFc(u.UserID);

               
                //Get Country
                Model_Country c = new Model_Country();
                List<Model_Country> ccountry = c.GetAllCountry();


                dropNation.DataSource = ccountry;
                dropNation.DataTextField = "DropValue";
                dropNation.DataValueField = "ID";
                dropNation.DataBind();

                dropNation.SelectedValue = "211";


                StringBuilder strcjf = new StringBuilder();
                StringBuilder strfc = new StringBuilder();


                strcjf.Append("<div  class=\"checkitem\">");


                foreach (Model_CJF i in cjflist.Where(o=>o.Status))
                {



                    string check = string.Empty;
                    if (cjfuserChecked.Where(r => r.CJFID == i.CJFID).Count() > 0)
                        check = "Checked=\"Checked\"";


                    strcjf.Append("<div class=\"item\">");


                    strcjf.Append("<input  type=\"checkbox\" name=\"chckCJF_form\" " + check + " class=\"role_cjf_valid\" value=\"" + i.CJFID + "\">");
                    strcjf.Append("<label>" + i.Title + "</label>");
                    strcjf.Append("</div>");
                }


                strcjf.Append("</div>");



                //strfc.Append("<div class=\"checkitem\">");

                //foreach (Model_FC i in fclist)
                //{

                //    string check = string.Empty;
                //    if (fcuserchecked.Where(r => r.FCID == i.FCID).Count() > 0)
                //        check = "Checked=\"Checked\"";

                //    strfc.Append("<div class=\"item\">");
                //    strfc.Append("<input  type=\"checkbox\" name=\"chckFC_form\" " + check + " class=\"role_fc_valid\" value=\"" + i.FCID + "\">");
                //    strfc.Append("<label>" + i.Title + "</label>");
                //    strfc.Append("</div>");


                //}

                //strfc.Append("</div>");

                chckCJF.Text = strcjf.ToString();
                //checkFC.Text = strfc.ToString();


                Maintitle.Text = "Your Profile";

                

              


                //Binding profile (initial data)
                heUserID.Value = u.UserID.ToString();
                firstName.Text = (string.IsNullOrEmpty(u.FirstName) ? "" : u.FirstName);
                LastName.Text = (string.IsNullOrEmpty(u.LastName) ? "" : u.LastName);
                dropGender.SelectedValue = u.Gender.ToString();
                dropNation.SelectedValue = u.Nationality.ToString();
                day.Text = (u.DateofBirth != null ? u.DateofBirth.ToString("yyy-MM-dd") : "");
                txtPhon.Text = (string.IsNullOrEmpty(u.MobileNumber) ? "" : u.MobileNumber);
                txtEmail.Text = u.Email;
            }
            
           
        }
       
       



    }

    

   
   

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("sss");
        Response.End();
    }

    protected void btnBackprofile_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default#download");
    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        int UserId = int.Parse(Request.Form["ctl00$MainContent$heUserID"]);
        string FirstName = Request.Form["ctl00$MainContent$firstName"];
        string LastName = Request.Form["ctl00$MainContent$LastName"];

        string bytGender = Request.Form["ctl00$MainContent$dropGender"];

        string Nationality = Request.Form["ctl00$MainContent$dropNation"];
        string DatBirth = Request.Form["ctl00$MainContent$day"];

        string Phone = Request.Form["ctl00$MainContent$txtPhon"];

        Model_Users us = new Model_Users
        {
            Email = txtEmail.Text.Trim(),
            UserID = UserId,
            FirstName = FirstName,
            LastName = LastName,
            DateofBirth = DatBirth.DateSplitYear('-'),
            Gender = byte.Parse(bytGender),
            Nationality = int.Parse(Nationality),
            MobileNumber = Phone
        };

       int ret = us.UpdateUserProfileUserEdit(us);

        if(ret > 0)
        {

            string FCCheck = Request.Form["chckFC_form"];
            if (!string.IsNullOrEmpty(FCCheck))
            {
                string[] arrfc = FCCheck.Split(',');
                if (arrfc.Length > 0)
                {
                    List<Model_UserFC> list = new List<Model_UserFC>();

                    foreach (string i in arrfc)
                    {

                        list.Add(new Model_UserFC
                        {
                            FCID = int.Parse(i),
                            UserID = UserId
                        });


                    }
                    Model_UserFC fc = new Model_UserFC();

                    fc.AddUserFC(list, UserId);
                }
            }



            //Current Job 

            string CJFCheck = Request.Form["chckCJF_form"];

            if (!string.IsNullOrEmpty(CJFCheck))
            {
                string[] arrcjf = CJFCheck.Split(',');
                if (arrcjf.Length > 0)
                {
                    List<Model_UserCJF> list = new List<Model_UserCJF>();
                    foreach (string i in arrcjf)
                    {
                        list.Add(new Model_UserCJF
                        {
                            CJFID = int.Parse(i),
                            UserID = UserId
                        });


                    }
                    Model_UserCJF cjf = new Model_UserCJF();
                    cjf.AddUserCjf(list, UserId);
                }
            }



            Response.Redirect(Request.Url.ToString());
        }
        else
        {
            lblError.Text = "The User Name is user already";
        }
        //Fuction Competencies




       
    }
}