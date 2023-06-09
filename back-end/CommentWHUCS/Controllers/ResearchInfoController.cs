using CommentWHUCS.Models;
using CommentWHUCS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CommentWHUCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResearchInfoController : ControllerBase
    {
        readonly ResearchInfoService service;
        public ResearchInfoController(ResearchInfoService service)
        {
            this.service = service;
        }


        //获取对应类型的科研成果
        // GET api/<ResearchInfoController>/RSRCHTypeId
        [HttpGet("{RSRCHTypeId}")]
        public ActionResult<List<ResearchAchievementNew>> GetRSRCHInfo(string RSRCHTypeId)
        {
            return service.SearchRInfo(RSRCHTypeId);
        }

        // GET api/<ResearchInfoController>/Group/RSRCHTypeId
        [HttpGet("Group/{RSRCHTypeId}")]
        public ActionResult<List<ResearchGroup>> GetRSRCHGroup(string RSRCHTypeId)
        {
            return service.SearchRGroup(RSRCHTypeId);
        }

        //申请加入科研成果（只有教师身份的用户可以进行此操作）
        // POST api/<ResearchInfoController>
        [HttpPost]
        public ActionResult PostRSRCHInfo(bool userType, string teacherId, string RSRCHTypeId, int year, string achievement)
        {
            try
            {
                service.AddRInfo(userType, teacherId, RSRCHTypeId, year, achievement);
                return Content("添加成果成功");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //申请添加科研团队（只有教师身份的用户可以进行此操作）
        // POST api/<ResearchInfoController>/Group
        [HttpPost("Group")]
        public ActionResult PostRSRCHGroup(bool userType, string RSRCHTypeId, string groupName, string teachers, string text, List<string> otherTypes)
        {
            try
            {
                service.AddRGroup(userType, RSRCHTypeId, groupName, teachers, text, otherTypes);
                return Content("添加科研团队成功！");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}