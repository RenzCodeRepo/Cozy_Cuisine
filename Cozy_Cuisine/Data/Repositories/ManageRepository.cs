using Cozy_Cuisine.Data.IRepositories;
using Cozy_Cuisine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cozy_Cuisine.Data.Repositories
{
    public class ManageRepository : IManageRepository
    {
        private readonly ApplicationDbContext _context;

        public ManageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

      
        // 🔹 Credit CRUD
        public async Task<List<Credit>> GetAllCreditsAsync() => await _context.Credit.ToListAsync();
        public async Task<(bool IsSuccess, Credit? CreditData)> GetCreditByIdAsync(int id)
        {
            var credit = await _context.Credit.FindAsync(id);
            return credit != null ? (true, credit) : (false, null);
        }
        public async Task AddCreditAsync(Credit credit)
        {
            _context.Credit.Add(credit);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCreditAsync(Credit credit)
        {
            _context.Credit.Update(credit);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteCreditAsync(int id)
        {
            var credit = await _context.Credit.FindAsync(id);
            if (credit != null)
            {
                _context.Credit.Remove(credit);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        // 🔹 About CRUD
        public async Task<List<About>> GetAllAboutsAsync() => await _context.About.ToListAsync();
        public async Task<About> GetAboutByIdAsync(int id) => await _context.About.FindAsync(id);
        public async Task AddAboutAsync(About about)
        {
            _context.About.Add(about);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAboutAsync(About about)
        {
            _context.About.Update(about);
            await _context.SaveChangesAsync();
        }
        public async Task <bool> DeleteAboutAsync(int id)
        {
            var about = await _context.About.FindAsync(id);
            if (about != null)
            {
                _context.About.Remove(about);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        // 🔹 Gallery CRUD
        public async Task<List<Gallery>> GetAllGalleryAsync() => await _context.Gallery.ToListAsync();
        public async Task<Gallery> GetGalleryByIdAsync(int id) => await _context.Gallery.FindAsync(id);
        public async Task AddGalleryAsync(Gallery gallery)
        {
            _context.Gallery.Add(gallery);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateGalleryAsync(Gallery gallery)
        {
            _context.Gallery.Update(gallery);
            await _context.SaveChangesAsync();
        }
        public async Task <bool> DeleteGalleryAsync(int id)
        {
            var gallery = await _context.Gallery.FindAsync(id);
            if (gallery != null)
            {
                _context.Gallery.Remove(gallery);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        // 🔹 FAQ CRUD
        public async Task<List<FAQ>> GetAllFAQsAsync()
        {
            if (_context == null)
            {
                throw new Exception("Database context is null in FAQRepository.");
            }

            return await _context.FAQ.ToListAsync();

        }
        public async Task<FAQ> GetFAQByIdAsync(int id) => await _context.FAQ.FindAsync(id);
        public async Task AddFAQAsync(FAQ faq)
        {
            _context.FAQ.Add(faq);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateFAQAsync(FAQ faq)
        {
            _context.FAQ.Update(faq);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteFAQAsync(int id)
        {
            var faq = await _context.FAQ.FindAsync(id);
            if (faq == null)
            {
                return false; // Record not found
            }

            _context.FAQ.Remove(faq);
            await _context.SaveChangesAsync();
            return true; // Successfully deleted
        }

        // 🔹 Notice CRUD
        public async Task<List<Notice>> GetAllNoticesAsync() => await _context.Notice.ToListAsync();
        public async Task<(bool IsSuccess, Notice? NoticeData)> GetNoticeByIdAsync(int id)
        {
            var notice = await _context.Notice.FindAsync(id);
            return notice != null ? (true, notice) : (false, null);
            
        }
        public async Task AddNoticeAsync(Notice notice)
        {
            _context.Notice.Add(notice);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateNoticeAsync(Notice notice)
        {
            _context.Notice.Update(notice);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteNoticeAsync(int id)
        {
            var notice = await _context.Notice.FindAsync(id);
            if (notice != null)
            {
                _context.Notice.Remove(notice);
                await _context.SaveChangesAsync();
            }
        }

        // 🔹 Visitors (Only Add and Get)
        public async Task<List<Visitor>> GetAllVisitorsAsync() => await _context.Visitor.ToListAsync();
        public async Task AddVisitorAsync(Visitor visitor)
        {
            _context.Visitor.Add(visitor);
            await _context.SaveChangesAsync();
        }
        public async Task<int> GetDailyVisitorsAsync()
        {
            return await _context.Visitor
                .CountAsync(d => d.DateVisited.Date == DateTime.Today);
        }


        // Game Downloads
        public async Task<List<GameDownloads>> GetAllDownloadsAsync()
        {
            return await _context.GameDownloads.ToListAsync();
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

        public async Task<GameReview> GetReviewByIdAsync(int reviewId)
        {
            return await _context.GameReview.FirstOrDefaultAsync(r => r.ReviewId == reviewId);
        }
        public async Task<List<GameReview>> GetAllReviewsAsync()
        {
            return await _context.GameReview.ToListAsync();
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
