using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cozy_Cuisine.Models
{
    public class GameReview
    {
        [Key]
        public int ReviewId { get; set; }
        public int DownloadId { get; set; }
        [ForeignKey("DownloadId")]
        public virtual GameDownloads GameDownloads { get; set; }
        
        public int Rating { get; set; }
        public DateTime PostedDate { get; set; } = DateTime.Now;
        public string ReviewComment { get; set; }

    }
}
