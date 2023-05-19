
using Microsoft.AspNetCore.Routing.Template;
using Org.BouncyCastle.Crypto.Signers;
using SearchHelper.Models;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.EntityFramework;

using Microsoft.Extensions.Options;
using System.Xml.Serialization;
//using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CommentWHUCS.SearchHelper
{


    public class Searcher
    {

        //public static CWCDbContext ctx;
        private static string _name = "";
        private static string _title = "";
  
            
        /*static Searcher()
        {
            ctx = new CWCDbContext();
        }
        */

        public Searcher Name(string name)
        {
            _name = name;
            return this; 
        }

        public Searcher Title(string title)
        {
            _title = title;
            return this;
        }

        // 1 Teachers: search by name or title, return TeacherId, Gender, Resfield
        public static List<Teacher> SearchTeachers(string name, string title)
        {
            using (var ctx = new CWCDbContext())
            {
                return _SearchByCondition(ctx.Teachers, o => o.Name.Contains(name) && o.Title.Contains(title));
               
            }

        }

        public static List<TeachStar> SearchTeachStar(string id)
        {
            using (var ctx = new CWCDbContext())
            {
                return _SearchByCondition<TeachStar>(ctx.TeachStars, (o => o.Id == id));
            }
        }

        public static double SearchAverageTeachStar(string id)
        {
            using (var ctx = new CWCDbContext())
            {
                return _SearchAverage(ctx.TeachStars, o => o.Id == id, o => o.Id, o => o.TotalStar);
            }
        }

        public static List<CompStar> SearchCompStar(string id)
        {
            using (var ctx = new CWCDbContext())
            {
                return _SearchByCondition<CompStar>(ctx.CompStars, (o => o.Id == id));
            }
        }

        public static double SearchAverageCompStar(string id)
        {
            using (var ctx = new CWCDbContext())
            {
                
                return _SearchAverage(ctx.CompStars, o => o.Id == id, o => o.Id, o => o.TotalStar);
            }
        }

        public static List<RSRCHStar> SearchRSRCHStar(string id)
        {
            using (var ctx = new CWCDbContext())
            {  
                return _SearchByCondition<RSRCHStar>(ctx.RSRCHStars, (o => o.Id == id));
            }
        }

        public static double SearchAverageRSRCHStar(string id)
        {
            using (var ctx = new CWCDbContext())
            {
                return _SearchAverage(ctx.RSRCHStars, o => o.Id == id, o => o.Id, o => o.TotalStar);
            }
            
        }

        public static List<Comment> SearchComments(string commentType, string teacherId)
        {
            using (var ctx = new CWCDbContext())
            {
                return _SearchByCondition(ctx.Comments, o => o.CommentType == commentType && o.TeacherId.Contains(teacherId));
            }
        }

        public static List<CompAwardInfo> SearchAwardInfo(string compId)
        {
            using (var ctx = new CWCDbContext())
            {
                return _SearchByCondition(ctx.CompAwardInfos, o => o.CompId == compId);
            }
        }

        public static List<CompType> SearchCompType(string name, string firstType, string secondType, string BonusType)
        {
            using (var ctx = new CWCDbContext())
            {
                return _SearchByCondition(ctx.CompTypes, o => o.CompName.Contains(name) && o.FirstType.Contains(firstType)
                    && o.SecondType.Contains(secondType) && o.BonusType.Contains(BonusType));
            }
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



        
    }   
}
