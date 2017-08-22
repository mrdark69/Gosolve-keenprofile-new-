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
    public Calculation_T1(int intResultSectionID, int TransactionID)
    {

        this.ResultSectionID = intResultSectionID;
        this.TransactionID = TransactionID;
        //
        // TODO: Add constructor logic here
        //
    }

    //Get Subsection F and H

    public List<Model_UsersAssessment> GetUserAss(char code)
    {
        Model_UsersAssessment uss = new Model_UsersAssessment();
        List<Model_UsersAssessment> ussList = uss.GetUserAssessmentByTsID(this.TransactionID).Where(o => o.Code.Trim().ToLower()[0] == code).ToList();

        return ussList;
    }


    public List<Model_ReportItemResult> Code_F_SumValueBySubSection(List<Model_UsersAssessment> list)
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
            foreach (string  m in arrmap)
            {
                 score  = score + list.Where(o => o.SUCID == int.Parse(m)).Sum(t => t.Score);
                
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

    public  bool Calnow()
    {

        //Step retrive f code list of assessment result
        List<Model_UsersAssessment> F = GetUserAss('f');


        List<Model_ReportItemResult> fscore = Code_F_SumValueBySubSection(F);

        return true;
    }

   
   

}