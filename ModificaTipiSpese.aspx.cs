using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModificaTipiSpese : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Se non vi è nessun elemento selezionato impedisco il proseguimento
            try // prova questo
            {
                if (string.IsNullOrEmpty(Session["codiceTipoSpesa"].ToString()))
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Seleziona una riga per poterla modificare')", true);
                    return;
                }
            }

            // se tira exceptions

            catch (NullReferenceException ex) // catch e gestisci
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Non è stata selezionata una riga')", true);
            }

            // e infine correggi l'errore
            finally
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Si è pregati di selezionare una riga per poter modificare')", true);

            }
            TIPISPESE.AGGIORNADB TA = new TIPISPESE.AGGIORNADB();
            TIPISPESE T = new TIPISPESE();

            TA.codicetipospesa = int.Parse(Session["codiceTipoSpesa"].ToString());
            DataTable dt = T.Select(TA.codicetipospesa);

            txtModificaTipiSpese.Text = dt.Rows[0]["descrizione"].ToString();
        }
    }

    protected void btnModifica_Click(object sender, EventArgs e)
    {

        // Controlli formali
        if (string.IsNullOrEmpty(txtModificaTipiSpese.Text.Trim()))
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ERRORE", "alert('Dati non validi')", true);
            return;
        }

        TIPISPESE.AGGIORNADB TA = new TIPISPESE.AGGIORNADB();
        TIPISPESE T = new TIPISPESE();

        TA.descrizione = txtModificaTipiSpese.Text.Trim();
        TA.codicetipospesa = int.Parse(Session["codiceTipoSpesa"].ToString());

        if (T.CheckOne(TA.descrizione) == true)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE!", "alert('Dati già presenti!')", true);
            return;
        }

        TA.Update();

        // Aggiorno la tabella e resetto i campi
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "SUCCESSO", "alert('Dati modificati correttamente')", true);

        txtModificaTipiSpese.Text = "";
        Session["codiceTipoSpesa"] = null;
    }
}