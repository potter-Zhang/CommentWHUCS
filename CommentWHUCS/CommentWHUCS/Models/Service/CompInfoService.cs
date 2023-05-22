using CommentWHUCS.Models.DAO;

namespace CommentWHUCS.Models.Service
{
    public class CompInfoService
    {
        private CWCDbContext _ctx;

        public CompInfoService(CWCDbContext ctx)
        {
            _ctx = ctx;
        } 

        public List<CompAwardInfo> SearchCompAwardInfo(string compId)
        {
            if (_ctx.CompAwardInfos == null)
                throw new Exception("CompAwardInfo is null");
            return _ctx.CompAwardInfos.Where(o => o.CompId == compId).ToList();
        }

        public void AddCompAwardInfo(CompAwardInfo compAwardInfo)
        {
            
            if (_ctx.CompAwardInfos == null)
                throw new Exception("CompAwardInfo is null");
            _ctx.CompAwardInfos.Add(compAwardInfo);
            _ctx.SaveChanges();
        }

     }
}
