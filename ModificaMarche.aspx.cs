using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModificaMarche : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Se non vi è nessun elemento selezionato impedisco il proseguimento
            if (string.IsNullOrEmpty(Session["codiceMarche"].ToString()))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Seleziona una riga per poterla modificare')", true);
                return;
            }

            MARCHE M = new MARCHE();
            DataTable dt = M.Select(int.Parse(Session["codiceMarche"].ToString()));

            txtMarche.Text = dt.Rows[0]["Marche"].ToString();
        }
    }

    protected void btnModifica_Click(object sender, EventArgs e)
    {

        // Controlli formali
        if (string.IsNullOrEmpty(txtMarche.Text.Trim()))
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ERRORE", "alert('Dati non validi')", true);
            return;
        }

        MARCHE.AGGIORNADB MA = new MARCHE.AGGIORNADB();
        MARCHE M = new MARCHE();

        MA.descrizione = txtMarche.Text.Trim();
        MA.codiceMarche = int.Parse(Session["codiceMarche"].ToString());

        if (M.CheckOne(MA.descrizione) == true)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE!", "alert('Dati già presenti!')", true);
            return;
        }

        MA.Update();

        // Aggiorno la tabella e resetto i campi
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "SUCCESSO", "alert('Dati modificati correttamente')", true);

        txtMarche.Text = "";
        Session["codiceMarche"] = null;
    }
}