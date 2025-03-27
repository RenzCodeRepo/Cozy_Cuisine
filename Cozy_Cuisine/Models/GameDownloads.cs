using System.ComponentModel.DataAnnotations;

namespace Cozy_Cuisine.Models
{
    public class GameDownloads
    {
        [Key]
        public int DownloadId { get; set; }
        public DateTime DateDownloaded { get; set; } = DateTime.Now;


    }
}
