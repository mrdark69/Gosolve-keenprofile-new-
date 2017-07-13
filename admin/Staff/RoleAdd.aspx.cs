using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff_RoleAdd : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {

            List<Model_AppAction> ma = UsersController.GetActionAll();
            chklistStaff.DataSource = ma.Where(a => a.ModuleID == 1);
            chklistStaff.DataTextField = "Title";
            chklistStaff.DataValueField = "ActionID";
            chklistStaff.DataBind();

            CheckContentAction.DataSource = ma.Where(a => a.ModuleID == 4);
            CheckContentAction.DataTextField = "Title";
            CheckContentAction.DataValueField = "ActionID";
            CheckContentAction.DataBind();

            checksettingAction.DataSource = ma.Where(a => a.ModuleID == 3);
            checksettingAction.DataTextField = "Title";
            checksettingAction.DataValueField = "ActionID";
            checksettingAction.DataBind();
            //dropRole.DataSource = UsersController.GetUserRole();
            //dropRole.DataTextField = "Title";
            //dropRole.DataValueField = "UsersRoleId";
            //dropRole.DataBind();

            //ListItem lis = new ListItem("All", "0");
            //dropRole.Items.Insert(0, lis);

            //if (!string.IsNullOrEmpty(Request.QueryString["s"]))
            //{
            //    Model_usersRole mu = UsersController.GetRoleByID(byte.Parse(Request.QueryString["s"]));

            //    if(mu != null)
            //    {
            //        RoleTitle.Text = mu.Title;
            //        //LastName.Text = mu.LastName;
            //        //UserName.Text = mu.UserName;
            //    }
            //}


        }
    }

   

    protected void btnSave_Click(object sender, EventArgs e)
    {

        Model_usersRole role = new Model_usersRole
        {
           
            Title = RoleTitle.Text,
            Status =  bool.Parse(status.SelectedValue)


        };

        byte RoleID =  UsersController.AddUserRole(role);

        if(RoleID > 0)
        {
            byte intUsersRoleId = RoleID;

            int staffmodule = int.Parse(chkStaffModule.Attributes["value"]);

            int intContentModule = int.Parse(ChkContentModule.Attributes["value"]);
            int intUserModule = int.Parse(chkUserModule.Attributes["value"]);
            int intSettingModule = int.Parse(ChkSttingModule.Attributes["value"]);


            //Response.Write(intUserModule);
            //Response.End();.Where(li => li.Selected)

            List<ListItem> selectedStaff = chklistStaff.Items.Cast<ListItem>().ToList();


            foreach (ListItem i in selectedStaff)
            {
                Model_AppFeatureRole ma = new Model_AppFeatureRole
                {
                    UsersRoleId = intUsersRoleId,
                    ModuleID = staffmodule,
                    ActionID = int.Parse(i.Value)

                };
                UsersController.InsertUserRole(ma, i.Selected);
            }

            List<ListItem> selectedUser = checkUserAction.Items.Cast<ListItem>().ToList();

            foreach (ListItem i in selectedUser)
            {
                Model_AppFeatureRole ma = new Model_AppFeatureRole
                {
                    UsersRoleId = intUsersRoleId,
                    ModuleID = intUserModule,
                    ActionID = int.Parse(i.Value)

                };
                UsersController.InsertUserRole(ma, i.Selected);
            }


            List<ListItem> selectedContent = CheckContentAction.Items.Cast<ListItem>().ToList();

            foreach (ListItem i in selectedContent)
            {
                Model_AppFeatureRole ma = new Model_AppFeatureRole
                {
                    UsersRoleId = intUsersRoleId,
                    ModuleID = intContentModule,
                    ActionID = int.Parse(i.Value)

                };
                UsersController.InsertUserRole(ma, i.Selected);
            }



            List<ListItem> selectedSetting = checksettingAction.Items.Cast<ListItem>().ToList();

            foreach (ListItem i in selectedSetting)
            {
                Model_AppFeatureRole ma = new Model_AppFeatureRole
                {
                    UsersRoleId = intUsersRoleId,
                    ModuleID = intSettingModule,
                    ActionID = int.Parse(i.Value)

                };
                UsersController.InsertUserRole(ma, i.Selected);
            }

            Response.Redirect("Role");
        }

        



    }

    protected void btnSaveAction_Click(object sender, EventArgs e)
    {
        

    }
}