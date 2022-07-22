using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class SPESE
{
    public SPESE()
    {

    }

    public class AGGIORNADB
    {
        public int codiceSpesa;
        public int codiceTipoSpesa;
        public decimal importo;
        public string dataspesa;
        public void Insert()
        {
            CONNESSIONE c = new CONNESSIONE();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "tabSpese_Insert";
            cmd.Parameters.AddWithValue("@codiceTipoSpesa", codiceTipoSpesa);
            cmd.Parameters.AddWithValue("@importo", importo);
            cmd.Parameters.AddWithValue("@dataspesa", dataspesa);

            c.EseguiSPcmdparam(cmd);
        }

        public void Update()
        {
            CONNESSIONE c = new CONNESSIONE();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "TabSpese_Update";
            cmd.Parameters.AddWithValue("@codiceSpesa", codiceSpesa);
            cmd.Parameters.AddWithValue("@codiceTipoSpesa", codiceTipoSpesa);
            cmd.Parameters.AddWithValue("@importo", importo);
            cmd.Parameters.AddWithValue("@dataspesa", dataspesa);

            c.EseguiSPcmdparam(cmd);
        }

        public void Delete()
        {
            CONNESSIONE c = new CONNESSIONE();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "TabSpese_Delete";
            cmd.Parameters.AddWithValue("@codiceSpesa", codiceSpesa);

            c.EseguiSPcmdparam(cmd);
        }

    }

    public DataTable Select() // SelectAll
    {
        CONNESSIONE c = new CONNESSIONE();

        return c.EseguiSp("tabSpese_SelectAll");
    }

    public DataTable Select(int codiceSpesa) // SelectOne
    {
        CONNESSIONE c = new CONNESSIONE();
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "tabSpesa_SelectOne";
        cmd.Parameters.AddWithValue("@codiceSpesa", codiceSpesa);

        return c.EseguiSPselectparam(cmd);
    }
    public DataTable SelectForDDL()
    {
        CONNESSIONE C = new CONNESSIONE();

        return C.EseguiSp("tabSpese_SelectForDDL");
    }

}