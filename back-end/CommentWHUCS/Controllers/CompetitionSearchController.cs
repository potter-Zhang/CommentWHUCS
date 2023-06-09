using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommentWHUCS.Models;
using CommentWHUCS.Services;

namespace CommentWHUCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionSearchController : ControllerBase
    {
        private CompetitionSearchService compService;

        public CompetitionSearchController(CompetitionSearchService compService)
        {
            this.compService = compService;
        }

        [HttpGet("comptype")]
        // 查询竞赛类型信息
        public ActionResult<List<CompetitionType>> GetCompType(string name = "", string firstType = "", string secondType = "", string BonusType = "")
        {
            try
            {
                return compService.Search(name, firstType, secondType, BonusType);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
