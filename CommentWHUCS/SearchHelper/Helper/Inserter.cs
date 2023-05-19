using SearchHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchHelper.Helper
{
    public class Inserter
    {
        public static void AddTeachStar(TeachStar ts)
        {
            using (var ctx = new CWCDbContext())
            {
                ctx.TeachStars.Add(ts);
                ctx.SaveChanges();
            }
        }

        public static void AddCompStar(CompStar cs)
        {
            using (var ctx = new CWCDbContext())
            {
                ctx.CompStars.Add(cs);
                ctx.SaveChanges();
            }
        }

        public static void AddRSRCHStar(RSRCHStar rs) 
        {
            using (var ctx = new CWCDbContext())
            {
                ctx.RSRCHStars.Add(rs);
                ctx.SaveChanges();
            }
        }

        public static void AddComment(Comment comment)
        {
            using (var ctx = new CWCDbContext())
            {
                ctx.Comments.Add(comment);
                ctx.SaveChanges();
            }
        }
    }
}
