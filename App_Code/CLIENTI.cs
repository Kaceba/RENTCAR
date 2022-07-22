using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class CLIENTI
{
    public CLIENTI()
    {

    }

    public class AGGIORNADB
    {
        public int codiceCliente;
        public string RAGSOC;
        public string piva;
        public string codfisc;
        public string indirizzo;
        public string cap;
        public string citta;
        public string provincia;

        public void Insert()
        {
            CONNESSIONE c = new CONNESSIONE();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "tabClienti_Insert";
            cmd.Parameters.AddWithValue("@RAGSOC", RAGSOC);
            cmd.Parameters.AddWithValue("@piva", piva);
            cmd.Parameters.AddWithValue("@codfisc", codfisc);
            cmd.Parameters.AddWithValue("@indirizzo", indirizzo);
            cmd.Parameters.AddWithValue("@cap", cap);
            cmd.Parameters.AddWithValue("@citta", citta);
            cmd.Parameters.AddWithValue("@provincia", provincia);

            c.EseguiSPcmdparam(cmd);
        }

        public void Update()
        {
            CONNESSIONE c = new CONNESSIONE();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "tabClienti_Update";
            cmd.Parameters.AddWithValue("@codiceCliente", codiceCliente);
            cmd.Parameters.AddWithValue("@RAGSOC", RAGSOC);
            cmd.Parameters.AddWithValue("@piva", piva);
            cmd.Parameters.AddWithValue("@codfisc", codfisc);
            cmd.Parameters.AddWithValue("@indirizzo", indirizzo);
            cmd.Parameters.AddWithValue("@cap", cap);
            cmd.Parameters.AddWithValue("@citta", citta);
            cmd.Parameters.AddWithValue("@provincia", provincia);

            c.EseguiSPcmdparam(cmd);
        }

        public bool CheckOne_Update()
        {
            CONNESSIONE c = new CONNESSIONE();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "tabClienti_CheckOne_Update";
            cmd.Parameters.AddWithValue("@RAGSOC", RAGSOC);
            cmd.Parameters.AddWithValue("@piva", piva);
            cmd.Parameters.AddWithValue("@codfisc", codfisc);
            cmd.Parameters.AddWithValue("@indirizzo", indirizzo);
            cmd.Parameters.AddWithValue("@cap", cap);
            cmd.Parameters.AddWithValue("@citta", citta);
            cmd.Parameters.AddWithValue("@provincia", provincia);

            dt = c.EseguiSPselectparam(cmd);

            return dt.Rows.Count > 0;
        }
    }

    public DataTable Select()
    {
        CONNESSIONE c = new CONNESSIONE();

        return c.EseguiSp("tabClienti_SelectAll");
    }

    public DataTable Select(int codiceCliente)
    {
        CONNESSIONE c = new CONNESSIONE();
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "tabClienti_SelectOne";
        cmd.Parameters.AddWithValue("@codiceCliente", codiceCliente);

        return c.EseguiSPselectparam(cmd);
    }

    public bool CheckOne(string piva, string codfisc)
    {
        CONNESSIONE c = new CONNESSIONE();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "tabClienti_CheckOne";
        cmd.Parameters.AddWithValue("@piva", piva);
        cmd.Parameters.AddWithValue("@codfisc", codfisc);

        dt = c.EseguiSPselectparam(cmd);

        return dt.Rows.Count > 0;
    }

    public DataTable SelectForDDL()
    {
        CONNESSIONE C = new CONNESSIONE();

        return C.EseguiSp("tabClienti_SelectForDDL");
    }
}