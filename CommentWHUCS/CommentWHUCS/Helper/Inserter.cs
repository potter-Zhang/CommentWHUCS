using CommentWHUCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentWHUCS.Helper
{
    public class Inserter
    {
        private static CWCDbContext ctx;
        public static void ConfigContext(CWCDbContext context) 
        {
            ctx = context;
        }

        public static void AddTeachStar(TeachStar ts)
        {
            ts.Id = new Guid().ToString();
            ctx.TeachStars.Add(ts);
            ctx.SaveChanges();
            
        }

        public static void AddCompStar(CompStar cs)
        {
            cs.Id = new Guid().ToString();
            ctx.CompStars.Add(cs);
            ctx.SaveChanges();
            
        }

        public static void AddRSRCHStar(RSRCHStar rs) 
        {
            rs.Id = new Guid().ToString();
            
            ctx.RSRCHStars.Add(rs);
            ctx.SaveChanges();
            
        }

        public static void AddComment(Comment comment)
        {
            comment.Time = DateTime.Now;
            comment.CommentId = new Guid().ToString();
            
            ctx.Comments.Add(comment);
            ctx.SaveChanges();
            
        }
    }
}
