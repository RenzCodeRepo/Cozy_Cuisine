using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class PatchBaseVM
    {
        public Patches? Patches { get; set; }
        public BugReport? BugReport { get; set; }
        public Comments? Comments { get; set; }
    }
}
