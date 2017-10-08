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
public class Calculation_T4
{
    public int ResultSectionID { get; set; }
    public int TransactionID { get; set; }

    public List<Model_Rule2> IdealScore { get; set; }

    public List<Model_ReportItemResult> ReportResultT3 { get; set; }

   

    public List<Model_ReportSectionItem> ReportSectionItem { get; set; }

  

    //public bool IsDup { get; set; }

  

    public Calculation_T4(int intResultSectionID, int TransactionID)
    {

        this.ResultSectionID = intResultSectionID;
        this.TransactionID = TransactionID;



        Model_ReportSectionItem rss = new Model_ReportSectionItem();

        this.ReportSectionItem = rss.GetListItemBySectionID(this.ResultSectionID);


        Model_ReportItemResult ret = new Model_ReportItemResult();
        this.ReportResultT3 = ret.GetItemReportByTransactionID(this.TransactionID,3);

        Model_Rule2 ideal = new Model_Rule2();
        this.IdealScore = ideal.GetAll();

    }

    //Get Subsection F and H




    public List<Model_ReportItemResult> Code_SumValueBySubSection()
    {

        //Cdoe F = Section 7;
        List<Model_ReportItemResult> rlist = new List<Model_ReportItemResult>();

        


        foreach (Model_ReportSectionItem item in this.ReportSectionItem)
        {
            string map = item.SUCID;
            string[] arrmap = map.Split(',');
            decimal score = 0;
            //int TASID = 0;
            string strDetail = string.Empty;
            bool bolAbove = false;
            bool bolBelow = false;
            //int? UserRank = null;
            foreach (string m in arrmap)
            {
                List<Model_ReportItemResult> ass = this.ReportResultT3.Where(o => o.ResultItemID == int.Parse(m)).ToList();

                //Get Record from assement group 1 for case Extra duplicate
              
                score = (decimal)ass.Select(c => c.Score_new).First();
                bolAbove = (bool)ass.Select(c => c.IsAbove).First();
                bolBelow = (bool)ass.Select(c => c.IsBelow).First();

            }


            rlist.Add(new Model_ReportItemResult
            {
                ResultSectionID = this.ResultSectionID,
                ResultItemID = item.ResultItemID,
                ResultItemTitle = item.Title,
                TransactionID = this.TransactionID,
                Score = score,
                Score_new = score,
                IsAbove = bolAbove,
                IsBelow = bolBelow


            });


        }

        
        

        List<Model_ReportItemResult> ListReview = ReviewResult(rlist);

        

        return ListReview.OrderByDescending(o => o.Score_new).ToList();
    }

    public bool Calnow()
    {

        List<Model_ReportItemResult> fscore = Code_SumValueBySubSection();
        

        return RecordResult(fscore);
    }


    public List<Model_ReportItemResult> ReviewResult(List<Model_ReportItemResult> rlist)
    {

        int count = 1;
        foreach (Model_ReportItemResult list in rlist.OrderByDescending(o => o.Score_new))
        {
            if(count < 8)
            {
                list.GT = 2;

                list.IdealScore =  this.IdealScore.Where(s => s.Score == 2).Select(o => o.Value).First();

                if (list.IsAbove)
                {
                    list.GT = 1;
                    list.IdealScore = this.IdealScore.Where(s => s.Score == 1).Select(o => o.Value).First();
                }
                   
              
            }
            




            if (count >= 8 && count <= 14)
            {
                list.GT = 3;
                list.IdealScore = this.IdealScore.Where(s => s.Score == 3).Select(o => o.Value).First();
            }
               



            if (count > 14)
            {
                list.GT = 4;
                list.IdealScore = this.IdealScore.Where(s => s.Score == 4).Select(o => o.Value).First();

                if (list.IsBelow)
                {
                    list.GT = 5;
                    list.IdealScore = this.IdealScore.Where(s => s.Score == 5).Select(o => o.Value).First();
                }
                    
            }

                count = count + 1;
        }
       


        return rlist;
    }
   

    
    public bool RecordResult(List<Model_ReportItemResult> result)
    {
        bool ret = false;
        if (result.Count > 0)
        {
            Model_ReportItemResult me = new Model_ReportItemResult();
            ret = me.InsertReportItemResultBulk(result);
        }

        return ret;
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

    private double CalculateStdDev(IEnumerable<double> values)
    {
        double ret = 0;
        if (values.Count() > 0)
        {
            //Compute the Average      
            double avg = values.Average();
            //Perform the Sum of (value-avg)_2_2      
            double sum = values.Sum(d => Math.Pow(d - avg, 2));
            //Put it all together      
            ret = Math.Sqrt((sum) / (values.Count() - 1));
        }
        return ret;
    }




    //if(!IsDup)
    //{
    //    Dictionary<decimal, int> GroupDup = ListReview.GroupBy(x => (decimal)x.Score_new)
    //    .Where(g => g.Count() > 1)
    //    .ToDictionary(x => x.Key, y => y.Count());

    //    foreach (KeyValuePair<decimal, int> q in GroupDup)
    //    {
    //        List<Model_ReportItemResult> dupfocus = ListReview.Where(d => d.Score == q.Key).OrderByDescending(r => r.Score).ToList();
    //        decimal startfactor = 0.99M;
    //        decimal? factor = dupfocus.OrderBy(o=>o.Score_new).FirstOrDefault(o => o.Factor.HasValue).Factor;
    //        if (factor.HasValue)
    //        {
    //            startfactor = (decimal)factor - (decimal)0.01;

    //            foreach(Model_ReportItemResult item in dupfocus.Where(o=>o.IsDup).OrderBy(o=>o.UserRank))
    //            {
    //                var obj = ListReview.FirstOrDefault(o => o.ResultItemID == item.ResultItemID);
    //                if (obj != null) obj.Score_new = obj.Score_new + startfactor;

    //                startfactor = startfactor - (decimal)0.01;
    //            }
    //        }
    //        else
    //        {
    //            foreach (Model_ReportItemResult item in dupfocus.Where(o => o.IsDup).OrderBy(o => o.UserRank))
    //            {
    //                var obj = ListReview.FirstOrDefault(o => o.ResultItemID == item.ResultItemID);
    //                if (obj != null) obj.Score_new = obj.Score_new + startfactor;

    //                startfactor = startfactor - (decimal)0.01;
    //            }
    //        }

    //    }
    //}
}