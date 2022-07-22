using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EliminaSpese : System.Web.UI.Page
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

        }
    }

    protected void btnElimina_Click(object sender, EventArgs e)
    {
        SPESE.AGGIORNADB SA = new SPESE.AGGIORNADB();

        SA.codiceSpesa = int.Parse(Session["codiceSpesa"].ToString());

        SA.Delete();

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SUCCESSO", "alert('Spesa eliminata con successo')", true);

    }
}