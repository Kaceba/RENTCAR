using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


/// <summary>
/// Classe che mi aiuta nel connettermi al db
/// </summary>
public class CONNESSIONE // classe
{
    // Dichiarazione dei membri della classe
    public SqlConnection conn = new SqlConnection();

    public CONNESSIONE() // costruttore della classe
    {
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["RobRENTCARConnectionString"].ConnectionString;
    }

    /// <summary>
    /// Metodo che esegue una query sul db
    /// </summary>
    /// <returns>Restituisce un DataTable</returns>

    public DataTable EseguiSelect(string query)
    {
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = conn;
        cmd.CommandText = query;

        SqlDataAdapter DA = new SqlDataAdapter();

        DA.SelectCommand = cmd;
        DA.Fill(dt);

        return (dt);

    }

    public void EseguiCommand(string query)
    {
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = conn;
        cmd.CommandText = query;

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public DataTable EseguiSp(string query)
    {
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = conn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = query;

        SqlDataAdapter DA = new SqlDataAdapter();

        DA.SelectCommand = cmd;
        DA.Fill(dt);

        return (dt);

    }

    public void EseguiSPcmdparam(SqlCommand cmd)
    {
        cmd.Connection = conn;
        cmd.CommandType = CommandType.StoredProcedure;

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public DataTable EseguiSPselectparam(SqlCommand cmd)
    {
        DataTable dt = new DataTable();

        cmd.Connection = conn;
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter DA = new SqlDataAdapter();

        DA.SelectCommand = cmd;
        DA.Fill(dt);

        return dt;
    }
}