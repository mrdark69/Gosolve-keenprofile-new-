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
/// Summary description for UsersController
/// </summary>
public class ProductController
{
    public ProductController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    
   
    public static IList<Model_Products> GetProductAll(Model_Products ts)
    {
        return ts.GetProduct(ts);
    }

   

}