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
public class Model_OrderProducts : BaseModel<Model_OrderProducts>
{
    public int OrderProductID { get; set; }
    public int OrderID { get; set; }
    public int ProductID { get; set; }
    public string Title { get; set; }
    public string Detail { get; set; }
    public decimal Price { get; set; }
    public bool Status { get; set; }
    


    public int TotalRows { get; set; }
    public int RowNum { get; set; }


    public DTParameters PagingParam { get; set; }
   
    

    public Model_OrderProducts()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int InsertOrderProduct(Model_OrderProducts order)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO OrderProducts (OrderID,ProductID,Title,Detail,Price,Status) VALUES(@OrderID,@ProductID,@Title,@Detail,@Price,@Status)", cn);
            cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = order.OrderID;
            cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = order.ProductID;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = order.Title;
            cmd.Parameters.Add("@Detail", SqlDbType.NVarChar).Value = order.Detail;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = order.Price;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
          

            cn.Open();

            return ExecuteNonQuery(cmd);
        }
    }




}