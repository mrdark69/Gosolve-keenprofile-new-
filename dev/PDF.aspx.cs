using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

public partial class dev_PDF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGenpdf_Click(object sender, EventArgs e)
    {
        string datahtml = txtpdf.Text;
        byte[] html = pdfgen.pdfGenerate(datahtml);

        pdfgen.ToClientSave(html, "sample");
    }
}