using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Distribuidora
{
    public class Importado : Producto, IActiveRecord<Importado>
    {
        private string origen;
        private int cantImportacion;

        #region Properties
        public string Origen
        {
            get
            {
                return origen;
            }

            set
            {
                origen = value;
            }
        }

        public int CantImportacion
        {
            get
            {
                return cantImportacion;
            }

            set
            {
                cantImportacion = value;
            }
        }
        #endregion

        public override bool Borrar()
        {
            bool ret = false;
            SqlConnection con = ObtenerConexion();
            SqlTransaction tran = null;
            try
            {
                string sql = "UPDATE Producto SET Descontinuado=1 WHERE Nombre=@nombre;";
                List<SqlParameter> parametros = new List<SqlParameter>();
                SqlParameter parNombre = new SqlParameter("@nombre", this.Nombre);
                parametros.Add(parNombre);
                con.Open();
                tran = con.BeginTransaction();
                int afectadas = EjecutarNoConsulta(con, sql, parametros, CommandType.Text, tran);
                if (afectadas > 0)
                {
                    ret = true;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return ret;
        }

        public Importado Buscar()
        {
            throw new NotImplementedException();
        }

        public override bool Crear()
        {
            throw new NotImplementedException();
        }

        public override bool Modificar()
        {
            throw new NotImplementedException();
        }

        public List<Importado> TraerTodo()
        {
            throw new NotImplementedException();
        }
    }
}