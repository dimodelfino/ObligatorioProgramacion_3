using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Distribuidora
{
    public class Tecnico : IActiveRecord<Tecnico>
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

        public int TempTarea
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

        bool IActiveRecord<Tecnico>.Borrar()
        {
            throw new NotImplementedException();
        }

        Tecnico IActiveRecord<Tecnico>.Buscar()
        {
            throw new NotImplementedException();
        }

        bool IActiveRecord<Tecnico>.Crear()
        {
            throw new NotImplementedException();
        }

        bool IActiveRecord<Tecnico>.Modificar()
        {
            throw new NotImplementedException();
        }

        List<Tecnico> IActiveRecord<Tecnico>.TraerTodo()
        {
            throw new NotImplementedException();
        }
    }
}