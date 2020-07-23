using System;
using System.Collections.Generic;

namespace HuntingAssociation.Models
{
    public partial class RiflePipeType
    {
        public RiflePipeType()
        {
            Rifle = new HashSet<Rifle>();
        }

        public int Id { get; set; }
        public string PipeType { get; set; }

        public virtual ICollection<Rifle> Rifle { get; set; }
    }
}
