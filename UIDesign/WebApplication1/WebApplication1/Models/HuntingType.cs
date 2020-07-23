using System;
using System.Collections.Generic;

namespace HuntingAssociation.Models
{
    public partial class HuntingType
    {
        public HuntingType()
        {
            Authorisation = new HashSet<Authorisation>();
            SpeciesHuntingType = new HashSet<SpeciesHuntingType>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Authorisation> Authorisation { get; set; }
        public virtual ICollection<SpeciesHuntingType> SpeciesHuntingType { get; set; }
    }
}
