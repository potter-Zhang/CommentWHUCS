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
    public class CompStarsController : ControllerBase
    {
        private readonly CWCDbContext _context;

        public CompStarsController(CWCDbContext context)
        {
            _context = context;
            Searcher.ConfigContext(context);
            Inserter.ConfigContext(context);
        }

        /*
        // GET: api/TeachStars
        [HttpGet("compstar")]
        public ActionResult<List<CompStar>> GetCompStars(string teacherId)
        {
            if (_context.TeachStars == null)
            {
                return NotFound();
            }
            return Searcher.SearchCompStar(teacherId);
        }
        */

        [HttpGet("average")]
        public ActionResult<double> GetAverageCompStars(string teacherId)
        {
            if (_context.TeachStars == null)
            {
                return NotFound();
            }
            return Searcher.SearchAverageCompStar(teacherId);
        }

        [HttpPost]
        public void PostCompStars(CompStar compStar)
        {
            Inserter.AddCompStar(compStar);
        }
    }
}
