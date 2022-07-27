using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public int? ClaimIdFk { get; set; }
        public int? UserIdFk { get; set; }
        public int? PolicyIdFk { get; set; }
        public string Details { get; set; } = null!;

        public virtual Claim? ClaimIdFkNavigation { get; set; }
        public virtual Policy? PolicyIdFkNavigation { get; set; }
        public virtual User? UserIdFkNavigation { get; set; }
    }
}
