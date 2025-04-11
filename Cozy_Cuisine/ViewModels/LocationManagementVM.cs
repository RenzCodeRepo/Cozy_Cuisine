using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class LocationManagementVM
    {
        public Locations NewLocation { get; set; }  = new Locations();
        public List<Locations> Locations { get; set; } = new List<Locations>();
    }
}
