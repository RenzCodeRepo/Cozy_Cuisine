using System.ComponentModel.DataAnnotations;

namespace Cozy_Cuisine.Models
{
    public class Visitor
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateVisited { get; set; } = DateTime.Now;
    }
}
