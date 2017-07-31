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
public class Model_Country : BaseModel<Model_Country>
{
    public int ID { get; set; }

    public string Iso { get; set; }

    public string Name { get; set; }

    public string NiceName { get; set; }

    public string Iso3 { get; set; }

    public short NumCode { get; set; }
    public int PhoneCode { get; set; }


    public bool Status { get; set; }

    public string Nationality { get; set; }

    public string DropValue {
        get
        {
            return (string.IsNullOrEmpty(this.Nationality) ? this.NiceName : this.Nationality);
        }
    }

    public Model_Country()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public List<Model_Country> GetAllCountry()
    {
          using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Country ORDER BY NiceName ASC", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }
    public Model_Country GetAllCountryByID(int Cid)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Country WHERE ID=@ID", cn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Cid;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
           
        }
    }


    public void UpdateCountry()
    {
        List<Model_Country> clist = null;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Country ORDER BY NiceName ASC", cn);
            cn.Open();

           clist = MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
           
        }
        
            foreach(Model_Country i in clist)
            {
                string Nationality = String.Empty;
                using (SqlConnection cn = new SqlConnection(this.ConnectionString))
                {
                    SqlCommand c1 = new SqlCommand("SELECT * FROM Countries WHERE CountryID =@CountryID", cn);
                c1.Parameters.Add("@CountryID", SqlDbType.Char).Value = i.Iso;
                    cn.Open();
                    IDataReader rs = ExecuteReader(c1);
                     if (rs.Read())
                    Nationality = rs["Nationality"].ToString();
                }


                using (SqlConnection cn = new SqlConnection(this.ConnectionString))
                {
                    SqlCommand up = new SqlCommand("UPDATE Country SET Nationality= @Nationality WHERE ID = @ID", cn);
                    up.Parameters.Add("@Nationality", SqlDbType.NVarChar).Value = Nationality;
                    up.Parameters.Add("@ID", SqlDbType.Int).Value = i.ID;
                cn.Open();
                    ExecuteNonQuery(up);
                }
                
            }
        
           
       
        

    }
   
}