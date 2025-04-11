using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.Data.IRepositories
{
    public interface IPatchRepository
    {
        Task<Dictionary<string, int>> GetPatchDictionaryAsync();
        Task<Patches> GetLatestPatch();

        // Patches
        Task<List<Patches>> GetAllPatchesAsync();
        Task<Patches> GetPatchByIdAsync(int patchId);
        Task AddPatchAsync(Patches patch);
        Task UpdatePatchAsync(Patches patch);
        Task <bool> DeletePatchAsync(int patchId);
        Task <List<Patches>> LatestFourPatches();

        // Bug Reports
        Task<List<BugReport>> GetBugReportsByPatchIdAsync(int patchId);
        Task<List<BugReport>> GetAllBugReports();
        Task<BugReport> GetBugReportByIdAsync(int bugId);
        Task AddBugReportAsync(BugReport bugReport);
        Task UpdateBugReportAsync(BugReport bugReport);
        Task DeleteBugReportAsync(int bugId);

        // Comments
        Task<List<Comments>> GetCommentsByBugIdAsync(int bugId);
        Task<List<Comments>> GetAllCommentsAsync();
        Task<Comments> GetCommentByIdAsync(int commentId);
        Task AddCommentAsync(Comments comment);
        Task UpdateCommentAsync(Comments comment);
        Task DeleteCommentAsync(int commentId);
        Task<int> GetTotalCountAsync();
        Task<List<Comments>> GetFilteredCommentsAsync(string search);
    }
}
