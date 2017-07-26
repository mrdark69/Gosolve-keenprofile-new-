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
public class Model_AssesIntro : BaseModel<Model_AssesIntro>
{
    public byte ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }


    public string LastTitle { get; set; }
    public string LastDes { get; set; }
    public string MainTitle { get; set; }


    public string ThanksTitle { get; set; }
    public string ThanksDes { get; set; }
    public string ProfileTitle { get; set; }
    public string ProfileCJFTitle { get; set; }
    public string ProfileFCTitle { get; set; }

    public Model_AssesIntro()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool SaveAssIntro(Model_AssesIntro ss)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE AssIntro SET Title=@Title, Description=@Description, 
            LastTitle=@LastTitle,LastDes=@LastDes,MainTitle=@MainTitle,ThanksTitle=@ThanksTitle 
,ThanksDes=@ThanksDes ,ProfileTitle=@ProfileTitle ,ProfileCJFTitle=@ProfileCJFTitle ,ProfileFCTitle=@ProfileFCTitle  WHERE ID =1", cn);
            cn.Open();
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ss.Title;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ss.Description;
            cmd.Parameters.Add("@LastTitle", SqlDbType.NVarChar).Value = ss.LastTitle;
            cmd.Parameters.Add("@LastDes", SqlDbType.NVarChar).Value = ss.LastDes;
            cmd.Parameters.Add("@MainTitle", SqlDbType.NVarChar).Value = ss.MainTitle;

            cmd.Parameters.Add("@ThanksTitle", SqlDbType.NVarChar).Value = ss.ThanksTitle;
            cmd.Parameters.Add("@ThanksDes", SqlDbType.NVarChar).Value = ss.ThanksDes;
            cmd.Parameters.Add("@ProfileTitle", SqlDbType.NVarChar).Value = ss.ProfileTitle;
            cmd.Parameters.Add("@ProfileCJFTitle", SqlDbType.NVarChar).Value = ss.ProfileCJFTitle;
            cmd.Parameters.Add("@ProfileFCTitle", SqlDbType.NVarChar).Value = ss.ProfileFCTitle;

            return ExecuteNonQuery(cmd) == 1;
        }
    }


    public Model_AssesIntro GetIntro()
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM AssIntro", cn);
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }



}