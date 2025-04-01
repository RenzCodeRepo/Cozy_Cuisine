using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class BugReportManagementVM
    {
        public List<BugReport> BugReports { get; set; } = new List<BugReport>();
        public Comments NewComments { get; set; } = new Comments(); // For new comment submission

    }
}
