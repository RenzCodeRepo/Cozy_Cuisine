using Cozy_Cuisine.Models;
using Microsoft.EntityFrameworkCore;

namespace Cozy_Cuisine.Data.IRepositories
{
    public interface IManageRepository
    {
       
        // Credit
        Task<List<Credit>> GetAllCreditsAsync();
        Task<(bool IsSuccess, Credit? CreditData)> GetCreditByIdAsync(int id);
        Task AddCreditAsync(Credit credit);
        Task UpdateCreditAsync(Credit credit);
        Task <bool> DeleteCreditAsync(int id);

        // About
        Task<List<About>> GetAllAboutsAsync();
        Task<About> GetAboutByIdAsync(int id);
        Task AddAboutAsync(About about);
        Task UpdateAboutAsync(About about);
        Task <bool>DeleteAboutAsync(int id);

        // Gallery
        Task<List<Gallery>> GetAllGalleryAsync();
        Task<Gallery> GetGalleryByIdAsync(int id);
        Task AddGalleryAsync(Gallery gallery);
        Task UpdateGalleryAsync(Gallery gallery);
        Task <bool> DeleteGalleryAsync(int id);

        // FAQ
        Task<List<FAQ>> GetAllFAQsAsync();
        Task<FAQ> GetFAQByIdAsync(int id);
        Task AddFAQAsync(FAQ faq);
        Task UpdateFAQAsync(FAQ faq);
        Task<bool> DeleteFAQAsync(int id);

        // Notice
        Task<List<Notice>> GetAllNoticesAsync();
        Task<(bool IsSuccess, Notice? NoticeData)> GetNoticeByIdAsync(int id);
        Task AddNoticeAsync(Notice notice);
        Task UpdateNoticeAsync(Notice notice);
        Task DeleteNoticeAsync(int id);

        // Visitor (Only Add and Get)
        Task<List<Visitor>> GetAllVisitorsAsync();
        Task AddVisitorAsync(Visitor visitor);
        Task<int> GetDailyVisitorsAsync();

        // Game Downloads
        Task<List<GameDownloads>> GetAllDownloadsAsync();
        Task AddDownloadAsync(GameDownloads download);
        Task UpdateDownloadAsync(GameDownloads download);
        Task DeleteDownloadAsync(int downloadId);

        // Game Reviews
        Task<GameReview> GetReviewByIdAsync(int reviewId);
        Task<List<GameReview>> GetAllReviewsAsync();
        Task AddReviewAsync(GameReview review);
        Task UpdateReviewAsync(GameReview review);
        Task DeleteReviewAsync(int reviewId);

        // Contacts
        Task<List<Contacts>> GetAllContactsAsync();
        Task<Contacts> GetContactByIdAsync(int id);
        Task CreateContactAsync(Contacts contact);
        Task<Contacts> UpdateContactAsync(int id, Contacts contact);
        Task<bool> DeleteContactAsync(int id);
    }
}
