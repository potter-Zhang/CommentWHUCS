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
    public class TeachStarsController : ControllerBase
    {
        private readonly CWCDbContext _context;

        public TeachStarsController(CWCDbContext context)
        {
            _context = context;
            Searcher.ConfigContext(context);
            Inserter.ConfigContext(context);
        }
        /*
        // GET: api/TeachStars
        [HttpGet("teachstar")]
        public ActionResult<List<TeachStar>> GetTeachStars(string teacherId)
        {
          if (_context.TeachStars == null)
          {
              return NotFound();
          }
            return Searcher.SearchTeachStar(teacherId);
        }
        */
        [HttpGet("average")]
        public ActionResult<double> GetAverageTeachStars(string teacherId)
        {
            if (_context.TeachStars == null)
            {
                return NotFound();
            }
            return Searcher.SearchAverageTeachStar(teacherId);
        }

        [HttpPost]
        public void PostTeachStars(TeachStar teachStar)
        {
            Inserter.AddTeachStar(teachStar);
        }

    }
}
