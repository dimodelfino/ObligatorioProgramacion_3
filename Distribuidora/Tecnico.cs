using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Distribuidora
{
    public class Tecnico : Persistente, IActiveRecord<Tecnico>
    {
        private string descTarea;
        private int tiempTarea;
        private int idProducto;
        private int idEmpleado;
        private int idFabricado;

        #region Properties
        public string DescTarea
        {
            get
            {
                return descTarea;
            }

            set
            {
                descTarea = value;
            }
        }

        public int TiempTarea
        {
            get
            {
                return tiempTarea;
            }

            set
            {
                tiempTarea = value;
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

        public int IdEmpleado
        {
            get
            {
                return idEmpleado;
            }

            set
            {
                idEmpleado = value;
            }
        }

        public int IdProducto
        {
            get
            {
                return idProducto;
            }

            set
            {
                idProducto = value;
            }
        }
        #endregion

        #region Metodos
        public bool Borrar()
        {
            bool ret = false;
            SqlConnection con = ObtenerConexion();
            SqlTransaction tran = null;
            try
            {
                string sql = "DELETE from FabricadoFuncionario where idFabricado=@idFabricado and idProdructo=@idProdructo and idFuncionario=@idFuncionario;";
                List<SqlParameter> parametros = new List<SqlParameter>();
                SqlParameter parIdFabricado = new SqlParameter("@idFabricado", this.idFabricado);
                SqlParameter parIdProducto = new SqlParameter("@idProducto", this.idProducto);
                SqlParameter parIdFuncionario = new SqlParameter("@idFuncionario", this.idEmpleado);
                parametros.Add(parIdFabricado);
                parametros.Add(parIdProducto);
                parametros.Add(parIdFuncionario);
                con.Open();
                tran = con.BeginTransaction();
                int afectadas = EjecutarNoConsulta(con, sql, parametros, CommandType.Text, tran);
                tran.Commit();
                if (afectadas > 0)
                {
                    ret = true;
                }
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

        public Tecnico Buscar()
        {
            Tecnico tec = null;
            SqlConnection con = ObtenerConexion();
            string sql = "SELECT * FROM FabricadoFuncionario WHERE idFabricado=@idFabricado AND idProducto=@idPRoducto AND idFuncionario=@idFuncionario";
            List <SqlParameter> parametros = new List <SqlParameter>();
            SqlParameter parIdFabricado = new SqlParameter("@idFabricado", this.idFabricado);
            SqlParameter parIdProducto = new SqlParameter("@idProducto", this.idProducto);
            SqlParameter parIdFuncionario = new SqlParameter("@idFuncionario", this.idEmpleado);
            parametros.Add(parIdFabricado);
            parametros.Add(parIdProducto);
            parametros.Add(parIdFuncionario);            
            con.Open();
            SqlDataReader reader = null;
            try
            {
                reader = EjecutarConsulta(con, sql, parametros, CommandType.Text);

                if (reader.Read())
                {
                    tec = new Tecnico();
                    tec.idProducto = Convert.ToInt32(reader["IdProducto"]);
                    tec.idEmpleado = Convert.ToInt32(reader["IdFuncionario"]);
                    tec.IdFabricado = Convert.ToInt32(reader["IdFabricado"]);
                    tec.descTarea = reader["DescTarea"].ToString();
                    tec.tiempTarea = Convert.ToInt32(reader["TiempoTarea"]);
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

            return tec;
        }

        public bool Crear()
        {
            bool ret = false;
            SqlConnection con = ObtenerConexion();
            SqlTransaction tran = null;
            try
            {
                string sql = "INSERT INTO FabricadoFuncionario VALUES( @idFabricado, @idProducto, @idFuncionario, @descTarea, @tiempoTarea)";
                List<SqlParameter> parametros = new List<SqlParameter>();
                SqlParameter parIdFabricado = new SqlParameter("@idFabricado", this.idFabricado);
                SqlParameter parIdProducto = new SqlParameter("@idProducto", this.idProducto);
                SqlParameter parIdFuncionario = new SqlParameter("@idFuncionario", this.idEmpleado);
                SqlParameter parDescTarea = new SqlParameter("@DescTarea", this.DescTarea);
                SqlParameter parTiempTarea = new SqlParameter("@TiempoTarea", this.TiempTarea);
                parametros.Add(parIdFabricado);
                parametros.Add(parIdProducto);
                parametros.Add(parIdFuncionario);
                parametros.Add(parDescTarea);
                parametros.Add(parTiempTarea);
                con.Open();
                tran = con.BeginTransaction();
                int afectadas = EjecutarNoConsulta(con, sql, parametros, CommandType.Text, tran);
                tran.Commit();
                if (afectadas > 0)
                {
                    ret = true;
                }
            }
            catch
            {
                if (tran != null) {
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

        public bool Modificar()
        {
            bool ret = false;
            SqlConnection con = ObtenerConexion();
            SqlTransaction tran = null;
            try
            {
                string sql = "UPDATE FabricadoFuncionario SET DescTarea=@descTarea, TiempoTarea=@tiempoTarea WHERE idFabricado=@idFabricado, idProducto=@idProducto, idFuncionario=@idFuncionario; ";
                List<SqlParameter> parametros = new List<SqlParameter>();
                SqlParameter parIdFabricado = new SqlParameter("@idFabricado", this.idFabricado);
                SqlParameter parIdProducto = new SqlParameter("@idProducto", this.idProducto);
                SqlParameter parIdFuncionario = new SqlParameter("@idFuncionario", this.idEmpleado);
                SqlParameter DescTarea = new SqlParameter("@descTarea", this.descTarea);
                SqlParameter TiempoTarea = new SqlParameter("@tiempoTarea", this.tiempTarea);
                parametros.Add(parIdFabricado);
                parametros.Add(parIdProducto);
                parametros.Add(parIdFuncionario);
                parametros.Add(DescTarea);
                parametros.Add(TiempoTarea);
                con.Open();
                tran = con.BeginTransaction();
                int afectadas = EjecutarNoConsulta(con, sql, parametros, CommandType.Text, tran);
                tran.Commit();
                if (afectadas > 0) {
                    ret = true;
                }
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

        public List<Tecnico> TraerTodo()
        {
            List<Tecnico> tecnicos = new List<Tecnico>();
            SqlConnection con = ObtenerConexion();
            string sql = "SELECT * FROM FabricadoFuncionario";
            SqlDataReader reader = null;
            try
            {
                reader = EjecutarConsulta(con, sql, null, CommandType.Text);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Tecnico tec = new Tecnico()
                        {
                            IdEmpleado = Convert.ToInt32(reader["IdFuncionario"]),
                            IdFabricado = Convert.ToInt32(reader["IdFabricado"]),
                            IdProducto = Convert.ToInt32(reader["IdProducto"]),
                            descTarea = reader["DescTarea"].ToString(),
                            TiempTarea = Convert.ToInt32(reader["TiempoTarea"])                           
                        };
                        tecnicos.Add(tec);
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (reader != null) reader.Close();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return tecnicos;
        }
        #endregion

    }
}