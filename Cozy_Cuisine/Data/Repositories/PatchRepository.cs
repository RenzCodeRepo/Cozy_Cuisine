using Cozy_Cuisine.Data.IRepositories;
using Cozy_Cuisine.Models;
using Microsoft.EntityFrameworkCore;

namespace Cozy_Cuisine.Data.Repositories
{
    public class PatchRepository : IPatchRepository
    {
        private readonly ApplicationDbContext _context;

        public PatchRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<Dictionary<string, int>> GetPatchDictionaryAsync()
        {
            var patches = await _context.Patches.ToListAsync();
            return patches.ToDictionary(p => p.Version, p => p.PatchId);
        }

        public async Task<Patches> GetLatestPatch()
        {
            var patches = await _context.Patches.OrderBy(p => p.ReleaseDate).LastAsync();
            return patches;
        }

        // Patches
        public async Task<List<Patches>> GetAllPatchesAsync()
        {
            return await _context.Patches.Include(p => p.BugReport).ToListAsync();
        }

        public async Task<Patches> GetPatchByIdAsync(int patchId)
        {
            return await _context.Patches.Include(p => p.BugReport)
                                         .FirstOrDefaultAsync(p => p.PatchId == patchId);
        }

        public async Task AddPatchAsync(Patches patch)
        {
            await _context.Patches.AddAsync(patch);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePatchAsync(Patches patch)
        {
            _context.Patches.Update(patch);
            await _context.SaveChangesAsync();
        }

        public async Task <bool> DeletePatchAsync(int patchId)
        {
            var patch = await _context.Patches.FindAsync(patchId);
            if (patch != null)
            {
                _context.Patches.Remove(patch);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task <List<Patches>> LatestFourPatches()
        {
            return await _context.Patches.OrderByDescending(p => p.ReleaseDate).Skip(1).Take(3).ToListAsync();
        }
        // Bug Reports
        public async Task<List<BugReport>> GetBugReportsByPatchIdAsync(int patchId)
        {
            return await _context.BugReport
                .Where(b => b.PatchId == patchId)
                .Include(b => b.Comments)
                .ToListAsync();
        }
        public async Task<List<BugReport>> GetAllBugReports()
        {
            return await _context.BugReport
                .Include(b => b.Patches)
                .Include(b => b.Comments)
                .ToListAsync();
        }

        public async Task<BugReport> GetBugReportByIdAsync(int bugId)
        {
            return await _context.BugReport
                .Include(b => b.Comments)
                .FirstOrDefaultAsync(b => b.BugId == bugId);
        }

        public async Task AddBugReportAsync(BugReport bugReport)
        {
            await _context.BugReport.AddAsync(bugReport);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBugReportAsync(BugReport bugReport)
        {
            _context.BugReport.Update(bugReport);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBugReportAsync(int bugId)
        {
            var bugReport = await _context.BugReport.FindAsync(bugId);
            if (bugReport != null)
            {
                _context.BugReport.Remove(bugReport);
                await _context.SaveChangesAsync();
            }
        }

        // Comments
        public async Task<List<Comments>> GetCommentsByBugIdAsync(int bugId)
        {
            return await _context.Comments.Where(c => c.BugId == bugId).ToListAsync();
        }

        public async Task<Comments> GetCommentByIdAsync(int commentId)
        {
            return await _context.Comments.FirstOrDefaultAsync(c => c.CommentId == commentId);
        }

        public async Task AddCommentAsync(Comments comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCommentAsync(Comments comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Comments.CountAsync();
        }

        public async Task<List<Comments>> GetFilteredCommentsAsync(string search)
        {
            var query = _context.Comments.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.Message.Contains(search) || c.Username.Contains(search));
            }

            return await query.ToListAsync();
        }
        public async Task<List<Comments>> GetAllCommentsAsync()
        {
            return await _context.Comments.ToListAsync();
        }
    }
}
