using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.EntityFramework;

using Microsoft.Extensions.Options;
using System.Xml.Serialization;
//using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Configuration;

namespace SearchHelper.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class CWCDbContext : DbContext
    {
        
        public CWCDbContext(/*DbContextOptions<CWCDbContext> options*/)
            /*: base(options)*/: base("name=evaldb")
        {
            /*this.Database.EnsureCreated(); //自动建库建表*/
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CWCDbContext>());
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
