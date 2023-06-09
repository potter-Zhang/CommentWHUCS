using CommentWHUCS.DAO;
using CommentWHUCS.Models;
using System.Data.Entity;

namespace CommentWHUCS.Services
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

        public CompetitionStar SearchCompStar(string teacherId)
        {
            if (_ctx.CompetitionStars == null)
                throw new Exception("compstar is null");
            var group = _ctx.CompetitionStars
                .Where(o => o.TeacherId == teacherId)
                .GroupBy(o => o.TeacherId)
                .Select(o => new CompetitionStar
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

        public ResearchStar SearchRSRCHStar(string teacherId)
        {
            if (_ctx.ResearchStars == null)
                throw new Exception("RSRCHStar is null");
            var group = _ctx.ResearchStars
                .Where(o => o.TeacherId == teacherId)
                .GroupBy(o => o.TeacherId)
                .Select(o => new ResearchStar
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
                throw new Exception("can't find RSRCHstar of this teacher");
            return group.First();

        }

        public TeachStar AddTeachStar(TeachStar ts)
        {
            if (_ctx.TeachStars == null)
                throw new Exception("teachstar is null");
            ts.Id = Guid.NewGuid().ToString();
            ts.TotalStar = (ts.ScoreStar + ts.TeachingStar + ts.TaskStar + ts.CommStar) / 4.0;
            _ctx.TeachStars.Add(ts);
            _ctx.SaveChanges();
            return ts;
        }

        public CompetitionStar AddCompStar(CompetitionStar cs)
        {
            if (_ctx.CompetitionStars == null)
                throw new Exception("compstar is null");
            cs.Id = Guid.NewGuid().ToString();
            cs.TotalStar = (cs.ResStar + cs.ExpStar + cs.FundsStar + cs.TeachingStar) / 4.0;
            _ctx.CompetitionStars.Add(cs);
            _ctx.SaveChanges();
            return cs;
        }

        public ResearchStar AddRSRCHStar(ResearchStar rs)
        {
            if (_ctx.ResearchStars == null)
                throw new Exception("RSRCHStar is null");
            rs.Id = Guid.NewGuid().ToString();
            rs.TotalStar = (rs.ACStar + rs.CharStar + rs.FundsStar + rs.ResStar) / 4.0;
            _ctx.ResearchStars.Add(rs);
            _ctx.SaveChanges();
            return rs;
        }





    }



}
