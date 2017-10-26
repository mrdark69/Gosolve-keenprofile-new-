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



            Model_JFR3 r3 = new Model_JFR3();
            List<Model_JFR3> rule3 = r3.GetAll();

            List<Model_JFR3> rule3G1 = rule3.Where(o => o.Cat == 1).ToList();
            List<Model_JFR3> rule3G2 = rule3.Where(o => o.Cat == 2).ToList();

            Model_JFR3 r3row1 = rule3G1.Where(o => o.RuleID == 1).FirstOrDefault();
            Model_JFR3 r3row2 = rule3G1.Where(o => o.RuleID == 2).FirstOrDefault();
            Model_JFR3 r3row3 = rule3G1.Where(o => o.RuleID == 3).FirstOrDefault();

            TextBox3_1.Text = r3row1.Condition1;
            TextBox3_2.Text = r3row1.Condition2;
            TextBox3_3.Text = r3row1.Score.ToString();

            TextBox3_11.Text = r3row2.Condition1;
            TextBox3_12.Text = r3row2.Condition2;
            TextBox3_13.Text = r3row2.Score.ToString();

            TextBox3_111.Text = r3row3.Condition1;
            TextBox3_112.Text = r3row3.Condition2;
            TextBox3_113.Text = r3row3.Score.ToString();

            Model_JFR3 r4row1 = rule3G2.Where(o => o.RuleID == 5).FirstOrDefault();
            Model_JFR3 r4row2 = rule3G2.Where(o => o.RuleID == 6).FirstOrDefault();
            Model_JFR3 r4row3 = rule3G2.Where(o => o.RuleID == 7).FirstOrDefault();


            TextBox4_1.Text = r4row1.Condition1;
            TextBox4_2.Text = r4row1.Condition2;
            TextBox4_3.Text = r4row1.Score.ToString();

            TextBox4_11.Text = r4row2.Condition1;
            TextBox4_12.Text = r4row2.Condition2;
            TextBox4_13.Text = r4row2.Score.ToString();

            TextBox4_111.Text = r4row3.Condition1;
            TextBox4_112.Text = r4row3.Condition2;
            TextBox4_113.Text = r4row3.Score.ToString();


            Model_JFR4 r4 = new Model_JFR4();
            List<Model_JFR4> rule4 = r4.GetAll();

            List<Model_JFR4> rule4G1 = rule4.Where(o => o.Cat == 1).ToList();
            List<Model_JFR4> rule4G2 = rule4.Where(o => o.Cat == 2).ToList();
            List<Model_JFR4> rule4G3 = rule4.Where(o => o.Cat == 3).ToList();
            List<Model_JFR4> rule4G4 = rule4.Where(o => o.Cat == 4).ToList();

            Model_JFR4 r5row1 = rule4G1.Where(o => o.RuleID == 1).FirstOrDefault();
            Model_JFR4 r5row2 = rule4G1.Where(o => o.RuleID == 2).FirstOrDefault();

          

            TextBox5_1.Text = r5row1.Condition1;
            TextBox5_2.Text = r5row1.Score.ToString();

            TextBox5_11.Text = r5row2.Condition1;
            TextBox5_12.Text = r5row2.Score.ToString();

            Model_JFR4 r6row1 = rule4G2.Where(o => o.RuleID == 4).FirstOrDefault();
            Model_JFR4 r6row2 = rule4G2.Where(o => o.RuleID == 5).FirstOrDefault();
            Model_JFR4 r6row3 = rule4G2.Where(o => o.RuleID == 6).FirstOrDefault();



            TextBox6_1.Text = r6row1.Condition1;
            TextBox6_2.Text = r6row1.Score.ToString();

            TextBox6_11.Text = r6row2.Condition1;
            TextBox6_12.Text = r6row2.Score.ToString();

            TextBox6_111.Text = r6row3.Condition1;
            TextBox6_112.Text = r6row3.Score.ToString();



            Model_JFR4 r7row1 = rule4G3.Where(o => o.RuleID == 7).FirstOrDefault();
            Model_JFR4 r7row2 = rule4G3.Where(o => o.RuleID == 8).FirstOrDefault();
            Model_JFR4 r7row3 = rule4G3.Where(o => o.RuleID == 9).FirstOrDefault();

            TextBox7_1.Text = r7row1.Condition1;
            TextBox7_2.Text = r7row1.Score.ToString();

            TextBox7_11.Text = r7row2.Condition1;
            TextBox7_12.Text = r7row2.Score.ToString();

            TextBox7_111.Text = r7row3.Condition1;
            TextBox7_112.Text = r7row3.Score.ToString();


            Model_JFR4 r8row1 = rule4G4.Where(o => o.RuleID == 10).FirstOrDefault();
            Model_JFR4 r8row2 = rule4G4.Where(o => o.RuleID == 11).FirstOrDefault();
            Model_JFR4 r8row3 = rule4G4.Where(o => o.RuleID == 12).FirstOrDefault();

            TextBox8_1.Text = r8row1.Condition1;
            TextBox8_2.Text = r8row1.Score.ToString();

            TextBox8_11.Text = r8row2.Condition1;
            TextBox8_12.Text = r8row2.Score.ToString();

            TextBox8_111.Text = r8row3.Condition1;
            TextBox8_112.Text = r8row3.Score.ToString();

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




        Model_JFR3 r3 = new Model_JFR3();
        List<Model_JFR3> rule3 = new List<Model_JFR3>();

        rule3.Add(new Model_JFR3 {
             RuleID =1,
             Condition1 = TextBox3_1.Text,
             Condition2 = TextBox3_2.Text,
             Score = int.Parse(TextBox3_3.Text)
        });

        rule3.Add(new Model_JFR3
        {
            RuleID = 2,
            Condition1 = TextBox3_11.Text,
            Condition2 = TextBox3_12.Text,
            Score = int.Parse(TextBox3_13.Text)
        });

        rule3.Add(new Model_JFR3
        {
            RuleID = 3,
            Condition1 = TextBox3_111.Text,
            Condition2 = TextBox3_112.Text,
            Score = int.Parse(TextBox3_113.Text)
        });



        rule3.Add(new Model_JFR3
        {
            RuleID = 5,
            Condition1 = TextBox4_1.Text,
            Condition2 = TextBox4_2.Text,
            Score = int.Parse(TextBox4_3.Text)
        });

        rule3.Add(new Model_JFR3
        {
            RuleID = 6,
            Condition1 = TextBox4_11.Text,
            Condition2 = TextBox4_12.Text,
            Score = int.Parse(TextBox4_13.Text)
        });

        rule3.Add(new Model_JFR3
        {
            RuleID = 7,
            Condition1 = TextBox4_111.Text,
            Condition2 = TextBox4_112.Text,
            Score = int.Parse(TextBox4_113.Text)
        });


        r3.UpdateBulk(rule3);



        Model_JFR4 r4 = new Model_JFR4();
        List<Model_JFR4> rule4 = new List<Model_JFR4>();

        rule4.Add(new Model_JFR4
        {
            RuleID = 1,
            Condition1 = TextBox5_1.Text,
            Score = int.Parse(TextBox5_2.Text)
        });
        rule4.Add(new Model_JFR4
        {
            RuleID = 2,
            Condition1 = TextBox5_11.Text,
            Score = int.Parse(TextBox5_12.Text)
        });
        rule4.Add(new Model_JFR4
        {
            RuleID = 4,
            Condition1 = TextBox6_1.Text,
            Score = int.Parse(TextBox6_2.Text)
        });
        rule4.Add(new Model_JFR4
        {
            RuleID = 5,
            Condition1 = TextBox6_11.Text,
            Score = int.Parse(TextBox6_12.Text)
        });
        rule4.Add(new Model_JFR4
        {
            RuleID = 6,
            Condition1 = TextBox6_111.Text,
            Score = int.Parse(TextBox6_112.Text)
        });


        rule4.Add(new Model_JFR4
        {
            RuleID = 7,
            Condition1 = TextBox7_1.Text,
            Score = int.Parse(TextBox7_2.Text)
        });
        rule4.Add(new Model_JFR4
        {
            RuleID = 8,
            Condition1 = TextBox7_11.Text,
            Score = int.Parse(TextBox7_12.Text)
        });
        rule4.Add(new Model_JFR4
        {
            RuleID = 9,
            Condition1 = TextBox7_111.Text,
            Score = int.Parse(TextBox7_112.Text)
        });


        rule4.Add(new Model_JFR4
        {
            RuleID = 10,
            Condition1 = TextBox8_1.Text,
            Score = int.Parse(TextBox8_2.Text)
        });
        rule4.Add(new Model_JFR4
        {
            RuleID = 11,
            Condition1 = TextBox8_11.Text,
            Score = int.Parse(TextBox8_12.Text)
        });
        rule4.Add(new Model_JFR4
        {
            RuleID = 12,
            Condition1 = TextBox8_111.Text,
            Score = int.Parse(TextBox8_112.Text)
        });

        r4.UpdateBulk(rule4);

        Response.Redirect(Request.Url.ToString());
    }
}