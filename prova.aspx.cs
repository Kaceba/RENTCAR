using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class prova : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CONNESSIONE c = new CONNESSIONE();

        ddl1.DataSource = c.EseguiSelect("SELECT * FROM tabTIPISPESE");
        ddl1.DataValueField = "codiceTipoSpesa";
        ddl1.DataTextField = "descrizione";

        ddl1.DataBind();

    }
}