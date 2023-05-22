using CommentWHUCS.Models.DAO;
using System.Data.Entity;

namespace CommentWHUCS.Models.Service
{
    public class StarService
    {
        private CWCDbContext _ctx;
        public StarService(CWCDbContext ctx)
        {
            _ctx = ctx;
        }
        

        public TeachStar SearchTeachStar(string teacherId)
        {
            if (_ctx.TeachStars == null)
                throw new Exception("teachstar is null");
            var group = _ctx.TeachStars
                .Where(o => o.TeacherId == teacherId)
                .GroupBy(o => o.TeacherId)
                .Select(o => new TeachStar
                {
                    Id = "",
                    TeacherId = o.First().TeacherId,
                    UserId = "",
                    ScoreStar = (int)o.Average(o => o.ScoreStar),
                    TeachingStar = (int)o.Average(o => o.TeachingStar),
                    TaskStar = (int)o.Average(o => o.TaskStar),
                    CommStar = (int)o.Average(o => o.CommStar),
                    TotalStar = o.Average(o => o.TotalStar)
                }
                );
            if (group.Count() == 0)
                throw new Exception("can't find teachstar of this teacher");
            return group.First();
            
        }

        public CompStar SearchCompStar(string teacherId)
        {
            if (_ctx.CompStars == null)
                throw new Exception("compstar is null");
            var group = _ctx.CompStars
                .Where(o => o.TeacherId == teacherId)
                .GroupBy(o => o.TeacherId)
                .Select(o => new CompStar 
                {
                    Id = "",
                    TeacherId = o.First().TeacherId,
                    UserId = "",
                    ExpStar = (int)o.Average(o => o.ExpStar),
                    FundsStar = (int)o.Average(o => o.FundsStar),
                    ResStar = (int)o.Average(o => o.ResStar),
                    TeachingStar = (int)o.Average(o => o.TeachingStar),
                    TotalStar = o.Average(o => o.TotalStar)
                });

            if (group.Count() == 0)
                throw new Exception("can't find compstar of this teacher");
            return group.First();
            
        }

        public dynamic SearchRSRCHStar(string teacherId)
        {
            if (_ctx.RSRCHStars == null)
                throw new Exception("RSRCHStar is null");
            var group = _ctx.RSRCHStars
                .Where(o => o.TeacherId == teacherId)
                .GroupBy(o => o.TeacherId)
                .Select(o => new RSRCHStar
                {
                    Id = "",
                    TeacherId = o.First().TeacherId,
                    UserId = "",
                    ACStar = (int)o.Average(o => o.ACStar),
                    FundsStar = (int)o.Average(o => o.FundsStar),
                    ResStar = (int)o.Average(o => o.ResStar),
                    CharStar = (int)o.Average(o => o.CharStar),
                    TotalStar = o.Average(o => o.TotalStar)
                });
                    
            if (group.Count() == 0)
                throw new Exception("找不到该老师");
            return group.First();
            
        }

        public void AddTeachStar(TeachStar ts)
        {
            if (_ctx.TeachStars == null)
                throw new Exception("teachstar is null");
            ts.Id = Guid.NewGuid().ToString();
            ts.TotalStar = (ts.ScoreStar + ts.TeachingStar + ts.TaskStar + ts.CommStar) / 4.0;
            _ctx.TeachStars.Add(ts);
            _ctx.SaveChanges();
        }

        public void AddCompStar(CompStar cs)
        {
            if (_ctx.CompStars == null)
                throw new Exception("compstar is null");
            cs.Id = Guid.NewGuid().ToString();
            cs.TotalStar = (cs.ResStar + cs.ExpStar + cs.FundsStar + cs.TeachingStar) / 4.0;
            _ctx.CompStars.Add(cs);
            _ctx.SaveChanges();
        }

        public void AddRSRCHStar(RSRCHStar rs)
        {
            if (_ctx.RSRCHStars == null)
                throw new Exception("RSRCHStar is null");
            rs.Id = Guid.NewGuid().ToString();
            rs.TotalStar = (rs.ACStar + rs.CharStar + rs.FundsStar + rs.ResStar) / 4.0;
            _ctx.RSRCHStars.Add(rs);
            _ctx.SaveChanges();
        }

        

        

    }

   

}
