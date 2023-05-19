using CommentWHUCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentWHUCS.SearchHelper
{
    public class Inserter
    {
        private static CWCDbContext ctx;
        public Inserter(CWCDbContext context) 
        {
            ctx = context;
        }

        public static void AddTeachStar(TeachStar ts)
        {
            
            ctx.TeachStars.Add(ts);
            ctx.SaveChanges();
            
        }

        public static void AddCompStar(CompStar cs)
        {
            
            ctx.CompStars.Add(cs);
            ctx.SaveChanges();
            
        }

        public static void AddRSRCHStar(RSRCHStar rs) 
        {
            
            ctx.RSRCHStars.Add(rs);
            ctx.SaveChanges();
            
        }

        public static void AddComment(Comment comment)
        {
            
            ctx.Comments.Add(comment);
            ctx.SaveChanges();
            
        }
    }
}
