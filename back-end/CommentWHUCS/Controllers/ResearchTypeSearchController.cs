using CommentWHUCS.Models;
using CommentWHUCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace CommentWHUCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResearchTypeSearchController : ControllerBase
    {
        readonly ResearchTypeSearchService rTypeSearch;
        public ResearchTypeSearchController(ResearchTypeSearchService rTypeSearch)
        {
            this.rTypeSearch = rTypeSearch;
        }

        //根据点击前端的条件查询符合条件的科研类型
        // GET: api/<ResearchTypeSearchController >
        [HttpGet]
        public ActionResult<List<ResearchType>> GetRSRCHType(string? generalDir, string? searchText)
        {
            return rTypeSearch.SearchRType(generalDir, searchText);
        }
    }
}
