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
        bool agregarProductoFabricado(string nombre, string descripcion, double costo, double precioSugerido, bool descontinuado, int tiempoFab, int usuarioAlta);

        [OperationContract]
        bool agregarProductoImportado(string nombre, string descripcion, double costo, double precioSugerido, bool descontinuado, string origen, int cantImportacion);

        [OperationContract]
        bool asignarTecnico(List<Tecnico>tecnicos);

        [OperationContract]
        List<Fabricado> mostrarTodosFabricados();

        [OperationContract]
        bool altaEmpleado(string nombre, string contrasena, string email, bool tipo);

        [OperationContract]
        List<Importado> mostrarTodosImportado();
    }    
}
