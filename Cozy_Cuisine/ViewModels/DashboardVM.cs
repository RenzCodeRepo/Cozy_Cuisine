using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class DashboardVM
    {
        public int TotalDownloads { get; set; } = 0 ;
        public double Ratings { get; set; } = 0.0 ;
        public int DailyVisits { get; set; } = 0 ;
        public List<Patches> Patches { get; set; } = new List<Patches>();
        public List<Contacts> Contacts { get; set; } = new List<Contacts>();
        public List<BugReport> BugReport { get; set; } = new List<BugReport>();
    }
}
