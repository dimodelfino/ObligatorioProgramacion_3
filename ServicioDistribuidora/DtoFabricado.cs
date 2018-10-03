using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ServicioDistribuidora
{
    [DataContract]
    public class DtoFabricado
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string desc { get; set; }
        [DataMember]
        public double costo { get; set; }
        [DataMember]
        public double precioSugerido { get; set; }
        [DataMember]
        public bool descontinuado { get; set; }
        [DataMember]
        public int tiempoFab { get; set; }
        [DataMember]
        public int usuarioAlta { get; set; }
        [DataMember]
        public int idFabricado { get; set; }        
        //[DataMember]
        //private List<Tecnico> tecnicos = new List<Tecnico>() { get; set; }
        [DataMember]
        public int tiempoRestante { get; set; }


    }
}