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

public class Model_AppFeatureRole : BaseModel<Model_AppFeatureRole>
{
    public byte UsersRoleId { get; set; }
    public int ModuleID { get; set; }
    public int ActionID { get; set; }

    public string SlugAction { get; set; }
    public string SlugModule { get; set; }

    public int AddAppFeatureRole(Model_AppFeatureRole ma)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            
            SqlCommand cmd = new SqlCommand("INSERT INTO AppFeatureRole (UsersRoleId,ModuleID,ActionID) VALUES(@UsersRoleId,@ModuleID,@ActionID)", cn);
            cmd.Parameters.Add("@UsersRoleId", SqlDbType.TinyInt).Value = ma.UsersRoleId;
            cmd.Parameters.Add("@ModuleID", SqlDbType.Int).Value = ma.ModuleID;
            cmd.Parameters.Add("@ActionID", SqlDbType.Int).Value = ma.ActionID;
            cn.Open();
            return ExecuteNonQuery(cmd);
        }
    }


    public bool DeleteAppFeature(Model_AppFeatureRole ma)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmddel = new SqlCommand("DELETE FROM AppFeatureRole WHERE UsersRoleId=@UsersRoleId AND ModuleID=@ModuleID AND ActionID=@ActionID", cn);
            cmddel.Parameters.Add("@UsersRoleId", SqlDbType.TinyInt).Value = ma.UsersRoleId;
            cmddel.Parameters.Add("@ModuleID", SqlDbType.Int).Value = ma.ModuleID;
            cmddel.Parameters.Add("@ActionID", SqlDbType.Int).Value = ma.ActionID;
            cn.Open();


            return ExecuteNonQuery(cmddel) == 1;
        }
           
    }
    public List<Model_AppFeatureRole> GetAppFeatureList(byte UsersRoleId)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM AppFeatureRole WHERE UsersRoleId=@UsersRoleId", cn);
            cmd.Parameters.Add("@UsersRoleId", SqlDbType.TinyInt).Value = UsersRoleId;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }
    public List<Model_AppFeatureRole> GetAppFeatureListAuthen(byte UsersRoleId)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT af.*,aa.Slug AS SlugAction,am.Slug AS SlugModule FROM 
                                            AppFeatureRole af 
                                            INNER JOIN AppAction aa ON aa.ActionID = af.ActionID
                                            INNER JOIN AppModule am ON am.ModuleID= af.ModuleID
                                            WHERE aa.Status = 1 AND af.UsersRoleId=@UsersRoleId", cn);
            cmd.Parameters.Add("@UsersRoleId", SqlDbType.TinyInt).Value = UsersRoleId;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }


    //public List<Model_AppFeature> getListAppFeature(byte bytUsersRoleId)
    //{
    //    using(SqlConnection cn = new SqlConnection(this.ConnectionString))
    //    {
    //        SqlCommand cmd = new SqlCommand("SELECT * FROM AppFeatureRole WHERE ModuleID =@ModuleID AND Status=1 ORDER BY Priority ASC", cn);
    //        cn.Open();

    //        cmd.Parameters.Add("@ModuleID", SqlDbType.Int).Value = bytUsersRoleId;


    //        return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
    //    }
    //}
}

