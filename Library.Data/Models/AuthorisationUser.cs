using System;
using System.Collections.Generic;

namespace Library.Data.Models
{
    public partial class AuthorisationUser
    {
        public int Id { get; set; }
        public int? IdAuthorisation { get; set; }
        public int? IdUser { get; set; }

        public virtual Authorisation IdAuthorisationNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
