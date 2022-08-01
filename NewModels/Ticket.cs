using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewModels
{
    public class Ticket
    {
        [Key]public int ticketID { get; set; }
        [ForeignKey("Claim")]public int claimID { get; set; }
        [ForeignKey("User")]public int userID { get; set; }
        [ForeignKey("Policy")]public int policyID { get; set; }
        [Required] public string details { get; set; } = null!;
    }
}
