using Cozy_Cuisine.Models;
using Microsoft.EntityFrameworkCore;

namespace Cozy_Cuisine.Data.IServices
{
    public interface IManageServices
    {
        Task<List<Comments>> GetAllComments();
    }
}
