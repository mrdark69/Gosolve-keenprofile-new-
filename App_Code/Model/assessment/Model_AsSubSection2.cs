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
public class Model_AsSubSection2 : BaseModel<Model_AsSubSection2>
{
    public int SUCID2 { get; set; }
    public int SCID { get; set; }
    public string Title { get; set; }
    public string Combind { get; set; }


    public bool Status { get; set; }

    public string SectionTitle { get; set; }

    public Model_AsSubSection2()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<Model_AsSubSection2> getAllSubSection(Model_AsSubSection2 mu)
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
            cText.Append(@"SELECT u.*,ur.Title AS SectionTitle FROM  SubSection2 u 
INNER JOIN Section ur ON ur.SCID =u.SCID AND ur.Status = 1" + w + " ORDER BY ur.SCID ASC");

            cmd.CommandText = cText.ToString();
            cmd.Connection = cn;


            cn.Open();

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public Model_AsSubSection2 getSubByID(int SubID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM SubSection2 WHERE SUCID2=@SUCID2", cn);
            cmd.Parameters.Add("@SUCID2", SqlDbType.Int).Value = SubID;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }

    public List<Model_AsSubSection2> getSubBySectionID(int SCID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM SubSection2 WHERE SCID=@SCID AND Status = 1", cn);
            cmd.Parameters.Add("@SCID", SqlDbType.Int).Value = SCID;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public int AddnewSub(Model_AsSubSection2 mu)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO SubSection2 (SCID,Title,Status,Combind) VALUES(@SCID,@Title,@Status,@Combind)", cn);
            cmd.Parameters.Add("@SCID", SqlDbType.Int).Value = mu.SCID;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = mu.Title;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = mu.Status;
            cmd.Parameters.Add("@Combind", SqlDbType.VarChar).Value = mu.Combind;
            cn.Open();
            return ExecuteNonQuery(cmd);
        }
    }

    public bool UpdateSub(Model_AsSubSection2 mu)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE SubSection2 SET Title=@Title ,Status=@Status ,SCID=@SCID ,Combind=@Combind WHERE SUCID2=@SUCID2", cn);
            cmd.Parameters.Add("@SCID", SqlDbType.Int).Value = mu.SCID;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = mu.Title;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = mu.Status;
            cmd.Parameters.Add("@Combind", SqlDbType.VarChar).Value = mu.Combind;
            cmd.Parameters.Add("@SUCID2", SqlDbType.Int).Value = mu.SUCID2;
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
    }


}