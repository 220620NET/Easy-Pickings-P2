using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewModels
{
    public class Insurance
    {
        [ForeignKey("Policy")]public int? provider { get; set; }
        [ForeignKey("User")]public int? benefactor { get; set; } 
        
    }
}
