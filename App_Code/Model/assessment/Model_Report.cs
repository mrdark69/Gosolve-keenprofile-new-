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

    public string Detail { get; set; } = string.Empty;


    public bool IsDup { get; set; } = false;

    public int? UserRank { get; set; }

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


    public string ResultItemTitle { get; set; }

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
,TASID=@TASID,Detail=@Detail,Factor=@Factor,IsDup=@IsDup WHERE ResultSectionID=@ResultSectionID AND ResultItemID=@ResultItemID AND TransactionID=@TransactionID;
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


                if (re.Factor.HasValue)
                    cmdupdate.Parameters.Add("@Factor", SqlDbType.Decimal).Value = re.Factor;
                else
                    cmdupdate.Parameters.AddWithValue("@Factor", DBNull.Value);


                cmdupdate.Parameters.Add("@IsDup", SqlDbType.Int).Value = re.IsDup;

                cmdupdate.Parameters.Add("@IsAbove", SqlDbType.Bit).Value = re.IsAbove;
                cmdupdate.Parameters.Add("@IsBelow", SqlDbType.Bit).Value = re.IsBelow;

                cmdupdate.Parameters.Add("@Detail", SqlDbType.VarChar).Value = re.Detail;


                //DELETE FROM ReportItemResult WHERE ResultSectionID = @ResultSectionID AND ResultItemID = @ResultItemID AND TransactionID = @TransactionID;
                if (ExecuteNonQuery(cmdupdate) == 0)
                {
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO ReportItemResult (ResultSectionID,ResultItemID,TransactionID,Score,IsAbove,IsBelow,Score_new,TASID,Detail,Factor,IsDup) 
                VALUES(@ResultSectionID,@ResultItemID,@TransactionID,@Score,@IsAbove,@IsBelow,@Score_new,@TASID,@Detail,@Factor,@IsDup)", cn);

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


                    if (re.Factor.HasValue)
                        cmd.Parameters.Add("@Factor", SqlDbType.Decimal).Value = re.Factor;
                    else
                        cmd.Parameters.AddWithValue("@Factor", DBNull.Value);


                    cmd.Parameters.Add("@IsDup", SqlDbType.Int).Value = re.IsDup;

                    cmd.Parameters.Add("@IsAbove", SqlDbType.Bit).Value = re.IsAbove;
                    cmd.Parameters.Add("@IsBelow", SqlDbType.Bit).Value = re.IsBelow;

                    cmd.Parameters.Add("@Detail", SqlDbType.VarChar).Value = re.Detail;

                    ret = ExecuteNonQuery(cmd) == 1;
                }
                else
                    ret = true;



            }




            return ret;
        }
    }

    public int InsertReportItemResult(Model_ReportItemResult re)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO ReportItemResult (ResultSectionID,ResultItemID,TransactionID,Score,Score_new,TASID,Detail,Factor,IsDup) 
                VALUES(@ResultSectionID,@ResultItemID,@TransactionID,@Score,@Score_new,@TASID,@Detail,@Factor,@IsDup)", cn);
            cn.Open();
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

            if (re.Factor.HasValue)
                cmd.Parameters.Add("@Factor", SqlDbType.Decimal).Value = re.Factor;
            else
                cmd.Parameters.AddWithValue("@Factor", DBNull.Value);

            cmd.Parameters.Add("@IsDup", SqlDbType.Int).Value = re.IsDup;


            cmd.Parameters.Add("@Detail", SqlDbType.VarChar).Value = re.Detail;
            cn.Open();

            return ExecuteNonQuery(cmd);
        }
    }
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