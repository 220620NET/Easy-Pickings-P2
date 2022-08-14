using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewModels
{
    public class Comment
    {
        [Key] public int commentID { get; set; }
        [ForeignKey("User")] public int userID { get; set; }
        [ForeignKey("Discussion")] public int messageID { get; set; }
        [Required] public string body { get; set; } = null!;
    }
}
