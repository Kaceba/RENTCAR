using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InserisciModelli : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CaricaDDLMarche();

        }
    }
    protected void CaricaDDLMarche()
    {
        MARCHE M = new MARCHE();

        ddlMarca.DataSource = M.SelectForDDL();
        ddlMarca.DataTextField = "Marche";
        ddlMarca.DataValueField = "codiceMarche";

        ddlMarca.DataBind();

    }

    protected void btnInvia_Click(object sender, EventArgs e)
    {
        // controlli formali
        if (string.IsNullOrEmpty(txtModello.Text.Trim()))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        MODELLI.AGGIORNADB MA = new MODELLI.AGGIORNADB();
        MA.descrizione = txtModello.Text.Trim();
        MA.codiceMarca = int.Parse(ddlMarca.SelectedValue);

        MA.Insert();

        //aggiorna la tabella
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SUCCESSO", "alert('Modello inserito')", true);

        //pulisci i campi
        ddlMarca.SelectedIndex = 0;
        txtModello.Text = "";
    }

}