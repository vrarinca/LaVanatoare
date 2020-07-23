using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Models.Login
{
    public class User
    {
       
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cnp { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string License { get; set; }
        public string Insurance { get; set; }
        public bool RememberMe { get; set; }

    }
}