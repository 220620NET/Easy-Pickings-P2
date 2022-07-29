using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class User
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleInit { get; set; }
        public string? LastName { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? DoB { get; set; }
        public string Role { get; set; } = null!;
    }
}
