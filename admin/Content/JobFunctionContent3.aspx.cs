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



            if (!string.IsNullOrEmpty(Request.QueryString["g"]))
            {
                add_section.Visible = true;
                int id = int.Parse(Request.QueryString["g"]);
                Model_JobFunctionListMain cgroup = new Model_JobFunctionListMain();
                cgroup = cgroup.GetByID(id);


                rname.Text = cgroup.Title;
              
                dropcat.SelectedValue = cgroup.Category.ToString();

                txtMap.Text = cgroup.Mapping;

                txtpri.Text = cgroup.Priority.ToString();
                headsection_pan.InnerHtml = "Edit";


            }







        }


        
    }




    protected void Button1_Click(object sender, EventArgs e)
    {
       
        string s = rname.Text.Trim();
        string title = rname.Text;

        byte bytcat = byte.Parse(dropcat.SelectedValue);
        bool st = bool.Parse(status.SelectedValue);
        int pr = int.Parse(txtpri.Text);
        string map = txtMap.Text;



        Button btn = (Button)sender;

        Model_JobFunctionListMain cgroup = new Model_JobFunctionListMain
        {
          
            Priority = pr,
            Status = st,
            Title = s,
            Category = bytcat,
            Mapping = map

        };

        if (!string.IsNullOrEmpty(Request.QueryString["g"]))
        {
            
            cgroup.JFMID= int.Parse(Request.QueryString["g"]);
            if (cgroup.updateGroup(cgroup))
            {
                Response.Redirect("JobFunctionContent1");
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
        Response.Redirect("JobFunctionContent1");
        //add_section.Visible = false;
    }

    
}