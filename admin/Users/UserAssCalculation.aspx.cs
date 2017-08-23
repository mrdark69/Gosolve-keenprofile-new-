﻿using System;
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

            T1Cal();
            T2Cal();
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

    public void T2Cal()
    {
        
        if (!string.IsNullOrEmpty(Request.QueryString["ts"]))
        {
            int tsID = int.Parse(Request.QueryString["ts"]);

            Calculation_T2 T2 = new Calculation_T2(2, tsID);

            //List<Model_UsersAssessment> T1list = T1.GetUserAss('f');
            StringBuilder ret = new StringBuilder();

            ret.Append("<table class='table table-strip'>");


            foreach (Model_UsersAssessment item in T2.R_UserAss_D.OrderBy(o => o.SUCID)) 
            {
                ret.Append("<tr>");
                ret.Append("<td style='text-align:left'>");
                ret.Append("<p>" + item.Code + " " + item.Questions + "</p>");
                ret.Append("</td>");

                ret.Append("<td>");
                ret.Append("<p>" + item.SubSectionTitle + "  "  + item.Score + "</p>");
                ret.Append("</td>");
               
                
                ret.Append("</tr>");
            }

            ret.Append("</table>");






            ret.Append("<table class='table table-strip'>");


            foreach (Model_UsersAssessment item in T2.R_UserAss_SumGroup_D)
            {
                ret.Append("<tr>");
                ret.Append("<td style='text-align:left'>");
                ret.Append("<p>" + item.SubSectionTitle + "</p>");
                ret.Append("</td>");

                ret.Append("<td>");
                ret.Append("<p>" + item.Score + "</p>");
                ret.Append("</td>");
                ret.Append("<td>");
                int score_r = T2.R_UserAss_SumGroup_D_RealScore.SingleOrDefault(o => o.SUCID == item.SUCID).Score;
                ret.Append("<p style='background-color:#fff202'>" + score_r + "         x2 = <strong>"+(score_r)+"</strong></p>");
                ret.Append("</td>");
                ret.Append("</tr>");
            }

            ret.Append("</table>");


            dataD.Text = ret.ToString();
            //List<object[]> Sumgroup = T1.R_UserAss_D
            ///* Group the list by the element at position 0 in each item */
            //.GroupBy(o => o.SUCID)
            ///* Project the created grouping into a new object[]: */
            //.Select(i => new object[]
            //{
            //    i.Key,
            //    i.Sum(x => (int)x.Score)
            //})
            //.ToList();


            StringBuilder retchH = new StringBuilder();

            List<Model_UsersAssessment> T1list_h = T2.R_UserAss_E;
            List<Model_UsersAssChoice> T1list_h_c = T2.R_UserAssChoice_E;

            foreach (Model_UsersAssessment cc in T1list_h)
            {
                retchH.Append("<div style='margin-bottom:10px;'>");
                retchH.Append("<p>" + cc.Questions + "</p>");
                retchH.Append("<table class='table table-strip'>");

                foreach (Model_UsersAssChoice ch in T1list_h_c.Where(o => o.TASID == cc.TASID))
                {
                    retchH.Append("<tr>");
                    retchH.Append("<td>" + ch.Questions + "</td>");
                    retchH.Append("<td>" + ch.SubSectionTitle + "</td>");
                    retchH.Append("<td>" + ch.Score + "</td>");

                    retchH.Append("</tr>");
                }


                retchH.Append("</table>");

                retchH.Append("</div>");
            }

            DAtaE.Text = retchH.ToString();


            StringBuilder retF2 = new StringBuilder();

            List<Model_ReportItemResult> fscore = T2.Code_SumValueBySubSection();


            retF2.Append("<table class='table'>");

            foreach (Model_ReportItemResult i in fscore)
            {
                retF2.Append("<tr>");
                retF2.Append("<td>");
                retF2.Append("<p>" + i.ResultItemTitle + "</p>");
                retF2.Append("</td>");
                retF2.Append("<td>");
                retF2.Append("<p>" + i.Score + "</p>");
                retF2.Append("</td>");
                retF2.Append("</tr>");
            }

            retF2.Append("</table>");


            dataT2.Text = retF2.ToString();

        }
    }

    public void T1Cal()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["ts"]))
        {
            int tsID = int.Parse(Request.QueryString["ts"]);

            Calculation_T1 T1 = new Calculation_T1(1, tsID);

            //List<Model_UsersAssessment> T1list = T1.GetUserAss('f');
            StringBuilder ret = new StringBuilder();

            ret.Append("<table>");
            ret.Append("<tr>");
            ret.Append("<td>");
            ret.Append("<table class='table'>");

            foreach (Model_UsersAssessment item in T1.R_UserAss_F.Where(o => o.Side == 1))
            {
                ret.Append("<tr>");
                ret.Append("<td style='text-align:left'>");
                ret.Append("<p>" + item.Code + " " + item.Questions + "</p>");
                ret.Append("</td>");

                ret.Append("<td>");
                ret.Append("<p " + (item.SubSectionTitle.ToLower() == "n/a" ? "" : "style='background-color:#fff202'") + "><strong>" + (item.SubSectionTitle.ToLower() == "n/a" ? "" : "<span style='font-size:9px'>" + item.SubSectionTitle + "</span>") + " " + item.Score + "</strong></p>");
                ret.Append("</td>");
                ret.Append("</tr>");
            }


            ret.Append("</table>");

            ret.Append("</td>");

            ret.Append("<td>");

            ret.Append("<table class='table '>");

            foreach (Model_UsersAssessment item in T1.R_UserAss_F.Where(o => o.Side == 2))
            {
                ret.Append("<tr>");
                ret.Append("<td>");
                ret.Append("<p " + (item.SubSectionTitle.ToLower() == "n/a" ? "" : "style='background-color:#fff202'") + "><strong>" + item.Score + " " + (item.SubSectionTitle.ToLower() == "n/a" ? "" : "<span style='font-size:9px'>" + item.SubSectionTitle + "</span>") + "</strong></p>");
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

            List<Model_UsersAssessment> T1list_h = T1.R_UserAss_H;
            List<Model_UsersAssChoice> T1list_h_c = T1.R_UserAssChoice_H;

            foreach (Model_UsersAssessment cc in T1list_h)
            {
                retchH.Append("<div style='margin-bottom:10px;'>");
                retchH.Append("<p>" + cc.Questions + "</p>");
                retchH.Append("<table class='table table-strip'>");

                foreach (Model_UsersAssChoice ch in T1list_h_c.Where(o => o.TASID == cc.TASID))
                {
                    retchH.Append("<tr>");
                    retchH.Append("<td>" + ch.Questions + "</td>");
                    retchH.Append("<td>" + ch.SubSectionTitle + "</td>");
                    retchH.Append("<td>" + ch.Score + "</td>");

                    retchH.Append("</tr>");
                }


                retchH.Append("</table>");

                retchH.Append("</div>");
            }

            datah2.Text = retchH.ToString();


            StringBuilder retF2 = new StringBuilder();

            List<Model_ReportItemResult> fscore = T1.Code_F_SumValueBySubSection();


            retF2.Append("<table class='table'>");

            foreach (Model_ReportItemResult i in fscore)
            {
                retF2.Append("<tr>");
                retF2.Append("<td>");
                retF2.Append("<p>" + i.ResultItemTitle + "</p>");
                retF2.Append("</td>");
                retF2.Append("<td>");
                retF2.Append("<p>" + i.Score + "</p>");
                retF2.Append("</td>");
                retF2.Append("</tr>");
            }

            retF2.Append("</table>");


            dataf2.Text = retF2.ToString();

        }
    }
}