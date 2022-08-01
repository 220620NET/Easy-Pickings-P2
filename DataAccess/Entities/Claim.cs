using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Claim
    {
        public int ClaimId { get; set; }
        public int? UserIdFk { get; set; }
        public int? DoctorIdFk { get; set; }
        public int? ProviderFk { get; set; }
        public byte[] ReasonForVisit { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual User1? DoctorIdFkNavigation { get; set; }
        public virtual Policy1? ProviderFkNavigation { get; set; }
        public virtual User1? UserIdFkNavigation { get; set; }
    }
}
