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

/// <summary>
/// Summary description for Model_Users
/// </summary>
/// 

public class Model_usersRoleApp : BaseModel<Model_usersRoleApp>
{
    public byte UsersRoleId { get; set; }
    public int AppID { get; set; }

    public List<Model_usersRoleApp> getListAppFeature(byte bytUsersRoleId)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM AppFeatureRole WHERE UsersRoleId =@UsersRoleId", cn);
            cn.Open();

            cmd.Parameters.Add("@UsersRoleId", SqlDbType.TinyInt).Value = bytUsersRoleId;

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }
}

public class Model_usersRole : BaseModel<Model_usersRole>
{

    public byte UsersRoleId { get; set; }
    public string Title { get; set; }
    public bool  Status { get; set; } 



    private List<Model_usersRoleApp> _appID = null;
    public List<Model_usersRoleApp> ListAPPFeature
    {
        get
        {
            if(_appID== null)
            {
                Model_usersRoleApp rp = new Model_usersRoleApp();
                _appID =  rp.getListAppFeature(this.UsersRoleId);
            }
            return _appID;


        }
    }


    public int TotelRows { get; set; }
    public int RowNum { get; set; }


    public Model_usersRole()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<Model_usersRole> getRole()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM UsersRole ORDER BY UsersRoleId ASC", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }



    public Model_usersRole getRoleByID(byte UserRoleID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM UsersRole WHERE UsersRoleId=@UsersRoleId", cn);
            cmd.Parameters.Add("@UsersRoleId", SqlDbType.TinyInt).Value = UserRoleID;
            cn.Open();

            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
            
        }
    }

    public bool UpdateUsersRole(Model_usersRole ur)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE UsersRole SET Title=@Title , Status =@Status WHERE UsersRoleId=@UsersRoleId", cn);
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ur.Title;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = ur.Status;
            cmd.Parameters.Add("@UsersRoleId", SqlDbType.TinyInt).Value = ur.UsersRoleId;
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
    }

    public byte AddeUsersRole(Model_usersRole ur)
    {
        byte ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO UsersRole (Title,Status) VALUES (@Title,@Status) ;SET @UsersRoleId=SCOPE_IDENTITY();", cn);
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ur.Title;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = ur.Status;
            cmd.Parameters.Add("@UsersRoleId", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
          
            //cmd.Parameters.Add("@UsersRoleId", SqlDbType.NVarChar).Value = ur.Title;
            cn.Open();

            if (ExecuteNonQuery(cmd) > 0)
            {
                ret = (byte)cmd.Parameters["@UsersRoleId"].Value;

            }
            return ret;
        }
    }

    public object getUserRoleAll_DataTable(DTParameters param)
    {

        string search = param.Search.Value;
        string sortOrder = param.SortOrder;
        int start = param.Start;
        int length = param.Length;
        List<string> columnFilters = DataTablesJS<Model_usersRole>.getcolumnSearch(param);

        DTCustomSerach custom = param.CustomSearch;

        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {


            string[] filerName = { "", "", "FirstName", "LastName", "Email" };
            StringBuilder strfilter = new StringBuilder();



            for (int i = 0; i < columnFilters.Count; i++)
            {
                if (!string.IsNullOrEmpty(columnFilters[i]))
                {
                    strfilter.Append(" AND LOWER(" + filerName[i] + ") LIKE @filer_" + i);

                }

            }


            string strcmd = @"
                ;WITH UsersRole_cte AS (
                SELECT *
                FROM dbo.UsersRole
	            " +
                (string.IsNullOrEmpty(search) ? "" : "AND  (FirstName LIKE @search  OR LastName LIKE @search OR Email LIKE @search) ") +
                 (custom.Value != null ? "AND " + custom.Key + " = @CustomKeyValue" : "") +
                (columnFilters.Count > 0 ? strfilter.ToString() : "")
                + @"
            )

            SELECT 
                db.*,
                tCountOrders.CountOrders AS TotalRows
            FROM UsersRole_cte db
                CROSS JOIN (SELECT Count(*) AS CountOrders FROM UsersRole_cte) AS tCountOrders
            ORDER BY " + sortOrder + @"
            OFFSET @Start ROWS
            FETCH NEXT @Size ROWS ONLY;
            ";
            SqlCommand cmd = new SqlCommand(strcmd, cn);

            cmd.Parameters.Add("@Start", SqlDbType.Int).Value = start;
            cmd.Parameters.Add("@Size", SqlDbType.Int).Value = length;


            if (custom.Value != null)
                cmd.Parameters.Add("@CustomKeyValue", SqlDbType.Int).Value = custom.Value;

            if (!string.IsNullOrEmpty(search))
            {
                string searchTerm = string.Format("%{0}%", search);
                cmd.Parameters.Add(new SqlParameter("@search", searchTerm));
                //cmd.Parameters.Add("@search", SqlDbType.NVarChar).Value = searchTerm;
            }

            if (columnFilters.Count > 0)
            {
                if (!string.IsNullOrEmpty(columnFilters[2]))
                {
                    string searchTerm = string.Format("%{0}%", columnFilters[2]);
                    cmd.Parameters.Add(new SqlParameter("@filer_2", searchTerm));
                }
                //if (!string.IsNullOrEmpty(columnFilters[3]))
                //{
                //    string searchTerm = string.Format("%{0}%", columnFilters[3]);
                //    cmd.Parameters.Add(new SqlParameter("@filer_3", searchTerm));
                //}


            }
            cn.Open();


            IDataReader reader = ExecuteReader(cmd);

            IList<Model_usersRole> result = MappingObjectCollectionFromDataReader(reader);

            int countTotal = (result.Count() > 0 ? result[0].TotelRows : 0);

            return DataTablesJS<Model_usersRole>.ResponeDataTable(param, result, countTotal);
        }

    }
}