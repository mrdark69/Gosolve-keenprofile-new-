using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class __AssessmentStepCheck : BasePageFront
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {

            if (!string.IsNullOrEmpty(Request.QueryString["success"]))
            {
                main_thanks.Visible = true;
                main_form.Visible = false;

                Model_AssesIntro intro = new Model_AssesIntro();
                intro = intro.GetIntro();
                ThanksTitle.Text = intro.ThanksTitle;
                ThanksDes.Text = convertcontent(intro.ThanksDes);
            }
            else
            {
                Model_Users u = this.UserActive;
                if (u != null)
                {
                    heUserID.Value = u.UserID.ToString();



                    if (!string.IsNullOrEmpty(Request.QueryString["ts"]))
                    {
                        int intTs = int.Parse(Request.QueryString["ts"]);

                        hdTsID.Value = intTs.ToString();

                        Model_ReportItemResult cr = new Model_ReportItemResult();
                        Model_UsersAssessment us = new Model_UsersAssessment();

                        List<Model_UsersAssessment> uss = us.GetUserAssessmentByTsID(intTs);

                        List<Model_ReportItemResult> crl = cr.GetItemReportByTransactionID(intTs);


                        List<Model_ReportItemResult> dup = crl.Where(o => o.IsDup).ToList();


                        Dictionary<decimal, int> GroupDup = dup.GroupBy(x => (decimal)x.Score_new)
                        .Where(g => g.Count() > 1)
                        .ToDictionary(x => x.Key, y => y.Count());



                        int numStep = GroupDup.Count();

                        StringBuilder ret = new StringBuilder();

                        int count = 1;
                        foreach (KeyValuePair<decimal, int> q in GroupDup)
                        {

                            List<Model_ReportItemResult> dupfocus = dup.Where(d => d.Score_new == q.Key).OrderByDescending(r => r.Score_new).ToList();

                            ret.Append("<h1 class=\"step_count\"></h1>\r\n");
                            ret.Append("<div class=\"step-content\" data-valid=\"check_choice\" data-count=\"" + (dupfocus.Count < 3 ? 3 : dupfocus.Count) + "\">\r\n");
                            ret.Append("<input type=\"hidden\" name=\"ass_fill_\"  value=\"" + count + "\" />\r\n");

                            ret.Append("<div class=\"text-center m-t-md\">\r\n");
                            ret.Append("<h2>XXXXXXX</h2>\r\n");


                            ret.Append("<div class=\"question-type q-type-rank-scale-choice\">\r\n");
                            ret.Append("<div class=\"col-md-12 tbl-rank-scale\" >\r\n");

                            ret.Append("<table>\r\n");
                            ret.Append("<tr>\r\n");
                            ret.Append("<td class=\"question\"></td>\r\n");
                            //ret.Append("<input type=\"hidden\"   name=\"ass_fill_i_sc_" + ass.ASID + "\" value=\"0\" />");
                            for (int i = 1; i <= (dupfocus.Count < 3 ? 3 : dupfocus.Count); i++)
                            {

                                if (i == 1)
                                    ret.Append("<td class=\"choice\">" + i + "<br /><span>XXXXX</span></td>\r\n");
                                else if (i == (dupfocus.Count < 3 ? 3 : dupfocus.Count))
                                    ret.Append("<td class=\"choice\">" + i + "<br /> <span>XXXXX</span>  </td>\r\n");
                                else
                                    ret.Append("<td class=\"choice\">" + i + "</td>\r\n");
                            }

                            ret.Append(" </tr>\r\n");

                            

                            if (dupfocus.Count > 0)
                            {
                                foreach (Model_ReportItemResult ch in dupfocus)
                                {
                                    Model_UsersAssessment assuser = uss.FirstOrDefault(o => o.TASID == ch.TASID);
                                    if(assuser != null)
                                    {
                                        ret.Append("<tr>\r\n");
                                        ret.Append("<input type=\"hidden\" name=\"ass_fill_ch_\"  value=\"" + ch.TASID + "\" />\r\n");
                                        ret.Append("<td class=\"question\">" + assuser.Questions + "</td>\r\n");

                                        for (int i = 1; i <= (dupfocus.Count < 3? 3: dupfocus.Count); i++)
                                        {
                                            //ret.Append("<td class=\"choice\"><input type=\"radio\"   name=\"ass_fill_ch_sc_" + ch.ResultID + "\" value=\"" + i + "\" /></td>\r\n");
                                            ret.Append("<td class=\"choice\"><input type=\"radio\"   name=\"ass_fill_ch_sc_" + ch.TASID + "\" value=\"" + i + "\" /></td>\r\n");
                                        }

                                        ret.Append("</tr>\r\n");
                                    }
                                    
                                }

                                
                                if (dupfocus.Count < 3)
                                {
                                    List<Model_UsersAssessment> randomlist = new List<Model_UsersAssessment>();

                                    foreach(Model_UsersAssessment i in uss)
                                    {
                                        foreach (Model_ReportItemResult ch in dupfocus)
                                        {
                                            if (i.TASID != ch.TASID)
                                                randomlist.Add(i);
                                        }
                                    }

                                    Model_UsersAssessment rd = randomlist.Skip(3).FirstOrDefault();
                                    
                                    ret.Append("<tr>\r\n");
                                    //ret.Append("<input type=\"hidden\" name=\"ass_fill_ch_\"  value=\"" + rd.ResultID + "\" />\r\n");
                                    ret.Append("<td class=\"question\">" + rd.Questions + "</td>\r\n");

                                    for (int i = 1; i <= (dupfocus.Count < 3 ? 3 : dupfocus.Count); i++)
                                    {
                                        ret.Append("<td class=\"choice\"><input type=\"radio\"   name=\"ass_fill_ch_sc_"+ rd.TASID+ "\" value=\"" + i + "\" /></td>\r\n");
                                    }

                                    ret.Append("</tr>\r\n");
                                }

                            }



                            ret.Append("</table>\r\n");
                            ret.Append("</div>\r\n");
                            ret.Append("</div>\r\n");



                            ret.Append("</div>\r\n");
                            ret.Append("</div>\r\n");

                            count = count + 1;
                        }

                        Stepcontent.Text = ret.ToString();
                    }

                   
                    

                }
            }
           
        }
        else
        {
            //Button btn = (Button)sender;

            //Response.Write(chckCJF.SelectedValue);
        }
       



    }

    public string GenQuestionTypeRankLeftRigth(Model_Assessment ass)
    {

        //List<Model_Assessment_Choice> choice = ass.AssChoice;
        StringBuilder ret = new StringBuilder();

        if (ass.Side == 1)
        {
            ret.Append("<h1 class=\"step_count\"></h1>");
            ret.Append("<div class=\"step-content\">");

            ret.Append("<input type=\"hidden\" name=\"ass_fill_\"  value=\"" + ass.ASID + "\" />");
            ret.Append("<div class=\"text-center m-t-md\">");
            ret.Append("<h2></h2>");



            ret.Append("<div class=\"question-type q-type-rank-scale-lr\">");

            int col = (ass.EndRank - ass.StartRank) + 1;
            ret.Append("<div class=\"col-md-6 tbl-rank-scale-lr left\"   >");
            ret.Append("<table>");
            ret.Append(" <tr><td colspan=\""+ col + "\" class=\"question left\">" + ass.Questions + "</td></tr>");
            ret.Append("<tr>");
            for (int i = ass.EndRank; i >= ass.StartRank; i--)
            {
                ret.Append("<td class=\"choice\">"+i+"</td>");
            }
                //ret.Append("<tr><td class=\"choice\">1</td><td class=\"choice\">2</td><td class=\"choice\">3</td><td class=\"choice\">4</td>");
            //ret.Append("<td class=\"choice\">5</td></tr>");
            ret.Append("</tr><tr>");
            for (int i = ass.StartRank; i <= ass.EndRank; i++)
            {
                ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"ass_fill_i_sc_" + ass.ASID + "\" value=\"" + i + "\" /></td>");
            }
            //ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"le\" /></td>");
            //ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"le\" /></td>");
            //ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"le\" /></td>");
            //ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"le\" /></td>");
            //ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"le\" /></td>");
            ret.Append("</tr>");
            ret.Append("</table>");
            ret.Append("</div>");

            //ret.Append("<div class=\"col-md-1\"></div>");
        }
        if (ass.Side == 2)
        {
            int col = (ass.EndRank - ass.StartRank) + 1;
            ret.Append("<input type=\"hidden\" name=\"ass_fill_\"  value=\"" + ass.ASID + "\" />");
            ret.Append("<div class=\"col-md-6 tbl-rank-scale-lr right\" >");
            ret.Append("<table>");
            ret.Append("<tr><td colspan=\""+ col + "\" class=\"question right\">" + ass.Questions + "</td></tr>");
            ret.Append("<tr>");
            for (int i = ass.StartRank; i <= ass.EndRank; i++)
            {
                ret.Append("<td class=\"choice\">" + i + "</td>");
            }
                //ret.Append("<tr><td class=\"choice\">1</td><td class=\"choice\">2</td><td class=\"choice\">3</td><td class=\"choice\">4</td>");
            //ret.Append("<td class=\"choice\">5</td></tr>");
            ret.Append("</tr><tr>");
            for (int i = ass.StartRank; i <= ass.EndRank; i++)
            {
                ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"ass_fill_i_sc_" + ass.ASID + "\" value=\"" + i + "\" /></td>");
            }
            //    ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"le\" /></td>");
            //ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"le\" /></td>");
            //ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"le\" /></td>");
            //ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"le\" /></td>");
            //ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"le\" /></td>");
            ret.Append("</tr>");
            ret.Append("</table>");
            ret.Append("</div>");


            ret.Append("</div>");



            ret.Append("</div>");
            ret.Append("</div>");
        }


            

        return ret.ToString();


    }

   
    public string convertcontent(string content)
    {
        content = content.Replace("\r\n", "<br/>");
        content = content.Replace("[", "<strong>");
        content = content.Replace("]", "</strong>");
       // string strong = content.GetKeywordReplace("[", "]");

        return content;
    }
    public string GenSectionIntro(Model_AsSection sec)
    {
        StringBuilder ret = new StringBuilder();


        ret.Append("<h1 class=\"step_count\"></h1>");
        ret.Append("<div class=\"step-content\">");
        ret.Append("<div class=\"text-center m-t-md\">");
        //ret.Append("<h2>"+sec.Title+"</h2>");
        ret.Append("<p class=\"intro-detail\">" + convertcontent(sec.Intro) + "</p>");
        ret.Append("</div>");
        ret.Append(" </div>");

        return ret.ToString();

    }


   
    public string GenQuestionTypeScale(Model_Assessment ass)
    {

        //List<Model_Assessment_Choice> choice = ass.AssChoice;
        StringBuilder ret = new StringBuilder();
        ret.Append("<h1 class=\"step_count\"></h1>");

     

        ret.Append("<div class=\"step-content\">");
        ret.Append("<input type=\"hidden\" name=\"ass_fill_\"  value=\"" + ass.ASID + "\" />");
        ret.Append("<div class=\"text-center m-t-md\">");
        ret.Append("<h2>"+ass.Questions+"</h2>");

        ret.Append("<div class=\"question-type q-type-scale\">");
        ret.Append("<div class=\"col-md-3 left-ele\" >"+ass.LeftScaleTitle+" </div>");
        ret.Append("<div class=\"col-md-6 choice-ele\">");
        ret.Append("<table>");
        ret.Append("<tr>");

        for(int i = ass.StartRank; i<= ass.EndRank; i++)
        {
            ret.Append("<td>" + i + "</td>");
        }
        //ret.Append("<td>1</td> <td>2</td> <td>3</td> <td>4</td> <td>5</td>");
        ret.Append("</tr>");
        ret.Append("<tr>");

        for (int i = ass.StartRank; i <= ass.EndRank; i++)
        {
            ret.Append("<td><input type=\"radio\"   name=\"ass_fill_i_sc_" + ass.ASID+"\" value=\""+i+"\" /></td>");
        }
           
        ret.Append("</tr>");
        ret.Append("</table>");
        ret.Append("</div>");
        ret.Append("<div class=\"col-md-3 right-ele\"> " + ass.RigthScaleTitle + "</div>");

        ret.Append("</div>");




        ret.Append("</div>");
        ret.Append("</div>");

        return ret.ToString();


    }


    public string GenQuestionTypeRankingScalChoice(Model_Assessment ass)
    {
      
        StringBuilder ret = new StringBuilder();
        ret.Append("<h1 class=\"step_count\"></h1>\r\n");
        ret.Append("<div class=\"step-content\">\r\n");
        ret.Append("<input type=\"hidden\" name=\"ass_fill_\"  value=\"" + ass.ASID + "\" />\r\n");

        ret.Append("<div class=\"text-center m-t-md\">\r\n");
        ret.Append("<h2>"+ass.Questions+"</h2>\r\n");

        
        ret.Append("<div class=\"question-type q-type-rank-scale-choice\">\r\n");
        ret.Append("<div class=\"col-md-12 tbl-rank-scale\" >\r\n");

        ret.Append("<table>\r\n");
        ret.Append("<tr>\r\n");
        ret.Append("<td class=\"question\"></td>\r\n");
        ret.Append("<input type=\"hidden\"   name=\"ass_fill_i_sc_" + ass.ASID + "\" value=\"0\" />");
        for (int i = ass.StartRank; i <= ass.EndRank; i++)
        {
           
            if (i == ass.StartRank)
                ret.Append("<td class=\"choice\">" + i + "<br /><span>" + ass.LeftScaleTitle + "</span></td>\r\n");
            else if (i == ass.EndRank)
                ret.Append("<td class=\"choice\">" + i + "<br /> <span>" + ass.RigthScaleTitle + "</span>  </td>\r\n");
            else
                ret.Append("<td class=\"choice\">" + i + "</td>\r\n");
        }
           
        ret.Append(" </tr>\r\n");

        List<Model_Assessment_Choice> choice = ass.AssChoice;

        if(choice.Count > 0)
        {
            foreach(Model_Assessment_Choice ch in choice)
            {
                ret.Append("<tr>\r\n");
                ret.Append("<input type=\"hidden\" name=\"ass_fill_ch_"+ ass.ASID + "\"  value=\"" + ch.ASCID + "\" />\r\n");
                ret.Append("<td class=\"question\">"+ch.Questions+"</td>\r\n");

                for (int i = ass.StartRank; i <= ass.EndRank; i++)
                {
                    ret.Append("<td class=\"choice\"><input type=\"radio\"   name=\"ass_fill_ch_sc_" + ass.ASID + "_"+ ch.ASCID+ "\" value=\"" + i + "\" /></td>\r\n");
                }
               
                ret.Append("</tr>\r\n");
            }
           
        }
        


        ret.Append("</table>\r\n");
        ret.Append("</div>\r\n");
        ret.Append("</div>\r\n");



        ret.Append("</div>\r\n");
        ret.Append("</div>\r\n");

        return ret.ToString();


    }


   

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("sss");
        Response.End();
    }

    protected void btnBackprofile_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default#download");
    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default#download");
    }
}