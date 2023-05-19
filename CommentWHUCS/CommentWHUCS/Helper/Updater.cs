using CommentWHUCS.Models;
using CommentWHUCS.Helper;

namespace CommentWHUCS.Helper
{
    public class Updater
    {
        public static CWCDbContext ctx;
        public static void ConfigContext(CWCDbContext _ctx)
        {
            ctx = _ctx;
        }

        public static void UpdateLikeNum(string commentId)
        {
            Comment comment = Searcher.SearchCommentById(commentId);
            ctx.Comments.Attach(comment);
            comment.LikeNum++;
            ctx.SaveChanges();

        }
    }
}
