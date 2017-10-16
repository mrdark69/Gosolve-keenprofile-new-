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
public class Model_UsersAssessment: BaseModel<Model_UsersAssessment>
{


    public int TASID { get; set; }

    public int TransactionID { get; set; }

    public int ASID { get; set; }
    public string Code { get; set; }
    public string Questions { get; set; }
    public int SCID { get; set; }
    public int SUCID { get; set; }

    public bool Status { get; set; }
    public bool IsHide { get; set; } = false;
    public byte QTID { get; set; }
    public int Priority { get; set; }
    public int StartRank { get; set; }
    public int EndRank { get; set; }
    public string GroupName { get; set; }
    public byte Side { get; set; }
    public string LeftScaleTitle { get; set; }
    public string RigthScaleTitle { get; set; }

    public int Score { get; set; }


    public string SectionTitle { get; set; }
    public int SectionPriority { get; set; }

    public string SubSectionTitle { get; set; }
    public string QuestionTypeTitle { get; set; }

    public int? ScoreUserRank { get; set; }

    public string Combind { get; set; }
    public int? SUCID2 { get; set; }
    public Model_UsersAssessment()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool UpdateUserAssbyID(int TASID,int Score, string Code)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE UserAssessment SET Score=@Score,Code=@Code WHERE TASID=@TASID", cn);
            cmd.Parameters.Add("@TASID", SqlDbType.Int).Value = TASID;
            cmd.Parameters.Add("@Score", SqlDbType.Int).Value = Score;
            cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = Code;
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
           
    }

    public bool UpdateUserRank(int intTASID, int Rank)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE UserAssessment SET ScoreUserRank=@ScoreUserRank WHERE TASID=@TASID", cn);
            cmd.Parameters.Add("@ScoreUserRank", SqlDbType.Int).Value = Rank;
            cmd.Parameters.Add("@TASID", SqlDbType.Int).Value = intTASID;
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
    }

    public List<Model_UsersAssessment> GetUserAssessmentByTsID(int TsID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT uss.*, ss.Title AS SectionTitle, 
            ss.Priority AS SectionPriority , su.Title AS SubSectionTitle, qs.Title AS QuestionTypeTitle
            FROM UserAssessment uss 
            LEFT JOIN Section ss ON ss.SCID = uss.SCID
            LEFT JOIN SubSection su ON su.SUCID = uss.SUCID
            LEFT JOIN QuestionsType qs ON qs.QTID = uss.QTID
            WHERE uss.TransactionID=@TransactionID
            ORDER BY ss.SCID, ss.Priority ASC, uss.Priority ASC", cn);
            cmd.Parameters.Add("@TransactionID", SqlDbType.Int).Value = TsID;
            cn.Open();

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));

        }
    }

    public int InsertUserAssessment(Model_UsersAssessment uass)
    {
        int ret = 0;

        Model_Assessment ass = new Model_Assessment();
        ass = ass.GetAssessmentByID(uass.ASID);

        if(ass != null)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO UserAssessment (TransactionID,Score,ASID,Code,Questions,SCID,SUCID,Status,IsHide,QTID,Priority,
                                    StartRank,EndRank,GroupName,Side,LeftScaleTitle,RigthScaleTitle,Combind,SUCID2) 
                            VALUES (@TransactionID,@Score,@ASID,@Code,@Questions,@SCID,@SUCID,@Status,@IsHide,@QTID,@Priority,
                    @StartRank,@EndRank,@GroupName,@Side,@LeftScaleTitle,@RigthScaleTitle,@Combind,@SUCID2);SET @TASID = SCOPE_IDENTITY();", cn);

                cn.Open();

                cmd.Parameters.Add("@TransactionID", SqlDbType.Int).Value = uass.TransactionID;
                cmd.Parameters.Add("@ASID", SqlDbType.Int).Value = uass.ASID;
                cmd.Parameters.Add("@Score", SqlDbType.Int).Value = uass.Score;


                cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = ass.Code;
                cmd.Parameters.Add("@Questions", SqlDbType.NVarChar).Value = ass.Questions;
                cmd.Parameters.Add("@SCID", SqlDbType.Int).Value = ass.SCID;
                cmd.Parameters.Add("@SUCID", SqlDbType.Int).Value = ass.SUCID;
                cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = ass.Status;
                cmd.Parameters.Add("@IsHide", SqlDbType.Bit).Value = ass.IsHide;
                cmd.Parameters.Add("@QTID", SqlDbType.TinyInt).Value = ass.QTID;
                cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = ass.Priority;
                cmd.Parameters.Add("@StartRank", SqlDbType.Int).Value = ass.StartRank;
                cmd.Parameters.Add("@EndRank", SqlDbType.Int).Value = ass.EndRank;
                cmd.Parameters.Add("@GroupName", SqlDbType.NVarChar).Value = ass.GroupName;
                cmd.Parameters.Add("@Side", SqlDbType.TinyInt).Value = ass.Side;
                cmd.Parameters.Add("@LeftScaleTitle", SqlDbType.NVarChar).Value = ass.LeftScaleTitle;
                cmd.Parameters.Add("@RigthScaleTitle", SqlDbType.NVarChar).Value = ass.RigthScaleTitle;

                cmd.Parameters.Add("@Combind", SqlDbType.VarChar).Value = ass.SubCombind;

                if (ass.SUCID2.HasValue)
                    cmd.Parameters.Add("@SUCID2", SqlDbType.Int).Value = ass.SUCID2;
                else
                    cmd.Parameters.AddWithValue("@SUCID2", DBNull.Value);


                cmd.Parameters.Add("@TASID", SqlDbType.Int).Direction = ParameterDirection.Output;


                if (ExecuteNonQuery(cmd) > 0)
                {
                    ret = (int)cmd.Parameters["@TASID"].Value;

                }

              

            }
        }
        return ret;
    }

}