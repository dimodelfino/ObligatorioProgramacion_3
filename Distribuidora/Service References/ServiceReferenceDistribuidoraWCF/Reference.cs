﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Distribuidora.ServiceReferenceDistribuidoraWCF {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Tecnico", Namespace="http://schemas.datacontract.org/2004/07/Distribuidora")]
    [System.SerializableAttribute()]
    public partial class Tecnico : Distribuidora.ServiceReferenceDistribuidoraWCF.Persistente {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescTareaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdEmpleadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdFabricadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdProductoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TiempTareaField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DescTarea {
            get {
                return this.DescTareaField;
            }
            set {
                if ((object.ReferenceEquals(this.DescTareaField, value) != true)) {
                    this.DescTareaField = value;
                    this.RaisePropertyChanged("DescTarea");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdEmpleado {
            get {
                return this.IdEmpleadoField;
            }
            set {
                if ((this.IdEmpleadoField.Equals(value) != true)) {
                    this.IdEmpleadoField = value;
                    this.RaisePropertyChanged("IdEmpleado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdFabricado {
            get {
                return this.IdFabricadoField;
            }
            set {
                if ((this.IdFabricadoField.Equals(value) != true)) {
                    this.IdFabricadoField = value;
                    this.RaisePropertyChanged("IdFabricado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdProducto {
            get {
                return this.IdProductoField;
            }
            set {
                if ((this.IdProductoField.Equals(value) != true)) {
                    this.IdProductoField = value;
                    this.RaisePropertyChanged("IdProducto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TiempTarea {
            get {
                return this.TiempTareaField;
            }
            set {
                if ((this.TiempTareaField.Equals(value) != true)) {
                    this.TiempTareaField = value;
                    this.RaisePropertyChanged("TiempTarea");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Persistente", Namespace="http://schemas.datacontract.org/2004/07/Distribuidora")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Distribuidora.ServiceReferenceDistribuidoraWCF.Tecnico))]
    public partial class Persistente : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DtoFabricado", Namespace="http://schemas.datacontract.org/2004/07/ServicioDistribuidora")]
    [System.SerializableAttribute()]
    public partial class DtoFabricado : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double costoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string descField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool descontinuadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idFabricadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double precioSugeridoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int tiempoFabField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int tiempoRestanteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int usuarioAltaField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double costo {
            get {
                return this.costoField;
            }
            set {
                if ((this.costoField.Equals(value) != true)) {
                    this.costoField = value;
                    this.RaisePropertyChanged("costo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string desc {
            get {
                return this.descField;
            }
            set {
                if ((object.ReferenceEquals(this.descField, value) != true)) {
                    this.descField = value;
                    this.RaisePropertyChanged("desc");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool descontinuado {
            get {
                return this.descontinuadoField;
            }
            set {
                if ((this.descontinuadoField.Equals(value) != true)) {
                    this.descontinuadoField = value;
                    this.RaisePropertyChanged("descontinuado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idFabricado {
            get {
                return this.idFabricadoField;
            }
            set {
                if ((this.idFabricadoField.Equals(value) != true)) {
                    this.idFabricadoField = value;
                    this.RaisePropertyChanged("idFabricado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double precioSugerido {
            get {
                return this.precioSugeridoField;
            }
            set {
                if ((this.precioSugeridoField.Equals(value) != true)) {
                    this.precioSugeridoField = value;
                    this.RaisePropertyChanged("precioSugerido");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int tiempoFab {
            get {
                return this.tiempoFabField;
            }
            set {
                if ((this.tiempoFabField.Equals(value) != true)) {
                    this.tiempoFabField = value;
                    this.RaisePropertyChanged("tiempoFab");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int tiempoRestante {
            get {
                return this.tiempoRestanteField;
            }
            set {
                if ((this.tiempoRestanteField.Equals(value) != true)) {
                    this.tiempoRestanteField = value;
                    this.RaisePropertyChanged("tiempoRestante");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int usuarioAlta {
            get {
                return this.usuarioAltaField;
            }
            set {
                if ((this.usuarioAltaField.Equals(value) != true)) {
                    this.usuarioAltaField = value;
                    this.RaisePropertyChanged("usuarioAlta");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DtoImportado", Namespace="http://schemas.datacontract.org/2004/07/ServicioDistribuidora")]
    [System.SerializableAttribute()]
    public partial class DtoImportado : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int cantImportacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double costoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string descField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool descontinuadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idImportadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string origenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double precioSugeridoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int cantImportacion {
            get {
                return this.cantImportacionField;
            }
            set {
                if ((this.cantImportacionField.Equals(value) != true)) {
                    this.cantImportacionField = value;
                    this.RaisePropertyChanged("cantImportacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double costo {
            get {
                return this.costoField;
            }
            set {
                if ((this.costoField.Equals(value) != true)) {
                    this.costoField = value;
                    this.RaisePropertyChanged("costo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string desc {
            get {
                return this.descField;
            }
            set {
                if ((object.ReferenceEquals(this.descField, value) != true)) {
                    this.descField = value;
                    this.RaisePropertyChanged("desc");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool descontinuado {
            get {
                return this.descontinuadoField;
            }
            set {
                if ((this.descontinuadoField.Equals(value) != true)) {
                    this.descontinuadoField = value;
                    this.RaisePropertyChanged("descontinuado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idImportado {
            get {
                return this.idImportadoField;
            }
            set {
                if ((this.idImportadoField.Equals(value) != true)) {
                    this.idImportadoField = value;
                    this.RaisePropertyChanged("idImportado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string origen {
            get {
                return this.origenField;
            }
            set {
                if ((object.ReferenceEquals(this.origenField, value) != true)) {
                    this.origenField = value;
                    this.RaisePropertyChanged("origen");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double precioSugerido {
            get {
                return this.precioSugeridoField;
            }
            set {
                if ((this.precioSugeridoField.Equals(value) != true)) {
                    this.precioSugeridoField = value;
                    this.RaisePropertyChanged("precioSugerido");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceDistribuidoraWCF.IDistribuidoraWCF")]
    public interface IDistribuidoraWCF {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistribuidoraWCF/agregarProductoFabricado", ReplyAction="http://tempuri.org/IDistribuidoraWCF/agregarProductoFabricadoResponse")]
        bool agregarProductoFabricado(string nombreProd, string descProd, double costoProd, double precioSugeridoProd, int tiempoFabProd, int idAltaEmpleado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistribuidoraWCF/agregarProductoFabricado", ReplyAction="http://tempuri.org/IDistribuidoraWCF/agregarProductoFabricadoResponse")]
        System.Threading.Tasks.Task<bool> agregarProductoFabricadoAsync(string nombreProd, string descProd, double costoProd, double precioSugeridoProd, int tiempoFabProd, int idAltaEmpleado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistribuidoraWCF/agregarProductoImportado", ReplyAction="http://tempuri.org/IDistribuidoraWCF/agregarProductoImportadoResponse")]
        bool agregarProductoImportado(string nombre, string descripcion, double costo, double precioSugerido, bool descontinuado, string origen, int cantImportacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistribuidoraWCF/agregarProductoImportado", ReplyAction="http://tempuri.org/IDistribuidoraWCF/agregarProductoImportadoResponse")]
        System.Threading.Tasks.Task<bool> agregarProductoImportadoAsync(string nombre, string descripcion, double costo, double precioSugerido, bool descontinuado, string origen, int cantImportacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistribuidoraWCF/asignarTecnico", ReplyAction="http://tempuri.org/IDistribuidoraWCF/asignarTecnicoResponse")]
        bool asignarTecnico(Distribuidora.ServiceReferenceDistribuidoraWCF.Tecnico[] tecnicos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistribuidoraWCF/asignarTecnico", ReplyAction="http://tempuri.org/IDistribuidoraWCF/asignarTecnicoResponse")]
        System.Threading.Tasks.Task<bool> asignarTecnicoAsync(Distribuidora.ServiceReferenceDistribuidoraWCF.Tecnico[] tecnicos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistribuidoraWCF/mostrarTodosFabricados", ReplyAction="http://tempuri.org/IDistribuidoraWCF/mostrarTodosFabricadosResponse")]
        Distribuidora.ServiceReferenceDistribuidoraWCF.DtoFabricado[] mostrarTodosFabricados();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistribuidoraWCF/mostrarTodosFabricados", ReplyAction="http://tempuri.org/IDistribuidoraWCF/mostrarTodosFabricadosResponse")]
        System.Threading.Tasks.Task<Distribuidora.ServiceReferenceDistribuidoraWCF.DtoFabricado[]> mostrarTodosFabricadosAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistribuidoraWCF/altaEmpleado", ReplyAction="http://tempuri.org/IDistribuidoraWCF/altaEmpleadoResponse")]
        bool altaEmpleado(string nombre, string contrasena, string email, bool tipo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistribuidoraWCF/altaEmpleado", ReplyAction="http://tempuri.org/IDistribuidoraWCF/altaEmpleadoResponse")]
        System.Threading.Tasks.Task<bool> altaEmpleadoAsync(string nombre, string contrasena, string email, bool tipo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistribuidoraWCF/mostrarTodosImportado", ReplyAction="http://tempuri.org/IDistribuidoraWCF/mostrarTodosImportadoResponse")]
        Distribuidora.ServiceReferenceDistribuidoraWCF.DtoImportado[] mostrarTodosImportado();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistribuidoraWCF/mostrarTodosImportado", ReplyAction="http://tempuri.org/IDistribuidoraWCF/mostrarTodosImportadoResponse")]
        System.Threading.Tasks.Task<Distribuidora.ServiceReferenceDistribuidoraWCF.DtoImportado[]> mostrarTodosImportadoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistribuidoraWCF/GenerarReporteTxtProductos", ReplyAction="http://tempuri.org/IDistribuidoraWCF/GenerarReporteTxtProductosResponse")]
        bool GenerarReporteTxtProductos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistribuidoraWCF/GenerarReporteTxtProductos", ReplyAction="http://tempuri.org/IDistribuidoraWCF/GenerarReporteTxtProductosResponse")]
        System.Threading.Tasks.Task<bool> GenerarReporteTxtProductosAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDistribuidoraWCFChannel : Distribuidora.ServiceReferenceDistribuidoraWCF.IDistribuidoraWCF, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DistribuidoraWCFClient : System.ServiceModel.ClientBase<Distribuidora.ServiceReferenceDistribuidoraWCF.IDistribuidoraWCF>, Distribuidora.ServiceReferenceDistribuidoraWCF.IDistribuidoraWCF {
        
        public DistribuidoraWCFClient() {
        }
        
        public DistribuidoraWCFClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DistribuidoraWCFClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DistribuidoraWCFClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DistribuidoraWCFClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool agregarProductoFabricado(string nombreProd, string descProd, double costoProd, double precioSugeridoProd, int tiempoFabProd, int idAltaEmpleado) {
            return base.Channel.agregarProductoFabricado(nombreProd, descProd, costoProd, precioSugeridoProd, tiempoFabProd, idAltaEmpleado);
        }
        
        public System.Threading.Tasks.Task<bool> agregarProductoFabricadoAsync(string nombreProd, string descProd, double costoProd, double precioSugeridoProd, int tiempoFabProd, int idAltaEmpleado) {
            return base.Channel.agregarProductoFabricadoAsync(nombreProd, descProd, costoProd, precioSugeridoProd, tiempoFabProd, idAltaEmpleado);
        }
        
        public bool agregarProductoImportado(string nombre, string descripcion, double costo, double precioSugerido, bool descontinuado, string origen, int cantImportacion) {
            return base.Channel.agregarProductoImportado(nombre, descripcion, costo, precioSugerido, descontinuado, origen, cantImportacion);
        }
        
        public System.Threading.Tasks.Task<bool> agregarProductoImportadoAsync(string nombre, string descripcion, double costo, double precioSugerido, bool descontinuado, string origen, int cantImportacion) {
            return base.Channel.agregarProductoImportadoAsync(nombre, descripcion, costo, precioSugerido, descontinuado, origen, cantImportacion);
        }
        
        public bool asignarTecnico(Distribuidora.ServiceReferenceDistribuidoraWCF.Tecnico[] tecnicos) {
            return base.Channel.asignarTecnico(tecnicos);
        }
        
        public System.Threading.Tasks.Task<bool> asignarTecnicoAsync(Distribuidora.ServiceReferenceDistribuidoraWCF.Tecnico[] tecnicos) {
            return base.Channel.asignarTecnicoAsync(tecnicos);
        }
        
        public Distribuidora.ServiceReferenceDistribuidoraWCF.DtoFabricado[] mostrarTodosFabricados() {
            return base.Channel.mostrarTodosFabricados();
        }
        
        public System.Threading.Tasks.Task<Distribuidora.ServiceReferenceDistribuidoraWCF.DtoFabricado[]> mostrarTodosFabricadosAsync() {
            return base.Channel.mostrarTodosFabricadosAsync();
        }
        
        public bool altaEmpleado(string nombre, string contrasena, string email, bool tipo) {
            return base.Channel.altaEmpleado(nombre, contrasena, email, tipo);
        }
        
        public System.Threading.Tasks.Task<bool> altaEmpleadoAsync(string nombre, string contrasena, string email, bool tipo) {
            return base.Channel.altaEmpleadoAsync(nombre, contrasena, email, tipo);
        }
        
        public Distribuidora.ServiceReferenceDistribuidoraWCF.DtoImportado[] mostrarTodosImportado() {
            return base.Channel.mostrarTodosImportado();
        }
        
        public System.Threading.Tasks.Task<Distribuidora.ServiceReferenceDistribuidoraWCF.DtoImportado[]> mostrarTodosImportadoAsync() {
            return base.Channel.mostrarTodosImportadoAsync();
        }
        
        public bool GenerarReporteTxtProductos() {
            return base.Channel.GenerarReporteTxtProductos();
        }
        
        public System.Threading.Tasks.Task<bool> GenerarReporteTxtProductosAsync() {
            return base.Channel.GenerarReporteTxtProductosAsync();
        }
    }
}