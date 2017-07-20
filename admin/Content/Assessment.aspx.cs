﻿using System;
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



            if (!string.IsNullOrEmpty(Request.QueryString["ass"]))
            {
                add_section.Visible = true;
                byte id = byte.Parse(Request.QueryString["ass"]);


                Model_Assessment ass = AssessmentController.GetAssessmentByID(id);
               
            
                if(ass.AssChoice.Count > 0)
                {
                    dropChoice_ret.DataSource = ass.AssChoice;
                    dropChoice_ret.DataTextField = "Questions";
                    dropChoice_ret.DataValueField = "Priority";
                    dropChoice_ret.DataBind(); 
                }

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
        int section = int.Parse(dropSection.SelectedValue);

        int? intSUCID = null;
        int? intSUCIDLF = null;
        int? intSUCIDRT = null;

        if(intSUCID == 7)
        {
            intSUCIDLF = int.Parse(dropsub.SelectedValue);
            intSUCIDRT = int.Parse(dropsubrigth.SelectedValue);
        }
        else
        {
            intSUCID = int.Parse(dropsub.SelectedValue);
        }

        List<Model_Assessment_Choice> cl = new List<Model_Assessment_Choice>();
        if (!string.IsNullOrEmpty(Request.Form["chk_choice"]))
        {
            string[] arrchoice = Request.Form["chk_choice"].Split(',');

            foreach (string i in arrchoice)
            {
                cl.Add(new Model_Assessment_Choice
                {
                    Questions = Request.Form["question_s_" + i],
                    Priority = int.Parse(Request.Form["pri_s_" + i]),
                    

                });

            }


        }

        Model_Assessment ass = new Model_Assessment
        {
            Questions = QuestionTitle.Text.Trim(),
            Code = txtCode.Text.Trim(),
            SCID = int.Parse(dropSection.SelectedValue),
            SUCID = intSUCID,
            Status = true,
            QTID = byte.Parse(dropQType.SelectedValue),
            SUCIDLF = intSUCIDLF,
            SUCIDRT = intSUCIDRT,
            Priority = int.Parse(txtpri.Text.Trim()),
            StartRank = int.Parse(txtStartRank.Text.Trim()),
            EndRank = int.Parse(txtEndRank.Text.Trim()), 
             AssChoice = cl

        };

        Button btn = (Button)sender;

        if (!string.IsNullOrEmpty(Request.QueryString["ass"]))
        {
            byte bytID = byte.Parse(Request.QueryString["ass"]);
            if (AssessmentController.EditAssessment(ass))
            {
                Response.Redirect("Assessment");
            }
        }
        else
        {
            int Assid = AssessmentController.AddAssessment(ass);
            if (Assid > 0)
            {

                    //Model_Assessment_Choice
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