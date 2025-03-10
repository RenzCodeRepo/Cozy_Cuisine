using System.ComponentModel.DataAnnotations;

namespace Cozy_Cuisine.Models
{
    public class Credit
    {
        [Key]
        public int CreditId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string URLGif { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}
