using CommentWHUCS.DAO;
using CommentWHUCS.Models;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace CommentWHUCS.Services
{
    public class CommentService
    {
        private CWCDbContext _ctx;
        //private string _userId;
        //private string _teacherId;
        public CommentService(CWCDbContext ctx)
        {
            _ctx = ctx;
        }

        /*
        public void SaveIds(string uid, string tid)
        {
            _userId = uid;
            _teacherId = tid;
        }
        */

        // 时间顺序返回评论
        public List<Comment> SearchCommentsOrderByTime(string teacherId, string commentType)
        {
            if (_ctx.Comments == null)
                throw new Exception("comments is null");
            return _ctx.Comments.Where(o => o.TeacherId == teacherId && o.CommentType == commentType)
                                .OrderByDescending(o => o.Time)
                                .ToList();
        }

        // 点赞数量返回评论
        public List<Comment> SearchCommentsOrderByLikes(string teacherId, string commentType)
        {
            if (_ctx.Comments == null)
                throw new Exception("comments is null");
            return _ctx.Comments.Where(o => o.TeacherId == teacherId && o.CommentType == commentType)
                                .OrderByDescending(o => o.LikeNum)
                                .ToList();
        }

        // 需要指定comment的userid，teacherid，commentType, content
        public Comment AddComment(Comment comment)
        {
            if (_ctx.Comments == null)
                throw new Exception("comments is null");
            comment.CommentId = Guid.NewGuid().ToString();
            comment.Time = DateTime.Now;
            comment.LikeNum = 0;
            _ctx.Comments.Add(comment);
            _ctx.SaveChanges();
            return comment;
        }

        // 增加一个like
        public Comment AddLike(Comment comment)
        {
            if (_ctx.Comments == null)
                throw new Exception("comments is null");
            _ctx.Comments.Attach(comment);
            comment.LikeNum++;
            _ctx.SaveChanges();
            return comment;
        }

        public Comment SearchByCommentId(string commentId)
        {
            if (_ctx.Comments == null)
                throw new Exception("comments is null");
            var comments = _ctx.Comments.Where(o => o.CommentId == commentId);
            if (comments.Count() == 0)
                throw new Exception("comment not exists");
            return comments.First();

        }

        public Comment SearchByUserId(string userId)
        {
            if (_ctx.Comments == null)
                throw new Exception("comments is null");
            var comments = _ctx.Comments.Where(o => o.UserId == userId);
            if (comments.Count() == 0)
                throw new Exception("user's comment not found");
            return comments.First();
        }




    }
}
