using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommentWHUCS.Models;
using CommentWHUCS.Models.DAO;
using CommentWHUCS.Models.Service;

namespace CommentWHUCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompSearchController : ControllerBase
    {
        private readonly CWCDbContext _context;
        private CompService compService;

        public CompSearchController(CWCDbContext context)
        {
            _context = context;
            compService = new CompService(context);
        }

        [HttpGet("comptype")]
        public ActionResult<List<CompType>> GetCompType(string name = "", string firstType = "", string secondType = "", string BonusType = "")
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
