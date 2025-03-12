using Cozy_Cuisine.Data.IRepositories;
using Cozy_Cuisine.Models;
using Microsoft.EntityFrameworkCore;

namespace Cozy_Cuisine.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _context;

        public GameRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Game Downloads
        public async Task<IEnumerable<GameDownloads>> GetAllDownloadsAsync()
        {
            return await _context.GameDownloads.Include(g => g.GameReview).ToListAsync();
        }

        public async Task<GameDownloads> GetDownloadByIdAsync(int downloadId)
        {
            return await _context.GameDownloads.Include(g => g.GameReview)
                                               .FirstOrDefaultAsync(g => g.DownloadId == downloadId);
        }

        public async Task AddDownloadAsync(GameDownloads download)
        {
            await _context.GameDownloads.AddAsync(download);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDownloadAsync(GameDownloads download)
        {
            _context.GameDownloads.Update(download);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDownloadAsync(int downloadId)
        {
            var download = await _context.GameDownloads.FindAsync(downloadId);
            if (download != null)
            {
                _context.GameDownloads.Remove(download);
                await _context.SaveChangesAsync();
            }
        }

        // Game Reviews
        public async Task<IEnumerable<GameReview>> GetReviewsByDownloadIdAsync(int downloadId)
        {
            return await _context.GameReview.Where(r => r.DownloadId == downloadId).ToListAsync();
        }

        public async Task<GameReview> GetReviewByIdAsync(int reviewId)
        {
            return await _context.GameReview.FirstOrDefaultAsync(r => r.ReviewId == reviewId);
        }

        public async Task AddReviewAsync(GameReview review)
        {
            await _context.GameReview.AddAsync(review);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReviewAsync(GameReview review)
        {
            _context.GameReview.Update(review);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(int reviewId)
        {
            var review = await _context.GameReview.FindAsync(reviewId);
            if (review != null)
            {
                _context.GameReview.Remove(review);
                await _context.SaveChangesAsync();
            }
        }
    }
}
