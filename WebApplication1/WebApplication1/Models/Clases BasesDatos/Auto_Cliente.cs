using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Clases_BasesDatos
{
    public class Auto_Cliente
    {
        public List<CLIENTE> CLIENTEs { get; set; }
        public List<C_AUTO> AUTOs { get; set; }
    }
}