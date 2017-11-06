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

    public string FirstName { get; set; }
    public string LastName { get; set; }
  
    public string Email { get; set; }
    public int TotalRows { get; set; }
    public int RowNum { get; set; }


    public DTParameters PagingParam { get; set; }
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
            SqlCommand cmd = new SqlCommand("SELECT * FROM UserAssTransaction WHERE UserID=@UserID ORDER BY DateSubmit DESC", cn);
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


    public Model_UsersTransaction GetTsLatestByUser(int UserID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM UserAssTransaction WHERE UserID=@UserID ORDER BY DateSubmit DESC", cn);
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
            
        }
    }


    public IList<Model_UsersTransaction> getTsListl_Paging(Model_UsersTransaction mu)
    {

        string search = (mu.PagingParam.Search != null ? mu.PagingParam.Search.Value : "");
        string sortOrder = mu.PagingParam.SortOrder;
        int start = mu.PagingParam.Start;
        int length = mu.PagingParam.Length;
        //List<string> columnFilters = DataTablesJS<Model_Users>.getcolumnSearch(mu.PagingParam);

        List<DTCustomSerach> custom = mu.PagingParam.CustomSearchList;

        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            
         
            SqlCommand cmd = new SqlCommand();

            string cfilter = string.Empty;
            if (custom.Count > 0)
            {
                foreach (DTCustomSerach f in custom)
                {
                    if (f.Key == "Search")
                    {
                        cfilter += (!string.IsNullOrEmpty(f.Value) ? " AND (FirstName LIKE '%'+@CustomKeyValue+'%' OR LastName LIKE '%'+@CustomKeyValue+'%' OR Email LIKE '%'+@CustomKeyValue+'%' OR MobileNumber LIKE '%'+@CustomKeyValue+'%')" : "");
                        cmd.Parameters.Add("@CustomKeyValue", SqlDbType.NVarChar).Value = f.Value;
                    }

                    if (f.Key == "caseissue")
                    {
                        if (!string.IsNullOrEmpty(f.Value))
                        {
                            switch (f.Value)
                            {
                                //Paid account
                                case "1":
                                    cfilter += " AND u.Ispaid = 1 ";
                                    break;
                                //Free account
                                case "2":
                                    cfilter += " AND u.Ispaid = 0 ";
                                    break;
                                //Waiting for verify email
                                case "3":
                                    cfilter += " AND u.EmailVerify = 0 ";
                                    break;
                                //Email verified EmailVerify
                                case "4":
                                    cfilter += " AND u.EmailVerify = 1 ";
                                    break;
                                //Assessment expired
                                case "5":
                                    break;
                                //Incomplete Profile
                                case "6":
                                    cfilter += " AND (u.FirstName IS NULL OR u.LastName IS NULL OR u.DateofBirth IS NULL OR u.Gender IS NULL OR u.Nationality IS NULL OR u.MobileNumber IS NULL)";
                                    break;
                            }
                        }

                    }
                }
            }
           
            string strcmd = @"
                ;WITH UserAssTransaction_cte AS (
                SELECT u.*,ur.FirstName,ur.LastName,ur.Email
                FROM dbo.UserAssTransaction u
                LEFT JOIN Users ur ON ur.UserID =u.UserID  
                WHERE u.TransactionID > 0 " + cfilter +

                @"
            )

            SELECT 
                db.*,
                tCountOrders.CountOrders AS TotalRows
            FROM UserAssTransaction_cte db
                CROSS JOIN (SELECT Count(*) AS CountOrders FROM UserAssTransaction_cte) AS tCountOrders
            ORDER BY  " +(!string.IsNullOrEmpty(sortOrder)? sortOrder: " DateSubmit DESC ") + @"
             OFFSET @Start ROWS
            FETCH NEXT @Size ROWS ONLY;
            ";

            // ORDER BY UserID, " + sortOrder + @"
           
            cmd.Parameters.Add("@Start", SqlDbType.Int).Value = start;
            cmd.Parameters.Add("@Size", SqlDbType.Int).Value = length;

            if (!string.IsNullOrEmpty(search))
            {
                string searchTerm = string.Format("%{0}%", search);
                cmd.Parameters.Add(new SqlParameter("@search", searchTerm));
                //cmd.Parameters.Add("@search", SqlDbType.NVarChar).Value = searchTerm;
            }

           

            cmd.CommandText = strcmd;
            cmd.Connection = cn;
            cn.Open();



            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));

        }

    }

}