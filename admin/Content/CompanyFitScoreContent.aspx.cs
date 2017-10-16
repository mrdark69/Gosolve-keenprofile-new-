using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _JobFitScoreContent : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.Page.IsPostBack)
        {


            Model_Com_Rule3 r3 = new Model_Com_Rule3();
            List<Model_Com_Rule3> rule3 = r3.GetAll();

            Model_Com_Rule3 r3row1 = rule3.Where(o => o.RuleID == 1).FirstOrDefault();
            exp_from_1.Text = r3row1.Range_Start.ToString();
            exp_to_1.Text = r3row1.Range_End.ToString();
            exp_des_1.Text = r3row1.Description.ToString();

            Model_Com_Rule3 r3row2 = rule3.Where(o => o.RuleID == 2).FirstOrDefault();
            exp_from_2.Text = r3row2.Range_Start.ToString();
            exp_to_2.Text = r3row2.Range_End.ToString();
            exp_des_2.Text = r3row2.Description.ToString();

            Model_Com_Rule3 r3row3 = rule3.Where(o => o.RuleID == 3).FirstOrDefault();
            exp_from_3.Text = r3row3.Range_Start.ToString();
            exp_to_3.Text = r3row3.Range_End.ToString();
            exp_des_3.Text = r3row3.Description.ToString();

            Model_Com_Rule3 r3row4 = rule3.Where(o => o.RuleID == 4).FirstOrDefault();
            exp_from_4.Text = r3row4.Range_Start.ToString();
            exp_to_4.Text = r3row4.Range_End.ToString();
            exp_des_4.Text = r3row4.Description.ToString();

            Model_Com_Rule3 r3row5 = rule3.Where(o => o.RuleID == 5).FirstOrDefault();
            exp_from_5.Text = r3row5.Range_Start.ToString();
            exp_to_5.Text = r3row5.Range_End.ToString();
            exp_des_5.Text = r3row5.Description.ToString();






            


        }

        if (!string.IsNullOrEmpty(Request.QueryString["tab"]))
        {
            string tab = Request.QueryString["tab"];

            switch (tab)
            {
                case "2":
                    tab1.Attributes.Add("aria-expanded", "false");
                    //tab2.Attributes.Add("aria-expanded", "true");
                    //tab3.Attributes.Add("aria-expanded", "false");
                    //tab4.Attributes.Add("aria-expanded", "false");

                    li_tab1.Attributes.Remove("class");
                    //li_tab2.Attributes.Add("class", "active");
                    //li_tab3.Attributes.Remove("class");
                    //li_tab4.Attributes.Remove("class");

                    tab_content1.Visible = false;
                    //tab_content2.Visible = true;
                    //tab_content3.Visible = false;
                    //tab_content4.Visible = false;

                    break;
                case "3":
                    tab1.Attributes.Add("aria-expanded", "false");
                    //tab2.Attributes.Add("aria-expanded", "false");
                    //tab3.Attributes.Add("aria-expanded", "true");
                    //tab4.Attributes.Add("aria-expanded", "false");

                    li_tab1.Attributes.Remove("class");
                    //li_tab3.Attributes.Add("class", "active");
                    //li_tab2.Attributes.Remove("class");
                    //li_tab4.Attributes.Remove("class");

                    tab_content1.Visible = false;
                    //tab_content2.Visible = false;
                    //tab_content3.Visible = true;
                    //tab_content4.Visible = false;

                    break;
                case "4":
                    tab1.Attributes.Add("aria-expanded", "false");
                    //tab2.Attributes.Add("aria-expanded", "false");
                    //tab3.Attributes.Add("aria-expanded", "false");
                    //tab4.Attributes.Add("aria-expanded", "true");

                    li_tab1.Attributes.Remove("class");
                    //li_tab4.Attributes.Add("class", "active");
                    //li_tab3.Attributes.Remove("class");
                    //li_tab2.Attributes.Remove("class");

                    tab_content1.Visible = false;
                    //tab_content2.Visible = false;
                    //tab_content3.Visible = false;
                    //tab_content4.Visible = true;

                    break;


            }
        }
        else
        {

            tab_content1.Visible = true;
            //tab_content2.Visible = false;
            //tab_content3.Visible = false;
            //tab_content4.Visible = false;

            tab1.Attributes.Add("aria-expanded", "true");
            //tab2.Attributes.Add("aria-expanded", "false");
            //tab3.Attributes.Add("aria-expanded", "false");
            //tab4.Attributes.Add("aria-expanded", "false");

            li_tab1.Attributes.Add("class", "active");
            //li_tab2.Attributes.Remove("class");

            //li_tab3.Attributes.Remove("class");
            //li_tab4.Attributes.Remove("class");



        }
    }











    protected void Unnamed_Click(object sender, EventArgs e)
    {


        Model_Com_Rule3 r3 = new Model_Com_Rule3();
        List<Model_Com_Rule3> rule3 = new List<Model_Com_Rule3>();

        rule3.Add(new Model_Com_Rule3
        {
            RuleID = 1,
            Range_Start = int.Parse(exp_from_1.Text),
            Range_End = int.Parse(exp_to_1.Text),
            Description = exp_des_1.Text

        });
        rule3.Add(new Model_Com_Rule3
        {
            RuleID = 2,
            Range_Start = int.Parse(exp_from_2.Text),
            Range_End = int.Parse(exp_to_2.Text),
            Description = exp_des_2.Text

        });
        rule3.Add(new Model_Com_Rule3
        {
            RuleID = 3,
            Range_Start = int.Parse(exp_from_3.Text),
            Range_End = int.Parse(exp_to_3.Text),
            Description = exp_des_3.Text

        });
        rule3.Add(new Model_Com_Rule3
        {
            RuleID = 4,
            Range_Start = int.Parse(exp_from_4.Text),
            Range_End = int.Parse(exp_to_4.Text),
            Description = exp_des_4.Text

        });
        rule3.Add(new Model_Com_Rule3
        {
            RuleID = 5,
            Range_Start = int.Parse(exp_from_5.Text),
            Range_End = int.Parse(exp_to_5.Text),
            Description = exp_des_5.Text

        });
       


        r3.UpdateBulk(rule3);




        Response.Redirect(Request.Url.ToString());
    }
}