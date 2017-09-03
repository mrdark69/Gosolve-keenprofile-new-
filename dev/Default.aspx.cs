using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public class gg
{
    public string key { get; set; }
    public int[] arr { get; set; }
    public string MyProperty { get; set; }
}

public partial class dev_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<gg> obj = new List<gg>();
        obj.Add(new gg
        {
            key = "Creative Thinking",
            arr = new int[] { 1, 2, 3, 4 },
            MyProperty = "sssrrraaaaas"
        });
        obj.Add(new gg
        {
            key = "Strategic Thinking",
            arr = new int[] { 1, 2, 3, 4 }
        });
        obj.Add(new gg
        {
            key = "Analytical Thinking",
            arr = new int[] { 1, 2, 3, 4 }
        });
        obj.Add(new gg
        {
            key = "Numerical Thinking",
            arr = new int[] { 1, 2, 3, 4 }
        });

        gg.DataSource = obj;
        gg.DataBind();
    }

    protected void btn_Click(object sender, EventArgs e)
    {

    }
}