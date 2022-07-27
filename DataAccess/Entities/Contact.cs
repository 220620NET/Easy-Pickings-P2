using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Contact
    {
        public Contact()
        {
            Users = new HashSet<User>();
        }

        public int ContactId { get; set; }
        public bool PoOrStreet { get; set; }
        public int PoNumber { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; } = null!;
        public string CityState { get; set; } = null!;
        public int Zipcode { get; set; }
        public int? Phone { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
