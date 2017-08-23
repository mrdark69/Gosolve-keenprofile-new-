using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDatatableApp;
using System.IO;
using System.Text;
using System.Configuration;
using System.Web.SessionState;
/// <summary>

/// <summary>
/// Summary description for AssessmentController
/// </summary>
public class Calculation_T2
{
    public int ResultSectionID { get; set; }
    public int TransactionID { get; set; }

    public List<Model_UsersAssessment> R_UserAss_D { get; set; }

    public List<Model_UsersAssessment> R_UserAss_SumGroup_D { get; set; }

    public List<Model_UsersAssessment> R_UserAss_SumGroup_D_RealScore { get; set; }

    public List<Model_UsersAssessment> R_UserAss_E { get; set; }
    public List<Model_UsersAssChoice> R_UserAssChoice_E { get; set; }

    public Calculation_T2(int intResultSectionID, int TransactionID)
    {

        this.ResultSectionID = intResultSectionID;
        this.TransactionID = TransactionID;



        //Step retrive f code list of assessment result
        this.R_UserAss_D = GetUserAss('d');

        this.R_UserAss_E = GetUserAss('e');

        //Step retrive H code list of assessment choice result
        this.R_UserAssChoice_E = GetUserAssChoice('e');



        this.R_UserAss_SumGroup_D = this.R_UserAss_D
         /* Group the list by the element at position 0 in each item */
         .GroupBy(o => new { o.SUCID, o.SubSectionTitle })
         /* Project the created grouping into a new object[]: */
         .Select(i => new Model_UsersAssessment
         {
             SUCID = i.Key.SUCID,

             SubSectionTitle = i.Key.SubSectionTitle,
             Score = i.Sum(x => (int)x.Score)
         })
         .OrderByDescending(r => r.Score).ToList();

        List<Model_UsersAssessment> real = new List<Model_UsersAssessment>();

        int topScore = this.R_UserAss_SumGroup_D.Count();
        foreach (Model_UsersAssessment group in this.R_UserAss_SumGroup_D)
        {
            real.Add(new Model_UsersAssessment {
                SUCID = group.SUCID,

                SubSectionTitle = group.SubSectionTitle,
                Score = topScore
            });

            topScore = topScore - 1;
        }

        this.R_UserAss_SumGroup_D_RealScore = real;

    }

    //Get Subsection F and H




    public List<Model_ReportItemResult> Code_SumValueBySubSection()
    {

        //Cdoe F = Section 7;
        List<Model_ReportItemResult> rlist = new List<Model_ReportItemResult>();

        Model_ReportSectionItem rss = new Model_ReportSectionItem();

        List<Model_ReportSectionItem> rsslist = rss.GetListItemBySectionID(this.ResultSectionID);




        foreach (Model_ReportSectionItem item in rsslist)
        {
            string map = item.SUCID;
            string[] arrmap = map.Split(',');
            decimal score = 0;
            foreach (string m in arrmap)
            {
                score = score + this.R_UserAss_D.Where(o => o.SUCID == int.Parse(m)).Sum(t => t.Score);

            }

            foreach (string m in arrmap)
            {
                score = score + this.R_UserAssChoice_E.Where(o => o.SUCID == int.Parse(m)).Sum(t => t.Score);

            }
            rlist.Add(new Model_ReportItemResult
            {
                ResultSectionID = this.ResultSectionID,
                ResultItemID = item.ResultItemID,
                ResultItemTitle = item.Title,
                TransactionID = this.TransactionID,
                Score = score
            });


        }


        return rlist;
    }

    public bool Calnow()
    {


        List<Model_ReportItemResult> fscore = Code_SumValueBySubSection();

        return true;
    }

    public List<Model_UsersAssessment> GetUserAss(char code)
    {
        Model_UsersAssessment uss = new Model_UsersAssessment();
        List<Model_UsersAssessment> ussList = uss.GetUserAssessmentByTsID(this.TransactionID).Where(o => o.Code.Trim().ToLower()[0] == code).ToList();

        return ussList;
    }

    public List<Model_UsersAssChoice> GetUserAssChoice(char code)
    {
        Model_UsersAssChoice uss = new Model_UsersAssChoice();
        List<Model_UsersAssChoice> ussList = uss.GetUserAssessmentChoiceByTransactionID(this.TransactionID).Where(o => o.Code.Trim().ToLower()[0] == code).ToList();

        return ussList;
    }


}