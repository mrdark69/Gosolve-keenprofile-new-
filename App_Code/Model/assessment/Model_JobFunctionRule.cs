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
public class Model_JFR1: BaseModel<Model_JFR1>
{
    public int RuleID { get; set; }
    public string Title { get; set; }

    public int Score { get; set; }
    public decimal CJRRuleScore1 { get; set; }
    public decimal CJRRuleScore2 { get; set; }
    public decimal CJRRuleScore3 { get; set; }
    public decimal CJRRuleScore4 { get; set; }
    public decimal CJRRuleScore5 { get; set; }

    public List<Model_JFR1> GetAll()
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM JobFunctionRule1",cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public bool UpdateBulk(List<Model_JFR1> data)
    {
        bool ret = false;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            cn.Open();
            foreach (Model_JFR1 item in data)
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE JobFunctionRule1 SET Title=@Title,Score=@Score, 
CJRRuleScore1=@CJRRuleScore1 ,CJRRuleScore2=@CJRRuleScore2,CJRRuleScore3=@CJRRuleScore3,
CJRRuleScore4=@CJRRuleScore4,CJRRuleScore5=@CJRRuleScore5 WHERE RuleID=@RuleID", cn);
                cmd.Parameters.Add("@RuleID", SqlDbType.Int).Value = item.RuleID;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = item.Title;
                cmd.Parameters.Add("@Score", SqlDbType.Int).Value = item.Score;
                cmd.Parameters.Add("@CJRRuleScore1", SqlDbType.Decimal).Value = item.CJRRuleScore1;
                cmd.Parameters.Add("@CJRRuleScore2", SqlDbType.Decimal).Value = item.CJRRuleScore2;
                cmd.Parameters.Add("@CJRRuleScore3", SqlDbType.Decimal).Value = item.CJRRuleScore3;
                cmd.Parameters.Add("@CJRRuleScore4", SqlDbType.Decimal).Value = item.CJRRuleScore4;
                cmd.Parameters.Add("@CJRRuleScore5", SqlDbType.Decimal).Value = item.CJRRuleScore5;
               
                ret = ExecuteNonQuery(cmd) == 1;
            }
        }

        return ret;
    }


}

public class Model_JFR2 : BaseModel<Model_JFR2>
{
    public int RuleID { get; set; }
    public string Title { get; set; }

    public int Score { get; set; }
    public decimal CJRRuleScore1 { get; set; }
    public decimal CJRRuleScore2 { get; set; }
    public decimal CJRRuleScore3 { get; set; }
    public decimal CJRRuleScore4 { get; set; }
    //public decimal CJRRuleScore5 { get; set; }

    public List<Model_JFR2> GetAll()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM JobFunctionRule2", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public bool UpdateBulk(List<Model_JFR2> data)
    {
        bool ret = false;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            cn.Open();
            foreach (Model_JFR2 item in data)
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE JobFunctionRule2 SET Title=@Title,Score=@Score, 
CJRRuleScore1=@CJRRuleScore1 ,CJRRuleScore2=@CJRRuleScore2,CJRRuleScore3=@CJRRuleScore3,
CJRRuleScore4=@CJRRuleScore4 WHERE RuleID=@RuleID", cn);
                cmd.Parameters.Add("@RuleID", SqlDbType.Int).Value = item.RuleID;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = item.Title;
                cmd.Parameters.Add("@Score", SqlDbType.Int).Value = item.Score;
                cmd.Parameters.Add("@CJRRuleScore1", SqlDbType.Decimal).Value = item.CJRRuleScore1;
                cmd.Parameters.Add("@CJRRuleScore2", SqlDbType.Decimal).Value = item.CJRRuleScore2;
                cmd.Parameters.Add("@CJRRuleScore3", SqlDbType.Decimal).Value = item.CJRRuleScore3;
                cmd.Parameters.Add("@CJRRuleScore4", SqlDbType.Decimal).Value = item.CJRRuleScore4;
               // cmd.Parameters.Add("@CJRRuleScore5", SqlDbType.Decimal).Value = item.CJRRuleScore5;

                ret = ExecuteNonQuery(cmd) == 1;
            }
        }

        return ret;
    }


}

public class Model_JFR3 : BaseModel<Model_JFR3>
{
    public int RuleID { get; set; }
    public string Condition1 { get; set; }

    public string Condition2 { get; set; }
    public int Score { get; set; }
    public byte Cat { get; set; }

    //public decimal CJRRuleScore5 { get; set; }

    public List<Model_JFR3> GetAll()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM JobFunctionRule3", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public bool UpdateBulk(List<Model_JFR3> data)
    {
        bool ret = false;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            cn.Open();
            foreach (Model_JFR3 item in data)
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE JobFunctionRule3 SET Condition1=@Condition1,Condition2=@Condition2, 
Score=@Score  WHERE RuleID=@RuleID", cn);
                cmd.Parameters.Add("@RuleID", SqlDbType.Int).Value = item.RuleID;
                cmd.Parameters.Add("@Condition1", SqlDbType.VarChar).Value = item.Condition1;
                cmd.Parameters.Add("@Condition2", SqlDbType.VarChar).Value = item.Condition2;
                cmd.Parameters.Add("@Score", SqlDbType.Int).Value = item.Score;
          
                // cmd.Parameters.Add("@CJRRuleScore5", SqlDbType.Decimal).Value = item.CJRRuleScore5;

                ret = ExecuteNonQuery(cmd) == 1;
            }
        }

        return ret;
    }


}

public class Model_JFR4 : BaseModel<Model_JFR4>
{
    public int RuleID { get; set; }
    public string Condition1 { get; set; }

    public int Score { get; set; }
    public byte Cat { get; set; }

    //public decimal CJRRuleScore5 { get; set; }

    public List<Model_JFR4> GetAll()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM JobFunctionRule4", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public bool UpdateBulk(List<Model_JFR4> data)
    {
        bool ret = false;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            cn.Open();
            foreach (Model_JFR4 item in data)
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE JobFunctionRule4 SET Condition1=@Condition1,Score=@Score  WHERE RuleID=@RuleID", cn);
                cmd.Parameters.Add("@RuleID", SqlDbType.Int).Value = item.RuleID;
                cmd.Parameters.Add("@Condition1", SqlDbType.VarChar).Value = item.Condition1;
                cmd.Parameters.Add("@Score", SqlDbType.Int).Value = item.Score;

                // cmd.Parameters.Add("@CJRRuleScore5", SqlDbType.Decimal).Value = item.CJRRuleScore5;

                ret = ExecuteNonQuery(cmd) == 1;
            }
        }

        return ret;
    }


}
