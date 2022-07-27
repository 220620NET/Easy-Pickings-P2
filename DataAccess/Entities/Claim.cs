using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Claim
    {
        public Claim()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int ClaimId { get; set; }
        public int? UserIdFk { get; set; }
        public int? DoctorIdFk { get; set; }
        public int? ProviderFk { get; set; }
        public byte[] ReasonForVisit { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual User? DoctorIdFkNavigation { get; set; }
        public virtual Policy? ProviderFkNavigation { get; set; }
        public virtual User? UserIdFkNavigation { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
