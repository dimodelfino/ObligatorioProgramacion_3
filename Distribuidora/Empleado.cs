using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Distribuidora
{
    public class Empleado : Persistente, IActiveRecord<Empleado>
    {
        private string nombre;
        private string email;
        private string contrasena;
        private int idEmpleado;
        private bool activo;

        #region Properties
        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public bool Activo
        {
            get
            {
                return activo;
            }

            set
            {
                activo = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Contrasena
        {
            get
            {
                return contrasena;
            }

            set
            {
                contrasena = value;
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
        #endregion

        #region Metodos
        public bool Borrar()
        {
            bool ret = false;
            SqlConnection con = ObtenerConexion();
            try
            {
                string sql = "UPDATE Funcionario SET Activo=0 where Email=@email;";
                List<SqlParameter> parametros = new List<SqlParameter>();
                SqlParameter parMail = new SqlParameter("@mail", this.email);
                parametros.Add(parMail);
                con.Open();
                int afectadas = EjecutarNoConsulta(con, sql, parametros, CommandType.Text);
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

        public Empleado Buscar()
        {
            Empleado empleado = new Empleado();
            SqlConnection con = ObtenerConexion();
            string sql = "SELECT IdFuncionario, Nombre, Contrasena, Email FROM Funcionario WHERE Email = @mail AND Activo=1;";
            SqlParameter par = new SqlParameter("@mail", this.email);
            SqlDataReader reader = null;
            try
            {
                reader = EjecutarConsulta(con, sql, new List<SqlParameter>() { par }, CommandType.Text);

                if (reader.Read())
                {
                    empleado.nombre = reader["Nombre"].ToString();
                    empleado.contrasena = reader["Contrasena"].ToString();
                    empleado.IdEmpleado = Convert.ToInt32(reader["IdFuncionario"]);
                    empleado.Activo = true;
                    empleado.email = this.email;
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

            return empleado;
        }

        public bool Crear()
        {
            bool ret = false;
            SqlConnection con = ObtenerConexion();
            try
            {
                string sql = "INSERT INTO Funcionario(Nombre, Email, Contrasena, Activo, Tipo) VALUES(@nom, @mail, @contrasena, 1, 'E')";
                List<SqlParameter> parametros = new List<SqlParameter>();
                SqlParameter parNom = new SqlParameter("@nom", this.nombre);
                SqlParameter parMail = new SqlParameter("@mail", this.email);
                SqlParameter parConstrasena = new SqlParameter("@contrasena", this.contrasena);
                parametros.Add(parNom);
                parametros.Add(parMail);
                parametros.Add(parConstrasena);
                con.Open();
                int afectadas = EjecutarNoConsulta(con, sql, parametros, CommandType.Text);
                if (afectadas > 0) ret = true;
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

        public bool Modificar()
        {
            bool ret = false;
            SqlConnection con = ObtenerConexion();
            try
            {
                string sql = "UPDATE Funcionaro set Email=@email, Nombre=@nombre, Contrasena=@contrasena where Email=@email;";
                List<SqlParameter> parametros = new List<SqlParameter>();
                SqlParameter parNombre = new SqlParameter("@nombre", this.nombre);
                SqlParameter parContrasena = new SqlParameter("@contrasena", this.contrasena);
                SqlParameter parMail = new SqlParameter("@email", this.email);
                parametros.Add(parNombre);
                parametros.Add(parContrasena);
                parametros.Add(parMail);
                con.Open();
                int afectadas = EjecutarNoConsulta(con, sql, parametros, CommandType.Text);
                if (afectadas > 0) ret = true;
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

        public List<Empleado> TraerTodo()
        {
            List<Empleado> personas = new List<Empleado>();
            SqlConnection con = ObtenerConexion();
            string sql = "SELECT Nombre, Contrasena, Email, IdFuncionario FROM Funcionario WHERE Activo=1 AND Tipo = 'E'";
            SqlDataReader reader = null;
            try
            {
                reader = EjecutarConsulta(con, sql, null, CommandType.Text);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Empleado emp = new Empleado()
                        {
                            Nombre = reader["Nombre"].ToString(),
                            Contrasena = reader["Contrasena"].ToString(),
                            Email = reader["Email"].ToString(),
                            IdEmpleado = Convert.ToInt32(reader["IdFuncionario"])
                        };
                        personas.Add(emp);
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
            return personas;
        }
        #endregion
    }
}