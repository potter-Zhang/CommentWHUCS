using CommentWHUCS.Models.DAO;
using Microsoft.AspNetCore.Mvc;

namespace CommentWHUCS.Models.Services
{
    //返回前端的科研成果信息类
    public class RSRCHInfoNew
    {
        public string Id { get; set; }
        public string TeacherName { get; set; }
        public string GeneralDir { get; set; }   //科研大方向
        public string DetailedDir { get; set; }  //科研小方向
        public int Year { get; set; }
        public string Achievement { get; set; }
    }

    //返回前端的科研团队信息类
    public class RSRCHGroupNew
    {
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public string TeacherName { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }

    public class RSRCHInfoService
    {
        readonly CWCDbContext dbContext;
        public RSRCHInfoService(CWCDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //获取对应类型的科研成果
        public List<RSRCHInfoNew> SearchRInfo(string RSRCHTypeId)
        {
            var query = from r in dbContext.RSRCHInfos
                        from i in dbContext.RSRCHTypes
                        join t in dbContext.Teachers on r.TeacherId equals t.TeacherId
                        where r.RSRCHTypeId == RSRCHTypeId && i.Id == RSRCHTypeId
                        select new RSRCHInfoNew
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
        public void AddRInfo(bool userType, string teacherId, string RSRCHTypeId, int year, string achievement)
        {
            if (!userType)
                throw new Exception("您不是教师用户，不能进行此操作");


            var query = dbContext.RSRCHInfos.SingleOrDefault(r => r.TeacherId == teacherId && r.RSRCHTypeId == RSRCHTypeId && r.Year == year && r.Achievement == achievement);
            if (query != null)
                throw new Exception("此科研成果已存在！");

            RSRCHInfo newInfo = new RSRCHInfo(teacherId, RSRCHTypeId, year, achievement);
            dbContext.RSRCHInfos.Add(newInfo);
            dbContext.SaveChanges();    
        }

        //获取对应类型的科研团队信息
        public List<RSRCHGroupNew> SearchRGroup(string RSRCHTypeId)
        {
            var query = from r in dbContext.RSRCHGroups
                        join p in dbContext.PartRSRCHes on r.GroupId equals p.GroupId
                        join t in dbContext.Teachers on r.TeacherId equals t.TeacherId
                        where p.TypeId == RSRCHTypeId
                        select new RSRCHGroupNew
                        {
                            GroupId = r.GroupId,
                            GroupName = r.GroupName,
                            TeacherName = t.Name,
                            Title = r.Title,
                            Text = r.Text
                        };

            return query.ToList<RSRCHGroupNew>();
        }

        // 申请发起科研团队招募（只有教师身份的用户可以进行此操作）
        public void AddRGroup(bool userType, string RSRCHTypeId, string groupName, string teacherId, string title, string text, List<string>? otherTypes/*这里用是否能用List存疑*/)
        {
            if (!userType)
                throw new Exception("您不是教师用户，不能进行此操作");

            var queryTeacher = dbContext.Teachers.SingleOrDefault(t => t.TeacherId == teacherId);
            if (queryTeacher == null)
                throw new Exception("您输入的教师Id无效");  //这里的教师id不是教师用户的id。之后还需要根据前端具体情况做调整

            var queryGroup = dbContext.RSRCHGroups.SingleOrDefault(g => g.GroupName == groupName && g.TeacherId == teacherId && g.Title == title && g.Text == text);
            if (queryGroup != null)
                throw new Exception("此科研团队已存在！");

            RSRCHGroup group = new RSRCHGroup(groupName, teacherId, title, text);
            dbContext.RSRCHGroups.Add(group);

            PartRSRCH partRSRCH = new PartRSRCH(group.GroupId, RSRCHTypeId);
            dbContext.PartRSRCHes.Add(partRSRCH);
            PartRSRCH partRSRCHNew;
            foreach (string type in otherTypes)
            {
                var queryType = dbContext.RSRCHTypes.SingleOrDefault(t => t.DetailedDir == type);
                if (queryType == null)
                    throw new Exception("输入的类型不在已有类型中！");
                partRSRCHNew = new PartRSRCH(group.GroupId, queryType.Id);
                dbContext.PartRSRCHes.Add(partRSRCHNew);
            }

            dbContext.SaveChanges();
        }
    }
}
