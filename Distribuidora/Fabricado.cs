using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Distribuidora
{
    public class Fabricado : Producto, IActiveRecord<Fabricado>
    {
        private int tiempoFab;
        private string usuarioAlta;
        private int idFabricado;
        private List<Tecnico> tecnicos;

        #region Properties
        public int TiempoFab
        {
            get
            {
                return tiempoFab;
            }

            set
            {
                tiempoFab = value;
            }
        }

        public string UsuarioAlta
        {
            get
            {
                return usuarioAlta;
            }

            set
            {
                usuarioAlta = value;
            }
        }

        public List<Tecnico> Tecnicos
        {
            get
            {
                return tecnicos;
            }

            set
            {
                tecnicos = value;
            }
        }

        public int IdFabricado
        {
            get
            {
                return idFabricado;
            }

            set
            {
                idFabricado = value;
            }
        }

        #endregion

        public override bool Borrar()
        {
            // TODO: Ver si se elimina de FabricadoFuncionarios, luego de Fabricados y despues de Producto o se crea un atributo en Fabricados que sea discontinuado
            // xa q la BD sea persistente
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

        public Fabricado Buscar()
        {
            Fabricado fabricado = new Fabricado();
            SqlConnection con = ObtenerConexion();
            string sql = "SELECT * FROM Fabricado INNER JOIN Producto ON Fabricado.IdProducto = Producto.IdProducto WHERE Producto.Nombre = @nombre";
            SqlParameter par = new SqlParameter("@nombre", this.Nombre);
            SqlDataReader reader = null;

            try
            {
                reader = EjecutarConsulta(con, sql, new List<SqlParameter>() { par }, CommandType.Text);

                if (reader.Read())
                {
                    fabricado.tiempoFab = Convert.ToInt32(reader["TiempoFab"]);
                    fabricado.usuarioAlta = reader["UsuarioAlta"].ToString();
                    fabricado.Id = Convert.ToInt32(reader["IdFabricado"]);
                    fabricado.Nombre = this.Nombre;
                    fabricado.Desc = reader["Descripcion"].ToString();
                    fabricado.Costo = Convert.ToInt32(reader["Costo"]);
                    fabricado.PrecioSugerido = Convert.ToInt32(reader["PrecioSugerido"]);
                    //TODO: Lista de tecnicos ??
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Dispose();
                }
            }

            return fabricado;
        }

        public override bool Crear()
        {
            bool ret = false;
            SqlConnection con = ObtenerConexion();
            SqlTransaction tran = null;
            try
            {
                string sql = "INSERT INTO Producto(Nombre, Descripcion, Costo, PrecioSugerido) VALUES(@nombre, @descripcion, @costo, @precioSugerido) SELECT scope_identity()AS IdProd";
                List<SqlParameter> parametros = new List<SqlParameter>();
                SqlParameter parNombre = new SqlParameter("@nombre", this.Nombre);
                SqlParameter parDescripcion = new SqlParameter("@descripcion", this.Desc);
                SqlParameter parCosto = new SqlParameter("@costo", this.Costo);
                SqlParameter parPrecioSugerido = new SqlParameter("@precioSugerido", this.PrecioSugerido);
                parametros.Add(parNombre);
                parametros.Add(parDescripcion);
                parametros.Add(parCosto);
                parametros.Add(parPrecioSugerido);
                con.Open();
                tran = con.BeginTransaction();
                int afectadas = EjecutarNoConsulta(con, sql, parametros, CommandType.Text, tran);
                if (afectadas > 0) ret = true;

                // TODO Como hacer xa tener el id del producto y agregarlo a fabricado 
                // Se puede poner el Insert con el Select en la consulta?
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

        public override bool Modificar()
        {
            throw new NotImplementedException();
        }

        public List<Fabricado> TraerTodo()
        {
            throw new NotImplementedException();
        }
    }
}