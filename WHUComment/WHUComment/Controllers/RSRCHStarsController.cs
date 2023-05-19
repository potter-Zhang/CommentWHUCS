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
    public class RSRCHStarsController : ControllerBase
    {
        private readonly CWCDbContext _context;

        public RSRCHStarsController(CWCDbContext context)
        {
            _context = context;
            Searcher.ConfigContext(context);
            Inserter.ConfigContext(context);
        }

        [HttpGet("average")]
        public ActionResult<double> GetAverageRSRCHStars(string teacherId)
        {
            if (_context.TeachStars == null)
            {
                return NotFound();
            }
            return Searcher.SearchAverageRSRCHStar(teacherId);
        }

        [HttpPost]
        public void PostRSRCHStars(RSRCHStar rsrchStar)
        {
            Inserter.AddRSRCHStar(rsrchStar);
        }
    }
}
