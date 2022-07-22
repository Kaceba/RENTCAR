using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModificaAuto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AUTO A = new AUTO();
            DataTable dt = A.Select(int.Parse(Session["codiceAuto"].ToString()));

            // prendo solo il campo descrizione dalla dt ritornata da SelectOne
            // E' POSSIBILE FARLO!
            ddlModello.SelectedValue = dt.Rows[0]["codiceModello"].ToString();
            txtTarga.Text = dt.Rows[0]["targa"].ToString();
            txtPrezzo.Text = dt.Rows[0]["prezzo"].ToString();
            txtCosto.Text = dt.Rows[0]["costo"].ToString();
            txtData.Text = dt.Rows[0].Field<DateTime>(5).ToString("yyyy-MM-dd");

            if (string.IsNullOrEmpty(Session["codiceAuto"].ToString()))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE!", "alert('Nessuna riga selezionata!')", true);
                return;
            }
            CaricaDDL();
        }
    }
    protected void CaricaDDL ()
    {
        AUTO A = new AUTO();

        ddlModello.DataSource = A.SelectForDDL();
        ddlModello.DataTextField = "descrizione";
        ddlModello.DataValueField = "codiceModello";
        ddlModello.DataBind();
    }
    protected void btnModifica_Click(object sender, EventArgs e)
    {

        #region "CONTROLLI FORMALI"

        if (string.IsNullOrEmpty(txtTarga.Text.Trim()) && string.IsNullOrEmpty(txtPrezzo.Text.Trim()))

        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE!", "alert('Dati mancanti!')", true);
            return;
        }
        if (string.IsNullOrEmpty(txtCosto.Text.Trim()) /*string.IsNullOrEmpty(txtData.Text.Trim())*/
)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE!", "alert('Dati mancanti!')", true);
            return;
        }
        if (string.IsNullOrEmpty(txtData.Text.Trim())
)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE!", "alert('Dati mancanti!')", true);
            return;
        }

        #endregion

        // istanza classe SPESE e dichiarazione variabili
        AUTO.AGGIORNADB AA = new AUTO.AGGIORNADB();

        AA.codiceAuto = int.Parse(Session["codiceAuto"].ToString());
        AA.codiceModello = int.Parse(ddlModello.SelectedValue.ToString());
        AA.targa = txtTarga.Text.Trim();
        AA.costo = decimal.Parse(txtCosto.Text.ToString());
        AA.prezzo = decimal.Parse(txtPrezzo.Text.ToString());
        AA.dataAcquisto = txtData.Text.Trim();

        // Update
        AA.Update();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SUCCESSO!", "alert('Auto modificata!')", true);

        // aggiorna griglia

        ddlModello.SelectedIndex = 0;
        txtCosto.Text = "";
        txtPrezzo.Text = "";
        txtData.Text = "";

        Session["codiceAuto"] = null;
    }
}