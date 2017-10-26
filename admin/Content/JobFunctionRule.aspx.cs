using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _JobFunctionRule : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.Page.IsPostBack)
        {
            Model_JFR1 r1 = new Model_JFR1();
         
            List<Model_JFR1> rule1 = r1.GetAll();


            Model_JFR1 r1row1 = rule1.Where(o => o.RuleID == 1).FirstOrDefault();

            txtRuleTitle1.Text = r1row1.Title;
            txtRuleScore1.Text = r1row1.Score.ToString();
            txtr1_1.Text = r1row1.CJRRuleScore1.ToString();
            txtr1_2.Text = r1row1.CJRRuleScore2.ToString();
            txtr1_3.Text = r1row1.CJRRuleScore3.ToString();
            txtr1_4.Text = r1row1.CJRRuleScore4.ToString();
            txtr1_5.Text = r1row1.CJRRuleScore5.ToString();

            Model_JFR1 r1row2 = rule1.Where(o => o.RuleID == 2).FirstOrDefault();

            txtRuleTitle2.Text = r1row2.Title;
            txtRuleScore2.Text = r1row2.Score.ToString();
            txtr2_1.Text = r1row2.CJRRuleScore1.ToString();
            txtr2_2.Text = r1row2.CJRRuleScore2.ToString();
            txtr2_3.Text = r1row2.CJRRuleScore3.ToString();
            txtr2_4.Text = r1row2.CJRRuleScore4.ToString();
            txtr2_5.Text = r1row2.CJRRuleScore5.ToString();

            Model_JFR1 r1row3 = rule1.Where(o => o.RuleID == 3).FirstOrDefault();

            txtRuleTitle3.Text = r1row3.Title;
            txtRuleScore3.Text = r1row3.Score.ToString();
            txtr3_1.Text = r1row3.CJRRuleScore1.ToString();
            txtr3_2.Text = r1row3.CJRRuleScore2.ToString();
            txtr3_3.Text = r1row3.CJRRuleScore3.ToString();
            txtr3_4.Text = r1row3.CJRRuleScore4.ToString();
            txtr3_5.Text = r1row3.CJRRuleScore5.ToString();

            Model_JFR1 r1row4 = rule1.Where(o => o.RuleID == 4).FirstOrDefault();

            txtRuleTitle4.Text = r1row4.Title;
            txtRuleScore4.Text = r1row4.Score.ToString();
            txtr4_1.Text = r1row4.CJRRuleScore1.ToString();
            txtr4_2.Text = r1row4.CJRRuleScore2.ToString();
            txtr4_3.Text = r1row4.CJRRuleScore3.ToString();
            txtr4_4.Text = r1row4.CJRRuleScore4.ToString();
            txtr4_5.Text = r1row4.CJRRuleScore5.ToString();

            Model_JFR1 r1row5 = rule1.Where(o => o.RuleID == 5).FirstOrDefault();

            txtRuleTitle5.Text = r1row5.Title;
            txtRuleScore5.Text = r1row5.Score.ToString();
            txtr5_1.Text = r1row5.CJRRuleScore1.ToString();
            txtr5_2.Text = r1row5.CJRRuleScore2.ToString();
            txtr5_3.Text = r1row5.CJRRuleScore3.ToString();
            txtr5_4.Text = r1row5.CJRRuleScore4.ToString();
            txtr5_5.Text = r1row5.CJRRuleScore5.ToString();


            Model_JFR2 r2 = new Model_JFR2();

            List<Model_JFR2> rule2 = r2.GetAll();


            Model_JFR2 r2row1 = rule2.Where(o => o.RuleID == 1).FirstOrDefault();

            txtRuleTitle21.Text = r2row1.Title;
            txtRuleScore21.Text = r2row1.Score.ToString();
            txtr21_1.Text = r2row1.CJRRuleScore1.ToString();
            txtr21_2.Text = r2row1.CJRRuleScore2.ToString();
            txtr21_3.Text = r2row1.CJRRuleScore3.ToString();
            txtr21_4.Text = r2row1.CJRRuleScore4.ToString();
            

            Model_JFR2 r2row2 = rule2.Where(o => o.RuleID == 2).FirstOrDefault();

            txtRuleTitle22.Text = r2row2.Title;
            txtRuleScore22.Text = r2row2.Score.ToString();
            txtr22_1.Text = r2row2.CJRRuleScore1.ToString();
            txtr22_2.Text = r2row2.CJRRuleScore2.ToString();
            txtr22_3.Text = r2row2.CJRRuleScore3.ToString();
            txtr22_4.Text = r2row2.CJRRuleScore4.ToString();
          

            Model_JFR2 r2row3 = rule2.Where(o => o.RuleID == 3).FirstOrDefault();

            txtRuleTitle23.Text = r2row3.Title;
            txtRuleScore23.Text = r2row3.Score.ToString();
            txtr23_1.Text = r2row3.CJRRuleScore1.ToString();
            txtr23_2.Text = r2row3.CJRRuleScore2.ToString();
            txtr23_3.Text = r2row3.CJRRuleScore3.ToString();
            txtr23_4.Text = r2row3.CJRRuleScore4.ToString();
            

            Model_JFR2 r2row4 = rule2.Where(o => o.RuleID == 4).FirstOrDefault();

            txtRuleTitle24.Text = r2row4.Title;
            txtRuleScore24.Text = r2row4.Score.ToString();
            txtr24_1.Text = r2row4.CJRRuleScore1.ToString();
            txtr24_2.Text = r2row4.CJRRuleScore2.ToString();
            txtr24_3.Text = r2row4.CJRRuleScore3.ToString();
            txtr24_4.Text = r2row4.CJRRuleScore4.ToString();
           

    



            Model_Rule3 r3 = new Model_Rule3();
            List<Model_Rule3> rule3 = r3.GetAll();

            Model_Rule3 r3row1 = rule3.Where(o => o.RuleID == 1).FirstOrDefault();
            exp_from_1.Text = r3row1.Range_Start.ToString();
            exp_to_1.Text = r3row1.Range_End.ToString();
            exp_des_1.Text = r3row1.Description.ToString();

            Model_Rule3 r3row2 = rule3.Where(o => o.RuleID == 2).FirstOrDefault();
            exp_from_2.Text = r3row2.Range_Start.ToString();
            exp_to_2.Text = r3row2.Range_End.ToString();
            exp_des_2.Text = r3row2.Description.ToString();

            Model_Rule3 r3row3 = rule3.Where(o => o.RuleID == 4).FirstOrDefault();
            exp_from_3.Text = r3row3.Range_Start.ToString();
            exp_to_3.Text = r3row3.Range_End.ToString();
            exp_des_3.Text = r3row3.Description.ToString();

            Model_Rule3 r3row4 = rule3.Where(o => o.RuleID == 5).FirstOrDefault();
            exp_from_4.Text = r3row4.Range_Start.ToString();
            exp_to_4.Text = r3row4.Range_End.ToString();
            exp_des_4.Text = r3row4.Description.ToString();

            Model_Rule3 r3row5 = rule3.Where(o => o.RuleID == 6).FirstOrDefault();
            exp_from_5.Text = r3row5.Range_Start.ToString();
            exp_to_5.Text = r3row5.Range_End.ToString();
            exp_des_5.Text = r3row5.Description.ToString();

            Model_Rule3 r3row6 = rule3.Where(o => o.RuleID == 11).FirstOrDefault();
            exp_from_6.Text = r3row6.Range_Start.ToString();
            exp_to_6.Text = r3row6.Range_End.ToString();
            exp_des_6.Text = r3row6.Description.ToString();

            Model_Rule3 r3row7 = rule3.Where(o => o.RuleID == 14).FirstOrDefault();
            exp_from_7.Text = r3row7.Range_Start.ToString();
            exp_to_7.Text = r3row7.Range_End.ToString();
            exp_des_7.Text = r3row7.Description.ToString();






            Model_Rule4 r4 = new Model_Rule4();
            List<Model_Rule4> rule4 = r4.GetAll();

            Model_Rule4 r4row1 = rule4.Where(o => o.RuleID == 1).FirstOrDefault();

            result_from_1.Text = r4row1.Range_Start.ToString();
            result_to_1.Text = r4row1.Range_End.ToString();
            result_top7_1.Text = r4row1.ValueTop.ToString();
            result_other_1.Text = r4row1.ValueOther.ToString();
            result_bottom4_1.Text = r4row1.ValueBottom.ToString();

            Model_Rule4 r4row2 = rule4.Where(o => o.RuleID == 2).FirstOrDefault();

            result_from_2.Text = r4row2.Range_Start.ToString();
            result_to_2.Text = r4row2.Range_End.ToString();
            result_top7_2.Text = r4row2.ValueTop.ToString();
            result_other_2.Text = r4row2.ValueOther.ToString();
            result_bottom4_2.Text = r4row2.ValueBottom.ToString();

            Model_Rule4 r4row3 = rule4.Where(o => o.RuleID == 4).FirstOrDefault();

            result_from_3.Text = r4row3.Range_Start.ToString();
            result_to_3.Text = r4row3.Range_End.ToString();
            result_top7_3.Text = r4row3.ValueTop.ToString();
            result_other_3.Text = r4row3.ValueOther.ToString();
            result_bottom4_3.Text = r4row3.ValueBottom.ToString();

            Model_Rule4 r4row4 = rule4.Where(o => o.RuleID == 5).FirstOrDefault();

            result_from_4.Text = r4row4.Range_Start.ToString();
            result_to_4.Text = r4row4.Range_End.ToString();
            result_top7_4.Text = r4row4.ValueTop.ToString();
            result_other_4.Text = r4row4.ValueOther.ToString();
            result_bottom4_4.Text = r4row4.ValueBottom.ToString();


        }

        if (!string.IsNullOrEmpty(Request.QueryString["tab"]))
        {
            string tab = Request.QueryString["tab"];

            switch (tab)
            {
                case "2":
                    tab1.Attributes.Add("aria-expanded", "false");
                    tab2.Attributes.Add("aria-expanded", "true");
                    tab3.Attributes.Add("aria-expanded", "false");
                    tab4.Attributes.Add("aria-expanded", "false");

                    li_tab1.Attributes.Remove("class");
                    li_tab2.Attributes.Add("class", "active");
                    li_tab3.Attributes.Remove("class");
                    li_tab4.Attributes.Remove("class");

                    tab_content1.Visible = false;
                    tab_content2.Visible = true;
                    tab_content3.Visible = false;
                    tab_content4.Visible = false;

                    break;
                case "3":
                    tab1.Attributes.Add("aria-expanded", "false");
                    tab2.Attributes.Add("aria-expanded", "false");
                    tab3.Attributes.Add("aria-expanded", "true");
                    tab4.Attributes.Add("aria-expanded", "false");

                    li_tab1.Attributes.Remove("class");
                    li_tab3.Attributes.Add("class", "active");
                    li_tab2.Attributes.Remove("class");
                    li_tab4.Attributes.Remove("class");

                    tab_content1.Visible = false;
                    tab_content2.Visible = false;
                    tab_content3.Visible = true;
                    tab_content4.Visible = false;

                    break;
                case "4":
                    tab1.Attributes.Add("aria-expanded", "false");
                    tab2.Attributes.Add("aria-expanded", "false");
                    tab3.Attributes.Add("aria-expanded", "false");
                    tab4.Attributes.Add("aria-expanded", "true");

                    li_tab1.Attributes.Remove("class");
                    li_tab4.Attributes.Add("class", "active");
                    li_tab3.Attributes.Remove("class");
                    li_tab2.Attributes.Remove("class");

                    tab_content1.Visible = false;
                    tab_content2.Visible = false;
                    tab_content3.Visible = false;
                    tab_content4.Visible = true;

                    break;


            }
        }
        else
        {

            tab_content1.Visible = true;
            tab_content2.Visible = false;
            tab_content3.Visible = false;
            tab_content4.Visible = false;

            tab1.Attributes.Add("aria-expanded", "true");
            tab2.Attributes.Add("aria-expanded", "false");
            tab3.Attributes.Add("aria-expanded", "false");
            tab4.Attributes.Add("aria-expanded", "false");

            li_tab1.Attributes.Add("class", "active");
            li_tab2.Attributes.Remove("class");

            li_tab3.Attributes.Remove("class");
            li_tab4.Attributes.Remove("class");



        }
    }











    protected void Unnamed_Click(object sender, EventArgs e)
    {
        Model_JFR1 r1 = new Model_JFR1();

        List<Model_JFR1> rule1 = new List<Model_JFR1>();

        rule1.Add(new Model_JFR1
        {
            RuleID = 1,
            Title = txtRuleTitle1.Text,
            Score = int.Parse(txtRuleScore1.Text),
            CJRRuleScore1 = decimal.Parse(txtr1_1.Text),
            CJRRuleScore2 = decimal.Parse(txtr1_2.Text),
            CJRRuleScore3 = decimal.Parse(txtr1_3.Text),
            CJRRuleScore4 = decimal.Parse(txtr1_4.Text),
            CJRRuleScore5 = decimal.Parse(txtr1_5.Text),

        });
        rule1.Add(new Model_JFR1
        {
            RuleID = 2,
            Title = txtRuleTitle2.Text,
            Score = int.Parse(txtRuleScore2.Text),
            CJRRuleScore1 = decimal.Parse(txtr2_1.Text),
            CJRRuleScore2 = decimal.Parse(txtr2_2.Text),
            CJRRuleScore3 = decimal.Parse(txtr2_3.Text),
            CJRRuleScore4 = decimal.Parse(txtr2_4.Text),
            CJRRuleScore5 = decimal.Parse(txtr2_5.Text),

        });
        rule1.Add(new Model_JFR1
        {
            RuleID = 3,
            Title = txtRuleTitle3.Text,
            Score = int.Parse(txtRuleScore3.Text),
            CJRRuleScore1 = decimal.Parse(txtr3_1.Text),
            CJRRuleScore2 = decimal.Parse(txtr3_2.Text),
            CJRRuleScore3 = decimal.Parse(txtr3_3.Text),
            CJRRuleScore4 = decimal.Parse(txtr3_4.Text),
            CJRRuleScore5 = decimal.Parse(txtr3_5.Text),

        });
        rule1.Add(new Model_JFR1
        {
            RuleID = 4,
            Title = txtRuleTitle4.Text,
            Score = int.Parse(txtRuleScore4.Text),
            CJRRuleScore1 = decimal.Parse(txtr4_1.Text),
            CJRRuleScore2 = decimal.Parse(txtr4_2.Text),
            CJRRuleScore3 = decimal.Parse(txtr4_3.Text),
            CJRRuleScore4 = decimal.Parse(txtr4_4.Text),
            CJRRuleScore5 = decimal.Parse(txtr4_5.Text),

        });
        rule1.Add(new Model_JFR1
        {
            RuleID = 5,
            Title = txtRuleTitle5.Text,
            Score = int.Parse(txtRuleScore5.Text),
            CJRRuleScore1 = decimal.Parse(txtr5_1.Text),
            CJRRuleScore2 = decimal.Parse(txtr5_2.Text),
            CJRRuleScore3 = decimal.Parse(txtr5_3.Text),
            CJRRuleScore4 = decimal.Parse(txtr5_4.Text),
            CJRRuleScore5 = decimal.Parse(txtr5_5.Text),

        });


        r1.UpdateBulk(rule1);


        Model_JFR2 r2 = new Model_JFR2();

        List<Model_JFR2> rule21 = new List<Model_JFR2>();

        rule21.Add(new Model_JFR2
        {
            RuleID = 1,
            Title = txtRuleTitle21.Text,
            Score = int.Parse(txtRuleScore21.Text),
            CJRRuleScore1 = decimal.Parse(txtr21_1.Text),
            CJRRuleScore2 = decimal.Parse(txtr21_2.Text),
            CJRRuleScore3 = decimal.Parse(txtr21_3.Text),
            CJRRuleScore4 = decimal.Parse(txtr21_4.Text),
           

        });
        rule21.Add(new Model_JFR2
        {
            RuleID = 2,
            Title = txtRuleTitle22.Text,
            Score = int.Parse(txtRuleScore22.Text),
            CJRRuleScore1 = decimal.Parse(txtr22_1.Text),
            CJRRuleScore2 = decimal.Parse(txtr22_2.Text),
            CJRRuleScore3 = decimal.Parse(txtr22_3.Text),
            CJRRuleScore4 = decimal.Parse(txtr22_4.Text),
           

        });
        rule21.Add(new Model_JFR2
        {
            RuleID = 3,
            Title = txtRuleTitle23.Text,
            Score = int.Parse(txtRuleScore23.Text),
            CJRRuleScore1 = decimal.Parse(txtr23_1.Text),
            CJRRuleScore2 = decimal.Parse(txtr23_2.Text),
            CJRRuleScore3 = decimal.Parse(txtr23_3.Text),
            CJRRuleScore4 = decimal.Parse(txtr23_4.Text),
           

        });
        rule21.Add(new Model_JFR2
        {
            RuleID = 4,
            Title = txtRuleTitle24.Text,
            Score = int.Parse(txtRuleScore24.Text),
            CJRRuleScore1 = decimal.Parse(txtr24_1.Text),
            CJRRuleScore2 = decimal.Parse(txtr24_2.Text),
            CJRRuleScore3 = decimal.Parse(txtr24_3.Text),
            CJRRuleScore4 = decimal.Parse(txtr24_4.Text),
          

        });
     
        
        r2.UpdateBulk(rule21);





        Model_Rule3 r3 = new Model_Rule3();
        List<Model_Rule3> rule3 = new List<Model_Rule3>();

        rule3.Add(new Model_Rule3 {
            RuleID = 1,
            Range_Start = int.Parse(exp_from_1.Text),
            Range_End = int.Parse(exp_to_1.Text),
            Description = exp_des_1.Text

        });
        rule3.Add(new Model_Rule3
        {
            RuleID = 2,
            Range_Start = int.Parse(exp_from_2.Text),
            Range_End = int.Parse(exp_to_2.Text),
            Description = exp_des_2.Text

        });
        rule3.Add(new Model_Rule3
        {
            RuleID = 4,
            Range_Start = int.Parse(exp_from_3.Text),
            Range_End = int.Parse(exp_to_3.Text),
            Description = exp_des_3.Text

        });
        rule3.Add(new Model_Rule3
        {
            RuleID = 5,
            Range_Start = int.Parse(exp_from_4.Text),
            Range_End = int.Parse(exp_to_4.Text),
            Description = exp_des_4.Text

        });
        rule3.Add(new Model_Rule3
        {
            RuleID = 6,
            Range_Start = int.Parse(exp_from_5.Text),
            Range_End = int.Parse(exp_to_5.Text),
            Description = exp_des_5.Text

        });
        rule3.Add(new Model_Rule3
        {
            RuleID = 11,
            Range_Start = int.Parse(exp_from_6.Text),
            Range_End = int.Parse(exp_to_6.Text),
            Description = exp_des_6.Text

        });
        rule3.Add(new Model_Rule3
        {
            RuleID = 14,
            Range_Start = int.Parse(exp_from_7.Text),
            Range_End = int.Parse(exp_to_7.Text),
            Description = exp_des_7.Text

        });


        r3.UpdateBulk(rule3);


        Model_Rule4 r4 = new Model_Rule4();
        List<Model_Rule4> rule4 = new List<Model_Rule4>();

        rule4.Add(new Model_Rule4 {
            RuleID = 1,
            Range_Start = int.Parse(result_from_1.Text),
            Range_End = int.Parse(result_to_1.Text),
            ValueTop = result_top7_1.Text,
            ValueOther = result_other_1.Text,
            ValueBottom= result_bottom4_1.Text

        });
        rule4.Add(new Model_Rule4
        {
            RuleID = 2,
            Range_Start = int.Parse(result_from_2.Text),
            Range_End = int.Parse(result_to_2.Text),
            ValueTop = result_top7_2.Text,
            ValueOther = result_other_2.Text,
            ValueBottom = result_bottom4_2.Text

        });
        rule4.Add(new Model_Rule4
        {
            RuleID = 4,
            Range_Start = int.Parse(result_from_3.Text),
            Range_End = int.Parse(result_to_3.Text),
            ValueTop = result_top7_3.Text,
            ValueOther = result_other_3.Text,
            ValueBottom = result_bottom4_3.Text

        });
        rule4.Add(new Model_Rule4
        {
            RuleID = 5,
            Range_Start = int.Parse(result_from_4.Text),
            Range_End = int.Parse(result_to_4.Text),
            ValueTop = result_top7_4.Text,
            ValueOther = result_other_4.Text,
            ValueBottom = result_bottom4_4.Text

        });

        r4.UpdateBulk(rule4);


        Response.Redirect(Request.Url.ToString());
    }
}