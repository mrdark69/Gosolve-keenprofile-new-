﻿using System;
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
            Model_AssesIntro ai = AssessmentController.GetAssIntro();
            txtIntroTitle.Text = ai.Title;
            txtIntroContent.Text = ai.Description;
            LastTitle.Text = ai.LastTitle;
            LastDes.Text = ai.LastDes;
            MainTitle.Text = ai.MainTitle;

            ThanksTitle.Text = ai.ThanksTitle;
            ThanksDes.Text = ai.ThanksDes;
            ProfileTitle.Text = ai.ProfileTitle;
            ProfileCJFTitle.Text = ai.ProfileCJFTitle;
            ProfileFCTitle.Text = ai.ProfileFCTitle;




            List<Model_AsSection> seclist = AssessmentController.GetSectionList(true);
            dropSection.DataSource = seclist;
            dropSection.DataTextField = "Title";
            dropSection.DataValueField = "SCID";
            dropSection.DataBind();

            dropsection2.DataSource = seclist;
            dropsection2.DataTextField = "Title";
            dropsection2.DataValueField = "SCID";
            dropsection2.DataBind();

            dropsection_1.DataSource = seclist;
            dropsection_1.DataTextField = "Title";
            dropsection_1.DataValueField = "SCID";
            dropsection_1.DataBind();


            dropsection2_2.DataSource = seclist;
            dropsection2_2.DataTextField = "Title";
            dropsection2_2.DataValueField = "SCID";
            dropsection2_2.DataBind();

            ListItem lis = new ListItem("All", "0");
            dropsection2.Items.Insert(0, lis);

           
            dropsection2_2.Items.Insert(0, lis);

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


            }

            if (!string.IsNullOrEmpty(Request.QueryString["subsection"]))
            {
                sub_pan.Visible = true;
                int subid = int.Parse(Request.QueryString["subsection"]);
                Model_AsSubSection sub = AssessmentController.getSubByID(subid);
                dropSection.SelectedValue = sub.SCID.ToString();
                txtSubTitle.Text = sub.Title;

                string comret = string.Empty;
                if (!string.IsNullOrEmpty(sub.Combind))
                {
                    string[] arrcom = sub.Combind.Split(',');
                    comret = string.Join(",", arrcom.Select(i => "SU" + i).ToArray());
                }
                
                Combind.Text = comret;
                radioSubStatus.Text = sub.Status.ToString();


                headsection_pan1.InnerHtml = "Edit Sub Section";


            }

            if (!string.IsNullOrEmpty(Request.QueryString["subsection2"]))
            {
                sub_pan2.Visible = true;
                int subid = int.Parse(Request.QueryString["subsection2"]);
                Model_AsSubSection2 sub = AssessmentController.getSubByID2(subid);
                dropsection_1.SelectedValue = sub.SCID.ToString();
                txtSubTitle2.Text = sub.Title;

                string comret = string.Empty;
                if (!string.IsNullOrEmpty(sub.Combind))
                {
                    string[] arrcom = sub.Combind.Split(',');
                    comret = string.Join(",", arrcom.Select(i => "SU" + i).ToArray());
                }

                Combind2.Text = comret;
                radioSubStatus2.Text = sub.Status.ToString();


                headsection_pan1.InnerHtml = "Edit Sub Section";


            }

            if (!string.IsNullOrEmpty(Request.QueryString["qt"]))
            {
                qType_pan.Visible = true;
                byte subid = byte.Parse(Request.QueryString["qt"]);
                Model_QType q = AssessmentController.GetQtypeID(subid);
                txtQtitle.Text = q.Title;
                qstatus.SelectedValue = q.Status.ToString();

                headsection_pan1.InnerHtml = "Edit Question Type";


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
                    tab5.Attributes.Add("aria-expanded", "false");

                    li_tab1.Attributes.Remove("class");
                    li_tab2.Attributes.Add("class", "active");
                    li_tab3.Attributes.Remove("class");
                    li_tab4.Attributes.Remove("class");
                    li_tab5.Attributes.Remove("class");


                    tab_content1.Visible = false;
                    tab_content2.Visible = true;
                    tab_content3.Visible = false;
                    tab_content4.Visible = false;
                    tab_content5.Visible = false;


                    if (!string.IsNullOrEmpty(Request.QueryString["section"]))
                    {
                        //dropsection2.SelectedValue = Request.QueryString["section"];
                    }



                    break;
                case "3":
                    tab1.Attributes.Add("aria-expanded", "false");
                    tab2.Attributes.Add("aria-expanded", "false");
                    tab3.Attributes.Add("aria-expanded", "true");
                    tab4.Attributes.Add("aria-expanded", "false");
                    tab5.Attributes.Add("aria-expanded", "false");

                    li_tab1.Attributes.Remove("class");
                    li_tab2.Attributes.Remove("class");
                    li_tab3.Attributes.Add("class", "active");
                    li_tab4.Attributes.Remove("class");
                    li_tab5.Attributes.Remove("class");

                    tab_content1.Visible = false;
                    tab_content2.Visible = false;
                    tab_content3.Visible = true;
                    tab_content4.Visible = false;
                    tab_content5.Visible = false;


                    break;
                case "4":
                    tab1.Attributes.Add("aria-expanded", "false");
                    tab2.Attributes.Add("aria-expanded", "false");
                    tab3.Attributes.Add("aria-expanded", "false");
                    tab4.Attributes.Add("aria-expanded", "true");
                    tab4.Attributes.Add("aria-expanded", "false");

                    li_tab1.Attributes.Remove("class");
                    li_tab2.Attributes.Remove("class");
                    li_tab3.Attributes.Remove("class");
                    li_tab4.Attributes.Add("class", "active");
                    li_tab5.Attributes.Remove("class");

                    tab_content1.Visible = false;
                    tab_content2.Visible = false;
                    tab_content3.Visible = false;
                    tab_content4.Visible = true;
                    tab_content5.Visible = false;



                    break;
                case "5":
                    tab1.Attributes.Add("aria-expanded", "false");
                    tab2.Attributes.Add("aria-expanded", "false");
                    tab3.Attributes.Add("aria-expanded", "false");
                    tab4.Attributes.Add("aria-expanded", "false");
                    tab5.Attributes.Add("aria-expanded", "true");

                    li_tab1.Attributes.Remove("class");
                    li_tab2.Attributes.Remove("class");
                    li_tab3.Attributes.Remove("class");
                    li_tab4.Attributes.Remove("class");
                    li_tab5.Attributes.Add("class", "active");

                    tab_content1.Visible = false;
                    tab_content2.Visible = false;
                    tab_content3.Visible = false;
                    tab_content4.Visible = false;
                    tab_content5.Visible = true;

                    if (!string.IsNullOrEmpty(Request.QueryString["section"]))
                    {
                       // dropsection2_2.SelectedValue = Request.QueryString["section"];
                    }

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

        string combind = Combind.Text;
        string combindRet = string.Empty;

        if (!string.IsNullOrEmpty(combind))
        {
            string[] arrc = combind.Split(',');
            combindRet = string.Join(",", arrc.Select(i => i.Substring(2)).ToArray());
        }

        Model_AsSubSection sub = new Model_AsSubSection
        {
            SCID = secID,
            Title = strtitle,
            Status = Status,
            Combind = combindRet

        };

        Button btn = (Button)sender;

        if (!string.IsNullOrEmpty(Request.QueryString["subsection"]))
        {
            int bytID = int.Parse(Request.QueryString["subsection"]);
            sub.SUCID = bytID;

            if (AssessmentController.EditSubSection(sub))
            {
                Response.Redirect("Assessmentoptionaddedit?tab=2&section=" + dropSection.SelectedValue);
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
        Response.Redirect("Assessmentoptionaddedit?tab=2&section=" + dropsection2.SelectedValue);
        //sub_pan.Visible  = false;
    }


    protected void Button6_Click(object sender, EventArgs e)
    {


        int secID = int.Parse(dropsection_1.SelectedValue);

        string strtitle = txtSubTitle2.Text.Trim();
        bool Status = bool.Parse(radioSubStatus2.SelectedValue);

        string combind = Combind2.Text;
        string combindRet = string.Empty;

        if (!string.IsNullOrEmpty(combind))
        {
            string[] arrc = combind.Split(',');
            combindRet = string.Join(",", arrc.Select(i => i.Substring(2)).ToArray());
        }
        Model_AsSubSection2 sub = new Model_AsSubSection2
        {
            SCID = secID,
            Title = strtitle,
            Status = Status,
            Combind = combindRet

        };

        Button btn = (Button)sender;

        if (!string.IsNullOrEmpty(Request.QueryString["subsection2"]))
        {
            int bytID = int.Parse(Request.QueryString["subsection2"]);
            sub.SUCID2 = bytID;

            if (AssessmentController.EditSubSection2(sub))
            {
                Response.Redirect("Assessmentoptionaddedit?tab=5&section=" + dropsection_1.SelectedValue);
            }
        }
        else
        {
            if (AssessmentController.AddSubSection2(sub) > 0)
            {
                Response.Redirect(Request.Url.ToString());
            }
        }
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        Response.Redirect("Assessmentoptionaddedit?tab=5&section=" + dropsection2_2.SelectedValue);
        //sub_pan.Visible  = false;
    }

    protected void Button5_Click(object sender, EventArgs e)
    {

        if(int.Parse(dropsection2.SelectedValue) > 0)
        {
            dropSection.SelectedValue = dropsection2.SelectedValue;
        }
        sub_pan.Visible = true;
    }

    protected void Button8_Click(object sender, EventArgs e)
    {

        if (int.Parse(dropsection2_2.SelectedValue) > 0)
        {
            dropsection_1.SelectedValue = dropsection2_2.SelectedValue;
        }
        sub_pan2.Visible = true;
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
             Description = txtIntroContent.Text.Trim(),
            LastTitle = LastTitle.Text.Trim(),
            LastDes = LastDes.Text.Trim(),
            MainTitle = MainTitle.Text.Trim(),

            ThanksTitle = ThanksTitle.Text.Trim(),
            ThanksDes = ThanksDes.Text.Trim(),
            ProfileTitle = ProfileTitle.Text.Trim(),
            ProfileCJFTitle = ProfileCJFTitle.Text.Trim(),
            ProfileFCTitle = ProfileFCTitle.Text.Trim(),

        };
        if (AssessmentController.UpdateIntro(intro))
        {
            Response.Redirect("Assessmentoptionaddedit?tab=4");
        }
        
    }
}