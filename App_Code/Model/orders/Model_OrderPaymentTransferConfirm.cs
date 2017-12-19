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
public class Model_OrderPaymentTransferConfirm : BaseModel<Model_OrderPaymentTransferConfirm>
{
    public int TransferConfirmID { get; set; }
    public int PaymentID { get; set; }
    public int OrderID { get; set; }
    public string Extra { get; set; }
    public DateTime DatePayment { get; set; }
     public string BankIssue { get; set; }
    public byte GateWayID { get; set; }
    public bool Status { get; set; }
    public decimal Amount { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }


    public string FilePath { get; set; }

    public int TotalRows { get; set; }
    public int RowNum { get; set; }


    public DTParameters PagingParam { get; set; }
   
    

    public Model_OrderPaymentTransferConfirm()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public int InsertOrderPaymentTransferConfirm(Model_OrderPaymentTransferConfirm order)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO OrderPaymentTransferConfirm (PaymentID,OrderID,Extra,Amount,GateWayID,DatePayment,Status,Name,Email,Phone,FilePath) VALUES(@PaymentID,@OrderID,@Extra,@Amount,@GateWayID,@DatePayment,@Status,@Name,@Email,@Phone,@FilePath)", cn);
            cmd.Parameters.Add("@PaymentID", SqlDbType.Int).Value = order.PaymentID;
            cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = order.OrderID;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = order.Amount;

            cmd.Parameters.Add("@GateWayID", SqlDbType.Int).Value = order.GateWayID;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = order.Name;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = order.Email;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = order.Phone;
            cmd.Parameters.Add("@Extra", SqlDbType.NVarChar).Value = order.Extra;

            cmd.Parameters.Add("@FilePath", SqlDbType.NVarChar).Value = order.FilePath;

            cmd.Parameters.Add("@DatePayment", SqlDbType.SmallDateTime).Value = DatetimeHelper._UTCNow();
            
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;

            cn.Open();

            return ExecuteNonQuery(cmd);
        }
    }




}