using CommentWHUCS.Controllers;
using CommentWHUCS.DAO;
using CommentWHUCS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommentWHUCS.Services
{
    public class CompetitionInfoService
    {
        readonly CWCDbContext dbContext;
        public CompetitionInfoService(CWCDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //查询该类型竞赛的竞赛得奖信息
        public List<CompetitionAward> SearchCompAwardInfo(string compTypeId)
        {
            if (dbContext.CompetitionAwards == null)
                throw new Exception("CompAwardInfo is null");
            return dbContext.CompetitionAwards.Where(o => o.CompetitionTypeId == compTypeId).ToList();
        }

        //添加得奖信息
        public CompetitionAward AddCompAwardInfo(CompetitionAward compAwardInfo)
        {

            if (dbContext.CompetitionAwards == null)
                throw new Exception("CompAwardInfo is null");
            compAwardInfo.CompetitionId = Guid.NewGuid().ToString();
            dbContext.CompetitionAwards.Add(compAwardInfo);
            dbContext.SaveChanges();
            return compAwardInfo;
        }

        //查询该类型竞赛的竞赛招募信息（团队信息）
        public List<CompetitionGroup> SearchCompGroup(string TypeId)
        {
            var query = from c in dbContext.CompetitionGroups
                        where c.CompetitionTypeId == TypeId
                        select c;

            return query.ToList<CompetitionGroup>();
        }

        //团队的发起
        public void AddCompGroup(string competitionTypeId, string groupName, string participants, string text)
        {
            var queryGroup = dbContext.CompetitionGroups.SingleOrDefault(g => g.GroupName == groupName && g.Participants == participants && g.Text == text);
            if (queryGroup != null)
                throw new Exception("此竞赛团队已存在！");

            CompetitionGroup group = new CompetitionGroup(groupName, competitionTypeId, participants, text);
            dbContext.CompetitionGroups.Add(group);

            dbContext.SaveChanges();
        }
    }
}
