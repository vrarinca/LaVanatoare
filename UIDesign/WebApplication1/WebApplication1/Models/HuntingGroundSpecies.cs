using System;
using System.Collections.Generic;

namespace HuntingAssociation.Models
{
    public partial class HuntingGroundSpecies
    {
        public int Id { get; set; }
        public int? IdHuntingground { get; set; }
        public int? IdSpecies { get; set; }
        public int? Season { get; set; }
        public int? Quota { get; set; }

        public virtual HuntingGround IdHuntinggroundNavigation { get; set; }
        public virtual Species IdSpeciesNavigation { get; set; }
    }
}
