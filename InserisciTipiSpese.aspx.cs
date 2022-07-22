using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InserisciTipiSpese : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    protected void btnInvia_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtTipoSpesa.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ERRORE", "alert('Campo vuoto')", true);
            return;
        }

        TIPISPESE T = new TIPISPESE();
        TIPISPESE.AGGIORNADB TA = new TIPISPESE.AGGIORNADB();

        TA.descrizione = txtTipoSpesa.Text;

        //verifico che non esista già
        if (T.CheckOne(TA.descrizione) == true)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ERRORE", "alert('Duplicato trovato')", true);
            return;
        }

        // se non esiste faccio insert
        TA.Insert();

        ScriptManager.RegisterClientScriptBlock(this, GetType(), "SUCCESSO", "alert('Tipo spesa inserito')", true);

        txtTipoSpesa.Text = "";
       
    }

}