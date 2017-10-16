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
/// 

public enum T5_Frequency : byte
{
    High = 1,
    Mid = 2,
    Low = 3
  

}

public class Calculation_T5
{
    public int ResultSectionID { get; set; }
    public int TransactionID { get; set; }

   

    public List<Model_UsersAssessment> R_UserAss_F { get; set; }
    public List<Model_UsersAssessment> R_UserAss_G { get; set; }

    public List<Model_ReportSectionItem> ReportSectionItem { get; set; }

  

    //public bool IsDup { get; set; }

  

    public Calculation_T5(int intResultSectionID, int TransactionID)
    {

        this.ResultSectionID = intResultSectionID;
        this.TransactionID = TransactionID;



        Model_ReportSectionItem rss = new Model_ReportSectionItem();

        this.ReportSectionItem = rss.GetListItemBySectionID(this.ResultSectionID);

        this.R_UserAss_F = GetUserAss('f').OrderBy(o => o.Priority).ToList();

        this.R_UserAss_G = GetUserAss('g').OrderBy(o => o.Priority).ToList();

       

    }

    //Get Subsection F and H




    public List<Model_ReportItemResult> Code_SumValueBySubSection()
    {

        //Cdoe F = Section 7;
        List<Model_ReportItemResult> rlist = new List<Model_ReportItemResult>();

        


        foreach (Model_ReportSectionItem item in this.ReportSectionItem)
        {
            string map = item.SUCID;
            //string[] arrGroup = map.Split('#');
            string[] arrmap = map.Split(',');
            decimal score = 0;
            decimal score_y = 0;
            decimal score_c = 0;
            string group = string.Empty;
            byte Side_y = 0;
            byte Side_c = 0;
            byte frequency_c = 0;
            byte frequency_y = 0;
            if (arrmap.Length > 0)
            {
                foreach (string m in arrmap)
                {
                    Model_UsersAssessment F_code = this.R_UserAss_F.Where(o => o.SUCID2 == int.Parse(m)).FirstOrDefault();
                    Model_UsersAssessment G_code = this.R_UserAss_G.Where(o => o.SUCID2 == int.Parse(m)).FirstOrDefault();
                    if (F_code != null)
                    {
                        Side_y = F_code.Side;
                        score_y = F_code.Score;
                        group = F_code.GroupName;

                        if (F_code.Score > 0)
                        {
                            switch (F_code.Score)
                            {
                                case 1: case 2:
                                    frequency_y = (byte)T5_Frequency.Low;
                                    break;
                               
                                case 3:
                                    frequency_y = (byte)T5_Frequency.Mid;
                                    break;
                                case 4:
                                case 5:
                                    frequency_y = (byte)T5_Frequency.High;
                                    break;
                            }
                        }
                    }

                    if(G_code != null)
                    {
                        Side_c = G_code.Side;
                        score_c = G_code.Score;
                        group = G_code.GroupName;

                        if (G_code.Score > 0)
                        {
                            switch (G_code.Score)
                            {
                                case 1:
                                case 2:
                                    frequency_c = (byte)T5_Frequency.Low;
                                    break;

                                case 3:
                                    frequency_c = (byte)T5_Frequency.Mid;
                                    break;
                                case 4:
                                case 5:
                                    frequency_c = (byte)T5_Frequency.High;
                                    break;
                            }
                        }

                    }
                }

                   


                rlist.Add(new Model_ReportItemResult
                {
                    ResultSectionID = this.ResultSectionID,
                    ResultItemID = item.ResultItemID,
                    ResultItemTitle = item.Title,
                    TransactionID = this.TransactionID,
                    Score = score,
                    Score_new = score,
                    Score_y = score_y,
                    Score_c = score_c,
                    T5Group = group,
                    Side_c = Side_c,
                    Side_y = Side_y,
                    Frequency_c = frequency_c,
                    Frequency_y  = frequency_y





                });
            }

            

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

        foreach (Model_ReportItemResult list in rlist.OrderByDescending(o => o.Score_new))
        {

        }
            //int count = 1;
            //foreach (Model_ReportItemResult list in rlist.OrderByDescending(o => o.Score_new))
            //{
            //    if(count < 8)
            //    {
            //        list.GT = 2;

            //        list.IdealScore =  this.IdealScore.Where(s => s.Score == 2).Select(o => o.Value).First();

            //        if (list.IsAbove)
            //        {
            //            list.GT = 1;
            //            list.IdealScore = this.IdealScore.Where(s => s.Score == 1).Select(o => o.Value).First();
            //        }


            //    }





            //    if (count >= 8 && count <= 14)
            //    {
            //        list.GT = 3;
            //        list.IdealScore = this.IdealScore.Where(s => s.Score == 3).Select(o => o.Value).First();
            //    }




            //    if (count > 14)
            //    {
            //        list.GT = 4;
            //        list.IdealScore = this.IdealScore.Where(s => s.Score == 4).Select(o => o.Value).First();

            //        if (list.IsBelow)
            //        {
            //            list.GT = 5;
            //            list.IdealScore = this.IdealScore.Where(s => s.Score == 5).Select(o => o.Value).First();
            //        }

            //    }

            //        count = count + 1;
            //}

            //int count1 = 1;
            //foreach (Model_ReportItemResult list in rlist.OrderByDescending(o => o.Score_new))
            //{
            //    Model_Rule1 r1 = this.RuleScore1.Where(s => s.Score == list.GT).FirstOrDefault();
            //    decimal score = 0.0m;

            //    if(r1 != null)
            //    {
            //        switch ((int)list.RqScore)
            //        {
            //            case 1:
            //                score = r1.CJRRuleScore1;
            //                break;
            //            case 2:
            //                score = r1.CJRRuleScore2;
            //                break;
            //            case 3:
            //                score = r1.CJRRuleScore3;
            //                break;
            //            case 4:
            //                score = r1.CJRRuleScore4;
            //                break;
            //            case 5:
            //                score = r1.CJRRuleScore5;
            //                break;
            //        }
            //    }
            //    list.ResultScore = score;

            //    list.UseAtWork = (int)Math.Round((decimal)(list.RqScore * 100) / 5, 0);

            //    if (count1 < 8)
            //    {
            //        Model_Rule4 r4 = this.RuleScore4.Where(o => o.Range_Start <= list.UseAtWork).Where(o=>o.Range_End >= list.UseAtWork).FirstOrDefault();
            //        if (r4 != null)
            //            list.Result = r4.ValueTop;
            //        //list.Result = this.RuleScore4.Where(o => o.Range_Start <= list.UseAtWork && o.Range_End >= list.UseAtWork).Select(r => r.ValueTop).First();
            //    }

            //    if (count1 >= 8 && count1 <= 14)
            //    {
            //        Model_Rule4 r4 = this.RuleScore4.Where(o => o.Range_Start <= list.UseAtWork).Where(o => o.Range_End >= list.UseAtWork).FirstOrDefault();
            //        if (r4 != null)
            //            list.Result = r4.ValueOther;
            //       // list.Result = this.RuleScore4.Where(o => o.Range_Start <= list.UseAtWork && o.Range_End >= list.UseAtWork).Select(r => r.ValueOther).First();
            //    }

            //    if (count1 > 14)
            //    {
            //        Model_Rule4 r4 = this.RuleScore4.Where(o => o.Range_Start <= list.UseAtWork).Where(o => o.Range_End >= list.UseAtWork).FirstOrDefault();
            //        if (r4 != null)
            //            list.Result = r4.ValueBottom;
            //       // list.Result = this.RuleScore4.Where(o => o.Range_Start <= list.UseAtWork && o.Range_End >= list.UseAtWork).Select(r => r.ValueBottom).First();
            //    }

            //        count1 = count1 + 1;
            //}
            ////RuleScore1


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