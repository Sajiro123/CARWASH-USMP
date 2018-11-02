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
        Facade facade = new Facade();
        // GET: GenerarOrdenCompra
        public ActionResult GenerarOrdenCompra()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GenerarOrdenCompra(string no)
        {

            var context = new CARWASHEntities5();

            string ruc1 = Convert.ToString(Request["txtProveedor"]);
            if (!String.IsNullOrEmpty(ruc1))
            {
                if (ModelState.IsValid)
                {
                    long ruc2 = Convert.ToInt64(ruc1);
                    var customer = context.PROVEEDOR.FirstOrDefault(i => i.RUC == ruc2);
                    if (customer == null)
                    {
                        TempData["Message"] = "No Encontro Proveedor";
                        return View();
                    }
                    else
                    {

                        TempData["RazonSocial"] = customer.RAZON_SOCIAL;
                        TempData["Direccion"] = customer.DIRECCION;
                        TempData["Ruc"] = customer.RUC;
                        TempData["Telefono"] = customer.TELEFONO;
                        TempData.Keep();
                        return View();
                    }
                }
            }

            else
            {


                string cod = Convert.ToString(Request["txtMaterial"]);
                if (ModelState.IsValid)
                {
                    TempData.Keep();
                    var customer1 = context.MATERIALES.FirstOrDefault(i => i.COD_MATE == cod);

                    if (customer1 == null)
                    {
                        TempData["Message"] = "No Encontro Material";

                        return View();

                    }
                    else
                    {

                        ViewData["Descripcion"] = customer1.DESCRIPCION;
                        ViewData["PreU"] = Convert.ToDecimal(customer1.PRECI_UNI);
                        ViewData["Codigo"] = customer1.COD_MATE;
                        return View();
                    }
                }
            }

            return View();






        }
        public ActionResult Buscar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(List<string> rows)
        {
            CARWASHEntities5 db = new CARWASHEntities5();
            List<MATERIALES> materiales = new List<MATERIALES>();
            string Ruc = Request["txtRuc"];
            string Cantidad = Request["txtCantidad"];
            string[] subtotal = new string[1000];
            int i = 0;
            rows.ForEach(x =>
            {
                MATERIALES items = new MATERIALES();
                var row = x.Split('-');
                var cod = rows[0];
                var des = row[1];
                var cant = row[2];
                var pre = row[3];
                subtotal[i] = row[4];
                items.COD_MATE = cod;
                items.DESCRIPCION = cant;
                items.PRECI_UNI = double.Parse(pre);
                i++;
            });
            int i2 = 0;
            foreach (MATERIALES e in materiales)
            {
                ORDEN_COMPRA ordenCom = new ORDEN_COMPRA();
                ordenCom.COD_MATE = e.COD_MATE;
                ordenCom.RUC = int.Parse(Ruc);
                ordenCom.CANTIDAD = int.Parse(Cantidad);
                ordenCom.SUBTOTAL = double.Parse(subtotal[i2]);
                db.ORDEN_COMPRA.Add(ordenCom);
            }
            db.SaveChanges();
            return Json(true);
        }
    }
}