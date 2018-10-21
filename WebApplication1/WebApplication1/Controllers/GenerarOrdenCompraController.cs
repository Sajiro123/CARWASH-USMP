using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class GenerarOrdenCompraController : Controller
    {
        // GET: GenerarOrdenCompra
        public ActionResult GenerarOrdenCompra(string RUC)
        {

            var facade = new Facade();

            var datos = facade.BuscarCliente(RUC);

            return View(datos);
        }
       
    }
}