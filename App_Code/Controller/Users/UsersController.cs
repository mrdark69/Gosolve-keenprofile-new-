using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDatatableApp;
using System.IO;
using System.Text;
using System.Configuration;
using System.Web.SessionState;
/// <summary>
/// Summary description for UsersController
/// </summary>
public class UsersController
{
    public UsersController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static bool UpdateIsPaidUser(Model_Users user)
    {
        return user.UpdateIsPaid(user);
    }
    public static int InsertUserAdmin(Model_Users user)
    {
       
       return user.InsertUserAdmin(user);
    }

    public static Model_Users AdminChecklogin(string user, string pass)
    {
        Model_Users u = new Model_Users();
        return u.CheckLoginAdmin(user, pass);
    }

    public static object GetUserRole_DatatbleView(DTParameters param)
    {
        Model_usersRole cSG = new Model_usersRole();

        return cSG.getUserRoleAll_DataTable(param);
    }


    public static Model_Users GetUserbyID(int intUserID)
    {
        Model_Users u = new Model_Users();
        return u.getUserbyID(intUserID);
    }

    public static Model_Users GetUserbyEmailFront(string email)
    {
        Model_Users u = new Model_Users();
        return u.getUserbyEmailFront(email);
    }

    public static IList<Model_Users> GetUsers(Model_Users mu)
    {
        return mu.getUserAll(mu);
    }

    public static IList<Model_Users> GetUsers_Paging(Model_Users mu)
    {
        return mu.getUserAll_Paging(mu);
    }

    public static IList<Model_usersRole> GetRoleAll(Model_usersRole mu)
    {
        return mu.getRole();
    }

    public static Model_usersRole GetRoleByID(byte bytUserRoleID)
    {
        Model_usersRole u = new Model_usersRole();
        return u.getRoleByID(bytUserRoleID);
    }

    public static List<Model_usersRole> GetUserRole()
    {
        Model_usersRole mr = new Model_usersRole();
       return  mr.getRole();
    }


    public static bool  UpdateUserAdmin(Model_Users user)
    {
        
        return user.UpdateUserAdmin(user);
    }
    public static bool UpdateUserRole(Model_usersRole role)
    {
        return role.UpdateUsersRole(role);
    }

    public static byte AddUserRole(Model_usersRole role)
    {
        return role.AddeUsersRole(role);
    }

    public static List<Model_AppAction> GetActionAll()
    {
        Model_AppAction ma = new Model_AppAction();
        return ma.getListAppFeatureAll();
    }



    public static int InsertUserRole(Model_AppFeatureRole ma,bool Selected)
    {
    
        ma.DeleteAppFeature(ma);

        return (Selected ? ma.AddAppFeatureRole(ma) : 0);
    }

    public static List<Model_AppFeatureRole> GetAppFeature(byte UserRoleID)
    {
        Model_AppFeatureRole ma = new Model_AppFeatureRole();
        return ma.GetAppFeatureList(UserRoleID);
    }

    public static List<Model_AppFeatureRole> GetAppFeatureAuthen(byte UserRoleID)
    {
        Model_AppFeatureRole ma = new Model_AppFeatureRole();
        return ma.GetAppFeatureListAuthen(UserRoleID);
    }

    // FrontEnd 
    public static Model_Users UserChecklogin(string user, string pass)
    {
        Model_Users u = new Model_Users();
        return u.CheckLoginUser(user, pass);
    }

    public static Model_Users UserCheckloginExternal(string user, UserLoginChannel loginchannel)
    {
        Model_Users u = new Model_Users();
        return u.CheckLoginUserExternal(user, loginchannel);
    }

    public static int InsertUser(Model_Users user)
    {
        int ret = user.InsertUser(user);

        if(ret > 0)
        {
            SendEmailVerify(ret);
        }
        return ret;
    }

    public static int InsertUserExternal(Model_Users user)
    {
        int ret = user.InsertUserExternal(user);

        
        return ret;
    }

    public static void SendEmailVerify(int UserID)
    {
        Model_Setting s = new Model_Setting();
        s = s.GetSetting();

      Model_Users  user = GetUserbyID(UserID);

        string body = string.Empty;
        string text = File.ReadAllText(HttpContext.Current.Server.MapPath("/Theme/emailtemplate/layout.html"), Encoding.UTF8);
        if (!string.IsNullOrEmpty(text))
        {
            string path = ConfigurationManager.AppSettings["AuthorizeBaseURL"].ToString().Replace("/admin","") + "Verify?ID=" + StringUtility.EncryptedData(user.UserID.ToString());
            body = text.Replace("<!--##@Linkverfiy##-->", path);
            body = text.Replace("<!--##@Linkverfiy_btn##-->", path);
        }
     
        MailSenderOption option = new MailSenderOption
        {
            MailSetting = s,
            context = HttpContext.Current,
            mailTo = user.Email,
            Mailbody = body,
            Subject = "Verify Email for Keen Profile Service"
        };
        MAilSender.SendMailEngine(option);
    }

    public static void SendEmailSuccess(int UserID)
    {
        Model_Setting s = new Model_Setting();
        s = s.GetSetting();

        Model_Users user = GetUserbyID(UserID);

        string body = string.Empty;
        string text = File.ReadAllText(HttpContext.Current.Server.MapPath("/Theme/emailtemplate/layout_sgSuccess.html"), Encoding.UTF8);
        if (!string.IsNullOrEmpty(text))
        {
            //string path = ConfigurationManager.AppSettings["AuthorizeBaseURL"].ToString().Replace("/admin", "") + "Verify?ID=" + StringUtility.EncryptedData(user.UserID.ToString());
            //body = text.Replace("<!--##@Linkverfiy##-->", path);
            //body = text.Replace("<!--##@Linkverfiy_btn##-->", path);

            body = text;
        }

        MailSenderOption option = new MailSenderOption
        {
            MailSetting = s,
            context = HttpContext.Current,
            mailTo = user.Email,
            Mailbody = body,
            Subject = "การสมัครของคุณเสร็จสิ้น/ You've successfully Register to Keen Profile System"
        };
        MAilSender.SendMailEngine(option);
    }

    public static Model_Users SendEmailForgot(string email)
    {
        Model_Setting s = new Model_Setting();
        s = s.GetSetting();
        Model_Users user = GetUserbyEmailFront(email);
      

        if(user != null)
        {
            string body = string.Empty;
            string text = File.ReadAllText(HttpContext.Current.Server.MapPath("/Theme/emailtemplate/layoutforgot.html"), Encoding.UTF8);
            if (!string.IsNullOrEmpty(text))
            {
                string param = user.UserID.ToString();
                string time = DateTime.Now.ApiService_DateToTimestamp();
                string paramstring = param + "@" + time;

                HttpSessionState Hotels2Session = HttpContext.Current.Session;

                Hotels2Session.Clear();

                Hotels2Session.Timeout = 10;
                Hotels2Session[time] = time;




                string path = ConfigurationManager.AppSettings["AuthorizeBaseURL"].ToString().Replace("/admin", "") + "ResetPassword?e=" + StringUtility.EncryptedData(paramstring);
                body = text.Replace("<!--##@Linkresetpassword##-->", path);
            }

            MailSenderOption option = new MailSenderOption
            {
                MailSetting = s,
                context = HttpContext.Current,
                mailTo = user.Email,
                Mailbody = body,
                Subject = "Forgot password and reset password"
            };
            MAilSender.SendMailEngine(option);

        }
       

        return user;
    }



    public static bool UpDateVerify(int intUserID)
    {
        Model_Users mu = new Model_Users
        {
            UserID = intUserID
        };

        if (mu.UpdateUserVerify(mu))
        {
            SendEmailSuccess(intUserID);
        }

        return true;




    }

    public static bool UpdatePassword (Model_Users mu)
    {
       return mu.UpdatePassword(mu);
    }








    ///FC
    ///

    public static Model_FC GetFCID(byte bytId)
    {
        Model_FC q = new Model_FC();
        return q.GetFCByID(bytId);
    }

    public static List<Model_FC> GetFCeAll(Model_FC ae)
    {
        return ae.GetFCAll();
    }

    public static bool EditFC(Model_FC q)
    {
        return q.UpdateFC(q);
    }

    public static int AddFc(Model_FC q)
    {
        return q.AddFC(q);
    }

    ///CJF
    ///

    public static Model_CJF GetCJF(int inttId)
    {
        Model_CJF q = new Model_CJF();
        return q.GetCJFByID(inttId);
    }

    public static List<Model_CJF> GetCJFAll(Model_CJF ae)
    {
        return ae.GetCJFeAll();
    }

    public static bool EditCJF(Model_CJF q)
    {
        return q.UpdateCJF(q);
    }

    public static int AddCJF(Model_CJF q)
    {
        return q.AddnewCJF(q);
    }


    //User TRSANSACTION
    public static IList<Model_UsersTransaction> getUserTransaction(Model_UsersTransaction ts)
    {
        return ts.getTsListl_Paging(ts);
    }

    public static IList<Model_UsersTransaction> getUserTransactionByUserID(Model_UsersTransaction ts)
    {
        return ts.getTsListByUserID(ts.UserID);
    }

}