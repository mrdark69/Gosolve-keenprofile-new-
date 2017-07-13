using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff_Staff : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            dropRole.DataSource = UsersController.GetUserRole();
            dropRole.DataTextField = "Title";
            dropRole.DataValueField = "UsersRoleId";
            dropRole.DataBind();

            ListItem lis = new ListItem("All", "0");
            dropRole.Items.Insert(0, lis);
           
        }
    }
}