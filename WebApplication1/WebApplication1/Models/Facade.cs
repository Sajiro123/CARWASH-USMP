using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Facade
    {
        public PROVEEDOR BuscarCliente(string RUC)
        {
        
            var context = new CARWASHEntities();
            var datos = context.PROVEEDORs.Find(RUC);
            context.SaveChanges();
            return datos;
        
        }
    }
}