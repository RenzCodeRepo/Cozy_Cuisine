﻿using Cozy_Cuisine.Data.IRepositories;
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

        // Patches
        public async Task<IEnumerable<Patches>> GetAllPatchesAsync()
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

        public async Task DeletePatchAsync(int patchId)
        {
            var patch = await _context.Patches.FindAsync(patchId);
            if (patch != null)
            {
                _context.Patches.Remove(patch);
                await _context.SaveChangesAsync();
            }
        }

        // Bug Reports
        public async Task<IEnumerable<BugReport>> GetBugReportsByPatchIdAsync(int patchId)
        {
            return await _context.BugReport
                .Where(b => b.PatchId == patchId)
                .Include(b => b.Comments)
                .ToListAsync();
        }
        public async Task<IEnumerable<BugReport>> GetAllBugReports()
        {
            return await _context.BugReport
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
        public async Task<IEnumerable<Comments>> GetCommentsByBugIdAsync(int bugId)
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


    }
}
