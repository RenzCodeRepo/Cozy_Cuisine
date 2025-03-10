using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Cozy_Cuisine.Models
{
    public class Contacts
    {
        [Key]
        public int ContactId { get; set; }

        public string Subject { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
