using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace NewModels
{
    public class Contact
    {
        [Key]public int contactID { get; set; }
        [Required]public bool PO_or_street { get; set; }
        [Required]public int PO_number { get; set; }
        [Required]public int street_number { get; set; }
        [Required] public string street_name { get; set; } = null!;
        [Required] public string city_state { get; set; } = null!;
        [Required]public int zipcode { get; set; }
        [ForeignKey("User")] public int userID { get; set; }
        public long phone { get; set; }
        public string email { get; set; } = null!;
    }
}