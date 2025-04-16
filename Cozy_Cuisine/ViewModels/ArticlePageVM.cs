using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class ArticlePageVM
    {
        public Notice? Article { get; set; } = new Notice();
        public List<Notice>? Articles { get; set; } = new List<Notice>();
        public List<Notice>? Features { get; set; } = new List<Notice>();
    }
}
