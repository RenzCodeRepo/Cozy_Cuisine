using Cozy_Cuisine.Data.IRepositories;
using Cozy_Cuisine.Models;
using System;

namespace Cozy_Cuisine.Data.Repositories
{
    public class ManageRepository : IManageRepository
    {
        private readonly AppDbContext _context;

        public ManageRepository(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 Contacts CRUD
        public async Task<IEnumerable<Contacts>> GetAllContactsAsync() => await _context.Contacts.ToListAsync();
        public async Task<Contacts> GetContactByIdAsync(int id) => await _context.Contacts.FindAsync(id);
        public async Task AddContactAsync(Contacts contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateContactAsync(Contacts contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteContactAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }

        // 🔹 Credit CRUD
        public async Task<IEnumerable<Credit>> GetAllCreditsAsync() => await _context.Credit.ToListAsync();
        public async Task<Credit> GetCreditByIdAsync(int id) => await _context.Credit.FindAsync(id);
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
        public async Task DeleteCreditAsync(int id)
        {
            var credit = await _context.Credit.FindAsync(id);
            if (credit != null)
            {
                _context.Credit.Remove(credit);
                await _context.SaveChangesAsync();
            }
        }

        // 🔹 About CRUD
        public async Task<IEnumerable<About>> GetAllAboutsAsync() => await _context.About.ToListAsync();
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
        public async Task DeleteAboutAsync(int id)
        {
            var about = await _context.About.FindAsync(id);
            if (about != null)
            {
                _context.About.Remove(about);
                await _context.SaveChangesAsync();
            }
        }

        // 🔹 Gallery CRUD
        public async Task<IEnumerable<Gallery>> GetAllGalleryAsync() => await _context.Gallery.ToListAsync();
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
        public async Task DeleteGalleryAsync(int id)
        {
            var gallery = await _context.Gallery.FindAsync(id);
            if (gallery != null)
            {
                _context.Gallery.Remove(gallery);
                await _context.SaveChangesAsync();
            }
        }

        // 🔹 FAQ CRUD
        public async Task<IEnumerable<FAQ>> GetAllFAQsAsync() => await _context.FAQ.ToListAsync();
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
        public async Task DeleteFAQAsync(int id)
        {
            var faq = await _context.FAQ.FindAsync(id);
            if (faq != null)
            {
                _context.FAQ.Remove(faq);
                await _context.SaveChangesAsync();
            }
        }

        // 🔹 Notice CRUD
        public async Task<IEnumerable<Notice>> GetAllNoticesAsync() => await _context.Notice.ToListAsync();
        public async Task<Notice> GetNoticeByIdAsync(int id) => await _context.Notice.FindAsync(id);
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
        public async Task<IEnumerable<Visitor>> GetAllVisitorsAsync() => await _context.Visitor.ToListAsync();
        public async Task AddVisitorAsync(Visitor visitor)
        {
            _context.Visitor.Add(visitor);
            await _context.SaveChangesAsync();
        }
    }
}
