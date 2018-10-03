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
        public bool agregarProductoFabricado(string nombreProd, string descProd, double costoProd, double precioSugeridoProd, int tiempoFabProd, int idAltaEmpleado)
        {
           return Fachada.CrearProductoFabricado(nombreProd, descProd, costoProd, precioSugeridoProd, tiempoFabProd, idAltaEmpleado);            
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
            return Fachada.CrearEmpleado(nombre, email, contrasena, tipo);
        }

        public bool asignarTecnico(List<Tecnico> tecnicos)
        {
            bool ret = false;
            if (tecnicos != null)
            {
                foreach (Tecnico tec in tecnicos)
                {
                    if (tec != null)
                    {
                        tec.Crear();
                    }
                }
                ret = true;
            }
            return ret;
        }

        public IEnumerable<DtoFabricado> mostrarTodosFabricados()
        {
            List<Fabricado> fabricados = Fachada.TraerTodoProdFabricado();
            List<DtoFabricado> retorno = new List<DtoFabricado>();
            foreach (Fabricado fab in fabricados)
            {
                retorno.Add(
                    new DtoFabricado
                    {
                        Id = fab.Id,
                        Nombre = fab.Nombre,
                        desc = fab.Desc,
                        costo = fab.Costo,
                        precioSugerido = fab.PrecioSugerido,
                        descontinuado = fab.Descontinuado,
                        tiempoFab = fab.TiempoFab,
                        usuarioAlta = fab.UsuarioAlta,
                        idFabricado = fab.IdFabricado,
                        tiempoRestante = fab.TiempoRestante
                    });
            }

            return retorno;
        }

        public bool GenerarReporteTxtProductos()
        {
            return Fachada.TxtReport();
        }

        public IEnumerable<DtoImportado> mostrarTodosImportado()
        {

            List<Importado> importados = Fachada.TraerTodoProdImportado();
            List<DtoImportado> retorno = new List<DtoImportado>();
            foreach (Importado imp in importados)
            {
                retorno.Add(
                    new DtoImportado
                    {
                        Id = imp.Id,
                        Nombre = imp.Nombre,
                        desc = imp.Desc,
                        costo = imp.Costo,
                        precioSugerido = imp.PrecioSugerido,
                        descontinuado = imp.Descontinuado,
                        idImportado = imp.IdImportado,
                        origen = imp.Origen,
                        cantImportacion = imp.CantImportacion                        
                    });
            }

            return retorno;           
        }       
    }
}
