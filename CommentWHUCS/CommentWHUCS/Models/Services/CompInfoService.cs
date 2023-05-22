using CommentWHUCS.Controllers;
using CommentWHUCS.Models.DAO;
using Microsoft.AspNetCore.Mvc;

namespace CommentWHUCS.Models.Services
{
    public class CompGroupNew      //返回前端的竞赛团队信息类型
    {
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public string OwnerName { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }

    public class CompInfoService
    {
        readonly CWCDbContext dbContext;
        public CompInfoService(CWCDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //查询该类型竞赛的竞赛得奖信息
        public List<CompAwardInfo> SearchCompAwardInfo(string compId)
        {
            if (dbContext.CompAwardInfos == null)
                throw new Exception("CompAwardInfo is null");
            return dbContext.CompAwardInfos.Where(o => o.CompId == compId).ToList();
        }

        //添加得奖信息
        public void AddCompAwardInfo(CompAwardInfo compAwardInfo)
        {

            if (dbContext.CompAwardInfos == null)
                throw new Exception("CompAwardInfo is null");
            dbContext.CompAwardInfos.Add(compAwardInfo);
            dbContext.SaveChanges();
        }

        //查询该类型竞赛的竞赛招募信息（团队信息）
        public List<CompGroupNew> SearchCompGroup(string CompTypeId)
        {
            var query = from c in dbContext.CompGroups
                        join p in dbContext.PartComps on c.GroupId equals p.GroupId
                        join u in dbContext.Users on c.OwnerId equals u.UserId
                        where p.TypeId == CompTypeId
                        select new CompGroupNew
                        {
                            GroupId = c.GroupId,
                            GroupName = c.GroupName,
                            OwnerName = u.NickName,
                            Title = c.Title,
                            Text = c.Text
                        };

            return query.ToList<CompGroupNew>();
        }

        //团队的发起
        public void AddCompGroup(string CompTypeId, string groupName, string ownerId, string title, string text, List<string>? otherComps)
        {
            CompGroup group = new CompGroup(groupName, ownerId, title, text);
            dbContext.CompGroups.Add(group);

            var queryUser = dbContext.Users.SingleOrDefault(t => t.UserId == ownerId);
            if (queryUser == null)
                throw new Exception("您输入的用户Id无效");

            var queryGroup = dbContext.CompGroups.SingleOrDefault(g => g.GroupName == groupName && g.OwnerId == ownerId && g.Title == title && g.Text == text);
            if (queryGroup != null)
                throw new Exception("此竞赛团队已存在！");

            PartComp partComp = new PartComp(group.GroupId, CompTypeId);
            dbContext.PartComps.Add(partComp);
            PartComp partCompNew;
            foreach (string comp in otherComps)
            {
                var queryType = dbContext.CompTypes.SingleOrDefault(t => t.CompName == comp);
                if (queryType == null)
                    throw new Exception("输入的竞赛不在已有竞赛类型中！");
                partCompNew = new PartComp(group.GroupId, queryType.CompTypeId);
                dbContext.PartComps.Add(partCompNew);
            }

            dbContext.SaveChanges();
        }
    }
}
