using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class ContactsVM
    {
        public List<FAQ> FAQs { get; set; } = new List<FAQ>();
        public Dictionary<string, int> PatchesDict { get; set; } = new Dictionary<string, int>();
        public Contacts? NewContacts { get; set; } = new Contacts();
        public BugReport? NewBugReport { get; set; } = new BugReport();
    }
}
