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

            ret = 1;



          
            object[] parameters = new object[] { u };
            SendingEngineController.cpool.QueueWork(parameters, SendEmaiReceiveToCustomer);


        }
        catch
        {

        }


        return ret;
    }


    public static void SendEmaiReceiveToCustomer(object param)
    {
        Model_Setting s = new Model_Setting();
        s = s.GetSetting();

        object[] parameters = (object[])param;
        Model_Users user = (Model_Users)parameters[0];

        string body = string.Empty;
        string text = File.ReadAllText(HttpContext.Current.Server.MapPath("/Theme/emailtemplate/layout.html"), Encoding.UTF8);
        if (!string.IsNullOrEmpty(text))
        {
            string path = ConfigurationManager.AppSettings["AuthorizeBaseURL"].ToString().Replace("/admin", "") + "Verify?ID=" + StringUtility.EncryptedData(user.UserID.ToString());
            body = text.Replace("<!--##@Linkverfiy##-->", "<a href=\"" + path + "\" />here</a>");
        }

        MailSenderOption option = new MailSenderOption
        {
            MailSetting = s,
            context = HttpContext.Current,
            mailTo = user.Email,
            Mailbody = body,
            Subject = "Please verify"
        };
        MAilSender.SendMailEngine(option);
    }

    public static void SendEmailReceiveToStaff(string staffmail)
    {
        Model_Setting s = new Model_Setting();
        s = s.GetSetting();

       

        string body = string.Empty;
        string text = File.ReadAllText(HttpContext.Current.Server.MapPath("/Theme/emailtemplate/layout.html"), Encoding.UTF8);
        //if (!string.IsNullOrEmpty(text))
        //{
        //    string path = ConfigurationManager.AppSettings["AuthorizeBaseURL"].ToString().Replace("/admin", "") + "Verify?ID=" + StringUtility.EncryptedData(user.UserID.ToString());
        //    body = text.Replace("<!--##@Linkverfiy##-->", "<a href=\"" + path + "\" />here</a>");
        //}

        foreach(string email in staffmail.Split(';'))
        {
            MailSenderOption option = new MailSenderOption
            {
                MailSetting = s,
                context = HttpContext.Current,
                mailTo = email,
                Mailbody = body,
                Subject = "Please verify"
            };
            MAilSender.SendMailEngine(option);
        }
        
    }

}