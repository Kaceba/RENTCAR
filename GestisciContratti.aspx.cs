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
    protected void griglia_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["codiceContratto"] = griglia.SelectedDataKey[0];
        btnModifica.Enabled = true;
        btnElimina.Enabled = true;
    }
    protected void CaricaGriglia()
    {
        CONTRATTI C = new CONTRATTI();
        griglia.DataSource = C.Select();
        griglia.DataBind();
    }

    protected void btnAggiorna_Click(object sender, EventArgs e)
    {
        CaricaGriglia();
    }
}