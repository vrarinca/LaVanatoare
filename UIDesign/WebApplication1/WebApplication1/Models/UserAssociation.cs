using System;
using System.Collections.Generic;

namespace HuntingAssociation.Models
{
    public partial class UserAssociation
    {
        public int Id { get; set; }
        public int? IdUser { get; set; }
        public int? IdAssociation { get; set; }
        public int? IdFunction { get; set; }
        public int? IdRole { get; set; }

        public virtual Association IdAssociationNavigation { get; set; }
        public virtual UserFunction IdFunctionNavigation { get; set; }
        public virtual UserRole IdRoleNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
