using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InserisciClienti : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnInvia_Click(object sender, EventArgs e)
    {

        #region "CONTROLLI FORMALI"

        if (string.IsNullOrEmpty(txtRAGSOC.Text.Trim()))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE", "alert('Ragione sociale vuota')", true);
            return;
        }
        if (string.IsNullOrEmpty(txtPiva.Text.Trim()))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERROE", "alert('P.IVA Mancante')", true);
            return;
        }
        if (string.IsNullOrEmpty(txtCodFisc.Text.Trim()))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE", "alert('Codice Fiscale mancante')", true);
            return;
        }
        if (string.IsNullOrEmpty(txtIndirizzo.Text.Trim()))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE", "alert('Indirizzo mancante')", true);
            return;
        }
        if (string.IsNullOrEmpty(txtCap.Text.Trim()))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE", "alert('CAP mancante')", true);
            return;
        }
        if (string.IsNullOrEmpty(txtCitta.Text.Trim()))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE", "alert('Città mancante')", true);
            return;
        }
        if (string.IsNullOrEmpty(txtProvincia.Text.Trim()))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE", "alert('Provincia mancante')", true);
            return;
        }

        #endregion

        CLIENTI.AGGIORNADB CA = new CLIENTI.AGGIORNADB();
        CLIENTI C = new CLIENTI();

        CA.RAGSOC = txtRAGSOC.Text.Trim();
        CA.piva = txtPiva.Text.Trim();
        CA.codfisc = txtCodFisc.Text.Trim();
        CA.indirizzo = txtIndirizzo.Text.Trim();
        CA.cap = txtCap.Text.Trim();
        CA.citta = txtCitta.Text.Trim();
        CA.provincia = txtProvincia.Text.Trim();

        if (C.CheckOne(CA.piva, CA.codfisc) == true)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ERRORE", "alert('Questo cliente esiste già')", true);
            return;
        }

        // se non esiste faccio insert
        CA.Insert();

        // Svuoto i campi  e aggiorno la griglia
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SUCCESSO", "alert('Cliente Inserito')", true);

        txtRAGSOC.Text = "";
        txtPiva.Text = "";
        txtCodFisc.Text = "";
        txtIndirizzo.Text = "";
        txtCap.Text = "";
        txtCitta.Text = "";
        txtProvincia.Text = "";

    }
}