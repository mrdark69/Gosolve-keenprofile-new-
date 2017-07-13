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

public class Model_AppAction : BaseModel<Model_AppAction>
{
    public int ActionID { get; set; }
    public int ModuleID { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public int Priority { get; set; }
    public bool Status { get; set; }



    public List<Model_AppAction> getListAppFeatureAll()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM AppAction WHERE  Status=1 ORDER BY Priority ASC", cn);
            cn.Open();
            

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }
    public List<Model_AppAction> getListAppFeature(byte bytUsersRoleId)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM AppAction WHERE ModuleID =@ModuleID AND Status=1 ORDER BY Priority ASC", cn);
            cn.Open();

            cmd.Parameters.Add("@ModuleID", SqlDbType.Int).Value = bytUsersRoleId;
     

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }
}

