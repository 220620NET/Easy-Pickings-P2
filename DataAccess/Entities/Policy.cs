using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Policy
    {
        public int PolicyId { get; set; }
        public int? Insurance { get; set; }
        public byte[] Coverage { get; set; } = null!;

        public virtual User1? InsuranceNavigation { get; set; }
    }
}
