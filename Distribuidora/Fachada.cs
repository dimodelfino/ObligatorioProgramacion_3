using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Distribuidora
{
    public class Fachada
    {
        #region Empleado
        public static Empleado BuscarEmpleado(string email)
        {            
            Empleado emp = new Empleado()
            {
                Email = email
            };
            return emp.Buscar();
        }

        public static bool CrearEmpleado(string nombre, string email, string contrasena, bool tipo)
        {
            bool result = false;
            Empleado emp = new Empleado()
            {
                Nombre = nombre,
                Email = email,
                Contrasena = contrasena,
                Activo = true,
                Tipo = "E"
            };
            if (tipo) emp.Tipo = "T";
            if (emp.Crear()) result = true;
            return result;
        }
        #endregion

        #region Tecnico
        public static List<Empleado> TraerTodoTecnicos()
        {
            Empleado emp = new Empleado();
            return emp.TraerTodoTecnicos();
        }

        public static Tecnico BuscarTecnico(int idProd, int idEmp, int idFab)
        {
            Tecnico tec = new Tecnico()
            {
                IdProducto = idProd,
                IdEmpleado = idEmp,
                IdFabricado = idFab
            };
            return tec.Buscar();
        }

        public static bool CrearTecnico(int idProd, int idEmp, int idFab, string descTarea, int tiempoEstimadoRealizacion)
        {
            Tecnico tec = new Tecnico()
            {
                IdProducto = idProd,
                IdEmpleado = idEmp,
                IdFabricado = idFab,
                DescTarea = descTarea,
                TiempTarea = tiempoEstimadoRealizacion
        };
            return tec.Crear();
        }
        #endregion

        #region Producto

        public static bool CrearProductoFabricado(string nombreProd, string descProd, double costoProd, double precioSugeridoProd, int tiempoFabProd, int idAltaEmpleado)
        {

            Fabricado fab = new Fabricado()
            {
                Nombre = nombreProd,
                Desc = descProd,
                Costo = costoProd,
                PrecioSugerido = precioSugeridoProd,
                Descontinuado = false,
                TiempoFab = tiempoFabProd,                
                UsuarioAlta = idAltaEmpleado
            };
            return fab.Crear();
        }

        public static bool CrearProductoImportado(string nombreProd, string descProd, double costoProd, double precioSugeridoProd, string origenImportado, int cantMinImport)
        {
            Importado imp = new Importado()
            {
                Nombre = nombreProd,
                Desc = descProd,
                Costo = costoProd,
                PrecioSugerido = precioSugeridoProd,
                Descontinuado = false,
                Origen = origenImportado,
                CantImportacion = cantMinImport
            };
            return imp.Crear();
        }

        public static bool ExisteProducto(string nombreProd)
        {
            bool result = false;
            Fabricado fab = new Fabricado()
            {
                Nombre = nombreProd
            };
            Importado imp = new Importado()
            {
                Nombre = nombreProd
            };
            if (fab.BuscarPorNombre() != null || imp.BuscarPorNombre() != null ) result = true;
            return result;
        }

        public static List<Fabricado> TraerTodoProdFabricado()
        {
            Fabricado fab = new Fabricado();
            return fab.TraerTodo();
        }

        public static List<Importado> TraerTodoProdImportado()
        {
            Importado imp = new Importado();
            return imp.TraerTodo();
        }

        public static bool TxtReport()
        {
            Importado imp = new Importado();
            Fabricado fab = new Fabricado();
            TxtHandler report = new TxtHandler();
            return (report.TxtProductos(imp.TraerTodo(), fab.TraerTodo()));
        }

        #endregion

    }
}