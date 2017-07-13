using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff_RoleEdit : BasePage
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
                byte id = byte.Parse(Request.QueryString["s"]);
                Model_usersRole mu = UsersController.GetRoleByID(id);

                if(mu != null)
                {
                    RoleTitle.Text = mu.Title;

                    status.SelectedValue = mu.Status.ToString();

                    //LastName.Text = mu.LastName;
                    //UserName.Text = mu.UserName;
                }

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


                List<Model_AppFeatureRole> RolApp = UsersController.GetAppFeature(id);

                if(RolApp.Count> 0)
                {
                    foreach(ListItem i in chklistStaff.Items)
                    {

                        i.Selected = (RolApp.Where(r => r.ActionID == int.Parse(i.Value) && r.ModuleID == 1).ToList().Count > 0);
                    }


                    foreach (ListItem i in CheckContentAction.Items)
                    {

                        i.Selected = (RolApp.Where(r => r.ActionID == int.Parse(i.Value) && r.ModuleID == 4).ToList().Count > 0);
                    }


                    foreach (ListItem i in checksettingAction.Items)
                    {

                        i.Selected = (RolApp.Where(r => r.ActionID == int.Parse(i.Value) && r.ModuleID == 3).ToList().Count > 0);
                    }

                }



                if(id == 10)
                {
                 
                   
                    List<CheckBoxList> allControls = new List<CheckBoxList>();
                    GetControlList<CheckBoxList>(Page.Controls, allControls);
                    foreach (var childControl in allControls)
                    {
                        CheckBoxList c = (CheckBoxList)childControl;
                        c.Enabled = false;
                    }

                    List<RadioButtonList> allControlsRadio = new List<RadioButtonList>();
                    GetControlList<RadioButtonList>(Page.Controls, allControlsRadio);
                    foreach (var childControl in allControlsRadio)
                    {
                        RadioButtonList c = (RadioButtonList)childControl;
                        c.Enabled = false;
                    }


                    List<Button> allControlsButton = new List<Button>();
                    GetControlList<Button>(Page.Controls, allControlsButton);
                    foreach (var childControl in allControlsButton)
                    {
                        Button c = (Button)childControl;
                        c.Enabled = false;
                    }

                    RoleTitle.Enabled = false;
                }



            }


        }
    }

    private void GetControlList<T>(ControlCollection controlCollection, List<T> resultCollection)
 where T : Control
    {
        foreach (Control control in controlCollection)
        {
            //if (control.GetType() == typeof(T))
            if (control is T) // This is cleaner
                resultCollection.Add((T)control);

            if (control.HasControls())
                GetControlList(control.Controls, resultCollection);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        Model_usersRole role = new Model_usersRole
        {
            UsersRoleId = byte.Parse(Request.QueryString["s"]),
            Title = RoleTitle.Text,
            Status = bool.Parse(status.SelectedValue)

        };

       if(UsersController.UpdateUserRole(role) && !string.IsNullOrEmpty(Request.QueryString["s"]))
            {
            byte intUsersRoleId = byte.Parse(Request.QueryString["s"]);

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

            Response.Redirect(Request.Url.ToString());

        }




    }



    protected void btnSaveAction_Click(object sender, EventArgs e)
    {
        


    }
}