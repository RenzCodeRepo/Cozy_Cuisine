using Cozy_Cuisine.Models;
using Microsoft.Identity.Client;

namespace Cozy_Cuisine.ViewModels
{
    public class WikiMangementVM
    {
        public List<Wiki> Wikis { get; set; } = new List<Wiki>();
        public Wiki NewWiki { get; set; } = new Wiki(); 
    }
}
