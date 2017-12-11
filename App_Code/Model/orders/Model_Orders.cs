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

//public enum UserLoginChannel : byte
//{
//     Application=1,
//     Facebook =2,
//     Google = 3
//}
/// <summary>
/// Summary description for Model_User
/// </summary>
public class Model_Orders : BaseModel<Model_Orders>
{

    public int OrderID { get; set; }
    public int UserID { get; set; }
    public byte StatusID { get; set; }
    public bool Status { get; set; }
    public DateTime DateSubmit { get; set; }


    public int TotalRows { get; set; }
    public int RowNum { get; set; }


    public DTParameters PagingParam { get; set; }
   
    

    public Model_Orders()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public int CountIsPaidByProduct(int ProductID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT COUNT(o.OrderID)
                                    FROM Orders o 
                                    INNER JOIN OrderProducts op ON op.OrderID = o.OrderID
                                    CROSS APPLY 
                                    (SELECT SUM(opy.Amount) As totalpaid FROM OrderPayment opy 
                                    WHERE opy.OrderID = o.OrderID
                                    AND opy.ComfirmPayment IS NOT NULL AND opy.Status = 1
                                    ) AS Payment
                                    WHERE op.ProductID = @ProductID AND Payment.totalpaid >= op.Price", cn);

            cn.Open();
            cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
            return (int)ExecuteScalar(cmd);
        }
    }


    public int InsertOrder(Model_Orders order)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO Orders (UserID,StatusID,Status,DateSubmit) VALUES(@UserID,@StatusID,@Status,@DateSubmit);SET @OrderID = SCOPE_IDENTITY();", cn);
            cmd.Parameters.Add("@DateSubmit", SqlDbType.SmallDateTime).Value = DatetimeHelper._UTCNow();
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = order.UserID;
            cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = order.StatusID;

            cmd.Parameters.Add("@OrderID", SqlDbType.Int).Direction = ParameterDirection.Output;

            cn.Open();

            if (ExecuteNonQuery(cmd) > 0)
                return (int)cmd.Parameters["@OrderID"].Value;
            else
                return 0;
        }
    }


    //public IList<Model_Orders> getUserAll_Paging(Model_Orders mu)
    //{

    //    string search =  (mu.PagingParam.Search != null? mu.PagingParam.Search.Value:"");
    //    string sortOrder = mu.PagingParam.SortOrder;
    //    int start = mu.PagingParam.Start;
    //    int length = mu.PagingParam.Length;
    //    //List<string> columnFilters = DataTablesJS<Model_Users>.getcolumnSearch(mu.PagingParam);

    //    List<DTCustomSerach> custom = mu.PagingParam.CustomSearchList;

    //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
    //    {


    //        string[] filerName = { "", "", "FirstName", "LastName", "Email" };
    //        StringBuilder strfilter = new StringBuilder();



    //        //for (int i = 0; i < columnFilters.Count; i++)
    //        //{
    //        //    if (!string.IsNullOrEmpty(columnFilters[i]))
    //        //    {
    //        //        strfilter.Append(" AND LOWER(" + filerName[i] + ") LIKE @filer_" + i);

    //        //    }

    //        //}
    //        SqlCommand cmd = new SqlCommand();

    //        string cfilter = string.Empty;
    //        if (custom.Count > 0)
    //        {
    //            foreach(DTCustomSerach f in custom)
    //            {
    //                if(f.Key == "Search")
    //                {
    //                    cfilter += (!string.IsNullOrEmpty(f.Value) ? " AND (FirstName LIKE '%'+@CustomKeyValue+'%' OR LastName LIKE '%'+@CustomKeyValue+'%' OR Email LIKE '%'+@CustomKeyValue+'%' OR MobileNumber LIKE '%'+@CustomKeyValue+'%')" : "");
    //                    cmd.Parameters.Add("@CustomKeyValue", SqlDbType.NVarChar).Value = f.Value;
    //                }

    //                if (f.Key == "caseissue")
    //                {
    //                    if (!string.IsNullOrEmpty(f.Value))
    //                    {
    //                        switch (f.Value)
    //                        {
    //                            //Paid account
    //                            case "1":
    //                                cfilter += " AND u.Ispaid = 1 ";
    //                                break;
    //                            //Free account
    //                            case "2":
    //                                cfilter += " AND u.Ispaid = 0 ";
    //                                break;
    //                            //Waiting for verify email
    //                            case "3":
    //                                cfilter += " AND u.EmailVerify = 0 ";
    //                                break;
    //                            //Email verified EmailVerify
    //                            case "4":
    //                                cfilter += " AND u.EmailVerify = 1 ";
    //                                break;
    //                            //Assessment expired
    //                            case "5":
    //                                break;
    //                            //Incomplete Profile
    //                            case "6":
    //                                cfilter += " AND (u.FirstName IS NULL OR u.LastName IS NULL OR u.DateofBirth IS NULL OR u.Gender IS NULL OR u.Nationality IS NULL OR u.MobileNumber IS NULL)";
    //                                break;
    //                        }
    //                    }
                          
    //                }
    //            }
    //        }
    //        string w = string.Empty;
    //        if (mu.UsersRoleId > 0)
    //        {
    //            w = "AND u.UsersRoleId =@UsersRoleId";
    //            cmd.Parameters.Add("@UsersRoleId", SqlDbType.TinyInt).Value = mu.UsersRoleId;

    //        }
    //        string strcmd = @"
    //            ;WITH Users_cte AS (
    //            SELECT u.*,ur.Title AS UserRoleName
    //            FROM dbo.Users u
    //            LEFT JOIN UsersRole ur ON ur.UsersRoleId =u.UsersRoleId  
    //            WHERE u.UserCatId = @UserCatId " + w +
    //            //(string.IsNullOrEmpty(search) ? "" : "AND  (FirstName LIKE @search  OR LastName LIKE @search OR Email LIKE @search) ") +
    //            cfilter +
    //            //(columnFilters.Count > 0 ? strfilter.ToString() : "")
    //            //OR LastName LIKE '%@CustomKeyValue%' OR Email LIKE '%@CustomKeyValue%'
    //            @"
    //        )

    //        SELECT 
    //            db.*,
    //            tCountOrders.CountOrders AS TotalRows
    //        FROM Users_cte db
    //            CROSS JOIN (SELECT Count(*) AS CountOrders FROM Users_cte) AS tCountOrders
    //        ORDER BY  " + (!string.IsNullOrEmpty(sortOrder) ? sortOrder : " UserID ASC ") + @" 
    //        OFFSET @Start ROWS
    //        FETCH NEXT @Size ROWS ONLY;
    //        ";

    //        // ORDER BY UserID, " + sortOrder + @"
    //        cmd.Parameters.Add("@UserCatId", SqlDbType.TinyInt).Value = mu.UserCatId;
    //        cmd.Parameters.Add("@Start", SqlDbType.Int).Value = start;
    //        cmd.Parameters.Add("@Size", SqlDbType.Int).Value = length;


    //        //if (custom.Key != null && !string.IsNullOrEmpty(custom.Value))
    //        //    cmd.Parameters.Add("@CustomKeyValue", SqlDbType.NVarChar).Value = custom.Value;

    //        if (!string.IsNullOrEmpty(search))
    //        {
    //            string searchTerm = string.Format("%{0}%", search);
    //            cmd.Parameters.Add(new SqlParameter("@search", searchTerm));
    //            //cmd.Parameters.Add("@search", SqlDbType.NVarChar).Value = searchTerm;
    //        }

    //        //if (columnFilters.Count > 0)
    //        //{
    //        //    if (!string.IsNullOrEmpty(columnFilters[2]))
    //        //    {
    //        //        string searchTerm = string.Format("%{0}%", columnFilters[2]);
    //        //        cmd.Parameters.Add(new SqlParameter("@filer_2", searchTerm));
    //        //    }
    //        //    if (!string.IsNullOrEmpty(columnFilters[3]))
    //        //    {
    //        //        string searchTerm = string.Format("%{0}%", columnFilters[3]);
    //        //        cmd.Parameters.Add(new SqlParameter("@filer_3", searchTerm));
    //        //    }


    //        //}


    //        cmd.CommandText = strcmd;
    //        cmd.Connection = cn;
    //        cn.Open();



    //        return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));

    //    }

    //}


}