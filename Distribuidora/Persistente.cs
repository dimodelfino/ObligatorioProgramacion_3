using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Distribuidora
{
    public abstract class Persistente
    {
        public SqlConnection ObtenerConexion()
        {
            SqlConnection con = new SqlConnection();
            string strCon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.ConnectionString = strCon;
            return con;
        }

        public int EjecutarNoConsulta(SqlConnection con, string texto, List<SqlParameter> pars, CommandType tipo)
        {
            int afectadas = -1;
            if (!string.IsNullOrEmpty(texto) && con != null)
            {
                SqlCommand com = ObtenerComando(con, texto, pars, tipo);
                try
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    afectadas = com.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
            return afectadas;

        }

        public SqlDataReader EjecutarConsulta(SqlConnection con, string texto, List<SqlParameter> pars, CommandType tipo)
        {
            SqlDataReader reader = null;
            if (!string.IsNullOrEmpty(texto) && con != null)
            {
                SqlCommand com = ObtenerComando(con, texto, pars, tipo);
                try
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    reader = com.ExecuteReader();
                }
                catch
                {
                    throw;
                }
            }
            return reader;

        }

        private static SqlCommand ObtenerComando(SqlConnection con, string texto, List<SqlParameter> pars, CommandType tipo)
        {
            SqlCommand com = new SqlCommand(texto, con);
            com.CommandType = tipo;
            if (pars != null) com.Parameters.AddRange(pars.ToArray());
            return com;
        }
    }
}