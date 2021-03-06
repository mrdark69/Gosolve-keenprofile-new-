﻿using System;
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
public class Model_UserFC : BaseModel<Model_UserFC>
{
    public int UserID { get; set; }
    public int FCID { get; set; }

    public string Title { get; set; }


    public int AddUserFC(List<Model_UserFC> userfc, int UserID)
    {
        int ret = 1;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM UserFC WHERE UserID=@UserID", cn);
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            cn.Open();
            ExecuteNonQuery(cmd);
            if(userfc.Count > 0)
            {
                foreach(Model_UserFC i in userfc)
                {
                    SqlCommand add = new SqlCommand("INSERT INTO UserFC (UserID,FCID) VALUES(@UserID,@FCID)", cn);
                    add.Parameters.Add("@UserID", SqlDbType.Int).Value = i.UserID;
                    add.Parameters.Add("@FCID", SqlDbType.Int).Value = i.FCID;
                    ret = ExecuteNonQuery(add);
                }
            }
           
        }
        return ret;
    }


    public List<Model_UserFC> GetListUserFc(int UserID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT uc.*,ff.Title FROM UserFC uc INNER JOIN FC ff ON ff.FCID=uc.FCID WHERE uc.UserID=@UserID", cn);
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }
}
public class Model_FC : BaseModel<Model_FC>
{
    public int FCID { get; set; }

    public string Title { get; set; }


    public bool Status { get; set; }
 


    public Model_FC()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<Model_FC> GetFCAll()
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM FC ", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public Model_FC GetFCByID(byte byid)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM FC WHERE FCID=@FCID", cn);
            cmd.Parameters.Add("@FCID", SqlDbType.Int).Value = byid;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    } 

    public bool UpdateFC(Model_FC q)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE FC SET Title=@Title,Status=@Status WHERE FCID=@FCID", cn);
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = q.Title;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = q.Status;
            cmd.Parameters.Add("@FCID", SqlDbType.Int).Value = q.FCID;
            cn.Open();

            return ExecuteNonQuery(cmd) == 1;
        }
    }


    public int AddFC(Model_FC q)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO FC (Title,Status) VALUES(@Title,@Status)", cn);
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = q.Title;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = q.Status;
            cn.Open();

            return ExecuteNonQuery(cmd);
        }
        
    }
}