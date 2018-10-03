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
    public class DtoImportado
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
        public int idImportado { get; set; }
        [DataMember]
        public string origen { get; set; }
        [DataMember]
        public int cantImportacion { get; set; }
    }
}