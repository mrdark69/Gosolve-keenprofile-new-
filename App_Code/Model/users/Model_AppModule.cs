using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MVCDatatableApp;
using Microsoft.AspNet.Identity;
using gs_newsletter;
using System.Web.Providers.Entities;

/// <summary>
/// Summary description for Model_Users
/// </summary>
/// 

public class Model_AppModule : BaseModel<Model_AppModule>
{
    public int ModuleID { get; set; }
    public string Title { get; set; }
    public byte AppSectionID { get; set; } = 1;
    public string Slug { get; set; }
    public int Priority { get; set; }
    public bool Status { get; set; }



    public List<Model_AppModule> getListAppFeature(byte AppSectionID)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM AppModule WHERE AppSectionID =@AppSectionID AND Status =1 ORDER BY Priority ASC", cn);
            cn.Open();

            cmd.Parameters.Add("@AppSectionID", SqlDbType.TinyInt).Value = AppSectionID;

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }
}

