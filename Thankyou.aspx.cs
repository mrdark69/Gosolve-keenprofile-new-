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

            Model_Users u = this.UserActive;

            string orderID = Request.QueryString["orderID"];
            if (u != null && !string.IsNullOrEmpty(orderID))
            {
                



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