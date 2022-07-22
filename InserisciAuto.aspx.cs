using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InserisciAuto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CaricaDdl();
        }
    }

    protected void btnInserisci_Click(object sender, EventArgs e)
    {
        #region "CONTROLLI FORMALI"

        // Faccio i controlli formali prima di riservare memoria alle variabili
        if (string.IsNullOrEmpty(txtTarga.Text) || string.IsNullOrEmpty(txtData.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE!", "alert('Dati non validi!')", true);
            return;
        }
        // controlli formali per impedire di mettere testo nella txtbox importo
        if (decimal.TryParse(txtCosto.Text, out decimal result) == false)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE!", "alert('Dati non validi!')", true);
            return;
        }
        if (decimal.TryParse(txtPrezzo.Text, out decimal result2) == false)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE!", "alert('Dati non validi!')", true);
            return;
        }

        #endregion

        AUTO.AGGIORNADB AA = new AUTO.AGGIORNADB();
        AA.codiceModello = int.Parse(ddlModello.SelectedValue);
        AA.targa = txtTarga.Text;
        AA.prezzo = decimal.Parse(txtPrezzo.Text.Replace(",", ".").ToString());
        AA.costo = decimal.Parse(txtCosto.Text.Replace(",", ".").ToString());
        AA.dataAcquisto = txtData.Text;

        AA.Insert();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SUCCESSO!", "alert('Dati inseriti con successo!')", true);

        ddlModello.SelectedIndex = 0;
        txtTarga.Text = "";
        txtCosto.Text = "";
        txtPrezzo.Text = "";
        txtData.Text = "";

    }

    protected void CaricaDdl()
    {
        AUTO A = new AUTO();

        ddlModello.DataSource = A.SelectForDDL();
        ddlModello.DataTextField = "descrizione";
        ddlModello.DataValueField = "codiceModello";
        ddlModello.DataBind();
    }
}