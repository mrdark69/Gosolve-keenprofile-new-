using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MVCDatatableApp;

/// <summary>
/// Summary description for Model_Subscriber
/// </summary>
public class Model_Subscriber : BaseModel<Model_Subscriber>
{

    public int SID { get; set; }
    public int SGID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool Sstatus { get; set; }
    public bool Sbin { get; set; }
    public bool IsSub { get; set; }


    public int TotelRows { get; set; }
    public int RowNum { get; set; }

    public Model_Subscriber()
    {
        //
        // TODO: Add constructor logic here
        //

    }

    public List<Model_Subscriber> model_getSubbyGroup(int SGID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Subscriber WHERE SGID=@SGID AND Sstatus=1 AND Sbin=1 AND IsSub=1", cn);
            cmd.Parameters.Add("@SGID", SqlDbType.Int).Value = SGID;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }


    public bool UpdateUnSub(int sid)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE Subscriber SET IsSub=0  WHERE SID=@SID", cn);
            cmd.Parameters.Add("@SID", SqlDbType.Int).Value = sid;
            cn.Open();

            return ExecuteNonQuery(cmd) == 1;
        }
    }

    public int model_InsertSubscriber(Model_Subscriber obj)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            int ret = 0;
            SqlCommand cmdUpdate = new SqlCommand(@"UPDATE Subscriber SET FirstName=@FirstName ,LastName=@LastName, Sbin=@Sbin WHERE Email=@Email AND SGID=@SGID", cn);
            cmdUpdate.Parameters.Add("@SGID", SqlDbType.NVarChar).Value = obj.SGID;
            cmdUpdate.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = obj.FirstName;
            cmdUpdate.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = obj.LastName;
            cmdUpdate.Parameters.Add("@Email", SqlDbType.NVarChar).Value = obj.Email;
            cmdUpdate.Parameters.Add("@Sbin", SqlDbType.Bit).Value = obj.Sbin;
            cn.Open();
            ret = ExecuteNonQuery(cmdUpdate);
            if (ret == 0)
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO Subscriber 
            (SGID,FirstName,LastName,Email) VALUES
            (@SGID,@FirstName,@LastName,@Email) 
           ; SET @SID = SCOPE_IDENTITY();", cn);

                cmd.Parameters.Add("@SGID", SqlDbType.NVarChar).Value = obj.SGID;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = obj.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = obj.LastName;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = obj.Email;
                cmd.Parameters.Add("@SID", SqlDbType.Int).Direction = ParameterDirection.Output;



                
                if (ExecuteNonQuery(cmd) > 0)
                    ret = (int)cmd.Parameters["@SID"].Value;
            }

           

            return ret;
        }
    }

    public bool modeol_UpdateSubcriberGroup(List<Model_Subscriber> obj)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            cn.Open();

            foreach (Model_Subscriber i in obj)
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE Subscriber SET FirstName=@FirstName, LastName=@LastName ,Email=@Email ,Sstatus=@Sstatus WHERE SID=@SID", cn);
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = i.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = i.LastName;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = i.Email;
                cmd.Parameters.Add("@Sstatus", SqlDbType.Bit).Value = i.Sstatus;
                cmd.Parameters.Add("@SID", SqlDbType.Int).Value = i.SID;
                ret = ExecuteNonQuery(cmd);
            }
        }
        return (ret == 1);
    }

    public int model_DeleteSubscriber(List<Model_Subscriber> obj)
    {
        StringBuilder pr = new StringBuilder();

        // string.Join(",", obj.Select(p => p.SGID).ToArray());

        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            int i = 0;
            foreach (Model_Subscriber m in obj)
            {
                if (i < (obj.Count() - 1))
                    pr.Append("@SID" + i + ",");
                else
                    pr.Append("@SID" + i);

                cmd.Parameters.AddWithValue("@SID" + i.ToString(), m.SID);
                i++;
            }
            string query = @"UPDATE Subscriber SET Sbin = 0 WHERE SID IN (" + pr.ToString() + ")";

            cmd.CommandText = query;
            cmd.Connection = cn;



            cn.Open();
            return ExecuteNonQuery(cmd);
        }




    }

    

    public object getSubscriberAll_DataTable(DTParameters param)
    {

        string search = param.Search.Value;
        string sortOrder = param.SortOrder;
        int start = param.Start;
        int length = param.Length;
        List<string> columnFilters = DataTablesJS<Model_Subscriber>.getcolumnSearch(param);

        DTCustomSerach custom = param.CustomSearch;

        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {


            string[] filerName = { "", "", "FirstName", "LastName","Email" };
            StringBuilder strfilter = new StringBuilder();



            for (int i = 0; i < columnFilters.Count; i++)
            {
                if (!string.IsNullOrEmpty(columnFilters[i]))
                {
                    strfilter.Append(" AND LOWER(" + filerName[i] + ") LIKE @filer_" + i);

                }

            }


            string strcmd = @"
                ;WITH Subscriber_cte AS (
                SELECT *
                FROM dbo.Subscriber
	            WHERE Sbin = 1 " +
                (string.IsNullOrEmpty(search) ? "" : "AND  (FirstName LIKE @search  OR LastName LIKE @search OR Email LIKE @search) ") +
                 (custom.Value != null ? "AND "+ custom.Key+ " = @CustomKeyValue" : "") +
                (columnFilters.Count > 0 ? strfilter.ToString() : "")
                + @"
            )

            SELECT 
                db.*,
                tCountOrders.CountOrders AS TotalRows
            FROM Subscriber_cte db
                CROSS JOIN (SELECT Count(*) AS CountOrders FROM Subscriber_cte) AS tCountOrders
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
                if (!string.IsNullOrEmpty(columnFilters[3]))
                {
                    string searchTerm = string.Format("%{0}%", columnFilters[3]);
                    cmd.Parameters.Add(new SqlParameter("@filer_3", searchTerm));
                }


            }
            cn.Open();


            IDataReader reader = ExecuteReader(cmd);

            IList<Model_Subscriber> result = MappingObjectCollectionFromDataReader(reader);

            int countTotal = (result.Count() > 0 ? result[0].TotelRows : 0);

            return DataTablesJS<Model_Subscriber>.ResponeDataTable(param, result, countTotal);
        }

    }
}