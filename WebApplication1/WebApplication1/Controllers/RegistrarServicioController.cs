    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Clases_BasesDatos;

namespace WebApplication1.Controllers
{
    public class RegistrarServicioController : Controller
    {
        // GET: RegistrarServicio
        public ActionResult RegistrarServicio1()
        {
            var auto_cliente = new Auto_Cliente();


            CARWASHEntities5 context = new CARWASHEntities5();
            var query1 = (from c in context.CLIENTE
                          join a in context.C_AUTO on c.DNI equals a.DNI
                          select c).ToList();

        

            auto_cliente.AUTOs = context.C_AUTO.ToList();
            auto_cliente.CLIENTEs = context.CLIENTE.ToList();



            return View(auto_cliente);


        }
    
    }
}