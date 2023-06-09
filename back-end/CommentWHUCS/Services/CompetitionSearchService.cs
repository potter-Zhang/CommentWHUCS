using CommentWHUCS.DAO;
using CommentWHUCS.Models;

namespace CommentWHUCS.Services
{
    public class CompetitionSearchService
    {
        private CWCDbContext _ctx;

        public CompetitionSearchService(CWCDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<CompetitionType> Search(string name = "", string firstType = "", string secondType = "", string BonusType = "")
        {
            if (_ctx.CompetitionTypes == null)
                throw new Exception("compType is null");
            return _ctx.CompetitionTypes.Where(o => o.CompetitionName.Contains(name) && (firstType == "" || o.FirstType == firstType) &&
                o.SecondType.Contains(secondType) && o.BonusType.Contains(BonusType)).ToList();
        }
    }
}
