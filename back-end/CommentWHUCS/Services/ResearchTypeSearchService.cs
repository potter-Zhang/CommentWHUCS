using CommentWHUCS.DAO;
using CommentWHUCS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommentWHUCS.Services
{
    public class ResearchTypeSearchService
    {
        readonly CWCDbContext dbContext;
        public ResearchTypeSearchService(CWCDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //根据点击前端的条件查询符合条件的科研类型
        public List<ResearchType> SearchRType(string? generalDir, string? searchText)
        {
            var query = from r in dbContext.ResearchTypes
                        where generalDir == null || r.GeneralDir == generalDir
                        where searchText == null || r.GeneralDir.Contains(searchText) || r.DetailedDir.Contains(searchText)  //模糊匹配
                        select r;

            return query.ToList();
        }
    }
}
