//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SERVICIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SERVICIO()
        {
            this.REGISTRAR_SERVICIO = new HashSet<REGISTRAR_SERVICIO>();
        }
    
        public string COD_SERVICIO { get; set; }
        public string COD_TIPO_SERV { get; set; }
        public string NOMBRE { get; set; }
        public Nullable<double> PRECIO { get; set; }
        public System.DateTime DURACION { get; set; }
        public string DESCRIPCION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGISTRAR_SERVICIO> REGISTRAR_SERVICIO { get; set; }
        public virtual TIPO_SERVICIO TIPO_SERVICIO { get; set; }
    }
}