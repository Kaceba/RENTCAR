using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class MARCHE
{
    public MARCHE()
    {

    }

    public class AGGIORNADB
    {
        public int codiceMarche;
        public string descrizione;
        public void Insert()
        {
            CONNESSIONE c = new CONNESSIONE();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "tabMarche_Insert";
            cmd.Parameters.AddWithValue("@descrizione", descrizione);

            c.EseguiSPcmdparam(cmd);
        }

        public void Update()
        {
            CONNESSIONE c = new CONNESSIONE();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "tabMarche_Update";
            cmd.Parameters.AddWithValue("@descrizione", descrizione);
            cmd.Parameters.AddWithValue("@codiceMarche", codiceMarche);

            c.EseguiSPcmdparam(cmd);
        }
    }
    
    public DataTable Select() // SelectAll
    {
        CONNESSIONE c = new CONNESSIONE();

        return c.EseguiSp("tabMarche_SelectAll");

    }

    public DataTable Select(int codiceMarche) // SelectOne
    {
        CONNESSIONE c = new CONNESSIONE();
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "tabMarche_SelectOne";
        cmd.Parameters.AddWithValue("@codiceMarche", codiceMarche);

        return c.EseguiSPselectparam(cmd);
    }

    public bool CheckOne(string descrizione)
    {
        CONNESSIONE c = new CONNESSIONE();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "tabMarche_CheckOne";
        cmd.Parameters.AddWithValue("@descrizione", descrizione);

        dt = c.EseguiSPselectparam(cmd);

        return dt.Rows.Count > 0;
    }

    public DataTable SelectForDDL()
    {
        CONNESSIONE C = new CONNESSIONE();

        return C.EseguiSp("tabModelli_SelectForDDL");
    }
}