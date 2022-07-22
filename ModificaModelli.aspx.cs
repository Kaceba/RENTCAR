using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModificaModelli : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Se non vi è nessun elemento selezionato impedisco il proseguimento
            if (string.IsNullOrEmpty(Session["codiceModello"].ToString()))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Seleziona una riga per poterla modificare')", true);
                return;
            }

            MODELLI M = new MODELLI();
            DataTable dt = M.Select(int.Parse(Session["codiceModello"].ToString()));

            CaricaMarche();

            ddlMarca.SelectedValue = dt.Rows[0]["codiceMarche"].ToString();
            txtModello.Text = dt.Rows[0]["descrizione"].ToString();
        }
    }

    protected void CaricaMarche()
    {
        MODELLI M = new MODELLI();

        ddlMarca.DataSource = M.SelectForDDL();
        ddlMarca.DataTextField = "Marche";
        ddlMarca.DataValueField = "codiceMarche";

        ddlMarca.DataBind();
    }

    protected void btnModifica_Click(object sender, EventArgs e)
    {
        // Controlli formali
        if (string.IsNullOrEmpty(txtModello.Text.Trim()))
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ERRORE", "alert('Dati non validi')", true);
            return;
        }

        MODELLI.AGGIORNADB MA = new MODELLI.AGGIORNADB();

        MA.codiceModello = int.Parse(Session["codiceModello"].ToString());
        MA.codiceMarca = int.Parse(ddlMarca.SelectedValue);
        MA.descrizione = txtModello.Text.Trim();

        MA.Update();

        // Aggiorno la tabella e resetto i campi
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "SUCCESSO", "alert('Dati modificati correttamente')", true);

        txtModello.Text = "";
        Session["codiceModello"] = null;
    }
}