using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using gs_newsletter;

public partial class Account_Register : Page
{
    protected  void CreateUser_ClickAsync(object sender, EventArgs e)
    {

        Model_Users u = new Model_Users
        {
            FirstName = FirsName.Text,
            LastName = LastName.Text,
            UserCatId = 2,
            UsersRoleId = byte.Parse(dropRole.SelectedValue),
            Password = Password.Text,
            UserName = UserName.Text
        };

        int ret = UsersController.InsertUserAdmin(u);
        if (ret < 0)
            lblsms.Text = "username and password is used already ";
        //var manager = new UserManager();
        //var user = new ApplicationUser()
        //{
        //    FirstName = FirsName.Text,
        //    LastName = LastName.Text,
        //    Email = Email.Text,
        //    UserName = UserName.Text,
        //    UserCatId = 2,
        //    UsersRoleId = byte.Parse(dropRole.SelectedValue)

            //};
            //// Configure validation logic for usernames
            //manager.UserValidator =
            //    new UserValidator<ApplicationUser>(manager)
            //    {
            //        AllowOnlyAlphanumericUserNames = false,
            //        RequireUniqueEmail = true
            //    };

            //// Configure validation logic for passwords
            ////manager.PasswordValidator = new MinimumLengthValidator(4);
            //manager.PasswordValidator = new PasswordValidator
            //{
            //    RequiredLength = 3,
            //    //RequireNonLetterOrDigit = true,
            //    RequireDigit = true,
            //    RequireLowercase = true,
            //    RequireUppercase = true,
            //};
            //IdentityResult result = await manager.CreateAsync(user, Password.Text);
            //if (result.Succeeded)
            //{
            //    IdentityHelper.SignIn(manager, user, isPersistent: false);
            //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //}
            //else
            //{
            //    ErrorMessage.Text = result.Errors.FirstOrDefault();
            //}
    }
}