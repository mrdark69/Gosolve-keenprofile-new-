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
public class Model_Assessment : BaseModel<Model_Assessment>
{
    public int ASID { get; set; }
    public string Code { get; set; }
    public string Questions { get; set; }
    public int SCID { get; set; }
    public int SUCID { get; set; }

    public bool Status { get; set; }
    public bool IsHide { get; set; }
    public byte QTID { get; set; }
    public int? SUCIDLF { get; set; }
    public int? SUCIDRT { get; set; }

    public int Priority { get; set; }

    public Model_Assessment()
    {
        //
        // TODO: Add constructor logic here
        //
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
                w = "WHERE u.SCID =@SCID";
                cmd.Parameters.Add("@SCID", SqlDbType.TinyInt).Value = mu.SCID;

            }
            cText.Append(@"SELECT u.*,ur.Title AS UserRoleName FROM  Assessment u 
INNER JOIN Section ur ON ur.SCID =u.SCID ORDER BY Priority ASC" + w);

            cmd.CommandText = cText.ToString();
            cmd.Connection = cn;


            cn.Open();

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

}