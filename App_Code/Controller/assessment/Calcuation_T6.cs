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



public class Calculation_T6
{
    public int ResultSectionID { get; set; }
    public int TransactionID { get; set; }

   

    public List<Model_ReportSectionItem> ReportSectionItem { get; set; }

    public List<Model_ReportItemResult> ReportResultT4 { get; set; }
    public List<Model_ReportItemResult> ReportResultT2 { get; set; }

    public List<Model_Jobfunction> JobFunctionList { get; set; }

    public List<Model_JobFunctionListMain> JobFunctionListMain { get; set; }

    public List<Model_JobFunctionListMap> JobFunctionListMap { get; set; }

    public List<Model_JFR1> Rule1 { get; set; }
    public List<Model_JFR2> Rule2 { get; set; }
    public List<Model_JFR3> Rule3 { get; set; }
    public List<Model_JFR4> Rule4 { get; set; }

    //public bool IsDup { get; set; }



    public Calculation_T6(int intResultSectionID, int TransactionID)
    {

        this.ResultSectionID = intResultSectionID;
        this.TransactionID = TransactionID;



        Model_ReportSectionItem rss = new Model_ReportSectionItem();

        this.ReportSectionItem = rss.GetListItemBySectionID(this.ResultSectionID);

      

        Model_ReportItemResult ret = new Model_ReportItemResult();
        this.ReportResultT4 = ret.GetItemReportByTransactionID(this.TransactionID, 4);
        this.ReportResultT2 = ret.GetItemReportByTransactionID(this.TransactionID, 2);

        Model_Jobfunction cj = new Model_Jobfunction();
        this.JobFunctionList = cj.GetAll();

        Model_JobFunctionListMain cjm = new Model_JobFunctionListMain();
        this.JobFunctionListMain = cjm.GetAllActive();

        Model_JobFunctionListMap cjmap = new Model_JobFunctionListMap();
        this.JobFunctionListMap = cjmap.GetAllList();

        Model_JFR1 r1 = new Model_JFR1();
        this.Rule1 = r1.GetAll();
        Model_JFR2 r2 = new Model_JFR2();
        this.Rule2 = r2.GetAll();
        Model_JFR3 r3 = new Model_JFR3();
        this.Rule3 = r3.GetAll();
        Model_JFR4 r4 = new Model_JFR4();
        this.Rule4 = r4.GetAll();
    }

    //Get Subsection F and H




    public List<Model_ReportItemResult> Code_SumValueBySubSection()
    {

        //Cdoe F = Section 7;
        List<Model_ReportItemResult> rlist = new List<Model_ReportItemResult>();


       var T2Ranking = this.ReportResultT2.Select(s => new {
            ResultID = s.ResultID,
            ResultItemID = s.ResultItemID,
            Ranking = this.ReportResultT2.Count(x => (decimal)x.Score_new > (decimal)s.Score_new) + 1,
            Name = s.ResultItemTitle,
            Score = s.Score_new
        });

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

            decimal SumGeniuses = 0.0m;
            decimal SumTrait = 0.0m;
            decimal ReqSupGeniuses = 0.0m;
            decimal ReqSupBottom = 0.0m;

            int CountSup = this.ReportResultT4.Where(o => o.GT == 1).Count();
            int CountBottom = this.ReportResultT4.Where(o => o.GT == 5).Count();

            if (arrmap.Length > 0)
            {
                foreach (string m in arrmap)
                {
                    List<Model_Jobfunction> cj = this.JobFunctionList.Where(o => o.JFID == int.Parse(m)).ToList();


                    if (cj.Count > 0)
                    {
                        Model_Jobfunction cJob = cj.FirstOrDefault();
                        foreach (Model_JobFunctionListMain main in this.JobFunctionListMain.Where(o => o.Category == 1))
                        {
                            Model_ReportItemResult ass = this.ReportResultT4.Where(o => o.ResultItemID == int.Parse(main.Mapping)).FirstOrDefault();

                            Model_JobFunctionListMap mapscore = this.JobFunctionListMap.Where(o => o.JFID == cJob.JFID && o.JFMID == main.JFMID).FirstOrDefault();

                            if(mapscore != null && ass != null)
                            {
                                Model_JFR1 rule1ret = this.Rule1.Where(o => o.Score == (int)ass.GT).FirstOrDefault();
                                SumGeniuses += (decimal)rule1ret.GetType().GetProperty("CJRRuleScore" + mapscore.Score).GetValue(rule1ret);


                                foreach(Model_JFR3 r3 in this.Rule3.Where(o => o.Cat == 1))
                                {

                                    if (CalKey(r3.Condition1, (int)ass.GT) && CalKey(r3.Condition2, (int)mapscore.Score))
                                    {
                                        ReqSupGeniuses += r3.Score;
                                        //if (r3.Score == 1)
                                        //    CountSup = CountSup + 1;
                                        break;
                                    }
                                   
                                }
                                foreach (Model_JFR3 r3 in this.Rule3.Where(o => o.Cat == 2))
                                {

                                    if (CalKey(r3.Condition1, (int)ass.GT) && CalKey(r3.Condition2, (int)mapscore.Score))
                                    {
                                        ReqSupBottom += r3.Score;
                                        //if (r3.Score == 5)
                                        //    CountBottom = CountBottom + 1;
                                        break;
                                    }

                                 

                                }
                                //Model_JFR3 rule2ret = this.Rule3.Where(o => ).FirstOrDefault();
                                //ReqSupGeniuses += (decimal)rule2ret.GetType().GetProperty("CJRRuleScore" + mapscore.Score).GetValue(rule1ret);

                                //Model_JFR3 rule3ret = this.Rule3.Where(o => o.Score == (int)ass.GT && o.Cat == 2).FirstOrDefault();
                            }
                          
                        }

                        foreach (Model_JobFunctionListMain main in this.JobFunctionListMain.Where(o => o.Category == 2))
                        {
                            var ass = T2Ranking.Where(o => o.ResultItemID == int.Parse(main.Mapping)).FirstOrDefault();

                            Model_JobFunctionListMap mapscore = this.JobFunctionListMap.Where(o => o.JFID == cJob.JFID && o.JFMID == main.JFMID).FirstOrDefault();

                            if (mapscore != null && ass != null)
                            {
                                Model_JFR2 rule1ret = this.Rule2.Where(o => o.Score == (int)ass.Ranking).FirstOrDefault();
                                SumTrait += (decimal)rule1ret.GetType().GetProperty("CJRRuleScore" + mapscore.Score).GetValue(rule1ret);
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
                    Frequency_y  = frequency_y,
                    SumGeniuses = SumGeniuses,
                    SumTrait = SumTrait,
                    ReqSupBottom= ReqSupBottom,
                    ReqSupGeniuses= ReqSupGeniuses,
                    CountBottom= CountBottom,
                    CountSup= CountSup






                });
            }

            

        }

        
        

        List<Model_ReportItemResult> ListReview = ReviewResult(rlist);

        

        return ListReview.OrderByDescending(o => o.Score_new).ToList();
    }

    public bool CalKey(string Key, int value)
    {
        bool ret = false;
        if (Key != "*")
        {
            string[] strsplit = Key.Split('-');
            if (strsplit.Length > 1)
            {
                if( int.Parse(strsplit[0]) <= value && int.Parse(strsplit[1]) >= value)
                {
                    ret = true;
                }
            }
            else
            {
                if (int.Parse(strsplit[0]) == value)
                    ret = true;
            }
        }
        else
            return true;
        return ret;
    }

    public bool Calnow()
    {

        List<Model_ReportItemResult> fscore = Code_SumValueBySubSection();
        

        return RecordResult(fscore);
    }


    public List<Model_ReportItemResult> ReviewResult(List<Model_ReportItemResult> rlist)
    {

        foreach(Model_ReportItemResult item in rlist)
        {
            if (item.CountSup > 0)
            {
                item.ReqSupGeniuses = Math.Round((decimal)(item.ReqSupGeniuses / item.CountSup) * 100, 0);
            } else
                item.ReqSupGeniuses = 0;


            if (item.CountBottom > 0)
            {
                item.ReqSupBottom = Math.Round((decimal)(item.ReqSupBottom / item.CountBottom) * 100, 0);
            }
            else
                item.ReqSupBottom = 0;


            item.MatchingScore = item.SumGeniuses + item.SumTrait;

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