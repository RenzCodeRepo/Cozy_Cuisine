using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class CreditsManagementVM
    {
        public Credit NewCredits { get; set; } = new Credit();
        public List<Credit> Credits { get; set; } = new List<Credit>();
    }
}
