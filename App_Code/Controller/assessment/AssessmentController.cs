﻿using System;
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
public class AssessmentController
{
    public AssessmentController()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public static string GetPaperReport1()
    {
        string ret = StringUtility.GetPDFTemplate("report1");
        //string css1 = StringUtility.GetPDFTemplate_css("style2");
        //string css2 = StringUtility.GetPDFTemplate_css("style3");
        //string css3 = StringUtility.GetPDFTemplate_css("chart");

        //ret = ret.Replace("<!--###StyePDF###-->", css1 + css2 + css3);
        return ret;
    }

    /// Assessment
    /// 

    public static int AddAssessment(Model_Assessment ass)
    {
        int assid = ass.AddAssessment(ass);
        if(ass.AssChoice.Count > 0)
        {
            Model_Assessment_Choice assc = new Model_Assessment_Choice();
            assc.AddAssessmentChoice(ass.AssChoice, assid);
        }
        return assid;
    }
    public static bool EditAssessment(Model_Assessment ass)
    {
        bool ret = ass.Update(ass);
        int assid = ass.ASID;
        if (ass.AssChoice.Count > 0 && ret)
        {
            Model_Assessment_Choice assc = new Model_Assessment_Choice();
            assc.AddAssessmentChoice(ass.AssChoice, assid);
        }
        return ass.Update(ass);
    }

    public static Model_Assessment GetAssessmentByID(int ASID)
    {
        Model_Assessment ass = new Model_Assessment();
        return ass.GetAssessmentByID(ASID);
    }


  


    /// <summary>
    /// Assessment Section
    /// </summary>
    /// <param name="ass"></param>
    /// <returns></returns>
    /// 






    public static int AddSection(string s, string c, string i, int pr)
    {
        Model_AsSection a = new Model_AsSection
        {
            Title = s,
            Code = c,
            Intro = i,
            Priority = pr
        };
        return a.InsertSection(a);
    }
    public static bool EditSection(byte id ,string s, string c, string i,bool Status, int pr)
    {
        Model_AsSection a = new Model_AsSection
        {
            SCID = id,
            Title = s,
            Code = c,
            Intro = i,
            Status = Status,
            Priority = pr
        };
        return a.UpdateSection(a);
    }


    public static List<Model_Assessment> GetAssessmentList(Model_Assessment ass)
    {

        return ass.GetAssessment_paging(ass);
    }


    public static  Model_AsSection getSectionByID(int intSectionID)
    {
        Model_AsSection sec = new Model_AsSection();
        return sec.GetSectionByID(intSectionID);
       
    }
    public static List<Model_AsSection> GetSectionList(bool status)
    {
        Model_AsSection sec = new Model_AsSection();
        return sec.GetListSection(status);
    }

    public static List<Model_AsSection> GetSectionList()
    {
        Model_AsSection sec = new Model_AsSection();
        return sec.GetListSection();
    }



    ////Sub Section

    public static List<Model_AsSubSection> getSubsectionBySecId(Model_AsSubSection ae)
    {
        return ae.getAllSubSection(ae);
    }
    public static List<Model_AsSubSection2> getSubsectionBySecId2(Model_AsSubSection2 ae)
    {
        return ae.getAllSubSection(ae);
    }

    public static Model_AsSubSection getSubByID(int sUID)
    {
        Model_AsSubSection s = new Model_AsSubSection();

        return s.getSubByID(sUID);
    }
    public static Model_AsSubSection2 getSubByID2(int sUID)
    {
        Model_AsSubSection2 s = new Model_AsSubSection2();

        return s.getSubByID(sUID);
    }

    public static bool EditSubSection(Model_AsSubSection sec)
    {
        return sec.UpdateSub(sec);
    }

    public static bool EditSubSection2(Model_AsSubSection2 sec)
    {
        return sec.UpdateSub(sec);
    }

    public static int AddSubSection(Model_AsSubSection sec)
    {
        return sec.AddnewSub(sec);
    }
    public static int AddSubSection2(Model_AsSubSection2 sec)
    {
        return sec.AddnewSub(sec);
    }




    ///Question Type
    ///

    public static Model_QType GetQtypeID(byte bytId)
    {
        Model_QType q = new Model_QType();
        return q.GetQTypeByID(bytId);
    }
    public static List<Model_QType> GetQTypeAllByStatus(bool Status)
    {
        Model_QType q = new Model_QType();
        return q.GetQTypeAllByStatus(Status);
    }
    public static List<Model_QType> GetQTypeAll()
    {
        Model_QType q = new Model_QType();
        return q.GetQTypeAll();
    }

    public static bool EditQType(Model_QType q)
    {
        return q.UpdateQ(q);
    }

    public static int AddQtype(Model_QType q)
    {
        return q.AddnewQ(q);
    }


    public static bool UpdateIntro(Model_AssesIntro ss)
    {
       return ss.SaveAssIntro(ss);
    }


    public static Model_AssesIntro GetAssIntro()
    {
        Model_AssesIntro ai = new Model_AssesIntro();
        return ai.GetIntro();
    }
}