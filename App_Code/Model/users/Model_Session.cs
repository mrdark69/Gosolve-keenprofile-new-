using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MVCDatatableApp;
using Microsoft.AspNet.Identity;
using gs_newsletter;
using System.Web.Providers.Entities;
using System.Security.Cryptography;

/// <summary>
/// Summary description for Model_User
/// </summary>
public class Model_Session : BaseModel<Model_Session>
{
    public int UserSessionID { get; set; }
    public int UserID { get; set; }
 
    public string LastAccessUrl { get; set; }
    public string IPAddress { get; set; }
    public DateTime TimeAccess { get; set; }
    public DateTime LastAccess { get; set; }
    public string Browser { get; set; }
    public byte Lang_Id { get; set; }
    public DateTime? LeaveTime { get; set; }


    public string FirstName { get; set; }
    public byte UsersRoleId { get; set; }
    public string UserRoleName { get; set; }

    public string CurrentURL
    {
        get
        {
            return HttpContext.Current.Request.Url.ToString();
        }
    }
    public Model_Session()
    {
        //
        // TODO: Add constructor logic here
        //
    }

   

     public int InsertUserToSesstionRecord(Model_Users ms)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO UserSession (UserID,LastAccessUrl,IPAddress,TimeAccess,LastAccess,Browser,Lang_Id)VALUES(@UserID,@LastAccessUrl,@IPAddress,@TimeAccess,@LastAccess,@Browser,@Lang_Id);SET @UserSessionID = scope_identity()", cn);
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = ms.UserID;
            cmd.Parameters.Add("@LastAccessUrl", SqlDbType.NVarChar).Value = this.CurrentURL;
       
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                cmd.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else
            {
                cmd.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = HttpContext.Current.Request.UserHostAddress;
            }
            cmd.Parameters.Add("@TimeAccess", SqlDbType.DateTime).Value = DatetimeHelper._UTCNow();
            cmd.Parameters.Add("@LastAccess", SqlDbType.DateTime).Value = DatetimeHelper._UTCNow();
            cmd.Parameters.Add("@Browser", SqlDbType.NVarChar).Value = HttpContext.Current.Request.Browser.Browser.ToString();
            cmd.Parameters.Add("@Lang_Id", SqlDbType.TinyInt).Value = 1;
            cmd.Parameters.Add("@UserSessionID", SqlDbType.Int).Direction = ParameterDirection.Output;

            cn.Open();

            int ret = ExecuteNonQuery(cmd);
            //HttpContext.Current.Response.Write((int)cmd.Parameters["@SessionId"].Value);
            //HttpContext.Current.Response.End();
            return (int)cmd.Parameters["@UserSessionID"].Value;
        }
    }


    public int CloseOtherCurrentLogin(int UserID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE UserSession SET LeaveTime=@LeaveTime WHERE UserSessionID IN ((SELECT UserSessionID FROM UserSession WHERE UserID = @UserID AND LeaveTime IS NULL))", cn);
            cmd.Parameters.Add("@LeaveTime", SqlDbType.SmallDateTime).Value = DatetimeHelper._UTCNow();
            cmd.Parameters.Add("@UserID", SqlDbType.SmallInt).Value = UserID;
            cn.Open();
            int ret = ExecuteNonQuery(cmd);
            return ret;
        }
    }


    //VERSION 2 ---update spectify Leave_time Record which to Logout 
    public bool UpdateSessionAuthorizeLogOut(Model_Session ss)
    {

        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE UserSession SET LastAccessUrl= @LastAccessUrl,LeaveTime=@LeaveTime WHERE UserSessionID=@UserSessionID", cn);
            cmd.Parameters.Add("@UserSessionID", SqlDbType.Int).Value = ss.UserSessionID;
            cmd.Parameters.Add("@LastAccessUrl", SqlDbType.NVarChar).Value = ss.CurrentURL;
            cmd.Parameters.Add("@LeaveTime", SqlDbType.DateTime).Value = DatetimeHelper._UTCNow();
            cn.Open();

            int ret = ExecuteNonQuery(cmd);
            return (ret == 1);

        }

    }


    public Model_Session IsHaveSessionRecord(int intSessionLogId)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT us.*,u.FirstName,u.UsersRoleId,ur.Title AS UserRoleName FROM UserSession us 
                        LEFT JOIN Users u ON u.UserID=us.UserID 
                        LEFT JOIN UsersRole ur ON ur.UsersRoleId = u.UsersRoleId
                    WHERE UserSessionID=@UserSessionID", cn);
            cmd.Parameters.Add("@UserSessionID", SqlDbType.Int).Value = intSessionLogId;
            cn.Open();

            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }


    public bool UpdateSessionAuthorize(Model_Session clStaffSession)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE UserSession SET LastAccessUrl = @LastAccessUrl WHERE UserSessionID=@UserSessionID", cn);
            cmd.Parameters.Add("@UserSessionID", SqlDbType.Int).Value = clStaffSession.UserSessionID;
            cmd.Parameters.Add("@LastAccessUrl", SqlDbType.NVarChar).Value = clStaffSession.CurrentURL;
            cn.Open();

            int ret = ExecuteNonQuery(cmd);
            return (ret == 1);

        }
    }

}