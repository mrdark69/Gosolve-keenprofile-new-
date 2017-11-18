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
    public List<Model_JobFunctionGroup> GetAllActive()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
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

    public string GroupName { get; set; }


    public string DesInto { get; set; }
    public string Des1 { get; set; }
    public string Des2 { get; set; }
    public string Des3 { get; set; }
    public string Des4 { get; set; }
    public string Des5 { get; set; }

    public bool UpdateById(Model_Jobfunction c)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE Jobfunction SET Title=@Title,Status=@Status,JGID=@JGID,DesInto=@DesInto,Des1=@Des1
,Des2=@Des2,Des3=@Des3,Des4=@Des4,Des5=@Des5 WHERE JFID=@JFID", cn);
            cmd.Parameters.Add("@JFID", SqlDbType.Int).Value = c.JFID;
            cmd.Parameters.Add("@JGID", SqlDbType.Int).Value = c.JGID;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = c.Title;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = c.Status;

            cmd.Parameters.Add("@DesInto", SqlDbType.NVarChar).Value = c.DesInto;
            cmd.Parameters.Add("@Des1", SqlDbType.NVarChar).Value = c.Des1;
            cmd.Parameters.Add("@Des2", SqlDbType.NVarChar).Value = c.Des2;
            cmd.Parameters.Add("@Des3", SqlDbType.NVarChar).Value = Des3;
            cmd.Parameters.Add("@Des4", SqlDbType.NVarChar).Value = c.Des4;
            cmd.Parameters.Add("@Des5", SqlDbType.NVarChar).Value = c.Des5;
          

            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
    }
    public int Insert(Model_Jobfunction c)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO (JFID,JGID,Title,Status,DesInto,Des1,Des2,Des3,Des4,Des5) VALUES(@JFID,@JGID,@Title,@Status,@DesInto,@Des1,@Des2,@Des3,@Des4,@Des5)  ", cn);
            cmd.Parameters.Add("@JFID", SqlDbType.Int).Value = c.JFID;
            cmd.Parameters.Add("@JGID", SqlDbType.Int).Value = c.JGID;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = c.Title;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;

            cmd.Parameters.Add("@DesInto", SqlDbType.NVarChar).Value = c.DesInto;
            cmd.Parameters.Add("@Des1", SqlDbType.NVarChar).Value = c.Des1;
            cmd.Parameters.Add("@Des2", SqlDbType.NVarChar).Value = c.Des2;
            cmd.Parameters.Add("@Des3", SqlDbType.NVarChar).Value = Des3;
            cmd.Parameters.Add("@Des4", SqlDbType.NVarChar).Value = c.Des4;
            cmd.Parameters.Add("@Des5", SqlDbType.NVarChar).Value = c.Des5;
            cn.Open();
            return ExecuteNonQuery(cmd);
        }
    }

    public List<Model_Jobfunction> GetAll()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT j.*,jg.Title As GroupName FROM Jobfunction j INNER JOIN JobFunctionGroup jg ON j.JGID=jg.JGID
WHERE jg.Status = 1", cn);
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

    public Model_Jobfunction GetByID(int intJFID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Jobfunction WHERE JFID=@JFID", cn);
            cmd.Parameters.Add("@JFID", SqlDbType.Int).Value = intJFID;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }

    public int insert(Model_Jobfunction c)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmdUpdate = new SqlCommand("UPDATE Jobfunction SET JGID=@JGID ,Title=@Title WHERE JFID=@JFID ", cn);
            cmdUpdate.Parameters.Add("@JFID", SqlDbType.Int).Value = c.JFID;
            cmdUpdate.Parameters.Add("@JGID", SqlDbType.Int).Value = c.JGID;
            cmdUpdate.Parameters.Add("@Title", SqlDbType.NVarChar).Value = c.Title;
            cn.Open();
            if (ExecuteNonQuery(cmdUpdate) == 0)
            {
                //SqlCommand cmddel = new SqlCommand("DELETE  FROM Jobfunction WHERE JFID=@JFID", cn);
                //cmddel.Parameters.Add("@JFID", SqlDbType.Int).Value = c.JFID;
                //ExecuteNonQuery(cmddel);

                SqlCommand cmd = new SqlCommand("INSERT INTO Jobfunction (JFID,JGID,Title,Status) VALUES(@JFID,@JGID,@Title,@Status);", cn);
                cmd.Parameters.Add("@JFID", SqlDbType.Int).Value = c.JFID;
                cmd.Parameters.Add("@JGID", SqlDbType.Int).Value = c.JGID;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = c.Title;
                cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
                ret = ExecuteNonQuery(cmd);
            }
            else
            {
                ret = 1;
            }
           
         
        


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

    public string JobTitle { get; set; }

    public string JobmainTitle { get; set; }



    public Model_JobFunctionListMap GetByID(int intJFID, int intJFMID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM JobFunctionListMap WHERE JFMID=@JFMID AND JFID=@JFID", cn);
            cmd.Parameters.Add("@JFMID", SqlDbType.Int).Value = intJFMID;
            cmd.Parameters.Add("@JFID", SqlDbType.Int).Value = intJFID;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;

        }
    }

    public bool Update(Model_JobFunctionListMap c)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE JobFunctionListMap SET Score=@Score WHERE JFMID=@JFMID AND JFID=@JFID", cn);
            cmd.Parameters.Add("@JFMID", SqlDbType.Int).Value = c.JFMID;
            cmd.Parameters.Add("@JFID", SqlDbType.Int).Value = c.JFID;
            cmd.Parameters.Add("@Score", SqlDbType.Int).Value = c.Score;
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;

        }
    }

    public int Insert(Model_JobFunctionListMap c)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO JobFunctionListMap (JFMID,JFID,Score) VALUES(@JFMID,@JFID,@Score) ", cn);
            cmd.Parameters.Add("@JFMID", SqlDbType.Int).Value = c.JFMID;
            cmd.Parameters.Add("@JFID", SqlDbType.Int).Value = c.JFID;
            cmd.Parameters.Add("@Score", SqlDbType.Int).Value = c.Score;
            cn.Open();
            return ExecuteNonQuery(cmd);

        }
    }

    public List<Model_JobFunctionListMap> GetAll(Model_JobFunctionListMap JobID)
    {


      

        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT jm.*,j.Title AS JobTitle,jma.Title As JobmainTitle FROM JobFunctionListMap jm 
        INNER JOIN JobFunctionListMain jma ON jma.JFMID = Jm.JFMID 
         INNER JOIN JobFunction j ON j.JFID = jm.JFID
WHERE jma.Status =1 AND j.Status =1 AND j.JFID=@JFID
ORDER BY jma.Priority", cn);
            cmd.Parameters.Add("@JFID", SqlDbType.Int).Value = JobID.JFID;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }


    public List<Model_JobFunctionListMap> GetAllList()
    {




        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT jm.*,j.Title AS JobTitle,jma.Title As JobmainTitle FROM JobFunctionListMap jm 
        INNER JOIN JobFunctionListMain jma ON jma.JFMID = Jm.JFMID 
         INNER JOIN JobFunction j ON j.JFID = jm.JFID
WHERE jma.Status =1 AND j.Status =1 
ORDER BY jma.Priority", cn);
           
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public int insert(Model_JobFunctionListMap c)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmdupdate = new SqlCommand("UPDATE JobFunctionListMap SET Score=@Score WHERE JFID=@JFID AND JFMID=@JFMID ", cn);
            cmdupdate.Parameters.Add("@JFID", SqlDbType.Int).Value = c.JFID;
            cmdupdate.Parameters.Add("@JFMID", SqlDbType.Int).Value = c.JFMID;
            cmdupdate.Parameters.Add("@Score", SqlDbType.Int).Value = c.Score;
            cn.Open();
            if (ExecuteNonQuery(cmdupdate) == 0)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO JobFunctionListMap (JFID,JFMID,Score) VALUES(@JFID,@JFMID,@Score) ;", cn);
                cmd.Parameters.Add("@JFID", SqlDbType.Int).Value = c.JFID;
                cmd.Parameters.Add("@JFMID", SqlDbType.Int).Value = c.JFMID;
                cmd.Parameters.Add("@Score", SqlDbType.Int).Value = c.Score;
              ret =   ExecuteNonQuery(cmd);
            }
            else
                ret = 1;





            return ret;


           

        }
    }

}

