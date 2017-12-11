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

public partial class admin_Users_ajax_webmethod_product : System.Web.UI.Page
{
    //protected void Page_Load(object sender, EventArgs e)
    //{

    //}

   

    [WebMethod]
    public static void GetProductAll(Model_Products parameters)
    {


        IList<Model_Products> ret = ProductController.GetProductAll(parameters);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }
   
}