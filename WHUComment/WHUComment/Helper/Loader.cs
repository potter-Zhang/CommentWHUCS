using CommentWHUCS.Models;
using CommentWHUCS.Helper;

namespace CommentWHUCS.Helper
{
    public class Loader
    {
        public static void ConfigContext(CWCDbContext _ctx)
        {
            Searcher.ConfigContext(_ctx);
            Inserter.ConfigContext(_ctx);
            Updater.ConfigContext(_ctx);
        }
    }
}
