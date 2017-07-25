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
public class Model_AsSubSection : BaseModel<Model_AsSubSection>
{
    public int SUCID { get; set; }
    public int SCID { get; set; }
    public string Title { get; set; }
 

    public bool Status { get; set; }

    public string SectionTitle { get; set; }

    public Model_AsSubSection()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<Model_AsSubSection> getAllSubSection(Model_AsSubSection mu)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder cText = new StringBuilder();

            string w = string.Empty;

            if (mu.SCID > 0)
            {
                w = " WHERE u.SCID =@SCID";
                cmd.Parameters.Add("@SCID", SqlDbType.TinyInt).Value = mu.SCID;

            }
            cText.Append(@"SELECT u.*,ur.Title AS SectionTitle FROM  SubSection u 
INNER JOIN Section ur ON ur.SCID =u.SCID AND ur.Status = 1" + w + " ORDER BY ur.SCID ASC");

            cmd.CommandText = cText.ToString();
            cmd.Connection = cn;


            cn.Open();

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public Model_AsSubSection getSubByID(int SubID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM SubSection WHERE SUCID=@SUCID", cn);
            cmd.Parameters.Add("@SUCID", SqlDbType.Int).Value = SubID;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }

    public int AddnewSub(Model_AsSubSection mu)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO SubSection (SCID,Title,Status) VALUES(@SCID,@Title,@Status)", cn);
            cmd.Parameters.Add("@SCID", SqlDbType.Int).Value = mu.SCID;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = mu.Title;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = mu.Status;
            cn.Open();
            return ExecuteNonQuery(cmd);
        }
    }

    public bool UpdateSub(Model_AsSubSection mu)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE SubSection SET Title=@Title ,Status=@Status ,SCID=@SCID WHERE SUCID=@SUCID", cn);
            cmd.Parameters.Add("@SCID", SqlDbType.Int).Value = mu.SCID;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = mu.Title;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = mu.Status;
            cmd.Parameters.Add("@SUCID", SqlDbType.Int).Value = mu.SUCID;
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
    }


}