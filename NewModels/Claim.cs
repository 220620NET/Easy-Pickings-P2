using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewModels
{
    public class Claim
    {
        [Key] public int claimID { get; set; }
        [ForeignKey("User")] public int userID { get; set; }
        [ForeignKey("User")] public int doctorID { get; set; }
        [ForeignKey("Policy")] public int policyID{ get; set; }
        [Required] public string reasonForVisit { get; set; } = null!;
        [Required] public string status { get; set; } = "Pending";
    }
}
