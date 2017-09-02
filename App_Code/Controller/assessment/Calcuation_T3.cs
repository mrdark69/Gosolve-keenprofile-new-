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
public class Calculation_T3
{
    public int ResultSectionID { get; set; }
    public int TransactionID { get; set; }

    public List<Model_UsersAssessment> R_UserAss_B { get; set; }

    public List<Model_ReportSectionItem> ReportSectionItem { get; set; }

    public decimal SD { get; set; }
    public decimal AVG  { get; set; }

    public decimal Above {

    get
        {
            return this.SD + this.AVG;
        }
    }
    public decimal Below {
        get
        {
            return this.AVG - this.SD;

        }
    }

    public bool IsDup { get; set; }


    public Calculation_T3(int intResultSectionID, int TransactionID)
    {

        this.ResultSectionID = intResultSectionID;
        this.TransactionID = TransactionID;



        //Step retrive f code list of assessment result
        this.R_UserAss_B = GetUserAss('b').OrderBy(o => o.Priority).ToList();

        Model_ReportSectionItem rss = new Model_ReportSectionItem();

        this.ReportSectionItem = rss.GetListItemBySectionID(this.ResultSectionID);

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
            int TASID = 0;
            string strDetail = string.Empty;
            foreach (string m in arrmap)
            {
                List<Model_UsersAssessment> ass = this.R_UserAss_B.Where(o => o.SUCID == int.Parse(m)).ToList();

                TASID = ass.Select(r => r.ASID).First();
                score = score + ass.Take(3).Sum(t => t.Score);
                score = score - ass.Skip(3).Sum(t => t.Score);


                strDetail = ass.Skip(0).Take(1).Select(t => t.Score).FirstOrDefault() +
                    "," + ass.Skip(1).Take(1).Select(t => t.Score).FirstOrDefault() +
                    "," + ass.Skip(2).Take(1).Select(t => t.Score).FirstOrDefault() +
                    "," + ass.Skip(3).Take(1).Select(t => t.Score).FirstOrDefault();
            }

           
            rlist.Add(new Model_ReportItemResult
            {
                ResultSectionID = this.ResultSectionID,
                ResultItemID = item.ResultItemID,
                ResultItemTitle = item.Title,
                TransactionID = this.TransactionID,
                Score = score,
                Score_new  = score,
                TASID = TASID,
                Detail = strDetail
            });


        }


        //cal avg 

        //this.AVG = rlist.Sum(t => t.Score) / rlist.Count();
        this.AVG = (decimal)Math.Round(rlist.Average(o => o.Score), MidpointRounding.AwayFromZero);

        IEnumerable<double> result = rlist.Select(v => (double)v.Score);
        //.CalculateStdDev();
        double  ret = CalculateStdDev(result);
        this.SD = (decimal)Math.Round(ret);

        return ReviewResultDup(rlist).OrderByDescending(o => o.Score).ToList();
    }

    public bool Calnow()
    {

        List<Model_ReportItemResult> fscore = Code_SumValueBySubSection();
        

        return RecordResult(fscore);
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



    public List<Model_ReportItemResult> ReviewResultDup(List<Model_ReportItemResult> rlist)
    {
        //var query = rlist.GroupBy(x => x.Score)
        //     .Where(g => g.Count() > 1)
        //     .Select(y => new { Element = y.Key, Counter = y.Count() })
        //     .ToList();
        List<Model_ReportItemResult> newlist = new List<Model_ReportItemResult>();

        Dictionary<decimal, int> query = rlist.GroupBy(x => x.Score)
              .Where(g => g.Count() > 1)
              .ToDictionary(x => x.Key, y => y.Count());



       List<Model_ReportSectionItem> item =   this.ReportSectionItem;

       List<Model_UsersAssessment> usr = this.R_UserAss_B;

        List<Model_ReportItemResult> dupwinList = new List<Model_ReportItemResult>();

        foreach (KeyValuePair<decimal,int> q in query)
        {

            decimal scoredup = q.Key;
            int totaldup = q.Value;


            List<Model_ReportItemResult> dup = rlist.Where(d => d.Score == q.Key).ToList();

            int[,] arr = new int[totaldup, 4];
            for (int i = 0; i < totaldup; i++)
            {

                string dd = dup[i].Detail;
                string[] arrde = dd.Split(',');
               
                for (int y = 0; y < arrde.Length; y++)
                {
                    arr[i, y] = int.Parse(arrde[y]);
                }
            }

            int intdexdup = 0;
            int intdex = 0;

            for (int i = 0; i < totaldup; i++)
            {

                for (int ii = 0; i < totaldup; ii++)
                {
                   if( arr[i, 3] != arr[ii, 3] )
                   {
                        intdexdup = arr[i, 3] < arr[ii, 3] ? i : ii;
                        intdex = 3;
                        break;
                   }
                    if (arr[i, 0] != arr[ii, 0])
                    {
                        intdexdup = arr[i, 0] < arr[ii, 0] ? i : ii;
                        intdex = 0;
                        break;
                    }
                    if (arr[i, 1] != arr[ii, 1])
                    {
                        intdexdup = arr[i, 1] < arr[ii, 1] ? i : ii;
                        intdex = 1;
                        break;
                    }
                    if (arr[i, 2] != arr[ii, 2])
                    {
                        intdexdup = arr[i, 2] < arr[ii, 2] ? i : ii;
                        intdex = 2;
                        break;
                    }
                }
                   
            }

            Model_ReportItemResult dupwin = dup[intdexdup];
            dupwinList.Add(dupwin);
        }



        foreach(Model_ReportItemResult i in rlist)
        {
            newlist.Add(new Model_ReportItemResult
            {
                ResultSectionID = this.ResultSectionID,
                ResultItemID = i.ResultItemID,
                ResultItemTitle = i.ResultItemTitle,
                TransactionID = this.TransactionID,
                Score = i.Score,
                Score_new = i.Score,
                TASID = i.TASID,
                Detail = i.Detail
            });
        }
        //if (query.Count > 0)
        //{
        //    this.IsDup = true;
        //    return fscore;
        //}
        //else
        //{
        //    return fscore;
        //}

        return newlist;
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

}