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
using System.Security.Cryptography;

/// <summary>
/// Summary description for Model_User
/// </summary>
/// 
public class Model_UserCJF : BaseModel<Model_UserCJF>
{

}
public class Model_CJF : BaseModel<Model_CJF>
{
    public int CJFID { get; set; }

    public string Title { get; set; }


    public bool Status { get; set; }
 


    public Model_CJF()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<Model_CJF> GetCJFeAll()
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM CJF ", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public Model_CJF GetCJFByID(int byid)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM CJF WHERE CJFID=@CJFID", cn);
            cmd.Parameters.Add("@CJFID", SqlDbType.Int).Value = byid;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    } 

    public bool UpdateCJF(Model_CJF q)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE CJF SET Title=@Title,Status=@Status WHERE CJFID=@CJFID", cn);
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = q.Title;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = q.Status;
            cmd.Parameters.Add("@CJFID", SqlDbType.Int).Value = q.CJFID;
            cn.Open();

            return ExecuteNonQuery(cmd) == 1;
        }
    }


    public int AddnewCJF(Model_CJF q)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO CJF (Title,Status) VALUES(@Title,@Status)", cn);
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = q.Title;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = q.Status;
            cn.Open();

            return ExecuteNonQuery(cmd);
        }
        
    }
}