using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Assessmentoptionaddedit : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["section"]))
            {
                add_section.Visible = true;
                int id = int.Parse(Request.QueryString["section"]);
                Model_AsSection sec = AssessmentController.getSectionByID(id);
                SectionTitle.Text = sec.Title;
                txtCode.Text = sec.Code;
                txtintro.Text = sec.Intro;
                status.SelectedValue = sec.Status.ToString();
                txtpri.Text = sec.Priority.ToString();
                headsection_pan.InnerHtml = "Edit Section";


                //Button btneditsec = (Button)FindControl("Button1");
                //btneditsec.CommandName = "Edit";
                //btneditsec.CommandName = "Edit";
            }

            if (!string.IsNullOrEmpty(Request.QueryString["subsection"]))
            {
                sub_pan.Visible = true;
                int subid = int.Parse(Request.QueryString["subsection"]);
                Model_AsSubSection sub = AssessmentController.getSubByID(subid);
                dropSection.SelectedValue = sub.SCID.ToString();
                txtSubTitle.Text = sub.Title;
                radioSubStatus.Text = sub.Status.ToString();


                headsection_pan1.InnerHtml = "Edit Sub Section";


                //Button btneditsec = (Button)FindControl("Button1");
                //btneditsec.CommandName = "Edit";
                //btneditsec.CommandName = "Edit";
            }

            if (!string.IsNullOrEmpty(Request.QueryString["qt"]))
            {
                qType_pan.Visible = true;
                byte subid = byte.Parse(Request.QueryString["qt"]);
                Model_QType q = AssessmentController.GetQtypeID(subid);
                txtQtitle.Text = q.Title;
                qstatus.SelectedValue = q.Status.ToString();

                headsection_pan1.InnerHtml = "Edit Question Type";


                //Button btneditsec = (Button)FindControl("Button1");
                //btneditsec.CommandName = "Edit";
                //btneditsec.CommandName = "Edit";
            }
           


        }


        if (!string.IsNullOrEmpty(Request.QueryString["tab"]))
        {
            string tab = Request.QueryString["tab"];

            switch (tab)
            {
                case "2":
                    tab1.Attributes.Add("aria-expanded", "false");
                    tab2.Attributes.Add("aria-expanded", "true");
                    tab3.Attributes.Add("aria-expanded", "false");
                    tab4.Attributes.Add("aria-expanded", "false");

                    li_tab1.Attributes.Remove("class");
                    li_tab2.Attributes.Add("class", "active");
                    li_tab3.Attributes.Remove("class");
                    li_tab4.Attributes.Remove("class");


                    tab_content1.Visible = false;
                    tab_content2.Visible = true;
                    tab_content3.Visible = false;
                    tab_content4.Visible = false;


                    List<Model_AsSection> sec = AssessmentController.GetSectionList();
                    dropSection.DataSource = sec;
                    dropSection.DataTextField = "Title";
                    dropSection.DataValueField = "SCID";
                    dropSection.DataBind();

                    dropsection2.DataSource = sec;
                    dropsection2.DataTextField = "Title";
                    dropsection2.DataValueField = "SCID";
                    dropsection2.DataBind();

                    ListItem lis = new ListItem("All", "0");
                    dropsection2.Items.Insert(0, lis);




                    break;
                case "3":
                    tab1.Attributes.Add("aria-expanded", "false");
                    tab2.Attributes.Add("aria-expanded", "false");
                    tab3.Attributes.Add("aria-expanded", "true");
                    tab4.Attributes.Add("aria-expanded", "false");

                    li_tab1.Attributes.Remove("class");
                    li_tab2.Attributes.Remove("class");
                    li_tab3.Attributes.Add("class", "active");
                    li_tab4.Attributes.Remove("class");

                    tab_content1.Visible = false;
                    tab_content2.Visible = false;
                    tab_content3.Visible = true;
                    tab_content4.Visible = false;



                    break;
                case "4":
                    tab1.Attributes.Add("aria-expanded", "false");
                    tab2.Attributes.Add("aria-expanded", "false");
                    tab3.Attributes.Add("aria-expanded", "false");
                    tab4.Attributes.Add("aria-expanded", "true");

                    li_tab1.Attributes.Remove("class");
                    li_tab2.Attributes.Remove("class");
                    li_tab3.Attributes.Remove("class");
                    li_tab4.Attributes.Add("class", "active");


                    tab_content1.Visible = false;
                    tab_content2.Visible = false;
                    tab_content3.Visible = false;
                    tab_content4.Visible = true;


                    Model_AssesIntro ai = AssessmentController.GetAssIntro();
                    txtIntroTitle.Text = ai.Title;
                    txtIntroContent.Text = ai.Description;

                    break;
            }
        }
        else
        {

            tab_content1.Visible = true;
            tab_content2.Visible = false;
            tab_content3.Visible = false;
            tab_content4.Visible = false;

            tab1.Attributes.Add("aria-expanded", "true");
            tab2.Attributes.Add("aria-expanded", "false");
            tab3.Attributes.Add("aria-expanded", "false");
            tab4.Attributes.Add("aria-expanded", "false");

            li_tab1.Attributes.Add("class", "active");
            li_tab2.Attributes.Remove("class");
            li_tab3.Attributes.Remove("class");
            li_tab4.Attributes.Remove("class");





        }
    }


   


    protected void Button1_Click(object sender, EventArgs e)
    {
        string s = SectionTitle.Text.Trim();
        string c = txtCode.Text.Trim();
        string i = txtintro.Text.Trim();
        bool st = bool.Parse(status.SelectedValue);
        int pr = int.Parse(txtpri.Text);


        Button btn = (Button)sender;

        if(!string.IsNullOrEmpty(Request.QueryString["section"]))
        {
            byte bytID = byte.Parse(Request.QueryString["section"]);
            if (AssessmentController.EditSection(bytID,s, c, i,st,pr))
            {
                Response.Redirect("Assessmentoptionaddedit");
            }
        }
        else
        {
            if (AssessmentController.AddSection(s, c, i,pr) > 0)
            {
                Response.Redirect(Request.Url.ToString());
            }
        }
       
    }

    protected void btnAddnewSection_Click(object sender, EventArgs e)
    {
        add_section.Visible = true;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Assessmentoptionaddedit");
        //add_section.Visible = false;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        

        int secID = int.Parse(dropSection.SelectedValue);

        string strtitle = txtSubTitle.Text.Trim();
        bool Status = bool.Parse(radioSubStatus.SelectedValue);
        Model_AsSubSection sub = new Model_AsSubSection
        {
            SCID = secID,
            Title = strtitle,
            Status = Status,

        };

        Button btn = (Button)sender;

        if (!string.IsNullOrEmpty(Request.QueryString["subsection"]))
        {
            int bytID = int.Parse(Request.QueryString["subsection"]);
            sub.SUCID = bytID;

            if (AssessmentController.EditSubSection(sub))
            {
                Response.Redirect("Assessmentoptionaddedit?tab=2");
            }
        }
        else
        {
            if (AssessmentController.AddSubSection(sub) > 0)
            {
                Response.Redirect(Request.Url.ToString());
            }
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("Assessmentoptionaddedit?tab=2");
        //sub_pan.Visible  = false;
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        sub_pan.Visible = true;
    }




    protected void Button10_Click(object sender, EventArgs e)
    {
        

        string strtitle = txtQtitle.Text.Trim();
        bool Status = bool.Parse(qstatus.SelectedValue);
        Model_QType q = new Model_QType
        {
            Title = strtitle,
            Status = Status
        };
        

        Button btn = (Button)sender;

        if (!string.IsNullOrEmpty(Request.QueryString["qt"]))
        {
            int bytID = int.Parse(Request.QueryString["qt"]);
            q.QTID = bytID;

            if (AssessmentController.EditQType(q))
            {
                Response.Redirect("Assessmentoptionaddedit?tab=3");
            }
        }
        else
        {
            if (AssessmentController.AddQtype(q) > 0)
            {
                Response.Redirect(Request.Url.ToString());
            }
        }
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        qType_pan.Visible = true;
    }

   

    protected void Button11_Click(object sender, EventArgs e)
    {
        Response.Redirect("Assessmentoptionaddedit?tab=3");
        //qType_pan.Visible = false;
    }

    

    protected void Button14_Click(object sender, EventArgs e)
    {
        Model_AssesIntro intro = new Model_AssesIntro
        {
             Title = txtIntroTitle.Text.Trim(),
             Description = txtIntroContent.Text.Trim()
        };
        if (AssessmentController.UpdateIntro(intro))
        {
            Response.Redirect("Assessmentoptionaddedit?tab=4");
        }
        
    }
}