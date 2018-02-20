using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dev_keen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        SendEmailReceiveToStaff();



        //SendingEngineController.cpool.QueueWork(parameters2, SendEmailReceiveToStaff);
    }

    public static void SendEmailReceiveToStaff()
    {

        Model_Setting s2 = new Model_Setting();
        s2 = s2.GetSetting();

        int intProductID = 1;

      

        string staffEmail = "mrdark6996@gmail.com;keenprofiledev@gmail.com";
        object[] param = new object[] { staffEmail, s2 };


        object[] parameters = (object[])param;
        string staffmail = (string)parameters[0];
        Model_Setting s = (Model_Setting)parameters[1];
        HttpContext context = HttpContext.Current;


        //Model_OrderPaymentTransferConfirm con = (Model_OrderPaymentTransferConfirm)parameters[3];

        string body = string.Empty;
        string text = "";
        if (intProductID == 1)
        {
            text = File.ReadAllText(context.Server.MapPath("/Theme/emailtemplate/layout_r3.html"), Encoding.UTF8);
        }

        if (intProductID == 2)
        {
            text = File.ReadAllText(context.Server.MapPath("/Theme/emailtemplate/layout_coaching.html"), Encoding.UTF8);
        }
        //if (!string.IsNullOrEmpty(text))
        //{
        //    string path = ConfigurationManager.AppSettings["AuthorizeBaseURL"].ToString().Replace("/admin", "") + "Verify?ID=" + StringUtility.EncryptedData(user.UserID.ToString());
        //    body = text.Replace("<!--##@Linkverfiy##-->", "<a href=\"" + path + "\" />here</a>");
        //}


        body = "FirstName : tet\r\n";
        body = body + "email : tet\r\n";
        body = body + "datetime : sss\r\n";

        FileInfo file = new FileInfo(HttpContext.Current.Server.MapPath("/orderconfirmfile/10033.jpg"));
        List<MailSenderFileAtt> list = new List<MailSenderFileAtt>();
        if (file.Exists)
        {
            list.Add(new MailSenderFileAtt
            {
                FileName = "",
                Path = "/orderconfirmfile/10033.jpg"

            });
           
        }

        
        foreach (string email in staffmail.Split(';'))
        {
            MailSenderOption option = new MailSenderOption
            {
                MailSetting = s,
                context = HttpContext.Current,
                mailTo = email,
                Mailbody = body,
                Attachment = list,
                Subject = "[Keen Staff] การชำระค่าบริการเสร็จสมบูรณ์แล้ว / Success Payment Confirmation "
            };
            MAilSender.SendMailEngine(option);
        }



    }
}