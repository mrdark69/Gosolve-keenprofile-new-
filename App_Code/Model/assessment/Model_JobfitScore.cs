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
public class Model_Rule1: BaseModel<Model_Rule1>
{
    public int RuleID { get; set; }
    public string Title { get; set; }

    public int Score { get; set; }
    public decimal CJRRuleScore1 { get; set; }
    public decimal CJRRuleScore2 { get; set; }
    public decimal CJRRuleScore3 { get; set; }
    public decimal CJRRuleScore4 { get; set; }
    public decimal CJRRuleScore5 { get; set; }

    public List<Model_Rule1> GetAll()
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM JobFitScore_Rule1",cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public bool UpdateBulk(List<Model_Rule1> data)
    {
        bool ret = false;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            cn.Open();
            foreach (Model_Rule1 item in data)
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE JobFitScore_Rule1 SET Title=@Title,Score=@Score, 
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
public class Model_Rule2 : BaseModel<Model_Rule2>
{
    public int RuleID { get; set; }
    public int Score { get; set; }

    public decimal Value { get; set; }
    public List<Model_Rule2> GetAll()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM IdealScoreRule", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public bool UpdateBulk(List<Model_Rule2> data)
    {
        bool ret = false;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            cn.Open();
            foreach (Model_Rule2 item in data)
            {
                SqlCommand cmd = new SqlCommand("UPDATE IdealScoreRule SET Score=@Score,Value=@Value WHERE RuleID=@RuleID", cn);
                cmd.Parameters.Add("@RuleID", SqlDbType.Int).Value = item.RuleID;
                cmd.Parameters.Add("@Score", SqlDbType.Int).Value = item.Score;
                cmd.Parameters.Add("@Value", SqlDbType.Decimal).Value = item.Value;
             
                ret = ExecuteNonQuery(cmd) == 1;
            }
        }

        return ret;
    }

}
public class Model_Rule3 : BaseModel<Model_Rule3>
{
    public int RuleID { get; set; }
    public int Range_Start { get; set; }
    public int Range_End { get; set; }
    public string Description { get; set; }

    public List<Model_Rule3> GetAll()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM JobFitScoreExplanation", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public bool UpdateBulk(List<Model_Rule3> data)
    {
        bool ret = false;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            cn.Open();
            foreach (Model_Rule3 item in data)
            {
                SqlCommand cmd = new SqlCommand("UPDATE JobFitScoreExplanation SET Range_Start=@Range_Start,Range_End=@Range_End,Description=@Description WHERE RuleID=@RuleID", cn);
                cmd.Parameters.Add("@RuleID", SqlDbType.Int).Value = item.RuleID;
                cmd.Parameters.Add("@Range_Start", SqlDbType.Int).Value = item.Range_Start;
                cmd.Parameters.Add("@Range_End", SqlDbType.Int).Value = item.Range_End;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = item.Description;
               
                ret = ExecuteNonQuery(cmd) == 1;
            }
        }

        return ret;
    }

}

public class Model_Rule4 : BaseModel<Model_Rule4>
{
    public int RuleID { get; set; }
    public int Range_Start { get; set; }
    public int Range_End { get; set; }
    public string ValueTop { get; set; }
    public string ValueOther { get; set; }
    public string ValueBottom { get; set; }

    public List<Model_Rule4> GetAll()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM JobFitScoreResultRule", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public bool UpdateBulk(List<Model_Rule4> data)
    {
        bool ret = false;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            cn.Open();
            foreach (Model_Rule4 item in data)
            {
                SqlCommand cmd = new SqlCommand("UPDATE JobFitScoreResultRule SET Range_Start=@Range_Start,Range_End=@Range_End,ValueTop=@ValueTop ,ValueOther=@ValueOther,ValueBottom=@ValueBottom WHERE RuleID=@RuleID", cn);
                cmd.Parameters.Add("@RuleID", SqlDbType.Int).Value = item.RuleID;
                cmd.Parameters.Add("@Range_Start", SqlDbType.Int).Value = item.Range_Start;
                cmd.Parameters.Add("@Range_End", SqlDbType.Int).Value = item.Range_End;

                cmd.Parameters.Add("@ValueTop", SqlDbType.NVarChar).Value = item.ValueTop;
                cmd.Parameters.Add("@ValueOther", SqlDbType.NVarChar).Value = item.ValueOther;
                cmd.Parameters.Add("@ValueBottom", SqlDbType.NVarChar).Value = item.ValueBottom;
                
                ret = ExecuteNonQuery(cmd) == 1;
            }
        }

        return ret;
    }
}

