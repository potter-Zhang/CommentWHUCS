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
    public class CompTypesController : ControllerBase
    {
        private readonly CWCDbContext _context;

        public CompTypesController(CWCDbContext context)
        {
            _context = context;
            Inserter.ConfigContext(context);
            Searcher.ConfigContext(context);
        }

        [HttpGet]
        public ActionResult<List<CompType>> GetCompTypeIds(string name = "", string firstType = "", string secondType = "", string BonusType = "")
        {
            if (_context.PartComps == null)
            {
                return NotFound();
            }
            return Searcher.SearchCompType(name, firstType, secondType, BonusType);
        }

    }
}
