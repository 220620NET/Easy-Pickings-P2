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

        public virtual Claim1? ClaimIdFkNavigation { get; set; }
        public virtual Policy1? PolicyIdFkNavigation { get; set; }
        public virtual User1? UserIdFkNavigation { get; set; }
    }
}
