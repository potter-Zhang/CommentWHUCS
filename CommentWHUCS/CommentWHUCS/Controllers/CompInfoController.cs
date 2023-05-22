using CommentWHUCS.Models;
using CommentWHUCS.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace CommentWHUCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompInfoController : ControllerBase
    {
        readonly CompInfoService service;
        public CompInfoController(CompInfoService service)
        {
            this.service = service;
        }


        //查询该类型竞赛的竞赛招募信息（团队信息）
        // GET api/<CompGroupController>/CompTypeId
        [HttpGet("{CompTypeId}")]
        public ActionResult<List<CompGroupNew>> GetCompGroup(string CompTypeId)
        {
            return service.SearchCompGroup(CompTypeId);
        }

        //团队的发起
        // POST api/<GroupController>
        [HttpPost]
        public ActionResult PostCompGroup(string CompTypeId, string groupName, string ownerId, string title, string text, List<string> otherComps)
        {
            try
            {
                service.AddCompGroup(CompTypeId, groupName, ownerId, title, text, otherComps);
                return Content("添加竞赛团队成功！");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        } 
    }
}
