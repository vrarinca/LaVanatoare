using System;
using System.Collections.Generic;

namespace HuntingAssociation.Models
{
    public partial class AuthorisationRifle
    {
        public int Id { get; set; }
        public int? IdAuthorisation { get; set; }
        public int? IdRifle { get; set; }

        public virtual Authorisation IdAuthorisationNavigation { get; set; }
        public virtual Rifle IdRifleNavigation { get; set; }
    }
}
