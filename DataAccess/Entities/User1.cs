using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class User1
    {
        public User1()
        {
            Claim1DoctorIdFkNavigations = new HashSet<Claim1>();
            Claim1UserIdFkNavigations = new HashSet<Claim1>();
            ClaimDoctorIdFkNavigations = new HashSet<Claim>();
            ClaimUserIdFkNavigations = new HashSet<Claim>();
            Contacts = new HashSet<Contact>();
            Policies = new HashSet<Policy>();
            Policy1s = new HashSet<Policy1>();
            Ticket1s = new HashSet<Ticket1>();
            Tickets = new HashSet<Ticket>();
            Providers = new HashSet<Policy1>();
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

        public virtual Contact1? ContactFkNavigation { get; set; }
        public virtual ICollection<Claim1> Claim1DoctorIdFkNavigations { get; set; }
        public virtual ICollection<Claim1> Claim1UserIdFkNavigations { get; set; }
        public virtual ICollection<Claim> ClaimDoctorIdFkNavigations { get; set; }
        public virtual ICollection<Claim> ClaimUserIdFkNavigations { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Policy> Policies { get; set; }
        public virtual ICollection<Policy1> Policy1s { get; set; }
        public virtual ICollection<Ticket1> Ticket1s { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

        public virtual ICollection<Policy1> Providers { get; set; }
    }
}
