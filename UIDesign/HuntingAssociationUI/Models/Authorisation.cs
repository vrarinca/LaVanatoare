using System;
using System.Collections.Generic;

namespace HuntingAssociation.Models
{
    public partial class Authorisation
    {
        public Authorisation()
        {
            AuthorisationRifle = new HashSet<AuthorisationRifle>();
            AuthorisationSpecies = new HashSet<AuthorisationSpecies>();
            AuthorisationUser = new HashSet<AuthorisationUser>();
        }

        public int Id { get; set; }
        public int? IdHuntingGround { get; set; }
        public int? IdHuntingType { get; set; }
        public int? IdUser { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? NoHunts { get; set; }

        public virtual HuntingGround IdHuntingGroundNavigation { get; set; }
        public virtual HuntingType IdHuntingTypeNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<AuthorisationRifle> AuthorisationRifle { get; set; }
        public virtual ICollection<AuthorisationSpecies> AuthorisationSpecies { get; set; }
        public virtual ICollection<AuthorisationUser> AuthorisationUser { get; set; }
    }
}
