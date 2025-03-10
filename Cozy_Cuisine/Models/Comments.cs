
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cozy_Cuisine.Models
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public string? Username { get; set; } //nullable to allow anonymous Dev or Mod
        public int BugId { get; set; }
        [ForeignKey("BugId")]
        public virtual BugReport BugReport { get; set; }
        public string Message { get; set; }
        public List<string> URLImageList { get; set; }
        public DateTime PostedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } // Nullable to change once there is 


    }
}
