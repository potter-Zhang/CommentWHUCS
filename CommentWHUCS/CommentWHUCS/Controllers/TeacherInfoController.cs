using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommentWHUCS.Models;
using CommentWHUCS.Models.DAO;
using CommentWHUCS.Models.Service;
using Microsoft.Identity.Client;

namespace CommentWHUCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherInfoController : ControllerBase
    {
        private readonly CWCDbContext _context;
        private StarService starService;
        private CommentService commentService;
        public TeacherInfoController(CWCDbContext context)
        {
            _context = context;
            starService = new StarService(context);
            commentService = new CommentService(context);
        }

        [HttpGet("compstars")]
        public ActionResult<CompStar> GetCompStars(string teacherId)
        {
            try
            {
                return starService.SearchCompStar(teacherId);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("teachstars")]
        public ActionResult<TeachStar> GetTeachStars(string teacherId)
        {
            try
            {
                return starService.SearchTeachStar(teacherId);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("RSRCHStars")]
        public ActionResult<RSRCHStar> GetRSRCHStars(string teacherId)
        {
            try
            {
                return starService.SearchRSRCHStar(teacherId);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("compstars")]
        public ActionResult PostCompStar(CompStar compStar)
        {
            try
            {
                starService.AddCompStar(compStar);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("teachstars")]
        public ActionResult PostTeachStar(TeachStar teachStar)
        {
            try
            {
                starService.AddTeachStar(teachStar);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("RSRCHstars")]
        public ActionResult PostRSRCHStar(RSRCHStar RSRCHstar)
        {
            try
            {
                starService.AddRSRCHStar(RSRCHstar);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("comments time")]
        public ActionResult<List<Comment>> GetCommentOrderByTime(string teacherId, string commentType)
        {
            try
            {
                return commentService.SearchCommentsOrderByTime(teacherId, commentType);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("comments like")]
        public ActionResult<List<Comment>> GetCommentOrderByLikes(string teacherId, string commentType)
        {
            try
            {
                return commentService.SearchCommentsOrderByLikes(teacherId, commentType);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("comment")] 
        public ActionResult<Comment> PostComment(Comment comment)
        {
            try
            {
                return commentService.AddComment(comment);
                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("like")]
        public ActionResult<Comment> PutLikes(Comment comment) 
        { 
            try
            {
                return commentService.AddLike(comment);
                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("comment userId")] 
        public ActionResult<Comment> GetCommentByUserId(string userId) 
        { 
            try
            {
                return commentService.SearchByUserId(userId);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
