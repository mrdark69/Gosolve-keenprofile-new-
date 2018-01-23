using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class _Orders : BasePageFront
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {

            //if (!string.IsNullOrEmpty(Request.QueryString["success"]))
            //{
            //    main_thanks.Visible = true;
            //    main_form.Visible = false;

            //    Model_AssesIntro intro = new Model_AssesIntro();
            //    intro = intro.GetIntro();
            //    ThanksTitle.Text = intro.ThanksTitle;
            //    ThanksDes.Text = convertcontent(intro.ThanksDes);
            //}

            if (!string.IsNullOrEmpty(Request.QueryString["ProductID"]))
            {
                switch (Request.QueryString["ProductID"])
                {
                    case "1":
                        lbltitle.Text = "ลิสต์รายชื่อสายงานทั้งหมดที่เหมาะกับอัจฉริยภาพและบุคลิกการทำงานของคุณ ง่ายๆ";
                        lbltitle2.Text = "แค่ดาวน์โหลด \"The Right Job - Functions Report\"";
                        lblpricemock.Text = "1,000";
                        lblpricenet.Text = "100";

                        amount.Text = "100";

                        Maintitle.Text = "The Right Job-Functions Report";
                        break;
                    case "2":
                        lbltitle.Text = "โค้ชลงลึกเกี่ยวกับกลยุทธ์เส้นทางอาชีพของคุณในอีก 3-5 ปีข้างหน้า โดยทีมงานผู้เชี่ยวชาญที่สัมภาษณ์ผู้บริหารมาแล้วมากกว่าพันคน คุณจะไม่ต้องหลงทางกับเส้นทางอาชีพของคุณอีกต่อไป";
                        lbltitle2.Text = "";
                        lblpricemock.Text = "5,000";
                        lblpricenet.Text = "1,000";
                        amount.Text = "1,000";

                        Maintitle.Text = "KEENCareer Coaching";
                        break;
                }
            }

            Model_Users u = this.UserActive;

            string orderID = Request.QueryString["orderID"];
            if (u != null && !string.IsNullOrEmpty(orderID))
            {
              


                firstName.Text = u.FirstName;
                email.Text = u.Email;
              
                txtPhone.Text = u.MobileNumber;

            }
           
        }
       

    }

    

   
   

    protected void btnBackprofile_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default#download");
    }


    public string functionBakIssue(byte gatewayID)
    {
        string ret = "";

        switch (gatewayID)
        {
            case 1:
                ret = "kbank";
                break;
            case 2:
                ret = "scb";
                break;
        }
        return ret;
    }

    protected void btn_confirm_Click(object sender, EventArgs e)
    {

        Model_Users u = this.UserActive;

        string orderID = Request.QueryString["orderID"];

        int intOrderID = int.Parse(orderID);
        string Filename = orderID + ".jpg";
        string FilePath = "/orderconfilmfile/" + Filename;

        string DAteconfirm = hd_date_payment.Value;
        string[] arrdatetime = DAteconfirm.Split('-');
        DateTime dpay = new DateTime(int.Parse(arrdatetime[0]), int.Parse(arrdatetime[1]), int.Parse(arrdatetime[2]), int.Parse(arrdatetime[3]), int.Parse(arrdatetime[4]), int.Parse(arrdatetime[5])).ToUniversalTime();
        Model_OrderPaymentTransferConfirm con = new Model_OrderPaymentTransferConfirm
        {
            Name = firstName.Text.Trim(),
            Email = email.Text.Trim(),
            DatePayment = dpay,
            Amount = decimal.Parse(amount.Text),
            Phone = txtPhone.Text,
            Extra = txtextra.Text,
            FilePath = FilePath,
            OrderID = intOrderID,
            GateWayID = byte.Parse(dropgatway.SelectedValue),
            BankIssue = functionBakIssue(byte.Parse(dropgatway.SelectedValue))

        };
        int intProductID = int.Parse(Request.QueryString["ProductID"]);

       int ret =  OrderController.ConfirmTransferPayment(intOrderID, u, con, intProductID);

        if( ret >0)
        {
            if (file.HasFile)
            {

               
                file.PostedFile.SaveAs(HttpContext.Current.Server.MapPath(FilePath));
            }

            Response.Redirect("~/Thankyou?Con=firm&OrderID=" + orderID + "&ProductID=" + intProductID);
        }

        
    }
}