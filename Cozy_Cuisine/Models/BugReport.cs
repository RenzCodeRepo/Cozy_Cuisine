using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cozy_Cuisine.Models
{
    public class BugReport
    {
        [Key]
        public int BugId { get; set; }
        public int PatchId { get; set; }
        [ForeignKey("PatchId")]
        public virtual Patches Patches { get; set; }

        public string BugTitle { get; set; }
        public string BugDescription { get; set; }
        public string Status { get; set; }
        public DateTime ReportDate { get; set; } = DateTime.Now;

        public ICollection<Comments> Comments { get; set; }
    }
}
