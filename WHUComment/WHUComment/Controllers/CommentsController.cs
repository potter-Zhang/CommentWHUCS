using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommentWHUCS.Models;
using CommentWHUCS.Helper;


namespace WHUComment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CWCDbContext _context;

        public CommentsController(CWCDbContext context)
        {
            _context = context;
            Loader.ConfigContext(context);
        }

        // GET: api/Teachers
        [HttpGet("time")]
        public ActionResult<List<Comment>> GetCommentsInTime(string commentType = "", string TeacherId = "")
        {
            if (_context.Teachers == null)
            {
                return NotFound();
            }


            return Searcher.SearchCommentsInTime(commentType, TeacherId);//_context.Teachers.ToListAsync();
        }

        [HttpGet("likes")]
        public ActionResult<List<Comment>> GetCommentsInLike(string commentType = "", string TeacherId = "")
        {
            if (_context.Teachers == null)
            {
                return NotFound();
            }


            return Searcher.SearchCommentsInLikes(commentType, TeacherId);//_context.Teachers.ToListAsync();
        }

        [HttpPost]
        public void PostComments(Comment comment)
        {
            Inserter.AddComment(comment);
        }

        [HttpPut]
        public void AddLikes(string commentId)
        {
            Updater.UpdateLikeNum(commentId);
        }

    }
}
