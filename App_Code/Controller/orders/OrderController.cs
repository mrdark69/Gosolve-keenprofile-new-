using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDatatableApp;
using System.IO;
using System.Text;
using System.Configuration;
using System.Web.SessionState;
using Interface_API.Threadings;
/// <summary>
/// Summary description for UsersController
/// </summary>
public class OrderController
{
    public OrderController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static API_ThreadPool cpool = new API_ThreadPool();

    public static IList<Model_Products> GetProductAll(Model_Products ts)
    {
        return ts.GetProduct(ts);
    }


    public static int MakeOrder(int intProductId, Model_Users u)
    {
        int ret = 0;
        try
        {
            Model_Orders o = new Model_Orders
            {
                Status = true,
                StatusID = 1,
                UserID = u.UserID
            };

            int orderID = o.InsertOrder(o);

            if (orderID > 0)
            {
                Model_Products Cproduct = new Model_Products();
                Cproduct = Cproduct.getProductByID(intProductId);

                Model_OrderProducts p = new Model_OrderProducts
                {
                    OrderID = orderID,
                    ProductID = intProductId,
                    Title = Cproduct.Title,
                    Detail = Cproduct.Detail,
                    Price = Cproduct.Price

                };
                p.InsertOrderProduct(p);

                Model_OrderPayment cp = new Model_OrderPayment
                {
                    OrderID = orderID,
                    Amount = Cproduct.Price,
                    GateWayID = (byte)GateWayBank.Kbank,
                    PaymentTypeID = (byte)PaymentType.Transfer

                };
                cp.InsertOrderPayment(cp);
            }


          
            ret = orderID;
        }
        catch
        {

        }


        return ret;
    }

    public static int ConfirmTransferPayment(int OrderID, Model_Users u, Model_OrderPaymentTransferConfirm con)
    {
        int ret = 0;
        try {

            Model_OrderPayment payment = new Model_OrderPayment();
            List<Model_OrderPayment> listpayment = payment.getPaymentByOrderID(con.OrderID);
            if(listpayment.Count > 0)
            {

                var total = listpayment.Sum(o => o.Amount);

                var PaymentID = listpayment.FirstOrDefault().PaymentID;


                if(con.Amount >= total)
                {
                    
                    con.PaymentID = PaymentID;

                    if(con.InsertOrderPaymentTransferConfirm(con) > 0)
                    {
                        payment.UpdatePayment(PaymentID);
                        Model_Setting s = new Model_Setting();
                        s = s.GetSetting();


                        HttpContext context = HttpContext.Current;

                        object[] parameters = new object[] { u, s, context };
                        SendingEngineController.cpool.QueueWork(parameters, SendEmaiReceiveToCustomer);

                        string staffEmail = "mrdark6996@gmail.com;serviceteam@keenprofile.com";
                        object[] parameters2 = new object[] { staffEmail, s, context , con };

                        SendingEngineController.cpool.QueueWork(parameters2, SendEmailReceiveToStaff);
                    }
                   
                }

              

            }

          

            ret = 1;
        } catch
        {

        }
        
        return ret;
    }

    public static void SendEmaiReceiveToCustomer(object param)
    {
       

        object[] parameters = (object[])param;

    
        Model_Users user = (Model_Users)parameters[0];
        Model_Setting s = (Model_Setting)parameters[1];
        HttpContext context = (HttpContext)parameters[2];
      
        string body = string.Empty;
        string text = File.ReadAllText(context.Server.MapPath("/Theme/emailtemplate/layout.html"), Encoding.UTF8);
        //if (!string.IsNullOrEmpty(text))
        //{
        //    string path = ConfigurationManager.AppSettings["AuthorizeBaseURL"].ToString().Replace("/admin", "") + "Verify?ID=" + StringUtility.EncryptedData(user.UserID.ToString());
        //    body = text.Replace("<!--##@Linkverfiy##-->", "<a href=\"" + path + "\" />here</a>");
        //}
        body = "test acknowledge email sending";
        MailSenderOption option = new MailSenderOption
        {
            MailSetting = s,
            context = HttpContext.Current,
            mailTo = user.Email,
            Mailbody = body,
            Subject = "Keenprofile thank you : THE RIGHT JOB-FUNCTIONS REPORT Your order is completed"
        };
        MAilSender.SendMailEngine(option);
    }

    public static void SendEmailReceiveToStaff(object param)
    {
       


        object[] parameters = (object[])param;
        string staffmail = (string)parameters[0];
        Model_Setting s = (Model_Setting)parameters[1];
        HttpContext context = (HttpContext)parameters[2];
        Model_OrderPaymentTransferConfirm con = (Model_OrderPaymentTransferConfirm)parameters[3];
        string body = string.Empty;
        string text = File.ReadAllText(context.Server.MapPath("/Theme/emailtemplate/layout.html"), Encoding.UTF8);
        //if (!string.IsNullOrEmpty(text))
        //{
        //    string path = ConfigurationManager.AppSettings["AuthorizeBaseURL"].ToString().Replace("/admin", "") + "Verify?ID=" + StringUtility.EncryptedData(user.UserID.ToString());
        //    body = text.Replace("<!--##@Linkverfiy##-->", "<a href=\"" + path + "\" />here</a>");
        //}


        body = "FirstName : " + con.Name + "\r\n";
        body = body +  "email : " + con.Email + "\r\n";
        body = body + "datetime : " + con.DatePayment.ToThaiDateTime() + "\r\n";
        foreach (string email in staffmail.Split(';'))
        {
            MailSenderOption option = new MailSenderOption
            {
                MailSetting = s,
                context = HttpContext.Current,
                mailTo = email,
                Mailbody = body,
                Subject = "THE RIGHT JOB-FUNCTIONS REPORT : Transaction Received [Confirmed Order#" + con.OrderID + "]"
            };
            MAilSender.SendMailEngine(option);
        }


        
    }

}