using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class GameplayManagementVM
    {
        public GameMechanics NewGameMechanic { get; set; } = new GameMechanics();
        public List<GameMechanics> GameMechanics { get; set; } = new List<GameMechanics>();
    }
}
