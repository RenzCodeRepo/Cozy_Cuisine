using Cozy_Cuisine.Models;
using Microsoft.EntityFrameworkCore;

namespace Cozy_Cuisine.Data.IRepositories
{
    public interface IManageRepository
    {
        // Contacts
        Task<IEnumerable<Contacts>> GetAllContactsAsync();
        Task<Contacts> GetContactByIdAsync(int id);
        Task AddContactAsync(Contacts contact);
        Task UpdateContactAsync(Contacts contact);
        Task DeleteContactAsync(int id);

        // Credit
        Task<IEnumerable<Credit>> GetAllCreditsAsync();
        Task<Credit> GetCreditByIdAsync(int id);
        Task AddCreditAsync(Credit credit);
        Task UpdateCreditAsync(Credit credit);
        Task DeleteCreditAsync(int id);

        // About
        Task<IEnumerable<About>> GetAllAboutsAsync();
        Task<About> GetAboutByIdAsync(int id);
        Task AddAboutAsync(About about);
        Task UpdateAboutAsync(About about);
        Task DeleteAboutAsync(int id);

        // Gallery
        Task<IEnumerable<Gallery>> GetAllGalleryAsync();
        Task<Gallery> GetGalleryByIdAsync(int id);
        Task AddGalleryAsync(Gallery gallery);
        Task UpdateGalleryAsync(Gallery gallery);
        Task DeleteGalleryAsync(int id);

        // FAQ
        Task<List<FAQ>> GetAllFAQsAsync();
        Task<FAQ> GetFAQByIdAsync(int id);
        Task AddFAQAsync(FAQ faq);
        Task UpdateFAQAsync(FAQ faq);
        Task<bool> DeleteFAQAsync(int id);

        // Notice
        Task<IEnumerable<Notice>> GetAllNoticesAsync();
        Task<Notice> GetNoticeByIdAsync(int id);
        Task AddNoticeAsync(Notice notice);
        Task UpdateNoticeAsync(Notice notice);
        Task DeleteNoticeAsync(int id);

        // Visitor (Only Add and Get)
        Task<IEnumerable<Visitor>> GetAllVisitorsAsync();
        Task AddVisitorAsync(Visitor visitor);
        Task<int> GetDailyVisitorsAsync();

        // Game Downloads
        Task<IEnumerable<GameDownloads>> GetAllDownloadsAsync();
        Task AddDownloadAsync(GameDownloads download);
        Task UpdateDownloadAsync(GameDownloads download);
        Task DeleteDownloadAsync(int downloadId);

        // Game Reviews
        Task<GameReview> GetReviewByIdAsync(int reviewId);
        Task<IEnumerable<GameReview>> GetAllReviewsAsync();
        Task AddReviewAsync(GameReview review);
        Task UpdateReviewAsync(GameReview review);
        Task DeleteReviewAsync(int reviewId);

    }
}
