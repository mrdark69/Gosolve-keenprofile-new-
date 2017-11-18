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
public class Model_ReportItemResult : BaseModel<Model_ReportItemResult>
{
    public int ResultID { get; set; }
    public int ResultSectionID { get; set; }
    public int ResultItemID { get; set; }
    public int TransactionID { get; set; }
    public decimal Score { get; set; }
    public bool IsAbove { get; set; } = false;
    public bool IsBelow { get; set; } = false;
    public decimal? Score_new { get; set; }
    public int? TASID { get; set; }
    public int? TASCID { get; set; }
    public string Detail { get; set; } = string.Empty;


    public decimal IsDup { get; set; } = 0.0m;

    public decimal? Division1 { get; set; } = 0.0m;
    public decimal? Division2 { get; set; } = 0.0m;
    public decimal? Division3 { get; set; } = 0.0m;
    public decimal? Division4 { get; set; } = 0.0m;

    public int? UserRank { get; set; }
    public int? AutoRank4 { get; set; }
    public int? AutoRank1 { get; set; }
    public int? AutoRank2 { get; set; }
    public int? AutoRank3{ get; set; }

    private string[] arr_raw = null;
    public string [] ArrRaw
    {
        get
        {
            if(arr_raw == null && !String.IsNullOrEmpty(this.Detail))
            {
                arr_raw = this.Detail.Trim().Split(',');
            }

            return arr_raw;
        }
    }

    public string G1 { get { return this.ArrRaw[0]; } }
    public string G2 { get { return this.ArrRaw[1]; } }
    public string G3 { get { return this.ArrRaw[2]; } }
    public string G4 { get { return this.ArrRaw[3]; } }

    public decimal? Factor { get; set; }

    public int? GT { get; set; }
    public decimal? IdealScore { get; set; }
    public decimal? RqScore { get; set; }
    public decimal? ResultScore { get; set; }
    public string Result { get; set; }

    public int? UseAtWork { get; set; }


    public byte? Frequency_y { get; set; }
    public byte? Frequency_c { get; set; }
    public byte? Side_y { get; set; }
    public byte? Side_c { get; set; }
    public string T5Group { get; set; } = string.Empty;

    public decimal? Score_y { get; set; }

    public decimal? Score_c { get; set; }

    public byte? FitOrNot { get; set; }

    public string ResultItemTitle { get; set; }


    public decimal? SumGeniuses { get; set; }
    public decimal? ReqSupGeniuses { get; set; }
    public decimal? ReqSupBottom { get; set; }
    public decimal? SumTrait { get; set; }
    public decimal? MatchingScore { get; set; }
    public decimal? JobPri_A { get; set; }
    public decimal? JobPri_B { get; set; }
    public decimal? JobPri_C { get; set; }
    public decimal? JobPri_D { get; set; }
    public decimal? SumJob { get; set; }
    public decimal? JobFitScore { get; set; }
    public decimal? JobFitScoreRank { get; set; }

    public int CountSup { get; set; }
    public int CountBottom { get; set; }

    public string des_Short { get; set; }
    public string des_Detail { get; set; }
    public string des_PeopleTxt { get; set; }
    public string des_CultureTxt { get; set; }
    public string des_CompetitionTxt { get; set; }


    public List<Model_ReportItemResult> GetItemReportByTransactionIDwithTitle(int TransactionId)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT rr.*,ri.Title AS ResultItemTitle,ri.Detail AS des_Detail,ri.PeopleTxt AS des_PeopleTxt 
,ri.CultureTxt AS des_CultureTxt,ri.CompetitionTxt AS des_CompetitionTxt, ri.Short AS des_Short FROM ReportItemResult rr 
INNER JOIN ReportSectionItem ri ON ri.ResultItemID = rr.ResultItemID 
 WHERE rr.TransactionID=@TransactionID ", cn);
            cmd.Parameters.Add("@TransactionID", SqlDbType.Int).Value = TransactionId;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public List<Model_ReportItemResult> GetItemReportByTransactionID(int TransactionId)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM ReportItemResult WHERE TransactionID=@TransactionID", cn);
            cmd.Parameters.Add("@TransactionID", SqlDbType.Int).Value = TransactionId;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }
    public List<Model_ReportItemResult> GetItemReportByTransactionID(int TransactionId, int ResultSectionID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM ReportItemResult WHERE TransactionID=@TransactionID AND ResultSectionID=@ResultSectionID", cn);
            cmd.Parameters.Add("@TransactionID", SqlDbType.Int).Value = TransactionId;
            cmd.Parameters.Add("@ResultSectionID", SqlDbType.Int).Value = ResultSectionID;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }


    public bool UpdateUserRank(int intResultID, int Rank)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE ReportItemResult SET UserRank=@UserRank WHERE ResultID=@ResultID", cn);
            cmd.Parameters.Add("@UserRank", SqlDbType.Int).Value = Rank;
            cmd.Parameters.Add("@ResultID", SqlDbType.Int).Value = intResultID;
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
    }
    

    public bool InsertReportItemResultBulk(List<Model_ReportItemResult> reList)
    {
        bool ret = false;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            cn.Open();
            foreach (Model_ReportItemResult re in reList)
            {

 


    SqlCommand cmdupdate = new SqlCommand(@"UPDATE  ReportItemResult SET Score=@Score,IsAbove=@IsAbove,IsBelow=@IsBelow,Score_new=@Score_new
,TASID=@TASID, TASCID=@TASCID, Detail=@Detail,Factor=@Factor,IsDup=@IsDup ,AutoRank4=@AutoRank4,AutoRank1=@AutoRank1,AutoRank2=@AutoRank2,AutoRank3=@AutoRank3
,Division1=@Division1,Division2=@Division2,Division3=@Division3,Division4=@Division4,GT=@GT,IdealScore=@IdealScore,RqScore=@RqScore,ResultScore=@ResultScore,Result=@Result,UseAtWork=@UseAtWork,Frequency_y=@Frequency_y,Frequency_c=@Frequency_c,Side_y=@Side_y,T5Group=@T5Group,Score_y=@Score_y, Score_c=@Score_c,Side_c=@Side_c,FitOrNot=@FitOrNot ,UserRank=@UserRank,SumGeniuses=@SumGeniuses,ReqSupGeniuses=@ReqSupGeniuses,ReqSupBottom=@ReqSupBottom,
SumTrait=@SumTrait,MatchingScore=@MatchingScore,JobPri_A=@JobPri_A,JobPri_B=@JobPri_B,JobPri_C=@JobPri_C,
JobPri_D=@JobPri_D,SumJob=@SumJob,JobFitScore=@JobFitScore,JobFitScoreRank=@JobFitScoreRank 
  WHERE ResultSectionID=@ResultSectionID AND ResultItemID=@ResultItemID AND TransactionID=@TransactionID;
                ", cn);

                cmdupdate.Parameters.Add("@ResultSectionID", SqlDbType.Int).Value = re.ResultSectionID;
                cmdupdate.Parameters.Add("@ResultItemID", SqlDbType.Int).Value = re.ResultItemID;
                cmdupdate.Parameters.Add("@TransactionID", SqlDbType.Int).Value = re.TransactionID;

                cmdupdate.Parameters.Add("@Score", SqlDbType.Decimal).Value = re.Score;

                if (re.Score_new.HasValue)
                    cmdupdate.Parameters.Add("@Score_new", SqlDbType.Decimal).Value = re.Score_new;
                else
                    cmdupdate.Parameters.AddWithValue("@Score_new", DBNull.Value);

                if (re.TASID.HasValue)
                    cmdupdate.Parameters.Add("@TASID", SqlDbType.Int).Value = re.TASID;
                else
                    cmdupdate.Parameters.AddWithValue("@TASID", DBNull.Value);

                if (re.TASCID.HasValue)
                    cmdupdate.Parameters.Add("@TASCID", SqlDbType.Int).Value = re.TASCID;
                else
                    cmdupdate.Parameters.AddWithValue("@TASCID", DBNull.Value);

                if (re.AutoRank4.HasValue)
                    cmdupdate.Parameters.Add("@AutoRank4", SqlDbType.Int).Value = re.AutoRank4;
                else
                    cmdupdate.Parameters.AddWithValue("@AutoRank4", DBNull.Value);

                if (re.AutoRank1.HasValue)
                    cmdupdate.Parameters.Add("@AutoRank1", SqlDbType.Int).Value = re.AutoRank1;
                else
                    cmdupdate.Parameters.AddWithValue("@AutoRank1", DBNull.Value);

                if (re.AutoRank2.HasValue)
                    cmdupdate.Parameters.Add("@AutoRank2", SqlDbType.Int).Value = re.AutoRank2;
                else
                    cmdupdate.Parameters.AddWithValue("@AutoRank2", DBNull.Value);

                if (re.AutoRank3.HasValue)
                    cmdupdate.Parameters.Add("@AutoRank3", SqlDbType.Int).Value = re.AutoRank3;
                else
                    cmdupdate.Parameters.AddWithValue("@AutoRank3", DBNull.Value);


                if (re.Factor.HasValue)
                    cmdupdate.Parameters.Add("@Factor", SqlDbType.Decimal).Value = re.Factor;
                else
                    cmdupdate.Parameters.AddWithValue("@Factor", DBNull.Value);


                if (re.Division1.HasValue)
                    cmdupdate.Parameters.Add("@Division1", SqlDbType.Decimal).Value = re.Division1;
                else
                    cmdupdate.Parameters.AddWithValue("@Division1", DBNull.Value);

                if (re.Division2.HasValue)
                    cmdupdate.Parameters.Add("@Division2", SqlDbType.Decimal).Value = re.Division2;
                else
                    cmdupdate.Parameters.AddWithValue("@Division2", DBNull.Value);

                if (re.Division3.HasValue)
                    cmdupdate.Parameters.Add("@Division3", SqlDbType.Decimal).Value = re.Division3;
                else
                    cmdupdate.Parameters.AddWithValue("@Division3", DBNull.Value);

                if (re.Division4.HasValue)
                    cmdupdate.Parameters.Add("@Division4", SqlDbType.Decimal).Value = re.Division4;
                else
                    cmdupdate.Parameters.AddWithValue("@Division4", DBNull.Value);


                if (re.GT.HasValue)
                    cmdupdate.Parameters.Add("@GT", SqlDbType.Int).Value = re.GT;
                else
                    cmdupdate.Parameters.AddWithValue("@GT", DBNull.Value);

                if (re.IdealScore.HasValue)
                    cmdupdate.Parameters.Add("@IdealScore", SqlDbType.Decimal).Value = re.IdealScore;
                else
                    cmdupdate.Parameters.AddWithValue("@IdealScore", DBNull.Value);

                if (re.RqScore.HasValue)
                    cmdupdate.Parameters.Add("@RqScore", SqlDbType.Decimal).Value = re.RqScore;
                else
                    cmdupdate.Parameters.AddWithValue("@RqScore", DBNull.Value);

                if (re.ResultScore.HasValue)
                    cmdupdate.Parameters.Add("@ResultScore", SqlDbType.Decimal).Value = re.ResultScore;
                else
                    cmdupdate.Parameters.AddWithValue("@ResultScore", DBNull.Value);

                if (!string.IsNullOrEmpty(re.Result))
                    cmdupdate.Parameters.Add("@Result", SqlDbType.VarChar).Value = re.Result;
                else
                    cmdupdate.Parameters.AddWithValue("@Result", DBNull.Value);

                if (re.UseAtWork.HasValue)
                    cmdupdate.Parameters.Add("@UseAtWork", SqlDbType.Int).Value = re.UseAtWork;
                else
                    cmdupdate.Parameters.AddWithValue("@UseAtWork", DBNull.Value);

                if (re.UserRank.HasValue)
                    cmdupdate.Parameters.Add("@UserRank", SqlDbType.Int).Value = re.UserRank;
                else
                    cmdupdate.Parameters.AddWithValue("@UserRank", DBNull.Value);
                

                if (re.Frequency_y.HasValue)
                    cmdupdate.Parameters.Add("@Frequency_y", SqlDbType.TinyInt).Value = re.Frequency_y;
                else
                    cmdupdate.Parameters.AddWithValue("@Frequency_y", DBNull.Value);

                if (re.Frequency_c.HasValue)
                    cmdupdate.Parameters.Add("@Frequency_c", SqlDbType.TinyInt).Value = re.Frequency_c;
                else
                    cmdupdate.Parameters.AddWithValue("@Frequency_c", DBNull.Value);

                if (re.Side_y.HasValue)
                    cmdupdate.Parameters.Add("@Side_y", SqlDbType.TinyInt).Value = re.Side_y;
                else
                    cmdupdate.Parameters.AddWithValue("@Side_y", DBNull.Value);

                if (re.Side_c.HasValue)
                    cmdupdate.Parameters.Add("@Side_c", SqlDbType.TinyInt).Value = re.Side_c;
                else
                    cmdupdate.Parameters.AddWithValue("@Side_c", DBNull.Value);

                cmdupdate.Parameters.Add("@T5Group", SqlDbType.NVarChar).Value = re.T5Group;
              

                if (re.Score_y.HasValue)
                    cmdupdate.Parameters.Add("@Score_y", SqlDbType.Decimal).Value = re.Score_y;
                else
                    cmdupdate.Parameters.AddWithValue("@Score_y", DBNull.Value);

                if (re.Score_c.HasValue)
                    cmdupdate.Parameters.Add("@Score_c", SqlDbType.Decimal).Value = re.Score_c;
                else
                    cmdupdate.Parameters.AddWithValue("@Score_c", DBNull.Value);

                if (re.FitOrNot.HasValue)
                    cmdupdate.Parameters.Add("@FitOrNot", SqlDbType.TinyInt).Value = re.FitOrNot;
                else
                    cmdupdate.Parameters.AddWithValue("@FitOrNot", DBNull.Value);
                

                cmdupdate.Parameters.Add("@IsDup", SqlDbType.Decimal).Value = re.IsDup;

                cmdupdate.Parameters.Add("@IsAbove", SqlDbType.Bit).Value = re.IsAbove;
                cmdupdate.Parameters.Add("@IsBelow", SqlDbType.Bit).Value = re.IsBelow;

                cmdupdate.Parameters.Add("@Detail", SqlDbType.VarChar).Value = re.Detail;



                if (re.SumGeniuses.HasValue)
                    cmdupdate.Parameters.Add("@SumGeniuses", SqlDbType.Decimal).Value = re.SumGeniuses;
                else
                    cmdupdate.Parameters.AddWithValue("@SumGeniuses", DBNull.Value);


                if (re.ReqSupGeniuses.HasValue)
                    cmdupdate.Parameters.Add("@ReqSupGeniuses", SqlDbType.Decimal).Value = re.ReqSupGeniuses;
                else
                    cmdupdate.Parameters.AddWithValue("@ReqSupGeniuses", DBNull.Value);


                if (re.ReqSupBottom.HasValue)
                    cmdupdate.Parameters.Add("@ReqSupBottom", SqlDbType.Decimal).Value = re.ReqSupBottom;
                else
                    cmdupdate.Parameters.AddWithValue("@ReqSupBottom", DBNull.Value);


                if (re.SumTrait.HasValue)
                    cmdupdate.Parameters.Add("@SumTrait", SqlDbType.Decimal).Value = re.SumTrait;
                else
                    cmdupdate.Parameters.AddWithValue("@SumTrait", DBNull.Value);


                if (re.MatchingScore.HasValue)
                    cmdupdate.Parameters.Add("@MatchingScore", SqlDbType.Decimal).Value = re.MatchingScore;
                else
                    cmdupdate.Parameters.AddWithValue("@MatchingScore", DBNull.Value);


                if (re.JobPri_A.HasValue)
                    cmdupdate.Parameters.Add("@JobPri_A", SqlDbType.Decimal).Value = re.JobPri_A;
                else
                    cmdupdate.Parameters.AddWithValue("@JobPri_A", DBNull.Value);


                if (re.JobPri_B.HasValue)
                    cmdupdate.Parameters.Add("@JobPri_B", SqlDbType.Decimal).Value = re.JobPri_B;
                else
                    cmdupdate.Parameters.AddWithValue("@JobPri_B", DBNull.Value);


                if (re.JobPri_C.HasValue)
                    cmdupdate.Parameters.Add("@JobPri_C", SqlDbType.Decimal).Value = re.JobPri_C;
                else
                    cmdupdate.Parameters.AddWithValue("@JobPri_C", DBNull.Value);


                if (re.JobPri_D.HasValue)
                    cmdupdate.Parameters.Add("@JobPri_D", SqlDbType.Decimal).Value = re.JobPri_D;
                else
                    cmdupdate.Parameters.AddWithValue("@JobPri_D", DBNull.Value);


                if (re.SumJob.HasValue)
                    cmdupdate.Parameters.Add("@SumJob", SqlDbType.Decimal).Value = re.SumJob;
                else
                    cmdupdate.Parameters.AddWithValue("@SumJob", DBNull.Value);


                if (re.JobFitScore.HasValue)
                    cmdupdate.Parameters.Add("@JobFitScore", SqlDbType.Decimal).Value = re.JobFitScore;
                else
                    cmdupdate.Parameters.AddWithValue("@JobFitScore", DBNull.Value);


                if (re.JobFitScoreRank.HasValue)
                    cmdupdate.Parameters.Add("@JobFitScoreRank", SqlDbType.Decimal).Value = re.JobFitScoreRank;
                else
                    cmdupdate.Parameters.AddWithValue("@JobFitScoreRank", DBNull.Value);


                //DELETE FROM ReportItemResult WHERE ResultSectionID = @ResultSectionID AND ResultItemID = @ResultItemID AND TransactionID = @TransactionID;
                if (ExecuteNonQuery(cmdupdate) == 0)
                {
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO ReportItemResult (ResultSectionID,ResultItemID,TransactionID,Score,IsAbove,IsBelow,Score_new,TASID,TASCID,Detail,Factor,IsDup,AutoRank4,AutoRank1,AutoRank2,AutoRank3,Division1,Division2,Division3,Division4,GT,IdealScore,RqScore,ResultScore,Result,UseAtWork,Frequency_y,Frequency_c,
Side_c,T5Group,Score_y,Score_c,Side_y,FitOrNot,UserRank,SumGeniuses,ReqSupGeniuses,ReqSupBottom,SumTrait,MatchingScore,JobPri_A,JobPri_B,JobPri_C,JobPri_D,SumJob,JobFitScore,JobFitScoreRank) 
                VALUES(@ResultSectionID,@ResultItemID,@TransactionID,@Score,@IsAbove,@IsBelow,@Score_new,@TASID,@TASCID,@Detail,@Factor,@IsDup,@AutoRank4,@AutoRank1,@AutoRank2,@AutoRank3,@Division1,@Division2,@Division3,@Division4,@GT,@IdealScore,@RqScore,@ResultScore,@Result,@UseAtWork,@Frequency_y,@Frequency_c,@Side_c,@T5Group,@Score_y,@Score_c,@Side_y,@FitOrNot,@UserRank,@SumGeniuses,@ReqSupGeniuses,@ReqSupBottom,@SumTrait,@MatchingScore,@JobPri_A,@JobPri_B,@JobPri_C,@JobPri_D,@SumJob,@JobFitScore,@JobFitScoreRank)", cn);
                    //             public int? GT { get; set; }
                    //public decimal? IdealScore { get; set; }
                    //public decimal? RqScore { get; set; }
                    //public decimal? ResultScore { get; set; }
                    //public string Result { get; set; }

                    cmd.Parameters.Add("@ResultSectionID", SqlDbType.Int).Value = re.ResultSectionID;
                    cmd.Parameters.Add("@ResultItemID", SqlDbType.Int).Value = re.ResultItemID;
                    cmd.Parameters.Add("@TransactionID", SqlDbType.Int).Value = re.TransactionID;

                    cmd.Parameters.Add("@Score", SqlDbType.Decimal).Value = re.Score;

                    if (re.Score_new.HasValue)
                        cmd.Parameters.Add("@Score_new", SqlDbType.Decimal).Value = re.Score_new;
                    else
                        cmd.Parameters.AddWithValue("@Score_new", DBNull.Value);

                    if (re.TASID.HasValue)
                        cmd.Parameters.Add("@TASID", SqlDbType.Int).Value = re.TASID;
                    else
                        cmd.Parameters.AddWithValue("@TASID", DBNull.Value);

                    if (re.AutoRank4.HasValue)
                        cmd.Parameters.Add("@AutoRank4", SqlDbType.Int).Value = re.AutoRank4;
                    else
                        cmd.Parameters.AddWithValue("@AutoRank4", DBNull.Value);

                    if (re.AutoRank1.HasValue)
                        cmd.Parameters.Add("@AutoRank1", SqlDbType.Int).Value = re.AutoRank1;
                    else
                        cmd.Parameters.AddWithValue("@AutoRank1", DBNull.Value);

                    if (re.AutoRank2.HasValue)
                        cmd.Parameters.Add("@AutoRank2", SqlDbType.Int).Value = re.AutoRank2;
                    else
                        cmd.Parameters.AddWithValue("@AutoRank2", DBNull.Value);

                    if (re.AutoRank3.HasValue)
                        cmd.Parameters.Add("@AutoRank3", SqlDbType.Int).Value = re.AutoRank3;
                    else
                        cmd.Parameters.AddWithValue("@AutoRank3", DBNull.Value);

                    if (re.TASCID.HasValue)
                        cmd.Parameters.Add("@TASCID", SqlDbType.Int).Value = re.TASCID;
                    else
                        cmd.Parameters.AddWithValue("@TASCID", DBNull.Value);

                    if (re.Factor.HasValue)
                        cmd.Parameters.Add("@Factor", SqlDbType.Decimal).Value = re.Factor;
                    else
                        cmd.Parameters.AddWithValue("@Factor", DBNull.Value);

                    if (re.Division1.HasValue)
                        cmd.Parameters.Add("@Division1", SqlDbType.Decimal).Value = re.Division1;
                    else
                        cmd.Parameters.AddWithValue("@Division1", DBNull.Value);

                    if (re.Division2.HasValue)
                        cmd.Parameters.Add("@Division2", SqlDbType.Decimal).Value = re.Division2;
                    else
                        cmd.Parameters.AddWithValue("@Division2", DBNull.Value);

                    if (re.Division3.HasValue)
                        cmd.Parameters.Add("@Division3", SqlDbType.Decimal).Value = re.Division3;
                    else
                        cmd.Parameters.AddWithValue("@Division3", DBNull.Value);

                    if (re.Division4.HasValue)
                        cmd.Parameters.Add("@Division4", SqlDbType.Decimal).Value = re.Division4;
                    else
                        cmd.Parameters.AddWithValue("@Division4", DBNull.Value);

                    if (re.UserRank.HasValue)
                        cmd.Parameters.Add("@UserRank", SqlDbType.Int).Value = re.UserRank;
                    else
                        cmd.Parameters.AddWithValue("@UserRank", DBNull.Value);

                    if (re.GT.HasValue)
                        cmd.Parameters.Add("@GT", SqlDbType.Int).Value = re.GT;
                    else
                        cmd.Parameters.AddWithValue("@GT", DBNull.Value);

                    if (re.IdealScore.HasValue)
                        cmd.Parameters.Add("@IdealScore", SqlDbType.Decimal).Value = re.IdealScore;
                    else
                        cmd.Parameters.AddWithValue("@IdealScore", DBNull.Value);

                    if (re.RqScore.HasValue)
                        cmd.Parameters.Add("@RqScore", SqlDbType.Decimal).Value = re.RqScore;
                    else
                        cmd.Parameters.AddWithValue("@RqScore", DBNull.Value);

                    if (re.ResultScore.HasValue)
                        cmd.Parameters.Add("@ResultScore", SqlDbType.Decimal).Value = re.ResultScore;
                    else
                        cmd.Parameters.AddWithValue("@ResultScore", DBNull.Value);

                    if (!string.IsNullOrEmpty(re.Result))
                        cmd.Parameters.Add("@Result", SqlDbType.VarChar).Value = re.Result;
                    else
                        cmd.Parameters.AddWithValue("@Result", DBNull.Value);


                    if (re.UseAtWork.HasValue)
                        cmd.Parameters.Add("@UseAtWork", SqlDbType.Int).Value = re.UseAtWork;
                    else
                        cmd.Parameters.AddWithValue("@UseAtWork", DBNull.Value);



                    if (re.Frequency_y.HasValue)
                        cmd.Parameters.Add("@Frequency_y", SqlDbType.TinyInt).Value = re.Frequency_y;
                    else
                        cmd.Parameters.AddWithValue("@Frequency_y", DBNull.Value);

                    if (re.Frequency_c.HasValue)
                        cmd.Parameters.Add("@Frequency_c", SqlDbType.TinyInt).Value = re.Frequency_c;
                    else
                        cmd.Parameters.AddWithValue("@Frequency_c", DBNull.Value);

                    if (re.Side_y.HasValue)
                        cmd.Parameters.Add("@Side_y", SqlDbType.TinyInt).Value = re.Side_y;
                    else
                        cmd.Parameters.AddWithValue("@Side_y", DBNull.Value);

                    if (re.Side_c.HasValue)
                        cmd.Parameters.Add("@Side_c", SqlDbType.TinyInt).Value = re.Side_c;
                    else
                        cmd.Parameters.AddWithValue("@Side_c", DBNull.Value);


                    cmd.Parameters.Add("@T5Group", SqlDbType.NVarChar).Value = re.T5Group;
                  
                    if (re.Score_y.HasValue)
                        cmd.Parameters.Add("@Score_y", SqlDbType.Decimal).Value = re.Score_y;
                    else
                        cmd.Parameters.AddWithValue("@Score_y", DBNull.Value);

                    if (re.Score_c.HasValue)
                        cmd.Parameters.Add("@Score_c", SqlDbType.Decimal).Value = re.Score_c;
                    else
                        cmd.Parameters.AddWithValue("@Score_c", DBNull.Value);

                    if (re.FitOrNot.HasValue)
                        cmd.Parameters.Add("@FitOrNot", SqlDbType.TinyInt).Value = re.FitOrNot;
                    else
                        cmd.Parameters.AddWithValue("@FitOrNot", DBNull.Value);

                    cmd.Parameters.Add("@IsDup", SqlDbType.Decimal).Value = re.IsDup;

                    cmd.Parameters.Add("@IsAbove", SqlDbType.Bit).Value = re.IsAbove;
                    cmd.Parameters.Add("@IsBelow", SqlDbType.Bit).Value = re.IsBelow;

                    cmd.Parameters.Add("@Detail", SqlDbType.VarChar).Value = re.Detail;




                    if (re.SumGeniuses.HasValue)
                        cmd.Parameters.Add("@SumGeniuses", SqlDbType.Decimal).Value = re.SumGeniuses;
                    else
                        cmd.Parameters.AddWithValue("@SumGeniuses", DBNull.Value);

                    if (re.ReqSupGeniuses.HasValue)
                        cmd.Parameters.Add("@ReqSupGeniuses", SqlDbType.Decimal).Value = re.ReqSupGeniuses;
                    else
                        cmd.Parameters.AddWithValue("@ReqSupGeniuses", DBNull.Value);

                    if (re.ReqSupBottom.HasValue)
                        cmd.Parameters.Add("@ReqSupBottom", SqlDbType.Decimal).Value = re.ReqSupBottom;
                    else
                        cmd.Parameters.AddWithValue("@ReqSupBottom", DBNull.Value);

                    if (re.SumTrait.HasValue)
                        cmd.Parameters.Add("@SumTrait", SqlDbType.Decimal).Value = re.SumTrait;
                    else
                        cmd.Parameters.AddWithValue("@SumTrait", DBNull.Value);

                    if (re.MatchingScore.HasValue)
                        cmd.Parameters.Add("@MatchingScore", SqlDbType.Decimal).Value = re.MatchingScore;
                    else
                        cmd.Parameters.AddWithValue("@MatchingScore", DBNull.Value);

                    if (re.JobPri_A.HasValue)
                        cmd.Parameters.Add("@JobPri_A", SqlDbType.Decimal).Value = re.JobPri_A;
                    else
                        cmd.Parameters.AddWithValue("@JobPri_A", DBNull.Value);

                    if (re.JobPri_B.HasValue)
                        cmd.Parameters.Add("@JobPri_B", SqlDbType.Decimal).Value = re.JobPri_B;
                    else
                        cmd.Parameters.AddWithValue("@JobPri_B", DBNull.Value);

                    if (re.JobPri_C.HasValue)
                        cmd.Parameters.Add("@JobPri_C", SqlDbType.Decimal).Value = re.JobPri_C;
                    else
                        cmd.Parameters.AddWithValue("@JobPri_C", DBNull.Value);

                    if (re.JobPri_D.HasValue)
                        cmd.Parameters.Add("@JobPri_D", SqlDbType.Decimal).Value = re.JobPri_D;
                    else
                        cmd.Parameters.AddWithValue("@JobPri_D", DBNull.Value);

                    if (re.SumJob.HasValue)
                        cmd.Parameters.Add("@SumJob", SqlDbType.Decimal).Value = re.SumJob;
                    else
                        cmd.Parameters.AddWithValue("@SumJob", DBNull.Value);

                    if (re.JobFitScore.HasValue)
                        cmd.Parameters.Add("@JobFitScore", SqlDbType.Decimal).Value = re.JobFitScore;
                    else
                        cmd.Parameters.AddWithValue("@JobFitScore", DBNull.Value);

                    if (re.JobFitScoreRank.HasValue)
                        cmd.Parameters.Add("@JobFitScoreRank", SqlDbType.Decimal).Value = re.JobFitScoreRank;
                    else
                        cmd.Parameters.AddWithValue("@JobFitScoreRank", DBNull.Value);

                    ret = ExecuteNonQuery(cmd) == 1;
                }
                else
                    ret = true;



            }




            return ret;
        }
    }

    //public int InsertReportItemResult(Model_ReportItemResult re)
    //{
    //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
    //    {
    //        SqlCommand cmd = new SqlCommand(@"INSERT INTO ReportItemResult (ResultSectionID,ResultItemID,TransactionID,Score,Score_new,TASID,Detail,Factor,IsDup) 
    //            VALUES(@ResultSectionID,@ResultItemID,@TransactionID,@Score,@Score_new,@TASID,@Detail,@Factor,@IsDup)", cn);
    //        cn.Open();
    //        cmd.Parameters.Add("@ResultSectionID", SqlDbType.Int).Value = re.ResultSectionID;
    //        cmd.Parameters.Add("@ResultItemID", SqlDbType.Int).Value = re.ResultItemID;
    //        cmd.Parameters.Add("@TransactionID", SqlDbType.Int).Value = re.TransactionID;
    //        cmd.Parameters.Add("@Score", SqlDbType.Decimal).Value = re.Score;
    //        if (re.Score_new.HasValue)
    //            cmd.Parameters.Add("@Score_new", SqlDbType.Decimal).Value = re.Score_new;
    //        else
    //            cmd.Parameters.AddWithValue("@Score_new", DBNull.Value);

    //        if (re.TASID.HasValue)
    //            cmd.Parameters.Add("@TASID", SqlDbType.Int).Value = re.TASID;
    //        else
    //            cmd.Parameters.AddWithValue("@TASID", DBNull.Value);

    //        if (re.Factor.HasValue)
    //            cmd.Parameters.Add("@Factor", SqlDbType.Decimal).Value = re.Factor;
    //        else
    //            cmd.Parameters.AddWithValue("@Factor", DBNull.Value);

    //        cmd.Parameters.Add("@IsDup", SqlDbType.Decimal).Value = re.IsDup;


    //        cmd.Parameters.Add("@Detail", SqlDbType.VarChar).Value = re.Detail;
    //        cn.Open();

    //        return ExecuteNonQuery(cmd);
    //    }
    //}
}
public class Model_ReportSectionItem : BaseModel<Model_ReportSectionItem>
{
    public int ResultItemID { get; set; }
    public int ResultSectionID { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }
    public bool Status { get; set; }
    public int Priority { get; set; }
    public string SUCID { get; set; }

    public string Short { get; set; }
    public string Detail { get; set; }

    public string PeopleTxt { get; set; } = string.Empty;
    public string CultureTxt { get; set; } = string.Empty;
    public string CompetitionTxt { get; set; } = string.Empty;

    public string SectionTitle { get; set; }

    public Model_ReportSectionItem()
    {

    }


    public List<Model_ReportSectionItem> GetListItem(int intResultSectionID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            string query = string.Empty;
            string w = string.Empty;
            if (intResultSectionID > 0)
            {
                w = " WHERE u.ResultSectionID =@ResultSectionID";
                cmd.Parameters.Add("@ResultSectionID", SqlDbType.Int).Value = intResultSectionID;

            }

            query = @"SELECT u.*, ss.Title AS SectionTitle FROM ReportSectionItem u INNER JOIN ReportSection ss 
    ON ss.ResultSectionID = u.ResultSectionID " + w+" ORDER BY Priority ASC";
            

            cmd.CommandText = query;
            cmd.Connection = cn;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));

        }
    }

    public List<Model_ReportSectionItem> GetListItemBySectionID(int intResultSectionID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            string query = string.Empty;
            string w = string.Empty;
           
            query = @"SELECT u.* FROM ReportSectionItem u WHERE u.ResultSectionID =@ResultSectionID AND Status = 1 ORDER BY Priority ASC";
            cmd.Parameters.Add("@ResultSectionID", SqlDbType.Int).Value = intResultSectionID;

            cmd.CommandText = query;
            cmd.Connection = cn;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));

        }
    }

    public Model_ReportSectionItem GetReportSectionItemByID(int intResultItemID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM ReportSectionItem WHERE ResultItemID=@ResultItemID", cn);
            cmd.Parameters.Add("@ResultItemID", SqlDbType.Int).Value = intResultItemID;
            cn.Open();

            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;

        }
    }
    
    public bool Delete(int intSectionID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"DELETE FROM ReportSectionItem WHERe ResultSectionID=@ResultSectionID", cn);
            cmd.Parameters.Add("@ResultSectionID", SqlDbType.Int).Value = intSectionID;
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
    }
    public int Insert(Model_ReportSectionItem pr)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO ReportSectionItem (ResultSectionID,Title,Priority,Code,SUCID,Short,Detail,PeopleTxt,CultureTxt,CompetitionTxt) 
VALUES(@ResultSectionID,@Title,@Priority,@Code,@SUCID,@Short,@Detail,@PeopleTxt,@CultureTxt,@CompetitionTxt) SET @ResultItemID = SCOPE_IDENTITY()", cn);

            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = pr.Title;
            cmd.Parameters.Add("@ResultSectionID", SqlDbType.Int).Value = pr.ResultSectionID;
            cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = pr.Code;
            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = pr.Priority;
            cmd.Parameters.Add("@SUCID", SqlDbType.VarChar).Value = pr.SUCID;

            cmd.Parameters.Add("@Short", SqlDbType.NVarChar).Value = pr.Short;
            cmd.Parameters.Add("@Detail", SqlDbType.NVarChar).Value = pr.Detail;

            cmd.Parameters.Add("@PeopleTxt", SqlDbType.NVarChar).Value = pr.PeopleTxt;
            cmd.Parameters.Add("@CultureTxt", SqlDbType.NVarChar).Value = pr.CultureTxt;
            cmd.Parameters.Add("@CompetitionTxt", SqlDbType.NVarChar).Value = pr.CompetitionTxt;
            cmd.Parameters.Add("@ResultItemID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cn.Open();
            if (ExecuteNonQuery(cmd) > 0)
            {
                ret = (int)cmd.Parameters["@ResultItemID"].Value;

            }
        }
        return ret;

    }

    public bool Update(Model_ReportSectionItem pr)
    {
       
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE ReportSectionItem SET ResultSectionID=@ResultSectionID,Title=@Title,Code=@code,
Priority=@Priority, Status=@Status , SUCID=@SUCID , Short=@short, Detail=@Detail ,PeopleTxt=@PeopleTxt,CultureTxt=@CultureTxt, CompetitionTxt=@CompetitionTxt WHERE ResultItemID=@ResultItemID ", cn);

            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = pr.Title;
            cmd.Parameters.Add("@ResultSectionID", SqlDbType.Int).Value = pr.ResultSectionID;
            cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = pr.Code;
            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = pr.Priority;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = pr.Status;
            cmd.Parameters.Add("@ResultItemID", SqlDbType.Int).Value = pr.ResultItemID;
            cmd.Parameters.Add("@Short", SqlDbType.NVarChar).Value = pr.Short;
            cmd.Parameters.Add("@Detail", SqlDbType.NVarChar).Value = pr.Detail;

            cmd.Parameters.Add("@PeopleTxt", SqlDbType.NVarChar).Value = pr.PeopleTxt;
            cmd.Parameters.Add("@CultureTxt", SqlDbType.NVarChar).Value = pr.CultureTxt;
            cmd.Parameters.Add("@CompetitionTxt", SqlDbType.NVarChar).Value = pr.CompetitionTxt;

            cmd.Parameters.Add("@SUCID", SqlDbType.VarChar).Value = pr.SUCID;
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
 
    }


}
public class Model_ReportSection : BaseModel<Model_ReportSection>
{
    public int ResultSectionID { get; set; }
    public string Title { get; set; }
    public string Code { get; set; }
    public string FormularDetail { get; set; }
    public int Priority { get; set; }
    public bool Status { get; set; }
    
   

    public Model_ReportSection()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<Model_ReportSection> GetList()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM ReportSection ORDER BY Priority ASC", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
           
        }
    }
    public List<Model_ReportSection> GetListActive()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM ReportSection WHERE Status = 1 ORDER BY Priority ASC", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));

        }
    }
    public Model_ReportSection GetReportSectionByID(int intResultSectionID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM ReportSection WHERE ResultSectionID=@ResultSectionID", cn);
            cmd.Parameters.Add("@ResultSectionID", SqlDbType.Int).Value = intResultSectionID;
            cn.Open();

            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
            
        }
    }

    public int Insert(Model_ReportSection pr)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO ReportSection (Title,Code,FormularDetail,Priority) 
VALUES(@Title,@Code,@FormularDetail,@Priority) SET @ResultSectionID = SCOPE_IDENTITY()", cn);

            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = pr.Title;
            cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = pr.Code;
            cmd.Parameters.Add("@FormularDetail", SqlDbType.NVarChar).Value = pr.FormularDetail;
            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = pr.Priority;

            cmd.Parameters.Add("@ResultSectionID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cn.Open();
            if (ExecuteNonQuery(cmd) > 0)
            {
                ret = (int)cmd.Parameters["@ResultSectionID"].Value;

            }
        }
        return ret;

    }

    public bool Update(Model_ReportSection pr)
    {
     
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE ReportSection SET Title=@Title,Code=@code, FormularDetail=@FormularDetail,
Priority=@Priority, Status=@Status  WHERE ResultSectionID=@ResultSectionID ", cn);

            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = pr.Title;
            cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = pr.Code;
            cmd.Parameters.Add("@FormularDetail", SqlDbType.NVarChar).Value = pr.FormularDetail;
            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = pr.Priority;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = pr.Status;
            cmd.Parameters.Add("@ResultSectionID", SqlDbType.Int).Value = pr.ResultSectionID;
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
     

    }


    


}