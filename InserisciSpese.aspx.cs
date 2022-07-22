using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InserisciSpese : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CaricaDdl();
        }
    }
    public void CaricaDdl()
    {
        SPESE S = new SPESE();

        ddlTipoSpesa.DataSource = S.SelectForDDL();
        ddlTipoSpesa.DataTextField = "descrizione";
        ddlTipoSpesa.DataValueField = "codiceTipoSpesa";

        ddlTipoSpesa.DataBind();
    }

    protected void btnInvia_Click(object sender, EventArgs e)
    {
        // Faccio i controlli formali prima di riservare memoria alle variabili
        if (string.IsNullOrEmpty(txtImporto.Text) || string.IsNullOrEmpty(txtDataSpesa.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        if (decimal.TryParse(txtImporto.Text, out decimal result) == false)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        SPESE.AGGIORNADB SA = new SPESE.AGGIORNADB();
        SA.codiceTipoSpesa = int.Parse(ddlTipoSpesa.SelectedValue);
        SA.importo = decimal.Parse(txtImporto.Text.ToString());
        SA.dataspesa = txtDataSpesa.Text.Trim();

        SA.Insert();

        // Mostro il messaggio di conferma
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SUCCESSO", "alert('Spesa immessa correttamente')", true);

        // Pulisco i campi
        ddlTipoSpesa.SelectedIndex = 0;
        txtImporto.Text = "";
        txtDataSpesa.Text = "";

    }
}