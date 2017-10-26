using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _JobFunctionContent3 : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {

            Model_Jobfunction j = new Model_Jobfunction();

            droupJob.DataSource = j.GetAll();
            droupJob.DataTextField = "Title";
            droupJob.DataValueField = "JFID";
            droupJob.DataBind();

            JobFunctionListdrop.DataSource = j.GetAll();
            JobFunctionListdrop.DataTextField = "Title";
            JobFunctionListdrop.DataValueField = "JFID";
            JobFunctionListdrop.DataBind();

            Model_JobFunctionListMain main = new Model_JobFunctionListMain();
            dropScoreMain.DataSource = main.GetAllActive();
            dropScoreMain.DataTextField = "Title";
            dropScoreMain.DataValueField = "JFMID";
            dropScoreMain.DataBind();
            

            if (!string.IsNullOrEmpty(Request.QueryString["g"]) && !string.IsNullOrEmpty(Request.QueryString["m"]))
            {
                add_section.Visible = true;
                int JFID = int.Parse(Request.QueryString["g"]);
                int JFMID = int.Parse(Request.QueryString["m"]);
                Model_JobFunctionListMap cgroup = new Model_JobFunctionListMap();
                cgroup = cgroup.GetByID(JFID, JFMID);


                Score.Text = cgroup.Score.ToString();

                JobFunctionListdrop.SelectedValue = JFID.ToString();

                dropScoreMain.SelectedValue = cgroup.JFMID.ToString();

                headsection_pan.InnerHtml = "Edit";


            }







        }


        
    }




    protected void Button1_Click(object sender, EventArgs e)
    {
       


        Button btn = (Button)sender;

        Model_JobFunctionListMap cgroup = new Model_JobFunctionListMap
        {

            JFID = int.Parse(JobFunctionListdrop.SelectedValue),
            JFMID = int.Parse(dropScoreMain.SelectedValue),
            Score = int.Parse(Score.Text),
           

        };

        if (!string.IsNullOrEmpty(Request.QueryString["g"]))
        {
           
            if (cgroup.Update(cgroup))
            {
                Response.Redirect("JobFunctionContent3");
            }
        }
        else
        {
           
           if(cgroup.Insert(cgroup) > 0)
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
        Response.Redirect("JobFunctionContent3");
        //add_section.Visible = false;
    }

    
}