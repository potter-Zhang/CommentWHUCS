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
    public class TeachersSearchController : ControllerBase
    {
        private readonly CWCDbContext _dbContext;
        private TeacherService teacherService;

        public TeachersSearchController(CWCDbContext context)
        {
            _dbContext = context;
            teacherService = new TeacherService(_dbContext);
        }

        // GET: api/TeachersSearch
        [HttpGet]
        public ActionResult<List<Teacher>> GetTeachers(string name = "", string title = "")
        {
            try
            {
                return teacherService.Search(name, title);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
