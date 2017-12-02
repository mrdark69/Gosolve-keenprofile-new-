using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDatatableApp;
using System.IO;
using System.Text;
using System.Configuration;
using System.Web.SessionState;
using System.Text.RegularExpressions;
/// <summary>

/// <summary>
/// Summary description for AssessmentController
/// </summary>
public class AssessmentController
{
    public AssessmentController()
    {
        //
        // TODO: Add constructor logic here
        //
    }


   
    public static string GetPaperReport1(Model_Users u)
    {
        string ret = StringUtility.GetPDFTemplate("report1");

        string userfullname = u.FirstName + " " + u.LastName;

        Model_UsersTransaction ts = new Model_UsersTransaction();
        ts = ts.GetTsLatestByUser(u.UserID);

        if (ts != null && u != null)
        {
            Model_ReportItemResult report = new Model_ReportItemResult();
            List<Model_ReportItemResult> reportlist = report.GetItemReportByTransactionIDwithTitle(ts.TransactionID);

            ret = Regex.Replace(ret, "<!--###FullName###-->", userfullname);

            DateTime Date = DateTime.Now;

            ret = Regex.Replace(ret, "<!--###Datetime###-->", Date.ToString("dd-MMM-yyyy"));
            //T1 process

            List<Model_ReportItemResult> T1list = reportlist.Where(o => o.ResultSectionID == 1).ToList();
            var T1Rank = T1list.Select(s => new {
                ResultID = s.ResultID,
                Title = s.ResultItemTitle,
                ResultItemID = s.ResultItemID,
                des_Detail = s.des_Detail,
                des_PeopleTxt = s.des_PeopleTxt,
                des_CultureTxt = s.des_CultureTxt,
                des_Short = s.des_Short,
                des_CompetitionTxt = s.des_CompetitionTxt,
                Ranking = T1list.Count(x => (decimal)x.Score > (decimal)s.Score) + 1,

            });

            int Innovation = T1Rank.FirstOrDefault(o => o.ResultItemID == 1).Ranking;
            int Service = T1Rank.FirstOrDefault(o => o.ResultItemID == 2).Ranking;
            int Cost = T1Rank.FirstOrDefault(o => o.ResultItemID == 3).Ranking;

            if(Innovation ==1 || Innovation  == 2 )
                ret = ret.Replace("<!--###css_color_1###-->", "item_blue");
            if (Service == 1 || Service == 2)
                ret = ret.Replace("<!--###css_color_2###-->", "item_blue");
            if (Cost == 1 || Cost == 2)
                ret = ret.Replace("<!--###css_color_3###-->", "item_blue");

            ret = ret.Replace("<!--###css_color_1###-->", "");
            ret = ret.Replace("<!--###css_color_2###-->", "");
            ret = ret.Replace("<!--###css_color_3###-->", "");

            ret = ret.Replace("<!--###T1_1###-->", Innovation.ToString());
            ret = ret.Replace("<!--###T1_2###-->", Service.ToString());
            ret = ret.Replace("<!--###T1_3###-->", Cost.ToString());

           
              string phi = string.Empty;
            StringBuilder phidetail = new StringBuilder();
            int countphi = 1;
            foreach (var i in T1Rank.Where(o => o.Ranking <= 2).OrderBy(o=>o.Ranking))
            {
                if(countphi <= 2)
                {


                    phi = phi + "<li>" + countphi + "." + i.Title + "</li>";

                    phidetail.Append("<div class=\"desscription-body big tri\">");
                    phidetail.Append("<div class=\"desscription-body-block left\">");
                    phidetail.Append("<div class=\"triangle-block big \">");
                    phidetail.Append("<span>"+i.Title+" <br />("+i.Ranking+")</span> ");
                       phidetail.Append("</div>");
                    phidetail.Append("</div>");
                    phidetail.Append("<div class=\"desscription-body-block right\">");
                    phidetail.Append("<p><span>"+i.Title+"</span></p>");
                    phidetail.Append("<p>");
                    phidetail.Append(i.des_Detail);
                    
                        phidetail.Append("</p>");
                    phidetail.Append("</div>");
                    phidetail.Append("<div class=\"clear:both\"></div>");
                    phidetail.Append("<div class=\"des-topic\">");
                    phidetail.Append("<p class=\"topic\">What does your environment look like?</p>");
                    phidetail.Append("<p><span>People:</span>"+i.des_PeopleTxt+"</p>");
                    phidetail.Append("<p><span>Culture:</span> "+i.des_CultureTxt+"</p>");
                    phidetail.Append("<p><span>Competition:</span> "+i.des_CompetitionTxt+"</p>");
                    phidetail.Append("</div>");
                    phidetail.Append(" </div>");



                }

                countphi = countphi + 1;
            }

            ret = ret.Replace("<!--###T1_phi_detail###-->", phidetail.ToString());
            ret = ret.Replace("<!--###T2_phi_7###-->", phi);
            //T2 process

            List <Model_ReportItemResult> T2list = reportlist.Where(o => o.ResultSectionID == 2).ToList();
            var T2Rank = T2list.Select(s => new {
                ResultID = s.ResultID,
                ResultItemID = s.ResultItemID,
                Title = s.ResultItemTitle,
                des_Detail = s.des_Detail,
                des_PeopleTxt = s.des_PeopleTxt,
                des_CultureTxt = s.des_CultureTxt,
                des_Short = s.des_Short,
                des_CompetitionTxt = s.des_CompetitionTxt,
                Ranking = T2list.Count(x => (decimal)x.Score > (decimal)s.Score) + 1,

            });

            int Inventor = T2Rank.FirstOrDefault(o => o.ResultItemID == 4).Ranking;
            int Promoter = T2Rank.FirstOrDefault(o => o.ResultItemID == 5).Ranking;
            int Optimizer = T2Rank.FirstOrDefault(o => o.ResultItemID == 6).Ranking;
            int Controller = T2Rank.FirstOrDefault(o => o.ResultItemID == 7).Ranking;

            if (Inventor == 1 || Inventor == 2)
                ret = ret.Replace("<!--###css_color_1_1###-->", "item_blue_bg");
            if (Promoter == 1 || Promoter == 2)
                ret = ret.Replace("<!--###css_color_2_2###-->", "item_blue_bg");
            if (Optimizer == 1 || Optimizer == 2)
                ret = ret.Replace("<!--###css_color_3_3###-->", "item_blue_bg");
            if (Controller == 1 || Controller == 2)
                ret = ret.Replace("<!--###css_color_4_4###-->", "item_blue_bg");

            ret = ret.Replace("<!--###css_color_1_1###-->", "");
            ret = ret.Replace("<!--###css_color_2_2###-->", "");
            ret = ret.Replace("<!--###css_color_3_3###-->", "");
            ret = ret.Replace("<!--###css_color_4_4###-->", "");

            ret = ret.Replace("<!--###T2_1###-->", Inventor.ToString());
            ret = ret.Replace("<!--###T2_2###-->", Promoter.ToString());
            ret = ret.Replace("<!--###T2_3###-->", Optimizer.ToString());
            ret = ret.Replace("<!--###T2_4###-->", Controller.ToString());



            string trait = string.Empty;
            StringBuilder traitdetail = new StringBuilder();
            int count = 1;
            foreach (var i in T2Rank.Where(o => o.Ranking <=2).OrderBy(o=>o.Ranking))
            {
                if(count <= 2)
                {
                    trait = trait + "<li>" + count + "." + i.Title + "</li>";



                    traitdetail.Append("<div class=\"desscription-body big\">");
                    traitdetail.Append("<div class=\"desscription-body-block left\">");
                    traitdetail.Append("<div class=\"square-block big bg-blue\">");
                    traitdetail.Append(" " + i.Title + " <br />(1)");
                    traitdetail.Append("</div>");
                    traitdetail.Append("</div>");
                    traitdetail.Append("<div class=\"desscription-body-block right\">");
                    traitdetail.Append(" <p><span>" + i.Title + "</span></p>");
                    traitdetail.Append("<p>");
                    traitdetail.Append(i.des_Detail);
                    traitdetail.Append("</p>");
                    traitdetail.Append("</div>");
                    traitdetail.Append(" </div>");
                }
               


                count = count + 1;

            }
            
                ret = ret.Replace("<!--###T2_des_detail###-->", traitdetail.ToString());
            ret = ret.Replace("<!--###T2_trait_7###-->", trait);

            //T3 process

            List<Model_ReportItemResult> T3list = reportlist.Where(o => o.ResultSectionID == 3).ToList();
            var T3Rank = T3list.Select(s => new {
                ResultID = s.ResultID,
                ResultItemID = s.ResultItemID,
                Title = s.ResultItemTitle,
                Isabove = s.IsAbove,
                Isbelow = s.IsBelow,
                des_Detail = s.des_Detail,
                des_PeopleTxt = s.des_PeopleTxt,
                des_CultureTxt= s.des_CultureTxt,
                des_Short = s.des_Short,
                des_CompetitionTxt= s.des_CompetitionTxt,
                Ranking = T3list.Count(x => (decimal)x.Score_new > (decimal)s.Score_new) + 1,

            });


    ret = jobT3(T3Rank, ret, "Creative", 8, 1);
            ret = jobT3(T3Rank, ret, "Strategic", 9, 2);
            ret = jobT3(T3Rank, ret, "Analytical", 10, 3);
            ret = jobT3(T3Rank, ret, "Numerical", 11, 4);
            ret = jobT3(T3Rank, ret, "Prudently", 12, 5);
            ret = jobT3(T3Rank, ret, "Obstacle", 13, 6);
            ret = jobT3(T3Rank, ret, "Words", 14, 7);
            ret = jobT3(T3Rank, ret, "Strong", 15, 8);
            ret = jobT3(T3Rank, ret, "Socialize", 16, 9);
            ret = jobT3(T3Rank, ret, "Knowledge", 17, 10);
            ret = jobT3(T3Rank, ret, "Individualizing", 18, 11);
            ret = jobT3(T3Rank, ret, "Sensation", 19, 12);
            ret = jobT3(T3Rank, ret, "Momentum", 20, 13);
            ret = jobT3(T3Rank, ret, "Working", 21, 14);
            ret = jobT3(T3Rank, ret, "Emotion", 22, 15);
            ret = jobT3(T3Rank, ret, "Time", 23, 16);
            ret = jobT3(T3Rank, ret, "Priority", 24, 17);
            ret = jobT3(T3Rank, ret, "Delegating", 25, 18);

            string top7 = string.Empty;
            StringBuilder detail = new StringBuilder();
            int count7 = 1;
            foreach(var i in T3Rank.Where(o => o.Ranking <= 7).OrderBy(o=>o.Ranking))
            {
                if(count <= 7)
                {
                    top7 = top7 + "<li>" + count7 + "." + i.Title + (i.Isabove ? "*" : "") + "</li>";


                    detail.Append("<div class=\"desscription-body\">");

                    detail.Append("<div class=\"desscription-body-block left\">");

                    detail.Append("<div class=\"square-block bg-blue\">");

                    detail.Append(i.Title + "* <br />("+ i.Ranking + ")");
                    detail.Append("</div>");

                    detail.Append("</div>");

                    detail.Append("<div class=\"desscription-body-block right\">");
                    detail.Append("<p><span>"+ i.Title + "*: </span>");
                    detail.Append(i.des_Detail);

                    detail.Append("</p>");
                    detail.Append("</div>");
                    detail.Append("</div>");
                }
                


                
                    
                
                count7 = count7 + 1;

            }
            ret = ret.Replace("<!--###T3_des_detail###-->", detail.ToString());
            ret = ret.Replace("<!--###T3_TOP_7###-->", top7);
            

            string bottom4 = string.Empty;
            int count4 = 1;
            StringBuilder detail2 = new StringBuilder();
            foreach (var i in T3Rank.Where(o => o.Ranking > 14).OrderBy(o => o.Ranking))
            {
                

                if(count4 <= 4)
                {
                    bottom4 = bottom4 + "<li>" + count4 + "." + i.Title + (i.Isbelow ? "*" : "") + "</li>";
                    detail2.Append("<div class=\"desscription-body\">");

                    detail2.Append("<div class=\"desscription-body-block left\">");

                    detail2.Append("<div class=\"square-block bg-red\">");

                    detail2.Append(i.Title + "* <br />(" + i.Ranking + ")");
                    detail2.Append("</div>");

                    detail2.Append("</div>");

                    detail2.Append("<div class=\"desscription-body-block right\">");
                    detail2.Append("<p><span>" + i.Title + "*: </span>");
                    detail2.Append(i.des_Detail);

                    detail2.Append("</p>");
                    detail2.Append("</div>");
                    detail2.Append("</div>");
                }


                count4 = count4 + 1;

            }
            ret = ret.Replace("<!--###T3_des_detail_bottom###-->", detail2.ToString());
            ret = ret.Replace("<!--###T3_Bottom_4###-->", bottom4);

           



        }




        return ret;
    }
    public static string GetPaperReport2(Model_Users u)
    {
        string ret = StringUtility.GetPDFTemplate("report2");

        string userfullname = u.FirstName + " " + u.LastName;

        Model_UsersTransaction ts = new Model_UsersTransaction();
        ts = ts.GetTsLatestByUser(u.UserID);


        if (ts != null && u != null)
        {
            Model_ReportItemResult report = new Model_ReportItemResult();
            List<Model_ReportItemResult> reportlist = report.GetItemReportByTransactionIDwithTitle(ts.TransactionID);

            ret = Regex.Replace(ret, "<!--###FullName###-->", userfullname);
            DateTime Date = DateTime.Now;

            ret = Regex.Replace(ret, "<!--###Datetime###-->", Date.ToString("dd-MMM-yyyy"));
            //T1 process

            List<Model_ReportItemResult> T1list = reportlist.Where(o => o.ResultSectionID == 1).ToList();
            var T1Rank = T1list.Select(s => new {
                ResultID = s.ResultID,
                Title = s.ResultItemTitle,
                ResultItemID = s.ResultItemID,
                des_Detail = s.des_Detail,
                des_PeopleTxt = s.des_PeopleTxt,
                des_CultureTxt = s.des_CultureTxt,
                des_Short = s.des_Short,
                des_CompetitionTxt = s.des_CompetitionTxt,
                Ranking = T1list.Count(x => (decimal)x.Score > (decimal)s.Score) + 1,

            });

            int Innovation = T1Rank.FirstOrDefault(o => o.ResultItemID == 1).Ranking;
            int Service = T1Rank.FirstOrDefault(o => o.ResultItemID == 2).Ranking;
            int Cost = T1Rank.FirstOrDefault(o => o.ResultItemID == 3).Ranking;

            if (Innovation == 1 || Innovation == 2)
                ret = ret.Replace("<!--###css_color_1###-->", "item_blue");
            if (Service == 1 || Service == 2)
                ret = ret.Replace("<!--###css_color_2###-->", "item_blue");
            if (Cost == 1 || Cost == 2)
                ret = ret.Replace("<!--###css_color_3###-->", "item_blue");

            ret = ret.Replace("<!--###css_color_1###-->", "");
            ret = ret.Replace("<!--###css_color_2###-->", "");
            ret = ret.Replace("<!--###css_color_3###-->", "");

            ret = ret.Replace("<!--###T1_1###-->", Innovation.ToString());
            ret = ret.Replace("<!--###T1_2###-->", Service.ToString());
            ret = ret.Replace("<!--###T1_3###-->", Cost.ToString());


            string phi = string.Empty;
          
            int countphi = 1;
            foreach (var i in T1Rank.Where(o => o.Ranking <= 2).OrderBy(o => o.Ranking))
            {
                if (countphi <= 2)
                {


                    phi = phi + "<li>" + countphi + "." + i.Title + "</li>";

                  



                }

                countphi = countphi + 1;
            }

           
            ret = ret.Replace("<!--###T2_phi_7###-->", phi);
            //T2 process

            List<Model_ReportItemResult> T2list = reportlist.Where(o => o.ResultSectionID == 2).ToList();
            var T2Rank = T2list.Select(s => new {
                ResultID = s.ResultID,
                ResultItemID = s.ResultItemID,
                Title = s.ResultItemTitle,
                des_Detail = s.des_Detail,
                des_PeopleTxt = s.des_PeopleTxt,
                des_CultureTxt = s.des_CultureTxt,
                des_Short = s.des_Short,
                des_CompetitionTxt = s.des_CompetitionTxt,
                Ranking = T2list.Count(x => (decimal)x.Score > (decimal)s.Score) + 1,

            });

            int Inventor = T2Rank.FirstOrDefault(o => o.ResultItemID == 4).Ranking;
            int Promoter = T2Rank.FirstOrDefault(o => o.ResultItemID == 5).Ranking;
            int Optimizer = T2Rank.FirstOrDefault(o => o.ResultItemID == 6).Ranking;
            int Controller = T2Rank.FirstOrDefault(o => o.ResultItemID == 7).Ranking;

            if (Inventor == 1 || Inventor == 2)
                ret = ret.Replace("<!--###css_color_1_1###-->", "item_blue_bg");
            if (Promoter == 1 || Promoter == 2)
                ret = ret.Replace("<!--###css_color_2_2###-->", "item_blue_bg");
            if (Optimizer == 1 || Optimizer == 2)
                ret = ret.Replace("<!--###css_color_3_3###-->", "item_blue_bg");
            if (Controller == 1 || Controller == 2)
                ret = ret.Replace("<!--###css_color_4_4###-->", "item_blue_bg");

            ret = ret.Replace("<!--###css_color_1_1###-->", "");
            ret = ret.Replace("<!--###css_color_2_2###-->", "");
            ret = ret.Replace("<!--###css_color_3_3###-->", "");
            ret = ret.Replace("<!--###css_color_4_4###-->", "");

            ret = ret.Replace("<!--###T2_1###-->", Inventor.ToString());
            ret = ret.Replace("<!--###T2_2###-->", Promoter.ToString());
            ret = ret.Replace("<!--###T2_3###-->", Optimizer.ToString());
            ret = ret.Replace("<!--###T2_4###-->", Controller.ToString());



            string trait = string.Empty;
            StringBuilder traitdetail = new StringBuilder();
            int count = 1;
            foreach (var i in T2Rank.Where(o => o.Ranking <= 2).OrderBy(o => o.Ranking))
            {
                if (count <= 2)
                {
                    trait = trait + "<li>" + count + "." + i.Title + "</li>";



                    traitdetail.Append("<div class=\"desscription-body big\">");
                    traitdetail.Append("<div class=\"desscription-body-block left\">");
                    traitdetail.Append("<div class=\"square-block big bg-blue\">");
                    traitdetail.Append(" " + i.Title + " <br />(1)");
                    traitdetail.Append("</div>");
                    traitdetail.Append("</div>");
                    traitdetail.Append("<div class=\"desscription-body-block right\">");
                    traitdetail.Append(" <p><span>" + i.Title + "</span></p>");
                    traitdetail.Append("<p>");
                    traitdetail.Append(i.des_Detail);
                    traitdetail.Append("</p>");
                    traitdetail.Append("</div>");
                    traitdetail.Append(" </div>");
                }



                count = count + 1;

            }

            ret = ret.Replace("<!--###T2_des_detail###-->", traitdetail.ToString());
            ret = ret.Replace("<!--###T2_trait_7###-->", trait);

            //T3 process

            List<Model_ReportItemResult> T3list = reportlist.Where(o => o.ResultSectionID == 3).ToList();
            var T3Rank = T3list.Select(s => new {
                ResultID = s.ResultID,
                ResultItemID = s.ResultItemID,
                Title = s.ResultItemTitle,
                Isabove = s.IsAbove,
                Isbelow = s.IsBelow,
                des_Detail = s.des_Detail,
                des_PeopleTxt = s.des_PeopleTxt,
                des_CultureTxt = s.des_CultureTxt,
                des_Short = s.des_Short,
                des_CompetitionTxt = s.des_CompetitionTxt,
                Ranking = T3list.Count(x => (decimal)x.Score_new > (decimal)s.Score_new) + 1,

            });


            ret = jobT3(T3Rank, ret, "Creative", 8, 1);
            ret = jobT3(T3Rank, ret, "Strategic", 9, 2);
            ret = jobT3(T3Rank, ret, "Analytical", 10, 3);
            ret = jobT3(T3Rank, ret, "Numerical", 11, 4);
            ret = jobT3(T3Rank, ret, "Prudently", 12, 5);
            ret = jobT3(T3Rank, ret, "Obstacle", 13, 6);
            ret = jobT3(T3Rank, ret, "Words", 14, 7);
            ret = jobT3(T3Rank, ret, "Strong", 15, 8);
            ret = jobT3(T3Rank, ret, "Socialize", 16, 9);
            ret = jobT3(T3Rank, ret, "Knowledge", 17, 10);
            ret = jobT3(T3Rank, ret, "Individualizing", 18, 11);
            ret = jobT3(T3Rank, ret, "Sensation", 19, 12);
            ret = jobT3(T3Rank, ret, "Momentum", 20, 13);
            ret = jobT3(T3Rank, ret, "Working", 21, 14);
            ret = jobT3(T3Rank, ret, "Emotion", 22, 15);
            ret = jobT3(T3Rank, ret, "Time", 23, 16);
            ret = jobT3(T3Rank, ret, "Priority", 24, 17);
            ret = jobT3(T3Rank, ret, "Delegating", 25, 18);

            string top7 = string.Empty;
         
            int count7 = 1;
            foreach (var i in T3Rank.Where(o => o.Ranking <= 7).OrderBy(o => o.Ranking))
            {
                if (count <= 7)
                {
                    top7 = top7 + "<li>" + count7 + "." + i.Title + (i.Isabove ? "*" : "") + "</li>";


                   
                }






                count7 = count7 + 1;

            }
            
            ret = ret.Replace("<!--###T3_TOP_7###-->", top7);


            string bottom4 = string.Empty;
            int count4 = 1;
          
            foreach (var i in T3Rank.Where(o => o.Ranking > 14).OrderBy(o => o.Ranking))
            {
               

                if (count4 <= 4)
                {
                    bottom4 = bottom4 + "<li>" + count4 + "." + i.Title + (i.Isbelow ? "*" : "") + "</li>";

                }


                count4 = count4 + 1;

            }
           
            ret = ret.Replace("<!--###T3_Bottom_4###-->", bottom4);



            //T4

            List<Model_ReportItemResult> T4list = reportlist.Where(o => o.ResultSectionID == 4).ToList();

            Decimal SumScore = 0.0m;
            decimal SumIdeal = 0.0m;
            StringBuilder T4ret = new StringBuilder();
            int countt4 = 1;
            foreach (Model_ReportItemResult i in T4list.OrderByDescending(o => o.Score_new))
            {
             
              

                if(countt4<= 7)
                    T4ret.Append("<tr class=\"bg-blue\">");
                else if(countt4> 14)
                    T4ret.Append("<tr class=\"bg-red\">");
                else
                    T4ret.Append("<tr class=\"bg-grey\">");
               
                T4ret.Append("<td " + (count4==1? "style=\"border-top:none;\"": "") + ">" + countt4 + "</td>");
                T4ret.Append("<td " + (count4 == 1 ? "style=\"border-top:none;\"" : "") + ">" + i.ResultItemTitle +( i.IsAbove || i.IsBelow? "*":"") + "</td>");
                T4ret.Append("<td " + (count4 == 1 ? "style=\"border-top:none;\"" : "") + ">" + i.UseAtWork + "</td>");
                T4ret.Append("<td " + (count4 == 1 ? "style=\"border-top:none;\"" : "") + ">" +i.Result+"d</td>");
                T4ret.Append("</tr>");
                T4ret.Append("");


                countt4 = countt4 + 1;




                

                SumScore = SumScore + (decimal)i.ResultScore;
                SumIdeal = SumIdeal + (decimal)i.IdealScore;
            }

            decimal RawResult = 0.0m;
            decimal AdjustREsult = 0.0m;
            decimal CurrentJobFitScore = 0.0m;

            if (SumScore > 0)
            {
                RawResult = SumScore / SumIdeal;
                AdjustREsult = RawResult + (decimal)0.1;

                CurrentJobFitScore = Math.Round(AdjustREsult * 100, 0);
            }

            ret = ret.Replace("<!--###T4_list###-->", T4ret.ToString());
            ret = ret.Replace("<!--###CurrentJobFitScore###-->", CurrentJobFitScore.ToString());

           
            
            decimal t4width = ((59 * CurrentJobFitScore) / 10) + 2;

            ret = ret.Replace("<!--###CurrentJobFitScore_width###-->", "style=\"width: "+ t4width.ToString("0.00") + "px\"" );
            Model_Rule3 r3 = new Model_Rule3();

            List<Model_Rule3> explaint4 = r3.GetAll();

            Model_Rule3 des = explaint4.Where(o => o.Range_Start <= CurrentJobFitScore && o.Range_End >= CurrentJobFitScore).FirstOrDefault();
            if(des != null)
            {
                ret = ret.Replace("<!--###CurrentJobFitScore_meaning###-->", des.Description);  
            }

            StringBuilder com_left = new StringBuilder();
            StringBuilder com_right = new StringBuilder();
            int countleft = 0;
            //T5 
            List<Model_ReportItemResult> T5list = reportlist.Where(o => o.ResultSectionID == 5).ToList();
            foreach (Model_ReportItemResult i in T5list.Where(o => o.Side_y == 1))
            {



                //string bg = "";
                //switch (i.FitOrNot)
                //{
                //    case 1:
                //        bg = "#eaaf62";
                //        break;
                //    case 2:
                //        bg = "#61d5ea";
                //        break;
                //    case 3:
                //        bg = "#c9cccb";
                //        break;
                //}
                string bg = "bg_blue";

                if (countleft % 2 == 0)
                    bg = "bg_blue_c";

                 com_left.Append("<tr class=\""+ bg + "\">");
                com_left.Append("<td "+ (countleft == 0 ? "style=\"border-top:none;\"" : "") + ">"+ i.ResultItemTitle+"</td>");
                com_left.Append("<td "+ (countleft == 0 ? "style=\"border-top:none;\"" : "") + ">" + (T5list.Where(o => o.Score_y > 0 && o.Frequency_y == 1 && o.ResultItemID == i.ResultItemID).Count() > 0 ? "Y" : "%##%") + (T5list.Where(o => o.Score_c > 0 && o.Frequency_c == 1 && o.ResultItemID == i.ResultItemID).Count() > 0 ? "/C" : "") + "</td>");
                com_left.Append("<td "+ (countleft == 0 ? "style=\"border-top:none;\"" : "") + ">" + (T5list.Where(o => o.Score_y > 0 && o.Frequency_y == 2 && o.ResultItemID == i.ResultItemID).Count() > 0 ? "Y" : "%##%") + (T5list.Where(o => o.Score_c > 0 && o.Frequency_c == 2 && o.ResultItemID == i.ResultItemID).Count() > 0 ? "/C" : "") + "</td>");
                  com_left.Append("<td "+ (countleft == 0 ? "style=\"border-top:none;\"" : "") + ">" + (T5list.Where(o => o.Score_y > 0 && o.Frequency_y == 3 && o.ResultItemID == i.ResultItemID).Count() > 0 ? "Y" : "%##%") + (T5list.Where(o => o.Score_c > 0 && o.Frequency_c == 3 && o.ResultItemID == i.ResultItemID).Count() > 0 ? "/C" : "") + "</td>");
                com_left.Append("</tr>");

                countleft = countleft + 1;

            }


            int countfit = 0;
            int countnotfit = 0;
            int countright = 0;
            foreach (Model_ReportItemResult i in T5list.Where(o => o.Side_y == 2))
            {


                string bg = "";
                switch (i.FitOrNot)
                {
                    case 1:
                        bg = "#eaaf62";
                        countfit = countfit + 1;
                        break;
                    case 2:
                        bg = "#61d5ea";
                        break;
                    case 3:
                        bg = "#c9cccb";
                        countnotfit = countnotfit + 1;
                        break;
                }


                string bg2 = "bg_grey";

                if (countright % 2 == 0)
                    bg2 = "bg_grey_c";

                com_right.Append("<tr class=\""+ bg2 + "\">");
                com_right.Append("<td "+ (countright == 0 ? "style=\"border-top:none;\"" : "") + ">" + (T5list.Where(o => o.Score_y > 0 && o.Frequency_y == 3 && o.ResultItemID == i.ResultItemID).Count() > 0 ? "Y" : "%##%") + (T5list.Where(o => o.Score_c > 0 && o.Frequency_c == 3 && o.ResultItemID == i.ResultItemID).Count() > 0 ? "/C" : "") + "</td>");
                com_right.Append("<td "+ (countright == 0 ? "style=\"border-top:none;\"" : "") + ">"+ (T5list.Where(o => o.Score_y > 0 && o.Frequency_y == 2 && o.ResultItemID == i.ResultItemID).Count() > 0 ? "Y" : "%##%") + (T5list.Where(o => o.Score_c > 0 && o.Frequency_c == 2 && o.ResultItemID == i.ResultItemID).Count() > 0 ? "/C" : "") + "</td>");
                com_right.Append("<td "+ (countright == 0 ? "style=\"border-top:none;\"" : "") + ">" + (T5list.Where(o => o.Score_y > 0 && o.Frequency_y == 1 && o.ResultItemID == i.ResultItemID).Count() > 0 ? "Y" : "%##%") + (T5list.Where(o => o.Score_c > 0 && o.Frequency_c == 1 && o.ResultItemID == i.ResultItemID).Count() > 0 ? "/C" : "") + "</td>");
                com_right.Append("<td "+ (countright == 0 ? "style=\"border-top:none;\"" : "") + ">"+ i.ResultItemTitle + "</td>");
                com_right.Append("</tr>");


                countright = countright + 1;



            }

            ret = ret.Replace("<!--###T5_Left_list###-->", com_left.ToString());
            ret = ret.Replace("<!--###T5_Rigth_list###-->", com_right.ToString());

            decimal RawResult_t5 = 0.0m;
            decimal AdjustREsult_t5 = 0.0m;
            decimal ComFit = 0.0m;

            decimal decFit = (countfit * 100) / 14;
            decimal decNotFit = (countnotfit * 100) / 14;

            RawResult_t5 = decFit - decNotFit;
            if (RawResult_t5 > 0)
                AdjustREsult_t5 = RawResult_t5 + 25;

            ComFit = AdjustREsult_t5;


            decimal t5width = ((59 * ComFit) / 10) + 2;

            ret = ret.Replace("<!--###comfit_width###-->", "style=\"width: " + t5width.ToString("0.00") + "px\"" );

            ret = ret.Replace("<!--###comfit###-->", ComFit.ToString());
          


            Model_Com_Rule3 r5 = new Model_Com_Rule3();
            List<Model_Com_Rule3> r5Explain = r5.GetAll();

            Model_Com_Rule3 des5 = r5Explain.Where(o => o.Range_Start <= ComFit && o.Range_End >= ComFit).FirstOrDefault();
            if (des5 != null)
            {
                ret = ret.Replace("<!--###comfit_meaning###-->", des5.Description);
            }
            //if (SumScore > 0)


            ret = Regex.Replace(ret, "%##%/", "");
            ret = Regex.Replace(ret, "%##%", "");
        }

        return ret;
    }

    public static string GetPaperReport3(Model_Users u)
    {
        string ret = StringUtility.GetPDFTemplate("report3");

        string userfullname = u.FirstName + " " + u.LastName;

        Model_UsersTransaction ts = new Model_UsersTransaction();
        ts = ts.GetTsLatestByUser(u.UserID);


        if (ts != null && u != null)
        {
            Model_ReportItemResult report = new Model_ReportItemResult();
            List<Model_ReportItemResult> reportlist = report.GetItemReportByTransactionIDwithTitle(ts.TransactionID);

            ret = Regex.Replace(ret, "<!--###FullName###-->", userfullname);
            DateTime Date = DateTime.Now;

            ret = Regex.Replace(ret, "<!--###Datetime###-->", Date.ToString("dd-MMM-yyyy"));
            //T1 process

            List<Model_ReportItemResult> T1list = reportlist.Where(o => o.ResultSectionID == 1).ToList();
            var T1Rank = T1list.Select(s => new {
                ResultID = s.ResultID,
                Title = s.ResultItemTitle,
                ResultItemID = s.ResultItemID,
                des_Detail = s.des_Detail,
                des_PeopleTxt = s.des_PeopleTxt,
                des_CultureTxt = s.des_CultureTxt,
                des_Short = s.des_Short,
                des_CompetitionTxt = s.des_CompetitionTxt,
                Ranking = T1list.Count(x => (decimal)x.Score > (decimal)s.Score) + 1,

            });

            int Innovation = T1Rank.FirstOrDefault(o => o.ResultItemID == 1).Ranking;
            int Service = T1Rank.FirstOrDefault(o => o.ResultItemID == 2).Ranking;
            int Cost = T1Rank.FirstOrDefault(o => o.ResultItemID == 3).Ranking;

            if (Innovation == 1 || Innovation == 2)
                ret = ret.Replace("<!--###css_color_1###-->", "item_blue");
            if (Service == 1 || Service == 2)
                ret = ret.Replace("<!--###css_color_2###-->", "item_blue");
            if (Cost == 1 || Cost == 2)
                ret = ret.Replace("<!--###css_color_3###-->", "item_blue");

            ret = ret.Replace("<!--###css_color_1###-->", "");
            ret = ret.Replace("<!--###css_color_2###-->", "");
            ret = ret.Replace("<!--###css_color_3###-->", "");

            ret = ret.Replace("<!--###T1_1###-->", Innovation.ToString());
            ret = ret.Replace("<!--###T1_2###-->", Service.ToString());
            ret = ret.Replace("<!--###T1_3###-->", Cost.ToString());


            string phi = string.Empty;

            int countphi = 1;
            foreach (var i in T1Rank.Where(o => o.Ranking <= 2).OrderBy(o => o.Ranking))
            {
                if (countphi <= 2)
                {


                    phi = phi + "<li>" + countphi + "." + i.Title + "</li>";





                }

                countphi = countphi + 1;
            }


            ret = ret.Replace("<!--###T2_phi_7###-->", phi);
            //T2 process

            List<Model_ReportItemResult> T2list = reportlist.Where(o => o.ResultSectionID == 2).ToList();
            var T2Rank = T2list.Select(s => new {
                ResultID = s.ResultID,
                ResultItemID = s.ResultItemID,
                Title = s.ResultItemTitle,
                des_Detail = s.des_Detail,
                des_PeopleTxt = s.des_PeopleTxt,
                des_CultureTxt = s.des_CultureTxt,
                des_Short = s.des_Short,
                des_CompetitionTxt = s.des_CompetitionTxt,
                Ranking = T2list.Count(x => (decimal)x.Score > (decimal)s.Score) + 1,

            });

            int Inventor = T2Rank.FirstOrDefault(o => o.ResultItemID == 4).Ranking;
            int Promoter = T2Rank.FirstOrDefault(o => o.ResultItemID == 5).Ranking;
            int Optimizer = T2Rank.FirstOrDefault(o => o.ResultItemID == 6).Ranking;
            int Controller = T2Rank.FirstOrDefault(o => o.ResultItemID == 7).Ranking;

            if (Inventor == 1 || Inventor == 2)
                ret = ret.Replace("<!--###css_color_1_1###-->", "item_blue_bg");
            if (Promoter == 1 || Promoter == 2)
                ret = ret.Replace("<!--###css_color_2_2###-->", "item_blue_bg");
            if (Optimizer == 1 || Optimizer == 2)
                ret = ret.Replace("<!--###css_color_3_3###-->", "item_blue_bg");
            if (Controller == 1 || Controller == 2)
                ret = ret.Replace("<!--###css_color_4_4###-->", "item_blue_bg");

            ret = ret.Replace("<!--###css_color_1_1###-->", "");
            ret = ret.Replace("<!--###css_color_2_2###-->", "");
            ret = ret.Replace("<!--###css_color_3_3###-->", "");
            ret = ret.Replace("<!--###css_color_4_4###-->", "");

            ret = ret.Replace("<!--###T2_1###-->", Inventor.ToString());
            ret = ret.Replace("<!--###T2_2###-->", Promoter.ToString());
            ret = ret.Replace("<!--###T2_3###-->", Optimizer.ToString());
            ret = ret.Replace("<!--###T2_4###-->", Controller.ToString());



            string trait = string.Empty;
            StringBuilder traitdetail = new StringBuilder();
            int count = 1;
            foreach (var i in T2Rank.Where(o => o.Ranking <= 2).OrderBy(o => o.Ranking))
            {
                if (count <= 2)
                {
                    trait = trait + "<li>" + count + "." + i.Title + "</li>";



                    traitdetail.Append("<div class=\"desscription-body big\">");
                    traitdetail.Append("<div class=\"desscription-body-block left\">");
                    traitdetail.Append("<div class=\"square-block big bg-blue\">");
                    traitdetail.Append(" " + i.Title + " <br />(1)");
                    traitdetail.Append("</div>");
                    traitdetail.Append("</div>");
                    traitdetail.Append("<div class=\"desscription-body-block right\">");
                    traitdetail.Append(" <p><span>" + i.Title + "</span></p>");
                    traitdetail.Append("<p>");
                    traitdetail.Append(i.des_Detail);
                    traitdetail.Append("</p>");
                    traitdetail.Append("</div>");
                    traitdetail.Append(" </div>");
                }



                count = count + 1;

            }

            ret = ret.Replace("<!--###T2_des_detail###-->", traitdetail.ToString());
            ret = ret.Replace("<!--###T2_trait_7###-->", trait);

            //T3 process

            List<Model_ReportItemResult> T3list = reportlist.Where(o => o.ResultSectionID == 3).ToList();
            var T3Rank = T3list.Select(s => new {
                ResultID = s.ResultID,
                ResultItemID = s.ResultItemID,
                Title = s.ResultItemTitle,
                Isabove = s.IsAbove,
                Isbelow = s.IsBelow,
                des_Detail = s.des_Detail,
                des_PeopleTxt = s.des_PeopleTxt,
                des_CultureTxt = s.des_CultureTxt,
                des_Short = s.des_Short,
                des_CompetitionTxt = s.des_CompetitionTxt,
                Ranking = T3list.Count(x => (decimal)x.Score_new > (decimal)s.Score_new) + 1,

            });


            ret = jobT3(T3Rank, ret, "Creative", 8, 1);
            ret = jobT3(T3Rank, ret, "Strategic", 9, 2);
            ret = jobT3(T3Rank, ret, "Analytical", 10, 3);
            ret = jobT3(T3Rank, ret, "Numerical", 11, 4);
            ret = jobT3(T3Rank, ret, "Prudently", 12, 5);
            ret = jobT3(T3Rank, ret, "Obstacle", 13, 6);
            ret = jobT3(T3Rank, ret, "Words", 14, 7);
            ret = jobT3(T3Rank, ret, "Strong", 15, 8);
            ret = jobT3(T3Rank, ret, "Socialize", 16, 9);
            ret = jobT3(T3Rank, ret, "Knowledge", 17, 10);
            ret = jobT3(T3Rank, ret, "Individualizing", 18, 11);
            ret = jobT3(T3Rank, ret, "Sensation", 19, 12);
            ret = jobT3(T3Rank, ret, "Momentum", 20, 13);
            ret = jobT3(T3Rank, ret, "Working", 21, 14);
            ret = jobT3(T3Rank, ret, "Emotion", 22, 15);
            ret = jobT3(T3Rank, ret, "Time", 23, 16);
            ret = jobT3(T3Rank, ret, "Priority", 24, 17);
            ret = jobT3(T3Rank, ret, "Delegating", 25, 18);

            string top7 = string.Empty;

            int count7 = 1;
            foreach (var i in T3Rank.Where(o => o.Ranking <= 7).OrderBy(o => o.Ranking))
            {
                if (count <= 7)
                {
                    top7 = top7 + "<li>" + count7 + "." + i.Title + (i.Isabove ? "*" : "") + "</li>";



                }






                count7 = count7 + 1;

            }

            ret = ret.Replace("<!--###T3_TOP_7###-->", top7);


            string bottom4 = string.Empty;
            int count4 = 1;

            foreach (var i in T3Rank.Where(o => o.Ranking > 14).OrderBy(o => o.Ranking))
            {


                if (count4 <= 4)
                {
                    bottom4 = bottom4 + "<li>" + count4 + "." + i.Title + (i.Isbelow ? "*" : "") + "</li>";

                }


                count4 = count4 + 1;

            }

            ret = ret.Replace("<!--###T3_Bottom_4###-->", bottom4);


            //T6 process

            string url = HttpContext.Current.Request.Url.Host;

            //HttpContext.Current.Response.Write(url);
            //HttpContext.Current.Response.End();
            ret = ret.Replace("<!--###T6_URL###-->", "http://" +url);
            

            List<Model_ReportItemResult> T6list = reportlist.Where(o => o.ResultSectionID == 6).OrderBy(o => o.JobFitScoreRank).ToList();
            Model_ReportSectionItem ReportSection = new Model_ReportSectionItem();
            List<Model_ReportSectionItem> SectionItem = ReportSection.GetListItemBySectionID(6);

            Model_JobFunctionGroup jg = new Model_JobFunctionGroup();
            List<Model_JobFunctionGroup> jglist = jg.GetAllActive();

            Model_Jobfunction jobf = new Model_Jobfunction();
            List<Model_Jobfunction> joblist = jobf.GetAll();


            Model_JobFunctionListMain joblistmain = new Model_JobFunctionListMain();
            List<Model_JobFunctionListMain> jobmainlist = joblistmain.GetAllActive();

            Model_JobFunctionListMap JobMap = new Model_JobFunctionListMap();
            List<Model_JobFunctionListMap> Jobmaplist = JobMap.GetAllList();


            //get Top priority with 
            int countpri = 1;
            StringBuilder topPri = new StringBuilder();
            StringBuilder secPri = new StringBuilder();

            List<Model_Jobfunction> ArrJobFirst = new List<Model_Jobfunction>();
            List<Model_Jobfunction> ArrJobSecound = new List<Model_Jobfunction>();
            foreach (Model_ReportItemResult item in T6list)
            {
                if(countpri <= 4)
                {
                    string bg = "bg-blue-smooth";
                    if (countpri % 2 == 0)
                        bg = "bg-blue-smooth-thin";

                    string Groupname = string.Empty;
                  string SUCID =  SectionItem.Where(o => o.ResultItemID == item.ResultItemID).Select(o => o.SUCID).FirstOrDefault();
                    if (!String.IsNullOrEmpty(SUCID))
                    {
                        Model_Jobfunction job = joblist.Where(o => o.JFID == int.Parse(SUCID)).FirstOrDefault();
                        if(job != null)
                        {
                            Model_JobFunctionGroup jobgroup = jglist.Where(o => o.JGID == job.JGID).FirstOrDefault();
                            Groupname = "(" + jobgroup.Title + ")";

                            ArrJobFirst.Add(job);
                        }
                        
                    }

                    topPri.Append("<tr><td class=\""+ bg + "\">"+ item.ResultItemTitle+ " " + Groupname + "</td></tr>");


                }

                if(countpri> 4 && countpri <= 8)
                {
                    string bg = "bg-grey-smooth";
                    if (countpri%2 == 0)
                         bg = "bg-grey-smooth-thin";


                    string Groupname = string.Empty;
                    string SUCID = SectionItem.Where(o => o.ResultItemID == item.ResultItemID).Select(o => o.SUCID).FirstOrDefault();
                    if (!String.IsNullOrEmpty(SUCID))
                    {
                        Model_Jobfunction job = joblist.Where(o => o.JFID == int.Parse(SUCID)).FirstOrDefault();
                        if (job != null)
                        {
                            Model_JobFunctionGroup jobgroup = jglist.Where(o => o.JGID == job.JGID).FirstOrDefault();
                            Groupname = "(" + jobgroup.Title + ")";

                            ArrJobSecound.Add(job);
                        }

                    }

                    secPri.Append("<tr><td class=\""+ bg + "\">" + item.ResultItemTitle + " " + Groupname + "</td></tr>");
                }

                countpri = countpri + 1;
            }


            ret = ret.Replace("<!--###T6_First_Pri###-->", topPri.ToString());
            ret = ret.Replace("<!--###T6_Sec_Pri###-->", secPri.ToString());



            string GetKeywordpRelace = StringUtility.GetKeywordpRelace(ret, "<!--###T6_Page_Gen_Start###-->", "<!--###T6_Page_Gen_End###-->");
            StringBuilder First = new StringBuilder();
            StringBuilder Secound = new StringBuilder();
            List<Model_ReportItemResult> T4list = reportlist.Where(o => o.ResultSectionID == 4).OrderByDescending(o => o.Score_new).ToList();


            int countPageDynamic = 10;
            // Generate Page dynamics First 
            string dupF = string.Empty;
            foreach (Model_Jobfunction job in ArrJobFirst)
            {
                dupF = GetKeywordpRelace;
                int countfirst = 1;
                string li = string.Empty;
                string td = string.Empty;
                foreach (Model_JobFunctionListMain main in jobmainlist.Where(o => o.Category == 1))
                {

                    //if(countfirst <= 7)
                    //{


                        Model_ReportItemResult ass = T4list.Where(o => o.ResultItemID == int.Parse(main.Mapping)).FirstOrDefault();

                        Model_JobFunctionListMap mapscore = Jobmaplist.Where(o => o.JFID == job.JFID && o.JFMID == main.JFMID).FirstOrDefault();

                        if(( ass.GT == 1 || ass.GT == 2 ) && (mapscore.Score == 4 || mapscore.Score == 5 || mapscore.Score == 3))
                        {
                            li = li + "<li>" + main.Title + "</li>\r\n";
                        }

                    //}
                   
                    
                    countfirst = countfirst + 1;
                }

                foreach (Model_JobFunctionListMain main in jobmainlist.Where(o=>o.Category == 2))
                {
                    Model_JobFunctionListMap mapscore = Jobmaplist.Where(o => o.JFID == job.JFID && o.JFMID == main.JFMID).FirstOrDefault();

                    if (mapscore.Score == 1 || mapscore.Score == 2)
                    {
                        td = td + "<td style=\"width:50%;\"><img src=\"http://" + url + "/doc_template/images/" + main.Title.ToLower() + ".png\" /><span>"+ main.Title + "</span></td>";
                    }
                }


                dupF = dupF.Replace("<!--###T6_Page_Gen_WorkingTrait###-->", td);
                
                dupF = dupF.Replace("<!--###T6_Page_Gen_Geniuses###-->", li);

                dupF = dupF.Replace("<!--###T6_Page_Gen_Title###-->", "The First Job Priority");
                dupF = dupF.Replace("<!--###T6_Page_Gen_Job_Title###-->", job.Title);
                dupF = dupF.Replace("<!--###T6_Page_Gen_Job_Group###-->", job.GroupName);


                

                // des process 

                dupF = dupF.Replace("<!--###T6_Page_Gen_des###-->", job.DesInto);

                StringBuilder desbulet = new StringBuilder();

                desbulet.Append( string.IsNullOrEmpty(job.Des1)? "" : "<li>"+job.Des1+"</li>");
                desbulet.Append(string.IsNullOrEmpty(job.Des2) ? "" : "<li>" + job.Des2 + "</li>");
                desbulet.Append(string.IsNullOrEmpty(job.Des3) ? "" : "<li>" + job.Des3 + "</li>");
                desbulet.Append(string.IsNullOrEmpty(job.Des4) ? "" : "<li>" + job.Des4 + "</li>");
                desbulet.Append(string.IsNullOrEmpty(job.Des5) ? "" : "<li>" + job.Des5 + "</li>");

                dupF = dupF.Replace("<!--###T6_Page_Gen_des_list###-->", desbulet.ToString());


                dupF = dupF.Replace("<!--###Page_dynamic###-->", countPageDynamic.ToString());
                dupF = dupF.Replace("<!--###Datetime_dynamic###-->", Date.ToString("dd-MMM-yyyy"));

                First.Append(dupF);

                countPageDynamic = countPageDynamic + 1;
            }


            // Generate Page dynamics Secound

           

            string dup = string.Empty;

            foreach (Model_Jobfunction job in ArrJobSecound)
            {
                dup = GetKeywordpRelace;
                int countsec = 1;
                string li = string.Empty;
                string td = string.Empty;
                foreach (Model_JobFunctionListMain main in jobmainlist.Where(o => o.Category == 1))
                {
                   
                    //if (countsec <= 7)
                    //{
                        Model_ReportItemResult ass = T4list.Where(o => o.ResultItemID == int.Parse(main.Mapping)).FirstOrDefault();

                        Model_JobFunctionListMap mapscore = Jobmaplist.Where(o => o.JFID == job.JFID && o.JFMID == main.JFMID).FirstOrDefault();

                        if ((ass.GT == 1 || ass.GT == 2) && (mapscore.Score == 4 || mapscore.Score == 5 || mapscore.Score == 3))
                        {
                            li = li + "<li>"+ main .Title+ "</li>\r\n";
                        }
                    //}
                    
                    countsec = countsec + 1;
                }


                foreach (Model_JobFunctionListMain main in jobmainlist.Where(o => o.Category == 2))
                {
                    Model_JobFunctionListMap mapscore = Jobmaplist.Where(o => o.JFID == job.JFID && o.JFMID == main.JFMID).FirstOrDefault();

                    if (mapscore.Score == 1 || mapscore.Score == 2)
                    {
                        td = td + "<td style=\"width:50%;\"><img src=\"http://" + url + "/doc_template/images/" + main.Title.ToLower() + ".png\" /><span>" + main.Title + "</span></td>";
                    }
                }

                dup = dup.Replace("<!--###T6_Page_Gen_WorkingTrait###-->", td);
                dup = dup.Replace("<!--###T6_Page_Gen_Geniuses###-->", li);

                dup = dup.Replace("<!--###T6_Page_Gen_Title###-->", "The Second Job Priority");
                dup = dup.Replace("<!--###T6_Page_Gen_Job_Title###-->", job.Title);
                dup = dup.Replace("<!--###T6_Page_Gen_Job_Group###-->", job.GroupName);

                // des process 


                dup = dup.Replace("<!--###T6_Page_Gen_des###-->", job.DesInto);

                StringBuilder desbulet2 = new StringBuilder();

                desbulet2.Append(string.IsNullOrEmpty(job.Des1) ? "" : "<li>" + job.Des1 + "</li>");
                desbulet2.Append(string.IsNullOrEmpty(job.Des2) ? "" : "<li>" + job.Des2 + "</li>");
                desbulet2.Append(string.IsNullOrEmpty(job.Des3) ? "" : "<li>" + job.Des3 + "</li>");
                desbulet2.Append(string.IsNullOrEmpty(job.Des4) ? "" : "<li>" + job.Des4 + "</li>");
                desbulet2.Append(string.IsNullOrEmpty(job.Des5) ? "" : "<li>" + job.Des5 + "</li>");

                dup = dup.Replace("<!--###T6_Page_Gen_des_list###-->", desbulet2.ToString());


                dup = dup.Replace("<!--###Page_dynamic###-->", countPageDynamic.ToString());
                dup = dup.Replace("<!--###Datetime_dynamic###-->", Date.ToString("dd-MMM-yyyy"));

                Secound.Append(dup);

                countPageDynamic = countPageDynamic + 1;
            }



            ret = ret.Replace(GetKeywordpRelace, First.ToString() + Secound.ToString());

            ret = ret.Replace("<!--###Page_dynamic+3###-->", (countPageDynamic+2).ToString());
            ret = ret.Replace("<!--###Page_dynamic+4###-->", (countPageDynamic + 3).ToString());
            ret = ret.Replace("<!--###Page_dynamic+5###-->", (countPageDynamic + 4).ToString());

            //countPageDynamic

            ret = ret.Replace("<!--###pageEnd###-->", (countPageDynamic -1).ToString());

            ret = ret.Replace("<!--###Paperend###-->", (countPageDynamic + 2).ToString() + "-" + (countPageDynamic + 4).ToString());
        }

        return ret;
    }

    public static string jobT3(IEnumerable<dynamic> T3Rank, string ret, string title, int intResultItemID, int StepContent ) 
    {
        var data = T3Rank.FirstOrDefault(o => (int)o.ResultItemID == intResultItemID);
        if (data != null)
        {
            ret = ret.Replace("<!--###T3_"+ StepContent + "###-->", data.Ranking.ToString());
            if (data.Ranking <= 7)
                ret = ret.Replace("<!--###T3_css_color_3_" + StepContent + "###-->", "item_blue_bg");


            if (data.Ranking > 14)
                ret = ret.Replace("<!--###T3_css_color_3_" + StepContent + "###-->", "item_red_bg");

            if (data.Ranking <= 7 && data.Isabove)
                ret = ret.Replace("<!--###css_star_3_"+ StepContent + "###-->", "*");

            if (data.Ranking > 14 && data.Isbelow)
                ret = ret.Replace("<!--###css_star_3_"+ StepContent + "###-->", "*");
        }

        return ret;
    }

    /// Assessment
    /// 

    public static int AddAssessment(Model_Assessment ass)
    {
        int assid = ass.AddAssessment(ass);
        if(ass.AssChoice.Count > 0)
        {
            Model_Assessment_Choice assc = new Model_Assessment_Choice();
            assc.AddAssessmentChoice(ass.AssChoice, assid);
        }
        return assid;
    }
    public static bool EditAssessment(Model_Assessment ass)
    {
        bool ret = ass.Update(ass);
        int assid = ass.ASID;
        if (ass.AssChoice.Count > 0 && ret)
        {
            Model_Assessment_Choice assc = new Model_Assessment_Choice();
            assc.AddAssessmentChoice(ass.AssChoice, assid);
        }
        return ass.Update(ass);
    }

    public static Model_Assessment GetAssessmentByID(int ASID)
    {
        Model_Assessment ass = new Model_Assessment();
        return ass.GetAssessmentByID(ASID);
    }


  


    /// <summary>
    /// Assessment Section
    /// </summary>
    /// <param name="ass"></param>
    /// <returns></returns>
    /// 






    public static int AddSection(string s, string c, string i, int pr)
    {
        Model_AsSection a = new Model_AsSection
        {
            Title = s,
            Code = c,
            Intro = i,
            Priority = pr
        };
        return a.InsertSection(a);
    }
    public static bool EditSection(byte id ,string s, string c, string i,bool Status, int pr)
    {
        Model_AsSection a = new Model_AsSection
        {
            SCID = id,
            Title = s,
            Code = c,
            Intro = i,
            Status = Status,
            Priority = pr
        };
        return a.UpdateSection(a);
    }


    public static List<Model_Assessment> GetAssessmentList(Model_Assessment ass)
    {

        return ass.GetAssessment_paging(ass);
    }


    public static  Model_AsSection getSectionByID(int intSectionID)
    {
        Model_AsSection sec = new Model_AsSection();
        return sec.GetSectionByID(intSectionID);
       
    }
    public static List<Model_AsSection> GetSectionList(bool status)
    {
        Model_AsSection sec = new Model_AsSection();
        return sec.GetListSection(status);
    }

    public static List<Model_AsSection> GetSectionList()
    {
        Model_AsSection sec = new Model_AsSection();
        return sec.GetListSection();
    }
    
    ////Sub Section

    public static List<Model_AsSubSection> getSubsectionBySecId(Model_AsSubSection ae)
    {
        return ae.getAllSubSection(ae);
    }


    public static List<Model_AsSubSection2> getSubsectionBySecId2(Model_AsSubSection2 ae)
    {
        return ae.getAllSubSection(ae);
    }

    public static Model_AsSubSection getSubByID(int sUID)
    {
        Model_AsSubSection s = new Model_AsSubSection();

        return s.getSubByID(sUID);
    }
    public static Model_AsSubSection2 getSubByID2(int sUID)
    {
        Model_AsSubSection2 s = new Model_AsSubSection2();

        return s.getSubByID(sUID);
    }

    public static bool EditSubSection(Model_AsSubSection sec)
    {
        return sec.UpdateSub(sec);
    }

    public static bool EditSubSection2(Model_AsSubSection2 sec)
    {
        return sec.UpdateSub(sec);
    }

    public static int AddSubSection(Model_AsSubSection sec)
    {
        return sec.AddnewSub(sec);
    }
    public static int AddSubSection2(Model_AsSubSection2 sec)
    {
        return sec.AddnewSub(sec);
    }




    ///Question Type
    ///

    public static Model_QType GetQtypeID(byte bytId)
    {
        Model_QType q = new Model_QType();
        return q.GetQTypeByID(bytId);
    }
    public static List<Model_QType> GetQTypeAllByStatus(bool Status)
    {
        Model_QType q = new Model_QType();
        return q.GetQTypeAllByStatus(Status);
    }
    public static List<Model_QType> GetQTypeAll()
    {
        Model_QType q = new Model_QType();
        return q.GetQTypeAll();
    }

    public static bool EditQType(Model_QType q)
    {
        return q.UpdateQ(q);
    }

    public static int AddQtype(Model_QType q)
    {
        return q.AddnewQ(q);
    }


    public static bool UpdateIntro(Model_AssesIntro ss)
    {
       return ss.SaveAssIntro(ss);
    }


    public static Model_AssesIntro GetAssIntro()
    {
        Model_AssesIntro ai = new Model_AssesIntro();
        return ai.GetIntro();
    }
}