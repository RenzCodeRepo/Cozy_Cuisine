using System.ComponentModel.DataAnnotations;

namespace Cozy_Cuisine.Models
{
    public class FAQ
    {
        [Key]
        public int FAQId { get; set; }
        public string Question { get; set; }
        public List<string> FAQURLImageList { get; set; }
        public string Answer { get; set; }
    }
}
