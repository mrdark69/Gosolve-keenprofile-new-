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
public class Model_JobFunctionGroup: BaseModel<Model_JobFunctionGroup>
{
    public int JGID { get; set; }
    public string Title { get; set; }
    public int Priority { get; set; }
    public bool Status { get; set; }
 

    public List<Model_JobFunctionGroup> GetAll()
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM JobFunctionGroup ORDER BY Priority ASC", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public Model_JobFunctionGroup GetByID(int intID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM JobFunctionGroup WHERE JGID=@JGID", cn);
            cmd.Parameters.Add("@JGID", SqlDbType.Int).Value = intID;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
           
        }
    }

    public int InsertGroup(Model_JobFunctionGroup g)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO JobFunctionGroup (JGID,Title,Priority,Status) VALUES(@JGID,@Title,@Priority,@Status)", cn);
            cmd.Parameters.Add("@JGID", SqlDbType.Int).Value = g.JGID;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = g.Title;
            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = g.Priority;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = g.Status;
            cn.Open();

            return ExecuteNonQuery(cmd);
           
        }
    }
   

    public bool updateGroup(Model_JobFunctionGroup g)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE JobFunctionGroup SET Title=@Title,Priority=@Priority,Status=@Status WHERE JGID=@JGID", cn);
            cmd.Parameters.Add("@JGID", SqlDbType.Int).Value = g.JGID;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = g.Title;
            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = g.Priority;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = g.Status;
            cn.Open();

            return ExecuteNonQuery(cmd) == 1;

        }
    }




}
public class Model_Jobfunction : BaseModel<Model_Jobfunction>
{
    public int JFID { get; set; }
    public int JGID { get; set; }
    public string Title { get; set; }
    
    public bool Status { get; set; }

   
    public List<Model_Jobfunction> GetAll()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Jobfunction", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public bool DeleteAll()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DELETE  FROM Jobfunction", cn);
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
    }

    public int insert(Model_Jobfunction c)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Jobfunction (JGID,Title,Status) VALUES(@JGID,@Title,@Status) ; SET @JFID=SCOPE_IDENTITY();", cn);
            cmd.Parameters.Add("@JGID", SqlDbType.Int).Value = c.JGID;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = c.Title;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
            cmd.Parameters.Add("@JFID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cn.Open();

            if (ExecuteNonQuery(cmd) > 0)
                ret = (int)cmd.Parameters["@JFID"].Value;


            return ret;

        }
    }

}
public class Model_JobFunctionListMain : BaseModel<Model_JobFunctionListMain>
{
    public int JFMID { get; set; }
    public string Title { get; set; }
    public string Mapping { get; set; }
    public bool Status { get; set; }
    public byte Category { get; set; }
    public int Priority { get; set; }

    public List<Model_JobFunctionListMain> GetAll()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM JobFunctionListMain", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }
    public List<Model_JobFunctionListMain> GetAllActive()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM JobFunctionListMain WHERE Status=1 ORDER BY Priority ASC", cn);
         
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }


    public Model_JobFunctionListMain GetByID(int intID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM JobFunctionListMain WHERE JFMID=@JFMID", cn);
            cmd.Parameters.Add("@JFMID", SqlDbType.Int).Value = intID;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;

        }
    }

    public int InsertGroup(Model_JobFunctionListMain g)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO JobFunctionListMain (Title,Priority,Status,Mapping,Category) VALUES(@Title,@Priority,@Status,@Mapping,@Category)", cn);
          
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = g.Title;
            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = g.Priority;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = g.Status;

            cmd.Parameters.Add("@Mapping", SqlDbType.NVarChar).Value = g.Mapping;
            cmd.Parameters.Add("@Category", SqlDbType.TinyInt).Value = g.Category;
            cn.Open();

            return ExecuteNonQuery(cmd);

        }
    }


    public bool updateGroup(Model_JobFunctionListMain g)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE JobFunctionListMain SET Title=@Title,Priority=@Priority,Status=@Status,Mapping=@Mapping, Category=@Category WHERE JFMID=@JFMID", cn);
            cmd.Parameters.Add("@JFMID", SqlDbType.Int).Value = g.JFMID;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = g.Title;
            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = g.Priority;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = g.Status;

            cmd.Parameters.Add("@Mapping", SqlDbType.NVarChar).Value = g.Mapping;
            cmd.Parameters.Add("@Category", SqlDbType.TinyInt).Value = g.Category;
            cn.Open();

            return ExecuteNonQuery(cmd) == 1;

        }
    }

}

public class Model_JobFunctionListMap : BaseModel<Model_JobFunctionListMap>
{
    public int JFID { get; set; }
    public int JFMID { get; set; }
    public int Score { get; set; }


    public List<Model_JobFunctionListMap> GetAll()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM JobFunctionListMap", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }
    public int insert(Model_JobFunctionListMap c)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO JobFunctionListMap (JFID,JFMID,Score) VALUES(@JFID,@JFMID,@Score) ;", cn);
            cmd.Parameters.Add("@JFID", SqlDbType.Int).Value = c.JFID;
            cmd.Parameters.Add("@JFMID", SqlDbType.Int).Value = c.JFMID;
            cmd.Parameters.Add("@Score", SqlDbType.Int).Value = c.Score;

            cn.Open();


            return ExecuteNonQuery(cmd);


           

        }
    }

}

