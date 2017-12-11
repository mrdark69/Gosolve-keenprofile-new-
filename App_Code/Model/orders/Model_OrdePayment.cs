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

public enum GateWayBank : byte
{
     Kbank=1,
     SCB =2,
     BBL = 3,
     KTB= 4,
     KTC =5
}

public enum PaymentType : byte
{
    Transfer = 1,
    PaymentGateWay = 2,
   
}
/// <summary>
/// Summary description for Model_User
/// </summary>
public class Model_OrderPayment : BaseModel<Model_OrderPayment>
{
    public int PaymenyID { get; set; }
    public int OrderID { get; set; }
    public decimal Amount { get; set; }
    public byte GateWayID { get; set; }
    public byte PaymentTypeID { get; set; }
    public DateTime DatePayment { get; set; }
    public DateTime ComfirmPayment { get; set; }
    public decimal SettleAmount { get; set; }
    public DateTime ComfirmSettle { get; set; }

    public bool Status { get; set; }



    public int TotalRows { get; set; }
    public int RowNum { get; set; }


    public DTParameters PagingParam { get; set; }
   
    

    public Model_OrderPayment()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public int InsertOrderPayment(Model_OrderPayment order)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO OrderPayment (OrderID,Amount,GateWayID,PaymentTypeID,DatePayment,Status) VALUES(@OrderID,@Amount,@GateWayID,@PaymentTypeID,@DatePayment,@Status)", cn);
            cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = order.OrderID;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = order.Amount;

            cmd.Parameters.Add("@GateWayID", SqlDbType.Int).Value = order.GateWayID;
            cmd.Parameters.Add("@PaymentTypeID", SqlDbType.NVarChar).Value = order.PaymentTypeID;
            cmd.Parameters.Add("@DatePayment", SqlDbType.NVarChar).Value = DatetimeHelper._UTCNow();

            //cmd.Parameters.Add("@ComfirmPayment", SqlDbType.Bit).Value = order.ComfirmPayment; 
            //cmd.Parameters.Add("@SettleAmount", SqlDbType.Bit).Value = order.SettleAmount; ;
            //cmd.Parameters.Add("@ComfirmSettle", SqlDbType.Bit).Value = order.ComfirmSettle; 
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;

            cn.Open();

            return ExecuteNonQuery(cmd);
        }
    }




}