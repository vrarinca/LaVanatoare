using System;
using System.Collections.Generic;

namespace HuntingAssociation.Models
{
    public partial class SpeciesHuntingType
    {
        public int Id { get; set; }
        public int? IdSpecies { get; set; }
        public int? IdHuntingType { get; set; }

        public virtual HuntingType IdHuntingTypeNavigation { get; set; }
        public virtual Species IdSpeciesNavigation { get; set; }
    }
}
