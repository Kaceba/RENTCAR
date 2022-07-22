using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
public class UTENTI
{
    public int chiave;
    public string utente;
    public string password;

    public UTENTI()
    {

    }

    public int login()
    {
        CONNESSIONE c = new CONNESSIONE();
        DataTable dt = new DataTable();

        dt = c.EseguiSelect("SELECT COUNT (*) AS Quanti FROM tabUTENTI WHERE utente = '" + utente + "' AND password = '" + password + "'");

        int quanti = (int)dt.Rows[0]["Quanti"];

        return quanti;
    }
}