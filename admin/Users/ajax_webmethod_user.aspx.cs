﻿using MVCDatatableApp;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNet.Identity;
using Excel;
using System.Data;
using System.Data.OleDb;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;
using System.Collections.Generic;

public partial class admin_Users_ajax_webmethod_user : System.Web.UI.Page
{
    //protected void Page_Load(object sender, EventArgs e)
    //{

    //}

    [WebMethod]
    public static void DataAll(DTParameters parameters)
    {

        AppTools.SendResponse(HttpContext.Current.Response, UsersController.GetUserRole_DatatbleView(parameters).ObjectToJSON());
    }


    [WebMethod]
    public static void GetRoleAll(Model_usersRole parameters)
    {
        IList<Model_usersRole> ret = UsersController.GetRoleAll(parameters);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }

    [WebMethod]
    public static void GetAll(Model_Users parameters)
    {


        IList<Model_Users> ret = UsersController.GetUsers_Paging(parameters);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }

    [WebMethod]
    public static void GetTsAll(Model_UsersTransaction parameters)
    {


        IList<Model_UsersTransaction> ret = UsersController.getUserTransaction(parameters);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }

}