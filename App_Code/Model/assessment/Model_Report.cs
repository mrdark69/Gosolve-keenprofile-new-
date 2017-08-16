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
}
public class Model_ReportSectionItem : BaseModel<Model_ReportSectionItem>
{
    public int ResultItemID { get; set; }
    public int ResultSectionID { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }
    public bool Status { get; set; }
    public int Priority { get; set; }
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
            SqlCommand cmd = new SqlCommand(@"INSERT INTO ReportSectionItem (ResultSectionID,Title,Priority,Code) 
VALUES(@ResultSectionID,@Title,@Priority,@Code) SET @ResultItemID = SCOPE_IDENTITY()", cn);

            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = pr.Title;
            cmd.Parameters.Add("@ResultSectionID", SqlDbType.Int).Value = pr.ResultSectionID;
            cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = pr.Code;
            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = pr.Priority;

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
Priority=@Priority, Status=@Status  WHERE ResultItemID=@ResultItemID ", cn);

            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = pr.Title;
            cmd.Parameters.Add("@ResultSectionID", SqlDbType.Int).Value = pr.ResultSectionID;
            cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = pr.Code;
            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = pr.Priority;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = pr.Status;
            cmd.Parameters.Add("@ResultItemID", SqlDbType.Int).Value = pr.ResultItemID;
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