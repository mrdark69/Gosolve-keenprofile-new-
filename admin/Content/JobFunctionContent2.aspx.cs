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

            data = new GsCsvReader(strPath, strFileName,1,25).ResultDataTable;

            if (data.Rows.Count > 0)
            {
                Model_Jobfunction cde = new Model_Jobfunction();
                cde.DeleteAll();
                int count = 0;
                
                Model_JobFunctionListMain cm = new Model_JobFunctionListMain();
                foreach (DataRow row in data.Rows)
                    {
                        if(count > 0)
                        {
                            Model_Jobfunction cSub = new Model_Jobfunction
                            {
                                JGID = int.Parse(row[0].ToString()),
                                Title = row[2].ToString()
                                //Email = (row.Table.Columns.Contains("Email") ? (row["Email"] == DBNull.Value ? "" : (string)row["Email"]) : ""),
                                //FirstName = (row.Table.Columns.Contains("FirstName") ? (row["FirstName"] == DBNull.Value ? "" : (string)row["FirstName"]) : ""),
                                //LastName = (row.Table.Columns.Contains("LastName") ? (row["LastName"] == DBNull.Value ? "" : (string)row["LastName"]) : ""),
                                //Sbin = true,
                                //SGID = int.Parse(p.Group)


                            };
                            int intJobfcuntionID = cSub.insert(cSub);

                      
                        List<Model_JobFunctionListMain> cm1 = cm.GetAllActive();

                        int count1 = 3;
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

                        int count2 = 21;
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