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

       

        for(int g =1; g<=14; g++)
        {
            List<Model_ReportItemResult> listGroup = rlist.Where(o => int.Parse(o.T5Group) == g).ToList();

            if(listGroup.Count == 2)
            {
                foreach (Model_ReportItemResult list in listGroup)
                {
                    if(list.Score_y > 0 && list.Score_c > 0)
                    {
                        if(list.Frequency_c == list.Frequency_y)
                        {
                            rlist.Where(o => o.ResultItemID == list.ResultItemID).FirstOrDefault().FitOrNot = 1;
                            list.FitOrNot = 1;
                            break;
                        }
                            

                        if ((list.Frequency_c == 2 || list.Frequency_c == 3 || list.Frequency_c == 0) && (list.Frequency_y == 2 || list.Frequency_y == 3 || list.Frequency_y == 0) && list.Frequency_c != list.Frequency_y)
                        {
                            rlist.Where(o => o.ResultItemID == list.ResultItemID).FirstOrDefault().FitOrNot = 2;
                            list.FitOrNot = 2;
                            break;
                        }
                           

                        if ((list.Frequency_c == 1 || list.Frequency_c == 3 || list.Frequency_c == 0) && (list.Frequency_y == 1 || list.Frequency_y == 3 || list.Frequency_y == 0) && list.Frequency_c != list.Frequency_y)
                        {
                           
                            rlist.Where(o => o.ResultItemID == list.ResultItemID).FirstOrDefault().FitOrNot = 3;
                            list.FitOrNot = 3;
                            break;
                        }
                           
                    }
                    else
                    {
                        if(list.Score_y > 0 || list.Score_c > 0)
                        {
                          rlist.Where(o => o.ResultItemID == list.ResultItemID).FirstOrDefault().FitOrNot = 3;
                            list.FitOrNot = 3;
                            break;
                        }
                        
                    }
                }
            }
        }
           
        foreach(Model_ReportItemResult ll in rlist.Where(o => o.FitOrNot.HasValue))
        {
            var obj = rlist.Where(o => !o.FitOrNot.HasValue && o.T5Group == ll.T5Group).FirstOrDefault();
            if (obj != null)
            {
                obj.FitOrNot = ll.FitOrNot;
            }
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