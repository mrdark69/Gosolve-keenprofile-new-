using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _ReportContent : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {


            Model_ReportSection pr = new Model_ReportSection();
            List<Model_ReportSection> seclist = pr.GetList();
            dropSection.DataSource = seclist;
            dropSection.DataTextField = "Title";
            dropSection.DataValueField = "ResultSectionID";
            dropSection.DataBind();

            dropsection2.DataSource = seclist;
            dropsection2.DataTextField = "Title";
            dropsection2.DataValueField = "ResultSectionID";
            dropsection2.DataBind();

            ListItem lis = new ListItem("All", "0");
            dropsection2.Items.Insert(0, lis);

            if (!string.IsNullOrEmpty(Request.QueryString["section"]))
            {
                add_section.Visible = true;
                int id = int.Parse(Request.QueryString["section"]);
               
                pr = pr.GetReportSectionByID(id);
                SectionTitle.Text = pr.Title;
                txtCode.Text = pr.Code;
                txtintro.Text = pr.FormularDetail;
                status.SelectedValue = pr.Status.ToString();
                txtpri.Text = pr.Priority.ToString();
                headsection_pan.InnerHtml = "Edit Section";


            }

            if (!string.IsNullOrEmpty(Request.QueryString["subsection"]))
            {
                sub_pan.Visible = true;
                int subid = int.Parse(Request.QueryString["subsection"]);
                Model_ReportSectionItem sub = new Model_ReportSectionItem();
                sub = sub.GetReportSectionItemByID(subid);
                dropSection.SelectedValue = sub.ResultItemID.ToString();
                txtSubTitle.Text = sub.Title;
                txtSubCode.Text = sub.Code;
                subpri.Text = sub.Priority.ToString();

                //string comret = string.Empty;
                //if (!string.IsNullOrEmpty(sub.Combind))
                //{
                //    string[] arrcom = sub.Combind.Split(',');
                //    comret = string.Join(",", arrcom.Select(i => "SU" + i).ToArray());
                //}

                //Combind.Text = comret;
                radioSubStatus.Text = sub.Status.ToString();


                headsection_pan1.InnerHtml = "Edit Sub Section";


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
                   


                    if (!string.IsNullOrEmpty(Request.QueryString["section"]))
                    {
                        dropsection2.SelectedValue = Request.QueryString["section"];
                    }



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
        string c = txtCode.Text.Trim();
        string i = txtintro.Text.Trim();
        bool st = bool.Parse(status.SelectedValue);
        int pr = int.Parse(txtpri.Text);


        Button btn = (Button)sender;

        Model_ReportSection cr = new Model_ReportSection
        {
            Title = SectionTitle.Text.Trim(),
            Code = txtCode.Text.Trim(),
            FormularDetail = txtintro.Text.Trim(),
            Priority = int.Parse(txtpri.Text),
            Status = bool.Parse(status.SelectedValue)
        };

        if (!string.IsNullOrEmpty(Request.QueryString["section"]))
        {
            byte bytID = byte.Parse(Request.QueryString["section"]);

            cr.ResultSectionID = bytID;
            if (cr.Update(cr))
            {
                Response.Redirect("Reportcontent");
            }
        }
        else
        {
            if (cr.Insert(cr) > 0)
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
        Response.Redirect("Reportcontent");
        //add_section.Visible = false;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        

        int secID = int.Parse(dropSection.SelectedValue);

        string strtitle = txtSubTitle.Text.Trim();
        bool Status = bool.Parse(radioSubStatus.SelectedValue);


        Model_ReportSectionItem sub = new Model_ReportSectionItem
        {
            ResultSectionID = secID,
            Title = strtitle,
            Status = Status,
            Priority = int.Parse(subpri.Text),
            Code = txtSubCode.Text

        };

        Button btn = (Button)sender;

        if (!string.IsNullOrEmpty(Request.QueryString["subsection"]))
        {
            int bytID = int.Parse(Request.QueryString["subsection"]);
            sub.ResultItemID = bytID;

            if (sub.Update(sub))
            {
                Response.Redirect("Reportcontent?tab=2&section=" + dropsection2.SelectedValue);
            }
        }
        else
        {
            if (sub.Insert(sub) > 0)
            {
                Response.Redirect(Request.Url.ToString());
            }
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("Reportcontent?tab=2&section=" + dropsection2.SelectedValue);
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



    

   
    
}