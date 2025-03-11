using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.Data.IRepositories
{
    public interface IWikiRepository
    {
        Task<IEnumerable<Wiki>> GetAllWikisAsync();
        Task<Wiki> GetWikiByIdAsync(int id);
        Task AddWikiAsync(Wiki wiki);
        Task UpdateWikiAsync(Wiki wiki);
        Task DeleteWikiAsync(int id);

        Task<IEnumerable<StoryPlot>> GetAllStoryPlotsAsync();
        Task<StoryPlot> GetStoryPlotByIdAsync(int id);
        Task AddStoryPlotAsync(StoryPlot storyPlot);
        Task UpdateStoryPlotAsync(StoryPlot storyPlot);
        Task DeleteStoryPlotAsync(int id);

        Task<IEnumerable<Characters>> GetAllCharactersAsync();
        Task<Characters> GetCharacterByIdAsync(int id);
        Task AddCharacterAsync(Characters character);
        Task UpdateCharacterAsync(Characters character);
        Task DeleteCharacterAsync(int id);

        Task<IEnumerable<GameMechanics>> GetAllGameMechanicsAsync();
        Task<GameMechanics> GetGameMechanicByIdAsync(int id);
        Task AddGameMechanicAsync(GameMechanics gameMechanic);
        Task UpdateGameMechanicAsync(GameMechanics gameMechanic);
        Task DeleteGameMechanicAsync(int id);

        Task<IEnumerable<GameItems>> GetAllGameItemsAsync();
        Task<GameItems> GetGameItemByIdAsync(int id);
        Task AddGameItemAsync(GameItems gameItem);
        Task UpdateGameItemAsync(GameItems gameItem);
        Task DeleteGameItemAsync(int id);

        Task<IEnumerable<Locations>> GetAllLocationsAsync();
        Task<Locations> GetLocationByIdAsync(int id);
        Task AddLocationAsync(Locations location);
        Task UpdateLocationAsync(Locations location);
        Task DeleteLocationAsync(int id);
    }

}
