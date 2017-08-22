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

            decimal score = list.Where(o => o.SUCID == item.SUCID).Sum(t => t.Score);

            foreach(Model_UsersAssessment com in list.Where(o => !string.IsNullOrEmpty(o.Combind)))
            {
               
                string[] arrcombind = com.Combind.Split(',');


                foreach (string c in arrcombind)
                {
                    Regex rgx = new Regex("[^0-9 -]");
                    string cnew = rgx.Replace(c, "");

                    if(item.SUCID == int.Parse(cnew))
                    {
                        score = score + com.Score;
                    }


                }

            }



            //foreach

            rlist.Add(new Model_ReportItemResult
            {
                ResultSectionID = this.ResultSectionID,
                ResultItemID = item.ResultItemID,
                ResultItemTitle = item.Title,
                TransactionID = this.TransactionID,
                Score = score
            });
        }


        //List<Model_AsSubSection> listSub = sub.getSubBySectionID(section.SCID);

        //foreach(Model_AsSubSection s in listSub)
        //{
          
        //    if(s.Title.ToLower() != "n/a")
        //    {
        //        ArrayList r = new ArrayList();
        //        r.Add(s.SCID);
        //        r.Add(s.Title);
        //        r.Add(list.Where(o => o.SUCID == s.SUCID).Sum(t => t.Score));
        //        r.Add(s.Combind);
        //        r.Add(s.SUCID);
        //        ret.Add(r);
        //    }
           
        //}

       
   
        //foreach (ArrayList s in ret)
        //{
        //    int index = 0;
        //    if (!string.IsNullOrEmpty((string)s[3]))
        //    {
                
        //        raw.Add(s);
        //        string combind = (string)s[3];
        //        string[] arrcombind = combind.Split(',');

        //        foreach(string c in arrcombind)
        //        {
        //           // Regex rgx = new Regex("[^0-9 -]");
        //           //string cnew = rgx.Replace(c, "");

        //           // ret.RemoveAt(index);
        //           //( (ArrayList)ret.Where(o => (int)o[4] == int.Parse(cnew)).SingleOrDefault()).se
        //           // decimal scoreold = (decimal)ret.Where(o => (int)o[4] == int.Parse(cnew)).SingleOrDefault()[3];
        //           // decimal scorenew = (decimal)c[3];

        //        }
               
        //    }

        //    index = index + 1;
        //}
            //decimal innovation = 0;
            //decimal service = 0;
            //decimal Cost = 0;


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