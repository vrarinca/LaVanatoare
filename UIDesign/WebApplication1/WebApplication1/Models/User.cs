using System;
using System.Collections.Generic;

namespace HuntingAssociation.Models
{
    public partial class User
    {
        public User()
        {
            Authorisation = new HashSet<Authorisation>();
            AuthorisationUser = new HashSet<AuthorisationUser>();
            UserAssociation = new HashSet<UserAssociation>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cnp { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string License { get; set; }
        public string Insurance { get; set; }

        public virtual ICollection<Authorisation> Authorisation { get; set; }
        public virtual ICollection<AuthorisationUser> AuthorisationUser { get; set; }
        public virtual ICollection<UserAssociation> UserAssociation { get; set; }
    }
}
