using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Policy
    {
        public Policy()
        {
            Claims = new HashSet<Claim>();
            Benefactors = new HashSet<User>();
        }

        public int PolicyId { get; set; }
        public int? Insurance { get; set; }
        public byte[] Coverage { get; set; } = null!;

        public virtual User? InsuranceNavigation { get; set; }
        public virtual ICollection<Claim> Claims { get; set; }

        public virtual ICollection<User> Benefactors { get; set; }
    }
}
