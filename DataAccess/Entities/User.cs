using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class User
    {
        public User()
        {
            ClaimDoctorIdFkNavigations = new HashSet<Claim>();
            ClaimUserIdFkNavigations = new HashSet<Claim>();
            Policies = new HashSet<Policy>();
            Providers = new HashSet<Policy>();
        }

        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleInit { get; set; }
        public string? LastName { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? DoB { get; set; }
        public int? ContactFk { get; set; }
        public string Role { get; set; } = null!;

        public virtual Contact? ContactFkNavigation { get; set; }
        public virtual ICollection<Claim> ClaimDoctorIdFkNavigations { get; set; }
        public virtual ICollection<Claim> ClaimUserIdFkNavigations { get; set; }
        public virtual ICollection<Policy> Policies { get; set; }

        public virtual ICollection<Policy> Providers { get; set; }
    }
}
