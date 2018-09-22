﻿using System;
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
        private int tempTarea;
        private int idProducto;
        private int idEmpleado;

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
                return tempTarea;
            }

            set
            {
                tempTarea = value;
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
                string sql = "UPDATE Funcionario SET Activo=0 where Email=@email;";
                List<SqlParameter> parametros = new List<SqlParameter>();
                SqlParameter parMail = new SqlParameter("@mail", this.Email);
                parametros.Add(parMail);
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

        public Tecnico Buscar()
        {
            Tecnico tec = new Tecnico();
            SqlConnection con = ObtenerConexion();
            string sql = "SELECT * FROM Funcionario WHERE Email = @mail AND Activo=1;";
            SqlParameter par = new SqlParameter("@mail", this.Email);
            SqlDataReader reader = null;
            try
            {
                reader = EjecutarConsulta(con, sql, new List<SqlParameter>() { par }, CommandType.Text);

                if (reader.Read())
                {
                    tec.Nombre = reader["Nombre"].ToString();
                    tec.Contrasena = reader["Contrasena"].ToString();                   
                    tec.IdEmpleado = Convert.ToInt32(reader["IdFuncionario"]);
                    tec.Activo = Convert.ToBoolean(reader["Activo"]);
                    tec.Email = this.Email;
                    tec.descTarea = reader["DescTarea"].ToString();
                    tec.tempTarea = Convert.ToInt32(reader["TiempoTarea"]);
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
                string sql = "INSERT INTO Funcionario VALUES(@nom, @contrasena, @mail, @descTarea, @tiempoTarea, 1, 'T')";                    
                List<SqlParameter> parametros = new List<SqlParameter>();
                SqlParameter parNom = new SqlParameter("@nom", this.Nombre);
                SqlParameter parPass = new SqlParameter("@contrasena", this.Contrasena);
                SqlParameter parMail = new SqlParameter("@mail", this.Email);
                SqlParameter parDesc = new SqlParameter("@DescTarea", this.DescTarea);                
                SqlParameter parTiempTarea = new SqlParameter("@TiempoTarea", this.TiempTarea);
                parametros.Add(parNom);
                parametros.Add(parPass);
                parametros.Add(parMail);                
                parametros.Add(parDesc);                
                parametros.Add(parTiempTarea);
                con.Open();
                tran = con.BeginTransaction();
                int afectadas = EjecutarNoConsulta(con, sql, parametros, CommandType.Text, tran);
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
            SqlTransaction tran = null;
            try
            {
                string sql = "UPDATE Funcionario SET Email=@email, Nombre=@nombre, Contrasena=@contrasena, DescTarea=@descTarea, TiempoTarea=@tiempoTarea WHERE Email=@email;";
                List<SqlParameter> parametros = new List<SqlParameter>();
                SqlParameter parNombre = new SqlParameter("@nombre", this.Nombre);
                SqlParameter parContrasena = new SqlParameter("@contrasena", this.Contrasena);
                SqlParameter parMail = new SqlParameter("@email", this.Email);
                SqlParameter DescTarea = new SqlParameter("@descTarea", this.descTarea);
                SqlParameter TiempoTarea = new SqlParameter("@tiempoTarea", this.tempTarea);
                parametros.Add(parNombre);
                parametros.Add(parContrasena);
                parametros.Add(parMail);
                parametros.Add(DescTarea);
                parametros.Add(TiempoTarea);
                con.Open();
                tran = con.BeginTransaction();
                int afectadas = EjecutarNoConsulta(con, sql, parametros, CommandType.Text, tran);
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

        public List<Tecnico> TraerTodo()
        {
            List<Tecnico> tecnicos = new List<Tecnico>();
            SqlConnection con = ObtenerConexion();
            string sql = "SELECT * FROM Funcionario WHERE Activo=1 AND Tipo = 'T'";
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
                            Nombre = reader["Nombre"].ToString(),
                            Contrasena = reader["Contrasena"].ToString(),
                            Email = reader["Email"].ToString(),
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