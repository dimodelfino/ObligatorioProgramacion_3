using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Distribuidora;

namespace ServicioDistribuidora
{
    public class DistribuidoraWCF : IDistribuidoraWCF
    {
        public bool agregarProductoFabricado(string nombre, string descripcion, double costo, double precioSugerido, bool descontinuado, int tiempoFab, int usuarioAlta)
        {
            bool ret = false;
            Fabricado prodF = new Fabricado()
            {
                Nombre = nombre,
                Desc = descripcion,
                Costo = costo,
                PrecioSugerido = precioSugerido,
                Descontinuado = descontinuado,
                TiempoFab = tiempoFab,
                UsuarioAlta = usuarioAlta,
            };
            if (prodF.Crear()) {
                ret = true;
            }
            return ret;
        }

        public bool agregarProductoImportado(string nombre, string descripcion, double costo, double precioSugerido, bool descontinuado, string origen, int cantImportacion)
        {
            bool ret = false;
            Importado prodI = new Importado()
            {
                Nombre = nombre,
                Desc = descripcion,
                Costo = costo,
                PrecioSugerido = precioSugerido,
                Descontinuado = descontinuado,
                Origen = origen,
                CantImportacion = cantImportacion,
            };
            if (prodI.Crear())
            {
                ret = true;
            }
            return ret;
        }

        public bool altaEmpleado(string nombre, string contrasena, string email, bool tipo)
        {
            Empleado emp = new Empleado()
            {
                Nombre = nombre,
                Contrasena = contrasena,
                Email = email,
                Tecnico = tipo,
            };
            return emp.Crear();
        }

        public bool asignarTecnico(List<Tecnico> tecnicos)
        {
            bool ret = false; 
            if (tecnicos != null) {
                foreach (Tecnico tec in tecnicos) {
                    if (tec != null)
                    {
                        tec.Crear();
                    }
                }
                ret = true;
            }
            return ret;
        }

        public List<Fabricado> mostrarTodosFabricados()
        {
            Fabricado fab = new Fabricado ();
            List<Fabricado> fabricados = new List<Fabricado>();
            fabricados = fab.TraerTodo();
            return fabricados;
        }

        public List<Importado> mostrarTodosImportado()
        {
            Importado imp = new Importado();
            List<Importado> importados = new List<Importado>();
            importados = imp.TraerTodo();
            return importados;
        }
    }
}
