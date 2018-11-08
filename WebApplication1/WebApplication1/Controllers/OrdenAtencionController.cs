
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OrdenAtencionController : Controller
    {
        // GET: OrdenAtencion
        public ActionResult OrdenAtencion()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OrdenAtencion(CLIENTE DNI)
        {

            //Obtener los datos ingresados por el cliente
            string Cod = (Request["txtServicio"]);
            string Cod2 = Convert.ToString(Request["txtcod"]);
            string dni1 = Convert.ToString(Request["txtCliente"]);

            //Obtener Datos Temporalmente para luego obtenerlos en la vista
            if (!string.IsNullOrEmpty(dni1))
                TempData["dni"] = dni1;
            if (!string.IsNullOrEmpty(Cod))
                TempData["servicio"] = Cod;
            if (!string.IsNullOrEmpty(Cod2))
                TempData["materiales"] = Cod2;



            //Validar que los datos sean los correctos
            if (ModelState.IsValid)
            {

                int dni21 = Convert.ToInt32(dni1);
                var context = new CARWASHEntities5();
                var customer = context.CLIENTE_AUTO.FirstOrDefault(i => i.DNI == dni21);


                if (customer == null && !string.IsNullOrEmpty(dni1))
                {
                    TempData["Message"] = "No enconotro Cliente ";
                    return View();
                }
                else if (customer != null)
                {
                    int a = Convert.ToInt32(dni1);

                    var customer1 = context.CLIENTE_AUTO.FirstOrDefault(i => i.DNI == a);

                    ViewData["DNI"] = customer1.DNI;
                    ViewData["APELLIDO"] = customer1.APELLIDO;
                    ViewData["NOMBRE"] = customer1.NOMBRE;
                    ViewData["CORREO"] = customer1.CORREO;
                    ViewData["TELEFONO"] = customer1.TELEFONO;
                    ViewData["PLACA"] = customer1.PLACA;
                    ViewData["MARCA"] = customer1.MARCA;
                    ViewData["MODELO"] = customer1.MODELO;
                    ViewData["CLASE"] = customer1.CLASE;
                    ViewData["NUM_ASI"] = customer1.NUM_ASI;

                    return View();
                }
                else if (!string.IsNullOrEmpty(TempData["dni"] as string))
                {
                    int a = Convert.ToInt32(TempData["dni"]);

                    var customer1 = context.CLIENTE_AUTO.FirstOrDefault(i => i.DNI == a);

                    ViewData["DNI"] = customer1.DNI;
                    ViewData["APELLIDO"] = customer1.APELLIDO;
                    ViewData["NOMBRE"] = customer1.NOMBRE;
                    ViewData["CORREO"] = customer1.CORREO;
                    ViewData["TELEFONO"] = customer1.TELEFONO;
                    ViewData["PLACA"] = customer1.PLACA;
                    ViewData["MARCA"] = customer1.MARCA;
                    ViewData["MODELO"] = customer1.MODELO;
                    ViewData["CLASE"] = customer1.CLASE;
                    ViewData["NUM_ASI"] = customer1.NUM_ASI;

                }


            }


            //Validar que los datos sean los correctos
            if (!string.IsNullOrEmpty(Cod))
            {
                var context = new CARWASHEntities5();
                if (ModelState.IsValid)
                {

                    var customer = context.SERVICIO.FirstOrDefault(i => i.COD_SERVICIO == Cod);

                    if (customer == null && !string.IsNullOrEmpty(Cod))
                    {
                        TempData["Message"] = "No encontro Servicios ";

                        return View();

                    }

                    else if (customer != null)
                    {


                        string a = Convert.ToString(TempData["servicio"]);
                        var customer1 = context.SERVICIO.FirstOrDefault(i => i.COD_SERVICIO == a);
                        ViewData["COD"] = customer1.NOMBRE;


                    }
                    else
                    {

                        string a = Convert.ToString(TempData["servicio"]);
                        var customer1 = context.SERVICIO.FirstOrDefault(i => i.COD_SERVICIO == a);
                        ViewData["COD"] = customer1.NOMBRE;
                    }
                }

            }
            else
            {
                var context = new CARWASHEntities5();
                string b = Convert.ToString(TempData["servicio"]);
                var customer3 = context.SERVICIO.FirstOrDefault(i => i.COD_SERVICIO == b);
                ViewData["COD"] = customer3.NOMBRE;
            }


            if (!string.IsNullOrEmpty(Cod2))
            {
                var context = new CARWASHEntities5();
                //Validar que los datos sean los correctos
                if (ModelState.IsValid)
                {

                    var customer = context.MATERIALES.FirstOrDefault(i => i.COD_MATE == Cod2);

                    if (customer == null && !string.IsNullOrEmpty(Cod2))
                    {
                        TempData["Message"] = "No enconotro Materiales";

                        return View();

                    }

                    else if (customer != null)
                    {

                        var customer2 = context.MATERIALES.FirstOrDefault(i => i.COD_MATE == Cod2);
                        ViewData["descripcion"] = customer2.DESCRIPCION;



                    }
                    else
                    {

                        string a = Convert.ToString(TempData["materiales"]);
                        var customer3 = context.MATERIALES.FirstOrDefault(i => i.COD_MATE == a);
                        ViewData["descripcion"] = customer3.DESCRIPCION;
                        
                        ViewData["precio"] = customer3.PRECI_UNI;
                        ViewData["fecha"] = customer3.FECHA_INGRESO;





                    }

                }

            }
            TempData.Keep();
            return View();

        }

 
   


    }
}





