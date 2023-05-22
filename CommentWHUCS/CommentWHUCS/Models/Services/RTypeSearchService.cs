using CommentWHUCS.Models.DAO;
using Microsoft.AspNetCore.Mvc;

namespace CommentWHUCS.Models.Services
{
    public class RTypeSearchService
    {
        readonly CWCDbContext dbContext;
        public RTypeSearchService(CWCDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //根据点击前端的条件查询符合条件的科研类型
        public List<RSRCHType> SearchRType(string? generalDir, string? searchText)
        {
            var query = from r in dbContext.RSRCHTypes
                        where (generalDir == null) || r.GeneralDir == generalDir
                        where (searchText == null) || r.GeneralDir.Contains(searchText) || r.DetailedDir.Contains(searchText)  //模糊匹配
                        select r;

            return query.ToList<RSRCHType>();
        }
    }
}
