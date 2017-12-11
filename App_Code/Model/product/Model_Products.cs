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
public class Model_Products : BaseModel<Model_Products>
{
    public int ProductID { get; set; }
    public string Title { get; set; }
    public string Detail { get; set; }
    public decimal Price { get; set; }
    public bool Status { get; set; }
    public int TotalRows { get; set; }
    public int RowNum { get; set; }


    public DTParameters PagingParam { get; set; }
    public Model_Products()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Model_Products getProductByID(int ProductId)
    {

        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE ProductID = @ProductID", cn);
            cn.Open();
            cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductId;

            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }

    public IList<Model_Products> GetProduct(Model_Products mu)
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
           

            string strcmd = @"
                ;WITH Products_cte AS (
                SELECT u.*
                FROM dbo.Products u
                
                WHERE u.ProductID > 0 " + cfilter +

                @"
            )

            SELECT 
                db.*,
                tCountOrders.CountOrders AS TotalRows
            FROM Products_cte db
                CROSS JOIN (SELECT Count(*) AS CountOrders FROM Products_cte) AS tCountOrders
            ORDER BY  " + (!string.IsNullOrEmpty(sortOrder) ? sortOrder : " ProductID DESC ") + @"
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