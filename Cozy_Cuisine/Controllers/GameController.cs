using Cozy_Cuisine.Data.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Cozy_Cuisine.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;

        public GameController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
