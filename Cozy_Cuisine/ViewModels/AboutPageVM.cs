using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class AboutPageVM
    {
        public About LatestAbout { get; set; } =  new About();
        public List<GameMechanics> GameMechanics { get; set;} = new List<GameMechanics>();
    }
}
