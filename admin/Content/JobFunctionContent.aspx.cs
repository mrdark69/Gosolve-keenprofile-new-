using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _JobFunctionContent : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {



            if (!string.IsNullOrEmpty(Request.QueryString["g"]))
            {
                add_section.Visible = true;
                int id = int.Parse(Request.QueryString["g"]);
                Model_JobFunctionGroup cgroup = new Model_JobFunctionGroup();
                cgroup = cgroup.GetByID(id);

               
                GroupName.Text = cgroup.Title;
                groupid.Text = cgroup.JGID.ToString();
              
              
                txtpri.Text = cgroup.Priority.ToString();
                headsection_pan.InnerHtml = "Edit Section";


            }







        }


        
    }




    protected void Button1_Click(object sender, EventArgs e)
    {
        int intgroupid = int.Parse(groupid.Text);
        string s = GroupName.Text.Trim();
     
       
        bool st = bool.Parse(status.SelectedValue);
        int pr = int.Parse(txtpri.Text);

      
        Button btn = (Button)sender;

        Model_JobFunctionGroup cgroup = new Model_JobFunctionGroup
        {
            JGID = intgroupid,
            Priority = pr,
            Status = st,
            Title = s
        };

        if (!string.IsNullOrEmpty(Request.QueryString["g"]))
        {
            int intJGID = int.Parse(Request.QueryString["g"]);
            if (cgroup.updateGroup(cgroup))
            {
                Response.Redirect("JobFunctionContent");
            }
        }
        else
        {
           
           if(cgroup.InsertGroup(cgroup) > 0)
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

    
}