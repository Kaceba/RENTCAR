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
        if (!IsPostBack)
        {
            ddlAnno.Items.Add(new ListItem("2020", "2020"));
            ddlAnno.Items.Add(new ListItem("2021", "2021"));
            ddlAnno.Items.Add(new ListItem("2022", "2022"));
        }

        ddlAnno.SelectedValue = "2022";

        CaricaGriglia();
    }

    protected void btnVisualizza_Click(object sender, EventArgs e)
    {
        CaricaGriglia();
    }

    protected void CaricaGriglia()
    {
        CONTRATTI.CONTABILITA CC = new CONTRATTI.CONTABILITA();
        int anno = int.Parse(ddlAnno.SelectedValue);

        griglia.DataSource = CC.FatturatoPerMensile(anno);
        griglia.DataBind();
    }
}