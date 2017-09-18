using System;
using System.Collections;
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
public class Calculation_T1
{
    public int ResultSectionID { get; set; }
    public int TransactionID { get; set; }

    public List<Model_UsersAssessment> R_UserAss_F { get; set; }
    public List<Model_UsersAssessment> R_UserAss_H { get; set; }
    public List<Model_UsersAssChoice> R_UserAssChoice_H { get; set; }

    public Calculation_T1(int intResultSectionID, int TransactionID)
    {

        this.ResultSectionID = intResultSectionID;
        this.TransactionID = TransactionID;



        //Step retrive f code list of assessment result
        this.R_UserAss_F = GetUserAss('f');

        this.R_UserAss_H = GetUserAss('h');

        //Step retrive H code list of assessment choice result
        this.R_UserAssChoice_H = GetUserAssChoice('h');
        
    }

    //Get Subsection F and H

   


    public List<Model_ReportItemResult> Code_F_SumValueBySubSection()
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
            int TASCID = 0;
            int TASID = 0;
            string strDetail = string.Empty;
            foreach (string  m in arrmap)
            {

                 score  = score + this.R_UserAss_F.Where(o => o.SUCID == int.Parse(m)).Sum(t => t.Score);
                
            }

            foreach (string m in arrmap)
            {
                List<Model_UsersAssChoice> assch = this.R_UserAssChoice_H.Where(o => o.SUCID == int.Parse(m)).ToList();
               
                score = score + this.R_UserAssChoice_H.Where(o => o.SUCID == int.Parse(m)).Sum(t => t.Score);

                if(assch.Count > 0)
                {
                    TASCID =assch.Select(r => r.TASCID).Last();
                    TASID =  assch.Select(r => r.TASID).Last();
                    strDetail = String.Join(",", assch.Select(t => t.Score).ToArray());
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
                TASCID = TASCID,
                TASID = TASID,
                Detail = strDetail
            });

            

        }

        Dictionary<decimal, int> GroupDupRecheck = rlist.GroupBy(x => (decimal)x.Score)
          .Where(g => g.Count() > 1)
          .ToDictionary(x => x.Key, y => y.Count());

        if(GroupDupRecheck.Count > 0)
        {
            Model_UsersAssessment hforcus = this.R_UserAss_H.OrderByDescending(o => o.Priority).FirstOrDefault();
            List<Model_UsersAssChoice> chfocus = this.R_UserAssChoice_H.Where(o => o.TASID == hforcus.TASID).OrderByDescending(r => r.Score).ToList();

            decimal startfactor = 0.99M;
            foreach (KeyValuePair<decimal, int> q in GroupDupRecheck)
            {
                List<Model_ReportItemResult> dupfocus = rlist.Where(d => d.Score == q.Key).OrderByDescending(r => r.Score).ToList();

                //foreach (Model_ReportItemResult item in dupfocus.Where(o => o.IsDup).OrderBy(o => o.UserRank))
                //{
                //    var obj = rlist.FirstOrDefault(o => o.ResultItemID == item.ResultItemID);
                //    if (obj != null) obj.Score_new = obj.Score_new + startfactor;

                //    startfactor = startfactor - (decimal)0.01;
                //}

                foreach (Model_UsersAssChoice item in chfocus)
                {
                    var obj = rlist.FirstOrDefault(o => o.TASCID == item.TASCID);
                    if (obj != null) obj.Score_new = obj.Score_new + startfactor;
                    startfactor = startfactor - (decimal)0.01;
                }
            }


       }
       


       

      

        return rlist;
    }

    public bool Calnow()
    {

        List<Model_ReportItemResult> fscore = Code_F_SumValueBySubSection();
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