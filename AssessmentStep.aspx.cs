using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _AssessmentStep : BasePageFront
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Model_Users u = this.UserActive;
        if(u != null)
        {
            Model_AssesIntro intro = new Model_AssesIntro();
            intro = intro.GetIntro();


        }

     


        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("sss");
        Response.End();
    }
}