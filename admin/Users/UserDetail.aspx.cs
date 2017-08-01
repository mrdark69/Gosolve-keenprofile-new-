using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_UserDetail : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            //dropRole.DataSource = UsersController.GetUserRole();
            //dropRole.DataTextField = "Title";
            //dropRole.DataValueField = "UsersRoleId";
            //dropRole.DataBind();

            //ListItem lis = new ListItem("All", "0");
            //dropRole.Items.Insert(0, lis);

            if (!string.IsNullOrEmpty(Request.QueryString["s"]))
            {

                int USerID = int.Parse(Request.QueryString["s"]);
                Model_Users u = new Model_Users();
                u = u.getUserbyID(USerID);

                //Get Job Function
                Model_CJF cjf = new Model_CJF();
                List<Model_CJF> cjflist = cjf.GetCJFeAll();

                Model_UserCJF cjflistUser = new Model_UserCJF();
                List<Model_UserCJF> cjfuserChecked = cjflistUser.GetListUsercjf(u.UserID);

                //Get Functional Competencies
                Model_FC fc = new Model_FC();
                List<Model_FC> fclist = fc.GetFCAll();

                Model_UserFC fcuser = new Model_UserFC();
                List<Model_UserFC> fcuserchecked = fcuser.GetListUserFc(u.UserID);


                //Get Country
                Model_Country c = new Model_Country();
                List<Model_Country> ccountry = c.GetAllCountry();


                dropNation.DataSource = ccountry;
                dropNation.DataTextField = "DropValue";
                dropNation.DataValueField = "ID";
                dropNation.DataBind();

                dropNation.SelectedValue = "211";


                StringBuilder strcjf = new StringBuilder();
                StringBuilder strfc = new StringBuilder();


                strcjf.Append("<div  class=\"checkitem\">");


                foreach (Model_CJF i in cjflist)
                {

                    string check = string.Empty;
                    if (cjfuserChecked.Where(r => r.CJFID == i.CJFID).Count() > 0)
                        check = "Checked=\"Checked\"";


                    strcjf.Append("<div class=\"item\">");


                    strcjf.Append("<input  type=\"checkbox\" name=\"chckCJF_form\" " + check + " class=\"role_cjf_valid\" value=\"" + i.CJFID + "\">");
                    strcjf.Append("<label>" + i.Title + "</label>");
                    strcjf.Append("</div>");
                }


                strcjf.Append("</div>");



                strfc.Append("<div class=\"checkitem\">");

                foreach (Model_FC i in fclist)
                {

                    string check = string.Empty;
                    if (fcuserchecked.Where(r => r.FCID == i.FCID).Count() > 0)
                        check = "Checked=\"Checked\"";

                    strfc.Append("<div class=\"item\">");
                    strfc.Append("<input  type=\"checkbox\" name=\"chckFC_form\" " + check + " class=\"role_fc_valid\" value=\"" + i.FCID + "\">");
                    strfc.Append("<label>" + i.Title + "</label>");
                    strfc.Append("</div>");


                }

                strfc.Append("</div>");

                chckCJF.Text = strcjf.ToString();
                checkFC.Text = strfc.ToString();


                //Maintitle.Text = "Your Profile";






                //Binding profile (initial data)
              
                firstName.Text = (string.IsNullOrEmpty(u.FirstName) ? "" : u.FirstName);
                LastName.Text = (string.IsNullOrEmpty(u.LastName) ? "" : u.LastName);
                dropGender.SelectedValue = u.Gender.ToString();
                dropNation.SelectedValue = u.Nationality.ToString();
                day.Text = (u.DateofBirth != null ? u.DateofBirth.ToString("yyy-MM-dd") : "");
                txtPhon.Text = (string.IsNullOrEmpty(u.MobileNumber) ? "" : u.MobileNumber);
                txtEmail.Text = u.Email;
            }

        }
    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        
    }
}