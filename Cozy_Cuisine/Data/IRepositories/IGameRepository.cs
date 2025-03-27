using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.Data.IRepositories
{
    public interface IGameRepository
    {
        // Game Downloads
        Task<IEnumerable<GameDownloads>> GetAllDownloadsAsync();
        Task AddDownloadAsync(GameDownloads download);
        Task UpdateDownloadAsync(GameDownloads download);
        Task DeleteDownloadAsync(int downloadId);

        // Game Reviews
        Task<GameReview> GetReviewByIdAsync(int reviewId);
        Task AddReviewAsync(GameReview review);
        Task UpdateReviewAsync(GameReview review);
        Task DeleteReviewAsync(int reviewId);
    }
}
