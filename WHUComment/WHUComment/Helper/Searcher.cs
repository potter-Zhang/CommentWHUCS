
using Microsoft.AspNetCore.Routing.Template;
using Org.BouncyCastle.Crypto.Signers;
using CommentWHUCS.Models;
    using System.Runtime.CompilerServices;
using System.Linq.Expressions;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.EntityFramework;

using Microsoft.Extensions.Options;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;
using System.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CommentWHUCS.Helper
{


    public class Searcher
    {

        //public static CWCDbContext ctx;
        
        private static CWCDbContext ctx;
        public static void ConfigContext(CWCDbContext _ctx)
        {
            ctx = _ctx;
        }

        /*static Searcher()
        {
            ctx = new CWCDbContext();
        }
        */

        

        // 1 Teachers: search by name or title, return TeacherId, Gender, Resfield
        public static List<Teacher> SearchTeachers(string name = "", string title = "")
        {
            
                return _SearchByCondition<Teacher>(ctx.Teachers, o => o.Name.Contains(name) && o.Title.Contains(title));
        }

        public static List<TeachStar> SearchTeachStar(string id)
        {
            
                return _SearchByCondition<TeachStar>(ctx.TeachStars, (o => o.TeacherId == id));
            
        }

        public static double SearchAverageTeachStar(string id)
        {
            return _SearchAverage(ctx.TeachStars, o => o.TeacherId == id, o => o.TeacherId, o => o.TotalStar);
        }

        public static List<CompStar> SearchCompStar(string id)
        {
            return _SearchByCondition<CompStar>(ctx.CompStars, (o => o.TeacherId == id));
        }

        public static double SearchAverageCompStar(string id)
        {
            return _SearchAverage(ctx.CompStars, o => o.TeacherId == id, o => o.TeacherId, o => o.TotalStar);
        }

        public static List<RSRCHStar> SearchRSRCHStar(string id)
        {
            return _SearchByCondition<RSRCHStar>(ctx.RSRCHStars, (o => o.TeacherId == id));
        }

        public static double SearchAverageRSRCHStar(string id)
        {
            return _SearchAverage(ctx.RSRCHStars, o => o.TeacherId == id, o => o.TeacherId, o => o.TotalStar);
            
        }

        public static List<Comment> SearchCommentsInTime(string commentType, string teacherId)
        {
            return _SearchByConditionInOrderDesc(ctx.Comments, o => o.CommentType == commentType && o.TeacherId == teacherId, o => o.Time);
        }

        public static List<Comment> SearchCommentsInLikes(string commentType, string teacherId)
        {
            return _SearchByConditionInOrderDesc(ctx.Comments, o => o.CommentType == commentType && o.TeacherId == teacherId, o => o.LikeNum);
        }

        public static Comment SearchCommentById(string commentId)
        {
            List<Comment> comments =_SearchByCondition(ctx.Comments, o => o.CommentId == commentId);
            if (comments.Count == 0)
                throw new Exception("comment not found");
            return comments[0];
        }


        public static List<CompAwardInfo> SearchAwardInfo(string compId)
        {
            return _SearchByCondition(ctx.CompAwardInfos, o => o.CompId == compId);
        }

        public static List<CompType> SearchCompType(string name, string firstType, string secondType, string BonusType)
        {
            return _SearchByCondition(ctx.CompTypes, o => o.CompName.Contains(name) && o.FirstType.Contains(firstType) && o.SecondType.Contains(secondType) && o.BonusType.Contains(BonusType));
        }

        private static double _SearchAverage<T, TKey>(DbSet<T> table, Expression<Func<T, bool>> condition, Func<T, TKey> group, Func<T, double> avg)
            where T : class
        {
            var q = table.Where(condition).GroupBy(group);

            return q == null ? 0 : q.First().Average(avg);
        }
        private static List<T> _SearchByCondition<T>(DbSet<T> table, Expression<Func<T, bool>> condition)
            where T : class
        {
            var q = table.Where(condition);
            return q.ToList();
        }

        private static List<T> _SearchByConditionInOrder<T, TKey>(DbSet<T> table, Expression<Func<T, bool>> condition, Expression<Func<T, TKey>> order)
            where T : class
        {
            var q = table.Where(condition).OrderBy(order);
            return q.ToList();
        }

        private static List<T> _SearchByConditionInOrderDesc<T, TKey>(DbSet<T> table, Expression<Func<T, bool>> condition, Expression<Func<T, TKey>> order)
            where T : class
        {
            var q = table.Where(condition).OrderByDescending(order);
            return q.ToList();
        }

        


    }   
}
