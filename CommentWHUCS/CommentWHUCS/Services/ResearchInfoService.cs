using CommentWHUCS.DAO;
using CommentWHUCS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommentWHUCS.Services
{
    //返回前端的科研成果信息类
    public class ResearchAchievementNew
    {
        public string Id { get; set; }
        public string TeacherName { get; set; }
        public string GeneralDir { get; set; }   //科研大方向
        public string DetailedDir { get; set; }  //科研小方向
        public int Year { get; set; }
        public string Achievement { get; set; }
    }

    public class ResearchInfoService
    {
        readonly CWCDbContext dbContext;
        public ResearchInfoService(CWCDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //获取对应类型的科研成果
        public List<ResearchAchievementNew> SearchRInfo(string TypeId)
        {
            var query = from r in dbContext.ResearchAchievements
                        from i in dbContext.ResearchTypes
                        join t in dbContext.Teachers on r.TeacherId equals t.TeacherId
                        where r.ResearchTypeId == TypeId && i.Id == TypeId
                        select new ResearchAchievementNew
                        {
                            Id = r.Id,
                            TeacherName = t.Name,
                            GeneralDir = i.GeneralDir,
                            DetailedDir = i.DetailedDir,
                            Year = r.Year,
                            Achievement = r.Achievement
                        };
            return query.ToList();
        }

        //申请加入科研成果（只有教师身份的用户可以进行此操作）
        public void AddRInfo(bool userType, string teacherId, string TypeId, int year, string achievement)
        {
            if (!userType)
                throw new Exception("您不是教师用户，不能进行此操作");


            var query = dbContext.ResearchAchievements.SingleOrDefault(r => r.TeacherId == teacherId && r.ResearchTypeId == TypeId && r.Year == year && r.Achievement == achievement);
            if (query != null)
                throw new Exception("此科研成果已存在！");

            ResearchAchievement newInfo = new ResearchAchievement(teacherId, TypeId, year, achievement);
            dbContext.ResearchAchievements.Add(newInfo);
            dbContext.SaveChanges();
        }

        //获取对应类型的科研团队信息
        public List<ResearchGroup> SearchRGroup(string TypeId)
        {
            var query = from r in dbContext.ResearchGroups
                        join p in dbContext.ParticipateResearches on r.GroupId equals p.GroupId
                        where p.ResearchTypeId == TypeId
                        select r;

            return query.ToList();
        }

        // 申请发起科研团队招募（只有教师身份的用户可以进行此操作）
        public void AddRGroup(bool userType, string RSRCHTypeId, string groupName, string teachers, string text, List<string>? otherTypes/*这里用是否能用List存疑*/)
        {
            if (!userType)
                throw new Exception("您不是教师用户，不能进行此操作");

            var queryGroup = dbContext.ResearchGroups.SingleOrDefault(g => g.GroupName == groupName && g.Teachers == teachers  && g.Text == text);
            if (queryGroup != null)
                throw new Exception("此科研团队已存在！");

            ResearchGroup group = new ResearchGroup(groupName, teachers, text);
            dbContext.ResearchGroups.Add(group);

            ParticipateResearch partRSRCH = new ParticipateResearch(group.GroupId, RSRCHTypeId);
            dbContext.ParticipateResearches.Add(partRSRCH);
            ParticipateResearch partRSRCHNew;
            foreach (string type in otherTypes)
            {
                var queryType = dbContext.ResearchTypes.SingleOrDefault(t => t.DetailedDir == type);
                if (queryType == null)
                    throw new Exception("输入的类型不在已有类型中！");
                partRSRCHNew = new ParticipateResearch(group.GroupId, queryType.Id);
                dbContext.ParticipateResearches.Add(partRSRCHNew);
            }

            dbContext.SaveChanges();
        }
    }
}
