using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class DownloadPageVM
    {
        public List<Patches> Patches { get; set; } = new List<Patches>();
        public Patches LatestPatch { get; set; } = new Patches();
        public GameReview? GameReview { get; set; } = new GameReview();
        public List<GameReview> RandomReviews { get; set; } = new List<GameReview>();
    }
}
