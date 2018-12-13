using Distribuidora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioDistribuidora
{
    [ServiceContract]
    public interface IDistribuidoraWCF
    {
        [OperationContract]
        bool agregarProductoFabricado(string nombreProd, string descProd, double costoProd, double precioSugeridoProd, int tiempoFabProd, int idAltaEmpleado, int garantiaAnios);

        [OperationContract]
        bool agregarProductoImportado(string nombre, string descripcion, double costo, double precioSugerido, bool descontinuado, string origen, int cantImportacion);

        [OperationContract]
        bool asignarTecnico(List<Tecnico>tecnicos);

        [OperationContract]
        IEnumerable<DtoFabricado> mostrarTodosFabricados();

        [OperationContract]
        bool altaEmpleado(string nombre, string contrasena, string email, bool tipo);

        [OperationContract]
        IEnumerable<DtoImportado> mostrarTodosImportado();

        [OperationContract] 
        bool GenerarReporteTxtProductos();
    }   
    
     
}
