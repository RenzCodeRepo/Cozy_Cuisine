using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class NewsManagementVM
    {
        public Notice NewNotice { get; set; } = new Notice();
        public List<Notice> Notices { get; set; } = new List<Notice>();
    }
}
