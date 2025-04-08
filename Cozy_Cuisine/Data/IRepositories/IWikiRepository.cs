using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.Data.IRepositories
{
    public interface IWikiRepository
    {
        Task<List<Wiki>> GetAllWikisAsync();
        Task<Wiki> GetWikiByIdAsync(int id);
        Task AddWikiAsync(Wiki wiki);
        Task UpdateWikiAsync(Wiki wiki);
        Task <bool> DeleteWikiAsync(int id);

        Task<List<StoryPlot>> GetAllStoryPlotsAsync();
        Task<StoryPlot> GetStoryPlotByIdAsync(int id);
        Task AddStoryPlotAsync(StoryPlot storyPlot);
        Task UpdateStoryPlotAsync(StoryPlot storyPlot);
        Task<bool> DeleteStoryPlotAsync(int id);

        Task<List<Characters>> GetAllCharactersAsync();
        Task<Characters> GetCharacterByIdAsync(int id);
        Task AddCharacterAsync(Characters character);
        Task UpdateCharacterAsync(Characters character);
        Task <bool> DeleteCharacterAsync(int id);

        Task<List<GameMechanics>> GetAllGameMechanicsAsync();
        Task<GameMechanics> GetGameMechanicByIdAsync(int id);
        Task AddGameMechanicAsync(GameMechanics gameMechanic);
        Task UpdateGameMechanicAsync(GameMechanics gameMechanic);
        Task <bool> DeleteGameMechanicAsync(int id);

        Task<List<GameItems>> GetAllGameItemsAsync();
        Task<GameItems> GetGameItemByIdAsync(int id);
        Task AddGameItemAsync(GameItems gameItem);
        Task UpdateGameItemAsync(GameItems gameItem);
        Task <bool> DeleteGameItemAsync(int id);

        Task<List<Locations>> GetAllLocationsAsync();
        Task<Locations> GetLocationByIdAsync(int id);
        Task AddLocationAsync(Locations location);
        Task UpdateLocationAsync(Locations location);
        Task DeleteLocationAsync(int id);
    }

}
