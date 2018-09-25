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
        private int idImportado;
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

        public int IdImportado
        {
            get
            {
                return idImportado;
            }

            set
            {
                idImportado = value;
            }
        }
        #endregion

        #region Metodos

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
            Importado importado = new Importado();
            SqlConnection con = ObtenerConexion();
            string sql = "SELECT * FROM Importados INNER JOIN Producto ON Importados.IdProducto = Producto.IdProducto WHERE IdImportados=@idImportado";
            SqlParameter par = new SqlParameter("@idImportado", this.IdImportado);
            SqlDataReader reader = null;

            try
            {
                reader = EjecutarConsulta(con, sql, new List<SqlParameter>() { par }, CommandType.Text);

                if (reader.Read())
                {
                    importado.origen = reader["Origen"].ToString();
                    importado.cantImportacion = Convert.ToInt32(reader["CantImportacion"]);
                    importado.Id = this.Id;
                    importado.idImportado = Convert.ToInt32(reader["IdImportados"]);
                    importado.Nombre = reader["Nombre"].ToString();
                    importado.Desc = reader["Descripcion"].ToString();
                    importado.Costo = Convert.ToInt32(reader["Costo"]);
                    importado.PrecioSugerido = Convert.ToInt32(reader["PrecioSugerido"]);
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
            return importado;
        }

        public Importado BuscarPorNombre()
        {
            Importado importados = new Importado();
            SqlConnection con = ObtenerConexion();
            string sql = "SELECT * FROM Importados INNER JOIN Producto ON Importados.IdProducto = Producto.IdProducto WHERE Nombre=@nombre";
            SqlParameter par = new SqlParameter("@nombre", this.Nombre);
            SqlDataReader reader = null;

            try
            {
                reader = EjecutarConsulta(con, sql, new List<SqlParameter>() { par }, CommandType.Text);

                if (reader.Read())
                {
                    importados.origen = reader["Origen"].ToString();
                    importados.cantImportacion = Convert.ToInt32(reader["CantImportacion"]);
                    importados.Id = Convert.ToInt32(reader["IdProducto"]);
                    importados.idImportado = Convert.ToInt32(reader["IdImportados"]);
                    importados.Nombre = this.Nombre;
                    importados.Desc = reader["Descripcion"].ToString();
                    importados.Costo = Convert.ToInt32(reader["Costo"]);
                    importados.PrecioSugerido = Convert.ToInt32(reader["PrecioSugerido"]);
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
            return importados;
        }

        public override bool Crear()
        {
            bool ret = false;
            SqlConnection con = ObtenerConexion();
            SqlTransaction tran = null;
            try
            {
                string sql = "INSERT INTO Producto(Nombre, Descripcion, Costo, PrecioSugerido, Descontinuado) VALUES(@nombre, @descripcion, @costo, @precioSugerido, 0) SELECT scope_identity()AS IdProd";
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
                this.Id = Convert.ToInt32(EjecutarEscalar(con, sql, parametros, CommandType.Text, tran));

                sql = "INSERT INTO Importados VALUES (@IdProducto, @Origen, @CantImportacion)";
                List<SqlParameter> parametrosImportado = new List<SqlParameter>();
                SqlParameter parIidProd = new SqlParameter("@IdProducto", this.Id);
                SqlParameter parIorigen = new SqlParameter("@Origen", this.Origen);
                SqlParameter parIcantImp = new SqlParameter("@CantImportacion", this.CantImportacion);

                parametrosImportado.Add(parIidProd);
                parametrosImportado.Add(parIorigen);
                parametrosImportado.Add(parIcantImp);

                EjecutarNoConsulta(con, sql, parametrosImportado, CommandType.Text, tran);

                tran.Commit();
                ret = true;
            }
            catch
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
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
            bool ret = false;
            SqlConnection con = ObtenerConexion();
            SqlTransaction tran = null;
            try
            {
                string sql = "UPDATE INTO Producto(Nombre, Descripcion, Costo, PrecioSugerido) VALUES(@nombre, @descripcion, @costo, @precioSugerido)";
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
                EjecutarNoConsulta(con, sql, parametros, CommandType.Text, tran);

                sql = "UPDATE Importados SET @IdProducto=IdProducto , @Origen=Origen , @CantImportacion=CantImportacion)";
                List<SqlParameter> parametrosImportado = new List<SqlParameter>();
                SqlParameter parIidProd = new SqlParameter("@IdProducto", this.Id);
                SqlParameter parIorigen = new SqlParameter("@Origen", this.Origen);
                SqlParameter parIcantImportacion = new SqlParameter("@CantImportacion", this.CantImportacion);

                parametrosImportado.Add(parIidProd);
                parametrosImportado.Add(parIorigen);
                parametrosImportado.Add(parIcantImportacion);

                EjecutarNoConsulta(con, sql, parametrosImportado, CommandType.Text, tran);

                tran.Commit();
                ret = true;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return ret;
        }

        public List<Importado> TraerTodo()
        {
            List<Importado> importados = new List<Importado>();
            SqlConnection con = ObtenerConexion();
            string sql = "SELECT * FROM Importados INNER JOIN Producto ON Importados.IdProducto = Producto.IdProducto";
            SqlDataReader reader = null;
            try
            {
                reader = EjecutarConsulta(con, sql, null, CommandType.Text);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Importado imp = new Importado()
                        {
                            IdImportado = Convert.ToInt32(reader["IdFabricado"]),
                            Id = Convert.ToInt32(reader["IdProducto"]),
                            Origen = reader["Origen"].ToString(),
                            CantImportacion = Convert.ToInt32(reader["CantImportacion"]),
              
                        };
                        importados.Add(imp);
                    }
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
            return importados;
        }

        #endregion

    }
}