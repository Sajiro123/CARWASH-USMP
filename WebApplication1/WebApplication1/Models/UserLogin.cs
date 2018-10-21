using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserLogin
    {
        public string C_USER { get; set; }
        public string _PASSWORD { get; set; }
        public string COD_TIPO_LOG { get; set; }

 

        CARWASHEntities user = new CARWASHEntities();

        public bool login_Cli()
        {


            var query = from u in user.C_LOGIN
                        where u.C_USER == C_USER && u.C_PASSWORD == _PASSWORD
                        select u;
            if (query.Count() > 0)
            {
                var query2 = from u in user.C_LOGIN
                             where u.C_USER == C_USER
                          
                             select u;
                var datos = query.ToList();

                foreach (var Data in datos)
                {
                    C_USER = Data.C_USER;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
 













    }
}