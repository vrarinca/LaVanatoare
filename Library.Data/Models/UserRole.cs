using System;
using System.Collections.Generic;

namespace Library.Data.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            UserAssociation = new HashSet<UserAssociation>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<UserAssociation> UserAssociation { get; set; }
    }
}
