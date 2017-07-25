﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class _AssessmentStep : BasePageFront
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Model_Users u = this.UserActive;
        if (u != null)
        {


            //Get Main Intro
            Model_AssesIntro intro = new Model_AssesIntro();
            intro = intro.GetIntro();


            //Get Job Function
            Model_CJF cjf = new Model_CJF();
            List<Model_CJF> cjflist = cjf.GetCJFeAll();

            //Get Functional Competencies
            Model_FC fc = new Model_FC();
            List<Model_FC> fclist = fc.GetFCAll();


            //Get Section 
            Model_AsSection section = new Model_AsSection();
            List<Model_AsSection> sectionlist = section.GetListSection();

            //Get Assessment
            Model_Assessment ass = new Model_Assessment();
            List<Model_Assessment> asslist = ass.GetAssessmentAll();

            //Get Country
            Model_Country c = new Model_Country();
            List<Model_Country> ccountry = c.GetAllCountry();


            dropNation.DataSource = ccountry;
            dropNation.DataTextField = "DropValue";
            dropNation.DataValueField = "ID";
            dropNation.DataBind();

            dropNation.SelectedValue = "211";


            //stepprofile_head.Visible = false;
            //stepprofile.Visible = false;



            IntroTitle.Text = intro.Title;
            IntroDetail.Text = convertcontent(intro.Description);

            LastTitle.Text = intro.LastTitle;
            LastDes.Text = convertcontent(intro.LastDes);

            Maintitle.Text = intro.MainTitle;

            StringBuilder ret = new StringBuilder();
            foreach (Model_AsSection sec in sectionlist)
            {
                //string sIntro = sec.Title;
                //string sDetail = convertcontent(sec.Intro);

                List<Model_Assessment> list = asslist.Where(r => r.SCID == sec.SCID).OrderBy(r=>r.Priority).OrderBy(r=>r.GroupName).ToList();
                if(list.Count > 0)
                {
                    ret.Append(GenSectionIntro(sec));


                    foreach (Model_Assessment asi in list)
                    {
                        string question = asi.Questions;
                        int rs = asi.StartRank;
                        int rd = asi.EndRank;

                        byte questionType = asi.QTID;



                        // 1   Scale
                        //4   Ranking Scale
                        //5   Left / Right Ranking
                        switch (questionType)
                        {
                            //Scale
                            case 1:
                                ret.Append(GenQuestionTypeScale(asi));
                                break;
                            //Ranking Scale
                            case 4:
                                ret.Append(GenQuestionTypeRankingScalChoice(asi));
                                break;
                            //Left / Right Ranking
                            case 5:
                                ret.Append(GenQuestionTypeRankLeftRigth(asi));
                                break;
                        }

                    }
                }
                


            }

            Stepcontent.Text = ret.ToString();
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
            ret.Append("<div class=\"text-center m-t-md\">");
            ret.Append("<h2></h2>");



            ret.Append("<div class=\"question-type q-type-rank-scale-lr\">");


            ret.Append("<div class=\"col-md-5 tbl-rank-scale-lr\"   >");
            ret.Append("<table>");
            ret.Append(" <tr><td colspan=\"5\" class=\"question left\">" + ass.Questions + "</td></tr>");
            ret.Append("<tr>");
            for (int i = ass.StartRank; i <= ass.EndRank; i++)
            {
                ret.Append("<td class=\"choice\">"+i+"</td>");
            }
                //ret.Append("<tr><td class=\"choice\">1</td><td class=\"choice\">2</td><td class=\"choice\">3</td><td class=\"choice\">4</td>");
            //ret.Append("<td class=\"choice\">5</td></tr>");
            ret.Append("</tr><tr>");
            for (int i = ass.StartRank; i <= ass.EndRank; i++)
            {
                ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"le\" /></td>");
            }
            //ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"le\" /></td>");
            //ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"le\" /></td>");
            //ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"le\" /></td>");
            //ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"le\" /></td>");
            //ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"le\" /></td>");
            ret.Append("</tr>");
            ret.Append("</table>");
            ret.Append("</div>");

            ret.Append("<div class=\"col-md-2\"></div>");
        }
        if (ass.Side == 2)
        {
            ret.Append("<div class=\"col-md-5 tbl-rank-scale-lr\" >");
            ret.Append("<table>");
            ret.Append("<tr><td colspan=\"5\" class=\"question right\">" + ass.Questions + "</td></tr>");
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
                ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"le\" /></td>");
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

    public void rigth()
    {
        StringBuilder ret = new StringBuilder();
        ret.Append("<div class=\"col-md-5 tbl-rank-scale-lr\" >");
        ret.Append("<table>");
        ret.Append("<tr><td colspan=\"5\" class=\"question right\">ทุ่มเททํางาน อย่างหนัก </td></tr>");
        ret.Append("<tr><td class=\"choice\">1</td><td class=\"choice\">2</td><td class=\"choice\">3</td><td class=\"choice\">4</td>");
        ret.Append("<td class=\"choice\">5</td></tr>");
        ret.Append("<tr>");
        ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"le\" /></td>");
        ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"le\" /></td>");
        ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"le\" /></td>");
        ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"le\" /></td>");
        ret.Append("<td class=\"choice\"><input type=\"radio\" name=\"le\" /></td>");
        ret.Append("</tr>");
        ret.Append("</table>");
        ret.Append("</div>");
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
        ret.Append("<h2>"+sec.Title+"</h2>");
        ret.Append("<p>" + convertcontent(sec.Intro) + "</p>");
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
            ret.Append("<td><input type=\"radio\"  name=\"1ss\" /></td>");
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
        ret.Append("<h1 class=\"step_count\"></h1>");
        ret.Append("<div class=\"step-content\">");
        ret.Append("<div class=\"text-center m-t-md\">");
        ret.Append("<h2>"+ass.Questions+"</h2>");



        ret.Append("<div class=\"question-type q-type-rank-scale-choice\">");
        ret.Append("<div class=\"col-md-12 tbl-rank-scale\" >");

        ret.Append("<table>");
        ret.Append("<tr>");
        ret.Append("<td class=\"question\"></td>");
        for (int i = ass.StartRank; i <= ass.EndRank; i++)
        {
           
            if (i == ass.StartRank)
                ret.Append("<td class=\"choice\">" + i + "<br /><span>" + ass.LeftScaleTitle + "</span></td>");
            else if (i == ass.EndRank)
                ret.Append("<td class=\"choice\">" + i + "<br /> <span>" + ass.RigthScaleTitle + "</span>  </td>");
            else
                ret.Append("<td class=\"choice\">" + i + "</td>");
        }
           
        ret.Append(" </tr>");

        List<Model_Assessment_Choice> choice = ass.AssChoice;

        if(choice.Count > 0)
        {
            foreach(Model_Assessment_Choice ch in choice)
            {
                ret.Append("<tr>");
                ret.Append("<td class=\"question\">"+ch.Questions+"</td>");

                for (int i = ass.StartRank; i <= ass.EndRank; i++)
                {
                    ret.Append("<td class=\"choice\"><input type=\"radio\"  name=\"1ss\" /></td>");
                }
               
                ret.Append("</tr>");
            }
           
        }

        





        ret.Append("</table>");
        ret.Append("</div>");
        ret.Append("</div>");



        ret.Append("</div>");
        ret.Append("</div>");

        return ret.ToString();


    }


   

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("sss");
        Response.End();
    }
}