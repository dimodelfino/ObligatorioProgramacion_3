using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Distribuidora
{
    public abstract class Producto : Persistente, IActiveRecord<Producto>
    {
        private int id;
        private string nombre;
        private string desc;
        private double costo;
        private double precioSugerido;
        private bool descontinuado;

        #region Properties 
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

        public string Desc
        {
            get
            {
                return desc;
            }

            set
            {
                desc = value;
            }
        }

        public double Costo
        {
            get
            {
                return costo;
            }

            set
            {
                costo = value;
            }
        }

        public double PrecioSugerido
        {
            get
            {
                return precioSugerido;
            }

            set
            {
                precioSugerido = value;
            }
        }

        public bool Descontinuado
        {
            get
            {
                return descontinuado;
            }

            set
            {
                descontinuado = value;
            }
        }
        #endregion

        #region Metodos
        public abstract bool Borrar();

        public Producto Buscar() {

            throw new NotImplementedException();
        }

        public abstract bool Crear();

        public abstract bool Modificar();

        public List<Producto> TraerTodo() {

            throw new NotImplementedException();
        }
        #endregion

    }
}