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
        private int usuarioAlta;
        private int idFabricado;
        private List<Tecnico> tecnicos = new List<Tecnico>();

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

        public int UsuarioAlta
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

        #endregion

        #region Metodos
        public override bool Borrar()
        {  
            bool ret = false;
            SqlConnection con = ObtenerConexion();
            SqlTransaction tran = null;
            try
            {
                string sql = "UPDATE Producto SET Descontinuado=1 WHERE IdProducto=@idProducto;";
                List<SqlParameter> parametros = new List<SqlParameter>();
                SqlParameter parId = new SqlParameter("@idProducto", this.Id);
                parametros.Add(parId);
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

        public Fabricado Buscar()
        {
            Fabricado fabricado = new Fabricado();
            SqlConnection con = ObtenerConexion();
            string sql = "SELECT * FROM Fabricado INNER JOIN Producto ON Fabricado.IdProducto = Producto.IdProducto WHERE IdFabricado=@idFabricado";
            SqlParameter par = new SqlParameter("@idFabricado", this.IdFabricado);
            SqlDataReader reader = null;

            try
            {
                reader = EjecutarConsulta(con, sql, new List<SqlParameter>() { par }, CommandType.Text);

                if (reader.Read())
                {
                    fabricado.tiempoFab = Convert.ToInt32(reader["TiempoFab"]);
                    fabricado.usuarioAlta = Convert.ToInt32(reader["usuarioAlta"]);
                    fabricado.Id = this.Id;
                    fabricado.idFabricado = Convert.ToInt32(reader["IdFabricado"]);
                    fabricado.Nombre = reader["Nombre"].ToString(); 
                    fabricado.Desc = reader["Descripcion"].ToString();
                    fabricado.Costo = Convert.ToInt32(reader["Costo"]);
                    fabricado.PrecioSugerido = Convert.ToInt32(reader["PrecioSugerido"]);
                }

                sql = "SELECT * FROM FabricadoFuncionario WHERE IdProducto=@idProducto";
                reader.Close();
                reader=EjecutarConsulta(con, sql, new List<SqlParameter>() { new SqlParameter ("@idProducto", this.Id)}, CommandType.Text);

                while (reader.Read())
                {
                    Tecnico tec = new Tecnico()
                    {
                        IdProducto = Convert.ToInt32(reader["IdProducto"]),
                        IdEmpleado = Convert.ToInt32(reader["IdFuncionario"]),
                        IdFabricado = Convert.ToInt32(reader["IdFabricado"]),
                        DescTarea = reader["DescTarea"].ToString(),
                        TiempTarea = Convert.ToInt32(reader["TiempoTarea"])
                    };
                    this.tecnicos.Add(tec);
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

        public Fabricado BuscarPorNombre()
        {
            Fabricado fabricado = new Fabricado();
            SqlConnection con = ObtenerConexion();
            string sql = "SELECT * FROM Fabricado INNER JOIN Producto ON Fabricado.IdProducto = Producto.IdProducto WHERE Nombre=@nombre";
            SqlParameter par = new SqlParameter("@nombre", this.Nombre);
            SqlDataReader reader = null;

            try
            {
                reader = EjecutarConsulta(con, sql, new List<SqlParameter>() { par }, CommandType.Text);

                if (reader.Read())
                {
                    fabricado.tiempoFab = Convert.ToInt32(reader["TiempoFab"]);
                    fabricado.usuarioAlta = Convert.ToInt32(reader["usuarioAlta"]);
                    fabricado.Id = Convert.ToInt32(reader["IdProducto"]);
                    fabricado.idFabricado = Convert.ToInt32(reader["IdFabricado"]);
                    fabricado.Nombre = this.Nombre;
                    fabricado.Desc = reader["Descripcion"].ToString();
                    fabricado.Costo = Convert.ToInt32(reader["Costo"]);
                    fabricado.PrecioSugerido = Convert.ToInt32(reader["PrecioSugerido"]);
                }
                sql = "SELECT * FROM FabricadoFuncionario WHERE IdProducto=@idProducto";
                reader.Close();
                reader = EjecutarConsulta(con, sql, new List<SqlParameter>() { new SqlParameter("@idProducto", this.Id) }, CommandType.Text);

                while (reader.Read())
                {
                    Tecnico tec = new Tecnico()
                    {
                        IdProducto = Convert.ToInt32(reader["IdProducto"]),
                        IdEmpleado = Convert.ToInt32(reader["IdFuncionario"]),
                        IdFabricado = Convert.ToInt32(reader["IdFabricado"]),
                        DescTarea = reader["DescTarea"].ToString(),
                        TiempTarea = Convert.ToInt32(reader["TiempoTarea"])
                    };
                    this.tecnicos.Add(tec);
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
                this.Id = EjecutarNoConsulta(con, sql, parametros, CommandType.Text, tran);

                sql = "INSERT INTO Fabricado VALUES (@IdProducto, @TiempoFab, @UsuarioAlta)";
                List<SqlParameter> parametrosFabricado = new List<SqlParameter>();
                SqlParameter parFidProd = new SqlParameter("@IdProducto", this.Id);
                SqlParameter parFtiempoFab = new SqlParameter("@TiempoFab", this.TiempoFab);
                SqlParameter parFusuAlta = new SqlParameter("@UsuarioAlta", this.UsuarioAlta);

                parametrosFabricado.Add(parFidProd);
                parametrosFabricado.Add(parFtiempoFab);
                parametrosFabricado.Add(parFusuAlta);
 
                EjecutarNoConsulta(con, sql, parametrosFabricado, CommandType.Text, tran);

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

                sql = "UPDATE Fabricado SET @IdProducto=IdProducto , @TiempoFab=TiempoFab , @UsuarioAlta=UsuarioAlta)";
                List<SqlParameter> parametrosFabricado = new List<SqlParameter>();
                SqlParameter parFidProd = new SqlParameter("@IdProducto", this.Id);
                SqlParameter parFtiempoFab = new SqlParameter("@descripcion", this.TiempoFab);
                SqlParameter parFusuAlta = new SqlParameter("@costo", this.UsuarioAlta);

                parametrosFabricado.Add(parFidProd);
                parametrosFabricado.Add(parFtiempoFab);
                parametrosFabricado.Add(parFusuAlta);

                EjecutarNoConsulta(con, sql, parametrosFabricado, CommandType.Text, tran);

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

        public List<Fabricado> TraerTodo()
        {
            List<Fabricado> fabricados = new List<Fabricado>();
            SqlConnection con = ObtenerConexion();
            string sql = "SELECT * FROM Fabricado INNER JOIN Producto ON Fabricado.IdProducto = Producto.IdProducto";
            SqlDataReader reader = null;
            try
            {
                reader = EjecutarConsulta(con, sql, null, CommandType.Text);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Fabricado fab = new Fabricado()
                        {
                            IdFabricado = Convert.ToInt32(reader["IdFabricado"]),
                            Id = Convert.ToInt32(reader["IdProducto"]),
                            tiempoFab = Convert.ToInt32(reader["tiepoFab"]),
                            usuarioAlta = Convert.ToInt32(reader["usuarioAlta"]),
                            Nombre = reader["Nombre"].ToString(),
                            Desc = reader["Descripcion"].ToString(),
                            Costo = Convert.ToInt32(reader["Costo"]),
                            // TO DO VER COMO CONVERIT MONEY DE SQL EN COSTO Y PRECIO SUGERIDO DE PRODUCTO
                            PrecioSugerido = Convert.ToInt32(reader["PrecioSugerido"]),
                            Descontinuado = Convert.ToBoolean(reader["Descontinuado"])
                        };
                        fabricados.Add(fab);
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
            return fabricados;
        }
        #endregion
    }
}