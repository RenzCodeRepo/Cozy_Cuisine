using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class PatchManagementVM
    {
        public Patches NewPatch { get; set; } = new Patches();
        public List<Patches> Patches { get; set; } = new List<Patches>(); 
    }
}
