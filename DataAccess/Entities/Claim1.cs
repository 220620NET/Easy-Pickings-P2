using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Claim1
    {
        public Claim1()
        {
            Ticket1s = new HashSet<Ticket1>();
            Tickets = new HashSet<Ticket>();
        }

        public int ClaimId { get; set; }
        public int? UserIdFk { get; set; }
        public int? DoctorIdFk { get; set; }
        public int? ProviderFk { get; set; }
        public byte[] ReasonForVisit { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual User1? DoctorIdFkNavigation { get; set; }
        public virtual Policy1? ProviderFkNavigation { get; set; }
        public virtual User1? UserIdFkNavigation { get; set; }
        public virtual ICollection<Ticket1> Ticket1s { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
