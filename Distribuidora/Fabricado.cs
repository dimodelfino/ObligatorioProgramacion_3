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

        public bool Borrar()
        {
            throw new NotImplementedException();
        }

        public Fabricado Buscar()
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

        public List<Fabricado> TraerTodo()
        {
            throw new NotImplementedException();
        }
    }
}