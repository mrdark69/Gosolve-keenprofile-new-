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
            bool IsCom = false;
            if (!string.IsNullOrEmpty(Request.Form["ctl00$MainContent$heUserID"]))
            {
                //try
                //{
                    int UserId = int.Parse(Request.Form["ctl00$MainContent$heUserID"]);

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
                        DateofBirth = DatBirth.DateSplitYear('-'),
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
                        if (arrfc.Length > 0)
                        {
                            List<Model_UserFC> list = new List<Model_UserFC>();

                            foreach (string i in arrfc)
                            {

                                list.Add(new Model_UserFC
                                {
                                    FCID = int.Parse(i),
                                    UserID = UserId
                                });


                            }
                            Model_UserFC fc = new Model_UserFC();

                            fc.AddUserFC(list, UserId);
                        }
                    }



                    //Current Job 

                    string CJFCheck = Request.Form["chckCJF_form"];

                    if (!string.IsNullOrEmpty(CJFCheck))
                    {
                        string[] arrcjf = CJFCheck.Split(',');
                        if (arrcjf.Length > 0)
                        {
                            List<Model_UserCJF> list = new List<Model_UserCJF>();
                            foreach (string i in arrcjf)
                            {
                                list.Add(new Model_UserCJF
                                {
                                    CJFID = int.Parse(i),
                                    UserID = UserId
                                });


                            }
                            Model_UserCJF cjf = new Model_UserCJF();
                            cjf.AddUserCjf(list, UserId);
                        }
                    }


                    //UserAssessment Transaction
                    Model_UsersTransaction ts = new Model_UsersTransaction
                    {
                        UserID = UserId

                    };

                    int tsid = ts.InsertUserTsAss(ts);

                    if (tsid > 0)
                    {
                        //Score Process
                        string ass = Request.Form["ass_fill_"];

                        if (!string.IsNullOrEmpty(Request.Form["ass_fill_"]))
                        {
                            string[] arrAss = ass.Split(',');
                            if (arrAss.Length > 0)
                            {
                                //List<Model_UsersAssessment> uslist = new List<Model_UsersAssessment>();
                                foreach (string assItem in arrAss)
                                {
                                    string assSCore = Request.Form["ass_fill_i_sc_" + assItem];
                                    //if (!string.IsNullOrEmpty(assSCore))
                                    // {
                                    int AssID = int.Parse(assItem);
                                     

                                    int AssScore = 0;
                                    if (!string.IsNullOrEmpty(assSCore))
                                        AssScore = int.Parse(assSCore);

                                    Model_UsersAssessment uass = new Model_UsersAssessment
                                    {
                                        ASID = AssID,
                                        TransactionID = tsid,
                                        Score = AssScore
                                    };

                                    int intTASID = uass.InsertUserAssessment(uass);



                                    string asssChoice = Request.Form["ass_fill_ch_" + assItem];

                                    if (!string.IsNullOrEmpty(asssChoice))
                                    {
                                        string[] arrChoice = asssChoice.Split(',');

                                        if (arrChoice.Length > 0)
                                        {

                                            foreach (string choiceItem in arrChoice)
                                            {
                                                string assChoiceScore = Request.Form["ass_fill_ch_sc_" + assItem + "_" + choiceItem];

                                                if (!string.IsNullOrEmpty(assChoiceScore))
                                                {
                                                    int AssChoiceID = int.Parse(choiceItem);
                                                    int AssChoiceScore = int.Parse(assChoiceScore);

                                                    Model_UsersAssChoice usch = new Model_UsersAssChoice
                                                    {
                                                        ASID = AssID,
                                                        ASCID = AssChoiceID,
                                                        TASID = intTASID,
                                                        Score = AssChoiceScore


                                                    };
                                                    usch.InsertUserAssessmentChoice(usch);
                                                    //insert choice here
                                                }
                                            }
                                        }


                                    }


                                    //   }

                                }
                            }

                        }

                    }

                    // assessment is recorded!
                    IsCom = true;


                    if (IsCom)
                        IsCom = CalculationController.CalculateActionStart(tsid);
                //}
                //catch(Exception ex)
                //{
                //    string ee = ex.Message + ex.StackTrace;
                //    IsCom = false;
                //}


               

            }
            

           

            Response.Write(IsCom.ToString());
            Response.End();
        }
    }
}