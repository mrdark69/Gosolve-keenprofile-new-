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
    public Calculation_T3(int intResultSectionID)
    {
        this.ResultSectionID = intResultSectionID;
        //
        // TODO: Add constructor logic here
        //
    }

    public  bool Calnow()
    {
        return false;
    }

}