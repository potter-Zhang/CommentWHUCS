using CommentWHUCS.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509;

namespace CommentWHUCS.DAO
{
    public class CWCDbContext : DbContext
    {
        public CWCDbContext(DbContextOptions<CWCDbContext> options)
            : base(options)
        {
            Database.EnsureCreated(); //自动建库建表
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeachStar> TeachStars { get; set; }
        public DbSet<CompetitionStar> CompetitionStars { get; set; }
        public DbSet<ResearchStar> ResearchStars { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CompetitionType> CompetitionTypes { get; set; }
        public DbSet<CompetitionAward> CompetitionAwards { get; set; }
        public DbSet<CompetitionGroup> CompetitionGroups { get; set; }
        public DbSet<ResearchType> ResearchTypes { get; set; }
        public DbSet<ResearchAchievement> ResearchAchievements { get; set; }
        public DbSet<ResearchGroup> ResearchGroups { get; set; }
        public DbSet<ParticipateResearch> ParticipateResearches { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
