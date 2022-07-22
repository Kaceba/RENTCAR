using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AUTO
/// </summary>
public class AUTO
{

    public AUTO()
    {

    }

    public class AGGIORNADB
    {
        public int codiceAuto;
        public int codiceModello;
        public string targa;
        public decimal costo;
        public decimal prezzo;
        public string dataAcquisto;

        public void Insert()
        {
            CONNESSIONE c = new CONNESSIONE();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "tabAuto_Insert";
            cmd.Parameters.AddWithValue("@codiceModello", codiceModello);
            cmd.Parameters.AddWithValue("@targa", targa);
            cmd.Parameters.AddWithValue("@costo", costo);
            cmd.Parameters.AddWithValue("@prezzo", prezzo);
            cmd.Parameters.AddWithValue("@dataAcquisto", dataAcquisto);

            c.EseguiSPcmdparam(cmd);
        }

        public void Update()
        {
            CONNESSIONE C = new CONNESSIONE();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "tabAUTO_Update";
            cmd.Parameters.AddWithValue("@codiceAuto", codiceAuto);
            cmd.Parameters.AddWithValue("@codiceModello", codiceModello);
            cmd.Parameters.AddWithValue("@targa", targa);
            cmd.Parameters.AddWithValue("@costo", costo);
            cmd.Parameters.AddWithValue("@prezzo", prezzo);
            cmd.Parameters.AddWithValue("@dataAcquisto", dataAcquisto);

            C.EseguiSPcmdparam(cmd);
        }
    }

    public DataTable Select()
    {
        CONNESSIONE c = new CONNESSIONE();

        return c.EseguiSp("tabAuto_SelectAll");
    }

    public DataTable Select(int codiceAuto)
    {
        CONNESSIONE c = new CONNESSIONE();
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "tabAuto_SelectOne";
        cmd.Parameters.AddWithValue("@codiceAuto", codiceAuto);

        return c.EseguiSPselectparam(cmd);
    }

    public DataTable DDLSelect()
    {
        CONNESSIONE C = new CONNESSIONE();

        return C.EseguiSp("tabAuto_DDLSelect");
    }

    public DataTable SelectForDDL()
    {
        CONNESSIONE c = new CONNESSIONE();

        return c.EseguiSp("tabAuto_SelectForDDL");
    }
}