using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Contact1
    {
        public Contact1()
        {
            User1s = new HashSet<User1>();
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

        public virtual ICollection<User1> User1s { get; set; }
    }
}
