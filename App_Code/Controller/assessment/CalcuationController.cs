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
public class CalculationController
{
    public CalculationController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static bool CalculateActionStart()
    {
        bool ret = false;
        Model_ReportSection Rs = new Model_ReportSection();

        List<Model_ReportSection> Rslist = Rs.GetListActive();


        if(Rslist.Count > 0)
        {
            foreach(Model_ReportSection item in Rslist)
            {
                switch (item.ResultSectionID)
                {
                    //T1 Working Philosophies
                    case 1:
                        Calculation_T1 cal1 = new Calculation_T1(item.ResultSectionID);
                        ret = cal1.Calnow();
                        break;
                    //T2 Working Traits
                    case 2:
                        Calculation_T2 cal2 = new Calculation_T2(item.ResultSectionID);
                        ret = cal2.Calnow();
                        break;
                    //T3 Working Geniuses
                    case 3:
                        Calculation_T3 cal3 = new Calculation_T3(item.ResultSectionID);
                        ret = cal3.Calnow();
                        break;
                    //T4 nothing ???
                    case 4:
                        break;
                }
            }
        }



        return ret;
    }



}