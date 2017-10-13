using MVCDatatableApp;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNet.Identity;
//using Excel;
using System.Data;
using System.Data.OleDb;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;
using System.Collections.Generic;

public partial class admin_Staff_ajax_webmethod_assessment : System.Web.UI.Page
{
    //protected void Page_Load(object sender, EventArgs e)
    //{

    //}


    [WebMethod]
    public static void GetAssessment(Model_Assessment parameters)
    {
        List<Model_Assessment> ret = AssessmentController.GetAssessmentList(parameters);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }

    [WebMethod]
    public static void GetSectionAll(Model_AsSection parameters)
    {
        IList<Model_AsSection> ret = AssessmentController.GetSectionList();


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }

    [WebMethod]
    public static void GetReportSectionAll(Model_ReportSection parameters)
    {
        Model_ReportSection pr = new Model_ReportSection();
        IList<Model_ReportSection> ret = pr.GetList();


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }
    [WebMethod]
    public static void GetReportSectionItemAll(Model_ReportSectionItem parameters)
    {
        Model_ReportSectionItem pr = new Model_ReportSectionItem();
        IList<Model_ReportSectionItem> ret = pr.GetListItem(parameters.ResultSectionID);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }

    [WebMethod]
    public static void GetAll(Model_Assessment parameters)
    {
        IList<Model_Assessment> ret = AssessmentController.GetAssessmentList(parameters);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }



    [WebMethod]
    public static void GetSubSectionAll(Model_AsSubSection parameters)
    {
        IList<Model_AsSubSection> ret = AssessmentController.getSubsectionBySecId(parameters);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }

    [WebMethod]
    public static void GetSubSectionAll2(Model_AsSubSection2 parameters)
    {
        IList<Model_AsSubSection2> ret = AssessmentController.getSubsectionBySecId2(parameters);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }



    [WebMethod]
    public static void GetQtAll(Model_QType parameters)
    {
        IList<Model_QType> ret = AssessmentController.GetQTypeAll();


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }


    [WebMethod]
    public static void GetFCAll(Model_FC parameters)
    {
        IList<Model_FC> ret = UsersController.GetFCeAll(parameters);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }

    [WebMethod]
    public static void GetCJFAll(Model_CJF parameters)
    {
        IList<Model_CJF> ret = UsersController.GetCJFAll(parameters);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }
}