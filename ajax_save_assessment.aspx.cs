using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ajax_save_assessment : BasePageFront
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            int UserId = 0;

            //Profile Process

            string FirstName = Request.Form["ctl00$MainContent$firstName"];
            string LastName = Request.Form["ctl00$MainContent$LastName"]; 

            string bytGender = Request.Form["ctl00$MainContent$dropGender"];

            string Nationality = Request.Form["ctl00$MainContent$dropNation"];
            string DatBirth = Request.Form["ctl00$MainContent$day"];

            string Phone = Request.Form["ctl00$MainContent$txtPhon"];

            Model_Users us = new Model_Users
            {
                UserID = UserId,
                FirstName = FirstName,
                LastName = LastName,
                Gender = byte.Parse(bytGender),
                Nationality = int.Parse(Nationality),
                MobileNumber = Phone
            };

            us.UpdateUserProfileFront(us);


            //Fuction Competencies

            string FCCheck = Request.Form["chckFC_form"];

            

            if (!string.IsNullOrEmpty(FCCheck))
            {
                string[] arrfc = FCCheck.Split(',');
                if(arrfc.Length > 0)
                {
                    foreach(string i in arrfc)
                    {
                        Model_UserFC fc = new Model_UserFC {
                            FCID = int.Parse(i),
                            UserID = UserId
                        };
                        fc.AddUserFC(fc);
                    }
                }
            }
           


            //Current Job 

            string CJFCheck = Request.Form["chckCJF_form"];

            if (!string.IsNullOrEmpty(CJFCheck))
            {
                string[] arrcjf = CJFCheck.Split(',');
                if (arrcjf.Length > 0)
                {
                    foreach (string i in arrcjf)
                    {
                        Model_UserCJF cjf = new Model_UserCJF
                        {
                            CJFID = int.Parse(i),
                            UserID = UserId
                        };
                        cjf.AddUserCjf(cjf);
                    }
                }
            }


            //Score Process
            string ass =  Request.Form["ass_fill_"];

            if (!string.IsNullOrEmpty(Request.Form["ass_fill_"]))
            {
                string[] arrAss = ass.Split(',');
                if(arrAss.Length > 0)
                {
                    foreach (string assItem in arrAss)
                    {
                        string assSCore = Request.Form["ass_fill_item_score_" + assItem];
                        if (!string.IsNullOrEmpty(assSCore))
                        {
                            int AssID = int.Parse(assItem);
                            int AssScore = int.Parse(assSCore);
                            //insert ass Score here
                        }

                        string asssChoice = Request.Form["ass_fill_choice_" + assItem];

                        if (!string.IsNullOrEmpty(asssChoice))
                        {
                            string[] arrChoice = asssChoice.Split(',');

                            if (arrChoice.Length > 0)
                            {
                                foreach (string choiceItem in arrChoice)
                                {
                                    string assChoiceScore = Request.Form["ass_fill_choice_score_" + assItem + "_" + choiceItem];

                                    if (!string.IsNullOrEmpty(assChoiceScore))
                                    {
                                        //insert choice here
                                    }
                                }
                            }


                        }


                    }
                }
                
            }


            //string assSCore = Request.Form["ass_fill_item_score_"];
            //string asssChoice = Request.Form["ass_fill_choice_"];

            

            Response.Write("True");
            Response.End();
        }
    }
}