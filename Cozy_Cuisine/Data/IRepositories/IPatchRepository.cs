using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.Data.IRepositories
{
    public interface IPatchRepository
    {
        // Patches
        Task<IEnumerable<Patches>> GetAllPatchesAsync();
        Task<Patches> GetPatchByIdAsync(int patchId);
        Task AddPatchAsync(Patches patch);
        Task UpdatePatchAsync(Patches patch);
        Task DeletePatchAsync(int patchId);

        // Bug Reports
        Task<IEnumerable<BugReport>> GetBugReportsByPatchIdAsync(int patchId);
        Task<BugReport> GetBugReportByIdAsync(int bugId);
        Task AddBugReportAsync(BugReport bugReport);
        Task UpdateBugReportAsync(BugReport bugReport);
        Task DeleteBugReportAsync(int bugId);

        // Comments
        Task<IEnumerable<Comments>> GetCommentsByBugIdAsync(int bugId);
        Task<Comments> GetCommentByIdAsync(int commentId);
        Task AddCommentAsync(Comments comment);
        Task UpdateCommentAsync(Comments comment);
        Task DeleteCommentAsync(int commentId);
    }
}
