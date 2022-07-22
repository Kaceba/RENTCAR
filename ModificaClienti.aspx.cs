using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModificaClienti : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Se non vi è nessun elemento selezionato impedisco il proseguimento
            if (string.IsNullOrEmpty(Session["codiceCliente"].ToString()))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Seleziona una riga per poterla modificare')", true);
                return;
            }

            CLIENTI C = new CLIENTI();
            DataTable dt = C.Select(int.Parse(Session["codiceCliente"].ToString()));

            txtRAGSOC.Text = dt.Rows[0]["RAGSOC"].ToString();
            txtPiva.Text = dt.Rows[0]["piva"].ToString();
            txtCodFisc.Text = dt.Rows[0]["codfisc"].ToString();
            txtIndirizzo.Text = dt.Rows[0]["indirizzo"].ToString();
            txtCap.Text = dt.Rows[0]["cap"].ToString();
            txtCitta.Text = dt.Rows[0]["citta"].ToString();
            txtProvincia.Text = dt.Rows[0]["prov"].ToString();
        }
    }

    protected void btnModifica_Click(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(txtRAGSOC.Text) ||
            string.IsNullOrEmpty(txtPiva.Text) ||
            string.IsNullOrEmpty(txtCodFisc.Text) ||
            string.IsNullOrEmpty(txtIndirizzo.Text) ||
            string.IsNullOrEmpty(txtCap.Text) ||
            string.IsNullOrEmpty(txtCitta.Text) ||
            string.IsNullOrEmpty(txtProvincia.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ERRORE", "alert('Almeno un campo vuoto')", true);
            return;
        }

        CLIENTI.AGGIORNADB CA = new CLIENTI.AGGIORNADB();

        CA.codiceCliente = int.Parse(Session["codiceCliente"].ToString());
        CA.RAGSOC = txtRAGSOC.Text;
        CA.piva = txtPiva.Text;
        CA.codfisc = txtCodFisc.Text;
        CA.indirizzo = txtIndirizzo.Text;
        CA.cap = txtCap.Text;
        CA.citta = txtCitta.Text;
        CA.provincia = txtProvincia.Text;


        if (CA.CheckOne_Update() == true)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ERRORE", "alert('Nessuna modifica effettuata')", true);
            return;
        }

        CA.Update();

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SUCCESSO", "alert('Informazioni cliente cambiate')", true);

        txtRAGSOC.Text = "";
        txtPiva.Text = "";
        txtCodFisc.Text = "";
        txtIndirizzo.Text = "";
        txtCap.Text = "";
        txtCitta.Text = "";
        txtProvincia.Text = "";

        Session["codiceCliente"] = null;
    }
}