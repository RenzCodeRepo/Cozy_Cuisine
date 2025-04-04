using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Cozy_Cuisine.Models
{
    public class Contacts
    {
        [Key]
        public int MessageId { get; set; }

        public string EmailSubject { get; set; }

        public string EmailBody { get; set; }
        public DateTime SentDate { get; set; } = DateTime.UtcNow;

        [EmailAddress] 
        public string? EmailAddress { get; set; }
    }

}
