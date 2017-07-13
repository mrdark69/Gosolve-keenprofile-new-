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
public class Model_AsSection : BaseModel<Model_AsSection>
{
    public int SCID { get; set; }
    public string Code { get; set; }

    public string Title { get; set; }
    public bool Status { get; set; }

    public string Intro { get; set; }
    public int Priority { get; set; }


    public Model_AsSection()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int InsertSection(Model_AsSection Section)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Section (Title,Code,Intro,Priority) VALUES(@Title,@Code,@Intro,@Priority)", cn);
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = Section.Title;
            cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = Section.Code;
            cmd.Parameters.Add("@Intro", SqlDbType.NVarChar).Value = Section.Intro;
            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = Section.Priority;
            cn.Open();
            return ExecuteNonQuery(cmd);
        }
    }
    public bool UpdateSection(Model_AsSection Section)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE Section SET Title=@Title,Code=@Code,Intro=@Intro,Status=@Status,Priority=@Priority WHERE  SCID=@SCID ", cn);
            cmd.Parameters.Add("@SCID", SqlDbType.TinyInt).Value = Section.SCID;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = Section.Title;
            cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = Section.Code;
            cmd.Parameters.Add("@Intro", SqlDbType.NVarChar).Value = Section.Intro;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = Section.Status;
            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = Section.Priority;
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
    }

    public List<Model_AsSection> GetListSection()
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Section WHERE Status =1 ORDER BY Priority ASC", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public Model_AsSection GetSectionByID(byte bytID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Section WHERE SCID=@SCID", cn);
            cmd.Parameters.Add("@SCID", SqlDbType.TinyInt).Value = bytID;
            cn.Open();

            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else return null;
        }
    }
}