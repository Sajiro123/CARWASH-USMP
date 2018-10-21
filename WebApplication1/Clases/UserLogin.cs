using System.

namespace Clases
{
    public class UserLogin
    {
        public string DNI { get; set; }
        public string PASSWORD { get; set; }

        CARWASHEntities user = new CARWASHEntities();

        public bool login()
        {


            var query = from u in user.Login1
                        where u.DNI == DNI && u.PASSWORD == PASSWORD
                        select u;
            if (query.Count() > 0)
            {
                var query2 = from u in user.Login1
                             where u.DNI == DNI
                             select u;
                var datos = query.ToList();

                foreach (var Data in datos)
                {
                    DNI = Data.DNI;
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