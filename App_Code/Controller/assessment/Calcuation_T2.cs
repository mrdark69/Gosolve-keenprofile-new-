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
public class Calculation_T2
{
    public int ResultSectionID { get; set; }
    public int TransactionID { get; set; }
    public Calculation_T2(int intResultSectionID, int TransactionID)
    {

        this.ResultSectionID = intResultSectionID;
        this.TransactionID = TransactionID;
        //
        // TODO: Add constructor logic here
        //
    }

    public  bool Calnow()
    {
        return true;
    }


}