using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class ContactsVM
    {
        public List<FAQ> FAQs { get; set; } = new List<FAQ>();
        public Dictionary<string, int> PatchesDict { get; set; } = new Dictionary<string, int>();
    }
}
