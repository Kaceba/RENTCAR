using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModificaSpese : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Se non vi è nessun elemento selezionato impedisco il proseguimento
            if (string.IsNullOrEmpty(Session["codiceSpesa"].ToString()))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Seleziona una riga per poterla modificare')", true);
                return;
            }

            SPESE S = new SPESE();
            DataTable dt = S.Select(int.Parse(Session["codiceSpesa"].ToString()));

            CaricaTipiSpesa();

            ddlCodiceTipoSpesa.SelectedValue = dt.Rows[0]["codiceTipoSpesa"].ToString();
            txtImporto.Text = dt.Rows[0]["importo"].ToString();
            txtDataSpesa.Text = dt.Rows[0].Field<DateTime>(3).ToString("yyyy-MM-dd");

        }
    }
    public void CaricaTipiSpesa()
    {
        SPESE S = new SPESE();

        ddlCodiceTipoSpesa.DataSource = S.SelectForDDL();
        ddlCodiceTipoSpesa.DataTextField = "descrizione";
        ddlCodiceTipoSpesa.DataValueField = "codiceTipoSpesa";

        ddlCodiceTipoSpesa.DataBind();
    }

    protected void btnModifica_Click(object sender, EventArgs e)
    {
        // Controlli formali
        if (string.IsNullOrEmpty(txtDataSpesa.Text.Trim()) || string.IsNullOrEmpty(txtImporto.Text.Trim()))
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ERRORE", "alert('Dati non validi')", true);
            return;
        }

        SPESE.AGGIORNADB SA = new SPESE.AGGIORNADB();

        SA.codiceSpesa = int.Parse(Session["codiceSpesa"].ToString());
        SA.codiceTipoSpesa = int.Parse(ddlCodiceTipoSpesa.SelectedValue);
        SA.importo = decimal.Parse(txtImporto.Text.Trim());
        SA.dataspesa = txtDataSpesa.Text.Trim();

        SA.Update();

        // Aggiorno la tabella e resetto i campi
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "SUCCESSO", "alert('Dati modificati correttamente')", true);

        txtDataSpesa.Text = "";
        txtImporto.Text = "";
        Session["codiceSpesa"] = null;
    }
}