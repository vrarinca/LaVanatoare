using System;
using System.Collections.Generic;

namespace Library.Data.Models
{
    public partial class HuntingGround
    {
        public HuntingGround()
        {
            Authorisation = new HashSet<Authorisation>();
            HuntingGroundSpecies = new HashSet<HuntingGroundSpecies>();
        }

        public int Id { get; set; }
        public int? IdAssociation { get; set; }
        public string Name { get; set; }

        public virtual Association IdAssociationNavigation { get; set; }
        public virtual ICollection<Authorisation> Authorisation { get; set; }
        public virtual ICollection<HuntingGroundSpecies> HuntingGroundSpecies { get; set; }
    }
}
