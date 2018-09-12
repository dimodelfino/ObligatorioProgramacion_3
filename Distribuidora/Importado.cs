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
        private string origen;
        private int cantImportacion;

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

        public bool Borrar()
        {            
            throw new NotImplementedException();
        }

        public Importado Buscar()
        {
            throw new NotImplementedException();
        }

        public bool Crear()
        {
            throw new NotImplementedException();
        }

        public bool Modificar()
        {
            throw new NotImplementedException();
        }

        public List<Importado> TraerTodo()
        {
            throw new NotImplementedException();
        }
    }
}