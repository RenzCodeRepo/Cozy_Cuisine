
using Cozy_Cuisine.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cozy_Cuisine.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<About> About { get; set; }
        public DbSet<BugReport> BugReport { get; set; }
        public DbSet<Characters> Characters { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Credit> Credit { get; set; }
        public DbSet<FAQ> FAQ { get; set; }
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<GameDownloads> GameDownloads { get; set; }
        public DbSet<GameItems> GameItems { get; set; }
        public DbSet<GameMechanics> GameMechanics { get; set; }
        public DbSet<GameReview> GameReview { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Notice> Notice { get; set; }
        public DbSet<Patches> Patches { get; set; }
        public DbSet<StoryPlot> StoryPlot { get; set; }
        public DbSet<Visitor> Visitor { get; set; }
        public DbSet<Wiki> Wiki { get; set; }
    }
}
