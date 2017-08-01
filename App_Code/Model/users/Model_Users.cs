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
public class Model_Users : BaseModel<Model_Users>
{

    public int UserID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime DateofBirth { get; set; }
    public byte Gender { get; set; }
    public int Nationality { get; set; }
    public string MobileNumber { get; set; }

    public byte UserCatId { get; set; }
    public byte UsersRoleId { get; set; }
    public bool Status { get; set; }
    public bool EmailVerify { get; set; }

    public DateTime DateSubmit  { get; set; } = DatetimeHelper._UTCNow();

    public bool Ispaid { get; set; }
    public DateTime DatePayment { get; set; }

    public string UserRoleName { get; set; }

    public bool IsResetPassword { get; set; } = false;


    public int TotalRows { get; set; }
    public int RowNum { get; set; }


    public DTParameters PagingParam { get; set; }
   


    private List<Model_UserFC> _userfc = null;
    public List<Model_UserFC> UserFC {
        get
        {
            if(_userfc == null)
            {
                Model_UserFC ufc = new Model_UserFC();
                _userfc = ufc.GetListUserFc(this.UserID);
            }
            return _userfc;
        }
    }
    private List<Model_UserCJF> _usercjf = null;
    public List<Model_UserCJF> UserCJF
    {
        get
        {
            if (_usercjf == null)
            {
                Model_UserCJF ufc = new Model_UserCJF();
                _usercjf = ufc.GetListUsercjf(this.UserID);
            }
            return _usercjf;
        }
    }
    private string _nationalityTitle = string.Empty;
    public string NationalityTitle {

        get
        {
            if (string.IsNullOrEmpty(_nationalityTitle) && this.Nationality>0)
            {
                Model_Country c = new Model_Country();
                c = c.GetAllCountryByID(this.Nationality);
                _nationalityTitle = c.Nationality;
            }
            return _nationalityTitle;
        }

        
    }

    public Model_Users()
    {
        //
        // TODO: Add constructor logic here
        //
    }

#region Hide unfocus
    public int InsertUserAdmin(Model_Users users)
    {
        int ret = 0;
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmdcheck = new SqlCommand("SELECT COUNT(*) FROM Users WHERE UserName=@UserName AND Password=@Password AND UserCatId=2", cn);
            cmdcheck.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = users.UserName;
            cmdcheck.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Hotels2MD5EncryptedData(users.Password);
            cn.Open();
            if((int)ExecuteScalar(cmdcheck) > 0)
            {
                ret = -1;
            }
            else
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO Users (FirstName,LastName,UserName,Password,Status,UserCatId,UsersRoleId,DateSubmit)
VALUES(@FirstName,@LastName,@UserName,@Password,@Status,@UserCatId,@UsersRoleId,@DateSubmit)", cn);

                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = users.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = users.LastName;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = users.UserName;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Hotels2MD5EncryptedData(users.Password);
                cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
                cmd.Parameters.Add("@UserCatId", SqlDbType.TinyInt).Value = users.UserCatId;
                cmd.Parameters.Add("@UsersRoleId", SqlDbType.TinyInt).Value = users.UsersRoleId;
                cmd.Parameters.Add("@DateSubmit", SqlDbType.SmallDateTime).Value = users.DateSubmit;

                ret = ExecuteNonQuery(cmd);
            }
           
        }
        return ret;
    }

    public int InsertUser(Model_Users users)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmdcheck = new SqlCommand("SELECT COUNT(*) FROM Users WHERE UserName=@UserName  AND UserCatId=1", cn);
            cmdcheck.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = users.UserName;
            //cmdcheck.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Hotels2MD5EncryptedData(users.Password);
            cn.Open();
            if ((int)ExecuteScalar(cmdcheck) > 0)
            {
                ret = -1;
            }
            else
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO Users (Email,UserName,Password,Status,UserCatId,DateSubmit)
VALUES(@Email,@UserName,@Password,@Status,@UserCatId,@DateSubmit);SET @UserID = SCOPE_IDENTITY();", cn);

                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = users.Email;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = users.UserName;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Hotels2MD5EncryptedData(users.Password);
                cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
                cmd.Parameters.Add("@UserCatId", SqlDbType.TinyInt).Value = users.UserCatId;
                cmd.Parameters.Add("@DateSubmit", SqlDbType.SmallDateTime).Value = users.DateSubmit;
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Direction = ParameterDirection.Output;

                ret = ExecuteNonQuery(cmd);

                if(ret > 0)
                    ret = (int)cmd.Parameters["@UserID"].Value;
            }

        }
        return ret;
    }


    public bool UpdateUserAdmin(Model_Users users)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            string w = string.Empty;
           
            SqlCommand cmd = new SqlCommand();
            if (IsResetPassword)
            {
                w = ", Password=@Password";
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Hotels2MD5EncryptedData(users.Password);
            }
            string q = @"UPDATE Users SET FirstName=@FirstName ,LastName=@LastName, UserName=@UserName " + w + " ,UsersRoleId=@UsersRoleId WHERE UserID=@UserID";
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = users.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = users.LastName;
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = users.UserName;
           
            cmd.Parameters.Add("@UsersRoleId", SqlDbType.TinyInt).Value = users.UsersRoleId;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = users.UserID;
            cmd.CommandText = q;
            cmd.Connection = cn;
           
            cn.Open();

            return ExecuteNonQuery(cmd) == 1;
        }

    }

    public bool UpdateUserProfileFront(Model_Users users)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            string w = string.Empty;

            SqlCommand cmd = new SqlCommand();
           
            string q = @"UPDATE Users SET FirstName=@FirstName ,LastName=@LastName 
            ,DateofBirth=@DateofBirth,Gender=@Gender,Nationality=@Nationality,MobileNumber=@MobileNumber WHERE UserID=@UserID";
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = users.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = users.LastName;
          

            cmd.Parameters.Add("@DateofBirth", SqlDbType.SmallDateTime).Value = users.DateofBirth;
            cmd.Parameters.Add("@Gender", SqlDbType.TinyInt).Value = users.Gender;
            cmd.Parameters.Add("@Nationality", SqlDbType.Int).Value = users.Nationality;
            cmd.Parameters.Add("@MobileNumber", SqlDbType.VarChar).Value = users.MobileNumber;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = users.UserID;
            cmd.CommandText = q;
            cmd.Connection = cn;

            cn.Open();

            return ExecuteNonQuery(cmd) == 1;
        }

    }


    public int UpdateUserProfileUserEdit(Model_Users users)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            string w = string.Empty;

            Model_Users uu = null;
           

            SqlCommand cmd1 = new SqlCommand("SELECT * FROM  Users WHERE UserName=@UserName AND UserID<>@UserID", cn);
            cmd1.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = users.Email;
            cmd1.Parameters.Add("@UserID", SqlDbType.Int).Value = users.UserID;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd1, CommandBehavior.SingleRow);
            if (reader.Read())
                 uu = MappingObjectFromDataReaderByName(reader);

            reader.Close();

            if (uu == null)
            {
                SqlCommand cmd = new SqlCommand();

                string q = @"UPDATE Users SET FirstName=@FirstName ,LastName=@LastName ,Email=@Email,UserName=@UserName
            ,DateofBirth=@DateofBirth,Gender=@Gender,Nationality=@Nationality,MobileNumber=@MobileNumber WHERE UserID=@UserID";
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = users.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = users.LastName;

                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = users.Email;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = users.Email;

                cmd.Parameters.Add("@DateofBirth", SqlDbType.SmallDateTime).Value = users.DateofBirth;
                cmd.Parameters.Add("@Gender", SqlDbType.TinyInt).Value = users.Gender;
                cmd.Parameters.Add("@Nationality", SqlDbType.Int).Value = users.Nationality;
                cmd.Parameters.Add("@MobileNumber", SqlDbType.VarChar).Value = users.MobileNumber;
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = users.UserID;
                cmd.CommandText = q;
                cmd.Connection = cn;

                ret = ExecuteNonQuery(cmd);
            }else
            {
                ret = -1;
            }





            return ret;
        }

    }

    public bool UpdateUserProfile(Model_Users users)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            string w = string.Empty;

            SqlCommand cmd = new SqlCommand();
            if (IsResetPassword)
            {
                w = ", Password=@Password";
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Hotels2MD5EncryptedData(users.Password);
            }
            string q = @"UPDATE Users SET FirstName=@FirstName ,LastName=@LastName, UserName=@UserName " + w + " ,UsersRoleId=@UsersRoleId WHERE UserID=@UserID";
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = users.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = users.LastName;
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = users.UserName;

            cmd.Parameters.Add("@UsersRoleId", SqlDbType.TinyInt).Value = users.UsersRoleId;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = users.UserID;
            cmd.CommandText = q;
            cmd.Connection = cn;

            cn.Open();

            return ExecuteNonQuery(cmd) == 1;
        }

    }

    public bool UpdateUserVerify(Model_Users users)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            string w = string.Empty;

            SqlCommand cmd = new SqlCommand();
            
            string q = @"UPDATE Users SET EmailVerify=@EmailVerify  WHERE UserID=@UserID";
            cmd.Parameters.Add("@EmailVerify", SqlDbType.Bit).Value = true;
          
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = users.UserID;
            cmd.CommandText = q;
            cmd.Connection = cn;

            cn.Open();

            return ExecuteNonQuery(cmd) == 1;
        }
    }

    public bool UpdatePassword(Model_Users users)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            string w = string.Empty;

            SqlCommand cmd = new SqlCommand();

            string q = @"UPDATE Users SET Password=@Password  WHERE UserID=@UserID";
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Hotels2MD5EncryptedData(users.Password);

            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = users.UserID;
            cmd.CommandText = q;
            cmd.Connection = cn;

            cn.Open();

            return ExecuteNonQuery(cmd) == 1;
        }
    }


    public Model_Users CheckLoginAdmin(string strUserName, string strPassword)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserName=@UserName AND Password=@Password AND UserCatId=2", cn);
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = strUserName;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Hotels2MD5EncryptedData(strPassword);
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return  MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }

    public Model_Users CheckLoginUser(string strUserName, string strPassword)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserName=@UserName AND Password=@Password AND UserCatId=1", cn);
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = strUserName;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Hotels2MD5EncryptedData(strPassword);
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }


    //Encode by MD5 (cant Decode)
    private string Hotels2MD5EncryptedData(string input)
    {
        MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
        byte[] data = Encoding.ASCII.GetBytes(input);
        byte[] encryptedData = md5Provider.ComputeHash(data);
        string encryptedString = Convert.ToBase64String(encryptedData);
        return encryptedString;
    }

    public Model_Users getUserbyID(int intUserID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            StringBuilder cText = new StringBuilder();
            cText.Append("SELECT * FROM  Users WHERE UserID=@UserID");
            
            SqlCommand cmd = new SqlCommand(cText.ToString(), cn);
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = intUserID;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }

    public Model_Users getUserbyEmailFront(string strEamil)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            StringBuilder cText = new StringBuilder();
            cText.Append("SELECT * FROM  Users WHERE UserName=@UserName");

            SqlCommand cmd = new SqlCommand(cText.ToString(), cn);
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = strEamil;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }
#endregion
    public IList<Model_Users> getUserAll(Model_Users mu)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder cText = new StringBuilder();
           
            string w = string.Empty;

            if (mu.UsersRoleId > 0)
            {
                w = "AND u.UsersRoleId =@UsersRoleId";
                cmd.Parameters.Add("@UsersRoleId", SqlDbType.TinyInt).Value = mu.UsersRoleId;

            }
            cText.Append(@"SELECT u.*,ur.Title AS UserRoleName FROM  Users u 
LEFT JOIN UsersRole ur ON ur.UsersRoleId =u.UsersRoleId WHERE u.UserCatId = @UserCatId" + w);

            cmd.Parameters.Add("@UserCatId", SqlDbType.TinyInt).Value = mu.UserCatId;

            cmd.CommandText = cText.ToString();
            cmd.Connection = cn;
          
          
            cn.Open();

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }


    public IList<Model_Users> getUserAll_Paging(Model_Users mu)
    {

        string search =  (mu.PagingParam.Search != null? mu.PagingParam.Search.Value:"");
        string sortOrder = mu.PagingParam.SortOrder;
        int start = mu.PagingParam.Start;
        int length = mu.PagingParam.Length;
        //List<string> columnFilters = DataTablesJS<Model_Users>.getcolumnSearch(mu.PagingParam);

        List<DTCustomSerach> custom = mu.PagingParam.CustomSearchList;

        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {


            string[] filerName = { "", "", "FirstName", "LastName", "Email" };
            StringBuilder strfilter = new StringBuilder();



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
                foreach(DTCustomSerach f in custom)
                {
                    if(f.Key == "Search")
                    {
                        cfilter += (!string.IsNullOrEmpty(f.Value) ? " AND (FirstName LIKE '%'+@CustomKeyValue+'%' OR LastName LIKE '%'+@CustomKeyValue+'%' OR Email LIKE '%'+@CustomKeyValue+'%' OR MobileNumber LIKE '%'+@CustomKeyValue+'%')" : "");
                        cmd.Parameters.Add("@CustomKeyValue", SqlDbType.NVarChar).Value = f.Value;
                    }

                    if (f.Key == "caseissue")
                    {
                        if (!string.IsNullOrEmpty(f.Value))
                        {
                            switch (f.Value)
                            {
                                //Paid account
                                case "1":
                                    cfilter += " AND u.Ispaid = 1 ";
                                    break;
                                //Free account
                                case "2":
                                    cfilter += " AND u.Ispaid = 0 ";
                                    break;
                                //Waiting for verify email
                                case "3":
                                    cfilter += " AND u.EmailVerify = 0 ";
                                    break;
                                //Email verified EmailVerify
                                case "4":
                                    cfilter += " AND u.EmailVerify = 1 ";
                                    break;
                                //Assessment expired
                                case "5":
                                    break;
                                //Incomplete Profile
                                case "6":
                                    cfilter += " AND (u.FirstName IS NULL OR u.LastName IS NULL OR u.DateofBirth IS NULL OR u.Gender IS NULL OR u.Nationality IS NULL OR u.MobileNumber IS NULL)";
                                    break;
                            }
                        }
                          
                    }
                }
            }
            string w = string.Empty;
            if (mu.UsersRoleId > 0)
            {
                w = "AND u.UsersRoleId =@UsersRoleId";
                cmd.Parameters.Add("@UsersRoleId", SqlDbType.TinyInt).Value = mu.UsersRoleId;

            }
            string strcmd = @"
                ;WITH Users_cte AS (
                SELECT u.*,ur.Title AS UserRoleName
                FROM dbo.Users u
                LEFT JOIN UsersRole ur ON ur.UsersRoleId =u.UsersRoleId  
                WHERE u.UserCatId = @UserCatId " + w +
                //(string.IsNullOrEmpty(search) ? "" : "AND  (FirstName LIKE @search  OR LastName LIKE @search OR Email LIKE @search) ") +
                cfilter +
                //(columnFilters.Count > 0 ? strfilter.ToString() : "")
                //OR LastName LIKE '%@CustomKeyValue%' OR Email LIKE '%@CustomKeyValue%'
                @"
            )

            SELECT 
                db.*,
                tCountOrders.CountOrders AS TotalRows
            FROM Users_cte db
                CROSS JOIN (SELECT Count(*) AS CountOrders FROM Users_cte) AS tCountOrders
            ORDER BY  " + (!string.IsNullOrEmpty(sortOrder) ? sortOrder : " UserID ASC ") + @" 
            OFFSET @Start ROWS
            FETCH NEXT @Size ROWS ONLY;
            ";

            // ORDER BY UserID, " + sortOrder + @"
            cmd.Parameters.Add("@UserCatId", SqlDbType.TinyInt).Value = mu.UserCatId;
            cmd.Parameters.Add("@Start", SqlDbType.Int).Value = start;
            cmd.Parameters.Add("@Size", SqlDbType.Int).Value = length;


            //if (custom.Key != null && !string.IsNullOrEmpty(custom.Value))
            //    cmd.Parameters.Add("@CustomKeyValue", SqlDbType.NVarChar).Value = custom.Value;

            if (!string.IsNullOrEmpty(search))
            {
                string searchTerm = string.Format("%{0}%", search);
                cmd.Parameters.Add(new SqlParameter("@search", searchTerm));
                //cmd.Parameters.Add("@search", SqlDbType.NVarChar).Value = searchTerm;
            }

            //if (columnFilters.Count > 0)
            //{
            //    if (!string.IsNullOrEmpty(columnFilters[2]))
            //    {
            //        string searchTerm = string.Format("%{0}%", columnFilters[2]);
            //        cmd.Parameters.Add(new SqlParameter("@filer_2", searchTerm));
            //    }
            //    if (!string.IsNullOrEmpty(columnFilters[3]))
            //    {
            //        string searchTerm = string.Format("%{0}%", columnFilters[3]);
            //        cmd.Parameters.Add(new SqlParameter("@filer_3", searchTerm));
            //    }


            //}


            cmd.CommandText = strcmd;
            cmd.Connection = cn;
            cn.Open();



            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));

        }

    }


}