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

public class Model_Assessment_Choice : BaseModel<Model_Assessment_Choice>
{
    public int ASCID { get; set; }
    public int ASID { get; set; }

    public string Code { get; set; }
    public int SUCID { get; set; }
    public string Questions { get; set; }
    public bool Status { get; set; }
    public int Priority { get; set; }

    public string SubCombind { get; set; }

    public string CombindValue
    {
        get
        {
            return this.Questions + "," + this.Code + "," + this.SUCID + "," + this.Priority;
        }
    }

    public Model_Assessment_Choice()
    {

    }

    public List<Model_Assessment_Choice> GetAssessmentChoice(int ASID)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM AssessmentChoice WHERE ASID=@ASID AND Status = 1 ORDER BY Priority ASC", cn);
            cmd.Parameters.Add("@ASID", SqlDbType.Int).Value = ASID;
            cn.Open();

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public Model_Assessment_Choice GetAssessmentChoiceByID(int ASCID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT ach.*, su.Combind AS SubCombind AS FROM AssessmentChoice ach 
INNER JOIN SubSection su ON su.SUCID = ach.SUCID WHERE ach.ASCID=@ASCID ", cn);
            cmd.Parameters.Add("@ASCID", SqlDbType.Int).Value = ASCID;
            cn.Open();

            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }


    public int AddAssessmentChoice(List<Model_Assessment_Choice> list,int ASID)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM AssessmentChoice WHERE ASID=@ASID", cn);
            cmd.Parameters.Add("@ASID", SqlDbType.Int).Value = ASID;
            cn.Open();
            ////try
            ////{
                ExecuteNonQuery(cmd);

                if (list.Count > 0)
                {
                    foreach (Model_Assessment_Choice mm in list)
                    {
                        SqlCommand cmd1 = new SqlCommand("INSERT INTO  AssessmentChoice (ASID,Code,SUCID,Questions,Priority) VALUES(@ASID,@Code,@SUCID,@Questions,@Priority) ", cn);

                        cmd1.Parameters.Add("@ASID", SqlDbType.Int).Value = ASID;
                        cmd1.Parameters.Add("@Questions", SqlDbType.NVarChar).Value = mm.Questions;
                        cmd1.Parameters.Add("@Code", SqlDbType.VarChar).Value = mm.Code;
                        cmd1.Parameters.Add("@SUCID", SqlDbType.Int).Value = mm.SUCID;
                        cmd1.Parameters.Add("@Priority", SqlDbType.Int).Value = mm.Priority;

                        ret = ExecuteNonQuery(cmd1);
                    }
                }
                   
                
            //}
            //catch  { }
          
        }

        return ret;
    }

}
public class Model_Assessment : BaseModel<Model_Assessment>
{
    public int ASID { get; set; }
    public string Code { get; set; }
    public string Questions { get; set; }
    public int SCID { get; set; }
    public int SUCID { get; set; }

    public bool Status { get; set; }
    public bool IsHide { get; set; } = false;
    public byte QTID { get; set; }
    //public int? SUCIDLF { get; set; }
    //public int? SUCIDRT { get; set; }

    public int Priority { get; set; }


    public int StartRank { get; set; }
    public int EndRank { get; set; }

    public string GroupName { get; set; }
    public byte Side { get; set; }

    public string LeftScaleTitle { get; set; }
    public string RigthScaleTitle { get; set; }

    public string SectionTitle { get; set; }

    public string SubCombind { get; set; }

    public int TotalRows { get; set; }
    public int RowNum { get; set; }


    public DTParameters PagingParam { get; set; }
    private List<Model_Assessment_Choice> _asschoice = null;
    public List<Model_Assessment_Choice> AssChoice {

        get
        {
            if(_asschoice == null)
            {
                Model_Assessment_Choice assc = new Model_Assessment_Choice();
                _asschoice = assc.GetAssessmentChoice(this.ASID);
            }
            return _asschoice;
        }

        set
        {
            _asschoice = value;
        }
    }

    public Model_Assessment()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public int AddAssessment(Model_Assessment mu)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO Assessment (Code,Questions,SCID,SUCID,Status,IsHide,QTID,Priority,StartRank,EndRank,Side,GroupName,LeftScaleTitle,RigthScaleTitle) 
VALUES(@Code,@Questions,@SCID,@SUCID,@Status,@IsHide,@QTID,@Priority,@StartRank,@EndRank,@Side,@GroupName,@LeftScaleTitle,@RigthScaleTitle);SET @ASID = SCOPE_IDENTITY();", cn);
            cn.Open();
            cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = mu.Code;
            cmd.Parameters.Add("@Questions", SqlDbType.NVarChar).Value = mu.Questions;
            cmd.Parameters.Add("@SCID", SqlDbType.Int).Value = mu.SCID;

            cmd.Parameters.Add("@SUCID", SqlDbType.Int).Value = mu.SUCID;
         
        
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = mu.Status;
            cmd.Parameters.Add("@IsHide", SqlDbType.Bit).Value = mu.IsHide;
            cmd.Parameters.Add("@QTID", SqlDbType.TinyInt).Value = mu.QTID;

           
            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = mu.Priority;

            cmd.Parameters.Add("@StartRank", SqlDbType.Int).Value = mu.StartRank;
            cmd.Parameters.Add("@EndRank", SqlDbType.Int).Value = mu.EndRank;


            cmd.Parameters.Add("@Side", SqlDbType.TinyInt).Value = mu.Side;
            cmd.Parameters.Add("@GroupName", SqlDbType.NVarChar).Value = mu.GroupName;

            cmd.Parameters.Add("@LeftScaleTitle", SqlDbType.NVarChar).Value = mu.LeftScaleTitle;
            cmd.Parameters.Add("@RigthScaleTitle", SqlDbType.NVarChar).Value = mu.RigthScaleTitle;

            cmd.Parameters.Add("@ASID", SqlDbType.Int).Direction = ParameterDirection.Output;

            if (ExecuteNonQuery(cmd) > 0)
            {
                ret = (int)cmd.Parameters["@ASID"].Value;

            }
        }
        return ret;
    }

    public bool Update(Model_Assessment mu)
    {
   
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE Assessment SET Code=@Code, Questions=@Questions, SCID=@SCID, SUCID=@SUCID, 
            Status =@Status,IsHide=@IsHide,QTID=@QTID ,GroupName=@GroupName, Side=@Side,Priority=@Priority, 
        StartRank=@StartRank,EndRank=@EndRank ,LeftScaleTitle=@LeftScaleTitle,RigthScaleTitle=@RigthScaleTitle WHERE ASID=@ASID", cn);

            cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = mu.Code;
            cmd.Parameters.Add("@Questions", SqlDbType.NVarChar).Value = mu.Questions;
            cmd.Parameters.Add("@SCID", SqlDbType.Int).Value = mu.SCID;
            cmd.Parameters.Add("@SUCID", SqlDbType.Int).Value = mu.SUCID;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = mu.Status;
            cmd.Parameters.Add("@IsHide", SqlDbType.Bit).Value = mu.IsHide;
            cmd.Parameters.Add("@QTID", SqlDbType.TinyInt).Value = mu.QTID;

          

            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = mu.Priority;

            cmd.Parameters.Add("@StartRank", SqlDbType.Int).Value = mu.StartRank;
            cmd.Parameters.Add("@EndRank", SqlDbType.Int).Value = mu.EndRank;
            cmd.Parameters.Add("@Side", SqlDbType.TinyInt).Value = mu.Side;
            cmd.Parameters.Add("@GroupName", SqlDbType.NVarChar).Value = mu.GroupName;
            cmd.Parameters.Add("@LeftScaleTitle", SqlDbType.NVarChar).Value = mu.LeftScaleTitle;
            cmd.Parameters.Add("@RigthScaleTitle", SqlDbType.NVarChar).Value = mu.RigthScaleTitle;

            cmd.Parameters.Add("@ASID", SqlDbType.Int).Value = mu.ASID;

            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
       
    }



    public Model_Assessment GetAssessmentByID(int ASID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT ach.*,su.Combind FROM Assessment ach 
INNER JOIN SubSection su ON su.SUCID = ach.SUCID WHERE ach.ASID= @ASID", cn);
            cmd.Parameters.Add("@ASID", SqlDbType.Int).Value = ASID;
            cn.Open();

            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }
    public List<Model_Assessment> GetAssessmentAll()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT ach.*,su.Combind FROM Assessment ach
INNER JOIN SubSection su ON su.SUCID = ach.SUCID WHERe ach.Status =1", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
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
                w = " WHERE u.SCID =@SCID";
                cmd.Parameters.Add("@SCID", SqlDbType.TinyInt).Value = mu.SCID;

            }
            cText.Append(@"SELECT u.*,ur.Title AS SectionTitle FROM  Assessment u 
INNER JOIN Section ur ON ur.SCID =u.SCID " + w  + " ORDER BY Status DESC, Priority ASC");

            cmd.CommandText = cText.ToString();
            cmd.Connection = cn;


            cn.Open();

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public List<Model_Assessment> GetAssessment_paging(Model_Assessment mu)
    {

        string search = (mu.PagingParam.Search != null ? mu.PagingParam.Search.Value : "");
        string sortOrder = mu.PagingParam.SortOrder;
        int start = mu.PagingParam.Start;
        int length = mu.PagingParam.Length;
        //List<string> columnFilters = DataTablesJS<Model_Users>.getcolumnSearch(mu.PagingParam);

        List<DTCustomSerach> custom = mu.PagingParam.CustomSearchList;

        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {


            //string[] filerName = { "", "", "FirstName", "LastName", "Email" };
            //StringBuilder strfilter = new StringBuilder();



            //for (int i = 0; i < columnFilters.Count; i++)
            //{
            //    if (!string.IsNullOrEmpty(columnFilters[i]))
            //    {
            //        strfilter.Append(" AND LOWER(" + filerName[i] + ") LIKE @filer_" + i);

            //    }

            //}
            SqlCommand cmd = new SqlCommand();

            string cfilter = string.Empty;
            if (custom.Count > 0)
            {
                foreach (DTCustomSerach f in custom)
                {
                    if (f.Key == "Search")
                    {
                        cfilter += (!string.IsNullOrEmpty(f.Value) ? " AND (u.Code LIKE '%'+@CustomKeyValue+'%' OR u.Questions LIKE '%'+@CustomKeyValue+'%')" : "");
                        cmd.Parameters.Add("@CustomKeyValue", SqlDbType.NVarChar).Value = f.Value;
                    }

                    if (f.Key == "casesection")
                    {
                        if (!string.IsNullOrEmpty(f.Value))
                        {

                            cfilter += " AND  u.SCID =@SCID ";
                            cmd.Parameters.Add("@SCID", SqlDbType.Int).Value = int.Parse(f.Value);
                        }

                    }
                }
            }
//            cText.Append(@"SELECT u.*,ur.Title AS SectionTitle FROM  Assessment u 
//INNER JOIN Section ur ON ur.SCID =u.SCID " + w + " ORDER BY Status DESC, Priority ASC");
            string strcmd = @"
                ;WITH Assessment_cte AS (
                SELECT u.*,ur.Title AS SectionTitle
                FROM dbo.Assessment u
                INNER JOIN Section ur ON ur.SCID =u.SCID  
                WHERE u.ASID >0 " + cfilter +
                //(string.IsNullOrEmpty(search) ? "" : "AND  (FirstName LIKE @search  OR LastName LIKE @search OR Email LIKE @search) ") +
                
                //(columnFilters.Count > 0 ? strfilter.ToString() : "")
                //OR LastName LIKE '%@CustomKeyValue%' OR Email LIKE '%@CustomKeyValue%'
                @"
            )

            SELECT 
                db.*,
                tCountOrders.CountOrders AS TotalRows
            FROM Assessment_cte db
                CROSS JOIN (SELECT Count(*) AS CountOrders FROM Assessment_cte) AS tCountOrders
            ORDER BY  " + (!string.IsNullOrEmpty(sortOrder) ? sortOrder : " Status DESC, Priority ASC ") + @" 
            OFFSET @Start ROWS
            FETCH NEXT @Size ROWS ONLY;
            ";

            // ORDER BY UserID, " + sortOrder + @"
            //cmd.Parameters.Add("@UserCatId", SqlDbType.TinyInt).Value = mu.UserCatId;
            cmd.Parameters.Add("@Start", SqlDbType.Int).Value = start;
            cmd.Parameters.Add("@Size", SqlDbType.Int).Value = length;


            if (!string.IsNullOrEmpty(search))
            {
                string searchTerm = string.Format("%{0}%", search);
                cmd.Parameters.Add(new SqlParameter("@search", searchTerm));
                //cmd.Parameters.Add("@search", SqlDbType.NVarChar).Value = searchTerm;
            }

            


            cmd.CommandText = strcmd;
            cmd.Connection = cn;
            cn.Open();



            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));

        }

    }




}