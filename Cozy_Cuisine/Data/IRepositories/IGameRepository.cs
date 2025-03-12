using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.Data.IRepositories
{
    public interface IGameRepository
    {
        // Game Downloads
        Task<IEnumerable<GameDownloads>> GetAllDownloadsAsync();
        Task<GameDownloads> GetDownloadByIdAsync(int downloadId);
        Task AddDownloadAsync(GameDownloads download);
        Task UpdateDownloadAsync(GameDownloads download);
        Task DeleteDownloadAsync(int downloadId);

        // Game Reviews
        Task<IEnumerable<GameReview>> GetReviewsByDownloadIdAsync(int downloadId);
        Task<GameReview> GetReviewByIdAsync(int reviewId);
        Task AddReviewAsync(GameReview review);
        Task UpdateReviewAsync(GameReview review);
        Task DeleteReviewAsync(int reviewId);
    }
}
