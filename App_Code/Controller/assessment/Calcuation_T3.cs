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

    //public bool IsDup { get; set; }

    public bool IsDupExtra { get; set; }

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
            int? UserRank = null;
            foreach (string m in arrmap)
            {
                List<Model_UsersAssessment> ass = this.R_UserAss_B.Where(o => o.SUCID == int.Parse(m)).ToList();

                //Get Record from assement group 1 for case Extra duplicate
                TASID = ass.Select(r => r.TASID).First();
                UserRank = ass.Select(r => r.ScoreUserRank).First();
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
                Detail = strDetail,
                UserRank = UserRank

            });


        }


        //cal avg 

        //this.AVG = rlist.Sum(t => t.Score) / rlist.Count();
        this.AVG = (decimal)Math.Round(rlist.Average(o => o.Score), MidpointRounding.AwayFromZero);

        IEnumerable<double> result = rlist.Select(v => (double)v.Score);
        //.CalculateStdDev();
        double  ret = CalculateStdDev(result);
        this.SD = (decimal)Math.Round(ret);


        //Supream logic
        foreach (Model_ReportItemResult i in rlist)
        {
            if(i.Score > this.Above)
            {
                var obj = rlist.FirstOrDefault(o => o.ResultItemID == i.ResultItemID);
                if (obj != null) obj.IsAbove = true;
            }

            if(i.Score < this.Below)
            {
                var obj = rlist.FirstOrDefault(o => o.ResultItemID == i.ResultItemID);
                if (obj != null) obj.IsBelow = true;
            }
            
        }



        List<Model_ReportItemResult> ListReview = ReviewResultDup_newV2(rlist);


        //check UserRank
        List<Model_ReportItemResult> listdup = ListReview.Where(o => o.IsDup).ToList();

        foreach (Model_ReportItemResult dup in listdup)
        {
            if (dup.UserRank.HasValue)
            {
                int countDup = listdup.Where(o => o.Score == dup.Score && o.IsDup).Count();
                //check ranksore from user extra rank have not more than total dup
                //int rank = (int)(dup.UserRank > countDup ? countDup : dup.UserRank);

                //int intUserRank = (rank + (int)dup.AutoRank3);

                int intUserRank = (int)(dup.UserRank > countDup ? countDup : dup.UserRank);
                decimal plus = (decimal)((decimal)0.99 - ((decimal)0.01 * intUserRank));

                var obj = ListReview.FirstOrDefault(o => o.ResultItemID == dup.ResultItemID);
                if (obj != null)
                {
                    //decimal plus = (decimal)(1 - ((decimal)0.01 * i.AutoRank4));
                    obj.Factor = plus;
                    obj.Score_new = obj.Score + plus;
                    //obj.IsDup = false;
                }

                //plus = plus - (decimal)0.01;
            }
        }




        //check IsdupExtra
        Dictionary<decimal, int> GroupDupRecheck = ListReview.GroupBy(x => (decimal)x.Score_new)
            .Where(g => g.Count() > 1)
            .ToDictionary(x => x.Key, y => y.Count());

        if (GroupDupRecheck.Count > 0)
            this.IsDupExtra = true;
        else
            this.IsDupExtra = false;

        return ListReview.OrderByDescending(o => o.Score_new).ToList();
    }

    public bool Calnow()
    {

        List<Model_ReportItemResult> fscore = Code_SumValueBySubSection();
        

        return RecordResult(fscore);
    }


   
    public List<Model_ReportItemResult> ReviewResultDup_newV2(List<Model_ReportItemResult> rlist)
    {


        //Group Dup list
        Dictionary<decimal, int> GroupDup = rlist.GroupBy(x => (decimal)x.Score_new)
             .Where(g => g.Count() > 1)
             .ToDictionary(x => x.Key, y => y.Count());


        foreach(KeyValuePair<decimal,int> dup in GroupDup)
        {
            List<Model_ReportItemResult> ListDup = rlist.Where(o => o.Score_new == dup.Key).ToList();
            int MaxRank = ListDup.Count;

            int min = int.Parse(ListDup.Min(r => r.G4));


           

            //update item flag duplicate
            foreach (Model_ReportItemResult i in ListDup)
            {
                var obj = rlist.FirstOrDefault(o => o.ResultItemID == i.ResultItemID);
                if (obj != null) obj.IsDup = true;

                var obj2 = ListDup.FirstOrDefault(o => o.ResultItemID == i.ResultItemID);
                if (obj2 != null) obj2.IsDup = true;
            }


            var rankedDataG4 = ListDup.Where(o=>o.IsDup).Select(s => new {
                ResultID = s.ResultID,
                ResultItemID = s.ResultItemID,
                Ranking = ListDup.Count(x => int.Parse(x.G4) < int.Parse(s.G4)) + 1,
                Name = s.ResultItemTitle,
                Score = s.Score_new
            });


            var rankedDataG1 = ListDup.Where(o => o.IsDup).Select(s => new {
                ResultID = s.ResultID,
                ResultItemID = s.ResultItemID,
                Ranking = ListDup.Count(x => int.Parse(x.G1) > int.Parse(s.G1)) + 1,
                Name = s.ResultItemTitle,
                Score = s.Score_new
            });

            var rankedDataG2 = ListDup.Where(o => o.IsDup).Select(s => new {
                ResultID = s.ResultID,
                ResultItemID = s.ResultItemID,
                Ranking = ListDup.Count(x => int.Parse(x.G2) > int.Parse(s.G2)) + 1,
                Name = s.ResultItemTitle,
                Score = s.Score_new
            });

            var rankedDataG3 = ListDup.Where(o => o.IsDup).Select(s => new {
                ResultID = s.ResultID,
                ResultItemID = s.ResultItemID,
                Ranking = ListDup.Count(x => int.Parse(x.G3) > int.Parse(s.G3)) + 1,
                Name = s.ResultItemTitle,
                Score = s.Score_new
            });

            foreach (var g4 in rankedDataG4.OrderBy(o=>o.Ranking))
            {
                var obj = rlist.FirstOrDefault(o => o.ResultItemID == g4.ResultItemID);
                if (obj != null) obj.AutoRank4 = g4.Ranking;

                var obj2 = ListDup.FirstOrDefault(o => o.ResultItemID == g4.ResultItemID);
                if (obj2 != null) obj.AutoRank4 = g4.Ranking;
            }
            foreach (var g1 in rankedDataG1.OrderBy(o => o.Ranking))
            {
                var obj = rlist.FirstOrDefault(o => o.ResultItemID == g1.ResultItemID);
                if (obj != null) obj.AutoRank1 = g1.Ranking;

                var obj2 = ListDup.FirstOrDefault(o => o.ResultItemID == g1.ResultItemID);
                if (obj2 != null) obj.AutoRank1 = g1.Ranking;
            }
            foreach (var g2 in rankedDataG2.OrderBy(o => o.Ranking))
            {
                var obj = rlist.FirstOrDefault(o => o.ResultItemID == g2.ResultItemID);
                if (obj != null) obj.AutoRank2 = g2.Ranking;

                var obj2 = ListDup.FirstOrDefault(o => o.ResultItemID == g2.ResultItemID);
                if (obj2 != null) obj.AutoRank2 = g2.Ranking;
            }
            foreach (var g3 in rankedDataG3.OrderBy(o => o.Ranking))
            {
                var obj = rlist.FirstOrDefault(o => o.ResultItemID == g3.ResultItemID);
                if (obj != null) obj.AutoRank3 = g3.Ranking;

                var obj2 = ListDup.FirstOrDefault(o => o.ResultItemID == g3.ResultItemID);
                if (obj2 != null) obj.AutoRank3 = g3.Ranking;
            }


            foreach (Model_ReportItemResult i in ListDup.Where(o => o.IsDup).OrderBy(o=>o.AutoRank4))
            {
              
                if (ListDup.Where(o=>o.AutoRank4 ==i.AutoRank4).Count() == 1)
                {
                    var obj = rlist.FirstOrDefault(o => o.ResultItemID == i.ResultItemID);
                    if (obj != null) {
                        decimal plus = (decimal)(1 - ((decimal)0.01 * i.AutoRank4));
                        obj.Factor = plus;
                        obj.Score_new = obj.Score + plus;
                        obj.IsDup = false;
                    }

                    var obj2 = ListDup.FirstOrDefault(o => o.ResultItemID == i.ResultItemID);
                    if (obj2 != null) obj2.IsDup = false;

                }
               
                
            }

            foreach (Model_ReportItemResult i in ListDup.Where(o => o.IsDup).OrderBy(o => o.AutoRank1))
            {
                if (ListDup.Where(o => o.AutoRank1 == i.AutoRank1).Count() == 1)
                {
                    var obj = rlist.FirstOrDefault(o => o.ResultItemID == i.ResultItemID);
                    if (obj != null)
                    {
                        decimal plus = (decimal)(1 - ((decimal)0.01 * (i.AutoRank1 + i.AutoRank4)));
                        obj.Factor = plus;
                        obj.Score_new = obj.Score + plus;
                        obj.IsDup = false;
                    }

                    var obj2 = ListDup.FirstOrDefault(o => o.ResultItemID == i.ResultItemID);
                    if (obj2 != null) obj2.IsDup = false;

                }
                

            }


            foreach (Model_ReportItemResult i in ListDup.Where(o => o.IsDup).OrderBy(o => o.AutoRank2))
            {
                if (ListDup.Where(o => o.AutoRank2 == i.AutoRank2).Count() == 1)
                {
                    var obj = rlist.FirstOrDefault(o => o.ResultItemID == i.ResultItemID);
                    if (obj != null)
                    {
                        decimal plus = (decimal)(1 - ((decimal)0.01 * (i.AutoRank2 + i.AutoRank1)));
                        obj.Factor = plus;
                        obj.Score_new = obj.Score + plus;
                        obj.IsDup = false;
                    }

                    var obj2 = ListDup.FirstOrDefault(o => o.ResultItemID == i.ResultItemID);
                    if (obj2 != null) obj2.IsDup = false;

                }
                
            }


            foreach (Model_ReportItemResult i in ListDup.Where(o => o.IsDup).OrderBy(o => o.AutoRank3))
            {
                if (ListDup.Where(o => o.AutoRank3 == i.AutoRank3).Count() == 1)
                {
                    var obj = rlist.FirstOrDefault(o => o.ResultItemID == i.ResultItemID);
                    if (obj != null)
                    {
                        decimal plus = (decimal)(1 - ((decimal)0.01 * (i.AutoRank3 + i.AutoRank2)));
                        obj.Factor = plus;
                        obj.Score_new = obj.Score + plus;
                        obj.IsDup = false;
                    }

                    var obj2 = ListDup.FirstOrDefault(o => o.ResultItemID == i.ResultItemID);
                    if (obj2 != null) obj2.IsDup = false;

                }
                
            }


            


        }



        return rlist;
    }
    public List<Model_ReportItemResult> ReviewResultDup_new(List<Model_ReportItemResult> rlist)
    {


        //Group Dup list
        Dictionary<decimal, int> GroupDup = rlist.GroupBy(x => (decimal)x.Score_new)
             .Where(g => g.Count() > 1)
             .ToDictionary(x => x.Key, y => y.Count());

    

        //int GroupDupCount = GroupDup.Count;
       // int factorcheck = rlist.Where(o => !o.Factor.HasValue).ToList().Count();
        if (GroupDup.Count > 0 )
        {
           
           // List<Model_ReportItemResult> newlist_raw = rlist;

            int GroupDupCount = GroupDup.Count;
          
            int totalReview = 1;
            decimal num = 0.99M;
            while (GroupDupCount > 0 && totalReview < 18)
            {
                // assign IsDup = true;
                this.IsDupExtra = true;
                List<Model_ReportItemResult> dupwinList = new List<Model_ReportItemResult>();
               
               
                //loop all dup group
                foreach (KeyValuePair<decimal, int> q in GroupDup)
                {
                    decimal scoredup = q.Key;
                    int totaldup = q.Value;

                    // define result each dup group to list
                    List<Model_ReportItemResult> dupfocus = rlist.Where(d => d.Score_new == q.Key).OrderByDescending(r => r.Score_new).ToList();
                    
                    //Check Sup Flag
                    foreach(Model_ReportItemResult dup in dupfocus)
                    {
                        var obj = dupfocus.FirstOrDefault(o => o.ResultItemID == dup.ResultItemID);
                        if (obj != null) obj.IsDup = true;
                    }

                    bool onprocess = true;
                    //check g4
                    // List<Model_ReportItemResult> listnew = new List<Model_ReportItemResult>();

                    if (onprocess)
                    {
                       // decimal num = 0.99M;
                        foreach (Model_ReportItemResult dup in dupfocus.OrderBy(d => int.Parse(d.G4)))
                        {
                            int min = int.Parse(dupfocus.Min(m => m.G4));
                            int count = dupfocus.Where(o => (int.Parse(o.G4)) == min).Count();
                            if (count != dupfocus.Count())
                            {
                                if (min == int.Parse(dup.G4))
                                {
                                    Model_ReportItemResult gg = dup;
                                    gg.Factor = num;
                                    gg.IsDup = false;
                                    //int v = int.Parse(dup.G4);
                                    dupwinList.Add(gg);
                                    onprocess = false;
                                    //break;
                                }
                            }

                            num = num - (decimal)0.01;
                        }
                    }

                    if (onprocess)
                    {
                       // decimal num = 0.99M;
                        foreach (Model_ReportItemResult dup in dupfocus.OrderByDescending(d => int.Parse(d.G1)))
                        {
                            int max = int.Parse(dupfocus.Max(m => m.G1));
                            int count = dupfocus.Where(o => (int.Parse(o.G1)) == max).Count();
                            if (count != dupfocus.Count())
                            {
                                if (max == int.Parse(dup.G1))
                                {
                                    Model_ReportItemResult gg = dup;
                                    gg.Factor = num;
                                    gg.IsDup = false;
                                    //int v = int.Parse(dup.G4);
                                    dupwinList.Add(gg);
                                    onprocess = false;
                                    //break;
                                }
                            }

                            num = num - (decimal)0.01;
                        }
                    }

                    if (onprocess)
                    {
                       // decimal num = 0.99M;
                        foreach (Model_ReportItemResult dup in dupfocus.OrderByDescending(d => int.Parse(d.G2)))
                        {
                            int max = int.Parse(dupfocus.Max(m => m.G2));
                            int count = dupfocus.Where(o => (int.Parse(o.G2)) == max).Count();
                            if (count != dupfocus.Count())
                            {
                                if (max == int.Parse(dup.G2))
                                {
                                    Model_ReportItemResult gg = dup;
                                    gg.Factor = num;
                                    gg.IsDup = false;
                                    //int v = int.Parse(dup.G4);
                                    dupwinList.Add(gg);
                                    onprocess = false;
                                    //break;
                                }
                            }

                            num = num - (decimal)0.01;
                        }
                    }


                    if (onprocess)
                    {
                        //decimal num = 0.99M;
                        foreach (Model_ReportItemResult dup in dupfocus.OrderByDescending(d => int.Parse(d.G3)))
                        {
                            int max = int.Parse(dupfocus.Max(m => m.G3));
                            int count = dupfocus.Where(o => (int.Parse(o.G3)) == max).Count();
                            if (count != dupfocus.Count())
                            {
                                if (max == int.Parse(dup.G3))
                                {
                                    Model_ReportItemResult gg = dup;
                                    gg.Factor = num;
                                    gg.IsDup = false;
                                    //int v = int.Parse(dup.G4);
                                    dupwinList.Add(gg);
                                    onprocess = false;
                                    //break;
                                }
                            }

                            num = num - (decimal)0.01;
                        }
                    }



                }



                foreach (Model_ReportItemResult i in dupwinList)
                {
                   var obj = rlist.FirstOrDefault(o => o.ResultItemID == i.ResultItemID);
                    if (obj != null) obj.Score_new = i.Score_new + (decimal)i.Factor;
                }

                // newlist_raw = newlist;
                GroupDup = rlist.GroupBy(x => (decimal)x.Score_new)
                     .Where(g => g.Count() > 1)
                     .ToDictionary(x => x.Key, y => y.Count());
                GroupDupCount = dupwinList.Count();
                if (GroupDupCount > 0)
                    this.IsDupExtra = true;
                else
                    this.IsDupExtra = false;

                totalReview = totalReview + 1;
                num = num - (decimal)0.01;
                //if (GroupDupCount == 0 || totalReview == 18)
                //{
                //    result = newlist_raw;
                //}
            }
           

        }
        


        return rlist;
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
            int intdexdup = 0;
            int intdex = 0;

            while (dup.Count > 1)
            {
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

               

                for (int i = 0; i < totaldup; i++)
                {

                    for (int ii = 0; i < totaldup; ii++)
                    {
                        if (arr[i, 3] != arr[ii, 3])
                        {
                            intdexdup = arr[i, 3] < arr[ii, 3] ? i : ii;
                            intdex = 3;
                            break;
                        }
                        if (arr[i, 0] != arr[ii, 0])
                        {
                            intdexdup = arr[i, 0] > arr[ii, 0] ? i : ii;
                            intdex = 0;
                            break;
                        }
                        if (arr[i, 1] != arr[ii, 1])
                        {
                            intdexdup = arr[i, 1] > arr[ii, 1] ? i : ii;
                            intdex = 1;
                            break;
                        }
                        if (arr[i, 2] != arr[ii, 2])
                        {
                            intdexdup = arr[i, 2] > arr[ii, 2] ? i : ii;
                            intdex = 2;
                            break;
                        }
                    }

                }
            }

           

            Model_ReportItemResult dupwin = dup[intdexdup];
            dup.RemoveAt(intdexdup);
            dupwinList.Add(dupwin);
        }



        foreach(Model_ReportItemResult i in rlist)
        {
            decimal newScore = i.Score;
            Model_ReportItemResult ff = dupwinList.FirstOrDefault(r => r.ResultItemID == i.ResultItemID);
            if (ff != null)
                newScore = ff.Score + (decimal)0.99;
            newlist.Add(new Model_ReportItemResult
            {
                ResultSectionID = this.ResultSectionID,
                ResultItemID = i.ResultItemID,
                ResultItemTitle = i.ResultItemTitle,
                TransactionID = this.TransactionID,
                Score = i.Score,
                Score_new = newScore,
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