using System;
using System.Collections.Generic;

namespace Library.Data.Models
{
    public partial class Association
    {
        public Association()
        {
            HuntingGround = new HashSet<HuntingGround>();
            UserAssociation = new HashSet<UserAssociation>();
        }

        public int Id { get; set; }
        public int? IdCounty { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual County IdCountyNavigation { get; set; }
        public virtual ICollection<HuntingGround> HuntingGround { get; set; }
        public virtual ICollection<UserAssociation> UserAssociation { get; set; }
    }
}
