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
        private int id;

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

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        bool IActiveRecord<Empleado>.Borrar()
        {
            throw new NotImplementedException();
        }

        Empleado IActiveRecord<Empleado>.Buscar()
        {
            Empleado empleado = new Empleado (); 
            SqlConnection con = ObtenerConexion();
            string sql = "select * from Empleado where Email = @mail;";
            SqlParameter par = new SqlParameter("@mail", this.email);
            SqlDataReader reader = null;
            try
            {
                reader = EjecutarConsulta(con, sql, new List<SqlParameter>() { par }, CommandType.Text);

                if (reader.Read())
                {
                    empleado.nombre = reader["Nombre"].ToString();
                    empleado.contrasena = reader["Contrasena"].ToString();
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

        bool IActiveRecord<Empleado>.Crear()
        {
            bool ret = false;
            SqlConnection con = ObtenerConexion();
            try
            {
                string sql = "insert into Empleado(Nombre, Email, Contrasena) values(@nom, @mail, @contrasena)";
                List<SqlParameter> parametros = new List<SqlParameter>();
                SqlParameter parNom = new SqlParameter("@nom", this.nombre);
                SqlParameter parMail = new SqlParameter("@mail", this.email);
                SqlParameter parConstrasena = new SqlParameter("@constrasena", this.contrasena);
                parametros.Add(parNom);
                parametros.Add(parMail);
                parametros.Add(parConstrasena);
                con.Open();
                int afectadas = EjecutarNoConsulta(con, sql, parametros, CommandType.Text);
                if (afectadas > 0) ret = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Dispose();
                    Console.WriteLine("Cerrada");
                }
            }
            return ret;
        }


        bool IActiveRecord<Empleado>.Modificar()
        {
            throw new NotImplementedException();
        }

        List<Empleado> IActiveRecord<Empleado>.TraerTodo()
        {
            throw new NotImplementedException();
        }
    }
}