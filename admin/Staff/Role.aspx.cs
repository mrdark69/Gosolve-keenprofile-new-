using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Role : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {

        }
    }


    protected string GetSideMenu()
    {
        StringBuilder ret = new StringBuilder();
        //List<Model_AppFeature> cmf = UsersController.GetMenu();

        //List<Model_AppFeature> cmf_child = UsersController.GetMenuChild();

        //foreach (Model_AppFeature item in cmf)
        //{
        //    List<Model_AppFeature> cmf_s = cmf_child.Where(c => c.IDRef == item.AppID).ToList();

        //    string slug = Page.ResolveClientUrl("~/" + item.Permarlink);
        //    bool IsChild = false;
        //    string arrow = string.Empty;
        //    string child = string.Empty;
        //    if (cmf_s.Count() > 0)
        //    {
        //        slug = "#";
        //        IsChild = true;
        //        arrow = "<span class=\"fa arrow\"></span>";

        //        child = String.Join(",", cmf_s.Select(r => r.Permarlink).ToArray());
        //    }


        //    ret.Append("<li >");
        //    ret.Append("<input type=\"checkbox\" name=\"rol-check\" value=\""+ item.AppID+ "\" />&nbsp;&nbsp;<span class=\"nav-label\">" + item.Title + "</span>");



        //    if (IsChild)
        //    {
        //        ret.Append("<ul class=\"nav nav-second-level app-sec-lev\">");
        //        foreach (Model_AppFeature i in cmf_s)
        //        {
        //            string slug_child = Page.ResolveClientUrl("~/" + i.Permarlink);
        //            ret.Append("<li ><input type=\"checkbox\" name=\"rol-check\" value=\"" + i.AppID + "\" /> &nbsp;&nbsp;<span class=\"nav-label\">" + i.Title + "</span></a>");
        //        }
        //        ret.Append("</ul>");
        //    }

        //    ret.Append("</li>");


        //}


        return ret.ToString();
    }

}