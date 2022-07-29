using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewModels
{
    public class User
    {
        [Key] public int? userID { get; set; }
        public string first_name { get; set; } = null!;
        public char middle_init { get; set; }
        public string last_name { get; set; } = null!;
        public string username { get; set; } = null!;
        public string password { get; set; } = null!;
        public DateTime DoB { get; set; } 
        public string role { get; set; } = null!;
    }
}
