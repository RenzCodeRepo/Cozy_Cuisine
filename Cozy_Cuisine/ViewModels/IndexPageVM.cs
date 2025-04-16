using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class IndexPageVM
    {
        public Patches Patches { get; set; } = new Patches();
        public List<GameItems> GameItems { get; set; } = new List<GameItems>();
    }
}
