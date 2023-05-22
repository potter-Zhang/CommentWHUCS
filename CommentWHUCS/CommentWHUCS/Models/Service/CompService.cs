using CommentWHUCS.Models.DAO;

namespace CommentWHUCS.Models.Service
{
    public class CompService
    {
        private CWCDbContext _ctx;

        public CompService(CWCDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<CompType> Search(string name = "", string firstType = "", string secondType = "", string BonusType = "")
        {
            if (_ctx.CompTypes == null)
                throw new Exception("compType is null");
            return _ctx.CompTypes.Where(o => o.CompName.Contains(name) && o.FirstType.Contains(firstType) && 
                o.SecondType.Contains(secondType) && o.BonusType.Contains(BonusType)).ToList();
        }
    }
}
