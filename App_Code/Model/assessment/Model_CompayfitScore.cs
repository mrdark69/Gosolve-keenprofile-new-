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

public class Model_Com_Rule3 : BaseModel<Model_Com_Rule3>
{
    public int RuleID { get; set; }
    public int Range_Start { get; set; }
    public int Range_End { get; set; }
    public string Description { get; set; }

    public List<Model_Com_Rule3> GetAll()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM CompanyFitScoreExplanation", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public bool UpdateBulk(List<Model_Com_Rule3> data)
    {
        bool ret = false;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            cn.Open();
            foreach (Model_Com_Rule3 item in data)
            {
                SqlCommand cmd = new SqlCommand("UPDATE CompanyFitScoreExplanation SET Range_Start=@Range_Start,Range_End=@Range_End,Description=@Description WHERE RuleID=@RuleID", cn);
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



