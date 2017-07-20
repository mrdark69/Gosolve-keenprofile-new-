using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _UserContent : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {

            if (!string.IsNullOrEmpty(Request.QueryString["fc"]))
            {
                add_section.Visible = true;
                byte id = byte.Parse(Request.QueryString["fc"]);
                Model_FC sec = UsersController.GetFCID(id);
                SectionTitle.Text = sec.Title;
                //txtCode.Text = sec.Code;
                // txtintro.Text = sec.Intro;
                status.SelectedValue = sec.Status.ToString();
                // txtpri.Text = sec.Priority.ToString();
                headsection_pan.InnerHtml = "Edit Functional Competencies";

            }

            if (!string.IsNullOrEmpty(Request.QueryString["cjf"]))
            {
                sub_pan.Visible = true;
                int subid = int.Parse(Request.QueryString["cjf"]);
                Model_CJF sub = UsersController.GetCJF(subid);
                //dropSection.SelectedValue = sub.SCID.ToString();
                txtSubTitle.Text = sub.Title;
                radioSubStatus.Text = sub.Status.ToString();


                headsection_pan1.InnerHtml = "Edit Current Job Function";

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


                    li_tab1.Attributes.Remove("class");
                    li_tab2.Attributes.Add("class", "active");



                    tab_content1.Visible = false;
                    tab_content2.Visible = true;




                    

                    break;

            }
        }
        else
        {

            tab_content1.Visible = true;
            tab_content2.Visible = false;


            tab1.Attributes.Add("aria-expanded", "true");
            tab2.Attributes.Add("aria-expanded", "false");


            li_tab1.Attributes.Add("class", "active");
            li_tab2.Attributes.Remove("class");





            
        }
    }





    protected void Button1_Click(object sender, EventArgs e)
    {
        string s = SectionTitle.Text.Trim();
       // string c = txtCode.Text.Trim();
        //string i = txtintro.Text.Trim();
        bool st = bool.Parse(status.SelectedValue);
        //int pr = int.Parse(txtpri.Text);
        Model_FC sub = new Model_FC
        {
            //SCID = secID,
            Title = s,
            Status = st,

        };


        Button btn = (Button)sender;

        if (!string.IsNullOrEmpty(Request.QueryString["fc"]))
        {
            byte bytID = byte.Parse(Request.QueryString["fc"]);
            sub.FCID = bytID;
            if (UsersController.EditFC(sub))
            {
                Response.Redirect("UsersContent");
            }
        }
        else
        {
            if (UsersController.AddFc(sub) > 0)
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
        //  add_section.Visible = false;
        Response.Redirect("UsersContent");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {


       // int secID = int.Parse(dropSection.SelectedValue);

        string strtitle = txtSubTitle.Text.Trim();
        bool Status = bool.Parse(radioSubStatus.SelectedValue);
        Model_CJF sub = new Model_CJF
        {
            //SCID = secID,
            Title = strtitle,
            Status = Status,

        };

        Button btn = (Button)sender;

        if (!string.IsNullOrEmpty(Request.QueryString["cjf"]))
        {
            int bytID = int.Parse(Request.QueryString["cjf"]);
            sub.CJFID = bytID;

            if (UsersController.EditCJF(sub))
            {
                Response.Redirect("UsersContent?tab=2");
            }
        }
        else
        {
            if (UsersController.AddCJF(sub) > 0)
            {
                Response.Redirect(Request.Url.ToString());
            }
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        sub_pan.Visible = false;
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        //sub_pan.Visible = true;
        Response.Redirect("UsersContent?tab=2");
    }
}


