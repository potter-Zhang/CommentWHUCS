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
    public class TeachersController : ControllerBase
    {
        private readonly CWCDbContext _context;
        

        public TeachersController(CWCDbContext context)
        {
            _context = context;
            Searcher.ConfigContext(context);
            Inserter.ConfigContext(context);
        }

        // GET: api/Teachers
        [HttpGet]
        public ActionResult<List<Teacher>> GetTeachers(string name = "", string title = "")
        {
            if (_context.Teachers == null)
            {
                return NotFound();
            }
            

            return Searcher.SearchTeachers(name, title);//_context.Teachers.ToListAsync();
        }

    }
}
