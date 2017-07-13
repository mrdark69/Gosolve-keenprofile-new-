using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff_StaffEdit : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {

            
            dropRole.DataSource = UsersController.GetUserRole();
            dropRole.DataTextField = "Title";
            dropRole.DataValueField = "UsersRoleId";
            dropRole.DataBind();

            //ListItem lis = new ListItem("All", "0");
            //dropRole.Items.Insert(0, lis);

            if (!string.IsNullOrEmpty(Request.QueryString["s"]))
            {
                Model_Users mu = UsersController.GetUserbyID(int.Parse(Request.QueryString["s"]));

                if(mu != null)
                {
                    FirsName.Text = mu.FirstName;
                    LastName.Text = mu.LastName;
                    UserName.Text = mu.UserName;
                }
            }


        }
    }

   

    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool bolIsreset = (resetPassword.Visible ? true : false);
        Model_Users user = new Model_Users
        {
            IsResetPassword = bolIsreset,
            FirstName = FirsName.Text,
            UserName = UserName.Text,
            LastName = LastName.Text,
            Password = Password.Text,
            UsersRoleId = byte.Parse(dropRole.SelectedValue),
            UserID = int.Parse(Request.QueryString["s"])
            
        };
        if (UsersController.UpdateUserAdmin(user))
            Response.Redirect(Request.Url.ToString());

      
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        if (resetPassword.Visible)
        {
            resetPassword.Visible = false;
            btnReset.Text = "Reset Password";
          
        }
        else
        {
            resetPassword.Visible = true;
            btnReset.Text = "Close Reset Password";
        }
            

        

       
    }
}