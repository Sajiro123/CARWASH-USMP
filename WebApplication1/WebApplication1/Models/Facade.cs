using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;

namespace WebApplication1.Models
{

    public class Facade
    {
     
        public PROVEEDOR BuscarProveedor(int RUC)
        {
            var context = new CARWASHEntities5();
            var datos = context.PROVEEDOR.Find(RUC);
            //context.SaveChanges();
            return datos;
        }
        public PROVEEDOR BuscarOrdenAtencion(string COD)
        {
            var context = new CARWASHEntities5();
            var datos = context.PROVEEDOR.Find(COD);
            //context.SaveChanges();
            return datos;
        }
        public CLIENTE_AUTO BuscarCliente(int dni21) { 
        
        
            var context = new CARWASHEntities5();
            var datos = context.CLIENTE_AUTO.Find(dni21);
            //context.SaveChanges();
            return datos;
        }
        public SERVICIO BuscarServicio(string COD)
        {


            var context = new CARWASHEntities5();
            var datos = context.SERVICIO.Find(COD);
            //context.SaveChanges();
            return datos;
        }







        public void RetornarDatos(int DNI, string NOMBRE, string APELLIDO, string CORREO, decimal TELEFONO, string PLACA, string MARCA, string MODELO, string CLASE, int NUM_ASI)
        {

            var context1 = new CARWASHEntities5();

            var query1 = from c in context1.CLIENTE
                         join a in context1.C_AUTO on c.DNI equals a.DNI
                         select new { c.DNI, c.NOMBRE, c.APELLIDO, c.CORREO, c.TELEFONO, a.PLACA, a.MARCA, a.MODELO, a.CLASE, a.NUM_ASI };

            var customer = query1.FirstOrDefault(i => i.DNI == DNI);


        }
 

    }
}