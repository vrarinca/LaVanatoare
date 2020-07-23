using System;
using System.Collections.Generic;

namespace Library.Data.Models
{
    public partial class SpeciesRifle
    {
        public int Id { get; set; }
        public int? IdSpecies { get; set; }
        public int? IdRifle { get; set; }

        public virtual Rifle IdRifleNavigation { get; set; }
        public virtual Species IdSpeciesNavigation { get; set; }
    }
}
