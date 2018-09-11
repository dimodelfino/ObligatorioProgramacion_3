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
        private int id;

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
                string sql = "UPDATE Funcionario SET DescTarea = @DescTarea, TiempoTarea =  WHERE Email = @email";
                    //"insert into Funcionario(DescTarea, TiempoTarea) values(@nom, @mail, @contrasena)";
                List<SqlParameter> parametros = new List<SqlParameter>();
                SqlParameter parDesc = new SqlParameter("@DescTarea", this.DescTarea);
                SqlParameter parMail = new SqlParameter("@mail", email);
                SqlParameter parTiempTarea = new SqlParameter("@TiempoTarea", this.TiempTarea);
                parametros.Add(parDesc);
                parametros.Add(parMail);
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