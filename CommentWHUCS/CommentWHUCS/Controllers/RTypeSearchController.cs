using CommentWHUCS.Models;
using CommentWHUCS.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace CommentWHUCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RTypeSearchController : ControllerBase
    {
        readonly RTypeSearchService rTypeSearch;
        public RTypeSearchController(RTypeSearchService rTypeSearch)
        {
            this.rTypeSearch = rTypeSearch;
        }

        //根据点击前端的条件查询符合条件的科研类型
        // GET: api/<RTypeSearchController>
        [HttpGet]
        public ActionResult<List<RSRCHType>> GetRSRCHType(string? generalDir, string? searchText)
        {
            return rTypeSearch.SearchRType(generalDir, searchText);
        }
    }
}
