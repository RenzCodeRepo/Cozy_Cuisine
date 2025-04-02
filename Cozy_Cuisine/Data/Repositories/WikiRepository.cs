using Cozy_Cuisine.Data.IRepositories;
using Cozy_Cuisine.Models;
using Microsoft.EntityFrameworkCore;

namespace Cozy_Cuisine.Data.Repositories
{
    public class WikiRepository : IWikiRepository
    {
        private readonly ApplicationDbContext _context;

        public WikiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // WIKI
        public async Task<List<Wiki>> GetAllWikisAsync() => await _context.Wiki.ToListAsync();
        public async Task<Wiki> GetWikiByIdAsync(int id) => await _context.Wiki.FindAsync(id);
        public async Task AddWikiAsync(Wiki wiki)
        {
            await _context.Wiki.AddAsync(wiki);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateWikiAsync(Wiki wiki)
        {
            _context.Wiki.Update(wiki);
            await _context.SaveChangesAsync();
        }
        public async Task <bool> DeleteWikiAsync(int id)
        {
            var wiki = await _context.Wiki.FindAsync(id);
            if (wiki != null)
            {
                _context.Wiki.Remove(wiki);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        // STORY PLOT
        public async Task<List<StoryPlot>> GetAllStoryPlotsAsync() => await _context.StoryPlot.ToListAsync();
        public async Task<StoryPlot> GetStoryPlotByIdAsync(int id) => await _context.StoryPlot.FindAsync(id);
        public async Task AddStoryPlotAsync(StoryPlot storyPlot) { await _context.StoryPlot.AddAsync(storyPlot); await _context.SaveChangesAsync(); }
        public async Task UpdateStoryPlotAsync(StoryPlot storyPlot) { _context.StoryPlot.Update(storyPlot); await _context.SaveChangesAsync(); }
        public async Task<bool> DeleteStoryPlotAsync(int id) 
        { 
            var item = await _context.StoryPlot.FindAsync(id); 
            if (item != null) { _context.StoryPlot.Remove(item); 
                await _context.SaveChangesAsync(); 
                return true;
            }
            return false;
        }

        // CHARACTERS
        public async Task<List<Characters>> GetAllCharactersAsync() => await _context.Characters.ToListAsync();
        public async Task<Characters> GetCharacterByIdAsync(int id) => await _context.Characters.FindAsync(id);
        public async Task AddCharacterAsync(Characters character) { await _context.Characters.AddAsync(character); await _context.SaveChangesAsync(); }
        public async Task UpdateCharacterAsync(Characters character) { _context.Characters.Update(character); await _context.SaveChangesAsync(); }
        public async Task DeleteCharacterAsync(int id) { var item = await _context.Characters.FindAsync(id); if (item != null) { _context.Characters.Remove(item); await _context.SaveChangesAsync(); } }

        // GAME MECHANICS
        public async Task<List<GameMechanics>> GetAllGameMechanicsAsync() => await _context.GameMechanics.ToListAsync();
        public async Task<GameMechanics> GetGameMechanicByIdAsync(int id) => await _context.GameMechanics.FindAsync(id);
        public async Task AddGameMechanicAsync(GameMechanics gameMechanic) { await _context.GameMechanics.AddAsync(gameMechanic); await _context.SaveChangesAsync(); }
        public async Task UpdateGameMechanicAsync(GameMechanics gameMechanic) { _context.GameMechanics.Update(gameMechanic); await _context.SaveChangesAsync(); }
        public async Task DeleteGameMechanicAsync(int id) { var item = await _context.GameMechanics.FindAsync(id); if (item != null) { _context.GameMechanics.Remove(item); await _context.SaveChangesAsync(); } }

        // GAME ITEMS
        public async Task<List<GameItems>> GetAllGameItemsAsync() => await _context.GameItems.ToListAsync();
        public async Task<GameItems> GetGameItemByIdAsync(int id) => await _context.GameItems.FindAsync(id);
        public async Task AddGameItemAsync(GameItems gameItem) { await _context.GameItems.AddAsync(gameItem); await _context.SaveChangesAsync(); }
        public async Task UpdateGameItemAsync(GameItems gameItem) { _context.GameItems.Update(gameItem); await _context.SaveChangesAsync(); }
        public async Task DeleteGameItemAsync(int id) { var item = await _context.GameItems.FindAsync(id); if (item != null) { _context.GameItems.Remove(item); await _context.SaveChangesAsync(); } }

        // LOCATIONS
        public async Task<List<Locations>> GetAllLocationsAsync() => await _context.Locations.ToListAsync();
        public async Task<Locations> GetLocationByIdAsync(int id) => await _context.Locations.FindAsync(id);
        public async Task AddLocationAsync(Locations location) { await _context.Locations.AddAsync(location); await _context.SaveChangesAsync(); }
        public async Task UpdateLocationAsync(Locations location) { _context.Locations.Update(location); await _context.SaveChangesAsync(); }
        public async Task DeleteLocationAsync(int id) { var item = await _context.Locations.FindAsync(id); if (item != null) { _context.Locations.Remove(item); await _context.SaveChangesAsync(); } }
    }

}
