using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class FAQManagementVM
    {
        public FAQ? NewFAQ { get; set; } = new FAQ();
        public List<FAQ> FAQs { get; set;} = new List<FAQ>();
    }
}
