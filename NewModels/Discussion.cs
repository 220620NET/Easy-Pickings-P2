using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace NewModels
{
    public class Discussion
    {
        [Key] public int discussionID { get; set; }
        [ForeignKey("User")] public int userID { get; set; }
        [Required] public string body { get; set; } = null!;
        [Required] public string dateCreated { get; set; } = null!;
    }
}
