using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class MODELLI
{

    public MODELLI()
    {

    }

    public class AGGIORNADB
    {
        public int codiceModello;
        public int codiceMarca;
        public string descrizione;

        public void Insert()
        {
            CONNESSIONE c = new CONNESSIONE();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "tabModelli_Insert";
            cmd.Parameters.AddWithValue("@codiceMarca", codiceMarca);
            cmd.Parameters.AddWithValue("@descrizione", descrizione);

            c.EseguiSPcmdparam(cmd);
        }

        public void Update()
        {
            CONNESSIONE c = new CONNESSIONE();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "tabModelli_Update";
            cmd.Parameters.AddWithValue("@codiceModello", codiceModello);
            cmd.Parameters.AddWithValue("@codiceMarca", codiceMarca);
            cmd.Parameters.AddWithValue("@descrizione", descrizione);

            c.EseguiSPcmdparam(cmd);
        }
    }

    public DataTable Select()
    {
        CONNESSIONE c = new CONNESSIONE();

        return c.EseguiSp("tabModelli_SelectAll");
    }
    public DataTable Select(int codiceModello)
    {
        CONNESSIONE c = new CONNESSIONE();
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "tabModelli_SelectOne";
        cmd.Parameters.AddWithValue("@codiceModello", codiceModello);

        return c.EseguiSPselectparam(cmd);
    }

    public bool CheckOne(int codiceMarca, string descrizione)
    {
        CONNESSIONE c = new CONNESSIONE();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "tabModelli_CheckOne";
        cmd.Parameters.AddWithValue("@codiceMarca", codiceMarca);
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