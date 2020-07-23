using System;
using System.Collections.Generic;

namespace Library.Data.Models
{
    public partial class Species
    {
        public Species()
        {
            AuthorisationSpecies = new HashSet<AuthorisationSpecies>();
            HuntingGroundSpecies = new HashSet<HuntingGroundSpecies>();
            SpeciesHuntingType = new HashSet<SpeciesHuntingType>();
            SpeciesRifle = new HashSet<SpeciesRifle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Sex { get; set; }
        public int? Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<AuthorisationSpecies> AuthorisationSpecies { get; set; }
        public virtual ICollection<HuntingGroundSpecies> HuntingGroundSpecies { get; set; }
        public virtual ICollection<SpeciesHuntingType> SpeciesHuntingType { get; set; }
        public virtual ICollection<SpeciesRifle> SpeciesRifle { get; set; }
    }
}
