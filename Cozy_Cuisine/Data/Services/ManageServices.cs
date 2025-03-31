using Cozy_Cuisine.Data.IServices;
using Cozy_Cuisine.Models;
using Microsoft.EntityFrameworkCore;

namespace Cozy_Cuisine.Data.Services
{
    public class ManageServices : IManageServices
    {
        private readonly ApplicationDbContext _context;
        public ManageServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Comments>> GetAllComments()
        {
            return _context.Comments.ToListAsync();
        }
    }
}
