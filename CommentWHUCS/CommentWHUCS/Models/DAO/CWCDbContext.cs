using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509;

namespace CommentWHUCS.Models.DAO
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
        public DbSet<CompStar> CompStars { get; set; }
        public DbSet<RSRCHStar> RSRCHStars { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CompType> CompTypes { get; set; }
        public DbSet<CompAwardInfo> CompAwardInfos { get; set; }
        public DbSet<CompGroup> CompGroups { get; set; }
        public DbSet<PartComp> PartComps { get; set; }
        public DbSet<RSRCHType> RSRCHTypes { get; set; }
        public DbSet<RSRCHInfo> RSRCHInfos { get; set; }
        public DbSet<RSRCHGroup> RSRCHGroups { get; set; }
        public DbSet<PartRSRCH> PartRSRCHes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
