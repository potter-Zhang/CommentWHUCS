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
    public class TeachersSearchController : ControllerBase
    {
        private TeacherService teacherService;

        public TeachersSearchController(TeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        // GET: api/TeachersSearch
        // 根据name和title返回teacher列表
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
