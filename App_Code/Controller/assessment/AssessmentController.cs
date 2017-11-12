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
                bottom4 = bottom4 + "<li>" + count4 + "." + i.Title + (i.Isbelow ? "*" : "") + "</li>";

                if(count4 <= 4)
                {
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