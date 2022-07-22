using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CaricaGriglia();

    }
    protected void btnAggiorna_Click(object sender, EventArgs e)
    {
        CaricaGriglia();
    }

    protected void griglia_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["codiceAuto"] = griglia.SelectedDataKey[0];
        btnModifica.Enabled = true;
    }

    protected void CaricaGriglia()
    {
        AUTO A = new AUTO();

        griglia.DataSource = A.Select();
        griglia.DataBind();
    }
}