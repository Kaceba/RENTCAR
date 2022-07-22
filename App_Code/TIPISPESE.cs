using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class TIPISPESE
{
    public TIPISPESE()
    {
        //costruttore
    }

    public class AGGIORNADB
    {
        public int codicetipospesa;
        public string descrizione;
        public void Insert()
        {
            CONNESSIONE c = new CONNESSIONE();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "tabTipiSpese_Insert";
            cmd.Parameters.AddWithValue("@descrizione", descrizione);

            c.EseguiSPcmdparam(cmd);

        }

        public void Update()
        {
            CONNESSIONE c = new CONNESSIONE();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "tabTipiSpese_Update";
            cmd.Parameters.AddWithValue("@descrizione", descrizione);
            cmd.Parameters.AddWithValue("@codicetipospesa", codicetipospesa);

            c.EseguiSPcmdparam(cmd);
        }
    }
    public DataTable Select() // SelectAll
    {
        CONNESSIONE c = new CONNESSIONE();

        return c.EseguiSp("tabTipiSpese_SelectAll");            // OVERLOAD DI METODI
    }
    public DataTable Select(int codicetipospesa) // SelectOne
    {
        CONNESSIONE c = new CONNESSIONE();
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "tabTipiSpese_SelectOne";
        cmd.Parameters.AddWithValue("@codiceTipoSpesa", codicetipospesa);

        return c.EseguiSPselectparam(cmd);
    }
    public bool CheckOne(string descrizione)
    {
        CONNESSIONE c = new CONNESSIONE();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "tabTipiSpese_CheckOne";
        cmd.Parameters.AddWithValue("@descrizione", descrizione);

        dt = c.EseguiSPselectparam(cmd);

        return dt.Rows.Count > 0;

    }
}