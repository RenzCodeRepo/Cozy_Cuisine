using System.ComponentModel.DataAnnotations;

namespace Cozy_Cuisine.Models
{
    public class Notice
    {
        [Key]
        public int NoticeId { get; set; }
        public string Headline { get; set; }
        public DateTime PostedDate { get; set; } = DateTime.Now;
        public string Category { get; set; }
        public string Content { get; set; }
        public string URLNewsImageList { get; set; }
        public string URLVideo { get; set; }
    }
}
