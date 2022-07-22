using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnInvia_Click(object sender, EventArgs e)
    {
        // controlli
        if (string.IsNullOrEmpty(txtUsername.Text.Trim()) || string.IsNullOrEmpty(txtPassword.Text.Trim()))
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Campo vuoto')", true);
            return;
        }

        UTENTI u = new UTENTI();

        u.utente = txtUsername.Text.Trim();
        u.password = txtPassword.Text.Trim();

        int quanti = u.login();

        if(quanti == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        // se controlli ok faccio login
        Response.Redirect("index.aspx");

    }
}