using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Assessment : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {

            List<Model_AsSection> sec = AssessmentController.GetSectionList();
            dropSection.DataSource = sec;
            dropSection.DataTextField = "Title";
            dropSection.DataValueField = "SCID";
            dropSection.DataBind();

            dropsecs.DataSource = sec;
            dropsecs.DataTextField = "Title";
            dropsecs.DataValueField = "SCID";
            dropsecs.DataBind();

            

            dropQType.DataSource = AssessmentController.GetQTypeAllByStatus(true);
            dropQType.DataTextField = "Title";
            dropQType.DataValueField = "QTID";
            dropQType.DataBind();
            


            Model_AsSubSection ss = new Model_AsSubSection
            {
                SCID = int.Parse(dropSection.SelectedValue)
            };

            List<Model_AsSubSection> sub = AssessmentController.getSubsectionBySecId(ss);
            dropsub.DataSource = sub;
            dropsub.DataTextField = "Title";
            dropsub.DataValueField = "SUCID";
            dropsub.DataBind();
            
        }


        if (!string.IsNullOrEmpty(Request.QueryString["tab"]))
        {
            string tab = Request.QueryString["tab"];

            switch (tab)
            {
                case "2":
                    tab1.Attributes.Add("aria-expanded", "false");
                    //tab2.Attributes.Add("aria-expanded", "true");
                    //tab3.Attributes.Add("aria-expanded", "false");
                    //tab4.Attributes.Add("aria-expanded", "false");

                    li_tab1.Attributes.Remove("class");
                    //li_tab2.Attributes.Add("class", "active");
                    //li_tab3.Attributes.Remove("class");
                    //li_tab4.Attributes.Remove("class");


                    tab_content1.Visible = false;
                    //tab_content2.Visible = true;
                    //tab_content3.Visible = false;
                    //tab_content4.Visible = false;


                    //List<Model_AsSection> sec = AssessmentController.GetSectionList();
                    //dropSection.DataSource = sec;
                    //dropSection.DataTextField = "Title";
                    //dropSection.DataValueField = "SCID";
                    //dropSection.DataBind();

                    //dropsection2.DataSource = sec;
                    //dropsection2.DataTextField = "Title";
                    //dropsection2.DataValueField = "SCID";
                    //dropsection2.DataBind();

                    //ListItem lis = new ListItem("All", "0");
                    //dropsection2.Items.Insert(0, lis);




                    break;
                case "3":
                    tab1.Attributes.Add("aria-expanded", "false");
                    //tab2.Attributes.Add("aria-expanded", "false");
                    //tab3.Attributes.Add("aria-expanded", "true");
                    //tab4.Attributes.Add("aria-expanded", "false");

                    li_tab1.Attributes.Remove("class");
                    //li_tab2.Attributes.Remove("class");
                    //li_tab3.Attributes.Add("class", "active");
                    //li_tab4.Attributes.Remove("class");

                    tab_content1.Visible = false;
                    //tab_content2.Visible = false;
                    //tab_content3.Visible = true;
                    //tab_content4.Visible = false;



                    break;
                case "4":
                    tab1.Attributes.Add("aria-expanded", "false");
                    //tab2.Attributes.Add("aria-expanded", "false");
                    //tab3.Attributes.Add("aria-expanded", "false");
                    //tab4.Attributes.Add("aria-expanded", "true");

                    li_tab1.Attributes.Remove("class");
                    //li_tab2.Attributes.Remove("class");
                    //li_tab3.Attributes.Remove("class");
                    //li_tab4.Attributes.Add("class", "active");


                    tab_content1.Visible = false;
                    //tab_content2.Visible = false;
                    //tab_content3.Visible = false;
                    //tab_content4.Visible = true;


                    Model_AssesIntro ai = AssessmentController.GetAssIntro();
                    //txtIntroTitle.Text = ai.Title;
                    //txtIntroContent.Text = ai.Description;

                    break;
            }
        }
        else
        {

            tab_content1.Visible = true;
            //tab_content2.Visible = false;
            //tab_content3.Visible = false;
            //tab_content4.Visible = false;

            tab1.Attributes.Add("aria-expanded", "true");
            //tab2.Attributes.Add("aria-expanded", "false");
            //tab3.Attributes.Add("aria-expanded", "false");
            //tab4.Attributes.Add("aria-expanded", "false");

            li_tab1.Attributes.Add("class", "active");
            //li_tab2.Attributes.Remove("class");
            //li_tab3.Attributes.Remove("class");
            //li_tab4.Attributes.Remove("class");





        }
    }





    protected void Button1_Click(object sender, EventArgs e)
    {
        //string s = SectionTitle.Text.Trim();
        //string c = txtCode.Text.Trim();
        //string i = txtintro.Text.Trim();
        //bool st = bool.Parse(status.SelectedValue);
        //int pr = int.Parse(txtpri.Text);


        //Button btn = (Button)sender;

        //if (!string.IsNullOrEmpty(Request.QueryString["section"]))
        //{
        //    byte bytID = byte.Parse(Request.QueryString["section"]);
        //    if (AssessmentController.EditSection(bytID, s, c, i, st, pr))
        //    {
        //        Response.Redirect("Assessmentoptionaddedit");
        //    }
        //}
        //else
        //{
        //    if (AssessmentController.AddSection(s, c, i, pr) > 0)
        //    {
        //        Response.Redirect(Request.Url.ToString());
        //    }
        //}

    }

    protected void btnAddnewSection_Click(object sender, EventArgs e)
    {
        add_section.Visible = true;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        add_section.Visible = false;
    }



    protected void dropSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intSCID = int.Parse(dropSection.SelectedValue);
        Model_AsSubSection ss = new Model_AsSubSection
        {
            SCID = intSCID,
        };

        List<Model_AsSubSection> sub = AssessmentController.getSubsectionBySecId(ss);
        dropsub.DataSource = sub;
        dropsub.DataTextField = "Title";
        dropsub.DataValueField = "SUCID";
        dropsub.DataBind();

        if(intSCID == 7)
        {
            dropsubrigth.DataSource = sub;
            dropsubrigth.DataTextField = "Title";
            dropsubrigth.DataValueField = "SUCID";
            dropsubrigth.DataBind();

            dropsubrigth.Visible = true;


        }
    }
}