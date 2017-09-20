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

    public static int CalculateActionStart(int intTransactionID)
    {
        int ret = -1;
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
                        Calculation_T1 cal1 = new Calculation_T1(item.ResultSectionID , intTransactionID);
                        if (cal1.Calnow())
                            ret = 0;
                        break;
                    //T2 Working Traits
                    case 2:
                        Calculation_T2 cal2 = new Calculation_T2(item.ResultSectionID, intTransactionID);
                    
                        if (cal2.Calnow())
                            ret = 0;
                        break;
                    //T3 Working Geniuses
                    case 3:
                        Calculation_T3 cal3 = new Calculation_T3(item.ResultSectionID, intTransactionID);
                        if (cal3.Calnow())
                            ret = 0;


                        if (!cal3.IsDupExtra)
                            ret = cal3.TransactionID;
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