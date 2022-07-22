using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class CONTRATTI
{

    public CONTRATTI()
    {

    }

    public class AGGIORNADB
    {
        public int codiceContratto;
        public int codiceCliente;
        public int codiceAuto;
        public string dataInizioContratto;
        public string dataFineContratto;

        public void Insert()
        {
            CONNESSIONE C = new CONNESSIONE();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "tabContratti_Insert";
            cmd.Parameters.AddWithValue("@codiceCliente", codiceCliente);
            cmd.Parameters.AddWithValue("@codiceAuto", codiceAuto);
            cmd.Parameters.AddWithValue("@dataInizioContratto", dataInizioContratto);
            cmd.Parameters.AddWithValue("@dataFineContratto", dataFineContratto);

            C.EseguiSPcmdparam(cmd);
        }

        public void Update()
        {
            CONNESSIONE C = new CONNESSIONE();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "tabContratti_Update";
            cmd.Parameters.AddWithValue("@codiceContratto", codiceContratto); // where
            cmd.Parameters.AddWithValue("@codiceCliente", codiceCliente); // set
            cmd.Parameters.AddWithValue("@codiceAuto", codiceAuto); // set
            cmd.Parameters.AddWithValue("@dataInizioContratto", dataInizioContratto); // set
            cmd.Parameters.AddWithValue("@dataFineContratto", dataFineContratto); // set

            C.EseguiSPcmdparam(cmd);
        }

        public void Delete()
        {
            CONNESSIONE C = new CONNESSIONE();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "tabContratti_Delete";
            cmd.Parameters.AddWithValue("codiceContratto", codiceContratto);

            C.EseguiSPcmdparam(cmd);
        }
    }

    public class CONTABILITA
    {
        public DataTable FatturatoPerMensile(int anno)
        {
            CONNESSIONE C = new CONNESSIONE();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "tabContratti_SelectMonthlySum";
            cmd.Parameters.AddWithValue("@anno", anno);

            return C.EseguiSPselectparam(cmd);
        }

    }

    public DataTable Select()
    {
        CONNESSIONE C = new CONNESSIONE();

        return C.EseguiSp("tabContratti_SelectAll");
    }
    public DataTable Select(int codiceContratto)
    {
        CONNESSIONE C = new CONNESSIONE();
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "tabContratti_SelectOne";
        cmd.Parameters.AddWithValue("@codiceContratto", codiceContratto);

        return C.EseguiSPselectparam(cmd);
    }

}