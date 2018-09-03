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

        bool IActiveRecord<Importado>.Borrar()
        {
            throw new NotImplementedException();
        }

        Importado IActiveRecord<Importado>.Buscar()
        {
            throw new NotImplementedException();
        }

        bool IActiveRecord<Importado>.Crear()
        {
            throw new NotImplementedException();
        }

        bool IActiveRecord<Importado>.Modificar()
        {
            throw new NotImplementedException();
        }

        List<Importado> IActiveRecord<Importado>.TraerTodo()
        {
            throw new NotImplementedException();
        }
    }
}