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
public class Model_UsersTransaction: BaseModel<Model_UsersTransaction>
{

    public int TransactionID { get; set; }
    public int UserID { get; set; }
    public DateTime DateSubmit { get; set; }
    public int DownloadCount { get; set; }
    public bool Status { get; set; }
   


    public Model_UsersTransaction()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int InsertUserTsAss(Model_UsersTransaction usts)
    {
        int ret = 0;
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO UserAssTransaction (UserID,DateSubmit,DownloadCount,Status) 
            VALUES (@UserID,@DateSubmit,@DownloadCount,@Status);SET @TransactionID =SCOPE_IDENTITY()", cn);
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = usts.UserID;
            cmd.Parameters.Add("@DateSubmit", SqlDbType.SmallDateTime).Value = DatetimeHelper._UTCNow();
            cmd.Parameters.Add("@DownloadCount", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
            cmd.Parameters.Add("@TransactionID", SqlDbType.Int).Direction = ParameterDirection.Output;

            cn.Open();

            
            if (ExecuteNonQuery(cmd) > 0)
            {
                ret = (int)cmd.Parameters["@TransactionID"].Value;

            }


        }

        return ret;
    }


    public Model_UsersTransaction GetTsByID(int TransactionID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM UserAssTransaction WHERE TransactionID=@TransactionID", cn);
            cmd.Parameters.Add("@TransactionID", SqlDbType.Int).Value = TransactionID;
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }
    public List<Model_UsersTransaction> getTsListByUserID(int UserID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM UserAssTransaction WHERE UserID=@UserID", cn);
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public List<Model_UsersTransaction> getTsList()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM UserAssTransaction", cn);
           
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

}