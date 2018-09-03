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
        private string usuarioAlta;
        private List<Tecnico> tecnicos;

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

        public string UsuarioAlta
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

        bool IActiveRecord<Fabricado>.Borrar()
        {
            throw new NotImplementedException();
        }

        Fabricado IActiveRecord<Fabricado>.Buscar()
        {
            throw new NotImplementedException();
        }

        bool IActiveRecord<Fabricado>.Crear()
        {
            throw new NotImplementedException();
        }

        bool IActiveRecord<Fabricado>.Modificar()
        {
            throw new NotImplementedException();
        }

        List<Fabricado> IActiveRecord<Fabricado>.TraerTodo()
        {
            throw new NotImplementedException();
        }
    }
}