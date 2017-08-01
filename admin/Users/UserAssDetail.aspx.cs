using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_UserAssDetail : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ts"]))
            {
                int tsID = int.Parse(Request.QueryString["ts"]);

                Model_UsersAssessment uss = new Model_UsersAssessment();
                List<Model_UsersAssessment> ussList = uss.GetUserAssessmentByTsID(tsID);


                StringBuilder ret = new StringBuilder();

                ret.Append("<div class=\"table-responsive\">");
                ret.Append("<table class=\"table table-striped\">");
                ret.Append("<thead>");
                ret.Append("<tr>");

                ret.Append("<th>Code</th>");
                ret.Append("<th>Question</th>");
                ret.Append("<th>Question Type </th>");
                ret.Append("<th>Section </th>");
                ret.Append("<th>SubSection </th>");
                ret.Append("<th>Score </th>");
                //ret.Append("<th>Task</th>");
                //ret.Append("<th>Date</th>");
                //ret.Append("<th>Date</th>");
                //ret.Append("<th >Action</th>");
                
                ret.Append("</tr>");
                ret.Append("</thead>");
                ret.Append("<tbody>");

                foreach (Model_UsersAssessment item in ussList)
                {
                    ret.Append("<tr>");

                    Model_UsersAssChoice ch = new Model_UsersAssChoice();
                    List<Model_UsersAssChoice> chlist = ch.GetUserAssessmentChoiceByTsID(item.TASID);

                    ret.Append("<td><input type=\"checkbox\" name=\"TASID\" checked=\"checked\" value=\"" + item.TASID + "\" /><input type=\"text\" class=\"form-control\" style=\"text-align:center;\" name=\"TASID_code_" + item.TASID + "\" value=\"" + item.Code + "\" /></td>");
                    ret.Append("<td>" + item.Questions + "</td>");
                    ret.Append("<td>" + item.QuestionTypeTitle +  (item.QTID == 5?  " <br/><strong>[" + item .GroupName+ "]["+(item.Side == 1? "Left":"Right")+"]</strong>" : "" ) + "</td>");
                    ret.Append("<td>" + item.SectionTitle + "</td>");
                    ret.Append("<td>" + item.SubSectionTitle + "</td>");
                    ret.Append("<td><input type=\"text\"  name=\"TASID_score_" + item.TASID + "\" class=\"form-control\" style=\"text-align:center;\" value=\"" + item.Score + "\" /></td>");
                    ret.Append("</tr>");

                    if(chlist.Count > 0)
                    {
                        ret.Append("<tr>");
                        ret.Append("<td colspan=\"6\">");


                        ret.Append("<table class=\"table \">");
                        ret.Append("<thead>");
                        ret.Append("<tr>");

                        ret.Append("<th>Code</th>");
                        ret.Append("<th>Question</th>");
                       
                        ret.Append("<th>SubSection </th>");
                        ret.Append("<th>Score </th>");
                        ret.Append("</tr>");
                        ret.Append("</thead>");
                        ret.Append("<tbody>");
                        foreach (Model_UsersAssChoice choice in chlist)
                        {
                            ret.Append("<tr>");
                            ret.Append("<td><input type=\"checkbox\" name=\"TASCID\" checked=\"checked\" value=\"" + choice.TASCID + "\" /><input type=\"text\" class=\"form-control\" style=\"text-align:center;\" name=\"TASCID_code_" + choice.TASCID + "\" value=\"" + choice.Code + "\" /></td>");
                            ret.Append("<td>" + choice.Questions + "</td>");
                            ret.Append("<td>" + choice.SubSectionTitle + "</td>");
                            ret.Append("<td><input type=\"text\" name=\"TASCID_score_" + choice.TASCID + "\" class=\"form-control\" style=\"text-align:center;\" value=\"" + choice.Score + "\" /></td>");
                           ;
                            ret.Append("</tr>");
                        }
                            

                        ret.Append("</tbody>");

                        ret.Append("</table>");

                        ret.Append("</td>");
                        ret.Append("</tr>");
                    }
                }
                   

                ret.Append("</tbody>");
                ret.Append("</table>");
                ret.Append("</div>");

               



                data.Text = ret.ToString();

                                                  



            }

        }
    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        Model_UsersAssChoice choice = new Model_UsersAssChoice();
        Model_UsersAssessment assUser = new Model_UsersAssessment();
        string ass = Request.Form["TASID"];
        if (!string.IsNullOrEmpty(ass))
        {
            string[] arrAss = ass.Split(',');
            if (arrAss.Length > 0)
            {
                foreach (string item in arrAss)
                {
                    // TASID,int Score, string Code
                    int TASID = int.Parse(item);
                    int Score = int.Parse(Request.Form["TASID_code_"+ item]);
                    string Code = Request.Form["TASID_score_"+ item].ToString();
                    assUser.UpdateUserAssbyID(TASID, Score, Code);
                }
            }



        }

        string ch = Request.Form["TASCID"];
        if (!string.IsNullOrEmpty(ch))
        {
            string[] arrCh = ch.Split(',');
            if (arrCh.Length > 0)
            {
                foreach (string item in arrCh)
                {
                    //TASCID, int Score, string Code
                    int TASCID = int.Parse(item);
                    int Score = int.Parse(Request.Form["TASCID_code_" + item]);
                    string Code = Request.Form["TASCID_score_" + item].ToString();
                    assUser.UpdateUserAssbyID(TASCID, Score, Code);
                }
            }



        }
    }
}