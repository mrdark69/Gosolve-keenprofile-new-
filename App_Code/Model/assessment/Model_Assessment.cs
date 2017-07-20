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

public class Model_Assessment_Choice : BaseModel<Model_Assessment_Choice>
{
    public int ASCID { get; set; }
    public int ASID { get; set; }
    public string Questions { get; set; }
    public bool Status { get; set; }
    public int Priority { get; set; }

    public Model_Assessment_Choice()
    {

    }

    public List<Model_Assessment_Choice> GetAssessmentChoice(int ASID)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM AssessmentChoice WHERE ASID=@ASID AND Status = 1 ORDER BY Priority DESC", cn);
            cmd.Parameters.Add("@ASID", SqlDbType.Int).Value = ASID;
            cn.Open();

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }


    public int AddAssessmentChoice(List<Model_Assessment_Choice> list,int ASID)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM AssessmentChoice WHERE ASID=@ASID", cn);
            cmd.Parameters.Add("@ASID", SqlDbType.Int).Value = ASID;
            cn.Open();

            ret = ExecuteNonQuery(cmd);

            if(ret > 0)
            {
                foreach(Model_Assessment_Choice mm in list)
                {
                    SqlCommand cmd1 = new SqlCommand("DELETE FROM AssessmentChoice WHERE ASID=@ASID", cn);
                    cmd1.Parameters.Add("@ASID", SqlDbType.Int).Value = ASID;
                    cmd1.Parameters.Add("@Questions", SqlDbType.NVarChar).Value = mm.Questions;

                    cmd1.Parameters.Add("@Priority", SqlDbType.Int).Value = mm.Priority;

                    ret=  ExecuteNonQuery(cmd1);
                }
            }
        }

        return ret;
    }

}
public class Model_Assessment : BaseModel<Model_Assessment>
{
    public int ASID { get; set; }
    public string Code { get; set; }
    public string Questions { get; set; }
    public int SCID { get; set; }
    public int? SUCID { get; set; }

    public bool Status { get; set; }
    public bool IsHide { get; set; } = false;
    public byte QTID { get; set; }
    public int? SUCIDLF { get; set; }
    public int? SUCIDRT { get; set; }

    public int Priority { get; set; }


    public int StartRank { get; set; }
    public int EndRank { get; set; }


    public string SectionTitle { get; set; }
    private List<Model_Assessment_Choice> _asschoice = null;
    public List<Model_Assessment_Choice> AssChoice {

        get
        {
            if(_asschoice == null)
            {
                Model_Assessment_Choice assc = new Model_Assessment_Choice();
                _asschoice = assc.GetAssessmentChoice(this.ASID);
            }
            return _asschoice;
        }

        set
        {
            _asschoice = value;
        }
    }

    public Model_Assessment()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public int AddAssessment(Model_Assessment mu)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO Assessment (Code,Questions,SCID,SUCID,Status,IsHide,QTID,SUCIDLF,SUCIDRT,Priority,StartRank,EndRank) 
VALUES(@Code,@Questions,@SCID,@SUCID,@Status,@IsHide,@QTID,@SUCIDLF,@SUCIDRT,@Priority,@StartRank,@EndRank);SET @ASID = SCOPE_IDENTITY();", cn);
            cn.Open();
            cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = mu.Code;
            cmd.Parameters.Add("@Questions", SqlDbType.NVarChar).Value = mu.Questions;
            cmd.Parameters.Add("@SCID", SqlDbType.Int).Value = mu.SCID;


            if (mu.SUCID.HasValue)
                cmd.Parameters.Add("@SUCID", SqlDbType.Int).Value = mu.SUCID;
            else
                cmd.Parameters.AddWithValue("@SUCID", DBNull.Value);
       


            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = mu.Status;
            cmd.Parameters.Add("@IsHide", SqlDbType.Bit).Value = mu.IsHide;
            cmd.Parameters.Add("@QTID", SqlDbType.TinyInt).Value = mu.QTID;

            if (mu.SUCIDLF.HasValue)
                cmd.Parameters.Add("@SUCIDLF", SqlDbType.Int).Value = mu.SUCIDLF;
            else
                cmd.Parameters.AddWithValue("@SUCIDLF", DBNull.Value);

            if (mu.SUCIDRT.HasValue)
                cmd.Parameters.Add("@SUCIDRT", SqlDbType.Int).Value = mu.SUCIDRT;
            else
                cmd.Parameters.AddWithValue("@SUCIDRT", DBNull.Value);

            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = mu.Priority;

            cmd.Parameters.Add("@StartRank", SqlDbType.Int).Value = mu.StartRank;
            cmd.Parameters.Add("@EndRank", SqlDbType.Int).Value = mu.EndRank;

            cmd.Parameters.Add("@ASID", SqlDbType.Int).Direction = ParameterDirection.Output;

            if (ExecuteNonQuery(cmd) > 0)
            {
                ret = (int)cmd.Parameters["@ASID"].Value;

            }
        }
        return ret;
    }

    public bool Update(Model_Assessment mu)
    {
   
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE Assessment SET Code=@Code, Questions=@Questions, SCID=@SCID, SUCID=@SUCID, 

Status =@Status,IsHide=@IsHide,QTID=@QTID ,SUCIDLF=@SUCIDLF, SUCIDRT=@SUCIDRT,Priority=@Priority, StartRank=@StartRank,EndRank=@EndRank WHERE ASID=@ASID", cn);

            cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = mu.Code;
            cmd.Parameters.Add("@Questions", SqlDbType.NVarChar).Value = mu.Questions;
            cmd.Parameters.Add("@SCID", SqlDbType.Int).Value = mu.SCID;
            if (mu.SUCID.HasValue)
                cmd.Parameters.Add("@SUCID", SqlDbType.Int).Value = mu.SUCID;
            else
                cmd.Parameters.AddWithValue("@SUCID", DBNull.Value);
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = mu.Status;
            cmd.Parameters.Add("@IsHide", SqlDbType.Bit).Value = mu.IsHide;
            cmd.Parameters.Add("@QTID", SqlDbType.TinyInt).Value = mu.QTID;

            if (mu.SUCIDLF.HasValue)
                cmd.Parameters.Add("@SUCIDLF", SqlDbType.Int).Value = mu.SUCIDLF;
            else
                cmd.Parameters.AddWithValue("@SUCIDLF", DBNull.Value);

            if (mu.SUCIDRT.HasValue)
                cmd.Parameters.Add("@SUCIDRT", SqlDbType.Int).Value = mu.SUCIDRT;
            else
                cmd.Parameters.AddWithValue("@SUCIDRT", DBNull.Value);

            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = mu.Priority;

            cmd.Parameters.Add("@StartRank", SqlDbType.Int).Value = mu.StartRank;
            cmd.Parameters.Add("@EndRank", SqlDbType.Int).Value = mu.EndRank;

            cmd.Parameters.Add("@ASID", SqlDbType.Int).Value = mu.ASID;

            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
       
    }



    public Model_Assessment GetAssessmentByID(int ASID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Assessment WHERE ASID= @ASID", cn);
            cmd.Parameters.Add("@ASID", SqlDbType.Int).Value = ASID;
            cn.Open();

            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }

    public List<Model_Assessment> GetAssessment(Model_Assessment mu)
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
            cText.Append(@"SELECT u.*,ur.Title AS SectionTitle FROM  Assessment u 
INNER JOIN Section ur ON ur.SCID =u.SCID " + w  + " ORDER BY Priority ASC");

            cmd.CommandText = cText.ToString();
            cmd.Connection = cn;


            cn.Open();

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }


   

}