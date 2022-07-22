using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InserisciMarche : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnInvia_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtMarca.Text.Trim()))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Campo vuoto')", true);
            return;
        }

        MARCHE.AGGIORNADB MA = new MARCHE.AGGIORNADB();
        MARCHE M = new MARCHE();

        MA.descrizione = txtMarca.Text.Trim();

        if (M.CheckOne(MA.descrizione) == true)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ERRORE", "alert('Duplicato trovato')", true);
            return;
        }

        // se non esiste faccio insert
        MA.Insert();

        // Svuoto i campi  e aggiorno la griglia
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SUCCESSO", "alert('Marca Inserita')", true);

        txtMarca.Text = "";

    }

}