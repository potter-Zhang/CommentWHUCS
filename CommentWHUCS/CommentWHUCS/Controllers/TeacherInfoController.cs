using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommentWHUCS.Models;
using Microsoft.Identity.Client;
using CommentWHUCS.Services;

namespace CommentWHUCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherInfoController : ControllerBase
    {
        private StarService starService;
        private CommentService commentService;
        public TeacherInfoController(StarService starService, CommentService commentService)
        {
            this.starService = starService;
            this.commentService = commentService;
        }

        // 返回一个CompStar对象，其中各个维度的星级都是平均值(其中只有totalstar是double，别的为int)，teacherId属性则和参数一致
        [HttpGet("compstars")]
        public ActionResult<CompetitionStar> GetCompStars(string teacherId)
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

        // 返回一个TeachStar对象，其中各个维度的星级都是平均值(其中只有totalstar是double，别的为int)，teacherId属性则和参数一致
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


        // 返回一个RSRCHStar对象，其中各个维度的星级都是平均值(其中只有totalstar是double，别的为int)，teacherId属性则和参数一致
        [HttpGet("RSRCHStars")]
        public ActionResult<ResearchStar> GetRSRCHStars(string teacherId)
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

        // Id和totalStar会自动分配和计算（totalstar会设置为四个星级的平均值）返回新添加的星级对象
        [HttpPost("compstars")]
        public ActionResult<CompetitionStar> PostCompStar(string teacherId, string userId, int expStar, int fundsStar, 
            int resStar, int teachingStar)
        {
            try
            {
                return starService.AddCompStar(new CompetitionStar
                {
                    TeacherId = teacherId,
                    UserId = userId,
                    ExpStar = expStar,
                    FundsStar = fundsStar,
                    ResStar = resStar,
                    TeachingStar = teachingStar
                });
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Id和totalStar会自动分配和计算（totalstar会设置为四个星级的平均值）返回新添加的星级对象
        [HttpPost("teachstars")]
        public ActionResult<TeachStar> PostTeachStar(string teacherId, string userId, int scoreStar, int teachingStar,
            int taskStar, int commStar )
        {
            try
            {
                return starService.AddTeachStar(new TeachStar
                {
                    TeacherId = teacherId,
                    UserId = userId,
                    ScoreStar = scoreStar,
                    TeachingStar = teachingStar,
                    TaskStar = taskStar,
                    CommStar = commStar
                });
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Id和totalStar会自动分配和计算（totalstar会设置为四个星级的平均值）返回新添加的星级对象
        [HttpPost("RSRCHstars")]
        public ActionResult<ResearchStar> PostRSRCHStar(string teacherId, string userId, int acStar, 
            int fundsStar, int resStar, int charStar)
        {
            try
            {
                return starService.AddRSRCHStar(new ResearchStar {     
                    TeacherId = teacherId,                                               
                    UserId = userId,                                               
                    ACStar = acStar,                                               
                    FundsStar = fundsStar,                                               
                    ResStar = resStar,                            
                    CharStar = charStar
                });
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // 返回按照时间排序的comment列表(降序排列)
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

        // 返回按照likes排序的comment列表(降序排列)
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

        // 添加新添加的评论，其中commentId会自动分配，评论时间就是now，评论的点赞数是0
        // 返回新添加的评论
        [HttpPost("comment")] 
        public ActionResult<Comment> PostComment(string teacherId, string userId, string commentType, string content)
        {
            try
            {
                return commentService.AddComment(new Comment {  TeacherId = teacherId, 
                                                                UserId = userId, 
                                                                CommentType = commentType,
                                                                Content = content
                });    
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // 点赞
        [HttpPut("like")]
        public ActionResult<Comment> PutLikes(string commentId) 
        { 
            try
            {
                return commentService.AddLike(commentService.SearchByCommentId(commentId));  
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // 通过userId寻找评论
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
