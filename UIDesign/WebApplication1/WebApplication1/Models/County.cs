using System;
using System.Collections.Generic;

namespace HuntingAssociation.Models
{
    public partial class County
    {
        public County()
        {
            Association = new HashSet<Association>();
        }

        public int Id { get; set; }
        public string County1 { get; set; }

        public virtual ICollection<Association> Association { get; set; }
    }
}
