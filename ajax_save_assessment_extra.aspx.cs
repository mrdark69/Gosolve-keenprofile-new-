using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ajax_save_assessment_extra : BasePageFront
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            bool IsCom = false;
            int ret = 0;
            if (!string.IsNullOrEmpty(Request.Form["ctl00$MainContent$heUserID"]) && !string.IsNullOrEmpty(Request.Form["ctl00$MainContent$hdTsID"]))
            {
                //try
                //{
                    int UserId = int.Parse(Request.Form["ctl00$MainContent$heUserID"]);
                int tsid = int.Parse(Request.Form["ctl00$MainContent$hdTsID"]);
                //Profile Process

                Model_ReportItemResult cr = new Model_ReportItemResult();

                string resultID = Request.Form["ass_fill_ch_"];
                if (!string.IsNullOrEmpty(resultID))
                {

                    string[] arrResultID = resultID.Split(',');

                    foreach(string r in arrResultID)
                    {
                        int intResultID = int.Parse(r);
                        int RankVal = int.Parse(Request.Form["ass_fill_ch_sc_" + r]);
                        IsCom = cr.UpdateUserRank(intResultID, RankVal);
                    }
                }

               
           

             
                    if (IsCom)
                    ret = CalculationController.CalculateActionStart(tsid);
              

               

            }

            string strRet = "True";
            switch (ret)
            {
                case -1:
                    strRet = "False";
                    break;
                case 0:
                    strRet = "True";
                    break;
                default:
                    strRet = ret.ToString();
                    break;
            }



            Response.Write(strRet);
            Response.End();
        }
    }
}