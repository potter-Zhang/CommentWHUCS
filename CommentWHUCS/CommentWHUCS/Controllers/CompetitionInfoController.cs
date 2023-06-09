using CommentWHUCS.Models;
using CommentWHUCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace CommentWHUCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionInfoController : ControllerBase
    {
        readonly CompetitionInfoService service;
        public CompetitionInfoController(CompetitionInfoService service)
        {
            this.service = service;
        }


        //查询该类型竞赛的竞赛招募信息（团队信息）
        // GET api/<CompetitionInfoController>/Award/CompTypeId
        [HttpGet("Award/{CompTypeId}")]
        public ActionResult<List<CompetitionAward>> GetCompAward(string CompTypeId)
        {
            return service.SearchCompAwardInfo(CompTypeId);
        }

        //查询该类型竞赛的竞赛招募信息（团队信息）
        // GET api/<CompetitionInfoController>/Group/CompTypeId
        [HttpGet("Group/{CompTypeId}")]
        public ActionResult<List<CompetitionGroup>> GetCompGroup(string CompTypeId)
        {
            return service.SearchCompGroup(CompTypeId);
        }

        //添加得奖信息
        // POST api/Award/<CompetitionInfoController>
        [HttpPost("Award")]
        public ActionResult<CompetitionAward> PostCompAward(CompetitionAward compAwardInfo)
        {
            try
            {
                return service.AddCompAwardInfo(compAwardInfo);    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //团队的发起
        // POST api/Group/<CompetitionInfoController>
        [HttpPost("Group")]
        public ActionResult PostCompGroup(string CompTypeId, string groupName, string participants, string text)
        {
            try
            {
                service.AddCompGroup(CompTypeId, groupName, participants, text);
                return Content("添加竞赛团队成功！");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
