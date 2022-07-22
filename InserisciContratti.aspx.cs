using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InserisciContratti : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            caricaDDLClienti();
            caricaDDLAuto();
        }
    }
    protected void caricaDDLAuto()
    {
        // carico dati in ddl
        AUTO a = new AUTO();

        // SelectAll ritorna DataTable
        ddlAuto.DataSource = a.DDLSelect();
        ddlAuto.DataValueField = "codiceAuto";
        ddlAuto.DataTextField = "Automobile";
        ddlAuto.DataBind();
    }
    protected void caricaDDLClienti()
    {
        // carico dati in ddl
        CLIENTI c = new CLIENTI();

        // SelectAll ritorna DataTable
        ddlClienti.DataSource = c.SelectForDDL();
        ddlClienti.DataValueField = "codiceCliente";
        ddlClienti.DataTextField = "Cliente";
        ddlClienti.DataBind();
    }

    protected void btnInvia_Click(object sender, EventArgs e)
    {
        #region CONTROLLI
        // controlli formali prima di salvare variabili
        if (string.IsNullOrEmpty(txtInizioContratto.Text) || string.IsNullOrEmpty(txtFineContratto.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Attenzione", "alert('Errore dati non validi')", true);
            return;
        }
        #endregion

        // determino variabili da inserire nella query
        CONTRATTI.AGGIORNADB CA = new CONTRATTI.AGGIORNADB();
        CA.codiceAuto = int.Parse(ddlAuto.SelectedValue);
        CA.codiceCliente = int.Parse(ddlClienti.SelectedValue);
        CA.dataInizioContratto = txtInizioContratto.Text.Trim();
        CA.dataFineContratto = txtFineContratto.Text.Trim();

        CA.Insert();

        //reset table dropdownlist
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Attenzione", "alert('Dati inseriti correttamente')", true);

        txtInizioContratto.Text = "";
        txtFineContratto.Text = "";
        ddlClienti.SelectedIndex = 0;
        ddlAuto.SelectedIndex = 0;
    }

}