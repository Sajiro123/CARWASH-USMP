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
    
    public partial class ORDEN_COMPRA
    {
        public string COD_MATE { get; set; }
        public long RUC { get; set; }
        public Nullable<int> CANTIDAD { get; set; }
        public Nullable<double> SUBTOTAL { get; set; }
    
        public virtual MATERIALES MATERIALES { get; set; }
        public virtual PROVEEDOR PROVEEDOR { get; set; }
    }
}
