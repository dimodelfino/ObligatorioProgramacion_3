using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Distribuidora
{
    public class Tecnico : Empleado, IActiveRecord<Tecnico>
    {
        private string descTarea;
        private int tempTarea;        

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
                return tempTarea;
            }

            set
            {
                tempTarea = value;
            }
        }        

        public bool Borrar()
        {
            throw new NotImplementedException();
        }

        public Tecnico Buscar()
        {
            throw new NotImplementedException();
        }

        public bool Crear(string email)
        {            
            bool ret = false;
            SqlConnection con = ObtenerConexion();
            try
            {
                string sql = "INSERT INTO Funcionario VALUES(@nom, @contrasena, @mail, @descTarea, @tiempoTarea)";                    
                List<SqlParameter> parametros = new List<SqlParameter>();
                SqlParameter parNom = new SqlParameter("@nom", this.Nombre);
                SqlParameter parPass = new SqlParameter("@contrasena", this.Contrasena);
                SqlParameter parMail = new SqlParameter("@mail", email);
                SqlParameter parDesc = new SqlParameter("@DescTarea", this.DescTarea);                
                SqlParameter parTiempTarea = new SqlParameter("@TiempoTarea", this.TiempTarea);
                parametros.Add(parNom);
                parametros.Add(parPass);
                parametros.Add(parMail);                
                parametros.Add(parDesc);                
                parametros.Add(parTiempTarea);
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
            throw new NotImplementedException();
        }

        public List<Tecnico> TraerTodo()
        {
            throw new NotImplementedException();
        }
    }
}