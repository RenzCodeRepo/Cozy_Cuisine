using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class CharacterManagementVM
    {
        public Characters NewCharacter { get; set; } = new Characters();
        public List<Characters> Characters { get; set; } = new List<Characters>();
    }
}
