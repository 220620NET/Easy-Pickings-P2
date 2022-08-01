using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Policy1
    {
        public Policy1()
        {
            Claim1s = new HashSet<Claim1>();
            Claims = new HashSet<Claim>();
            Ticket1s = new HashSet<Ticket1>();
            Tickets = new HashSet<Ticket>();
            Benefactors = new HashSet<User1>();
        }

        public int PolicyId { get; set; }
        public int? Insurance { get; set; }
        public byte[] Coverage { get; set; } = null!;

        public virtual User1? InsuranceNavigation { get; set; }
        public virtual ICollection<Claim1> Claim1s { get; set; }
        public virtual ICollection<Claim> Claims { get; set; }
        public virtual ICollection<Ticket1> Ticket1s { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

        public virtual ICollection<User1> Benefactors { get; set; }
    }
}
