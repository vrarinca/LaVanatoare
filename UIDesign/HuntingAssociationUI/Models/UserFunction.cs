using System;
using System.Collections.Generic;

namespace HuntingAssociation.Models
{
    public partial class UserFunction
    {
        public UserFunction()
        {
            UserAssociation = new HashSet<UserAssociation>();
        }

        public int Id { get; set; }
        public string FunctionName { get; set; }

        public virtual ICollection<UserAssociation> UserAssociation { get; set; }
    }
}
