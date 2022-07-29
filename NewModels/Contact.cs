using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace NewModels
{
    public class Contact
    {
        [Key]public int contactID { get; set; }
        [Required]public bool POorStreet { get; set; }
        [Required]public int PONumber { get; set; }
        [Required]public int streetNumber { get; set; }
        [Required] public string streetName { get; set; } = null!;
        [Required]public string cityState { get; set; }=null!;
        [Required]public int zipcode { get; set; }
        [ForeignKey("User")] public int userID { get; set; }
        public int phone { get; set; }
        public string email { get; set; } = null!;
    }
}