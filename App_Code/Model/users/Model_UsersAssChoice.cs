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
public class Model_UsersAssChoice: BaseModel<Model_UsersAssChoice>
{
    public int TASCID { get; set; }
    public int TASID { get; set; }

    public int ASCID { get; set; }
    public int ASID { get; set; }

    public string Code { get; set; }
    public int SUCID { get; set; }
    public string Questions { get; set; }
    public bool Status { get; set; }
    public int Priority { get; set; }

    public int Score { get; set; }

    public string SubCombind { get; set; }

    public string SubSectionTitle { get; set; }
    public Model_UsersAssChoice()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool UpdateUserAssChoicebyID(int TASCID, int Score, string Code)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE UserAssessmentChoice SET Score=@Score,Code=@Code WHERE TASCID=@TASCID", cn);
            cmd.Parameters.Add("@TASCID", SqlDbType.Int).Value = TASCID;
            cmd.Parameters.Add("@Score", SqlDbType.Int).Value = Score;
            cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = Code;
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }

    }
    public List<Model_UsersAssChoice> GetUserAssessmentChoiceByTsID(int uASIS)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT uss.*,su.Title AS SubSectionTitle FROM UserAssessmentChoice uss 
LEFT JOIN SubSection su ON su.SUCID = uss.SUCID 
WHERE uss.TASID=@TASID ORDER BY Priority ASC", cn);
            cmd.Parameters.Add("@TASID", SqlDbType.Int).Value = uASIS;
            cn.Open();

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));

        }
    }

    public int InsertUserAssessmentChoice(Model_UsersAssChoice uass)
    {
        int ret = 0;
        Model_Assessment_Choice ass = new Model_Assessment_Choice();
        ass = ass.GetAssessmentChoiceByID(uass.ASCID);

        if (ass != null)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {



            SqlCommand cmd = new SqlCommand(@"INSERT INTO UserAssessmentChoice (TASID,ASCID,ASID,Code,SUCID,Questions,Status,Priority,Score,Combind) 
                            VALUES (@TASID,@ASCID,@ASID,@Code,@SUCID,@Questions,@Status,@Priority,@Score,@Combind)", cn);

                cn.Open();

                cmd.Parameters.Add("@TASID", SqlDbType.Int).Value = uass.TASID;
                cmd.Parameters.Add("@ASID", SqlDbType.Int).Value = uass.ASID;
                cmd.Parameters.Add("@ASCID", SqlDbType.Int).Value = uass.ASCID;
                cmd.Parameters.Add("@Score", SqlDbType.Int).Value = uass.Score;


                cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = ass.Code;
                cmd.Parameters.Add("@SUCID", SqlDbType.Int).Value = ass.SUCID;
                cmd.Parameters.Add("@Questions", SqlDbType.NVarChar).Value = ass.Questions;
                cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = ass.Status;
                cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = ass.Priority;
                cmd.Parameters.Add("@Combind", SqlDbType.VarChar).Value = ass.SubCombind;

                ret = ExecuteNonQuery(cmd);
                
            }
        }

        return ret;


    }


}