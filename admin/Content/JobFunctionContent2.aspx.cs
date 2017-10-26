using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _JobFunctionContent2 : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {

            Model_JobFunctionGroup cGroup = new Model_JobFunctionGroup();
            dropGroup.DataSource = cGroup.GetAll();
            dropGroup.DataTextField = "Title";
            dropGroup.DataValueField = "JGID";
            dropGroup.DataBind();

            if (!string.IsNullOrEmpty(Request.QueryString["g"]))
            {
                add_section.Visible = true;
                int id = int.Parse(Request.QueryString["g"]);
                Model_Jobfunction cf = new Model_Jobfunction();
                cf = cf.GetByID(id);

                JobID.Text = cf.JFID.ToString();
                rname.Text = cf.Title;
                status.SelectedValue = cf.Status.ToString();
                dropGroup.SelectedValue = cf.JGID.ToString();
                txtintro.Text = cf.DesInto;
                txtdes1.Text = cf.Des1;
                txtdes2.Text = cf.Des2;
                txtdes3.Text = cf.Des3;
                txtdes4.Text = cf.Des4;
                txtdes5.Text = cf.Des5;

                headsection_pan.InnerHtml = "Edit";


            }







        }


        
    }




    protected void Button1_Click(object sender, EventArgs e)
    {
       
        string s = rname.Text.Trim();
        string title = rname.Text;

        int intGroup = int.Parse(dropGroup.SelectedValue);
        bool st = bool.Parse(status.SelectedValue);
     

        string strDes1 = txtdes1.Text;
        string strDes2 = txtdes2.Text;
        string strDes3 = txtdes3.Text;
        string strDes4 = txtdes4.Text;
        string strDes5 = txtdes5.Text;
        string Destxtintro = txtintro.Text;
        int intJobID = int.Parse(JobID.Text);



        Button btn = (Button)sender;

        Model_Jobfunction cgroup = new Model_Jobfunction
        {

            DesInto = Destxtintro,
            Des1 = strDes1,
            Des2 = strDes2,
            Des3 = strDes3,
            Des4 = strDes4,
            Des5 = strDes5,
            Status = st,
            Title = s,
            JGID = intGroup,
            JFID = intJobID


        };

        if (!string.IsNullOrEmpty(Request.QueryString["g"]))
        {
            
            cgroup.JFID= int.Parse(Request.QueryString["g"]);
            if (cgroup.UpdateById(cgroup))
            {
                Response.Redirect("JobFunctionContent2");
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
        Response.Redirect("JobFunctionContent1");
        //add_section.Visible = false;
    }



    protected void btnImport_Click(object sender, EventArgs e)
    {
    
        string strFileName = string.Empty;
        string strPath = string.Empty;
       

        Base64BinarySrtingToFile save = new Base64BinarySrtingToFile
        {
            FilePrefix = "1"
        };
        save.SaveFileNew(HttpContext.Current.Request.Files["ctl00$MainContent$fileImport"]);


      

        if (save.IsSaved)
        {
           
            strFileName = save.FileName;
            strPath = save.Path;

            DataTable data = null;

            data = new GsCsvReader(strPath, strFileName,1,26).ResultDataTable;

            if (data.Rows.Count > 0)
            {
                Model_Jobfunction cde = new Model_Jobfunction();
                //cde.DeleteAll();
                int count = 0;
                
                Model_JobFunctionListMain cm = new Model_JobFunctionListMain();
                foreach (DataRow row in data.Rows)
                    {
                        if(count > 0)
                        {
                            Model_Jobfunction cSub = new Model_Jobfunction
                            {
                                JFID = int.Parse(row[2].ToString()),
                                JGID = int.Parse(row[0].ToString()),
                                Title = row[3].ToString()
                                //Email = (row.Table.Columns.Contains("Email") ? (row["Email"] == DBNull.Value ? "" : (string)row["Email"]) : ""),
                                //FirstName = (row.Table.Columns.Contains("FirstName") ? (row["FirstName"] == DBNull.Value ? "" : (string)row["FirstName"]) : ""),
                                //LastName = (row.Table.Columns.Contains("LastName") ? (row["LastName"] == DBNull.Value ? "" : (string)row["LastName"]) : ""),
                                //Sbin = true,
                                //SGID = int.Parse(p.Group)


                            };
                                cSub.insert(cSub);
                            int intJobfcuntionID = int.Parse(row[2].ToString());

                      
                        List<Model_JobFunctionListMain> cm1 = cm.GetAllActive();

                        int count1 = 4;
                        foreach (Model_JobFunctionListMain i1 in cm1.Where(o => o.Category == 1).OrderBy(o => o.Priority))
                        {
                            Model_JobFunctionListMap cj = new Model_JobFunctionListMap
                            {
                                JFID = intJobfcuntionID,
                                JFMID = i1.JFMID,
                                Score = int.Parse(row[count1].ToString()),
                            };
                            cj.insert(cj);
                            count1 = count1 + 1;
                        }

                        int count2 = 22;
                        foreach (Model_JobFunctionListMain i2 in cm1.Where(o => o.Category == 2).OrderBy(o=>o.Priority))
                        {
                            Model_JobFunctionListMap cj = new Model_JobFunctionListMap
                            {
                                JFID = intJobfcuntionID,
                                JFMID = i2.JFMID,
                                Score = int.Parse(row[count2].ToString()),
                            };
                            cj.insert(cj);
                            count2 = count2 + 1;
                        }

                    }
                      

                    count = count + 1;
                    }
               
                
            }
             

        }



        Response.Redirect(Request.Url.ToString());


    }
}