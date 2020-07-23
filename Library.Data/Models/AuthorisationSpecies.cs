using System;
using System.Collections.Generic;

namespace Library.Data.Models
{
    public partial class AuthorisationSpecies
    {
        public int Id { get; set; }
        public int? IdAuthorisation { get; set; }
        public int? IdSpecies { get; set; }
        public int? NoAllowed { get; set; }
        public int? NoKilled { get; set; }

        public virtual Authorisation IdAuthorisationNavigation { get; set; }
        public virtual Species IdSpeciesNavigation { get; set; }
    }
}
