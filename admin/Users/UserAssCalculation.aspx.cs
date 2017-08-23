using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_UserAssCalculation : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ts"]))
            {
                int tsID = int.Parse(Request.QueryString["ts"]);

                Calculation_T1 T1 = new Calculation_T1(1, tsID);

                List<Model_UsersAssessment> T1list = T1.GetUserAss('f');
                StringBuilder ret = new StringBuilder();

                ret.Append("<table>");
                ret.Append("<tr>");
                ret.Append("<td>");
                    ret.Append("<table class='table'>");
                   
                    foreach (Model_UsersAssessment item in T1list.Where(o=>o.Side == 1))
                    {
                        ret.Append("<tr>");
                        ret.Append("<td style='text-align:left'>");
                        ret.Append("<p>"+ item.Code + " " + item.Questions +   "</p>");
                        ret.Append("</td>");

                        ret.Append("<td>");
                    ret.Append("<p "+ (item.SubSectionTitle.ToLower() == "n/a" ? "" : "style='background-color:#fff202'") + "><strong>" + (item.SubSectionTitle.ToLower() == "n/a" ? "" : "<span style='font-size:9px'>" + item.SubSectionTitle + "</span>") + " " + item.Score + "</strong></p>");
                    ret.Append("</td>");
                    ret.Append("</tr>");
                }

                  
                    ret.Append("</table>");

                ret.Append("</td>");

                ret.Append("<td>");

                    ret.Append("<table class='table '>");
                   
                    foreach (Model_UsersAssessment item in T1list.Where(o => o.Side == 2))
                    {
                        ret.Append("<tr>");
                        ret.Append("<td>");
                        ret.Append("<p "+ (item.SubSectionTitle.ToLower() == "n/a" ? "" : "style='background-color:#fff202'") + "><strong>" + item.Score + " " + (item.SubSectionTitle.ToLower() == "n/a" ? "" : "<span style='font-size:9px'>" + item.SubSectionTitle + "</span>") + "</strong></p>");
                        ret.Append("</td>");
                        ret.Append("<td style='text-align:right'>");
                    ret.Append("<p>" + item.Code + " " + item.Questions + "</p>");
                    ret.Append("</td>");
                        ret.Append("</tr>");
                    }

                   
                    ret.Append("</table>");
                ret.Append("</td>");
                ret.Append("</tr>");
                ret.Append("</table>");
                data.Text = ret.ToString();



                StringBuilder retchH = new StringBuilder();

                List<Model_UsersAssessment> T1list_h = T1.GetUserAss('h');
                List<Model_UsersAssChoice> T1list_h_c = T1.GetUserAssChoice('h');

                foreach (Model_UsersAssessment cc in T1list_h)
                {
                    retchH.Append("<div style='margin-bottom:10px;'>");
                    retchH.Append("<p>"+cc.Questions+"</p>");
                    ret.Append("<table class='table table-strip'>");

                    foreach(Model_UsersAssChoice ch in T1list_h_c.Where(o=>o.TASID == cc.TASID))
                    {
                        ret.Append("<tr>");
                        ret.Append("<td>"+ch.Questions+"</td>");
                     
                        ret.Append("<td>"+ch.Score+"</td>");
                      
                        ret.Append("</tr>");
                    }


                    ret.Append("</table>");

                    retchH.Append("</div>");
                }

                datah2.Text = retchH.ToString();


                StringBuilder retF2 = new StringBuilder();

                List<Model_ReportItemResult> fscore = T1.Code_F_SumValueBySubSection(T1list);


                retF2.Append("<table class='table'>");
               
                foreach (Model_ReportItemResult i in fscore)
                {
                    retF2.Append("<tr>");
                    retF2.Append("<td>");
                    retF2.Append( "<p>" + i.ResultItemTitle +   "</p>");
                    retF2.Append("</td>");
                    retF2.Append("<td>");
                    retF2.Append("<p>" +  i.Score + "</p>");
                    retF2.Append("</td>");
                    retF2.Append("</tr>");
                }

                retF2.Append("</table>");


                dataf2.Text = retF2.ToString();

            }

        }
    }

   

    protected void btnRecal_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["ts"]))
        {
            int tsID = int.Parse(Request.QueryString["ts"]);
            bool IsCom = CalculationController.CalculateActionStart(tsID);

            if (IsCom)
                Response.Redirect(Request.Url.ToString());
        }

          
    }
}