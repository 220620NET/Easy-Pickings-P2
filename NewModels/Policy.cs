using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewModels
{
    public class Policy
    {
        [Key] public int policyID { get; set; }
        [ForeignKey("User")]public int insurance { get; set; }
        [Required] public string coverage { get; set; } = null!;
    }
}
