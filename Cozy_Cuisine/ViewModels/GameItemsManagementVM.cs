using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class GameItemsManagementVM
    {
        public GameItems NewGameItems { get; set; } = new GameItems();
        public List<GameItems> GameItems { get; set; } = new List<GameItems>();
    }
}
