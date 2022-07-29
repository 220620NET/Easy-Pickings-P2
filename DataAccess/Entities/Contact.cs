using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public int? UserId { get; set; }
        public bool PoOrStreet { get; set; }
        public int PoNumber { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; } = null!;
        public string CityState { get; set; } = null!;
        public int Zipcode { get; set; }
        public int? Phone { get; set; }
        public string? Email { get; set; }

        public virtual User1? User { get; set; }
    }
}
