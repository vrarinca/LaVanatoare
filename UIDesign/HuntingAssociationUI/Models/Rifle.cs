using System;
using System.Collections.Generic;

namespace HuntingAssociation.Models
{
    public partial class Rifle
    {
        public Rifle()
        {
            AuthorisationRifle = new HashSet<AuthorisationRifle>();
            SpeciesRifle = new HashSet<SpeciesRifle>();
        }

        public int Id { get; set; }
        public int? IdRiflePipeType { get; set; }
        public decimal? CartridgeDiameter { get; set; }
        public int? CartridgeLength { get; set; }
        public int? CartridgeWeight { get; set; }
        public int? Energy { get; set; }
        public decimal? PelletDiameter { get; set; }

        public virtual RiflePipeType IdRiflePipeTypeNavigation { get; set; }
        public virtual ICollection<AuthorisationRifle> AuthorisationRifle { get; set; }
        public virtual ICollection<SpeciesRifle> SpeciesRifle { get; set; }
    }
}
