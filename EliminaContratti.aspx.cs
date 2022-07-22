using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EliminaContratti : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(Session["codiceContratto"].ToString()))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE!", "alert('Inserisci dati validi!')", true);
                return;
            }
        }
    }
    protected void btnElimina_Click(object sender, EventArgs e)
    {
        CONTRATTI.AGGIORNADB CA = new CONTRATTI.AGGIORNADB();
        CONTRATTI C = new CONTRATTI();
        DataTable dt = C.Select(int.Parse(Session["codiceContratto"].ToString()));

        CA.Delete();

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SUCCESSO!", "alert('Eliminazione avvenuta!')", true);
        return;
    }
}