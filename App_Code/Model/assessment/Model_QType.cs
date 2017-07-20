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
public class Model_QType : BaseModel<Model_QType>
{
    public int QTID { get; set; }

    public string Title { get; set; }


    public bool Status { get; set; }



    public Model_QType()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<Model_QType> GetQTypeAllByStatus(bool Status)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM QuestionsType WHERE Status =@Status ORDER BY Status DESC", cn);
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = Status;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }
    public List<Model_QType> GetQTypeAll()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM QuestionsType ORDER BY Status DESC", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public Model_QType GetQTypeByID(byte byid)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM QuestionsType WHERE QTID=@QTID", cn);
            cmd.Parameters.Add("@QTID", SqlDbType.TinyInt).Value = byid;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }

    public bool UpdateQ(Model_QType q)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE QuestionsType SET Title=@Title,Status=@Status WHERE QTID=@QTID", cn);
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = q.Title;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = q.Status;
            cmd.Parameters.Add("@QTID", SqlDbType.TinyInt).Value = q.QTID;
            cn.Open();

            return ExecuteNonQuery(cmd) == 1;
        }
    }


    public int AddnewQ(Model_QType q)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO QuestionsType (Title,Status) VALUES(@Title,@Status)", cn);
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = q.Title;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = q.Status;
            cn.Open();

            return ExecuteNonQuery(cmd);
        }

    }
}

