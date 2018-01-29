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
        this.Page.Title = "KeenProfile Thank you";
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

            Model_Users u = this.UserActive;

            string orderID = Request.QueryString["orderID"];



            if (u != null && !string.IsNullOrEmpty(orderID))
            {

                switch (Request.QueryString["ProductID"])
                {
                    case "1":
                        lbldes.Text = "เราได้รับการยืนยันการโอนเงินจากคุณเรียบร้อยแล้ว <strong> กรุณารอการยืนยันจากทีมงานประมาณ 5 นาที </strong> ทางทีมงานจะส่งอีเมลแจ้งคุณทันทีที่การโอนเงินได้รับการยืนยันจากเจ้าหน้าที่ จากนั้นคุณจะสามารถ Download Report ได้ทันที โดยปุ่มจะเปลี่ยนจาก \"ต้องการ Download\" เป็น \"คลิกเพื่อ Download\"";
                        break;
                    case "2":
                        lbldes.Text = "เราได้รับการยืนยันการโอนเงินจากคุณเรียบร้อยแล้ว <strong>กรุณารอการยืนยันจากทีมงานประมาณ 1-3 วัน </strong> ทางทีมงานจะส่งอีเมลและโทรติดต่อคุณทันทีที่การโอนเงินได้รับการยืนยันจากเจ้าหน้าที่ จากนั้นทีมผู้เชี่ยวชาญจะทำการนัดหมายคุณเพื่อรับการโค้ชในวัน-เวลาที่คุณสะดวก";
                        break;
                }


                Maintitle.Text = "Order Summary : OrderID#158237 [รอการชำระเงิน]";

                
            }
            
           
        }
       
       



    }

    

   
   

    protected void btnBackprofile_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default#download");
    }


    protected void btnDownload_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default#download");
    }
}