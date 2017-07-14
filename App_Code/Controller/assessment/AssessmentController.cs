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
public class AssessmentController
{
    public AssessmentController()
    {
        //
        // TODO: Add constructor logic here
        //
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

        return ass.GetAssessment(ass);
    }


    public static  Model_AsSection getSectionByID(byte bytSectionID)
    {
        Model_AsSection sec = new Model_AsSection();
        return sec.GetSectionByID(bytSectionID);
       
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

    public static Model_AsSubSection getSubByID(int sUID)
    {
        Model_AsSubSection s = new Model_AsSubSection();

        return s.getSubByID(sUID);
    }

    public static bool EditSubSection(Model_AsSubSection sec)
    {
        return sec.UpdateSub(sec);
    }

    public static int AddSubSection(Model_AsSubSection sec)
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

    public static List<Model_QType> GetQTypeAll(Model_QType ae)
    {
        return ae.GetQTypeAll();
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